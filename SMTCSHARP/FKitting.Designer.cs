namespace SMTCSHARP
{
    partial class FKitting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FKitting));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnbrowse = new System.Windows.Forms.Button();
            this.txtpath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtserver = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnsave_config = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnexport_csv = new System.Windows.Forms.Button();
            this.btnsearch = new System.Windows.Forms.Button();
            this.btnFindpsn = new System.Windows.Forms.Button();
            this.ckOutstaningOnly = new System.Windows.Forms.CheckBox();
            this.txtcat = new System.Windows.Forms.ComboBox();
            this.dGV = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblname = new System.Windows.Forms.Label();
            this.btnshowhidesetting = new System.Windows.Forms.Button();
            this.txtline = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtinfo = new System.Windows.Forms.TextBox();
            this.bgworksearch = new System.ComponentModel.BackgroundWorker();
            this.bgworkexport = new System.ComponentModel.BackgroundWorker();
            this.txtpsn = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGV)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnbrowse
            // 
            this.btnbrowse.Location = new System.Drawing.Point(517, 80);
            this.btnbrowse.Name = "btnbrowse";
            this.btnbrowse.Size = new System.Drawing.Size(52, 24);
            this.btnbrowse.TabIndex = 31;
            this.btnbrowse.Text = "...";
            this.btnbrowse.UseVisualStyleBackColor = true;
            this.btnbrowse.Click += new System.EventHandler(this.btnbrowse_Click);
            // 
            // txtpath
            // 
            this.txtpath.Location = new System.Drawing.Point(162, 79);
            this.txtpath.Name = "txtpath";
            this.txtpath.ReadOnly = true;
            this.txtpath.Size = new System.Drawing.Size(349, 25);
            this.txtpath.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 18);
            this.label6.TabIndex = 29;
            this.label6.Text = "CSV Folder";
            // 
            // txtserver
            // 
            this.txtserver.Location = new System.Drawing.Point(162, 48);
            this.txtserver.Name = "txtserver";
            this.txtserver.Size = new System.Drawing.Size(407, 25);
            this.txtserver.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 18);
            this.label5.TabIndex = 1;
            this.label5.Text = "Server";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(181, 27);
            this.label4.TabIndex = 0;
            this.label4.Text = "Configuration";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btnbrowse);
            this.panel2.Controls.Add(this.txtpath);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.btnsave_config);
            this.panel2.Controls.Add(this.txtserver);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(11, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(848, 437);
            this.panel2.TabIndex = 54;
            this.panel2.Visible = false;
            // 
            // btnsave_config
            // 
            this.btnsave_config.Image = ((System.Drawing.Image)(resources.GetObject("btnsave_config.Image")));
            this.btnsave_config.Location = new System.Drawing.Point(162, 110);
            this.btnsave_config.Name = "btnsave_config";
            this.btnsave_config.Size = new System.Drawing.Size(33, 26);
            this.btnsave_config.TabIndex = 28;
            this.toolTip1.SetToolTip(this.btnsave_config, "Save");
            this.btnsave_config.UseVisualStyleBackColor = true;
            this.btnsave_config.Click += new System.EventHandler(this.btnsave_config_Click);
            // 
            // btnexport_csv
            // 
            this.btnexport_csv.Image = ((System.Drawing.Image)(resources.GetObject("btnexport_csv.Image")));
            this.btnexport_csv.Location = new System.Drawing.Point(173, 152);
            this.btnexport_csv.Name = "btnexport_csv";
            this.btnexport_csv.Size = new System.Drawing.Size(33, 26);
            this.btnexport_csv.TabIndex = 50;
            this.toolTip1.SetToolTip(this.btnexport_csv, "Export to CSV");
            this.btnexport_csv.UseVisualStyleBackColor = true;
            this.btnexport_csv.Click += new System.EventHandler(this.btnexport_csv_Click);
            // 
            // btnsearch
            // 
            this.btnsearch.Image = ((System.Drawing.Image)(resources.GetObject("btnsearch.Image")));
            this.btnsearch.Location = new System.Drawing.Point(134, 152);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(33, 26);
            this.btnsearch.TabIndex = 49;
            this.toolTip1.SetToolTip(this.btnsearch, "Search");
            this.btnsearch.UseVisualStyleBackColor = true;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // btnFindpsn
            // 
            this.btnFindpsn.Image = ((System.Drawing.Image)(resources.GetObject("btnFindpsn.Image")));
            this.btnFindpsn.Location = new System.Drawing.Point(451, 60);
            this.btnFindpsn.Name = "btnFindpsn";
            this.btnFindpsn.Size = new System.Drawing.Size(33, 26);
            this.btnFindpsn.TabIndex = 58;
            this.toolTip1.SetToolTip(this.btnFindpsn, "Find PSN No");
            this.btnFindpsn.UseVisualStyleBackColor = true;
            this.btnFindpsn.Click += new System.EventHandler(this.btnFindpsn_Click);
            // 
            // ckOutstaningOnly
            // 
            this.ckOutstaningOnly.AutoSize = true;
            this.ckOutstaningOnly.Location = new System.Drawing.Point(490, 60);
            this.ckOutstaningOnly.Name = "ckOutstaningOnly";
            this.ckOutstaningOnly.Size = new System.Drawing.Size(91, 22);
            this.ckOutstaningOnly.TabIndex = 60;
            this.ckOutstaningOnly.Text = "O/S Only";
            this.toolTip1.SetToolTip(this.ckOutstaningOnly, "Outstanding \'Upload to MEGA\'");
            this.ckOutstaningOnly.UseVisualStyleBackColor = true;
            // 
            // txtcat
            // 
            this.txtcat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtcat.FormattingEnabled = true;
            this.txtcat.Location = new System.Drawing.Point(135, 88);
            this.txtcat.Name = "txtcat";
            this.txtcat.Size = new System.Drawing.Size(139, 26);
            this.txtcat.TabIndex = 52;
            this.txtcat.DropDown += new System.EventHandler(this.txtcat_DropDown);
            // 
            // dGV
            // 
            this.dGV.AllowUserToAddRows = false;
            this.dGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV.Location = new System.Drawing.Point(11, 181);
            this.dGV.Name = "dGV";
            this.dGV.RowHeadersWidth = 51;
            this.dGV.Size = new System.Drawing.Size(848, 278);
            this.dGV.TabIndex = 51;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 120);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 18);
            this.label3.TabIndex = 48;
            this.label3.Text = "Line";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 88);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 18);
            this.label2.TabIndex = 47;
            this.label2.Text = "Category";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 59);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 18);
            this.label1.TabIndex = 46;
            this.label1.Text = "PSN No.";
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblname.Location = new System.Drawing.Point(377, 12);
            this.lblname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(0, 14);
            this.lblname.TabIndex = 32;
            // 
            // btnshowhidesetting
            // 
            this.btnshowhidesetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnshowhidesetting.Image = ((System.Drawing.Image)(resources.GetObject("btnshowhidesetting.Image")));
            this.btnshowhidesetting.Location = new System.Drawing.Point(815, 5);
            this.btnshowhidesetting.Margin = new System.Windows.Forms.Padding(4);
            this.btnshowhidesetting.Name = "btnshowhidesetting";
            this.btnshowhidesetting.Size = new System.Drawing.Size(44, 21);
            this.btnshowhidesetting.TabIndex = 29;
            this.btnshowhidesetting.UseVisualStyleBackColor = true;
            this.btnshowhidesetting.Click += new System.EventHandler(this.btnshowhidesetting_Click);
            // 
            // txtline
            // 
            this.txtline.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtline.FormattingEnabled = true;
            this.txtline.Location = new System.Drawing.Point(135, 120);
            this.txtline.Name = "txtline";
            this.txtline.Size = new System.Drawing.Size(139, 26);
            this.txtline.TabIndex = 53;
            this.txtline.DropDown += new System.EventHandler(this.txtline_DropDown);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.LightCyan;
            this.panel1.Controls.Add(this.lblname);
            this.panel1.Controls.Add(this.btnshowhidesetting);
            this.panel1.Location = new System.Drawing.Point(0, 22);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(871, 29);
            this.panel1.TabIndex = 45;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtinfo);
            this.groupBox1.Location = new System.Drawing.Point(607, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 117);
            this.groupBox1.TabIndex = 57;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Last Info";
            // 
            // txtinfo
            // 
            this.txtinfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtinfo.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtinfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtinfo.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtinfo.Location = new System.Drawing.Point(6, 21);
            this.txtinfo.Multiline = true;
            this.txtinfo.Name = "txtinfo";
            this.txtinfo.ReadOnly = true;
            this.txtinfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtinfo.Size = new System.Drawing.Size(240, 90);
            this.txtinfo.TabIndex = 57;
            // 
            // bgworksearch
            // 
            this.bgworksearch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgworksearch_DoWork);
            // 
            // bgworkexport
            // 
            this.bgworkexport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgworkexport_DoWork);
            // 
            // txtpsn
            // 
            this.txtpsn.Location = new System.Drawing.Point(135, 60);
            this.txtpsn.Name = "txtpsn";
            this.txtpsn.ReadOnly = true;
            this.txtpsn.Size = new System.Drawing.Size(310, 25);
            this.txtpsn.TabIndex = 59;
            // 
            // FKitting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 461);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtcat);
            this.Controls.Add(this.dGV);
            this.Controls.Add(this.btnexport_csv);
            this.Controls.Add(this.btnsearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtline);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtpsn);
            this.Controls.Add(this.btnFindpsn);
            this.Controls.Add(this.ckOutstaningOnly);
            this.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FKitting";
            this.ShowIcon = false;
            this.Text = "Kitting";
            this.Load += new System.EventHandler(this.FKitting_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGV)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnbrowse;
        private System.Windows.Forms.TextBox txtpath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtserver;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnsave_config;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnexport_csv;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.ComboBox txtcat;
        private System.Windows.Forms.DataGridView dGV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Button btnshowhidesetting;
        private System.Windows.Forms.ComboBox txtline;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtinfo;
        private System.ComponentModel.BackgroundWorker bgworksearch;
        private System.ComponentModel.BackgroundWorker bgworkexport;
        private System.Windows.Forms.Button btnFindpsn;
        private System.Windows.Forms.TextBox txtpsn;
        private System.Windows.Forms.CheckBox ckOutstaningOnly;
    }
}