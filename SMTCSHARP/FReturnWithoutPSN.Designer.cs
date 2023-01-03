namespace SMTCSHARP
{
    partial class FReturnWithoutPSN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FReturnWithoutPSN));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbLoc = new System.Windows.Forms.ComboBox();
            this.btnsetting = new System.Windows.Forms.Button();
            this.dGV = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txt3N1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtitemname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt3N2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLotNum = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtActualQty = new System.Windows.Forms.TextBox();
            this.btnreturnprint = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSearchItemcd = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnexport = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dt2 = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dt1 = new System.Windows.Forms.DateTimePicker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dGV)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source Location :";
            this.label1.Visible = false;
            // 
            // cmbLoc
            // 
            this.cmbLoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLoc.FormattingEnabled = true;
            this.cmbLoc.Items.AddRange(new object[] {
            "PLANT1",
            "PLANT2",
            "PLANT_NA"});
            this.cmbLoc.Location = new System.Drawing.Point(174, 56);
            this.cmbLoc.Name = "cmbLoc";
            this.cmbLoc.Size = new System.Drawing.Size(162, 26);
            this.cmbLoc.TabIndex = 1;
            this.cmbLoc.Visible = false;
            this.cmbLoc.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // btnsetting
            // 
            this.btnsetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnsetting.Image = ((System.Drawing.Image)(resources.GetObject("btnsetting.Image")));
            this.btnsetting.Location = new System.Drawing.Point(839, 23);
            this.btnsetting.Name = "btnsetting";
            this.btnsetting.Size = new System.Drawing.Size(33, 26);
            this.btnsetting.TabIndex = 57;
            this.btnsetting.UseVisualStyleBackColor = true;
            this.btnsetting.Click += new System.EventHandler(this.btnsetting_Click);
            // 
            // dGV
            // 
            this.dGV.AllowUserToAddRows = false;
            this.dGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV.Location = new System.Drawing.Point(6, 246);
            this.dGV.Name = "dGV";
            this.dGV.Size = new System.Drawing.Size(866, 229);
            this.dGV.TabIndex = 58;
            this.dGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGV_CellClick);
            this.dGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGV_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 20);
            this.label2.TabIndex = 59;
            this.label2.Text = "Item Code [3N1] :";
            // 
            // txt3N1
            // 
            this.txt3N1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt3N1.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt3N1.Location = new System.Drawing.Point(174, 93);
            this.txt3N1.Name = "txt3N1";
            this.txt3N1.Size = new System.Drawing.Size(264, 25);
            this.txt3N1.TabIndex = 60;
            this.txt3N1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt3N1_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 20);
            this.label3.TabIndex = 61;
            this.label3.Text = "Item Name :";
            // 
            // txtitemname
            // 
            this.txtitemname.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtitemname.Location = new System.Drawing.Point(174, 124);
            this.txtitemname.Name = "txtitemname";
            this.txtitemname.ReadOnly = true;
            this.txtitemname.Size = new System.Drawing.Size(264, 25);
            this.txtitemname.TabIndex = 62;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(2, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 20);
            this.label4.TabIndex = 63;
            this.label4.Text = "Supplied Qty [3N2] :";
            // 
            // txt3N2
            // 
            this.txt3N2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt3N2.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt3N2.Location = new System.Drawing.Point(174, 154);
            this.txt3N2.Name = "txt3N2";
            this.txt3N2.Size = new System.Drawing.Size(111, 25);
            this.txt3N2.TabIndex = 64;
            this.txt3N2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt3N2_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(291, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 20);
            this.label5.TabIndex = 65;
            this.label5.Text = "Lot. Num.";
            // 
            // txtLotNum
            // 
            this.txtLotNum.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLotNum.Location = new System.Drawing.Point(369, 154);
            this.txtLotNum.Name = "txtLotNum";
            this.txtLotNum.ReadOnly = true;
            this.txtLotNum.Size = new System.Drawing.Size(154, 25);
            this.txtLotNum.TabIndex = 66;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(2, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 20);
            this.label6.TabIndex = 67;
            this.label6.Text = "Actual Qty :";
            // 
            // txtActualQty
            // 
            this.txtActualQty.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActualQty.Location = new System.Drawing.Point(174, 184);
            this.txtActualQty.Name = "txtActualQty";
            this.txtActualQty.Size = new System.Drawing.Size(111, 25);
            this.txtActualQty.TabIndex = 68;
            this.txtActualQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtActualQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtActualQty_KeyPress);
            // 
            // btnreturnprint
            // 
            this.btnreturnprint.Image = ((System.Drawing.Image)(resources.GetObject("btnreturnprint.Image")));
            this.btnreturnprint.Location = new System.Drawing.Point(252, 214);
            this.btnreturnprint.Name = "btnreturnprint";
            this.btnreturnprint.Size = new System.Drawing.Size(33, 26);
            this.btnreturnprint.TabIndex = 71;
            this.btnreturnprint.UseVisualStyleBackColor = true;
            this.btnreturnprint.Click += new System.EventHandler(this.btnreturnprint_Click);
            // 
            // btnsave
            // 
            this.btnsave.Image = ((System.Drawing.Image)(resources.GetObject("btnsave.Image")));
            this.btnsave.Location = new System.Drawing.Point(213, 214);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(33, 26);
            this.btnsave.TabIndex = 70;
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.Location = new System.Drawing.Point(176, 214);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(33, 26);
            this.btnNew.TabIndex = 69;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtSearchItemcd);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.btnexport);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.dt2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dt1);
            this.groupBox1.Location = new System.Drawing.Point(581, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 184);
            this.groupBox1.TabIndex = 72;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // txtSearchItemcd
            // 
            this.txtSearchItemcd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchItemcd.Location = new System.Drawing.Point(145, 50);
            this.txtSearchItemcd.Name = "txtSearchItemcd";
            this.txtSearchItemcd.Size = new System.Drawing.Size(139, 24);
            this.txtSearchItemcd.TabIndex = 75;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(141, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 20);
            this.label9.TabIndex = 74;
            this.label9.Text = "Item Code";
            // 
            // btnexport
            // 
            this.btnexport.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnexport.Image = ((System.Drawing.Image)(resources.GetObject("btnexport.Image")));
            this.btnexport.Location = new System.Drawing.Point(145, 150);
            this.btnexport.Name = "btnexport";
            this.btnexport.Size = new System.Drawing.Size(30, 28);
            this.btnexport.TabIndex = 73;
            this.toolTip1.SetToolTip(this.btnexport, "Export to spreadsheet file");
            this.btnexport.UseVisualStyleBackColor = true;
            this.btnexport.Click += new System.EventHandler(this.btnexport_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(6, 150);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(133, 28);
            this.btnSearch.TabIndex = 65;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dt2
            // 
            this.dt2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dt2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt2.Location = new System.Drawing.Point(6, 110);
            this.dt2.Name = "dt2";
            this.dt2.Size = new System.Drawing.Size(133, 24);
            this.dt2.TabIndex = 64;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(2, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 20);
            this.label8.TabIndex = 63;
            this.label8.Text = "To";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(2, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 20);
            this.label7.TabIndex = 62;
            this.label7.Text = "From";
            // 
            // dt1
            // 
            this.dt1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dt1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt1.Location = new System.Drawing.Point(6, 50);
            this.dt1.Name = "dt1";
            this.dt1.Size = new System.Drawing.Size(133, 24);
            this.dt1.TabIndex = 0;
            // 
            // FReturnWithoutPSN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(884, 487);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnreturnprint);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.txtActualQty);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtLotNum);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt3N2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtitemname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt3N1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dGV);
            this.Controls.Add(this.btnsetting);
            this.Controls.Add(this.cmbLoc);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(736, 526);
            this.Name = "FReturnWithoutPSN";
            this.Text = "Return Without PSN";
            this.Load += new System.EventHandler(this.FReturnWithoutPSN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGV)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbLoc;
        private System.Windows.Forms.Button btnsetting;
        private System.Windows.Forms.DataGridView dGV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt3N1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtitemname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt3N2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLotNum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtActualQty;
        private System.Windows.Forms.Button btnreturnprint;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dt1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dt2;
        private System.Windows.Forms.Button btnexport;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtSearchItemcd;
        private System.Windows.Forms.Label label9;
    }
}