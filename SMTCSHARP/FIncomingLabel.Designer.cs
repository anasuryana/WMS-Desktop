namespace SMTCSHARP
{
    partial class FIncomingLabel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FIncomingLabel));
            this.label1 = new System.Windows.Forms.Label();
            this.txtDONumber = new System.Windows.Forms.TextBox();
            this.btnFindpsn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbOutstandingOnly = new System.Windows.Forms.CheckBox();
            this.txtPallet = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPartCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.dGV = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblPartCode = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nudPrintQty = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.nudQty = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLotNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dGV2 = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new SMTCSHARP.ProgressBarWithText();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGV)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrintQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGV2)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "DO Number";
            // 
            // txtDONumber
            // 
            this.txtDONumber.Location = new System.Drawing.Point(118, 40);
            this.txtDONumber.Name = "txtDONumber";
            this.txtDONumber.ReadOnly = true;
            this.txtDONumber.Size = new System.Drawing.Size(163, 25);
            this.txtDONumber.TabIndex = 1;
            // 
            // btnFindpsn
            // 
            this.btnFindpsn.Image = ((System.Drawing.Image)(resources.GetObject("btnFindpsn.Image")));
            this.btnFindpsn.Location = new System.Drawing.Point(287, 40);
            this.btnFindpsn.Name = "btnFindpsn";
            this.btnFindpsn.Size = new System.Drawing.Size(33, 27);
            this.btnFindpsn.TabIndex = 79;
            this.btnFindpsn.UseVisualStyleBackColor = true;
            this.btnFindpsn.Click += new System.EventHandler(this.btnFindpsn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cbOutstandingOnly);
            this.groupBox1.Controls.Add(this.txtPallet);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtPartCode);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblInfo);
            this.groupBox1.Controls.Add(this.dGV);
            this.groupBox1.Location = new System.Drawing.Point(13, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(637, 410);
            this.groupBox1.TabIndex = 81;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Resume";
            // 
            // cbOutstandingOnly
            // 
            this.cbOutstandingOnly.AutoSize = true;
            this.cbOutstandingOnly.Location = new System.Drawing.Point(373, 43);
            this.cbOutstandingOnly.Name = "cbOutstandingOnly";
            this.cbOutstandingOnly.Size = new System.Drawing.Size(155, 22);
            this.cbOutstandingOnly.TabIndex = 89;
            this.cbOutstandingOnly.Text = "Outstanding Only";
            this.cbOutstandingOnly.UseVisualStyleBackColor = true;
            this.cbOutstandingOnly.CheckedChanged += new System.EventHandler(this.cbOutstandingOnly_CheckedChanged);
            // 
            // txtPallet
            // 
            this.txtPallet.Location = new System.Drawing.Point(6, 41);
            this.txtPallet.MaxLength = 25;
            this.txtPallet.Name = "txtPallet";
            this.txtPallet.Size = new System.Drawing.Size(165, 25);
            this.txtPallet.TabIndex = 88;
            this.txtPallet.TextChanged += new System.EventHandler(this.txtPallet_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 18);
            this.label5.TabIndex = 87;
            this.label5.Text = "Pallet";
            // 
            // txtPartCode
            // 
            this.txtPartCode.Location = new System.Drawing.Point(192, 42);
            this.txtPartCode.MaxLength = 25;
            this.txtPartCode.Name = "txtPartCode";
            this.txtPartCode.Size = new System.Drawing.Size(165, 25);
            this.txtPartCode.TabIndex = 86;
            this.txtPartCode.TextChanged += new System.EventHandler(this.txtPartCode_TextChanged);
            this.txtPartCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPartCode_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(189, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 85;
            this.label4.Text = "Part Code";
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.AutoSize = true;
            this.lblInfo.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblInfo.ForeColor = System.Drawing.Color.White;
            this.lblInfo.Location = new System.Drawing.Point(524, 21);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(32, 18);
            this.lblInfo.TabIndex = 84;
            this.lblInfo.Text = "...";
            // 
            // dGV
            // 
            this.dGV.AllowUserToAddRows = false;
            this.dGV.AllowUserToDeleteRows = false;
            this.dGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV.Location = new System.Drawing.Point(6, 72);
            this.dGV.Name = "dGV";
            this.dGV.ReadOnly = true;
            this.dGV.RowHeadersWidth = 51;
            this.dGV.Size = new System.Drawing.Size(625, 332);
            this.dGV.TabIndex = 81;
            this.dGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGV_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lblPartCode);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.nudPrintQty);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.btnPrint);
            this.groupBox2.Controls.Add(this.nudQty);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtLotNumber);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dGV2);
            this.groupBox2.Location = new System.Drawing.Point(656, 26);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(499, 482);
            this.groupBox2.TabIndex = 82;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detail";
            // 
            // lblPartCode
            // 
            this.lblPartCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPartCode.AutoSize = true;
            this.lblPartCode.Font = new System.Drawing.Font("Consolas", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartCode.Location = new System.Drawing.Point(6, 48);
            this.lblPartCode.Name = "lblPartCode";
            this.lblPartCode.Size = new System.Drawing.Size(40, 22);
            this.lblPartCode.TabIndex = 91;
            this.lblPartCode.Text = "...";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 18);
            this.label7.TabIndex = 90;
            this.label7.Text = "Part Code";
            // 
            // nudPrintQty
            // 
            this.nudPrintQty.Location = new System.Drawing.Point(241, 111);
            this.nudPrintQty.Maximum = new decimal(new int[] {
            21,
            0,
            0,
            0});
            this.nudPrintQty.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPrintQty.Name = "nudPrintQty";
            this.nudPrintQty.Size = new System.Drawing.Size(77, 25);
            this.nudPrintQty.TabIndex = 89;
            this.nudPrintQty.ThousandsSeparator = true;
            this.nudPrintQty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPrintQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudPrintQty_KeyPress);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(238, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 18);
            this.label6.TabIndex = 88;
            this.label6.Text = "Print Qty";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Location = new System.Drawing.Point(460, 109);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(33, 26);
            this.btnPrint.TabIndex = 87;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // nudQty
            // 
            this.nudQty.Location = new System.Drawing.Point(7, 112);
            this.nudQty.Maximum = new decimal(new int[] {
            3000000,
            0,
            0,
            0});
            this.nudQty.Name = "nudQty";
            this.nudQty.Size = new System.Drawing.Size(95, 25);
            this.nudQty.TabIndex = 86;
            this.nudQty.ThousandsSeparator = true;
            this.nudQty.ValueChanged += new System.EventHandler(this.nudQty_ValueChanged);
            this.nudQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudQty_KeyPress);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 18);
            this.label3.TabIndex = 85;
            this.label3.Text = "Part Qty";
            // 
            // txtLotNumber
            // 
            this.txtLotNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLotNumber.Location = new System.Drawing.Point(117, 111);
            this.txtLotNumber.MaxLength = 25;
            this.txtLotNumber.Name = "txtLotNumber";
            this.txtLotNumber.Size = new System.Drawing.Size(106, 25);
            this.txtLotNumber.TabIndex = 84;
            this.txtLotNumber.TextChanged += new System.EventHandler(this.txtLotNumber_TextChanged);
            this.txtLotNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLotNumber_KeyPress);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 18);
            this.label2.TabIndex = 83;
            this.label2.Text = "Lot Number";
            // 
            // dGV2
            // 
            this.dGV2.AllowUserToAddRows = false;
            this.dGV2.AllowUserToDeleteRows = false;
            this.dGV2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV2.Location = new System.Drawing.Point(6, 144);
            this.dGV2.Name = "dGV2";
            this.dGV2.ReadOnly = true;
            this.dGV2.RowHeadersWidth = 51;
            this.dGV2.Size = new System.Drawing.Size(487, 332);
            this.dGV2.TabIndex = 82;
            this.dGV2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGV2_CellClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.progressBar1);
            this.groupBox3.Location = new System.Drawing.Point(326, 26);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(324, 66);
            this.groupBox3.TabIndex = 84;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Labeling Progress";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(9, 24);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(306, 30);
            this.progressBar1.TabIndex = 84;
            // 
            // FIncomingLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 529);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnFindpsn);
            this.Controls.Add(this.txtDONumber);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FIncomingLabel";
            this.Text = "Incoming Part Labeling";
            this.Load += new System.EventHandler(this.FIncomingLabel_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGV)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrintQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGV2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDONumber;
        private System.Windows.Forms.Button btnFindpsn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dGV;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dGV2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudQty;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.GroupBox groupBox3;
        private ProgressBarWithText progressBar1;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.TextBox txtPartCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLotNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPallet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbOutstandingOnly;
        private System.Windows.Forms.NumericUpDown nudPrintQty;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblPartCode;
    }
}