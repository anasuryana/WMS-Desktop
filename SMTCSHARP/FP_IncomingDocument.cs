using IniParser;
using IniParser.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace SMTCSHARP
{
    public partial class FP_IncomingDocument : Form
    {
        string serverURLEnpoint = "";
        public string ReturnValue1 { get; set; }
        public FP_IncomingDocument()
        {
            InitializeComponent();
        }

        void Initcolumn()
        {
            dGV.ColumnCount = 2;
            dGV.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dGV.AlternatingRowsDefaultCellStyle.BackColor = Color.GreenYellow;
            dGV.Columns[0].Name = "DO Number";
            dGV.Columns[0].Width = 300;
            dGV.Columns[1].Name = "DO Date";
            dGV.Columns[1].Width = 200;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            btnSearch.Enabled = false;
            lblInfo.Text = "Please wait";
            Dictionary<string, string> datanya = new Dictionary<string, string>();
            datanya.Add("doc", txtsearch.Text);
            string[] strings = await searchLabel(datanya);

            JObject jobject = JObject.Parse(strings[2]);
            dGV.Rows.Clear();
            var RSData = from r in jobject["data"] select r;
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            foreach (var r in RSData)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dGV);
                row.Cells[0].Value = r["delivery_doc"];
                row.Cells[1].Value = r["delivery_date"];
                rows.Add(row);
            }
            dGV.Rows.AddRange(rows.ToArray());

            if (RSData.Count() == 0)
            {
                if (txtsearch.Text.Trim().Length > 3)
                {
                    strings = await accessApiSyncDocument(datanya);
                    if (strings[0].Equals("1"))
                    {
                        lblInfo.Text = String.Format("{0}, but please wait", strings[1]);
                        strings = await searchLabel(datanya);

                        jobject = JObject.Parse(strings[2]);
                        dGV.Rows.Clear();
                        RSData = from r in jobject["data"] select r;
                        rows = new List<DataGridViewRow>();
                        foreach (var r in RSData)
                        {
                            DataGridViewRow row = new DataGridViewRow();
                            row.CreateCells(dGV);
                            row.Cells[0].Value = r["delivery_doc"];
                            row.Cells[1].Value = r["delivery_date"];
                            rows.Add(row);
                        }
                        dGV.Rows.AddRange(rows.ToArray());
                    }
                }
            }

            lblInfo.Text = String.Format("({0}) row(s) found", dGV.Rows.Count);
            btnSearch.Enabled = true;

        }

        private void FP_IncomingDocument_Load(object sender, EventArgs e)
        {
            Initcolumn();
            ActiveControl = txtsearch;

            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("config.ini");
            serverURLEnpoint = data["SERVER"]["ADDRESS"];
        }

        private void dGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                var response = await hc.GetAsync(String.Format(serverURLEnpoint + "/receive/document?{0}", query.ToString()));
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

        private async Task<string[]> accessApiSyncDocument(Dictionary<string, string> dataInput)
        {
            string message = "";
            string data = "";
            string returnCode = "1";

            using (HttpClient hc = new HttpClient())
            {
                string theUrl = String.Format(serverURLEnpoint + "/receive/synchronize-for-labeling");
                var valuesRequest = new FormUrlEncodedContent(dataInput);
                var response = await hc.PostAsync(theUrl, valuesRequest);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    data = content;
                    JObject jobject = JObject.Parse(data);
                    double synchronized_items_count = jobject["synchronized_items_count"].ToObject<double>();

                    returnCode = synchronized_items_count > 0 ? "1" : "0";

                    message = jobject["message"].ToString();
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
                    MessageBox.Show("Please input valid the Document Number");
                    return;
                }
                btnSearch.Focus();
            }
        }
    }
}
