using IniParser.Model;
using IniParser;
using System;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Linq;
using NPOI.SS.Formula.Functions;
using Microsoft.Win32;
using System.Xml.Linq;

namespace SMTCSHARP
{
    public partial class FLabelMasterHistory : Form
    {
        string ItemCode = string.Empty;
        string serverURLEnpoint = "";
        string mrackcd = string.Empty;
        string mretitemcd = string.Empty;
        string mretqty = string.Empty;
        string mretlot = string.Empty;
        string mretitemnm = string.Empty;
        string mUniqueCode = string.Empty;
        string mNIK = string.Empty;
        string mNIKName= string.Empty;


        public FLabelMasterHistory()
        {
            InitializeComponent();
        }

        private void FLabelMasterHistory_Load(object sender, EventArgs e)
        {
            initColumn();

            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("config.ini");
            serverURLEnpoint = data["SERVER"]["ADDRESS"];
        }

        void initColumn()
        {
            dGV.ColumnCount = 10;
            dGV.Columns[0].Name = "ID";
            dGV.Columns[0].Width = 150;
            dGV.Columns[1].Name = "Document";
            dGV.Columns[1].Width = 150;
            dGV.Columns[2].Name = "Item Code";
            dGV.Columns[3].Name = "Item Name";
            dGV.Columns[4].Name = "Item Description";
            dGV.Columns[4].Width = 250;
            dGV.Columns[5].Name = "Qty";
            dGV.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dGV.Columns[6].Name = "Lot Code";
            dGV.Columns[7].Name = "NIK";
            dGV.Columns[8].Name = "User Name";
            dGV.Columns[9].Name = "Rack";

            foreach (DataGridViewColumn column in dGV.Columns)
            {
                column.ReadOnly = true;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            DataGridViewCheckBoxColumn hcb = new DataGridViewCheckBoxColumn();
            hcb.ValueType = typeof(bool);
            hcb.Width = 50;
            hcb.ToolTipText = "Print Flag";
            dGV.Columns.Add(hcb);
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> datanya = new Dictionary<string, string>();
            datanya.Add("code", txtUniqueCode.Text);
            btnSearch.Enabled = false;
            string[] strings = await searchLabel(datanya);
            btnSearch.Enabled = true;

            JObject jobject = JObject.Parse(strings[2]);

            var RSData = from r in jobject["data"] select r;
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            foreach (var r in RSData)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dGV);
                row.Cells[0].Value = r["code"];
                row.Cells[1].Value = r["doc_code"];
                row.Cells[2].Value = r["item_code"];
                row.Cells[3].Value = r["SPTNO"];
                row.Cells[4].Value = r["ITMD1"];
                row.Cells[5].Value = r["quantity"];
                row.Cells[6].Value = r["lot_code"];
                row.Cells[7].Value = r["created_by"];
                row.Cells[8].Value = r["user_nicename"];
                row.Cells[9].Value = r["LOC"];
                row.Cells[10].Value = false;
                rows.Add(row);
            }
            dGV.Rows.AddRange(rows.ToArray());
        }

        private async Task<string[]> searchLabel(Dictionary<string, string> dataInput)
        {
            string message = "";
            string data = "";
            string returnCode = "1";
            using (HttpClient hc = new HttpClient())
            {
                var valuesRequest = new FormUrlEncodedContent(dataInput);
                var response = await hc.PostAsync(String.Format(serverURLEnpoint + "/label/c3-reprint"), valuesRequest);
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

        private void txtUniqueCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (txtUniqueCode.Text.Trim().Length == 16)
                {
                    // When user type uniquekey
                    btnSearch.Focus();
                }
                else
                {
                    if (txtUniqueCode.Text.Contains("|"))
                    {
                        // parse qr code
                        string[] QRArray = txtUniqueCode.Text.Split('|');
                        if (QRArray[0].Substring(0, 4).Equals("Z3N1"))
                        {
                            ItemCode = QRArray[0].Substring(4, QRArray[0].Length - 1 - 3);
                            txtUniqueCode.Text = QRArray[2];
                            btnSearch.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Invalid C3 Label (UC)");
                        }
                    }
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dGV.Rows)
            {
                if (Convert.ToBoolean(row.Cells[10].Value))
                {
                    mretitemcd = row.Cells[2].Value.ToString().Trim();
                    mretqty = row.Cells[5].Value.ToString().Trim();
                    mretlot = row.Cells[6].Value.ToString().Trim();
                    mNIK = row.Cells[7].Value.ToString().Trim();
                    mNIKName = row.Cells[8].Value.ToString().Trim();
                    mretitemnm = row.Cells[3].Value.ToString().Trim();

                    mrackcd = row.Cells[9].Value.ToString().Trim();
                    mUniqueCode = row.Cells[0].Value.ToString().Trim();
                    printsmtlabel();
                }
            }
        }


        void printsmtlabel()
        {
            RegistryKey ckrk = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\" + Application.ProductName);

            PSIPrinter PSIprinter = new PSIPrinter();
            Dictionary<string, string> datanya = new Dictionary<string, string>();
            datanya.Add("rackCode", mrackcd);
            datanya.Add("itemQty", mretqty);
            datanya.Add("itemCode", mretitemcd);
            datanya.Add("itemLot", mretlot);
            datanya.Add("itemKey", mUniqueCode);
            datanya.Add("itemName", mretitemnm);
            datanya.Add("nik", mNIK);
            datanya.Add("user_name", mNIKName);
            datanya.Add("mretrohs", "1");
            PSIprinter.setData(datanya);
            PSIprinter.print(ckrk.GetValue("PRINTER_DEFAULT_BRAND").ToString().ToLower());
        }
    }
}
