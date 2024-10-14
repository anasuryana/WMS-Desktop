namespace SMTCSHARP
{
    partial class FSplitLabel
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radMulti = new System.Windows.Forms.RadioButton();
            this.radTwo = new System.Windows.Forms.RadioButton();
            this.txt3n1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt3n2 = new System.Windows.Forms.TextBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtQty = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNIK = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCopies = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCopies)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.radMulti);
            this.groupBox1.Controls.Add(this.radTwo);
            this.groupBox1.Location = new System.Drawing.Point(17, 175);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(609, 89);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mode";
            // 
            // radMulti
            // 
            this.radMulti.AutoSize = true;
            this.radMulti.Location = new System.Drawing.Point(204, 39);
            this.radMulti.Name = "radMulti";
            this.radMulti.Size = new System.Drawing.Size(146, 22);
            this.radMulti.TabIndex = 1;
            this.radMulti.Text = "Multiple labels";
            this.radMulti.UseVisualStyleBackColor = true;
            this.radMulti.CheckedChanged += new System.EventHandler(this.radMulti_CheckedChanged);
            this.radMulti.Click += new System.EventHandler(this.radMulti_Click);
            // 
            // radTwo
            // 
            this.radTwo.AutoSize = true;
            this.radTwo.Location = new System.Drawing.Point(51, 39);
            this.radTwo.Name = "radTwo";
            this.radTwo.Size = new System.Drawing.Size(106, 22);
            this.radTwo.TabIndex = 0;
            this.radTwo.Text = "Two labels";
            this.radTwo.UseVisualStyleBackColor = true;
            this.radTwo.CheckedChanged += new System.EventHandler(this.radTwo_CheckedChanged);
            this.radTwo.Click += new System.EventHandler(this.radTwo_Click);
            // 
            // txt3n1
            // 
            this.txt3n1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt3n1.Location = new System.Drawing.Point(84, 66);
            this.txt3n1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt3n1.MaxLength = 255;
            this.txt3n1.Name = "txt3n1";
            this.txt3n1.Size = new System.Drawing.Size(542, 25);
            this.txt3n1.TabIndex = 1;
            this.txt3n1.TextChanged += new System.EventHandler(this.txt3n1_TextChanged);
            this.txt3n1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt3n1_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "3N1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "3N2";
            // 
            // txt3n2
            // 
            this.txt3n2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt3n2.Location = new System.Drawing.Point(84, 99);
            this.txt3n2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt3n2.Name = "txt3n2";
            this.txt3n2.Size = new System.Drawing.Size(222, 25);
            this.txt3n2.TabIndex = 3;
            this.txt3n2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt3n2_KeyPress);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Consolas", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblInfo.Location = new System.Drawing.Point(14, 292);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(43, 23);
            this.lblInfo.TabIndex = 5;
            this.lblInfo.Text = "...";
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(17, 348);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(186, 45);
            this.btnNew.TabIndex = 6;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "New Qty";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(448, 348);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(186, 45);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save && Print";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(84, 134);
            this.txtQty.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(143, 25);
            this.txtQty.TabIndex = 10;
            this.txtQty.Click += new System.EventHandler(this.txtQty_Click);
            this.txtQty.Enter += new System.EventHandler(this.txtQty_Enter);
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            this.txtQty.Leave += new System.EventHandler(this.txtQty_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 18);
            this.label3.TabIndex = 12;
            this.label3.Text = "NIK";
            // 
            // txtNIK
            // 
            this.txtNIK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNIK.Location = new System.Drawing.Point(84, 23);
            this.txtNIK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNIK.MaxLength = 255;
            this.txtNIK.Name = "txtNIK";
            this.txtNIK.Size = new System.Drawing.Size(143, 25);
            this.txtNIK.TabIndex = 0;
            this.toolTip1.SetToolTip(this.txtNIK, "-");
            this.txtNIK.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNIK_KeyPress);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(324, 23);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtName.MaxLength = 255;
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(302, 25);
            this.txtName.TabIndex = 13;
            this.toolTip1.SetToolTip(this.txtName, "-");
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(254, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 18);
            this.label5.TabIndex = 14;
            this.label5.Text = "Name";
            // 
            // txtCopies
            // 
            this.txtCopies.Location = new System.Drawing.Point(324, 134);
            this.txtCopies.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.txtCopies.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtCopies.Name = "txtCopies";
            this.txtCopies.Size = new System.Drawing.Size(69, 25);
            this.txtCopies.TabIndex = 16;
            this.txtCopies.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(254, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 18);
            this.label6.TabIndex = 15;
            this.label6.Text = "Copies";
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(249, 375);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(144, 18);
            this.linkLabel1.TabIndex = 17;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Failed to print ?";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // FSplitLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 405);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.txtCopies);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNIK);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt3n2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt3n1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "FSplitLabel";
            this.Text = "Split Labels";
            this.Load += new System.EventHandler(this.FSplitLabel_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCopies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt3n1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt3n2;
        private System.Windows.Forms.RadioButton radMulti;
        private System.Windows.Forms.RadioButton radTwo;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.NumericUpDown txtQty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNIK;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.NumericUpDown txtCopies;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}