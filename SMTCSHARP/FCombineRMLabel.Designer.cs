namespace SMTCSHARP
{
    partial class FCombineRMLabel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCombineRMLabel));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtlotno = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dGV_lbljoin = new System.Windows.Forms.DataGridView();
            this.btnSaveCombine = new System.Windows.Forms.Button();
            this.btnreturnprint = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnCancelScan = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.panelExport = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.DTPTo = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.DTPFrom = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_lbljoin)).BeginInit();
            this.panelExport.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 58;
            this.label1.Text = "Item Code";
            // 
            // textBox1
            // 
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox1.Location = new System.Drawing.Point(124, 75);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(335, 25);
            this.textBox1.TabIndex = 59;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // txtlotno
            // 
            this.txtlotno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtlotno.Location = new System.Drawing.Point(124, 106);
            this.txtlotno.Name = "txtlotno";
            this.txtlotno.Size = new System.Drawing.Size(335, 25);
            this.txtlotno.TabIndex = 61;
            this.txtlotno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtlotno_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 18);
            this.label2.TabIndex = 60;
            this.label2.Text = "Lot Number";
            // 
            // dGV_lbljoin
            // 
            this.dGV_lbljoin.AllowUserToAddRows = false;
            this.dGV_lbljoin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGV_lbljoin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV_lbljoin.Location = new System.Drawing.Point(12, 169);
            this.dGV_lbljoin.Name = "dGV_lbljoin";
            this.dGV_lbljoin.ReadOnly = true;
            this.dGV_lbljoin.Size = new System.Drawing.Size(792, 322);
            this.dGV_lbljoin.TabIndex = 62;
            // 
            // btnSaveCombine
            // 
            this.btnSaveCombine.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveCombine.Image")));
            this.btnSaveCombine.Location = new System.Drawing.Point(216, 137);
            this.btnSaveCombine.Name = "btnSaveCombine";
            this.btnSaveCombine.Size = new System.Drawing.Size(33, 26);
            this.btnSaveCombine.TabIndex = 63;
            this.btnSaveCombine.UseVisualStyleBackColor = true;
            this.btnSaveCombine.Click += new System.EventHandler(this.btnSaveCombine_Click);
            // 
            // btnreturnprint
            // 
            this.btnreturnprint.Image = ((System.Drawing.Image)(resources.GetObject("btnreturnprint.Image")));
            this.btnreturnprint.Location = new System.Drawing.Point(255, 137);
            this.btnreturnprint.Name = "btnreturnprint";
            this.btnreturnprint.Size = new System.Drawing.Size(33, 26);
            this.btnreturnprint.TabIndex = 64;
            this.btnreturnprint.UseVisualStyleBackColor = true;
            this.btnreturnprint.Click += new System.EventHandler(this.btnreturnprint_Click);
            // 
            // btnNew
            // 
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.Location = new System.Drawing.Point(124, 137);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(33, 26);
            this.btnNew.TabIndex = 65;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnCancelScan
            // 
            this.btnCancelScan.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelScan.Image")));
            this.btnCancelScan.Location = new System.Drawing.Point(163, 137);
            this.btnCancelScan.Name = "btnCancelScan";
            this.btnCancelScan.Size = new System.Drawing.Size(33, 26);
            this.btnCancelScan.TabIndex = 67;
            this.toolTip1.SetToolTip(this.btnCancelScan, "Cancel last scan");
            this.btnCancelScan.UseVisualStyleBackColor = true;
            this.btnCancelScan.Click += new System.EventHandler(this.btnCancelScan_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(294, 137);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 26);
            this.button1.TabIndex = 68;
            this.button1.Text = "Report";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelExport
            // 
            this.panelExport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panelExport.Controls.Add(this.btnClose);
            this.panelExport.Controls.Add(this.btnExport);
            this.panelExport.Controls.Add(this.DTPTo);
            this.panelExport.Controls.Add(this.label4);
            this.panelExport.Controls.Add(this.DTPFrom);
            this.panelExport.Controls.Add(this.label3);
            this.panelExport.Location = new System.Drawing.Point(12, 75);
            this.panelExport.Name = "panelExport";
            this.panelExport.Size = new System.Drawing.Size(792, 139);
            this.panelExport.TabIndex = 69;
            this.panelExport.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(405, 84);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(93, 27);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(306, 84);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(93, 27);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // DTPTo
            // 
            this.DTPTo.CustomFormat = "yyy-MM-dd";
            this.DTPTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPTo.Location = new System.Drawing.Point(453, 34);
            this.DTPTo.Name = "DTPTo";
            this.DTPTo.Size = new System.Drawing.Size(144, 25);
            this.DTPTo.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(423, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "To";
            // 
            // DTPFrom
            // 
            this.DTPFrom.CustomFormat = "yyy-MM-dd";
            this.DTPFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPFrom.Location = new System.Drawing.Point(235, 34);
            this.DTPFrom.Name = "DTPFrom";
            this.DTPFrom.Size = new System.Drawing.Size(144, 25);
            this.DTPFrom.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(189, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "From";
            // 
            // FCombineRMLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(819, 503);
            this.Controls.Add(this.panelExport);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnreturnprint);
            this.Controls.Add(this.btnSaveCombine);
            this.Controls.Add(this.dGV_lbljoin);
            this.Controls.Add(this.txtlotno);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelScan);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FCombineRMLabel";
            this.Text = "Combine RM Label";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FCombineRMLabel_FormClosed);
            this.Load += new System.EventHandler(this.FCombineRMLabel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGV_lbljoin)).EndInit();
            this.panelExport.ResumeLayout(false);
            this.panelExport.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtlotno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dGV_lbljoin;
        private System.Windows.Forms.Button btnSaveCombine;
        private System.Windows.Forms.Button btnreturnprint;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnCancelScan;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panelExport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DateTimePicker DTPTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker DTPFrom;
    }
}