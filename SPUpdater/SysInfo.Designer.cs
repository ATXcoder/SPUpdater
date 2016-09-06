namespace SPUpdater
{
    partial class SysInfo
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LBL_OSVersion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LBL_PSVersion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LBL_OSVersion
            // 
            this.LBL_OSVersion.AutoSize = true;
            this.LBL_OSVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_OSVersion.Location = new System.Drawing.Point(118, 24);
            this.LBL_OSVersion.Name = "LBL_OSVersion";
            this.LBL_OSVersion.Size = new System.Drawing.Size(132, 18);
            this.LBL_OSVersion.TabIndex = 0;
            this.LBL_OSVersion.Text = "<<Windows OS>>";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Windows OS:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "PowerShell Version:";
            // 
            // LBL_PSVersion
            // 
            this.LBL_PSVersion.AutoSize = true;
            this.LBL_PSVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_PSVersion.Location = new System.Drawing.Point(162, 84);
            this.LBL_PSVersion.Name = "LBL_PSVersion";
            this.LBL_PSVersion.Size = new System.Drawing.Size(122, 18);
            this.LBL_PSVersion.TabIndex = 3;
            this.LBL_PSVersion.Text = "<<PS_Version>>";
            // 
            // SysInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 265);
            this.Controls.Add(this.LBL_PSVersion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LBL_OSVersion);
            this.Name = "SysInfo";
            this.Text = "SysInfo";
            this.Load += new System.EventHandler(this.SysInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LBL_OSVersion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LBL_PSVersion;
    }
}