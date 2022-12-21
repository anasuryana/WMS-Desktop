namespace SMTCSHARP
{
    partial class FRM_MAIN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_MAIN));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbluser = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbluserid = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.naTabForm = new System.Windows.Forms.TabControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tvmenu = new System.Windows.Forms.TreeView();
            this.panlesep = new System.Windows.Forms.Panel();
            this.businessGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.businessGroupToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(813, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.lbluser,
            this.toolStripStatusLabel4,
            this.lbluserid,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 359);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(813, 24);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(31, 19);
            this.toolStripStatusLabel1.Text = "EMP";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(10, 19);
            this.toolStripStatusLabel2.Text = ":";
            // 
            // lbluser
            // 
            this.lbluser.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lbluser.Name = "lbluser";
            this.lbluser.Size = new System.Drawing.Size(41, 19);
            this.lbluser.Text = "ROOT";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(24, 19);
            this.toolStripStatusLabel4.Text = "ID :";
            // 
            // lbluserid
            // 
            this.lbluserid.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lbluserid.Name = "lbluserid";
            this.lbluserid.Size = new System.Drawing.Size(16, 19);
            this.lbluserid.Text = "-";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.BackColor = System.Drawing.Color.DodgerBlue;
            this.toolStripStatusLabel3.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.toolStripStatusLabel3.ForeColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(676, 19);
            this.toolStripStatusLabel3.Spring = true;
            this.toolStripStatusLabel3.Text = "WMS";
            this.toolStripStatusLabel3.Click += new System.EventHandler(this.toolStripStatusLabel3_Click);
            // 
            // naTabForm
            // 
            this.naTabForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.naTabForm.Location = new System.Drawing.Point(205, 24);
            this.naTabForm.Name = "naTabForm";
            this.naTabForm.SelectedIndex = 0;
            this.naTabForm.Size = new System.Drawing.Size(607, 25);
            this.naTabForm.TabIndex = 3;
            this.naTabForm.SelectedIndexChanged += new System.EventHandler(this.naTabForm_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tvmenu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 335);
            this.panel1.TabIndex = 6;
            // 
            // tvmenu
            // 
            this.tvmenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvmenu.Location = new System.Drawing.Point(3, 3);
            this.tvmenu.Name = "tvmenu";
            this.tvmenu.Size = new System.Drawing.Size(194, 329);
            this.tvmenu.TabIndex = 0;
            this.tvmenu.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvmenu_NodeMouseDoubleClick);
            this.tvmenu.DoubleClick += new System.EventHandler(this.tvmenu_DoubleClick);
            // 
            // panlesep
            // 
            this.panlesep.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.panlesep.Dock = System.Windows.Forms.DockStyle.Left;
            this.panlesep.Location = new System.Drawing.Point(200, 24);
            this.panlesep.Name = "panlesep";
            this.panlesep.Size = new System.Drawing.Size(5, 335);
            this.panlesep.TabIndex = 7;
            this.panlesep.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panlesep_MouseDown);
            this.panlesep.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panlesep_MouseMove);
            this.panlesep.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panlesep_MouseUp);
            // 
            // businessGroupToolStripMenuItem
            // 
            this.businessGroupToolStripMenuItem.Name = "businessGroupToolStripMenuItem";
            this.businessGroupToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.businessGroupToolStripMenuItem.Text = "Business Group";
            this.businessGroupToolStripMenuItem.Click += new System.EventHandler(this.businessGroupToolStripMenuItem_Click);
            // 
            // FRM_MAIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 383);
            this.Controls.Add(this.panlesep);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.naTabForm);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FRM_MAIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Warehouse Management System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FRM_MAIN_FormClosing);
            this.Load += new System.EventHandler(this.FRM_MAIN_Load);
            this.MdiChildActivate += new System.EventHandler(this.FRM_MAIN_MdiChildActivate);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FRM_MAIN_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lbluser;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.TabControl naTabForm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView tvmenu;
        private System.Windows.Forms.Panel panlesep;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel lbluserid;
        private System.Windows.Forms.ToolStripMenuItem businessGroupToolStripMenuItem;
    }
}