using IniParser;
using IniParser.Model;
using Microsoft.Win32;
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
using System.Xml.Linq;

namespace SMTCSHARP
{
    public partial class FIncomingLabel : Form
    {
        string serverURLEnpoint = "";
        string sItemCode = String.Empty;
        string sPallet = String.Empty;

        ProgressBarWithText myProgressBar = new ProgressBarWithText();

        public FIncomingLabel()
        {
            InitializeComponent();
        }

        void Initcolumn()
        {
            dGV.ColumnCount = 4;
            dGV.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dGV.AlternatingRowsDefaultCellStyle.BackColor = Color.GreenYellow;
            dGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dGV.MultiSelect = false;
            dGV.Columns[0].Name = "Pallet";
            dGV.Columns[0].Width = 100;
            dGV.Columns[1].Name = "Part Code";
            dGV.Columns[1].Width = 100;
            dGV.Columns[2].Name = "Part Name";
            dGV.Columns[2].Width = 150;
            dGV.Columns[3].Name = "Quantity";
            dGV.Columns[3].Width = 100;
            dGV.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dGV.Columns[3].DefaultCellStyle.Format = "N0";


            dGV2.ColumnCount = 3;
            dGV2.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dGV2.AlternatingRowsDefaultCellStyle.BackColor = Color.GreenYellow;
            dGV2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dGV2.Columns[0].Name = "Unique Code";
            dGV2.Columns[0].Width = 100;
            dGV2.Columns[1].Name = "Lot Number";
            dGV2.Columns[1].Width = 100;
            dGV2.Columns[2].Name = "Quantity";
            dGV2.Columns[2].Width = 100;
            dGV2.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dGV2.Columns[2].DefaultCellStyle.Format = "N0";
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
            return new string[] { returnCode, message, data };
        }

        private async Task<string[]> accessApiItemInDocument(Dictionary<string, string> dataInput)
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
                bytes = Encoding.UTF8.GetBytes(dataInput["item"]);
                string base64Item = Convert.ToBase64String(bytes);
                string theUrl = String.Format(serverURLEnpoint + "/receive/document/{0}/{1}", base64, base64Item);

                var response = await hc.GetAsync(theUrl);
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

        private async void btnFindpsn_Click(object sender, EventArgs e)
        {
            using (var pf = new FP_IncomingDocument())
            {
                var res = pf.ShowDialog();
                if (res == DialogResult.OK)
                {
                    txtDONumber.Text = pf.ReturnValue1;
                    if (!pf.ReturnValue1.Equals(""))
                    {
                        btnFindpsn.Enabled = false;
                        dGV.Rows.Clear();
                        lblInfo.Text = "Please wait";

                        Dictionary<string, string> datanya = new Dictionary<string, string>();
                        datanya.Add("doc", pf.ReturnValue1);
                        string[] strings = await searchLabel(datanya);

                        JObject jobject = JObject.Parse(strings[2]);
                        var percentage = Convert.ToInt16(jobject["progress"]);
                        progressBar1.Value = percentage;



                        var RSData = from r in jobject["data"] select r;
                        List<DataGridViewRow> rows = new List<DataGridViewRow>();
                        foreach (var r in RSData)
                        {
                            DataGridViewRow row = new DataGridViewRow();
                            row.CreateCells(dGV);
                            row.Cells[0].Value = r["pallet"];
                            row.Cells[1].Value = r["item_code"];
                            row.Cells[2].Value = r["SPTNO"];
                            row.Cells[3].Value = Convert.ToDecimal(r["total_qty"]);
                            rows.Add(row);
                        }
                        btnFindpsn.Enabled = true;
                        dGV.Rows.AddRange(rows.ToArray());
                        lblInfo.Text = ".";
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

            nudQty.Controls[0].Visible = false;
        }

        private void txtLotNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnPrint.Focus();
            }
        }

        private void nudQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtLotNumber.Focus();
            }
        }

        private async void dGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dGV.Rows[e.RowIndex];
                string _itemCode = selectedRow.Cells[1].Value.ToString();
                string _pallet = selectedRow.Cells[0].Value.ToString();

                sItemCode = _itemCode;
                sPallet = _pallet;

                txtLotNumber.Enabled = false;
                dGV2.Rows.Clear();
                lblInfo.Text = "Please wait";

                Dictionary<string, string> datanya = new Dictionary<string, string>();
                datanya.Add("doc", txtDONumber.Text);
                datanya.Add("item", _itemCode);

                string[] strings = await accessApiItemInDocument(datanya);

                JObject jobject = JObject.Parse(strings[2]);



                var RSData = from r in jobject["data"] select r;
                var BalanceData = from r in jobject["balance_data"] select r;
                List<DataGridViewRow> rows = new List<DataGridViewRow>();
                foreach (var r in RSData)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dGV2);
                    row.Cells[0].Value = r["code"];
                    row.Cells[1].Value = r["lot_code"];
                    row.Cells[2].Value = Convert.ToDecimal(r["quantity"]);
                    rows.Add(row);
                }
                dGV2.Rows.AddRange(rows.ToArray());

                // validasi maksimum buat label per pallet
                foreach (var r in BalanceData)
                {
                    if (r["pallet"].ToString().Equals(_pallet))
                    {
                        nudQty.Maximum = Convert.ToDecimal(r["total_bal_qty"]);
                    }
                }

                txtLotNumber.Enabled = true;
                lblInfo.Text = ".";
                nudQty.Focus();
            }
        }

        private async void btnPrint_Click(object sender, EventArgs e)
        {
            if (txtLotNumber.Text.Length == 0)
            {
                MessageBox.Show("Lot number should not be empty");
                return;
            }

            if (txtDONumber.Text.Length == 0)
            {
                MessageBox.Show("DO Number should not be empty");
                return;
            }

            Dictionary<string, string> datanya = new Dictionary<string, string>();
            datanya.Add("doc", txtDONumber.Text);
            datanya.Add("item_code", sItemCode);
            datanya.Add("machineName", Environment.MachineName.ToString());
            datanya.Add("qty", nudQty.Value.ToString());
            datanya.Add("lot_number", txtLotNumber.Text);
            datanya.Add("user_id", ASettings.getmyuserid());
            datanya.Add("pallet", sPallet);
            btnPrint.Enabled = false;

            string[] strings = await accessApiRegisterC3(datanya);

            MessageBox.Show(strings[1]);

            if (strings[1].Equals("OK"))
            {

                JObject jobject = JObject.Parse(strings[2]);
                var data = jobject["data"];
                var RSData = from r in jobject["data"] select r;
                var BalanceData = from r in jobject["balance_data"] select r;

                var percentage = Convert.ToInt16(jobject["progress"]);
                progressBar1.Value = percentage;

                // validasi maksimum buat label per pallet
                foreach (var r in BalanceData)
                {
                    if (r["pallet"].ToString().Equals(sPallet))
                    {
                        nudQty.Maximum = Convert.ToDecimal(r["total_bal_qty"]);
                    }
                }

                // cetak label
                Dictionary<string, string> dataToPrint = new Dictionary<string, string>();
                dataToPrint.Add("rackCode", data["LOC"].ToString());
                dataToPrint.Add("itemQty", data["quantity"].ToString());
                dataToPrint.Add("itemCode", sItemCode);
                dataToPrint.Add("itemLot", txtLotNumber.Text);
                dataToPrint.Add("itemKey", data["code"].ToString());
                dataToPrint.Add("itemName", data["SPTNO"].ToString());
                dataToPrint.Add("nik", ASettings.getmyuserid());
                dataToPrint.Add("user_name", ASettings.getmyuserfname());
                dataToPrint.Add("mretrohs", "1");

                printsmtlabel(dataToPrint);

                nudQty.Value = 0;
                txtLotNumber.Text = String.Empty;
            }

            btnPrint.Enabled = true;
        }


        private async Task<string[]> accessApiRegisterC3(Dictionary<string, string> dataInput)
        {
            string message = "";
            string data = "";
            string returnCode = "1";
            using (HttpClient hc = new HttpClient())
            {
                var valuesRequest = new FormUrlEncodedContent(dataInput);
                var response = await hc.PostAsync(String.Format(serverURLEnpoint + "/label/c3"), valuesRequest);
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

        void printsmtlabel(Dictionary<string, string> dataInput)
        {
            RegistryKey ckrk = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\" + Application.ProductName);

            PSIPrinter PSIprinter = new PSIPrinter();

            PSIprinter.setData(dataInput);
            PSIprinter.print(ckrk.GetValue("PRINTER_DEFAULT_BRAND").ToString().ToLower());
        }
    }
}
