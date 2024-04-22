namespace SMTCSHARP
{
    partial class FKittingReturnXRay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FKittingReturnXRay));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnXRayGetter = new System.Windows.Forms.Button();
            this.DGVTemp = new System.Windows.Forms.DataGridView();
            this.btnNew = new System.Windows.Forms.Button();
            this.txtjoblist = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtlot = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtbefqty = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtitmname = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtitemcd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtline = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtcat = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtpsn = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnreturnprint = new System.Windows.Forms.Button();
            this.btnRefreshSavedDoc = new System.Windows.Forms.Button();
            this.dGV = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVTemp)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGV)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 54);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(862, 520);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnNext);
            this.tabPage1.Controls.Add(this.btnXRayGetter);
            this.tabPage1.Controls.Add(this.DGVTemp);
            this.tabPage1.Controls.Add(this.btnNew);
            this.tabPage1.Controls.Add(this.txtjoblist);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.txtlot);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.txtbefqty);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txtitmname);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtitemcd);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtline);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtcat);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtpsn);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(854, 489);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Input";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.AutoSize = true;
            this.btnNext.Location = new System.Drawing.Point(787, 161);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(61, 28);
            this.btnNext.TabIndex = 94;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnXRayGetter
            // 
            this.btnXRayGetter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXRayGetter.AutoSize = true;
            this.btnXRayGetter.Location = new System.Drawing.Point(555, 161);
            this.btnXRayGetter.Name = "btnXRayGetter";
            this.btnXRayGetter.Size = new System.Drawing.Size(226, 28);
            this.btnXRayGetter.TabIndex = 93;
            this.btnXRayGetter.Text = "Get Counting Result && Save";
            this.btnXRayGetter.UseVisualStyleBackColor = true;
            this.btnXRayGetter.Click += new System.EventHandler(this.btnXRayGetter_Click);
            // 
            // DGVTemp
            // 
            this.DGVTemp.AllowUserToAddRows = false;
            this.DGVTemp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVTemp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVTemp.Location = new System.Drawing.Point(6, 195);
            this.DGVTemp.Name = "DGVTemp";
            this.DGVTemp.RowHeadersWidth = 51;
            this.DGVTemp.Size = new System.Drawing.Size(842, 288);
            this.DGVTemp.TabIndex = 92;
            this.DGVTemp.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVTemp_CellClick);
            this.DGVTemp.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DGVTemp_CellPainting);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.Location = new System.Drawing.Point(516, 161);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(33, 28);
            this.btnNew.TabIndex = 85;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // txtjoblist
            // 
            this.txtjoblist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtjoblist.Location = new System.Drawing.Point(108, 163);
            this.txtjoblist.Multiline = true;
            this.txtjoblist.Name = "txtjoblist";
            this.txtjoblist.ReadOnly = true;
            this.txtjoblist.Size = new System.Drawing.Size(236, 25);
            this.txtjoblist.TabIndex = 80;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 166);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 18);
            this.label10.TabIndex = 79;
            this.label10.Text = "Job Number";
            // 
            // txtlot
            // 
            this.txtlot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtlot.Location = new System.Drawing.Point(714, 102);
            this.txtlot.Name = "txtlot";
            this.txtlot.ReadOnly = true;
            this.txtlot.Size = new System.Drawing.Size(109, 25);
            this.txtlot.TabIndex = 75;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(644, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 18);
            this.label8.TabIndex = 74;
            this.label8.Text = "Lot No.";
            // 
            // txtbefqty
            // 
            this.txtbefqty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbefqty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtbefqty.Location = new System.Drawing.Point(529, 102);
            this.txtbefqty.Name = "txtbefqty";
            this.txtbefqty.Size = new System.Drawing.Size(109, 25);
            this.txtbefqty.TabIndex = 73;
            this.txtbefqty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbefqty_KeyPress);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(375, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 18);
            this.label7.TabIndex = 72;
            this.label7.Text = "Supplied Qty [3N2]";
            // 
            // txtitmname
            // 
            this.txtitmname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtitmname.Location = new System.Drawing.Point(529, 71);
            this.txtitmname.Name = "txtitmname";
            this.txtitmname.ReadOnly = true;
            this.txtitmname.Size = new System.Drawing.Size(294, 25);
            this.txtitmname.TabIndex = 71;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(375, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 18);
            this.label6.TabIndex = 70;
            this.label6.Text = "Item Name";
            // 
            // txtitemcd
            // 
            this.txtitemcd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtitemcd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtitemcd.Location = new System.Drawing.Point(529, 39);
            this.txtitemcd.Name = "txtitemcd";
            this.txtitemcd.Size = new System.Drawing.Size(294, 25);
            this.txtitemcd.TabIndex = 69;
            this.txtitemcd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtitemcd_KeyPress);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(375, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 18);
            this.label5.TabIndex = 68;
            this.label5.Text = "Item Code [3N1]";
            // 
            // txtline
            // 
            this.txtline.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtline.Location = new System.Drawing.Point(108, 102);
            this.txtline.Name = "txtline";
            this.txtline.Size = new System.Drawing.Size(105, 25);
            this.txtline.TabIndex = 67;
            this.txtline.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtline_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 18);
            this.label3.TabIndex = 66;
            this.label3.Text = "Line";
            // 
            // txtcat
            // 
            this.txtcat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtcat.Location = new System.Drawing.Point(108, 71);
            this.txtcat.Name = "txtcat";
            this.txtcat.Size = new System.Drawing.Size(105, 25);
            this.txtcat.TabIndex = 65;
            this.txtcat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcat_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 18);
            this.label2.TabIndex = 64;
            this.label2.Text = "Category";
            // 
            // txtpsn
            // 
            this.txtpsn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtpsn.Location = new System.Drawing.Point(108, 39);
            this.txtpsn.Name = "txtpsn";
            this.txtpsn.Size = new System.Drawing.Size(236, 25);
            this.txtpsn.TabIndex = 63;
            this.txtpsn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpsn_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 18);
            this.label1.TabIndex = 62;
            this.label1.Text = "PSN No.";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnreturnprint);
            this.tabPage2.Controls.Add(this.btnRefreshSavedDoc);
            this.tabPage2.Controls.Add(this.dGV);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(854, 489);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "List";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnreturnprint
            // 
            this.btnreturnprint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnreturnprint.Image = ((System.Drawing.Image)(resources.GetObject("btnreturnprint.Image")));
            this.btnreturnprint.Location = new System.Drawing.Point(669, 15);
            this.btnreturnprint.Name = "btnreturnprint";
            this.btnreturnprint.Size = new System.Drawing.Size(33, 26);
            this.btnreturnprint.TabIndex = 95;
            this.btnreturnprint.UseVisualStyleBackColor = true;
            this.btnreturnprint.Click += new System.EventHandler(this.btnreturnprint_Click);
            // 
            // btnRefreshSavedDoc
            // 
            this.btnRefreshSavedDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshSavedDoc.Location = new System.Drawing.Point(708, 15);
            this.btnRefreshSavedDoc.Name = "btnRefreshSavedDoc";
            this.btnRefreshSavedDoc.Size = new System.Drawing.Size(140, 26);
            this.btnRefreshSavedDoc.TabIndex = 94;
            this.btnRefreshSavedDoc.Text = "Refresh";
            this.btnRefreshSavedDoc.UseVisualStyleBackColor = true;
            this.btnRefreshSavedDoc.Click += new System.EventHandler(this.btnRefreshSavedDoc_Click);
            // 
            // dGV
            // 
            this.dGV.AllowUserToAddRows = false;
            this.dGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV.Location = new System.Drawing.Point(6, 56);
            this.dGV.Name = "dGV";
            this.dGV.RowHeadersWidth = 62;
            this.dGV.Size = new System.Drawing.Size(842, 427);
            this.dGV.TabIndex = 56;
            // 
            // FKittingReturnXRay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 577);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FKittingReturnXRay";
            this.Text = "Return from Production by X-Ray";
            this.Load += new System.EventHandler(this.FKittingReturnXRay_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVTemp)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dGV;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.TextBox txtjoblist;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtlot;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtbefqty;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtitmname;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtitemcd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtline;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtcat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtpsn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DGVTemp;
        private System.Windows.Forms.Button btnXRayGetter;
        private System.Windows.Forms.Button btnRefreshSavedDoc;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnreturnprint;
    }
}