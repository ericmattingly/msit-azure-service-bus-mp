using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;

namespace Microsoft.IT.SCOM.ASB.UI
{
    [Serializable, XmlType(AnonymousType = true), XmlRoot(Namespace = "", IsNullable = false)]
    public class ASBNamespaceDetailsConfig
    {
         private string asbNamespaceName;
        private string runAsAccount;

        public ASBNamespaceDetailsConfig()
        {
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string ASBNamespaceName
        {
            get
            {
                return this.asbNamespaceName;
            }
            set
            {
                this.asbNamespaceName = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string RunAsAccount
        {
            get
            {
                return this.runAsAccount;
            }
            set
            {
                this.runAsAccount = value;
            }
        }  
    }
}
