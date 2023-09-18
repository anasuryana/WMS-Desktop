using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
            ckOutstaningOnly.Checked = ASettings.getmyflag().Equals('0') ? true : false; 
        }

        async
        Task
searchpsnlist(char flag)
        {
            lblInfo.Text = "Please wait";
            if (txtsearch.Text.Length < 7 && flag.Equals('1'))
            {
                MessageBox.Show("At least 7 chars required", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                txtsearch.ReadOnly = true;
                btnSearch.Enabled = false;

                string constr = String.Format(ASettings.getconstr(), ASettings.getmys_server(), ASettings.getmys_db(), ASettings.getmys_user(), ASettings.getmys_pw());
                SqlConnection conn = new SqlConnection(constr);
                DataTable ds = new DataTable();
                conn.Open();


                SqlCommand cmd = new SqlCommand(flag.Equals('1') ? "sp_psnno_list" : "wms_sp_psnno_ost_upload_mega_list", conn);
                cmd.Parameters.Add("@psnno", SqlDbType.VarChar).Value = txtsearch.Text;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 120;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                da.Dispose();


                txtsearch.ReadOnly = false;
                btnSearch.Enabled = true;
                dGV.AutoGenerateColumns = true;
                dGV.Columns.Clear();
                ds.Columns[0].ColumnName = "PSN Number";
                dGV.DataSource = ds;
                dGV.Columns[0].Width = 200;
                conn.Close();
            }
        }

        private async void txtsearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                await searchpsnlist(ckOutstaningOnly.Checked ? '0' : '1');
            }
        }

        private void FP_PSNList_Load(object sender, EventArgs e)
        {
            initcolumn();
            ActiveControl = txtsearch;
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

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            lblInfo.Text = "Please wait";
            btnSearch.Enabled = false;
            await Task.Delay(TimeSpan.FromSeconds(0.5));
            try
            {
                await searchpsnlist(ckOutstaningOnly.Checked ? '0' : '1');
                lblInfo.Text = dGV.Rows.Count + " row(s) found";
            }
            catch (Exception ex)
            {
                lblInfo.Text = "";
                btnSearch.Enabled = true;
                txtsearch.ReadOnly = false;
                MessageBox.Show(ex.Message);
            }
        }

    }
}
