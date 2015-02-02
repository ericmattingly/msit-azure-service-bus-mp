# Microsoft IT Azure Service Bus Management Pack
A management pack created by Microsoft IT for monitoring Azure Service Bus with System Center Operations Manager 2012 R2

## Features

* Management Pack Template for Creating Windows Azure Service Bus Management Packs
* Securely Encrypts User/Pass for Service Bus Authentication
* Auto Discovers Azure Service Bus Queues, Topics and Subscriptions
* Views for Alerts and Namespace, Queues, Topics and Subscriptions Health
* Monitors for Queues
  * Queue is Enabled
  * Acceptable Message Count in Queue
  * Acceptable Message Count in Dead Letter Queue
  * Old Messages in Queue
* Monitors for Topics
  * Topic is Enabled
  * Topic has Correct Number of Subscribers
* Monitors for Subscriptions
  * Subscription is Enabled
  * Acceptable Message Count in Subscription
  * Acceptable Message Count in Dead Letter Queue
  * Old Messages in Subscription


## Quick Start - Usage

**Please always test new management packs in a test environment before importing to production!**

### Requirements
* System Center Operations Manager 2012 R2

### Importing the MP
1. Download the MPB by downloading a zip file of the code from by clicking the link *Download Zip* on the right of this web page.  The MPB file will be located in the root of the extracted folder.
2. Import the management pack into SCOM
3. Create a Simple Authentication Run As account with the user name being the SharedAccessKeyName and the password the SharedAccessKey from the SAS connection info on the Azure Portal for the Azure Service Bus namespace you wish to monitor
4. Create a new Microsoft IT Windows Azure Service Bus management pack using the Management Pack templates in the Authoring section of the SCOM 2012 R2 Console

## Quick Start - Compiling

### Requirements
* Visual Studio 2013
* [System Center 2012 Visual Studio Authoring Extensions](http://www.microsoft.com/en-us/download/details.aspx?id=30169)

### Compiling
1. Open the solution file
2. Open the AzureServiceBusManagementPack Project's properties and on the Build tab either provide a key to seal the MP or uncheck "Generate sealed and signed management pack"
3. Open the Microsoft.IT.SCOM.ASB.UI Project's properties and on the Build Events tab change the Post-Build event to copy to the Resources folder located in the AzureServiceBusManagementPack project directory