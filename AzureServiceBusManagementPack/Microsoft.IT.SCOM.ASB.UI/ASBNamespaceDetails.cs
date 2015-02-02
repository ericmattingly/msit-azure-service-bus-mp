using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using Microsoft.EnterpriseManagement.Mom.Internal.UI.Common;
//using Microsoft.EnterpriseManagement.Mom.UI;
using Microsoft.EnterpriseManagement.Monitoring.Security;
using Microsoft.EnterpriseManagement.Security;
using Microsoft.EnterpriseManagement.UI;

namespace Microsoft.IT.SCOM.ASB.UI
{
    public partial class ASBNamespaceDetails : UIPage
    {
        private List<SimpleRunAsAccount> runAsAccountList;

        public ASBNamespaceDetails()
        {
            InitializeComponent();
        }

        public override void LoadPageConfig()
        {
            if (!base.IsCreationMode)
            {
                if (string.IsNullOrEmpty(base.InputConfigurationXml))
                {
                    //Bid.TraceError("<ApplicationDetails.LoadPageConfig|ERR> input configuration xml is null\n");
                    return;
                }
                try
                {
                    Predicate<SimpleRunAsAccount> match = null;

                    ASBNamespaceDetailsConfig pageConfig = XmlHelper.Deserialize(base.InputConfigurationXml, typeof(ASBNamespaceDetailsConfig), true) as ASBNamespaceDetailsConfig;
                    this.PopulateRunAsComboBox();

                    this.asbNamespaceNameTextBox.Text = pageConfig.ASBNamespaceName;

                    if (string.IsNullOrEmpty(pageConfig.RunAsAccount))
                    {
                        this.runAsAccountComboBox.SelectedIndex = -1;
                    }
                    else
                    {
                        if (match == null)
                        {
                            match = delegate(SimpleRunAsAccount simpleAccount)
                            {
                                return simpleAccount.AccountStorageIdString.Equals(pageConfig.RunAsAccount);
                            };
                        }
                        this.runAsAccountComboBox.SelectedIndex = this.runAsAccountList.FindIndex(match);
                    }

                    this.SetSharedUserData();
                }
                catch (Exception exception)
                {
                    return;
                }
            }

            base.IsConfigValid = this.ValidatePageConfiguration();
            base.LoadPageConfig();

        }

        public override bool OnSetActive()
        {
            this.PopulateRunAsComboBox();
            return base.OnSetActive();
        }


        public override bool SavePageConfig()
        {
            base.IsConfigValid = this.ValidatePageConfiguration();
            if (!base.IsConfigValid)
            {
                return false;
            }
            ASBNamespaceDetailsConfig config = new ASBNamespaceDetailsConfig();

            config.ASBNamespaceName = this.asbNamespaceNameTextBox.Text.ToLowerInvariant();
            config.RunAsAccount = this.runAsAccountList[this.runAsAccountComboBox.SelectedIndex].AccountStorageIdString;

            base.OutputConfigurationXml = XmlHelper.Serialize(config, true);
            this.SetSharedUserData();
            return true;
        }

        private void PopulateRunAsComboBox()
        {
            if ((this.runAsAccountList != null) && (this.runAsAccountList.Count > 0))
            {
            }
            else
            {
                var monitoringSecureData = base.ManagementGroup.Security.GetSecureData();
                this.runAsAccountList = new List<SimpleRunAsAccount>();

                foreach (SecureData data in monitoringSecureData)
                {
                    if (data.SecureDataType.Equals(SecureDataType.Simple))
                    {
                        this.runAsAccountComboBox.Items.Add(data.Name);
                        this.runAsAccountList.Add(new SimpleRunAsAccount(data));
                    }
                }
            }
        }

        private void SetSharedUserData()
        {
            base.SharedUserData["ASBNamespaceDetails.ASBNamespaceName"] = this.asbNamespaceNameTextBox.Text;

            if (this.runAsAccountComboBox.SelectedIndex >= 0)
            {
                base.SharedUserData["ASBNamespaceDetails.RunAsId"] = this.runAsAccountList[this.runAsAccountComboBox.SelectedIndex].AccountStorageIdString;
                base.SharedUserData["ASBNamespaceDetails.RunAsName"] = this.runAsAccountList[this.runAsAccountComboBox.SelectedIndex].AccountName;
                base.SharedUserData["ASBNamespaceDetails.RunAsSsid"] = this.runAsAccountList[this.runAsAccountComboBox.SelectedIndex].AccountStorageIdByteArray;
            }
        }

        private bool ValidatePageConfiguration()
        {
            this.errorProvider.Clear();
            if (string.IsNullOrEmpty(this.asbNamespaceNameTextBox.Text.Trim()))
            {
                this.errorProvider.SetError(this.asbNamespaceNameTextBox, string.Format(CultureInfo.CurrentUICulture, "AppNameTextBoxWarning", new object[0]));
                return false;
            }
            if (this.runAsAccountComboBox.SelectedIndex < 0)
            {
                this.errorProvider.SetError(this.runAsAccountComboBox, string.Format(CultureInfo.CurrentUICulture, "AppNameTextBoxWarning", new object[0]));
                return false;
            }

            this.SetSharedUserData();
            return true;
        }

        private void ValidatePageConfigurationEventHandler(object sender, EventArgs e)
        {
            base.IsConfigValid = this.ValidatePageConfiguration();
        }
    }
}
