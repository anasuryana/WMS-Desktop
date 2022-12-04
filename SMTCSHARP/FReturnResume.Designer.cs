namespace SMTCSHARP
{
    partial class FReturnResume
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FReturnResume));
            this.bgworkexport = new System.ComponentModel.BackgroundWorker();
            this.bgworksearch = new System.ComponentModel.BackgroundWorker();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lblinfo = new System.Windows.Forms.Label();
            this.txtserver = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.btnbrowse = new System.Windows.Forms.Button();
            this.txtpath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnsave_config = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblname = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnshowhidesetting = new System.Windows.Forms.Button();
            this.btnexport = new System.Windows.Forms.Button();
            this.btnfind = new System.Windows.Forms.Button();
            this.datepc = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dGV = new System.Windows.Forms.DataGridView();
            this.datefr = new System.Windows.Forms.DateTimePicker();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGV)).BeginInit();
            this.SuspendLayout();
            // 
            // bgworkexport
            // 
            this.bgworkexport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgworkexport_DoWork);
            // 
            // bgworksearch
            // 
            this.bgworksearch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgworksearch_DoWork);
            // 
            // lblinfo
            // 
            this.lblinfo.AutoSize = true;
            this.lblinfo.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblinfo.ForeColor = System.Drawing.Color.White;
            this.lblinfo.Location = new System.Drawing.Point(14, 93);
            this.lblinfo.Name = "lblinfo";
            this.lblinfo.Size = new System.Drawing.Size(24, 18);
            this.lblinfo.TabIndex = 79;
            this.lblinfo.Text = "..";
            // 
            // txtserver
            // 
            this.txtserver.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtserver.Location = new System.Drawing.Point(162, 51);
            this.txtserver.Name = "txtserver";
            this.txtserver.Size = new System.Drawing.Size(407, 25);
            this.txtserver.TabIndex = 33;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.txtserver);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.btnbrowse);
            this.panel2.Controls.Add(this.txtpath);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.btnsave_config);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(11, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(848, 425);
            this.panel2.TabIndex = 75;
            this.panel2.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 18);
            this.label5.TabIndex = 32;
            this.label5.Text = "Server";
            // 
            // btnbrowse
            // 
            this.btnbrowse.Location = new System.Drawing.Point(517, 80);
            this.btnbrowse.Name = "btnbrowse";
            this.btnbrowse.Size = new System.Drawing.Size(52, 24);
            this.btnbrowse.TabIndex = 31;
            this.btnbrowse.Text = "...";
            this.btnbrowse.UseVisualStyleBackColor = true;
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
            this.label6.Text = "XLS Folder";
            // 
            // btnsave_config
            // 
            this.btnsave_config.Image = ((System.Drawing.Image)(resources.GetObject("btnsave_config.Image")));
            this.btnsave_config.Location = new System.Drawing.Point(162, 110);
            this.btnsave_config.Name = "btnsave_config";
            this.btnsave_config.Size = new System.Drawing.Size(33, 26);
            this.btnsave_config.TabIndex = 28;
            this.btnsave_config.UseVisualStyleBackColor = true;
            this.btnsave_config.Click += new System.EventHandler(this.btnsave_config_Click);
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
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.LightCyan;
            this.panel1.Controls.Add(this.lblname);
            this.panel1.Controls.Add(this.btnshowhidesetting);
            this.panel1.Location = new System.Drawing.Point(0, 18);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(871, 29);
            this.panel1.TabIndex = 74;
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
            // btnexport
            // 
            this.btnexport.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnexport.Image = ((System.Drawing.Image)(resources.GetObject("btnexport.Image")));
            this.btnexport.Location = new System.Drawing.Point(445, 57);
            this.btnexport.Name = "btnexport";
            this.btnexport.Size = new System.Drawing.Size(30, 26);
            this.btnexport.TabIndex = 72;
            this.btnexport.UseVisualStyleBackColor = true;
            this.btnexport.Click += new System.EventHandler(this.btnexport_Click);
            // 
            // btnfind
            // 
            this.btnfind.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnfind.Image = ((System.Drawing.Image)(resources.GetObject("btnfind.Image")));
            this.btnfind.Location = new System.Drawing.Point(409, 57);
            this.btnfind.Name = "btnfind";
            this.btnfind.Size = new System.Drawing.Size(30, 26);
            this.btnfind.TabIndex = 71;
            this.btnfind.UseVisualStyleBackColor = true;
            this.btnfind.Click += new System.EventHandler(this.btnfind_Click);
            // 
            // datepc
            // 
            this.datepc.CustomFormat = "yyyy-MM-dd";
            this.datepc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datepc.Location = new System.Drawing.Point(242, 56);
            this.datepc.Name = "datepc";
            this.datepc.Size = new System.Drawing.Size(150, 25);
            this.datepc.TabIndex = 70;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(212, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 18);
            this.label2.TabIndex = 69;
            this.label2.Text = "to";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 18);
            this.label1.TabIndex = 67;
            this.label1.Text = "Date";
            // 
            // dGV
            // 
            this.dGV.AllowUserToAddRows = false;
            this.dGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV.Location = new System.Drawing.Point(11, 120);
            this.dGV.Name = "dGV";
            this.dGV.Size = new System.Drawing.Size(848, 323);
            this.dGV.TabIndex = 66;
            // 
            // datefr
            // 
            this.datefr.CustomFormat = "yyyy-MM-dd";
            this.datefr.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datefr.Location = new System.Drawing.Point(58, 56);
            this.datefr.Name = "datefr";
            this.datefr.Size = new System.Drawing.Size(148, 25);
            this.datefr.TabIndex = 80;
            // 
            // FReturnResume
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 461);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnexport);
            this.Controls.Add(this.btnfind);
            this.Controls.Add(this.datepc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dGV);
            this.Controls.Add(this.lblinfo);
            this.Controls.Add(this.datefr);
            this.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FReturnResume";
            this.Text = "Return Resume";
            this.Load += new System.EventHandler(this.FReturnResume_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker bgworkexport;
        private System.ComponentModel.BackgroundWorker bgworksearch;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label lblinfo;
        private System.Windows.Forms.TextBox txtserver;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnbrowse;
        private System.Windows.Forms.TextBox txtpath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnsave_config;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnshowhidesetting;
        private System.Windows.Forms.Button btnexport;
        private System.Windows.Forms.Button btnfind;
        private System.Windows.Forms.DateTimePicker datepc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dGV;
        private System.Windows.Forms.DateTimePicker datefr;
    }
}