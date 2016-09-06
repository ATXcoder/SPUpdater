namespace SPUpdater
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            this.GView_spupdates = new System.Windows.Forms.DataGridView();
            this.BTN_Search = new System.Windows.Forms.Button();
            this.DROP_Product = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DROP_Patch = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Menu_Help = new System.Windows.Forms.ToolStripDropDownButton();
            this.Menu_Help_About = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Help_SysInfo = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.GView_spupdates)).BeginInit();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GView_spupdates
            // 
            this.GView_spupdates.AllowUserToAddRows = false;
            this.GView_spupdates.AllowUserToDeleteRows = false;
            this.GView_spupdates.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.GView_spupdates.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.GView_spupdates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GView_spupdates.Location = new System.Drawing.Point(219, 33);
            this.GView_spupdates.Name = "GView_spupdates";
            this.GView_spupdates.ReadOnly = true;
            this.GView_spupdates.Size = new System.Drawing.Size(736, 358);
            this.GView_spupdates.TabIndex = 0;
            // 
            // BTN_Search
            // 
            this.BTN_Search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.BTN_Search.Location = new System.Drawing.Point(12, 262);
            this.BTN_Search.Name = "BTN_Search";
            this.BTN_Search.Size = new System.Drawing.Size(172, 36);
            this.BTN_Search.TabIndex = 1;
            this.BTN_Search.Text = "Search";
            this.BTN_Search.UseVisualStyleBackColor = false;
            this.BTN_Search.Click += new System.EventHandler(this.BTN_Search_Click);
            // 
            // DROP_Product
            // 
            this.DROP_Product.FormattingEnabled = true;
            this.DROP_Product.Items.AddRange(new object[] {
            "AppFabric 1.1",
            "Office Web Apps 2013",
            "Project Server 2013",
            "SharePoint Foundation 2013",
            "SharePoint Server 2013",
            "Workflow Manager 1.0"});
            this.DROP_Product.Location = new System.Drawing.Point(12, 64);
            this.DROP_Product.Name = "DROP_Product";
            this.DROP_Product.Size = new System.Drawing.Size(172, 21);
            this.DROP_Product.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Product";
            // 
            // DROP_Patch
            // 
            this.DROP_Patch.FormattingEnabled = true;
            this.DROP_Patch.Items.AddRange(new object[] {
            "Cumulative Update (CU)",
            "Public Update (PU)",
            "Security Hotfix (SC)",
            "Non-Securirty Hotfix (HF)",
            "Service Pack (SP)",
            "Release to Manufacturing (RM)"});
            this.DROP_Patch.Location = new System.Drawing.Point(12, 143);
            this.DROP_Patch.Name = "DROP_Patch";
            this.DROP_Patch.Size = new System.Drawing.Size(172, 21);
            this.DROP_Patch.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Patch Type";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(15, 209);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(98, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Download Only";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(433, 127);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(390, 133);
            this.panel1.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(107, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 29);
            this.label3.TabIndex = 1;
            this.label3.Text = "Fetching Data...";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Help});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(967, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Menu_Help
            // 
            this.Menu_Help.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Menu_Help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Help_About,
            this.Menu_Help_SysInfo});
            this.Menu_Help.Name = "Menu_Help";
            this.Menu_Help.Size = new System.Drawing.Size(45, 22);
            this.Menu_Help.Text = "Help";
            // 
            // Menu_Help_About
            // 
            this.Menu_Help_About.Name = "Menu_Help_About";
            this.Menu_Help_About.Size = new System.Drawing.Size(178, 22);
            this.Menu_Help_About.Text = "About";
            // 
            // Menu_Help_SysInfo
            // 
            this.Menu_Help_SysInfo.Name = "Menu_Help_SysInfo";
            this.Menu_Help_SysInfo.Size = new System.Drawing.Size(178, 22);
            this.Menu_Help_SysInfo.Text = "System Information";
            this.Menu_Help_SysInfo.Click += new System.EventHandler(this.Menu_Help_SysInfo_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 498);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DROP_Patch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DROP_Product);
            this.Controls.Add(this.BTN_Search);
            this.Controls.Add(this.GView_spupdates);
            this.Name = "Main";
            this.Text = "SharePoint Updater";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GView_spupdates)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GView_spupdates;
        private System.Windows.Forms.Button BTN_Search;
        private System.Windows.Forms.ComboBox DROP_Product;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox DROP_Patch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton Menu_Help;
        private System.Windows.Forms.ToolStripMenuItem Menu_Help_About;
        private System.Windows.Forms.ToolStripMenuItem Menu_Help_SysInfo;
    }
}

