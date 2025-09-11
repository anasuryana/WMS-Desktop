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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new SMTCSHARP.ProgressBarWithText();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtQty = new System.Windows.Forms.TextBox();
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbOutstandingOnly = new System.Windows.Forms.CheckBox();
            this.txtPallet = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPartCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.dGV = new System.Windows.Forms.DataGridView();
            this.btnFindpsn = new System.Windows.Forms.Button();
            this.txtDONumber = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.nudwo_printqty = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.dgvwo = new System.Windows.Forms.DataGridView();
            this.btnwo_print = new System.Windows.Forms.Button();
            this.txtwo_qty = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtwo_lotnumber = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtwo_partcode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtwo_donumber = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrintQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGV2)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGV)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudwo_printqty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvwo)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(7, 39);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1259, 563);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.btnFindpsn);
            this.tabPage1.Controls.Add(this.txtDONumber);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1251, 532);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "With Reference";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.progressBar1);
            this.groupBox3.Location = new System.Drawing.Point(323, 9);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(332, 66);
            this.groupBox3.TabIndex = 90;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Labeling Progress";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(9, 24);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(314, 30);
            this.progressBar1.TabIndex = 84;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtQty);
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
            this.groupBox2.Location = new System.Drawing.Point(661, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(584, 487);
            this.groupBox2.TabIndex = 89;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detail";
            // 
            // txtQty
            // 
            this.txtQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQty.Location = new System.Drawing.Point(5, 111);
            this.txtQty.MaxLength = 50;
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(119, 25);
            this.txtQty.TabIndex = 92;
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            this.txtQty.Leave += new System.EventHandler(this.txtQty_Leave);
            this.txtQty.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtQty_PreviewKeyDown);
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
            this.nudPrintQty.Location = new System.Drawing.Point(272, 111);
            this.nudPrintQty.Maximum = new decimal(new int[] {
            99,
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
            this.label6.Location = new System.Drawing.Point(269, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 18);
            this.label6.TabIndex = 88;
            this.label6.Text = "Print Qty";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Location = new System.Drawing.Point(545, 109);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(33, 26);
            this.btnPrint.TabIndex = 87;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // nudQty
            // 
            this.nudQty.Location = new System.Drawing.Point(382, 48);
            this.nudQty.Maximum = new decimal(new int[] {
            3000000,
            0,
            0,
            0});
            this.nudQty.Name = "nudQty";
            this.nudQty.Size = new System.Drawing.Size(95, 25);
            this.nudQty.TabIndex = 86;
            this.nudQty.ThousandsSeparator = true;
            this.nudQty.Visible = false;
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
            this.label3.Size = new System.Drawing.Size(120, 18);
            this.label3.TabIndex = 85;
            this.label3.Text = "Part Qty [3N2]";
            // 
            // txtLotNumber
            // 
            this.txtLotNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLotNumber.Location = new System.Drawing.Point(148, 111);
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
            this.label2.Location = new System.Drawing.Point(145, 92);
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
            this.dGV2.Location = new System.Drawing.Point(5, 144);
            this.dGV2.Name = "dGV2";
            this.dGV2.ReadOnly = true;
            this.dGV2.RowHeadersWidth = 51;
            this.dGV2.Size = new System.Drawing.Size(573, 337);
            this.dGV2.TabIndex = 82;
            this.dGV2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGV2_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 85;
            this.label1.Text = "DO Number";
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
            this.groupBox1.Location = new System.Drawing.Point(10, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(645, 415);
            this.groupBox1.TabIndex = 88;
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
            this.txtPartCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
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
            this.label4.Size = new System.Drawing.Size(128, 18);
            this.label4.TabIndex = 85;
            this.label4.Text = "Part Code [3N1]";
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.AutoSize = true;
            this.lblInfo.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblInfo.ForeColor = System.Drawing.Color.White;
            this.lblInfo.Location = new System.Drawing.Point(532, 21);
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
            this.dGV.Size = new System.Drawing.Size(633, 337);
            this.dGV.TabIndex = 81;
            this.dGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGV_CellClick);
            this.dGV.SelectionChanged += new System.EventHandler(this.dGV_SelectionChanged);
            // 
            // btnFindpsn
            // 
            this.btnFindpsn.Image = ((System.Drawing.Image)(resources.GetObject("btnFindpsn.Image")));
            this.btnFindpsn.Location = new System.Drawing.Point(284, 23);
            this.btnFindpsn.Name = "btnFindpsn";
            this.btnFindpsn.Size = new System.Drawing.Size(33, 27);
            this.btnFindpsn.TabIndex = 87;
            this.btnFindpsn.UseVisualStyleBackColor = true;
            this.btnFindpsn.Click += new System.EventHandler(this.btnFindpsn_Click);
            // 
            // txtDONumber
            // 
            this.txtDONumber.Location = new System.Drawing.Point(115, 23);
            this.txtDONumber.Name = "txtDONumber";
            this.txtDONumber.ReadOnly = true;
            this.txtDONumber.Size = new System.Drawing.Size(163, 25);
            this.txtDONumber.TabIndex = 86;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.nudwo_printqty);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.dgvwo);
            this.tabPage2.Controls.Add(this.btnwo_print);
            this.tabPage2.Controls.Add(this.txtwo_qty);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.txtwo_lotnumber);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.txtwo_partcode);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.txtwo_donumber);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1251, 532);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Without Reference";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // nudwo_printqty
            // 
            this.nudwo_printqty.Location = new System.Drawing.Point(408, 154);
            this.nudwo_printqty.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nudwo_printqty.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudwo_printqty.Name = "nudwo_printqty";
            this.nudwo_printqty.Size = new System.Drawing.Size(77, 25);
            this.nudwo_printqty.TabIndex = 101;
            this.nudwo_printqty.ThousandsSeparator = true;
            this.nudwo_printqty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudwo_printqty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudwo_printqty_KeyPress);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(292, 159);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 18);
            this.label12.TabIndex = 100;
            this.label12.Text = "Print Qty";
            // 
            // dgvwo
            // 
            this.dgvwo.AllowUserToAddRows = false;
            this.dgvwo.AllowUserToDeleteRows = false;
            this.dgvwo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvwo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvwo.Location = new System.Drawing.Point(17, 183);
            this.dgvwo.Name = "dgvwo";
            this.dgvwo.ReadOnly = true;
            this.dgvwo.RowHeadersWidth = 51;
            this.dgvwo.Size = new System.Drawing.Size(1228, 343);
            this.dgvwo.TabIndex = 99;
            this.dgvwo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvwo_CellClick);
            // 
            // btnwo_print
            // 
            this.btnwo_print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnwo_print.Image = ((System.Drawing.Image)(resources.GetObject("btnwo_print.Image")));
            this.btnwo_print.Location = new System.Drawing.Point(1212, 152);
            this.btnwo_print.Name = "btnwo_print";
            this.btnwo_print.Size = new System.Drawing.Size(33, 26);
            this.btnwo_print.TabIndex = 98;
            this.btnwo_print.UseVisualStyleBackColor = true;
            this.btnwo_print.Click += new System.EventHandler(this.btnwo_print_Click);
            // 
            // txtwo_qty
            // 
            this.txtwo_qty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtwo_qty.Location = new System.Drawing.Point(123, 119);
            this.txtwo_qty.MaxLength = 50;
            this.txtwo_qty.Name = "txtwo_qty";
            this.txtwo_qty.Size = new System.Drawing.Size(106, 25);
            this.txtwo_qty.TabIndex = 96;
            this.txtwo_qty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtwo_qty_KeyPress);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 119);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 18);
            this.label10.TabIndex = 95;
            this.label10.Text = "Part Qty";
            // 
            // txtwo_lotnumber
            // 
            this.txtwo_lotnumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtwo_lotnumber.Location = new System.Drawing.Point(123, 152);
            this.txtwo_lotnumber.MaxLength = 25;
            this.txtwo_lotnumber.Name = "txtwo_lotnumber";
            this.txtwo_lotnumber.Size = new System.Drawing.Size(106, 25);
            this.txtwo_lotnumber.TabIndex = 94;
            this.txtwo_lotnumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtwo_lotnumber_KeyPress);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 152);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 18);
            this.label11.TabIndex = 93;
            this.label11.Text = "Lot Number";
            // 
            // txtwo_partcode
            // 
            this.txtwo_partcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtwo_partcode.Location = new System.Drawing.Point(123, 88);
            this.txtwo_partcode.MaxLength = 25;
            this.txtwo_partcode.Name = "txtwo_partcode";
            this.txtwo_partcode.Size = new System.Drawing.Size(165, 25);
            this.txtwo_partcode.TabIndex = 90;
            this.txtwo_partcode.TextChanged += new System.EventHandler(this.txtwo_partcode_TextChanged);
            this.txtwo_partcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtwo_partcode_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 18);
            this.label9.TabIndex = 89;
            this.label9.Text = "Part Code";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 18);
            this.label8.TabIndex = 87;
            this.label8.Text = "DO Number";
            // 
            // txtwo_donumber
            // 
            this.txtwo_donumber.Location = new System.Drawing.Point(123, 29);
            this.txtwo_donumber.Name = "txtwo_donumber";
            this.txtwo_donumber.Size = new System.Drawing.Size(230, 25);
            this.txtwo_donumber.TabIndex = 88;
            this.txtwo_donumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtwo_donumber_KeyPress);
            this.txtwo_donumber.Leave += new System.EventHandler(this.txtwo_donumber_Leave);
            // 
            // FIncomingLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 604);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FIncomingLabel";
            this.Text = "Incoming Part Labeling";
            this.Load += new System.EventHandler(this.FIncomingLabel_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrintQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGV2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGV)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudwo_printqty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvwo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox3;
        private ProgressBarWithText progressBar1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label lblPartCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudPrintQty;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.NumericUpDown nudQty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLotNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dGV2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbOutstandingOnly;
        private System.Windows.Forms.TextBox txtPallet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPartCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.DataGridView dGV;
        private System.Windows.Forms.Button btnFindpsn;
        private System.Windows.Forms.TextBox txtDONumber;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtwo_donumber;
        private System.Windows.Forms.TextBox txtwo_partcode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtwo_qty;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtwo_lotnumber;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnwo_print;
        private System.Windows.Forms.DataGridView dgvwo;
        private System.Windows.Forms.NumericUpDown nudwo_printqty;
        private System.Windows.Forms.Label label12;
    }
}