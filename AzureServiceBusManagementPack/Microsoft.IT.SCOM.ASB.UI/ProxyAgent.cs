using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Globalization;
using Microsoft.EnterpriseManagement;
using Microsoft.EnterpriseManagement.Administration;
using Microsoft.EnterpriseManagement.Common;
using Microsoft.EnterpriseManagement.Configuration;
using Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Azure;
using Microsoft.EnterpriseManagement.Mom.Internal.UI.Common;
using Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls;
//using Microsoft.EnterpriseManagement.Mom.UI;
using Microsoft.EnterpriseManagement.Monitoring;
using Microsoft.EnterpriseManagement.Monitoring.Security;
using Microsoft.EnterpriseManagement.Security;
using Microsoft.EnterpriseManagement.UI;

namespace Microsoft.IT.SCOM.ASB.UI
{
    public partial class ProxyAgent : UIPage
    {
        private PartialMonitoringObject proxyAgentComputer;
        internal const string SharedUserDataProxyAgentComputerPrincipalName = "ProxyAgent.ProxyAgentComputerPrincipalName";
        internal const string SharedUserDataTemplateIdString = "ProxyAgent.TemplateIdString";
        private string templateIdString;

        private string ASBNamespaceName;
        private string runAsName;
        private byte[] runAsSsid;

        public ProxyAgent()
        {
            InitializeComponent();
        }

        private PartialMonitoringObject GetProxyAgentComputer(string proxyAgentComputerName)
        {
            if (base.ManagementGroup == null)
            {
                return null;
            }
            ManagementPackClass monitoringClass = base.ManagementGroup.EntityTypes.GetClass(SystemMonitoringClass.HealthService);
            if (monitoringClass == null)
            {
                return null;
            }

            List<PartialMonitoringObject> partialMonitoringObjects = new List<PartialMonitoringObject>();
            IObjectReader<PartialMonitoringObject> reader =
                ManagementGroup.EntityObjects.GetObjectReader<PartialMonitoringObject>(
                    new MonitoringObjectGenericCriteria(string.Format(CultureInfo.InvariantCulture, "Name = '{0}' OR DisplayName = '{0}'", new object[] { proxyAgentComputerName })), monitoringClass, ObjectQueryOptions.Default);
                 
            partialMonitoringObjects.AddRange(reader);
            
            if (partialMonitoringObjects.Count == 1)
            {
                return partialMonitoringObjects[0];
            }
            return null;
        }

        private void GetSharedUserData()
        {
            this.ASBNamespaceName = base.SharedUserData["ASBNamespaceDetails.ASBNamespaceName"] as string;
            this.runAsName = base.SharedUserData["ASBNamespaceDetails.RunAsName"] as string;
            this.runAsSsid = base.SharedUserData["ASBNamespaceDetails.RunAsSsid"] as byte[];

            this.proxyAgentComputer = this.GetProxyAgentComputer(this.proxyAgentBrowseTextBox.Text);
        }

        public override void LoadPageConfig()
        {
            if (base.IsCreationMode)
            {
                this.templateIdString = Guid.NewGuid().ToString("N");
            }
            else
            {
                if (string.IsNullOrEmpty(base.InputConfigurationXml))
                {
                    return;
                }
                try
                {
                    ProxyAgentConfig config = XmlHelper.Deserialize(base.InputConfigurationXml, typeof(ProxyAgentConfig), true) as ProxyAgentConfig;
                    this.templateIdString = config.TemplateIdString;
                    this.proxyAgentBrowseTextBox.Text = config.ProxyAgentComputerPrincipalName;

                    this.SetSharedUserData();
                }
                catch (ArgumentNullException exception)
                {
                    return;
                }
                catch (InvalidOperationException exception2)
                {
                    return;
                }
            }
            base.IsConfigValid = this.ValidatePageConfiguration();
            base.LoadPageConfig();
        }

        private void proxyAgentBrowseButton_Click(object sender, EventArgs e)
        {
            this.ShowComputerPickerDialog();
        }

        private bool RunAsAccountDistributionDialog()
        {
            this.GetSharedUserData();

            SecureData securedData = base.ManagementGroup.Security.GetSecureData(this.runAsSsid);
            if (securedData == null)
            {
                return false;
            }

            IApprovedHealthServicesForDistribution<PartialMonitoringObject> newState = base.ManagementGroup.Security.GetApprovedHealthServicesForDistribution<PartialMonitoringObject>(securedData);
            
            if (newState == null)
            {
                return false;
            }            
            bool flag2 = newState.Result.Equals(ApprovedHealthServicesResults.All) || newState.HealthServices.Contains(this.proxyAgentComputer);
            if (!flag2)
            {
                string text = string.Empty;
                StringBuilder builder = new StringBuilder();
                if (!flag2)
                {
                    builder.AppendLine(this.runAsName);
                }
                //TODO: Fix this language
                text = string.Format("To enable discovery of databases on SQL Azure Server <{0}>, the following Run As account must be distributed to the health service '{1}':\n\n{2}\n\nWould you like Operations Manager to distribute the accounts?", this.ASBNamespaceName, this.proxyAgentComputer.DisplayName, builder.ToString());
                if (MessageBox.Show(base.ParentForm, text, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                {
                    return false;
                }
                if (!flag2)
                {
                    newState.Result = ApprovedHealthServicesResults.Specified;
                    newState.HealthServices.Add(this.proxyAgentComputer);
                    base.ManagementGroup.Security.SetApprovedHealthServicesForDistribution<PartialMonitoringObject>(securedData, newState);
                }
            }
            return true;
        }

        public override bool SavePageConfig()
        {
            base.IsConfigValid = this.ValidatePageConfiguration();
            if (!base.IsConfigValid)
            {
                return false;
            }
            if (!this.RunAsAccountDistributionDialog())
            {
                return false;
            }
            ProxyAgentConfig config = new ProxyAgentConfig();
            config.TemplateIdString = this.templateIdString;
            config.ProxyAgentComputerPrincipalName = this.proxyAgentBrowseTextBox.Text;

            base.OutputConfigurationXml = XmlHelper.Serialize(config, true);
            this.SetSharedUserData();
            return true;
        }

        private void SetSharedUserData()
        {
            base.SharedUserData["ProxyAgent.TemplateIdString"] = this.templateIdString;
            base.SharedUserData["ProxyAgent.ProxyAgentComputerPrincipalName"] = this.proxyAgentBrowseTextBox.Text;
        }

        private void ShowComputerPickerDialog()
        {
            AgentSimpleChooserDialog dialog = new AgentSimpleChooserDialog(base.Container);
            dialog.ShowDialog(this);
            if (dialog.DialogResult == DialogResult.OK)
            {
                if (dialog.SelectedItems != null)
                {
                    ChooserControlItem selectedItem = dialog.SelectedItem as ChooserControlItem;
                    if ((selectedItem == null) || (selectedItem.Item == null))
                    {
                    }
                    else
                    {
                        ComputerHealthService item = selectedItem.Item as ComputerHealthService;
                        if (!string.IsNullOrEmpty(item.PrincipalName))
                        {
                            this.proxyAgentBrowseTextBox.Text = item.PrincipalName;
                        }
                    }
                }
            }
        }

        private bool ValidatePageConfiguration()
        {
            this.errorProvider.Clear();
            if (string.IsNullOrEmpty(this.proxyAgentBrowseTextBox.Text))
            {
                this.errorProvider.SetError(this.proxyAgentBrowseButton, string.Format(CultureInfo.CurrentUICulture, "Proxy agent must be selected", new object[0]));
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
