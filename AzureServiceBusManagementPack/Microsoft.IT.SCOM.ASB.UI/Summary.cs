using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.EnterpriseManagement.Configuration;
using Microsoft.EnterpriseManagement.UI;
//using Microsoft.EnterpriseManagement.Mom.UI;

namespace Microsoft.IT.SCOM.ASB.UI
{
    public partial class Summary : UIPage
    {
        private string name;
        private string description;
        private ManagementPack outputManagementPack;
        private string asbNamespaceName;
        private string runAsName;
        private string proxyAgent;

        public Summary()
        {
            InitializeComponent();
        }

        private void AddSummaryItem(string name, string value)
        {
            ListViewItem item = new ListViewItem(name);
            item.SubItems.Add(value);
            this.summaryListView.Items.Add(item);
        }

        private void GetSharedUserData()
        {

            this.name = base.SharedUserData["NameAndDescriptionPage.Name"] as string;
            this.description = base.SharedUserData["NameAndDescriptionPage.Description"] as string;
            this.outputManagementPack = base.SharedUserData["NameAndDescriptionPage.ManagementPack"] as ManagementPack;
            this.asbNamespaceName = base.SharedUserData["ASBNamespaceDetails.ASBNamespaceName"] as string;
            this.runAsName = SharedUserData["ASBNamespaceDetails.RunAsName"] as string;
            this.proxyAgent = SharedUserData["ProxyAgent.ProxyAgentComputerPrincipalName"] as string;
        }

        public override bool OnSetActive()
        {
            this.GetSharedUserData();
            this.SetListViewItems();
            base.IsConfigValid = true;
            return base.OnSetActive();
        }


        private void SetListViewItems()
        {
            this.summaryListView.Items.Clear();
            base.IsConfigValid = false;
            this.AddSummaryItem("Name", this.name);
            if (!string.IsNullOrEmpty(this.description))
            {
                this.AddSummaryItem("Description", this.description);
            }
            if (base.DestinationManagementPack != null)
            {
                this.AddSummaryItem("Management Pack", base.DestinationManagementPack.DisplayName);
            }
            else if (this.outputManagementPack != null)
            {
                this.AddSummaryItem("Management Pack", this.outputManagementPack.DisplayName);
            }
            this.AddSummaryItem("Windows Azure Service Bus Namespace Name", this.asbNamespaceName);
            this.AddSummaryItem("Run As Account", this.runAsName);
            this.AddSummaryItem("Proxy Agent", this.proxyAgent);

            this.summaryListView.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.summaryListView.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
    }
}
