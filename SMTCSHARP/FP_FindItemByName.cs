using IniParser;
using IniParser.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace SMTCSHARP
{
    public partial class FP_FindItemByName : Form
    {
        string serverURLEnpoint = "";
        public string ReturnValue1 { get; set; }

        private readonly string _document;

        public FP_FindItemByName(string[] data)
        {
            InitializeComponent();

            _document = data.Length > 0 ? data[0] : string.Empty;
        }

        void Initcolumn()
        {
            dGV.ColumnCount = 2;
            dGV.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dGV.AlternatingRowsDefaultCellStyle.BackColor = Color.GreenYellow;
            dGV.Columns[0].Name = "Code";
            dGV.Columns[0].Width = 100;
            dGV.Columns[1].Name = "Description";
            dGV.Columns[1].Width = 300;
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

        private void FP_FindItemByName_Load(object sender, EventArgs e)
        {
            Initcolumn();
            ActiveControl = txtsearch;

            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("config.ini");
            serverURLEnpoint = data["SERVER"]["ADDRESS"];
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            btnSearch.Enabled = false;
            lblInfo.Text = "Please wait";
            Dictionary<string, string> datanya = new Dictionary<string, string>();
            datanya.Add("item_name", txtsearch.Text);
            datanya.Add("doc", _document);
            string[] strings = await searchLabel(datanya);
            if (strings[0].Equals("0"))
            {
                lblInfo.Text = strings[1];
                btnSearch.Enabled = true;
                return;
            }

            JObject jobject = JObject.Parse(strings[2]);
            dGV.Rows.Clear();
            var RSData = from r in jobject["data"] select r;
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            foreach (var r in RSData)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dGV);
                row.Cells[0].Value = r["ITMCD"];
                row.Cells[1].Value = r["ITMD1"];
                rows.Add(row);
            }
            dGV.Rows.AddRange(rows.ToArray());

            lblInfo.Text = String.Format("({0}) row(s) found", dGV.Rows.Count);
            btnSearch.Enabled = true;

            dGV.Focus();
        }

        private async Task<string[]> searchLabel(Dictionary<string, string> dataInput)
        {
            string message = "";
            string data = "";
            string returnCode = "1";
            var query = HttpUtility.ParseQueryString(String.Empty);
            foreach (var pair in dataInput)
            {
                query[pair.Key] = pair.Value;
            }

            using (HttpClient hc = new HttpClient())
            {
                var response = await hc.GetAsync(String.Format(serverURLEnpoint + "/receive/search-by-item-name?{0}", query.ToString()));
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    data = content;
                    message = "OK";
                }
                else
                {
                    returnCode = "0";
                    message = "the response is not success yet";
                }

            }
            return new string[] { returnCode, message, data };
        }

        private void txtsearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (txtsearch.Text.Trim().Length <= 3)
                {
                    MessageBox.Show("Please input valid item name");
                    return;
                }
                btnSearch.Focus();
            }
        }

        private void dGV_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dGV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Supaya tidak bunyi 'ding' dan tidak lompat baris

                // Pastikan ada minimal 1 baris (selain baris baru)
                if (dGV.Rows.Count == 1 && dGV.CurrentRow != null)
                {
                    // Ambil nilai dari kolom pertama (indeks 0)
                    string nilaiKolomPertama = dGV.CurrentRow.Cells[0].Value?.ToString();

                    this.ReturnValue1 = nilaiKolomPertama;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
    }
}
