using System;
using System.Data;
using System.Data.SqlClient;
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
            if (MessageBox.Show("Are you sure ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                ASettings.setmyrunsess(false);
            }
            else
            {
                e.Cancel = true;
            }
        }

        void myf_parsenod(TreeNode pnode)
        {
            TreeNode mtnode;
            if (pnode.Nodes.Count > 0)
            {
                foreach (TreeNode tnodku in pnode.Nodes)
                {
                    foreach (DataRow dr in dtmenu.Rows)
                    {
                        string[] aNodeTag = tnodku.Tag.ToString().Split('#');
                        string[] aMenuParent = dr["MENU_PRNT"].ToString().Split('#');

                        if (aNodeTag[0] == aMenuParent[0])
                        {
                            if (tnodku.Nodes.Count > 0)
                            {
                                bool isaddd = false;
                                foreach (TreeNode tnodku1 in tnodku.Nodes)
                                {
                                    string[] _aNodeTag = tnodku1.Tag.ToString().Split('#');
                                    string[] _aMenu = dr["MENU_ID"].ToString().Split('#');

                                    if (_aNodeTag[0] == _aMenu[0])
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
                            }
                            else
                            {
                                mtnode = tnodku.Nodes.Add(dr["MENU_NAME"].ToString());
                                mtnode.Tag = dr["MENU_ID"].ToString();
                                myf_parsenod(tnodku);
                            }
                        }
                    }
                }

            }
            else
            {
                foreach (DataRow dr in dtmenu.Rows)
                {
                    string[] _aNodeTag2 = pnode.Tag.ToString().Split('#');
                    string[] _aMenu2 = dr["MENU_PRNT"].ToString().Split('#');

                    if (_aNodeTag2[0] == _aMenu2[0])
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
            using (SqlConnection conn = new SqlConnection(constr))
            {
                try
                {
                    conn.Open();
                    using (var da = new SqlDataAdapter(String.Format("SELECT concat(a.MENU_ID, '#', MENU_DESKTOP) as MENU_ID,MENU_DSCRPTN,MENU_NAME,concat(MENU_PRNT, '#', MENU_DESKTOP) as MENU_PRNT,MENU_URL,MENU_ICON,MENU_STT from MENU_TBL a inner join EMPACCESS_TBL b on a.MENU_ID = b.EMPACCESS_MENUID  where EMPACCESS_GRPID = '{0}' and MENU_DESKTOP IS NOT NULL order by a.MENU_ID asc ", ASettings.getmygroup()), conn))
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
                                    string[] aParentMenu = dr["MENU_PRNT"].ToString().Split('#');

                                    if (aParentMenu[0] == "0")
                                    {
                                        tnod = tvmenu.Nodes.Add(dr["MENU_NAME"].ToString());
                                        tnod.Tag = dr["MENU_ID"].ToString();
                                    }
                                }

                                foreach (TreeNode tn in this.tvmenu.Nodes)
                                {
                                    myf_parsenod(tn);
                                }
                            }
                            tvmenu.ExpandAll();
                        }
                    }
                }
                catch (SqlException exx)
                {
                    MessageBox.Show(exx.Message);
                }
            }
        }

        private void FRM_MAIN_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
            {
                naTabForm.Visible = false;
            }
            else
            {
                naTabForm.Visible = true;

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

        private void panlesep_MouseDown(object sender, MouseEventArgs e)
        {
            ismosdown = true;
        }

        private void panlesep_MouseMove(object sender, MouseEventArgs e)
        {
            if (ismosdown)
            {
                this.panel1.Width += e.X;
                naTabForm.Width += this.Width - (panel1.Width + panlesep.Width);
                naTabForm.Left += e.X;
            }
        }

        private void panlesep_MouseUp(object sender, MouseEventArgs e)
        {
            ismosdown = false;
        }

        private void tvmenu_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            bool isoopen = false;
            string[] _nodeSelected = e.Node.Tag.ToString().Split('#');

            // untuk menghindari fail on createInstance, dengan memeriksa form name yang didaftarkan di tabel MENU_TBL kolom MENU_DESKTOP
            if (_nodeSelected[0].Length >= 2 && _nodeSelected[1].Length > 1)
            {
                foreach (Form frm in this.MdiChildren)
                {
                    //iterate through
                    if (frm.Name == _nodeSelected[1])
                    {
                        isoopen = true;
                    }
                }
                if (!isoopen)
                {
                    var form = Activator.CreateInstance(Type.GetType("SMTCSHARP." + _nodeSelected[1])) as Form;
                    form.MdiParent = this;
                    form.Show();
                }
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
