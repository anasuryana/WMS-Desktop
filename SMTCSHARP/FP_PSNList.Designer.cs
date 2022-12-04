namespace SMTCSHARP
{
    partial class FP_PSNList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FP_PSNList));
            this.dGV = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtsearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dGV)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dGV
            // 
            this.dGV.AllowUserToAddRows = false;
            this.dGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV.Location = new System.Drawing.Point(14, 75);
            this.dGV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dGV.Name = "dGV";
            this.dGV.ReadOnly = true;
            this.dGV.Size = new System.Drawing.Size(595, 332);
            this.dGV.TabIndex = 0;            
            this.dGV.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGV_CellDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtsearch);
            this.groupBox1.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(14, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(595, 63);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // txtsearch
            // 
            this.txtsearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtsearch.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsearch.Location = new System.Drawing.Point(196, 26);
            this.txtsearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(187, 25);
            this.txtsearch.TabIndex = 0;
            this.txtsearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtsearch_KeyPress);
            this.txtsearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtsearch_KeyUp);
            // 
            // FP_PSNList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 420);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dGV);
            this.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FP_PSNList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PSN List";
            this.Load += new System.EventHandler(this.FP_PSNList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGV)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dGV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtsearch;
    }
}