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
    public partial class FIncomingLabel : Form
    {
        string serverURLEnpoint = "";
        public FIncomingLabel()
        {
            InitializeComponent();
        }

        void Initcolumn()
        {
            dGV.ColumnCount = 4;
            dGV.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dGV.AlternatingRowsDefaultCellStyle.BackColor = Color.GreenYellow;
            dGV.Columns[0].Name = "Pallet";
            dGV.Columns[0].Width = 100;
            dGV.Columns[1].Name = "Part Code";
            dGV.Columns[1].Width = 100;
            dGV.Columns[2].Name = "Part Name";
            dGV.Columns[2].Width = 100;
            dGV.Columns[3].Name = "Quantity";
            dGV.Columns[3].Width = 100;
            dGV.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dGV2.ColumnCount = 2;
            dGV2.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dGV2.AlternatingRowsDefaultCellStyle.BackColor = Color.GreenYellow;
            dGV2.Columns[0].Name = "Lot Number";
            dGV2.Columns[0].Width = 100;
            dGV2.Columns[1].Name = "Quantity";
            dGV2.Columns[1].Width = 100;
            dGV2.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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
                byte[] bytes = Encoding.UTF8.GetBytes(dataInput["doc"]);
                string base64 = Convert.ToBase64String(bytes);
                var response = await hc.GetAsync(String.Format(serverURLEnpoint + "/receive/document/{0}", base64));
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

            Console.WriteLine(message);
            return new string[] { returnCode, message, data };
        }

        private async void btnFindpsn_Click(object sender, EventArgs e)
        {
            using (var pf = new FP_IncomingDocument())
            {
                var res = pf.ShowDialog();
                if (res == DialogResult.OK)
                {
                    txtDONumber.Text = pf.ReturnValue1;
                    if(!pf.ReturnValue1.Equals(""))
                    {
                        Dictionary<string, string> datanya = new Dictionary<string, string>();
                        datanya.Add("doc", pf.ReturnValue1);
                        btnFindpsn.Enabled = false;
                        string[] strings = await searchLabel(datanya);

                        JObject jobject = JObject.Parse(strings[2]);
                        dGV.Rows.Clear();
                        var RSData = from r in jobject["data"] select r;
                        List<DataGridViewRow> rows = new List<DataGridViewRow>();
                        foreach (var r in RSData)
                        {
                            DataGridViewRow row = new DataGridViewRow();
                            row.CreateCells(dGV);
                            row.Cells[0].Value = r["pallet"];
                            row.Cells[1].Value = r["item_code"];
                            row.Cells[2].Value = r["SPTNO"];
                            row.Cells[3].Value = r["total_qty"];
                            rows.Add(row);
                        }
                        dGV.Rows.AddRange(rows.ToArray());

                        btnFindpsn.Enabled = true;
                    }                    
                }
            }
        }

        private void FIncomingLabel_Load(object sender, EventArgs e)
        {
            Initcolumn();

            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("config.ini");
            serverURLEnpoint = data["SERVER"]["ADDRESS"];
        }

        private void txtLotNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                nudQty.Focus();
            }
        }

        private void nudQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnPrint.Focus();
            }
        }
    }
}
