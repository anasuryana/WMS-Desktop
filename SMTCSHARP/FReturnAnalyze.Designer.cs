namespace SMTCSHARP
{
    partial class FReturnAnalyze
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FReturnAnalyze));
            this.dGV = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtpsn = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.datepc = new System.Windows.Forms.DateTimePicker();
            this.btnnew = new System.Windows.Forms.Button();
            this.btnexport = new System.Windows.Forms.Button();
            this.btnconform = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblname = new System.Windows.Forms.Label();
            this.btnshowhidesetting = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtserver = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnbrowse = new System.Windows.Forms.Button();
            this.txtpath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnsave_config = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtjob = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bgworksearch = new System.ComponentModel.BackgroundWorker();
            this.ckall = new System.Windows.Forms.CheckBox();
            this.bgworkexport = new System.ComponentModel.BackgroundWorker();
            this.lblinfo = new System.Windows.Forms.Label();
            this.bgworkconform = new System.ComponentModel.BackgroundWorker();
            this.txtReffDoc = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnFindpsn = new System.Windows.Forms.Button();
            this.ckOutstaningOnly = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dGV)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dGV
            // 
            this.dGV.AllowUserToAddRows = false;
            this.dGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV.Location = new System.Drawing.Point(11, 204);
            this.dGV.Name = "dGV";
            this.dGV.RowHeadersWidth = 51;
            this.dGV.Size = new System.Drawing.Size(848, 245);
            this.dGV.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 18);
            this.label1.TabIndex = 53;
            this.label1.Text = "PSN Number";
            // 
            // txtpsn
            // 
            this.txtpsn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtpsn.Location = new System.Drawing.Point(126, 62);
            this.txtpsn.Name = "txtpsn";
            this.txtpsn.Size = new System.Drawing.Size(326, 25);
            this.txtpsn.TabIndex = 54;
            this.txtpsn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpsn_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(615, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 18);
            this.label2.TabIndex = 55;
            this.label2.Text = "Date";
            // 
            // datepc
            // 
            this.datepc.CustomFormat = "yyyy-MM-dd";
            this.datepc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datepc.Location = new System.Drawing.Point(661, 62);
            this.datepc.Name = "datepc";
            this.datepc.Size = new System.Drawing.Size(198, 25);
            this.datepc.TabIndex = 56;
            // 
            // btnnew
            // 
            this.btnnew.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnnew.Image = ((System.Drawing.Image)(resources.GetObject("btnnew.Image")));
            this.btnnew.Location = new System.Drawing.Point(408, 174);
            this.btnnew.Name = "btnnew";
            this.btnnew.Size = new System.Drawing.Size(30, 26);
            this.btnnew.TabIndex = 57;
            this.btnnew.UseVisualStyleBackColor = true;
            this.btnnew.Click += new System.EventHandler(this.btnnew_Click);
            // 
            // btnexport
            // 
            this.btnexport.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnexport.Image = ((System.Drawing.Image)(resources.GetObject("btnexport.Image")));
            this.btnexport.Location = new System.Drawing.Point(444, 174);
            this.btnexport.Name = "btnexport";
            this.btnexport.Size = new System.Drawing.Size(30, 26);
            this.btnexport.TabIndex = 58;
            this.btnexport.UseVisualStyleBackColor = true;
            this.btnexport.Click += new System.EventHandler(this.btnexport_Click);
            // 
            // btnconform
            // 
            this.btnconform.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnconform.Location = new System.Drawing.Point(480, 174);
            this.btnconform.Name = "btnconform";
            this.btnconform.Size = new System.Drawing.Size(83, 26);
            this.btnconform.TabIndex = 59;
            this.btnconform.Text = "Conform";
            this.btnconform.UseVisualStyleBackColor = true;
            this.btnconform.Click += new System.EventHandler(this.btnconform_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.LightCyan;
            this.panel1.Controls.Add(this.lblname);
            this.panel1.Controls.Add(this.btnshowhidesetting);
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(871, 29);
            this.panel1.TabIndex = 60;
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
            this.panel2.Location = new System.Drawing.Point(11, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(848, 425);
            this.panel2.TabIndex = 61;
            this.panel2.Visible = false;
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
            // txtjob
            // 
            this.txtjob.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtjob.Location = new System.Drawing.Point(126, 93);
            this.txtjob.Name = "txtjob";
            this.txtjob.ReadOnly = true;
            this.txtjob.Size = new System.Drawing.Size(733, 25);
            this.txtjob.TabIndex = 63;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 18);
            this.label3.TabIndex = 62;
            this.label3.Text = "Job Number";
            // 
            // bgworksearch
            // 
            this.bgworksearch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgworksearch_DoWork);
            // 
            // ckall
            // 
            this.ckall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckall.AutoSize = true;
            this.ckall.Location = new System.Drawing.Point(752, 178);
            this.ckall.Name = "ckall";
            this.ckall.Size = new System.Drawing.Size(107, 22);
            this.ckall.TabIndex = 64;
            this.ckall.Text = "Select all";
            this.ckall.UseVisualStyleBackColor = true;
            this.ckall.CheckedChanged += new System.EventHandler(this.ckall_CheckedChanged);
            // 
            // bgworkexport
            // 
            this.bgworkexport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgworkexport_DoWork);
            // 
            // lblinfo
            // 
            this.lblinfo.AutoSize = true;
            this.lblinfo.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblinfo.ForeColor = System.Drawing.Color.White;
            this.lblinfo.Location = new System.Drawing.Point(14, 179);
            this.lblinfo.Name = "lblinfo";
            this.lblinfo.Size = new System.Drawing.Size(24, 18);
            this.lblinfo.TabIndex = 65;
            this.lblinfo.Text = "..";
            // 
            // bgworkconform
            // 
            this.bgworkconform.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgworkconform_DoWork);
            // 
            // txtReffDoc
            // 
            this.txtReffDoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReffDoc.Location = new System.Drawing.Point(162, 124);
            this.txtReffDoc.Name = "txtReffDoc";
            this.txtReffDoc.ReadOnly = true;
            this.txtReffDoc.Size = new System.Drawing.Size(697, 25);
            this.txtReffDoc.TabIndex = 67;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(144, 18);
            this.label7.TabIndex = 66;
            this.label7.Text = "Kitting Reference";
            // 
            // btnFindpsn
            // 
            this.btnFindpsn.Image = ((System.Drawing.Image)(resources.GetObject("btnFindpsn.Image")));
            this.btnFindpsn.Location = new System.Drawing.Point(458, 61);
            this.btnFindpsn.Name = "btnFindpsn";
            this.btnFindpsn.Size = new System.Drawing.Size(33, 27);
            this.btnFindpsn.TabIndex = 68;
            this.btnFindpsn.UseVisualStyleBackColor = true;
            this.btnFindpsn.Click += new System.EventHandler(this.btnFindpsn_Click);
            // 
            // ckOutstaningOnly
            // 
            this.ckOutstaningOnly.AutoSize = true;
            this.ckOutstaningOnly.Location = new System.Drawing.Point(497, 65);
            this.ckOutstaningOnly.Name = "ckOutstaningOnly";
            this.ckOutstaningOnly.Size = new System.Drawing.Size(91, 22);
            this.ckOutstaningOnly.TabIndex = 69;
            this.ckOutstaningOnly.Text = "O/S Only";
            this.ckOutstaningOnly.UseVisualStyleBackColor = true;
            this.ckOutstaningOnly.CheckedChanged += new System.EventHandler(this.ckOutstaningOnly_CheckedChanged);
            // 
            // FReturnAnalyze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 461);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtjob);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnconform);
            this.Controls.Add(this.btnexport);
            this.Controls.Add(this.btnnew);
            this.Controls.Add(this.datepc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtpsn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dGV);
            this.Controls.Add(this.ckall);
            this.Controls.Add(this.lblinfo);
            this.Controls.Add(this.txtReffDoc);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnFindpsn);
            this.Controls.Add(this.ckOutstaningOnly);
            this.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FReturnAnalyze";
            this.Text = "Analyze Return RM";
            this.Load += new System.EventHandler(this.FReturnAnalyze_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGV)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dGV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtpsn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker datepc;
        private System.Windows.Forms.Button btnnew;
        private System.Windows.Forms.Button btnexport;
        private System.Windows.Forms.Button btnconform;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Button btnshowhidesetting;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnbrowse;
        private System.Windows.Forms.TextBox txtpath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnsave_config;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox txtjob;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtserver;
        private System.Windows.Forms.Label label5;
        private System.ComponentModel.BackgroundWorker bgworksearch;
        private System.Windows.Forms.CheckBox ckall;
        private System.ComponentModel.BackgroundWorker bgworkexport;
        private System.Windows.Forms.Label lblinfo;
        private System.ComponentModel.BackgroundWorker bgworkconform;
        private System.Windows.Forms.TextBox txtReffDoc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnFindpsn;
        private System.Windows.Forms.CheckBox ckOutstaningOnly;
    }
}