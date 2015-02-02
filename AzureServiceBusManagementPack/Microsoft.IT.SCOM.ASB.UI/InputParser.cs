using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Text.RegularExpressions;
using Microsoft.EnterpriseManagement.Common;
using Microsoft.EnterpriseManagement.Configuration;
using Microsoft.EnterpriseManagement.Internal.UI.Authoring.Extensibility;
using Microsoft.EnterpriseManagement.Mom.Internal.UI.Common;
using Microsoft.EnterpriseManagement.UI;

namespace Microsoft.IT.SCOM.ASB.UI
{
    public class InputParser : Component, IInputConfigurationParser
    {
        private const string ClassNamePrefix = "Microsoft.IT.SCOM.ASB.Namespace.";
        private const string DiscoveryNamePrefix = "Microsoft.IT.SCOM.ASB.InitialDiscovery.";
        private const string AccountOverrideNamePrefix = "Microsoft.IT.SCOM.ASB.RunAsProfile.Account.";
        private const string ValueNodeRegex = "<Value>([^<]*)</Value>";

        public InputParser(IContainer parentContainer)
        {
            if (parentContainer != null)
            {
                parentContainer.Add(this);
            }
        }

        private void GetDiscoveryConfig(ITemplateContext templateContext, ref TemplateInputConfig templateConfig)
        {
            if (templateContext == null)
            {
                throw new ArgumentNullException("templateContext");
            }
            foreach (ManagementPackDiscovery discovery in SDKHelper.GetFolderItems<ManagementPackDiscovery>(this, templateContext.OutputFolder))
            {
                if (discovery.Name.StartsWith(DiscoveryNamePrefix, StringComparison.OrdinalIgnoreCase))
                {
                    MatchCollection matchs = new Regex(ValueNodeRegex, RegexOptions.CultureInvariant | RegexOptions.Compiled).Matches(discovery.DataSource.Configuration);

                    templateConfig.ASBNamespaceName = matchs[0].Groups[1].Value;
                    templateConfig.ProxyAgentComputerPrincipalName = matchs[2].Groups[1].Value;
                    return;
                }
            }
            throw new ObjectNotFoundException("my message");
        }

        private void GetRunAsAccounts(ITemplateContext templateContext, ref TemplateInputConfig templateConfig)
        {
            if (templateContext == null)
            {
                throw new ArgumentNullException("templateContext");
            }

            ManagementPackElementCollection<ManagementPackSecureReferenceOverride> folderItems = SDKHelper.GetFolderItems<ManagementPackSecureReferenceOverride>(this, templateContext.OutputFolder);
            templateConfig.RunAsAccount = string.Empty;

            foreach (ManagementPackSecureReferenceOverride @override in folderItems)
            {
                if (@override.Name.StartsWith(AccountOverrideNamePrefix, StringComparison.OrdinalIgnoreCase))
                {
                    templateConfig.RunAsAccount = @override.Value;
                    break;
                }
            }
        }

        private string GetTemplateIdString(ITemplateContext templateContext)
        {
            if (templateContext == null)
            {
                throw new ArgumentNullException("templateContext");
            }
            foreach (ManagementPackClass class2 in SDKHelper.GetFolderItems<ManagementPackClass>(this, templateContext.OutputFolder))
            {
                if (class2.Name.StartsWith(ClassNamePrefix, StringComparison.OrdinalIgnoreCase))
                {
                    return class2.Name.Remove(0, ClassNamePrefix.Length);
                }
            }
            throw new ObjectNotFoundException();
        }

        public bool LoadConfigurationXml(IPageContext pageContext)
        {
            if (pageContext == null)
            {
                throw new ArgumentNullException("pageContext");
            }
            ITemplateContext templateContext = (ITemplateContext)pageContext;
            TemplateInputConfig templateConfig = new TemplateInputConfig
            {
                Name = templateContext.OutputFolder.DisplayName,
                Description = templateContext.OutputFolder.Description,
                TemplateIdString = this.GetTemplateIdString(templateContext)
            };
            this.GetDiscoveryConfig(templateContext, ref templateConfig);
            this.GetRunAsAccounts(templateContext, ref templateConfig);
            pageContext.ConfigurationXml = XmlHelper.Serialize(templateConfig, false);
            return true;
        }
    }
}
