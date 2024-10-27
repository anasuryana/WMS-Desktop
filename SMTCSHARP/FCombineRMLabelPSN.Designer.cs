namespace SMTCSHARP
{
    partial class FCombineRMLabelPSN
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
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnTriggerExportModal = new System.Windows.Forms.Button();
            this.dGV_lbljoin = new System.Windows.Forms.DataGridView();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.lblPortStatus = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtMCZ = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMC = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt3n2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt3n1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProcess = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDocument = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClearLogs = new System.Windows.Forms.Button();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.dgvLogs = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_lbljoin)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(17, 38);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(73, 26);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(92, 38);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 26);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save && Print";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnTriggerExportModal
            // 
            this.btnTriggerExportModal.Location = new System.Drawing.Point(218, 38);
            this.btnTriggerExportModal.Name = "btnTriggerExportModal";
            this.btnTriggerExportModal.Size = new System.Drawing.Size(73, 26);
            this.btnTriggerExportModal.TabIndex = 2;
            this.btnTriggerExportModal.Text = "Export";
            this.btnTriggerExportModal.UseVisualStyleBackColor = true;
            // 
            // dGV_lbljoin
            // 
            this.dGV_lbljoin.AllowUserToAddRows = false;
            this.dGV_lbljoin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGV_lbljoin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV_lbljoin.Location = new System.Drawing.Point(17, 276);
            this.dGV_lbljoin.Name = "dGV_lbljoin";
            this.dGV_lbljoin.ReadOnly = true;
            this.dGV_lbljoin.Size = new System.Drawing.Size(801, 242);
            this.dGV_lbljoin.TabIndex = 63;
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.lblPortStatus);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.txtMax);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtMin);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtValue);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(17, 189);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(801, 81);
            this.groupBox1.TabIndex = 70;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Value Checking";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(141, 61);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(77, 14);
            this.linkLabel1.TabIndex = 78;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "See logs ?";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lblPortStatus
            // 
            this.lblPortStatus.AutoSize = true;
            this.lblPortStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblPortStatus.Location = new System.Drawing.Point(141, 32);
            this.lblPortStatus.Name = "lblPortStatus";
            this.lblPortStatus.Size = new System.Drawing.Size(32, 18);
            this.lblPortStatus.TabIndex = 77;
            this.lblPortStatus.Text = "...";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(11, 32);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(124, 43);
            this.btnConnect.TabIndex = 76;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtMax
            // 
            this.txtMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMax.Location = new System.Drawing.Point(456, 38);
            this.txtMax.Name = "txtMax";
            this.txtMax.ReadOnly = true;
            this.txtMax.Size = new System.Drawing.Size(68, 25);
            this.txtMax.TabIndex = 75;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(418, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 18);
            this.label9.TabIndex = 74;
            this.label9.Text = "Max";
            // 
            // txtMin
            // 
            this.txtMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMin.Location = new System.Drawing.Point(350, 38);
            this.txtMin.Name = "txtMin";
            this.txtMin.ReadOnly = true;
            this.txtMin.Size = new System.Drawing.Size(62, 25);
            this.txtMin.TabIndex = 73;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(300, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 18);
            this.label8.TabIndex = 72;
            this.label8.Text = "Min";
            // 
            // txtValue
            // 
            this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtValue.Location = new System.Drawing.Point(642, 41);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(144, 25);
            this.txtValue.TabIndex = 71;
            this.txtValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValue_KeyPress);
            this.txtValue.Leave += new System.EventHandler(this.txtValue_Leave);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(579, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 18);
            this.label7.TabIndex = 70;
            this.label7.Text = "Value";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtMCZ);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtMC);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txt3n2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txt3n1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtProcess);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtDocument);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(17, 79);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(801, 93);
            this.groupBox2.TabIndex = 71;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Document Validation";
            // 
            // txtMCZ
            // 
            this.txtMCZ.Location = new System.Drawing.Point(625, 55);
            this.txtMCZ.Name = "txtMCZ";
            this.txtMCZ.ReadOnly = true;
            this.txtMCZ.Size = new System.Drawing.Size(144, 25);
            this.txtMCZ.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(578, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 18);
            this.label6.TabIndex = 21;
            this.label6.Text = "MCZ";
            // 
            // txtMC
            // 
            this.txtMC.Location = new System.Drawing.Point(380, 55);
            this.txtMC.Name = "txtMC";
            this.txtMC.ReadOnly = true;
            this.txtMC.Size = new System.Drawing.Size(144, 25);
            this.txtMC.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(327, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 18);
            this.label5.TabIndex = 19;
            this.label5.Text = "MC";
            // 
            // txt3n2
            // 
            this.txt3n2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt3n2.Location = new System.Drawing.Point(625, 24);
            this.txt3n2.Name = "txt3n2";
            this.txt3n2.Size = new System.Drawing.Size(144, 25);
            this.txt3n2.TabIndex = 18;
            this.txt3n2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt3n2_KeyPress_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(578, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 18);
            this.label3.TabIndex = 17;
            this.label3.Text = "3N2";
            // 
            // txt3n1
            // 
            this.txt3n1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt3n1.Location = new System.Drawing.Point(380, 24);
            this.txt3n1.Name = "txt3n1";
            this.txt3n1.Size = new System.Drawing.Size(144, 25);
            this.txt3n1.TabIndex = 16;
            this.txt3n1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt3n1_KeyPress_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(327, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 18);
            this.label2.TabIndex = 15;
            this.label2.Text = "3N1";
            // 
            // txtProcess
            // 
            this.txtProcess.Location = new System.Drawing.Point(86, 55);
            this.txtProcess.Name = "txtProcess";
            this.txtProcess.ReadOnly = true;
            this.txtProcess.Size = new System.Drawing.Size(144, 25);
            this.txtProcess.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 18);
            this.label4.TabIndex = 13;
            this.label4.Text = "Process";
            // 
            // txtDocument
            // 
            this.txtDocument.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDocument.Location = new System.Drawing.Point(86, 24);
            this.txtDocument.Name = "txtDocument";
            this.txtDocument.Size = new System.Drawing.Size(189, 25);
            this.txtDocument.TabIndex = 12;
            this.txtDocument.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDocument_KeyPress_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "Document";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dgvLogs);
            this.panel1.Controls.Add(this.btnClearLogs);
            this.panel1.Controls.Add(this.linkLabel2);
            this.panel1.Location = new System.Drawing.Point(12, 276);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(806, 238);
            this.panel1.TabIndex = 72;
            this.panel1.Visible = false;
            // 
            // btnClearLogs
            // 
            this.btnClearLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearLogs.BackColor = System.Drawing.Color.DarkOrange;
            this.btnClearLogs.Location = new System.Drawing.Point(674, 8);
            this.btnClearLogs.Name = "btnClearLogs";
            this.btnClearLogs.Size = new System.Drawing.Size(126, 33);
            this.btnClearLogs.TabIndex = 2;
            this.btnClearLogs.Text = "Clear logs";
            this.btnClearLogs.UseVisualStyleBackColor = false;
            this.btnClearLogs.Click += new System.EventHandler(this.btnClearLogs_Click);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(12, 8);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(88, 18);
            this.linkLabel2.TabIndex = 1;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Close logs";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // dgvLogs
            // 
            this.dgvLogs.AllowUserToDeleteRows = false;
            this.dgvLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLogs.Location = new System.Drawing.Point(5, 47);
            this.dgvLogs.Name = "dgvLogs";
            this.dgvLogs.ReadOnly = true;
            this.dgvLogs.Size = new System.Drawing.Size(795, 188);
            this.dgvLogs.TabIndex = 3;
            // 
            // FCombineRMLabelPSN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dGV_lbljoin);
            this.Controls.Add(this.btnTriggerExportModal);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FCombineRMLabelPSN";
            this.Text = "Combine RM Label PSN";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FCombineRMLabelPSN_FormClosed);
            this.Load += new System.EventHandler(this.FCombineRMLabelPSN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGV_lbljoin)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnTriggerExportModal;
        private System.Windows.Forms.DataGridView dGV_lbljoin;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMax;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtMCZ;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt3n2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt3n1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProcess;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDocument;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblPortStatus;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Button btnClearLogs;
        private System.Windows.Forms.DataGridView dgvLogs;
    }
}