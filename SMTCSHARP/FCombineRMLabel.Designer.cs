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
            this.btnsetting = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtlotno = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dGV_lbljoin = new System.Windows.Forms.DataGridView();
            this.btnSaveCombine = new System.Windows.Forms.Button();
            this.btnreturnprint = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnclose = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtserver = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textspeed = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.trackbarspeed = new System.Windows.Forms.TrackBar();
            this.textnarrow = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.trackbnarrow = new System.Windows.Forms.TrackBar();
            this.txthick = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.trackbthick = new System.Windows.Forms.TrackBar();
            this.txtdarkness = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.trackbdark = new System.Windows.Forms.TrackBar();
            this.listView1 = new System.Windows.Forms.ListView();
            this.ifCmbBox = new System.Windows.Forms.ComboBox();
            this.btnsearchprinter = new System.Windows.Forms.Button();
            this.btnSaveconfig = new System.Windows.Forms.Button();
            this.btnCancelScan = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dGV_lbljoin)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackbarspeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackbnarrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackbthick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackbdark)).BeginInit();
            this.SuspendLayout();
            // 
            // btnsetting
            // 
            this.btnsetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnsetting.Image = ((System.Drawing.Image)(resources.GetObject("btnsetting.Image")));
            this.btnsetting.Location = new System.Drawing.Point(774, 35);
            this.btnsetting.Name = "btnsetting";
            this.btnsetting.Size = new System.Drawing.Size(33, 26);
            this.btnsetting.TabIndex = 57;
            this.btnsetting.UseVisualStyleBackColor = true;
            this.btnsetting.Click += new System.EventHandler(this.btnsetting_Click);
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
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btnclose);
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Controls.Add(this.btnSaveconfig);
            this.panel2.Location = new System.Drawing.Point(12, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(806, 456);
            this.panel2.TabIndex = 66;
            this.panel2.Visible = false;
            // 
            // btnclose
            // 
            this.btnclose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnclose.Location = new System.Drawing.Point(399, 422);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(90, 31);
            this.btnclose.TabIndex = 7;
            this.btnclose.Text = "Close";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(799, 416);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtserver);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(791, 385);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Server";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtserver
            // 
            this.txtserver.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtserver.Location = new System.Drawing.Point(175, 145);
            this.txtserver.Name = "txtserver";
            this.txtserver.Size = new System.Drawing.Size(407, 25);
            this.txtserver.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(338, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Address";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textspeed);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.trackbarspeed);
            this.tabPage2.Controls.Add(this.textnarrow);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.trackbnarrow);
            this.tabPage2.Controls.Add(this.txthick);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.trackbthick);
            this.tabPage2.Controls.Add(this.txtdarkness);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.trackbdark);
            this.tabPage2.Controls.Add(this.listView1);
            this.tabPage2.Controls.Add(this.ifCmbBox);
            this.tabPage2.Controls.Add(this.btnsearchprinter);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(791, 385);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Printer";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textspeed
            // 
            this.textspeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textspeed.Location = new System.Drawing.Point(712, 307);
            this.textspeed.Multiline = true;
            this.textspeed.Name = "textspeed";
            this.textspeed.ReadOnly = true;
            this.textspeed.Size = new System.Drawing.Size(73, 44);
            this.textspeed.TabIndex = 19;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(8, 306);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 18);
            this.label16.TabIndex = 18;
            this.label16.Text = "Speed";
            // 
            // trackbarspeed
            // 
            this.trackbarspeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackbarspeed.Location = new System.Drawing.Point(103, 306);
            this.trackbarspeed.Maximum = 33;
            this.trackbarspeed.Minimum = 1;
            this.trackbarspeed.Name = "trackbarspeed";
            this.trackbarspeed.Size = new System.Drawing.Size(603, 45);
            this.trackbarspeed.TabIndex = 17;
            this.trackbarspeed.Value = 17;
            // 
            // textnarrow
            // 
            this.textnarrow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textnarrow.Location = new System.Drawing.Point(712, 256);
            this.textnarrow.Multiline = true;
            this.textnarrow.Name = "textnarrow";
            this.textnarrow.ReadOnly = true;
            this.textnarrow.Size = new System.Drawing.Size(73, 44);
            this.textnarrow.TabIndex = 16;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 255);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 18);
            this.label15.TabIndex = 15;
            this.label15.Text = "Narrow";
            // 
            // trackbnarrow
            // 
            this.trackbnarrow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackbnarrow.Location = new System.Drawing.Point(103, 255);
            this.trackbnarrow.Maximum = 24;
            this.trackbnarrow.Minimum = 1;
            this.trackbnarrow.Name = "trackbnarrow";
            this.trackbnarrow.Size = new System.Drawing.Size(603, 45);
            this.trackbnarrow.TabIndex = 14;
            this.trackbnarrow.Value = 1;
            // 
            // txthick
            // 
            this.txthick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txthick.Location = new System.Drawing.Point(712, 200);
            this.txthick.Multiline = true;
            this.txthick.Name = "txthick";
            this.txthick.ReadOnly = true;
            this.txthick.Size = new System.Drawing.Size(73, 44);
            this.txthick.TabIndex = 13;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 199);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 18);
            this.label14.TabIndex = 12;
            this.label14.Text = "Thick";
            // 
            // trackbthick
            // 
            this.trackbthick.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackbthick.Location = new System.Drawing.Point(103, 199);
            this.trackbthick.Maximum = 24;
            this.trackbthick.Minimum = 1;
            this.trackbthick.Name = "trackbthick";
            this.trackbthick.Size = new System.Drawing.Size(603, 45);
            this.trackbthick.TabIndex = 11;
            this.trackbthick.Value = 1;
            // 
            // txtdarkness
            // 
            this.txtdarkness.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtdarkness.Location = new System.Drawing.Point(712, 143);
            this.txtdarkness.Multiline = true;
            this.txtdarkness.Name = "txtdarkness";
            this.txtdarkness.ReadOnly = true;
            this.txtdarkness.Size = new System.Drawing.Size(73, 44);
            this.txtdarkness.TabIndex = 10;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 143);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 18);
            this.label13.TabIndex = 9;
            this.label13.Text = "Darkness";
            // 
            // trackbdark
            // 
            this.trackbdark.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackbdark.Location = new System.Drawing.Point(103, 143);
            this.trackbdark.Maximum = 30;
            this.trackbdark.Name = "trackbdark";
            this.trackbdark.Size = new System.Drawing.Size(603, 45);
            this.trackbdark.TabIndex = 8;
            this.trackbdark.Value = 10;
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(11, 39);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(774, 80);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // ifCmbBox
            // 
            this.ifCmbBox.FormattingEnabled = true;
            this.ifCmbBox.Location = new System.Drawing.Point(11, 7);
            this.ifCmbBox.Name = "ifCmbBox";
            this.ifCmbBox.Size = new System.Drawing.Size(130, 26);
            this.ifCmbBox.TabIndex = 4;
            // 
            // btnsearchprinter
            // 
            this.btnsearchprinter.Location = new System.Drawing.Point(147, 7);
            this.btnsearchprinter.Name = "btnsearchprinter";
            this.btnsearchprinter.Size = new System.Drawing.Size(129, 26);
            this.btnsearchprinter.TabIndex = 3;
            this.btnsearchprinter.Text = "Search Printer";
            this.btnsearchprinter.UseVisualStyleBackColor = true;
            this.btnsearchprinter.Click += new System.EventHandler(this.btnsearchprinter_Click);
            // 
            // btnSaveconfig
            // 
            this.btnSaveconfig.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSaveconfig.Location = new System.Drawing.Point(269, 422);
            this.btnSaveconfig.Name = "btnSaveconfig";
            this.btnSaveconfig.Size = new System.Drawing.Size(124, 31);
            this.btnSaveconfig.TabIndex = 0;
            this.btnSaveconfig.Text = "Save && Close";
            this.btnSaveconfig.UseVisualStyleBackColor = true;
            this.btnSaveconfig.Click += new System.EventHandler(this.btnSaveconfig_Click);
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
            // FCombineRMLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(819, 503);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnreturnprint);
            this.Controls.Add(this.btnSaveCombine);
            this.Controls.Add(this.dGV_lbljoin);
            this.Controls.Add(this.txtlotno);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnsetting);
            this.Controls.Add(this.btnCancelScan);
            this.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FCombineRMLabel";
            this.Text = "Combine RM Label";
            this.Load += new System.EventHandler(this.FCombineRMLabel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGV_lbljoin)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackbarspeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackbnarrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackbthick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackbdark)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnsetting;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtlotno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dGV_lbljoin;
        private System.Windows.Forms.Button btnSaveCombine;
        private System.Windows.Forms.Button btnreturnprint;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtserver;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textspeed;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TrackBar trackbarspeed;
        private System.Windows.Forms.TextBox textnarrow;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TrackBar trackbnarrow;
        private System.Windows.Forms.TextBox txthick;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TrackBar trackbthick;
        private System.Windows.Forms.TextBox txtdarkness;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TrackBar trackbdark;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ComboBox ifCmbBox;
        private System.Windows.Forms.Button btnsearchprinter;
        private System.Windows.Forms.Button btnSaveconfig;
        private System.Windows.Forms.Button btnCancelScan;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}