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
            ((System.ComponentModel.ISupportInitialize)(this.dGV)).BeginInit();
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
            this.btnsetting.Location = new System.Drawing.Point(610, 23);
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
            this.dGV.Size = new System.Drawing.Size(637, 229);
            this.dGV.TabIndex = 58;
            this.dGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGV_CellClick);
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
            // FReturnWithoutPSN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(655, 487);
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
            this.Name = "FReturnWithoutPSN";
            this.Text = "Return Without PSN";
            this.Load += new System.EventHandler(this.FReturnWithoutPSN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGV)).EndInit();
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
    }
}