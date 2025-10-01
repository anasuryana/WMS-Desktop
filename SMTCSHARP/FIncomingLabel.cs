using IniParser;
using IniParser.Model;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NPOI.SS.Formula.Functions;
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
        string sUniqueCode = String.Empty;
        string sRackCode = String.Empty;
        string sQty = String.Empty;
        string sLotCode = String.Empty;
        string sItemName = String.Empty;
        BindingSource bs = new BindingSource();
        string sSupqty = String.Empty;

        public FIncomingLabel()
        {
            InitializeComponent();
        }

        void Initcolumn()
        {
            dGV.ColumnCount = 8;
            dGV.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dGV.AlternatingRowsDefaultCellStyle.BackColor = Color.GreenYellow;
            dGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dGV.MultiSelect = false;
            dGV.AutoGenerateColumns = false;
            dGV.Columns[0].Name = "No";
            dGV.Columns[0].Width = 40;
            dGV.Columns[0].DataPropertyName = "no";
            dGV.Columns[1].Name = "Pallet";
            dGV.Columns[1].Width = 100;
            dGV.Columns[1].DataPropertyName = "pallet";
            dGV.Columns[2].Name = "Part Code";
            dGV.Columns[2].Width = 100;
            dGV.Columns[2].DataPropertyName = "part_code";
            dGV.Columns[3].Name = "Part Name";
            dGV.Columns[3].Width = 150;
            dGV.Columns[3].DataPropertyName = "part_name";

            dGV.Columns[4].Name = "Part Qty";
            dGV.Columns[4].Width = 100;
            dGV.Columns[4].DataPropertyName = "part_qty";
            dGV.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dGV.Columns[4].DefaultCellStyle.Format = "N0";

            dGV.Columns[5].Name = "Labeled Qty";
            dGV.Columns[5].Width = 100;
            dGV.Columns[5].DataPropertyName = "labeled_qty";
            dGV.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dGV.Columns[5].DefaultCellStyle.Format = "N0";

            dGV.Columns[6].Name = "Balance Qty";
            dGV.Columns[6].Width = 100;
            dGV.Columns[6].DataPropertyName = "balance_qty";
            dGV.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dGV.Columns[6].DefaultCellStyle.Format = "N0";

            dGV.Columns[7].Name = "Rack";
            dGV.Columns[7].Width = 100;
            dGV.Columns[7].DataPropertyName = "rack";


            dGV2.ColumnCount = 5;
            dGV2.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dGV2.AlternatingRowsDefaultCellStyle.BackColor = Color.GreenYellow;
            dGV2.Columns[0].Name = "Unique Code";
            dGV2.Columns[0].Width = 150;
            dGV2.Columns[1].Name = "Lot Number";
            dGV2.Columns[1].Width = 100;
            dGV2.Columns[2].Name = "Part Qty";
            dGV2.Columns[2].Width = 75;
            dGV2.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dGV2.Columns[2].DefaultCellStyle.Format = "N0";
            dGV2.Columns[3].Name = "Item Code";
            dGV2.Columns[3].Visible = false;
            dGV2.Columns[4].Name = "Rack Code";
            dGV2.Columns[4].Visible = false;

            DataGridViewButtonColumn hbt = new DataGridViewButtonColumn();
            hbt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            hbt.Width = 100;
            dGV2.Columns.Add(hbt);

            dgvwo.ColumnCount = 7;
            dgvwo.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dgvwo.AlternatingRowsDefaultCellStyle.BackColor = Color.GreenYellow;
            dgvwo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvwo.Columns[0].Name = "Unique Code";
            dgvwo.Columns[0].Width = 150;
            dgvwo.Columns[1].Name = "Part Code";
            dgvwo.Columns[1].Width = 170;
            dgvwo.Columns[2].Name = "Lot Number";
            dgvwo.Columns[2].Width = 170;
            dgvwo.Columns[3].Name = "Part Qty";
            dgvwo.Columns[3].Width = 105;
            dgvwo.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvwo.Columns[3].DefaultCellStyle.Format = "N0";
            dgvwo.Columns[4].Name = "DO Number";
            dgvwo.Columns[4].Width = 170;
            dgvwo.Columns[5].Name = "Part Name";
            dgvwo.Columns[5].Width = 170;
            dgvwo.Columns[6].Name = "Rack Code";
            dgvwo.Columns[6].Width = 170;

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

        private async Task<string[]> accessApiItemInDocumentEmergency(Dictionary<string, string> dataInput)
        {
            string message = "";
            string data = "";
            string returnCode = "1";

            using (HttpClient hc = new HttpClient())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(dataInput["doc"]);
                string base64 = Convert.ToBase64String(bytes);

                string theUrl = String.Format(serverURLEnpoint + "/receive/document-emergency/{0}", base64);

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

        private async Task<string[]> accessApiDeleteLabel(Dictionary<string, string> dataInput)
        {
            string message = "";
            string data = "";
            string returnCode = "1";

            using (HttpClient hc = new HttpClient())
            {
                var dataBody = new
                {
                    code = dataInput["code"],
                    user_id = ASettings.getmyuserid(),
                };
                var json = JsonConvert.SerializeObject(dataBody);
                string theUrl = String.Format(serverURLEnpoint + "/label/c3");

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri(theUrl),
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                };

                var response = await hc.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    data = content;
                    JObject jobject = JObject.Parse(data);
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

        private void btnFindpsn_Click(object sender, EventArgs e)
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
                        lblInfo.Text = "Please wait";
                        lblPartCode.Text = String.Empty;

                        Dictionary<string, string> datanya = new Dictionary<string, string>();
                        datanya.Add("doc", pf.ReturnValue1);
                        loadDataPerDocument(datanya);

                        btnFindpsn.Enabled = true;
                        lblInfo.Text = ".";

                        txtPartCode.Text = String.Empty;
                        cbOutstandingOnly.Checked = false;
                        txtPallet.Text = String.Empty;

                        dGV2.Rows.Clear();
                    }
                }
            }
        }

        private async void loadDataPerDocument(Dictionary<string, string> dataInput)
        {
            string[] strings = await searchLabel(dataInput);
            if (strings[0].Equals("0"))
            {
                MessageBox.Show(strings[1]);
                btnFindpsn.Enabled = true;
                lblInfo.Text = ".";
                return;
            }
            JObject jobject = JObject.Parse(strings[2]);
            var percentage = Convert.ToInt16(jobject["progress"]);
            progressBar1.Value = percentage;

            var RSData = from r in jobject["data"] select r;

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("no");
            dataTable.Columns.Add("pallet");
            dataTable.Columns.Add("part_code");
            dataTable.Columns.Add("part_name");
            dataTable.Columns.Add("part_qty", typeof(double));
            dataTable.Columns.Add("labeled_qty", typeof(double));
            dataTable.Columns.Add("balance_qty", typeof(double));
            dataTable.Columns.Add("rack");
            int i = 1;
            foreach (var r in RSData)
            {
                dataTable.Rows.Add(
                    i++,
                    r["pallet"].ToString(),
                    r["item_code"].ToString(),
                    r["SPTNO"].ToString(),
                    Convert.ToDecimal(r["total_qty"]),
                    Convert.ToDecimal(r["total_lbl_qty"]),
                    Convert.ToDecimal(r["balance_qty"]),
                    r["RACK_CD"].ToString()
                );

            }
            bs.DataSource = dataTable;
            dGV.DataSource = bs;
        }

        private async void loadDetailPerData(Dictionary<string, string> dataInput)
        {
            dGV2.Rows.Clear();
            string[] strings = await accessApiItemInDocument(dataInput);
            if (strings[0].Equals("0"))
            {
                MessageBox.Show(strings[1]);
                return;
            }
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
                row.Cells[3].Value = r["item_code"];
                row.Cells[4].Value = r["LOC"];
                row.Cells[5].Value = r["doc_code"].ToString().Equals(txtDONumber.Text) ? "Delete" : "";
                rows.Add(row);
            }
            dGV2.Rows.AddRange(rows.ToArray());
            dGV2.ClearSelection();

            // validasi maksimum buat label per pallet
            foreach (var r in BalanceData)
            {
                if (r["pallet"].ToString().Equals(sPallet))
                {
                    nudQty.Maximum = Convert.ToDecimal(r["total_bal_qty"]);
                }
            }
        }

        private async void loadDetailPerDataEmergency(Dictionary<string, string> dataInput)
        {
            dgvwo.Rows.Clear();
            string[] strings = await accessApiItemInDocumentEmergency(dataInput);
            if (strings[0].Equals("0"))
            {
                MessageBox.Show(strings[1]);
                return;
            }
            JObject jobject = JObject.Parse(strings[2]);

            var RSData = from r in jobject["data"] select r;
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            foreach (var r in RSData)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvwo);
                row.Cells[0].Value = r["code"];
                row.Cells[1].Value = r["item_code"];
                row.Cells[2].Value = r["lot_code"];
                row.Cells[3].Value = Convert.ToDecimal(r["quantity"]);
                row.Cells[4].Value = r["doc_code"];
                row.Cells[5].Value = r["SPTNO"];
                row.Cells[6].Value = r["RACK_CD"];
                rows.Add(row);
            }
            dgvwo.Rows.AddRange(rows.ToArray());
            dgvwo.ClearSelection();
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
                nudPrintQty.Focus();
                nudPrintQty.Select(0, nudPrintQty.Text.Length);
            }
        }

        private void nudQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtLotNumber.Focus();
            }
        }

        private void dGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                sUniqueCode = String.Empty;

                DataGridViewRow selectedRow = dGV.CurrentRow;
                string _itemCode = selectedRow.Cells[2].Value.ToString();
                string _pallet = selectedRow.Cells[1].Value.ToString();
                sRackCode = selectedRow.Cells[7].Value.ToString();
                sItemName = selectedRow.Cells[3].Value.ToString();
                lblPartCode.Text = _itemCode;

                sItemCode = _itemCode;
                sPallet = _pallet;

                txtLotNumber.Enabled = false;
                lblInfo.Text = "Please wait";

                Dictionary<string, string> datanya = new Dictionary<string, string>();
                datanya.Add("doc", txtDONumber.Text);
                datanya.Add("item", _itemCode);
                loadDetailPerData(datanya);


                txtLotNumber.Enabled = true;
                lblInfo.Text = ".";
                txtQty.Text = sSupqty.Length == 0 ? "" : sSupqty;
                txtQty.Focus();
            }
        }

        private async void btnPrint_Click(object sender, EventArgs e)
        {
            if (sUniqueCode.Length > 0)
            {
                DialogResult dialogResult = MessageBox.Show("It will reprint, are you sure ?", "Decide", MessageBoxButtons.YesNo);
                if (dialogResult != DialogResult.Yes)
                {
                    return;
                }


                btnPrint.Enabled = true;
                Dictionary<string, string> dataToPrint = new Dictionary<string, string>();
                dataToPrint.Add("rackCode", sRackCode);
                dataToPrint.Add("itemQty", sQty);
                dataToPrint.Add("itemCode", sItemCode);
                dataToPrint.Add("itemLot", sLotCode);
                dataToPrint.Add("itemKey", sUniqueCode);
                dataToPrint.Add("itemName", sItemName);
                dataToPrint.Add("nik", ASettings.getmyuserid());
                dataToPrint.Add("user_name", ASettings.getmyuserfname());
                dataToPrint.Add("mretrohs", "1");

                printsmtlabel(dataToPrint);
            }
            else
            {
                if (lblPartCode.Text.Length == 0)
                {
                    MessageBox.Show("Please select item first");
                    return;
                }

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

                if (nudQty.Value * nudPrintQty.Value > nudQty.Maximum)
                {
                    MessageBox.Show("Qty to print exceeds maximum allowed quantity");
                    return;
                }

                if (nudQty.Value == 0)
                {
                    MessageBox.Show("Qty to print should not be zero");
                    return;
                }

                if (txtLotNumber.Text.Contains(" "))
                {
                    MessageBox.Show("lot number should not contain any space char");
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
                datanya.Add("print_qty", nudPrintQty.Value.ToString());
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
                    foreach (var r in RSData)
                    {
                        Dictionary<string, string> dataToPrint = new Dictionary<string, string>();
                        dataToPrint.Add("rackCode", r["LOC"].ToString());
                        dataToPrint.Add("itemQty", r["quantity"].ToString());
                        dataToPrint.Add("itemCode", sItemCode);
                        dataToPrint.Add("itemLot", txtLotNumber.Text.Trim());
                        dataToPrint.Add("itemKey", r["code"].ToString());
                        dataToPrint.Add("itemName", r["SPTNO"].ToString());
                        dataToPrint.Add("nik", ASettings.getmyuserid());
                        dataToPrint.Add("user_name", ASettings.getmyuserfname());
                        dataToPrint.Add("mretrohs", "1");

                        printsmtlabel(dataToPrint);
                    }


                    nudQty.Value = 0;
                    txtLotNumber.Text = String.Empty;
                    nudPrintQty.Value = 1;
                    txtQty.Text = String.Empty;
                    sSupqty = String.Empty;

                    reloadAll();
                }

                btnPrint.Enabled = true;
            }
            txtPartCode.Focus();

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

        private async Task<string[]> accessApiRegisterC3WithoutReference(Dictionary<string, string> dataInput)
        {
            string message = "";
            string data = "";
            string returnCode = "1";
            using (HttpClient hc = new HttpClient())
            {
                var valuesRequest = new FormUrlEncodedContent(dataInput);
                var response = await hc.PostAsync(String.Format(serverURLEnpoint + "/label/c3-emergency"), valuesRequest);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    data = content;
                    message = "OK";
                }
                else
                {
                    returnCode = "0";
                    var content = await response.Content.ReadAsStringAsync();
                    if (content.Contains("Item is not found"))
                    {
                        message = "Item is not found";
                    }
                    else
                    {
                        message = "the response is not success yet";
                    }

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

        private async void dGV2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dGV2.Rows[e.RowIndex];
                sUniqueCode = selectedRow.Cells[0].Value.ToString();
                sLotCode = selectedRow.Cells[1].Value.ToString();
                sItemCode = selectedRow.Cells[3].Value.ToString();
                sRackCode = selectedRow.Cells[4].Value.ToString();

                sQty = ((int)Convert.ToDouble(selectedRow.Cells[2].Value)).ToString();
            }

            switch (dGV2.CurrentCell.ColumnIndex)
            {
                case 0:

                    break;
                case 5:
                    if (dGV2.CurrentCell.Value.ToString().Equals("Delete"))
                    {
                        if (MessageBox.Show("Are you sure want to delete ?", "Decide", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            Dictionary<string, string> dataToDelete = new Dictionary<string, string>();
                            dataToDelete.Add("code", sUniqueCode);

                            string[] strings = await accessApiDeleteLabel(dataToDelete);
                            MessageBox.Show(strings[1]);

                            reloadAll();
                        }
                    }
                    break;
            }

        }

        private void txtLotNumber_TextChanged(object sender, EventArgs e)
        {
            sUniqueCode = String.Empty;
        }

        private void nudQty_ValueChanged(object sender, EventArgs e)
        {
            sUniqueCode = String.Empty;
        }

        private void txtPartCode_TextChanged(object sender, EventArgs e)
        {
            filterDGV();
        }

        private void filterDGV()
        {
            lblPartCode.Text = String.Empty;
            nudQty.Value = 0;
            if (bs.DataSource != null)
            {
                string keyword = txtPartCode.Text.Replace("'", "''");
                string keyword2 = txtPallet.Text.Replace("'", "''");
                string keyword3 = cbOutstandingOnly.Checked ? "AND balance_qty>0" : "";
                if (txtPallet.Text.Length == 0)
                {
                    bs.Filter = String.Format("part_code LIKE '%{0}%' and pallet like '%{1}%' {2}", keyword, keyword2, keyword3);
                }
                else
                {
                    bs.Filter = String.Format("part_code LIKE '%{0}%' and pallet = '{1}' {2}", keyword, keyword2, keyword3);
                }
            }
        }

        private void txtPallet_TextChanged(object sender, EventArgs e)
        {
            filterDGV();
        }

        private void cbOutstandingOnly_CheckedChanged(object sender, EventArgs e)
        {
            filterDGV();
        }

        private void reloadAll()
        {
            // reload data grid resume
            Dictionary<string, string> datanya = new Dictionary<string, string>();
            datanya.Add("doc", txtDONumber.Text);
            loadDataPerDocument(datanya);

            // reload data grid detail
            datanya = new Dictionary<string, string>();
            datanya.Add("doc", txtDONumber.Text);
            datanya.Add("item", lblPartCode.Text);
            loadDetailPerData(datanya);
        }

        private void nudPrintQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnPrint.Focus();
            }
        }

        private void txtPartCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                sSupqty = String.Empty;
                if (txtPartCode.Text.Contains("|"))
                {

                }
                else
                {
                    int[] intsArray = { 16, 17 };
                    bool isContainSpace = false;
                    if (txtPartCode.Text.Contains(" "))
                    {
                        isContainSpace = true;
                    }
                    if (intsArray.Contains(txtPartCode.Text.Trim().Length) && !isContainSpace)
                    {

                    }
                    else
                    {
                        string[] an1 = txtPartCode.Text.Split(' ');
                        if (isContainSpace)
                        {
                            int strleng = an1[0].Length - 3;
                            txtPartCode.Text = an1[0].Substring(3, strleng);
                        }
                        else
                        {
                            if (txtPartCode.Text.Contains("3N1"))
                            {
                                int strleng = txtPartCode.Text.Length - 3;
                                txtPartCode.Text = txtPartCode.Text.Substring(3, strleng);
                            }
                        }

                        if (dGV.Rows.Count == 1)
                        {
                            DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(0, 0);
                            dGV_CellClick(dGV, args);

                            if (isContainSpace)
                            {
                                nudQty.Value = Convert.ToDecimal(an1[1]);
                                sSupqty = an1[1];

                                int strleng = an1[0].Length - 3;
                                txtQty.Text = an1[1];
                            }
                            else
                            {
                                nudQty.Value = 0;
                            }

                            txtQty.Focus();
                        }
                        else
                        {
                            if (dGV.Rows.Count == 0 && txtDONumber.Text.Trim().Length > 0)
                            {
                                MessageBox.Show("the part code is not in " + txtDONumber.Text);
                                txtPartCode.Text = String.Empty;
                            }
                        }
                    }
                }
            }
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                initialize3n2();
            }
        }

        private void dGV_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void txtQty_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                if (txtQty.Text.Length != 0)
                {
                    initialize3n2();
                }
            }
        }

        private void initialize3n2()
        {
            if (txtQty.Text.Length > 0)
            {
                if (txtQty.Text.Contains("3N2"))
                {
                    string[] mthis_ar = txtQty.Text.Split(' ');
                    if (sSupqty.Length > 0)
                    {
                        decimal _txtqty = Convert.ToDecimal(sSupqty);
                        decimal _confirmedQty = _txtqty > nudQty.Maximum ? nudQty.Maximum : _txtqty;

                        nudQty.Value = _confirmedQty;
                        txtQty.Text = _confirmedQty.ToString("F0");
                        txtLotNumber.Text = mthis_ar[1];
                    }
                    else
                    {
                        if (mthis_ar[1].All(char.IsNumber))
                        {
                            decimal _txtqty = Convert.ToDecimal(mthis_ar[1]);
                            decimal _confirmedQty = _txtqty > nudQty.Maximum ? nudQty.Maximum : _txtqty;

                            nudQty.Value = _confirmedQty;
                            txtQty.Text = _confirmedQty.ToString("F0");
                            txtLotNumber.Text = mthis_ar[2];
                        }
                    }
                    txtLotNumber.Focus();
                }
                else
                {
                    if (txtQty.Text.All(char.IsNumber))
                    {
                        decimal _txtqty = Convert.ToDecimal(txtQty.Text);
                        decimal _confirmedQty = _txtqty > nudQty.Maximum ? nudQty.Maximum : _txtqty;
                        nudQty.Value = _confirmedQty;
                        txtQty.Text = _confirmedQty.ToString("F0");
                        txtLotNumber.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Qty should be a number");
                        txtQty.Text = "";
                    }
                }
            }
        }

        private void txtQty_Leave(object sender, EventArgs e)
        {
            initialize3n2();
        }

        private void txtwo_donumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (txtwo_donumber.Text.Trim().Length > 3)
                {
                    txtwo_partcode.Focus();
                }
            }
        }

        private void txtwo_partcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (txtwo_partcode.Text.Trim().Length <= 3)
                {
                    MessageBox.Show("Part code is not valid");
                    return;
                }

                bool isContainSpace = false;
                if (txtwo_partcode.Text.Contains(" "))
                {
                    isContainSpace = true;
                }

                if (isContainSpace)
                {
                    string[] an1 = txtwo_partcode.Text.Split(' ');
                    txtwo_qty.Text = an1[1];
                    sSupqty = an1[1];

                    int strleng = an1[0].Length - 3;
                    txtwo_partcode.Text = an1[0].Substring(3, strleng);

                    txtwo_lotnumber.Focus();
                }
                else
                {
                    if (txtwo_partcode.Text.Contains("3N1"))
                    {
                        int strleng = txtwo_partcode.Text.Length - 3;
                        txtwo_partcode.Text = txtwo_partcode.Text.Substring(3, strleng);
                        txtwo_qty.Text = "";
                    }
                    else
                    {

                    }
                    txtwo_qty.Focus();
                }
            }
        }

        private async void btnwo_print_Click(object sender, EventArgs e)
        {
            if (sUniqueCode.Length > 0)
            {
                DialogResult dialogResult = MessageBox.Show("It will reprint, are you sure ?", "Decide", MessageBoxButtons.YesNo);
                if (dialogResult != DialogResult.Yes)
                {
                    return;
                }

                Dictionary<string, string> dataToPrint = new Dictionary<string, string>();
                dataToPrint.Add("rackCode", sRackCode);
                dataToPrint.Add("itemQty", sQty);
                dataToPrint.Add("itemCode", sItemCode);
                dataToPrint.Add("itemLot", sLotCode);
                dataToPrint.Add("itemKey", sUniqueCode);
                dataToPrint.Add("itemName", sItemName);
                dataToPrint.Add("nik", ASettings.getmyuserid());
                dataToPrint.Add("user_name", ASettings.getmyuserfname());
                dataToPrint.Add("mretrohs", "1");

                printsmtlabel(dataToPrint);
            }
            else
            {
                if (txtwo_lotnumber.Text.Length == 0)
                {
                    MessageBox.Show("Lot number should not be empty");
                    return;
                }

                if (txtwo_donumber.Text.Length == 0)
                {
                    MessageBox.Show("DO Number should not be empty");
                    return;
                }

                if (!txtwo_qty.Text.All(char.IsNumber))
                {
                    MessageBox.Show("Qty to print should not be zero");
                    return;
                }

                if (txtLotNumber.Text.Contains(" "))
                {
                    MessageBox.Show("lot number should not contain any space char");
                    return;
                }

                Dictionary<string, string> datanya = new Dictionary<string, string>();
                datanya.Add("doc", txtwo_donumber.Text);
                datanya.Add("item_code", txtwo_partcode.Text);
                datanya.Add("machineName", Environment.MachineName.ToString());
                datanya.Add("qty", txtwo_qty.Text);
                datanya.Add("lot_number", txtwo_lotnumber.Text.Trim());
                datanya.Add("user_id", ASettings.getmyuserid());
                datanya.Add("print_qty", nudwo_printqty.Value.ToString());
                btnwo_print.Enabled = false;

                string[] strings = await accessApiRegisterC3WithoutReference(datanya);

                MessageBox.Show(strings[1]);

                if (strings[1].Equals("OK"))
                {
                    JObject jobject = JObject.Parse(strings[2]);
                    var data = jobject["data"];
                    var RSData = from r in jobject["data"] select r;

                    // cetak label
                    foreach (var r in RSData)
                    {
                        Dictionary<string, string> dataToPrint = new Dictionary<string, string>();
                        dataToPrint.Add("rackCode", r["LOC"].ToString());
                        dataToPrint.Add("itemQty", r["quantity"].ToString());
                        dataToPrint.Add("itemCode", r["ITMCD"].ToString());
                        dataToPrint.Add("itemLot", txtwo_lotnumber.Text.Trim());
                        dataToPrint.Add("itemKey", r["code"].ToString());
                        dataToPrint.Add("itemName", r["SPTNO"].ToString());
                        dataToPrint.Add("nik", ASettings.getmyuserid());
                        dataToPrint.Add("user_name", ASettings.getmyuserfname());
                        dataToPrint.Add("mretrohs", "1");

                        printsmtlabel(dataToPrint);
                    }

                    loadDetailPerDataEmergency(datanya);

                }

                txtwo_partcode.Text = String.Empty;
                txtwo_qty.Text = String.Empty;
                txtwo_lotnumber.Text = String.Empty;
                txtwo_partcode.Focus();

                btnwo_print.Enabled = true;

            }

        }

        private void txtwo_qty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (txtwo_qty.Text.Contains("3N2"))
                {
                    string[] mthis_ar = txtwo_qty.Text.Split(' ');

                    if (mthis_ar[1].All(char.IsNumber))
                    {
                        decimal _txtqty = Convert.ToDecimal(mthis_ar[1]);

                        txtwo_qty.Text = _txtqty.ToString("F0");
                        txtwo_lotnumber.Text = mthis_ar[2];
                    }

                    nudwo_printqty.Focus();
                }
                else
                {
                    txtwo_lotnumber.Focus();
                }
            }
        }

        private void txtwo_lotnumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (txtwo_lotnumber.Text.Contains("3N2"))
                {
                    string[] mthis_ar = txtwo_lotnumber.Text.Split(' ');

                    txtwo_lotnumber.Text = mthis_ar[1];

                    nudwo_printqty.Focus();
                }
                else
                {
                    nudwo_printqty.Focus();
                }

            }
        }

        private void nudwo_printqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnwo_print.Focus();
            }
        }

        private void txtwo_partcode_TextChanged(object sender, EventArgs e)
        {
            sUniqueCode = String.Empty;
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            txtwo_donumber.Focus();
        }

        private void txtwo_donumber_Leave(object sender, EventArgs e)
        {
            if (txtwo_donumber.Text.Length == 0)
            {
                txtwo_donumber.Focus();
                MessageBox.Show("DO Number should not be empty");
            }
            else
            {
                Dictionary<string, string> datanya = new Dictionary<string, string>();
                datanya.Add("doc", txtwo_donumber.Text.Trim());
                loadDetailPerDataEmergency(datanya);
            }
        }

        private void dgvwo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvwo.Rows[e.RowIndex];
                sUniqueCode = selectedRow.Cells[0].Value.ToString();
                sLotCode = selectedRow.Cells[2].Value.ToString();
                sItemName = selectedRow.Cells[5].Value.ToString();
                sRackCode = selectedRow.Cells[6].Value.ToString();
                sItemCode = selectedRow.Cells[1].Value.ToString();

                sQty = ((int)Convert.ToDouble(selectedRow.Cells[3].Value)).ToString();
            }
        }
    }
}
