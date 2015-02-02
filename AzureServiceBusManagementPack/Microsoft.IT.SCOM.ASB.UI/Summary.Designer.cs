namespace Microsoft.IT.SCOM.ASB.UI
{
    partial class Summary
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
            this.summaryListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sqlAzureDetailsTitleLabel = new Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.PageSectionLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // summaryListView
            // 
            this.summaryListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.summaryListView.Location = new System.Drawing.Point(6, 26);
            this.summaryListView.Name = "summaryListView";
            this.summaryListView.Size = new System.Drawing.Size(459, 338);
            this.summaryListView.TabIndex = 0;
            this.summaryListView.UseCompatibleStateImageBehavior = false;
            this.summaryListView.View = System.Windows.Forms.View.Details;
            // 
            // sqlAzureDetailsTitleLabel
            // 
            this.sqlAzureDetailsTitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.sqlAzureDetailsTitleLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sqlAzureDetailsTitleLabel.Location = new System.Drawing.Point(3, 0);
            this.sqlAzureDetailsTitleLabel.MinimumSize = new System.Drawing.Size(244, 0);
            this.sqlAzureDetailsTitleLabel.Name = "sqlAzureDetailsTitleLabel";
            this.sqlAzureDetailsTitleLabel.Size = new System.Drawing.Size(244, 23);
            this.sqlAzureDetailsTitleLabel.TabIndex = 1;
            this.sqlAzureDetailsTitleLabel.Text = "Confirm the settings";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Microsoft.IT.SCOM.ASB.UI.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(6, 370);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(208, 30);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // Summary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.sqlAzureDetailsTitleLabel);
            this.Controls.Add(this.summaryListView);
            this.Name = "Summary";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView summaryListView;
        private Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.PageSectionLabel sqlAzureDetailsTitleLabel;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
