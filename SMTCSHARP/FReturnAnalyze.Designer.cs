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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FReturnAnalyze));
            this.btnnew = new System.Windows.Forms.Button();
            this.btnexport = new System.Windows.Forms.Button();
            this.btnconform = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.bgworksearch = new System.ComponentModel.BackgroundWorker();
            this.bgworkexport = new System.ComponentModel.BackgroundWorker();
            this.bgworkconform = new System.ComponentModel.BackgroundWorker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ckall = new System.Windows.Forms.CheckBox();
            this.dGV = new System.Windows.Forms.DataGridView();
            this.lblinfo = new System.Windows.Forms.Label();
            this.txtjob = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.datepc = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtpsn = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtReffDoc = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnFindpsn = new System.Windows.Forms.Button();
            this.ckOutstaningOnly = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DGVDetail = new System.Windows.Forms.DataGridView();
            this.picStatus = new System.Windows.Forms.PictureBox();
            this.lblItemDescription = new System.Windows.Forms.Label();
            this.btnNewCheck = new System.Windows.Forms.Button();
            this.lblMeasure = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLabelID = new System.Windows.Forms.TextBox();
            this.dgvLogs = new System.Windows.Forms.DataGridView();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.lblPortStatus = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGV)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).BeginInit();
            this.SuspendLayout();
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
            // bgworksearch
            // 
            this.bgworksearch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgworksearch_DoWork);
            // 
            // bgworkexport
            // 
            this.bgworkexport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgworkexport_DoWork);
            // 
            // bgworkconform
            // 
            this.bgworkconform.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgworkconform_DoWork);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(11, 60);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(848, 448);
            this.tabControl1.TabIndex = 70;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ckall);
            this.tabPage1.Controls.Add(this.dGV);
            this.tabPage1.Controls.Add(this.lblinfo);
            this.tabPage1.Controls.Add(this.txtjob);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.datepc);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtpsn);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtReffDoc);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.btnFindpsn);
            this.tabPage1.Controls.Add(this.ckOutstaningOnly);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(840, 417);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Analyze";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ckall
            // 
            this.ckall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckall.AutoSize = true;
            this.ckall.Location = new System.Drawing.Point(727, 125);
            this.ckall.Name = "ckall";
            this.ckall.Size = new System.Drawing.Size(107, 22);
            this.ckall.TabIndex = 82;
            this.ckall.Text = "Select all";
            this.ckall.UseVisualStyleBackColor = true;
            this.ckall.CheckedChanged += new System.EventHandler(this.ckall_CheckedChanged_1);
            // 
            // dGV
            // 
            this.dGV.AllowUserToAddRows = false;
            this.dGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV.Location = new System.Drawing.Point(6, 150);
            this.dGV.Name = "dGV";
            this.dGV.RowHeadersWidth = 51;
            this.dGV.Size = new System.Drawing.Size(828, 261);
            this.dGV.TabIndex = 81;
            // 
            // lblinfo
            // 
            this.lblinfo.AutoSize = true;
            this.lblinfo.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblinfo.ForeColor = System.Drawing.Color.White;
            this.lblinfo.Location = new System.Drawing.Point(8, 129);
            this.lblinfo.Name = "lblinfo";
            this.lblinfo.Size = new System.Drawing.Size(24, 18);
            this.lblinfo.TabIndex = 80;
            this.lblinfo.Text = "..";
            // 
            // txtjob
            // 
            this.txtjob.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtjob.Location = new System.Drawing.Point(122, 48);
            this.txtjob.Name = "txtjob";
            this.txtjob.ReadOnly = true;
            this.txtjob.Size = new System.Drawing.Size(712, 25);
            this.txtjob.TabIndex = 75;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 18);
            this.label3.TabIndex = 74;
            this.label3.Text = "Job Number";
            // 
            // datepc
            // 
            this.datepc.CustomFormat = "yyyy-MM-dd";
            this.datepc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datepc.Location = new System.Drawing.Point(669, 17);
            this.datepc.Name = "datepc";
            this.datepc.Size = new System.Drawing.Size(165, 25);
            this.datepc.TabIndex = 73;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(611, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 18);
            this.label2.TabIndex = 72;
            this.label2.Text = "Date";
            // 
            // txtpsn
            // 
            this.txtpsn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtpsn.Location = new System.Drawing.Point(122, 17);
            this.txtpsn.Name = "txtpsn";
            this.txtpsn.Size = new System.Drawing.Size(261, 25);
            this.txtpsn.TabIndex = 71;
            this.txtpsn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpsn_KeyPress_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 18);
            this.label1.TabIndex = 70;
            this.label1.Text = "PSN Number";
            // 
            // txtReffDoc
            // 
            this.txtReffDoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReffDoc.Location = new System.Drawing.Point(158, 79);
            this.txtReffDoc.Name = "txtReffDoc";
            this.txtReffDoc.ReadOnly = true;
            this.txtReffDoc.Size = new System.Drawing.Size(676, 25);
            this.txtReffDoc.TabIndex = 77;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(144, 18);
            this.label7.TabIndex = 76;
            this.label7.Text = "Kitting Reference";
            // 
            // btnFindpsn
            // 
            this.btnFindpsn.Image = ((System.Drawing.Image)(resources.GetObject("btnFindpsn.Image")));
            this.btnFindpsn.Location = new System.Drawing.Point(388, 16);
            this.btnFindpsn.Name = "btnFindpsn";
            this.btnFindpsn.Size = new System.Drawing.Size(33, 27);
            this.btnFindpsn.TabIndex = 78;
            this.btnFindpsn.UseVisualStyleBackColor = true;
            // 
            // ckOutstaningOnly
            // 
            this.ckOutstaningOnly.AutoSize = true;
            this.ckOutstaningOnly.Location = new System.Drawing.Point(427, 20);
            this.ckOutstaningOnly.Name = "ckOutstaningOnly";
            this.ckOutstaningOnly.Size = new System.Drawing.Size(91, 22);
            this.ckOutstaningOnly.TabIndex = 79;
            this.ckOutstaningOnly.Text = "O/S Only";
            this.ckOutstaningOnly.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DGVDetail);
            this.tabPage2.Controls.Add(this.lblItemDescription);
            this.tabPage2.Controls.Add(this.btnNewCheck);
            this.tabPage2.Controls.Add(this.lblMeasure);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.txtMax);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.txtMin);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.txtLabelID);
            this.tabPage2.Controls.Add(this.dgvLogs);
            this.tabPage2.Controls.Add(this.txtValue);
            this.tabPage2.Controls.Add(this.lblPortStatus);
            this.tabPage2.Controls.Add(this.btnConnect);
            this.tabPage2.Controls.Add(this.picStatus);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(840, 417);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Value Checker";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DGVDetail
            // 
            this.DGVDetail.AllowUserToAddRows = false;
            this.DGVDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVDetail.Location = new System.Drawing.Point(6, 245);
            this.DGVDetail.Name = "DGVDetail";
            this.DGVDetail.RowHeadersWidth = 62;
            this.DGVDetail.Size = new System.Drawing.Size(828, 168);
            this.DGVDetail.TabIndex = 57;
            // 
            // picStatus
            // 
            this.picStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picStatus.Location = new System.Drawing.Point(440, 19);
            this.picStatus.Name = "picStatus";
            this.picStatus.Size = new System.Drawing.Size(19, 220);
            this.picStatus.TabIndex = 16;
            this.picStatus.TabStop = false;
            // 
            // lblItemDescription
            // 
            this.lblItemDescription.AutoSize = true;
            this.lblItemDescription.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemDescription.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblItemDescription.Location = new System.Drawing.Point(95, 97);
            this.lblItemDescription.Name = "lblItemDescription";
            this.lblItemDescription.Size = new System.Drawing.Size(40, 22);
            this.lblItemDescription.TabIndex = 15;
            this.lblItemDescription.Text = "...";
            // 
            // btnNewCheck
            // 
            this.btnNewCheck.Location = new System.Drawing.Point(6, 19);
            this.btnNewCheck.Name = "btnNewCheck";
            this.btnNewCheck.Size = new System.Drawing.Size(81, 26);
            this.btnNewCheck.TabIndex = 14;
            this.btnNewCheck.Text = "New";
            this.btnNewCheck.UseVisualStyleBackColor = true;
            this.btnNewCheck.Click += new System.EventHandler(this.btnNewCheck_Click);
            // 
            // lblMeasure
            // 
            this.lblMeasure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMeasure.AutoSize = true;
            this.lblMeasure.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeasure.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblMeasure.Location = new System.Drawing.Point(402, 212);
            this.lblMeasure.Name = "lblMeasure";
            this.lblMeasure.Size = new System.Drawing.Size(32, 18);
            this.lblMeasure.TabIndex = 13;
            this.lblMeasure.Text = "...";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 167);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 18);
            this.label11.TabIndex = 11;
            this.label11.Text = "Max";
            // 
            // txtMax
            // 
            this.txtMax.Location = new System.Drawing.Point(99, 164);
            this.txtMax.Name = "txtMax";
            this.txtMax.ReadOnly = true;
            this.txtMax.Size = new System.Drawing.Size(102, 25);
            this.txtMax.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 136);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 18);
            this.label10.TabIndex = 9;
            this.label10.Text = "Min";
            // 
            // txtMin
            // 
            this.txtMin.Location = new System.Drawing.Point(99, 133);
            this.txtMin.Name = "txtMin";
            this.txtMin.ReadOnly = true;
            this.txtMin.Size = new System.Drawing.Size(102, 25);
            this.txtMin.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(230, 209);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 18);
            this.label9.TabIndex = 7;
            this.label9.Text = "Value";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 18);
            this.label8.TabIndex = 6;
            this.label8.Text = "Label ID";
            // 
            // txtLabelID
            // 
            this.txtLabelID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLabelID.Location = new System.Drawing.Point(99, 69);
            this.txtLabelID.Name = "txtLabelID";
            this.txtLabelID.Size = new System.Drawing.Size(176, 25);
            this.txtLabelID.TabIndex = 5;
            this.txtLabelID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLabelID_KeyPress_1);
            // 
            // dgvLogs
            // 
            this.dgvLogs.AllowUserToDeleteRows = false;
            this.dgvLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLogs.Location = new System.Drawing.Point(465, 19);
            this.dgvLogs.Name = "dgvLogs";
            this.dgvLogs.ReadOnly = true;
            this.dgvLogs.Size = new System.Drawing.Size(369, 221);
            this.dgvLogs.TabIndex = 3;
            // 
            // txtValue
            // 
            this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue.Location = new System.Drawing.Point(284, 209);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(112, 25);
            this.txtValue.TabIndex = 2;
            this.txtValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValue_KeyPress);
            // 
            // lblPortStatus
            // 
            this.lblPortStatus.AutoSize = true;
            this.lblPortStatus.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblPortStatus.Location = new System.Drawing.Point(115, 212);
            this.lblPortStatus.Name = "lblPortStatus";
            this.lblPortStatus.Size = new System.Drawing.Size(32, 18);
            this.lblPortStatus.TabIndex = 1;
            this.lblPortStatus.Text = "...";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(6, 210);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(103, 30);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // FReturnAnalyze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 520);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnconform);
            this.Controls.Add(this.btnexport);
            this.Controls.Add(this.btnnew);
            this.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FReturnAnalyze";
            this.Text = "Analysis and Confirmation";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FReturnAnalyze_FormClosed);
            this.Load += new System.EventHandler(this.FReturnAnalyze_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGV)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnnew;
        private System.Windows.Forms.Button btnexport;
        private System.Windows.Forms.Button btnconform;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.ComponentModel.BackgroundWorker bgworksearch;
        private System.ComponentModel.BackgroundWorker bgworkexport;
        private System.ComponentModel.BackgroundWorker bgworkconform;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dGV;
        private System.Windows.Forms.Label lblinfo;
        private System.Windows.Forms.TextBox txtjob;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker datepc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtpsn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtReffDoc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnFindpsn;
        private System.Windows.Forms.CheckBox ckOutstaningOnly;
        private System.Windows.Forms.CheckBox ckall;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblPortStatus;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridView dgvLogs;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtLabelID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtMax;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMin;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label lblMeasure;
        private System.Windows.Forms.Button btnNewCheck;
        private System.Windows.Forms.Label lblItemDescription;
        private System.Windows.Forms.PictureBox picStatus;
        private System.Windows.Forms.DataGridView DGVDetail;
    }
}