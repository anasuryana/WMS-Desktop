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
    public partial class FP_PSNList : Form
    {

        public string ReturnValue1 { get; set; }
        public FP_PSNList()
        {
            InitializeComponent();
        }

        void initcolumn()
        {
            dGV.ColumnCount = 1;
            dGV.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dGV.AlternatingRowsDefaultCellStyle.BackColor = Color.GreenYellow;
            dGV.Columns[0].Name = "PSN Number";
            dGV.Columns[0].Width = 200;
        }

        void searchpsnlist()
        {
            //dGV.Rows.Clear();
            string constr = String.Format(ASettings.getconstr(), ASettings.getmys_server(), ASettings.getmys_db(), ASettings.getmys_user(), ASettings.getmys_pw());
            using (SqlConnection conn = new SqlConnection(constr))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_psnno_list", conn))
                    {
                        cmd.Parameters.Add("@psnno", SqlDbType.VarChar).Value = txtsearch.Text;
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable ds = new DataTable();
                        da.Fill(ds);
                        dGV.AutoGenerateColumns = true;
                        dGV.Columns.Clear();
                        dGV.DataSource = ds;
                        dGV.Columns[0].HeaderText = "PSN Number";
                        dGV.Columns[0].Width = 300;                       
                    }
                }
                catch (SqlException exx)
                {
                    MessageBox.Show(exx.Message);
                }
            }
        }

        private void txtsearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                searchpsnlist();
            }
        }

        private void FP_PSNList_Load(object sender, EventArgs e)
        {
            initcolumn();
            ActiveControl = txtsearch;
        }

        private void txtsearch_KeyUp(object sender, KeyEventArgs e)
        {
            searchpsnlist();
        }

        private void dGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dGV.CurrentCell.ColumnIndex.Equals(0))
            {
                this.ReturnValue1 = dGV.CurrentCell.Value.ToString();
                DialogResult = DialogResult.OK;
                Close();
            }
        }        
    }
}
