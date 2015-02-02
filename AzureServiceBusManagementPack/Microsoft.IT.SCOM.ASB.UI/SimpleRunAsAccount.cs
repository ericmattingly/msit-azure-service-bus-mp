using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EnterpriseManagement.Monitoring.Security;
using System.Globalization;
using Microsoft.EnterpriseManagement.Security;

namespace Microsoft.IT.SCOM.ASB.UI
{
    class SimpleRunAsAccount
    {
        // Fields
        private Guid? accountId;
        private string accountName;
        private byte[] accountStorageIdByteArray;
        private string accountStorageIdString;

        // Methods
        internal SimpleRunAsAccount(SecureData account)
        {
            this.accountName = account.Name;
            this.accountId = account.Id;
            this.accountStorageIdByteArray = account.SecureStorageId;
            this.accountStorageIdString = string.Empty;
            foreach (byte num in this.accountStorageIdByteArray)
            {
                this.accountStorageIdString = this.accountStorageIdString + num.ToString("X2", CultureInfo.InvariantCulture);
            }
        }

        // Properties
        internal Guid? AccountId
        {
            get
            {
                return this.accountId;
            }
        }

        internal string AccountName
        {
            get
            {
                return this.accountName;
            }
        }

        internal byte[] AccountStorageIdByteArray
        {
            get
            {
                return this.accountStorageIdByteArray;
            }
        }

        internal string AccountStorageIdString
        {
            get
            {
                return this.accountStorageIdString;
            }
        }
    }
}
