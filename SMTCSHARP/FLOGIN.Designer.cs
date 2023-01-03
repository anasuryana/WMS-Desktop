namespace SMTCSHARP
{
    partial class FLOGIN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FLOGIN));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblinfo = new System.Windows.Forms.Label();
            this.btnsignin = new System.Windows.Forms.Button();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnsave = new System.Windows.Forms.Button();
            this.btntest = new System.Windows.Forms.Button();
            this.txts_pw = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txts_user = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txts_db = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txts_server = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.bgworklog = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(307, 212);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblinfo);
            this.tabPage1.Controls.Add(this.btnsignin);
            this.tabPage1.Controls.Add(this.txtpassword);
            this.tabPage1.Controls.Add(this.txtusername);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(299, 181);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Enter";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblinfo
            // 
            this.lblinfo.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblinfo.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblinfo.ForeColor = System.Drawing.Color.PaleGreen;
            this.lblinfo.Location = new System.Drawing.Point(0, 162);
            this.lblinfo.Name = "lblinfo";
            this.lblinfo.Size = new System.Drawing.Size(299, 23);
            this.lblinfo.TabIndex = 3;
            this.lblinfo.Text = "Welcome ...";
            this.lblinfo.Click += new System.EventHandler(this.lblinfo_Click);
            // 
            // btnsignin
            // 
            this.btnsignin.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsignin.Location = new System.Drawing.Point(31, 105);
            this.btnsignin.Name = "btnsignin";
            this.btnsignin.Size = new System.Drawing.Size(233, 35);
            this.btnsignin.TabIndex = 2;
            this.btnsignin.Text = "Log in";
            this.btnsignin.UseVisualStyleBackColor = true;
            this.btnsignin.Click += new System.EventHandler(this.btnsignin_Click);
            // 
            // txtpassword
            // 
            this.txtpassword.Font = new System.Drawing.Font("Consolas", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpassword.Location = new System.Drawing.Point(19, 68);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(256, 37);
            this.txtpassword.TabIndex = 1;
            this.txtpassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtpassword, "Password");
            this.txtpassword.UseSystemPasswordChar = true;
            this.txtpassword.TextChanged += new System.EventHandler(this.txtpassword_TextChanged);
            this.txtpassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpassword_KeyPress);
            // 
            // txtusername
            // 
            this.txtusername.Font = new System.Drawing.Font("Consolas", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtusername.ForeColor = System.Drawing.Color.Silver;
            this.txtusername.Location = new System.Drawing.Point(19, 31);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(256, 37);
            this.txtusername.TabIndex = 0;
            this.txtusername.Text = "UserID";
            this.txtusername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtusername.TextChanged += new System.EventHandler(this.txtusername_TextChanged);
            this.txtusername.Enter += new System.EventHandler(this.txtusername_Enter);
            this.txtusername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtusername_KeyPress);
            this.txtusername.Leave += new System.EventHandler(this.txtusername_Leave);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Controls.Add(this.btnsave);
            this.tabPage2.Controls.Add(this.btntest);
            this.tabPage2.Controls.Add(this.txts_pw);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.txts_user);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.txts_db);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.txts_server);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(299, 181);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Setting";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(19, 123);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 54);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(96, 153);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(179, 24);
            this.btnsave.TabIndex = 9;
            this.btnsave.Text = "Edit";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btntest
            // 
            this.btntest.Location = new System.Drawing.Point(96, 123);
            this.btntest.Name = "btntest";
            this.btntest.Size = new System.Drawing.Size(179, 24);
            this.btntest.TabIndex = 8;
            this.btntest.Text = "Connection Testing";
            this.btntest.UseVisualStyleBackColor = true;
            this.btntest.Click += new System.EventHandler(this.btntest_Click);
            // 
            // txts_pw
            // 
            this.txts_pw.Location = new System.Drawing.Point(96, 95);
            this.txts_pw.Name = "txts_pw";
            this.txts_pw.ReadOnly = true;
            this.txts_pw.Size = new System.Drawing.Size(179, 25);
            this.txts_pw.TabIndex = 7;
            this.txts_pw.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Password";
            // 
            // txts_user
            // 
            this.txts_user.Location = new System.Drawing.Point(96, 67);
            this.txts_user.Name = "txts_user";
            this.txts_user.ReadOnly = true;
            this.txts_user.Size = new System.Drawing.Size(179, 25);
            this.txts_user.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "User";
            // 
            // txts_db
            // 
            this.txts_db.Location = new System.Drawing.Point(96, 38);
            this.txts_db.Name = "txts_db";
            this.txts_db.ReadOnly = true;
            this.txts_db.Size = new System.Drawing.Size(179, 25);
            this.txts_db.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Database";
            // 
            // txts_server
            // 
            this.txts_server.Location = new System.Drawing.Point(96, 10);
            this.txts_server.Name = "txts_server";
            this.txts_server.ReadOnly = true;
            this.txts_server.Size = new System.Drawing.Size(179, 25);
            this.txts_server.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server";
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // bgworklog
            // 
            this.bgworklog.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgworklog_DoWork);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FLOGIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(331, 231);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FLOGIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WMS :::";
            this.Load += new System.EventHandler(this.FLOGIN_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txts_server;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btntest;
        private System.Windows.Forms.TextBox txts_pw;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txts_user;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txts_db;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnsignin;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblinfo;
        private System.ComponentModel.BackgroundWorker bgworklog;
        private System.Windows.Forms.Timer timer1;
    }
}

