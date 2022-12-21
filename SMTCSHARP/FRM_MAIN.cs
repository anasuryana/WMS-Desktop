using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMTCSHARP
{
    public partial class FRM_MAIN : Form
    {
        bool ismosdown = false;
        DataSet dsmenu;
        DataTable dtmenu;
        public FRM_MAIN()
        {
            InitializeComponent();
        }

        private void FRM_MAIN_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Are you sure ?", "Confirmation",MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                ASettings.setmyrunsess(false);
            } else
            {
                e.Cancel = true;
            }            
        }

        void myf_parsenod(TreeNode pnode)
        {
            TreeNode mtnode;
            if (pnode.Nodes.Count > 0)
            {                
                foreach(TreeNode tnodku in pnode.Nodes)
                {
                    foreach (DataRow dr in dtmenu.Rows)
                    {
                        if (tnodku.Tag.ToString() == dr["MENU_PRNT"].ToString())
                        {
                            if (tnodku.Nodes.Count > 0)
                            {
                                bool isaddd = false;
                                foreach (TreeNode tnodku1 in tnodku.Nodes)
                                {
                                    if (tnodku1.Tag.ToString() == dr["MENU_ID"].ToString())
                                    {
                                        isaddd = true;
                                    }
                                }
                                if (!isaddd)
                                {
                                    mtnode = tnodku.Nodes.Add(dr["MENU_NAME"].ToString());
                                    mtnode.Tag = dr["MENU_ID"].ToString();
                                    myf_parsenod(tnodku);
                                }
                            } else
                            {
                                mtnode = tnodku.Nodes.Add(dr["MENU_NAME"].ToString());
                                mtnode.Tag = dr["MENU_ID"].ToString();
                                myf_parsenod(tnodku);
                            }                           
                        }
                    }
                }
                
            } else
            {
                foreach (DataRow dr in dtmenu.Rows)
                {
                    if (pnode.Tag.ToString() == dr["MENU_PRNT"].ToString())
                    {
                        mtnode = pnode.Nodes.Add(dr["MENU_NAME"].ToString());
                        mtnode.Tag = dr["MENU_ID"].ToString();
                        myf_parsenod(pnode);
                    }
                }
            }
        }

        private void FRM_MAIN_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + " " + ASettings.getVersion();
            TreeNode tnod;
            string constr = String.Format(ASettings.getconstr(), ASettings.getmys_server(), ASettings.getmys_db(), ASettings.getmys_user(), ASettings.getmys_pw());
            lbluser.Text = ASettings.getmyuser();
            lbluserid.Text = ASettings.getmyuserid();
            using(SqlConnection conn = new SqlConnection(constr))
            {
                try
                {
                    conn.Open();
                    using(var da = new SqlDataAdapter(String.Format("SELECT a.MENU_ID,MENU_DSCRPTN,MENU_NAME,MENU_PRNT,MENU_URL,MENU_ICON,MENU_STT from MENU_TBL a inner join EMPACCESS_TBL b on a.MENU_ID = b.EMPACCESS_MENUID  where EMPACCESS_GRPID = '{0}' and MENU_DESKTOP='1' order by a.MENU_ID asc ", ASettings.getmygroup()), conn))
                    {
                        dsmenu = new DataSet();
                        da.Fill(dsmenu);
                        if (dsmenu != null)
                        {
                            dtmenu = dsmenu.Tables[0];
                            if (dtmenu.Rows.Count > 0)
                            {
                                foreach (DataRow dr in dtmenu.Rows)
                                {
                                    //Console.WriteLine(dr["MENU_ID"].ToString());
                                    if (dr["MENU_PRNT"].ToString() == "0")
                                    {
                                        tnod = tvmenu.Nodes.Add(dr["MENU_NAME"].ToString());
                                        tnod.Tag = dr["MENU_ID"].ToString();
                                    } 
                                }     
                                
                                foreach(TreeNode tn in this.tvmenu.Nodes)
                                {
                                    myf_parsenod(tn);                                    
                                }                           
                            }
                            tvmenu.ExpandAll();
                        }
                    }
                }                
                catch ( SqlException exx)
                {
                    MessageBox.Show(exx.Message);
                }
            }
        }

        private void FRM_MAIN_MdiChildActivate(object sender, EventArgs e)
        {
            if(this.ActiveMdiChild == null)
            {
                naTabForm.Visible = false;
                //MessageBox.Show("ke sini");
            } else
            {
                naTabForm.Visible = true;
                //MessageBox.Show("sanaa");
                this.ActiveMdiChild.WindowState = FormWindowState.Maximized;
                if (this.ActiveMdiChild.Tag == null)
                {
                    TabPage tp = new TabPage(this.ActiveMdiChild.Text);
                    tp.Tag = this.ActiveMdiChild;
                    tp.Parent = naTabForm;
                    naTabForm.SelectedTab = tp;

                    this.ActiveMdiChild.Tag = tp;
                    this.ActiveMdiChild.FormClosed += new FormClosedEventHandler(ActiveMdiChild_FormClosed);
                }
            }
        }

        private void ActiveMdiChild_FormClosed(object sender,
                                    FormClosedEventArgs e)
        {
            ((sender as Form).Tag as TabPage).Dispose();

        }

        private void naTabForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((naTabForm.SelectedTab != null) && (naTabForm.SelectedTab.Tag != null))
            {
                (naTabForm.SelectedTab.Tag as Form).Select();
            }                
        }

        private void itemCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
                  
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void panlesep_MouseDown(object sender, MouseEventArgs e)
        {
            ismosdown = true;
            //Console.WriteLine("mouse down start");
            //Console.WriteLine("x: " + e.X + " y:" + e.Y);
            //Console.WriteLine("mouse down end");
        }

        private void panlesep_MouseMove(object sender, MouseEventArgs e)
        {
            if (ismosdown)
            {
                this.panel1.Width += e.X;
                naTabForm.Width += this.Width-(panel1.Width+panlesep.Width);
                naTabForm.Left += e.X;
                //Console.WriteLine("mouse move start");
                //Console.WriteLine("x: " + e.X + " y:" + e.Y);
                //Console.WriteLine("mouse move end");
            }            
        }

        private void panlesep_MouseUp(object sender, MouseEventArgs e)
        {
            ismosdown = false;
        }

        private void tvmenu_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void tvmenu_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            bool isoopen = false;
            switch (e.Node.Tag.ToString())
            {
                case "AAA":
                    isoopen = false;
                    foreach (Form frm in this.MdiChildren)
                    {
                        if (frm.Name == "FMSTItem")
                        {
                            isoopen = true;
                        }
                    }
                    if (!isoopen)
                    {
                        FMSTItem fmitem = new FMSTItem();
                        fmitem.MdiParent = this;
                        fmitem.Show();
                    }
                    break;
                case "AB":
                    isoopen = false;
                    foreach (Form frm in this.MdiChildren)
                    {
                        //iterate through
                        if (frm.Name == "FCustomer")
                        {
                            isoopen = true;
                        }
                    }
                    if (!isoopen)
                    {
                        FCustomer fmitem = new FCustomer();
                        fmitem.MdiParent = this;
                        fmitem.Show();
                    }
                    break;
                case "BB":
                    isoopen = false;
                    foreach (Form frm in this.MdiChildren)
                    {
                        //iterate through
                        if (frm.Name == "FKitting")
                        {
                            isoopen = true;
                        }
                    }
                    if (!isoopen)
                    {
                        FKitting fmitem = new FKitting();               
                        fmitem.MdiParent = this;
                        fmitem.Show();
                    }
                    break;
                case "BCA":
                    isoopen = false;
                    foreach (Form frm in this.MdiChildren)
                    {
                        //iterate through
                        if (frm.Name == "FKittingReturn")
                        {
                            isoopen = true;
                        }
                    }
                    if (!isoopen)
                    {
                        FKittingReturn fmitem = new FKittingReturn();
                        fmitem.MdiParent = this;
                        fmitem.Show();
                    }
                    break;
                case "BCB":
                    isoopen = false;
                    foreach (Form frm in this.MdiChildren)
                    {
                        //iterate through
                        if (frm.Name == "FReturnAnalyze")
                        {
                            isoopen = true;
                        }
                    }
                    if (!isoopen)
                    {
                        FReturnAnalyze fmitem = new FReturnAnalyze();
                        fmitem.MdiParent = this;
                        fmitem.Show();
                    }
                    break;
                case "BCD":
                    isoopen = false;
                    foreach (Form frm in this.MdiChildren)
                    {
                        //iterate through
                        if (frm.Name == "FKittingResume")
                        {
                            isoopen = true;
                        }
                    }
                    if (!isoopen)
                    {
                        FReturnResume fmitem = new FReturnResume();
                        fmitem.MdiParent = this;
                        fmitem.Show();
                    }
                    break;
                case "BIM":
                    isoopen = false;
                    foreach (Form frm in this.MdiChildren)
                    {
                        //iterate through
                        if (frm.Name == "FCombineRMLabel")
                        {
                            isoopen = true;
                        }
                    }
                    if (!isoopen)
                    {
                        FCombineRMLabel fmitem = new FCombineRMLabel();
                        fmitem.MdiParent = this;
                        fmitem.Show();
                    }
                    break;
                case "BCE":
                    isoopen = false;
                    foreach (Form frm in this.MdiChildren)
                    {
                        //iterate through
                        if (frm.Name == "FReturnWithoutPSN")
                        {
                            isoopen = true;
                        }
                    }
                    if (!isoopen)
                    {
                        FReturnWithoutPSN fmitem = new FReturnWithoutPSN();
                        fmitem.MdiParent = this;
                        fmitem.Show();
                    }
                    break;

            }            
        }

        private void FRM_MAIN_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show(e.Shift.ToString());
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("WMS");
        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {

        }

        private void businessGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isoopen = false;
            foreach (Form frm in this.MdiChildren)
            {
                //iterate through
                if (frm.Name == "FBusinessGroup")
                {
                    isoopen = true;
                }
            }
            if (!isoopen)
            {
                FBusinessGroup fmitem = new FBusinessGroup();
                fmitem.MdiParent = this;
                fmitem.Show();
            }
        }
    }
}
