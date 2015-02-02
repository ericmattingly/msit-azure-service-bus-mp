namespace Microsoft.IT.SCOM.ASB.UI
{
    partial class ProxyAgent
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
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.proxyAgentBrowseTextBox = new System.Windows.Forms.TextBox();
            this.proxyAgentDescriptionLabel = new System.Windows.Forms.Label();
            this.proxyAgentTitleLabel = new Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.PageSectionLabel();
            this.proxyAgentBrowseButton = new System.Windows.Forms.Button();
            this.proxyAgentBrowseLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // proxyAgentBrowseTextBox
            // 
            this.proxyAgentBrowseTextBox.Location = new System.Drawing.Point(76, 112);
            this.proxyAgentBrowseTextBox.Name = "proxyAgentBrowseTextBox";
            this.proxyAgentBrowseTextBox.ReadOnly = true;
            this.proxyAgentBrowseTextBox.Size = new System.Drawing.Size(268, 20);
            this.proxyAgentBrowseTextBox.TabIndex = 0;
            this.proxyAgentBrowseTextBox.TextChanged += new System.EventHandler(this.ValidatePageConfigurationEventHandler);
            // 
            // proxyAgentDescriptionLabel
            // 
            this.proxyAgentDescriptionLabel.AutoSize = true;
            this.proxyAgentDescriptionLabel.Location = new System.Drawing.Point(3, 34);
            this.proxyAgentDescriptionLabel.Name = "proxyAgentDescriptionLabel";
            this.proxyAgentDescriptionLabel.Size = new System.Drawing.Size(444, 26);
            this.proxyAgentDescriptionLabel.TabIndex = 8;
            this.proxyAgentDescriptionLabel.Text = "Select an agent-managed computer to act as a proxy agent.  The proxy agent commun" +
    "icates\r\nwith the Windows Azure Service Bus to retrieve data.";
            // 
            // proxyAgentTitleLabel
            // 
            this.proxyAgentTitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.proxyAgentTitleLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.proxyAgentTitleLabel.Location = new System.Drawing.Point(3, 0);
            this.proxyAgentTitleLabel.MinimumSize = new System.Drawing.Size(244, 0);
            this.proxyAgentTitleLabel.Name = "proxyAgentTitleLabel";
            this.proxyAgentTitleLabel.Size = new System.Drawing.Size(244, 23);
            this.proxyAgentTitleLabel.TabIndex = 7;
            this.proxyAgentTitleLabel.Text = "Choose Proxy Agent";
            // 
            // proxyAgentBrowseButton
            // 
            this.proxyAgentBrowseButton.Location = new System.Drawing.Point(350, 110);
            this.proxyAgentBrowseButton.Name = "proxyAgentBrowseButton";
            this.proxyAgentBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.proxyAgentBrowseButton.TabIndex = 9;
            this.proxyAgentBrowseButton.Text = "Browse...";
            this.proxyAgentBrowseButton.UseVisualStyleBackColor = true;
            this.proxyAgentBrowseButton.Click += new System.EventHandler(this.proxyAgentBrowseButton_Click);
            // 
            // proxyAgentBrowseLabel
            // 
            this.proxyAgentBrowseLabel.AutoSize = true;
            this.proxyAgentBrowseLabel.Location = new System.Drawing.Point(3, 115);
            this.proxyAgentBrowseLabel.Name = "proxyAgentBrowseLabel";
            this.proxyAgentBrowseLabel.Size = new System.Drawing.Size(67, 13);
            this.proxyAgentBrowseLabel.TabIndex = 10;
            this.proxyAgentBrowseLabel.Text = "Proxy Agent:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Microsoft.IT.SCOM.ASB.UI.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(6, 370);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(208, 30);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // ProxyAgent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.proxyAgentBrowseLabel);
            this.Controls.Add(this.proxyAgentBrowseButton);
            this.Controls.Add(this.proxyAgentDescriptionLabel);
            this.Controls.Add(this.proxyAgentTitleLabel);
            this.Controls.Add(this.proxyAgentBrowseTextBox);
            this.Name = "ProxyAgent";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TextBox proxyAgentBrowseTextBox;
        private System.Windows.Forms.Label proxyAgentDescriptionLabel;
        private Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.PageSectionLabel proxyAgentTitleLabel;
        private System.Windows.Forms.Button proxyAgentBrowseButton;
        private System.Windows.Forms.Label proxyAgentBrowseLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
