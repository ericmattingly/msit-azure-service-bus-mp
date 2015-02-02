namespace Microsoft.IT.SCOM.ASB.UI
{
    partial class ASBNamespaceDetails
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ASBNamespaceDetails));
            this.asbNamespaceDetailsTitleLabel = new Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.PageSectionLabel();
            this.asbNamespaceNameLabel = new System.Windows.Forms.Label();
            this.asbNamespaceNameTextBox = new System.Windows.Forms.TextBox();
            this.sqlAzureRunAsAccountLabel = new System.Windows.Forms.Label();
            this.runAsAccountComboBox = new System.Windows.Forms.ComboBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.sqlAzureDetailsDescriptionLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // asbNamespaceDetailsTitleLabel
            // 
            this.asbNamespaceDetailsTitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.asbNamespaceDetailsTitleLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.asbNamespaceDetailsTitleLabel.Location = new System.Drawing.Point(0, 0);
            this.asbNamespaceDetailsTitleLabel.MinimumSize = new System.Drawing.Size(244, 0);
            this.asbNamespaceDetailsTitleLabel.Name = "asbNamespaceDetailsTitleLabel";
            this.asbNamespaceDetailsTitleLabel.Size = new System.Drawing.Size(244, 23);
            this.asbNamespaceDetailsTitleLabel.TabIndex = 0;
            this.asbNamespaceDetailsTitleLabel.Text = "Windows Azure Service Bus Details";
            // 
            // asbNamespaceNameLabel
            // 
            this.asbNamespaceNameLabel.AutoSize = true;
            this.asbNamespaceNameLabel.Location = new System.Drawing.Point(3, 131);
            this.asbNamespaceNameLabel.Name = "asbNamespaceNameLabel";
            this.asbNamespaceNameLabel.Size = new System.Drawing.Size(399, 13);
            this.asbNamespaceNameLabel.TabIndex = 0;
            this.asbNamespaceNameLabel.Text = "Windows Azure Service Bus Namespace URL (including .servicebus.windows.net):";
            // 
            // asbNamespaceNameTextBox
            // 
            this.asbNamespaceNameTextBox.Location = new System.Drawing.Point(6, 147);
            this.asbNamespaceNameTextBox.Name = "asbNamespaceNameTextBox";
            this.asbNamespaceNameTextBox.Size = new System.Drawing.Size(237, 20);
            this.asbNamespaceNameTextBox.TabIndex = 1;
            this.asbNamespaceNameTextBox.TextChanged += new System.EventHandler(this.ValidatePageConfigurationEventHandler);
            // 
            // sqlAzureRunAsAccountLabel
            // 
            this.sqlAzureRunAsAccountLabel.AutoSize = true;
            this.sqlAzureRunAsAccountLabel.Location = new System.Drawing.Point(3, 183);
            this.sqlAzureRunAsAccountLabel.Name = "sqlAzureRunAsAccountLabel";
            this.sqlAzureRunAsAccountLabel.Size = new System.Drawing.Size(280, 13);
            this.sqlAzureRunAsAccountLabel.TabIndex = 4;
            this.sqlAzureRunAsAccountLabel.Text = "Windows Azure Service Bus Credentials Run As Account:";
            // 
            // runAsAccountComboBox
            // 
            this.runAsAccountComboBox.FormattingEnabled = true;
            this.runAsAccountComboBox.Location = new System.Drawing.Point(6, 199);
            this.runAsAccountComboBox.Name = "runAsAccountComboBox";
            this.runAsAccountComboBox.Size = new System.Drawing.Size(241, 21);
            this.runAsAccountComboBox.TabIndex = 5;
            this.runAsAccountComboBox.SelectedIndexChanged += new System.EventHandler(this.ValidatePageConfigurationEventHandler);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 0;
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // sqlAzureDetailsDescriptionLabel
            // 
            this.sqlAzureDetailsDescriptionLabel.AutoSize = true;
            this.sqlAzureDetailsDescriptionLabel.Location = new System.Drawing.Point(0, 34);
            this.sqlAzureDetailsDescriptionLabel.Name = "sqlAzureDetailsDescriptionLabel";
            this.sqlAzureDetailsDescriptionLabel.Size = new System.Drawing.Size(0, 13);
            this.sqlAzureDetailsDescriptionLabel.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Microsoft.IT.SCOM.ASB.UI.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(6, 370);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(208, 30);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(445, 65);
            this.label1.TabIndex = 8;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // ASBNamespaceDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.sqlAzureDetailsDescriptionLabel);
            this.Controls.Add(this.asbNamespaceDetailsTitleLabel);
            this.Controls.Add(this.runAsAccountComboBox);
            this.Controls.Add(this.sqlAzureRunAsAccountLabel);
            this.Controls.Add(this.asbNamespaceNameTextBox);
            this.Controls.Add(this.asbNamespaceNameLabel);
            this.Name = "ASBNamespaceDetails";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.PageSectionLabel asbNamespaceDetailsTitleLabel;
        private System.Windows.Forms.Label asbNamespaceNameLabel;
        private System.Windows.Forms.TextBox asbNamespaceNameTextBox;
        private System.Windows.Forms.Label sqlAzureRunAsAccountLabel;
        private System.Windows.Forms.ComboBox runAsAccountComboBox;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label sqlAzureDetailsDescriptionLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}
