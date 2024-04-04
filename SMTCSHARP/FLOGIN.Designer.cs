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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnsave = new System.Windows.Forms.Button();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btntest = new System.Windows.Forms.Button();
            this.txts_pw = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txts_user = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txts_db = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txts_server = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnTestX = new System.Windows.Forms.Button();
            this.txtPasswordX = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUserX = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDBX = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtServerX = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.bgworklog = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(331, 247);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblinfo);
            this.tabPage1.Controls.Add(this.btnsignin);
            this.tabPage1.Controls.Add(this.txtpassword);
            this.tabPage1.Controls.Add(this.txtusername);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(323, 220);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Enter";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblinfo
            // 
            this.lblinfo.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lblinfo.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblinfo.ForeColor = System.Drawing.Color.PaleGreen;
            this.lblinfo.Location = new System.Drawing.Point(0, 195);
            this.lblinfo.Name = "lblinfo";
            this.lblinfo.Size = new System.Drawing.Size(323, 23);
            this.lblinfo.TabIndex = 3;
            this.lblinfo.Text = "Welcome ...";
            // 
            // btnsignin
            // 
            this.btnsignin.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsignin.Location = new System.Drawing.Point(31, 122);
            this.btnsignin.Name = "btnsignin";
            this.btnsignin.Size = new System.Drawing.Size(259, 43);
            this.btnsignin.TabIndex = 2;
            this.btnsignin.Text = "Sign in";
            this.btnsignin.UseVisualStyleBackColor = true;
            this.btnsignin.Click += new System.EventHandler(this.btnsignin_Click);
            // 
            // txtpassword
            // 
            this.txtpassword.Font = new System.Drawing.Font("Consolas", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpassword.Location = new System.Drawing.Point(19, 74);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(283, 34);
            this.txtpassword.TabIndex = 1;
            this.txtpassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtpassword, "Password");
            this.txtpassword.UseSystemPasswordChar = true;
            this.txtpassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpassword_KeyPress);
            // 
            // txtusername
            // 
            this.txtusername.Font = new System.Drawing.Font("Consolas", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtusername.ForeColor = System.Drawing.Color.Silver;
            this.txtusername.Location = new System.Drawing.Point(19, 31);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(283, 34);
            this.txtusername.TabIndex = 0;
            this.txtusername.Text = "UserID";
            this.txtusername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtusername.Enter += new System.EventHandler(this.txtusername_Enter);
            this.txtusername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtusername_KeyPress);
            this.txtusername.Leave += new System.EventHandler(this.txtusername_Leave);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.btnsave);
            this.tabPage2.Controls.Add(this.tabControl2);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(323, 220);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Setting";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Location = new System.Drawing.Point(5, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(317, 208);
            this.panel1.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(62, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 14);
            this.label5.TabIndex = 1;
            this.label5.Text = "PIN";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(65, 103);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(187, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.UseSystemPasswordChar = true;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(106, 190);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(179, 24);
            this.btnsave.TabIndex = 21;
            this.btnsave.Text = "Edit";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Location = new System.Drawing.Point(6, 6);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(311, 181);
            this.tabControl2.TabIndex = 12;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.pictureBox1);
            this.tabPage3.Controls.Add(this.btntest);
            this.tabPage3.Controls.Add(this.txts_pw);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.txts_user);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.txts_db);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.txts_server);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(303, 154);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "WMS DB";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(19, 115);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 31);
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // btntest
            // 
            this.btntest.Location = new System.Drawing.Point(96, 121);
            this.btntest.Name = "btntest";
            this.btntest.Size = new System.Drawing.Size(179, 24);
            this.btntest.TabIndex = 19;
            this.btntest.Text = "Connection Testing";
            this.btntest.UseVisualStyleBackColor = true;
            this.btntest.Click += new System.EventHandler(this.btntest_Click);
            // 
            // txts_pw
            // 
            this.txts_pw.Location = new System.Drawing.Point(96, 93);
            this.txts_pw.Name = "txts_pw";
            this.txts_pw.ReadOnly = true;
            this.txts_pw.Size = new System.Drawing.Size(179, 22);
            this.txts_pw.TabIndex = 18;
            this.txts_pw.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 17;
            this.label4.Text = "Password";
            // 
            // txts_user
            // 
            this.txts_user.Location = new System.Drawing.Point(96, 65);
            this.txts_user.Name = "txts_user";
            this.txts_user.ReadOnly = true;
            this.txts_user.Size = new System.Drawing.Size(179, 22);
            this.txts_user.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 15;
            this.label3.Text = "User";
            // 
            // txts_db
            // 
            this.txts_db.Location = new System.Drawing.Point(96, 36);
            this.txts_db.Name = "txts_db";
            this.txts_db.ReadOnly = true;
            this.txts_db.Size = new System.Drawing.Size(179, 22);
            this.txts_db.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 13;
            this.label2.Text = "Database";
            // 
            // txts_server
            // 
            this.txts_server.Location = new System.Drawing.Point(96, 8);
            this.txts_server.Name = "txts_server";
            this.txts_server.ReadOnly = true;
            this.txts_server.Size = new System.Drawing.Size(179, 22);
            this.txts_server.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 11;
            this.label1.Text = "Server";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.pictureBox2);
            this.tabPage4.Controls.Add(this.btnTestX);
            this.tabPage4.Controls.Add(this.txtPasswordX);
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.txtUserX);
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Controls.Add(this.txtDBX);
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Controls.Add(this.txtServerX);
            this.tabPage4.Controls.Add(this.label9);
            this.tabPage4.Location = new System.Drawing.Point(4, 23);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(303, 154);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "X Ray DB";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(19, 115);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(60, 29);
            this.pictureBox2.TabIndex = 32;
            this.pictureBox2.TabStop = false;
            // 
            // btnTestX
            // 
            this.btnTestX.Location = new System.Drawing.Point(96, 119);
            this.btnTestX.Name = "btnTestX";
            this.btnTestX.Size = new System.Drawing.Size(179, 24);
            this.btnTestX.TabIndex = 30;
            this.btnTestX.Text = "Connection Testing";
            this.btnTestX.UseVisualStyleBackColor = true;
            this.btnTestX.Click += new System.EventHandler(this.btnTestX_Click);
            // 
            // txtPasswordX
            // 
            this.txtPasswordX.Location = new System.Drawing.Point(96, 91);
            this.txtPasswordX.Name = "txtPasswordX";
            this.txtPasswordX.ReadOnly = true;
            this.txtPasswordX.Size = new System.Drawing.Size(179, 22);
            this.txtPasswordX.TabIndex = 29;
            this.txtPasswordX.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 28;
            this.label6.Text = "Password";
            // 
            // txtUserX
            // 
            this.txtUserX.Location = new System.Drawing.Point(96, 63);
            this.txtUserX.Name = "txtUserX";
            this.txtUserX.ReadOnly = true;
            this.txtUserX.Size = new System.Drawing.Size(179, 22);
            this.txtUserX.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 14);
            this.label7.TabIndex = 26;
            this.label7.Text = "User";
            // 
            // txtDBX
            // 
            this.txtDBX.Location = new System.Drawing.Point(96, 34);
            this.txtDBX.Name = "txtDBX";
            this.txtDBX.ReadOnly = true;
            this.txtDBX.Size = new System.Drawing.Size(179, 22);
            this.txtDBX.TabIndex = 25;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 14);
            this.label8.TabIndex = 24;
            this.label8.Text = "Database";
            // 
            // txtServerX
            // 
            this.txtServerX.Location = new System.Drawing.Point(96, 6);
            this.txtServerX.Name = "txtServerX";
            this.txtServerX.ReadOnly = true;
            this.txtServerX.Size = new System.Drawing.Size(179, 22);
            this.txtServerX.TabIndex = 23;
            this.txtServerX.Text = "localhost";
            this.txtServerX.DoubleClick += new System.EventHandler(this.txtServerX_DoubleClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 14);
            this.label9.TabIndex = 22;
            this.label9.Text = "Server";
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // FLOGIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(353, 265);
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnsignin;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblinfo;
        private System.ComponentModel.BackgroundWorker bgworklog;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btntest;
        private System.Windows.Forms.TextBox txts_pw;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txts_user;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txts_db;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txts_server;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtPasswordX;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUserX;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDBX;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtServerX;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnTestX;
        private System.Windows.Forms.Button btnsave;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
    }
}

