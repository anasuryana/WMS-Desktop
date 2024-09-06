using com.citizen.sdk.LabelPrint;
using IniParser;
using IniParser.Model;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMTCSHARP
{

    public partial class FKittingReturn : Form
    {
        string msupqty = "";
        string mretitemcd = "";
        string mrackcd = "";
        string mretqty = "";
        string mretlot = "";
        string mretitemnm = "";
        string mretrohs = "";
        string mUniqueCode = "";
        public FKittingReturn()
        {
            InitializeComponent();
            DataTable dataTable1 = new DataTable("ComboBox");
            dataTable1.Columns.Add("Display", typeof(string));
            dataTable1.Columns.Add("Value", typeof(int));
            dataTable1.Rows.Add("NET", LabelConst.CLS_PORT_NET);
            dataTable1.Rows.Add("USB", LabelConst.CLS_PORT_USB);
            dataTable1.Rows.Add("COM", LabelConst.CLS_PORT_COM);
            dataTable1.Rows.Add("LPT", LabelConst.CLS_PORT_LPT);
            dataTable1.Rows.Add("Bluetooth", LabelConst.CLS_PORT_Bluetooth);
            ifCmbBox.DataSource = dataTable1;
            ifCmbBox.DisplayMember = "Display";
            ifCmbBox.ValueMember = "Value";
            ifCmbBox.SelectedIndex = 0;

            txtRackcd.ReadOnly = true;
        }

        private async Task<string[]> validateUniqueKeyVsPSN(string key)
        {
            string message = "";
            string data = "";
            string returnCode = "1";
            using (HttpClient hc = new HttpClient())
            {
                var response = await hc.GetAsync(String.Format(txtserver.Text + "/supply/validate-label?uniquekey={0}", key));
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    data = content;
                    message = "OK";
                }
                else
                {
                    message = "the response is not success yet";
                }

            }
            return new string[] { returnCode, message, data };
        }

        void get_countrylist()
        {
            using (WebClient wc = new WebClient())
            {
                try
                {
                    string url = txtserver.Text + "/country";
                    var res = wc.DownloadString(url);
                    JObject res_jes = JObject.Parse(res);
                    var rsdata = from p in res_jes["data"] select p;
                    var cmbsourc = new Dictionary<string, string>();
                    foreach (var rw in rsdata)
                    {
                        cmbsourc.Add((string)rw["MMADE_CD"], (string)rw["MMADE_NM"]);
                    }
                    comboBox1.DataSource = new BindingSource(cmbsourc, null);
                    comboBox1.DisplayMember = "Value";
                    comboBox1.ValueMember = "Key";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "[" + txtserver.Text + "]");
                }

            }
        }

        void ShowConfig()
        {
            RegistryKey ckrk = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\" + Application.ProductName);
            if (ckrk == null)
            {
                RegistryKey rk = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\" + Application.ProductName);
                rk.SetValue("PRINTER_DARK", trackbdark.Value);
                rk.SetValue("PRINTER_TICK", trackbthick.Value);
                rk.SetValue("PRINTER_NARRROW", trackbnarrow.Value);
                rk.SetValue("PRINTER_TYPE", "");
                rk.SetValue("PRINTER_ADDRESS", "");
                rk.SetValue("PRINTER_SPEED", "17");
            }
            else
            {
                var kchild = ckrk.GetValue("PRINTER_DARK");
                if (kchild == null)
                {
                    RegistryKey rk = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\" + Application.ProductName);
                    rk.SetValue("PRINTER_DARK", trackbdark.Value);
                    rk.SetValue("PRINTER_TICK", trackbthick.Value);
                    rk.SetValue("PRINTER_NARRROW", trackbnarrow.Value);
                    rk.SetValue("PRINTER_TYPE", "");
                    rk.SetValue("PRINTER_ADDRESS", "");
                    rk.SetValue("PRINTER_SPEED", "17");
                }
                else
                {
                    trackbdark.Value = UInt16.Parse(ckrk.GetValue("PRINTER_DARK").ToString());
                    trackbthick.Value = UInt16.Parse(ckrk.GetValue("PRINTER_TICK").ToString());
                    trackbnarrow.Value = UInt16.Parse(ckrk.GetValue("PRINTER_NARRROW").ToString());
                    trackbarspeed.Value = UInt16.Parse(ckrk.GetValue("PRINTER_SPEED").ToString());
                    ifCmbBox.SelectedValue = ckrk.GetValue("PRINTER_TYPE");
                }
            }
            ckrk.Close();
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("config.ini");
            txtserver.Text = data["SERVER"]["ADDRESS"];
        }

        void initcolumn()
        {
            dGV.ColumnCount = 13;
            dGV.Columns[0].Name = "ID";
            dGV.Columns[1].Name = "PSN No";
            dGV.Columns[2].Name = "Category";
            dGV.Columns[3].Name = "Line";
            dGV.Columns[3].Width = 70;
            dGV.Columns[4].Name = "F/R";
            dGV.Columns[4].Width = 40;
            dGV.Columns[5].Name = "Machine";
            dGV.Columns[6].Name = "Item Code";
            dGV.Columns[7].Name = "Item Name";
            dGV.Columns[8].Name = "Lot No";
            dGV.Columns[9].Name = "Sup. QTY";
            dGV.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dGV.Columns[10].Name = "Ret. QTY";
            dGV.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dGV.Columns[11].Name = "RoHS";
            dGV.Columns[11].Width = 70;
            dGV.Columns[12].Name = "Country";

            foreach (DataGridViewColumn column in dGV.Columns)
            {
                column.ReadOnly = true;
            }

            DataGridViewCheckBoxColumn hcb = new DataGridViewCheckBoxColumn();
            hcb.ValueType = typeof(bool);
            hcb.Width = 50;
            hcb.ToolTipText = "Print Flag";
            dGV.Columns.Add(hcb);

            DataGridViewTextBoxColumn htx = new DataGridViewTextBoxColumn();
            htx.DefaultCellStyle.Font = new Font("Wingdings", 22, GraphicsUnit.Pixel);
            htx.DefaultCellStyle.ForeColor = Color.Blue;
            htx.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            htx.Width = 50;
            htx.ReadOnly = true;
            dGV.Columns.Add(htx);



            DataGridViewButtonColumn hbt = new DataGridViewButtonColumn();
            hbt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            hbt.Width = 100;
            dGV.Columns.Add(hbt);

            htx = new DataGridViewTextBoxColumn();
            htx.Name = "Rack";
            htx.Width = 150;
            htx.ReadOnly = true;
            dGV.Columns.Add(htx);

            htx = new DataGridViewTextBoxColumn();
            htx.Name = "Key";
            htx.Width = 150;
            htx.ReadOnly = true;
            dGV.Columns.Add(htx);

            listView1.Items.Clear();
            listView1.Columns.Add("Port", 120, HorizontalAlignment.Left);
            listView1.Columns.Add("", 210, HorizontalAlignment.Left);


            //DG Joined Label
            dGV_lbljoin.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dGV_lbljoin.ColumnCount = 4;
            dGV_lbljoin.Columns[0].Name = "Item Code";
            dGV_lbljoin.Columns[0].Width = 200;
            dGV_lbljoin.Columns[1].Name = "Qty";
            dGV_lbljoin.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dGV_lbljoin.Columns[2].Name = "Lot No";
            dGV_lbljoin.Columns[2].Width = 200;
            dGV_lbljoin.Columns[3].Name = "Item Name";

        }

        void ret_e_getlist()
        {
            using (WebClient wc = new WebClient())
            {
                try
                {
                    string url = String.Format(txtserver.Text + "/return/counted?doc={0}&category={1}&line={2}", txtpsn.Text, txtcat.Text, txtline.Text).ToString();
                    var res = wc.DownloadString(url);
                    JObject res_jes = JObject.Parse(res);
                    var rsdata = from p in res_jes["data"] select p;
                    dGV.Rows.Clear();
                    List<DataGridViewRow> rows = new List<DataGridViewRow>();
                    foreach (var rw in rsdata)
                    {

                        string savedorno = rw["RETSCN_SAVED"].ToString();
                        string flghold = rw["FLG_HOLD"].ToString();
                        if (savedorno == "1")
                        {
                            savedorno = "ü";
                            flghold = "";
                        }
                        else
                        {
                            savedorno = "û";
                            if (flghold.Equals("0"))
                            {
                                flghold = "HOLD";
                            }
                            else
                            {
                                flghold = "RELEASE";
                            }
                        }
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(dGV);
                        row.Cells[0].Value = rw["RETSCN_ID"];
                        row.Cells[1].Value = rw["RETSCN_SPLDOC"];
                        row.Cells[2].Value = rw["RETSCN_CAT"];
                        row.Cells[3].Value = rw["RETSCN_LINE"];
                        row.Cells[4].Value = rw["RETSCN_FEDR"];
                        row.Cells[5].Value = rw["RETSCN_ORDERNO"];
                        row.Cells[6].Value = rw["RETSCN_ITMCD"];
                        row.Cells[7].Value = rw["MITM_SPTNO"];
                        row.Cells[8].Value = rw["RETSCN_LOT"];
                        row.Cells[9].Value = Convert.ToDouble(rw["RETSCN_QTYBEF"]).ToString("#,#");
                        row.Cells[10].Value = Convert.ToDouble(rw["RETSCN_QTYAFT"]).ToString("#,#");
                        row.Cells[11].Value = rw["RETSCN_ROHS"];
                        row.Cells[12].Value = rw["MMADE_NM"];
                        row.Cells[13].Value = false;
                        row.Cells[14].Value = savedorno;
                        row.Cells[15].Value = flghold;
                        row.Cells[16].Value = rw["SPL_RACKNO"];
                        row.Cells[17].Value = rw["RETSCN_UNIQUEKEY"];
                        rows.Add(row);
                    }
                    dGV.Rows.AddRange(rows.ToArray());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        private void btnsetting_Click(object sender, EventArgs e)
        {
            panel2.Show();
        }

        private void btnSaveconfig_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            int type = (int)ifCmbBox.SelectedValue;
            string straddres = "";
            if (listView1.SelectedItems.Count <= 0)
            {
                straddres = "";
            }
            else
            {
                straddres = listView1.SelectedItems[0].Text;
                RegistryKey rk = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\" + Application.ProductName);
                rk.SetValue("PRINTER_DARK", trackbdark.Value.ToString());
                rk.SetValue("PRINTER_TICK", trackbthick.Value.ToString());
                rk.SetValue("PRINTER_NARRROW", trackbnarrow.Value.ToString());
                rk.SetValue("PRINTER_TYPE", type.ToString());
                rk.SetValue("PRINTER_ADDRESS", straddres);
                rk.SetValue("PRINTER_SPEED", trackbarspeed.Value.ToString());
            }
            MessageBox.Show("Saved");
        }


        private void txtpsn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                using (WebClient wc = new WebClient())
                {
                    try
                    {
                        var res = wc.DownloadString(txtserver.Text + "/supply/validate-document?doc=" + txtpsn.Text);
                        JObject res_jes = JObject.Parse(res);
                        string sts = (string)res_jes["status"][0]["cd"];
                        if (!sts.Equals("0"))
                        {
                            txtcat.Focus();
                        }
                        else
                        {
                            MessageBox.Show((string)res_jes["status"][0]["msg"]);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
        }

        private void FKittingReturn_Load(object sender, EventArgs e)
        {
            initcolumn();
            ShowConfig();
            get_countrylist();
        }

        private void trackbdark_ValueChanged(object sender, EventArgs e)
        {
            txtdarkness.Text = trackbdark.Value.ToString();
        }

        void printsmtlabel()
        {
            PSIPrinter PSIprinter = new PSIPrinter();
            Dictionary<string, string> datanya = new Dictionary<string, string>();
            datanya.Add("rackCode", mrackcd);
            datanya.Add("itemQty", mretqty);
            datanya.Add("itemCode", mretitemcd.Trim());
            datanya.Add("itemLot", mretlot.Trim());
            datanya.Add("itemKey", mUniqueCode);
            datanya.Add("itemName", mretitemnm.Trim());
            datanya.Add("mretrohs", "1");
            PSIprinter.setData(datanya);
            PSIprinter.print("citizen");
        }

        private void btnreturnprint_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dGV.Rows)
            {

                if (Convert.ToBoolean(row.Cells[13].Value))
                {
                    mretitemcd = row.Cells[6].Value.ToString().Trim();
                    mretqty = row.Cells[10].Value.ToString().Trim();
                    mretlot = row.Cells[8].Value.ToString().Trim();
                    mretitemnm = row.Cells[7].Value.ToString().Trim();
                    mretrohs = row.Cells[11].Value.ToString().Trim();
                    mrackcd = row.Cells[16].Value.ToString().Trim();
                    txtRackcd.Text = row.Cells[16].Value.ToString().Trim();
                    mUniqueCode = row.Cells[17].Value.ToString().Trim();
                    printsmtlabel();
                }
            }

        }

        private void txtcat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                using (WebClient wc = new WebClient())
                {
                    try
                    {
                        var res = wc.DownloadString(String.Format(txtserver.Text + "/supply/validate-document?doc={0}&category={1}", txtpsn.Text, txtcat.Text));
                        JObject res_jes = JObject.Parse(res);
                        string sts = (string)res_jes["status"][0]["cd"];
                        if (!sts.Equals("0"))
                        {
                            txtline.Focus();
                        }
                        else
                        {
                            MessageBox.Show((string)res_jes["status"][0]["msg"]);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
        }

        private void txtline_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                using (WebClient wc = new WebClient())
                {
                    try
                    {
                        var res = wc.DownloadString(String.Format(txtserver.Text + "/supply/validate-document?doc={0}&category={1}&line={2}", txtpsn.Text, txtcat.Text, txtline.Text));
                        JObject res_jes = JObject.Parse(res);

                        string sts = (string)res_jes["status"][0]["cd"];
                        if (sts.Equals("1"))
                        {
                            txtitemcd.Focus();
                            var rsdata = from p in res_jes["WorkOrder"] select p;
                            string joblist = "";
                            foreach (var rw in rsdata)
                            {
                                joblist += rw["PPSN1_WONO"] + ",";
                            }
                            txtjoblist.Text = joblist.Substring(0, joblist.Length - 1);

                            ret_e_getlist();
                        }
                        else
                        {
                            MessageBox.Show((string)res_jes["status"][0]["msg"]);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
        }

        private void btnsearchprinter_Click_1(object sender, EventArgs e)
        {
            int searchmode = 0;     // searchmode == 0  : SearchCitizenPrinter
            //            != 0  : SearchLabelPrinter
            int res = 0;
            int type = 0;
            LabelPrinter printer = new LabelPrinter();

            //Initialize
            listView1.Items.Clear();
            type = (int)ifCmbBox.SelectedValue;

            if (searchmode == 0)
            {
                // 
                // example for SearchCitizenPrinter
                //

                CitizenPrinterInfo[] info;

                //Search available Citizen printers
                info = printer.SearchCitizenPrinter(type, 10, out res);
                if (res != LabelConst.CLS_SUCCESS)
                {
                    if (res == LabelConst.CLS_E_NO_LIST)
                    {
                        MessageBox.Show("Printer Not Found.");
                    }
                    else
                    {
                        MessageBox.Show("SearchCitizenPrinter Failed");
                    }
                    return;
                }

                //List up all available Citizen printers in the listView
                for (int i = 0; i < info.Length; i++)
                {
                    string[] CLSs = new string[2];
                    switch (type)
                    {

                        case LabelConst.CLS_PORT_NET:
                            CLSs[0] = info[i].ipAddress;
                            CLSs[1] = info[i].macAddress;
                            break;

                        case LabelConst.CLS_PORT_USB:
                            CLSs[0] = info[i].deviceName;
                            CLSs[1] = info[i].printerModel;
                            break;

                        case LabelConst.CLS_PORT_COM:
                            CLSs[0] = info[i].deviceName;
                            break;

                        case LabelConst.CLS_PORT_LPT:
                            CLSs[0] = info[i].deviceName;
                            break;

                        case LabelConst.CLS_PORT_Bluetooth:
                            CLSs[0] = info[i].bdAddress;
                            CLSs[1] = info[i].deviceName;
                            break;

                    }
                    listView1.Items.Add(new ListViewItem(CLSs));
                }
            }
            else
            {
                // 
                // example for SearchLabelPrinter
                //

                string[] address;

                //Search available Label printers
                address = printer.SearchLabelPrinter(type, 10, out res);
                if (res != LabelConst.CLS_SUCCESS)
                {
                    if (res == LabelConst.CLS_E_NO_LIST)
                    {
                        MessageBox.Show("Printer Not Found.");
                    }
                    else
                    {
                        MessageBox.Show("SearchLabelPrinter Failed");
                    }
                    return;
                }

                //List up all available Label printers in the listView
                for (int i = 0; i < address.Length; i++)
                {
                    string CLSs = address[i];
                    listView1.Items.Add(new ListViewItem(CLSs));
                }
            }

            listView1.Focus();
            listView1.Items[0].Selected = true;
        }



        private void txtitemcd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (txtpsn.Text == "")
                {
                    MessageBox.Show("Please fill PSN No");
                    txtpsn.Focus();
                    return;
                }
                if (txtcat.Text == "")
                {
                    MessageBox.Show("Please fill Category");
                    txtcat.Focus();
                    return;
                }

                if (txtline.Text == "")
                {
                    MessageBox.Show("Please fill Line");
                    txtline.Focus();
                    return;
                }

                if (txtitemcd.Text == "")
                {
                    MessageBox.Show("Please fill Item Code");
                    return;
                }

                if (txtitemcd.Text.Length <= 3)
                {
                    MessageBox.Show("Unknown Format C3 Label");
                    txtitemcd.Text = "";
                    return;
                }


                if (txtitemcd.Text.Contains("|"))
                {
                    string[] QRArray = txtitemcd.Text.ToUpper().Split('|');
                    int strLength3N1 = 0;
                    switch (QRArray[0].Substring(0, 2).ToString())
                    {
                        case "Z3":
                            strLength3N1 = QRArray[0].Length - 4;
                            txtitemcd.Text = QRArray[0].Substring(4, strLength3N1);
                            break;
                        case "3N":
                            strLength3N1 = QRArray[0].Length - 3;
                            txtitemcd.Text = QRArray[0].Substring(3, strLength3N1);
                            break;
                        default:
                            txtitemcd.Text = QRArray[0];
                            break;
                    }

                    string[] Array3N2;

                    if (QRArray.Length == 4)
                    {
                        txtbefqty.Text = QRArray[1];
                        txtlot.Text = QRArray[2];
                        txtbefqty.ReadOnly = true;
                    }
                    else
                    {
                        Array3N2 = QRArray[1].Split(' ');
                        switch (QRArray[1].Substring(0, 3).ToString())
                        {
                            case "3N2":
                                if (Array3N2[1].All(char.IsNumber))
                                {
                                    txtbefqty.Text = Array3N2[1];
                                    txtlot.Text = Array3N2[2];
                                    txtbefqty.ReadOnly = true;
                                }
                                break;

                            default:
                                if (Array3N2[0].All(char.IsNumber))
                                {
                                    txtbefqty.Text = Array3N2[0];
                                    txtlot.Text = Array3N2[1];
                                    txtbefqty.ReadOnly = true;
                                }
                                break;
                        }
                    }
                }
                else
                {

                }

                if (txtitemcd.Text.Substring(0, 3) != "3N1")
                {
                    MessageBox.Show("Unknown Format C3 Label");
                    txtitemcd.Text = "";
                    txtitmname.Text = "";
                    return;
                }

                if (txtitemcd.Text.Contains(" "))
                {
                    string[] an1 = txtitemcd.Text.Split(' ');
                    msupqty = an1[1];
                    int strleng = an1[0].Length - 3;
                    txtitemcd.Text = an1[0].Substring(3, strleng);
                }
                else
                {
                    int strleng = txtitemcd.Text.Length - 3;
                    txtitemcd.Text = txtitemcd.Text.Substring(3, strleng);
                    msupqty = "";
                }

                using (WebClient wc = new WebClient())
                {
                    try
                    {
                        string url = String.Format(txtserver.Text + "/supply/validate-item?doc={0}&category={1}&line={2}&item={3}", txtpsn.Text, txtcat.Text, txtline.Text, txtitemcd.Text);
                        var res = wc.DownloadString(url);

                        JObject res_jes = JObject.Parse(res);
                        string sts = (string)res_jes["data"][0]["cd"];
                        if (sts.Equals("0"))
                        {
                            MessageBox.Show((string)res_jes["data"][0]["msg"]);
                            txtitemcd.Text = "";
                            txtRackcd.Text = "";
                            txtitmname.Text = "";
                        }
                        else
                        {
                            txtbefqty.Focus();
                            txtbefqty.ReadOnly = false;
                            txtitmname.Text = (string)res_jes["data"][0]["ref"];
                            txtRackcd.Text = (string)res_jes["data"][0]["rackno"];
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
        }

        private void txtbefqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (txtbefqty.Text.Length <= 3)
                {
                    MessageBox.Show("Unknown Format C3 Label");
                    txtbefqty.Text = "";
                    return;
                }

                if (txtbefqty.Text.Substring(0, 3) != "3N2")
                {
                    MessageBox.Show("Unknown Format C3 Label lot");
                    txtbefqty.Text = "";
                    return;
                }
                else
                {
                    string[] mthis_ar = txtbefqty.Text.Split(' ');
                    if (msupqty != "")
                    {
                        txtbefqty.Text = msupqty;

                        txtbefqty.ReadOnly = true;
                        txtlot.Text = mthis_ar[1];
                    }
                    else
                    {
                        if (mthis_ar[1].All(char.IsNumber))
                        {
                            txtbefqty.Text = mthis_ar[1];
                            txtlot.Text = mthis_ar[2];
                            txtbefqty.ReadOnly = true;
                        }
                    }


                    using (WebClient wc = new WebClient())
                    {
                        string url = String.Format(txtserver.Text + "/supply/validate-supplied-item");
                        string myparam = String.Format("doc={0}&category={1}&line={2}&item={3}&lotNumber={4}&qty={5}", txtpsn.Text, txtcat.Text, txtline.Text, txtitemcd.Text, txtlot.Text, txtbefqty.Text);
                        myparam = myparam.Replace("+", "%2B");
                        try
                        {
                            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                            var res = wc.UploadString(url, myparam);
                            JObject res_jes = JObject.Parse(res);
                            string sts = (string)res_jes["status"][0]["cd"];
                            if (!sts.Equals("0"))
                            {
                                if (lbljoinPnl.Visible)
                                {
                                    //validate difference itemcode                                    
                                    if (dGV_lbljoin.Rows.Count > 0)
                                    {
                                        string currentItemcode = "";
                                        foreach (DataGridViewRow row in dGV_lbljoin.Rows)
                                        {
                                            currentItemcode = row.Cells[0].Value.ToString();
                                        }
                                        if (currentItemcode.Equals(txtitemcd.Text))
                                        {
                                            dGV_lbljoin.Rows.Add(txtitemcd.Text, txtbefqty.Text, txtlot.Text, txtitmname.Text);
                                        }
                                        else
                                        {
                                            MessageBox.Show("Could not join different Item Code");
                                        }
                                    }
                                    else
                                    {
                                        dGV_lbljoin.Rows.Add(txtitemcd.Text, txtbefqty.Text, txtlot.Text, txtitmname.Text);
                                    }
                                    txtitemcd.Text = "";
                                    txtitmname.Text = "";
                                    txtbefqty.Text = "";
                                    txtlot.Text = "";
                                    txtitemcd.Focus();
                                }
                                else
                                {
                                    txtaftqty.Focus();
                                }
                            }
                            else
                            {
                                txtbefqty.Text = "";
                                txtlot.Text = "";
                                MessageBox.Show("Item and PSN were not match");
                                txtbefqty.ReadOnly = false;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + "[" + url + "]");
                            txtbefqty.ReadOnly = false;
                        }
                    }
                }
            }
        }

        private void txtaftqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (txtaftqty.Text == "")
                {
                    txtaftqty.Focus();
                    MessageBox.Show("Please fill Actual Qty");
                    return;
                }
                if (UInt32.Parse(txtaftqty.Text) > UInt32.Parse(txtbefqty.Text))
                {
                    MessageBox.Show("Qty After > Qty Before");
                    txtaftqty.Focus();
                    txtaftqty.Select();
                    return;
                }
                btnsave.Focus();
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtpsn.Text == "")
            {
                MessageBox.Show("Please fill PSN No");
                txtpsn.Focus();
                return;
            }
            if (txtcat.Text == "")
            {
                MessageBox.Show("Please fill Category");
                txtcat.Focus();
                return;
            }

            if (txtline.Text == "")
            {
                MessageBox.Show("Please fill Line");
                txtline.Focus();
                return;
            }

            if (txtitemcd.Text == "")
            {
                MessageBox.Show("Please fill Item Code");
                return;
            }

            if (txtbefqty.Text == "")
            {
                MessageBox.Show("Please Scan qty or lot");
                txtbefqty.Text = "";
                return;
            }

            if (txtaftqty.Text == "")
            {
                txtaftqty.Focus();
                MessageBox.Show("Please fill Actual Qty");
                return;
            }
            if (UInt32.Parse(txtaftqty.Text) > UInt32.Parse(txtbefqty.Text))
            {
                MessageBox.Show("Qty After > Qty Before");
                txtaftqty.Focus();
                txtaftqty.Select();
                return;
            }
            string mrohs = radioButton1.Checked ? "1" : "0";

            using (WebClient wc = new WebClient())
            {
                try
                {
                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    string url = txtserver.Text + "/return";
                    string myparam = String.Format("doc={0}&category={1}&line={2}&item={3}&roHs={4}&qtyBefore={5}&qtyAfter={6}&lotNumber={7}&countryId={8}&userId={9}&machineName={10}",
                        txtpsn.Text,
                        txtcat.Text,
                        txtline.Text,
                        txtitemcd.Text,
                        mrohs,
                        txtbefqty.Text,
                        txtaftqty.Text,
                        txtlot.Text,
                        comboBox1.SelectedValue.ToString(),
                        ASettings.getmyuserid(),
                        Environment.MachineName.ToString());
                    myparam = myparam.Replace("+", "%2B");
                    string res = wc.UploadString(url, myparam);
                    JObject res_jes = JObject.Parse(res);

                    string sts = (string)res_jes["status"][0]["cd"];
                    string msg = (string)res_jes["status"][0]["msg"];

                    if (sts.Equals("02"))
                    {
                        DialogResult dr = MessageBox.Show(msg + ". Proceed anyway ?", "Decide", MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            save_alt();
                        }
                    }
                    else
                    {
                        MessageBox.Show(msg);
                        if (sts.Equals("11"))
                        {
                            mretitemcd = txtitemcd.Text.Trim();
                            mretqty = txtaftqty.Text.Trim();
                            mretlot = txtlot.Text.Trim().Length > 12 && txtpsn.Text.ToUpper().Contains("IEI") ? txtlot.Text.Trim().Substring(0, 12) : txtlot.Text.Trim();
                            mretitemnm = txtitmname.Text.Trim();
                            mrackcd = txtRackcd.Text.Trim();
                            mretrohs = mrohs;
                            mUniqueCode = (string)res_jes["status"][0]["RETSCN_UNIQUEKEY"];
                            printsmtlabel();
                        }
                        ret_e_getlist();
                        txtaftqty.Text = "";
                        txtitmname.Text = "";
                        txtitemcd.Text = "";
                        txtRackcd.Text = "";
                        txtlot.Text = "";
                        txtbefqty.ReadOnly = false;
                        txtbefqty.Text = "";
                        txtitemcd.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    txtbefqty.ReadOnly = false;
                }
            }
        }

        private void save_alt()
        {
            if (txtpsn.Text == "")
            {
                MessageBox.Show("Please fill PSN No");
                txtpsn.Focus();
                return;
            }
            if (txtcat.Text == "")
            {
                MessageBox.Show("Please fill Category");
                txtcat.Focus();
                return;
            }

            if (txtline.Text == "")
            {
                MessageBox.Show("Please fill Line");
                txtline.Focus();
                return;
            }

            if (txtitemcd.Text == "")
            {
                MessageBox.Show("Please fill Item Code");
                return;
            }

            if (txtbefqty.Text == "")
            {
                MessageBox.Show("Please Scan qty or lot");
                txtbefqty.Text = "";
                return;
            }

            if (txtaftqty.Text == "")
            {
                txtaftqty.Focus();
                MessageBox.Show("Please fill Actual Qty");
                return;
            }

            string mrohs = radioButton1.Checked ? "1" : "0";

            using (WebClient wc = new WebClient())
            {
                try
                {
                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    string url = txtserver.Text + "/return/alternative-saving";
                    string myparam = String.Format("doc={0}&category={1}&line={2}&item={3}&roHs={4}&qtyAfter={5}&countryId={6}&userId={7}&machineName={8}",
                        txtpsn.Text,
                        txtcat.Text,
                        txtline.Text,
                        txtitemcd.Text,
                        mrohs,
                        txtaftqty.Text,
                        comboBox1.SelectedValue.ToString(),
                        ASettings.getmyuserid(),
                        Environment.MachineName.ToString()
                        );
                    myparam = myparam.Replace("+", "%2B");
                    string res = wc.UploadString(url, myparam);

                    JObject res_jes = JObject.Parse(res);
                    string sts = (string)res_jes["status"][0]["cd"];
                    string msg = (string)res_jes["status"][0]["msg"];


                    MessageBox.Show(msg);

                    if (sts.Equals("11"))
                    {
                        mretitemcd = (string)res_jes["status"][0]["xitem"];
                        mretqty = (string)res_jes["status"][0]["xqty"];
                        mretlot = (string)res_jes["status"][0]["xlot"];
                        mretitemnm = (string)res_jes["status"][0]["xitemnm"];
                        mrackcd = txtRackcd.Text;
                        mUniqueCode = (string)res_jes["status"][0]["RETSCN_UNIQUEKEY"];
                        printsmtlabel();
                    }

                    ret_e_getlist();
                    txtaftqty.Text = "";
                    txtitmname.Text = "";
                    txtitemcd.Text = "";
                    txtRackcd.Text = "";
                    txtlot.Text = "";
                    txtbefqty.ReadOnly = false;
                    txtbefqty.Text = "";
                    txtitemcd.Focus();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    txtbefqty.ReadOnly = false;
                }
            }
        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            dGV.Rows.Clear();
            txtpsn.Text = "";
            txtcat.Text = "";
            txtline.Text = "";
            txtjoblist.Text = "";
            txtitemcd.Text = "";
            txtitmname.Text = "";
            txtbefqty.Text = "";
            txtbefqty.ReadOnly = false;
            txtlot.Text = "";
            txtRackcd.Text = "";
            msupqty = "";
            txtpsn.Focus();
        }

        private void dGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string idscan = dGV.Rows[dGV.CurrentCell.RowIndex].Cells[0].Value.ToString();
            switch (dGV.CurrentCell.ColumnIndex)
            {
                case 14:
                    if (dGV.CurrentCell.Value.ToString().Equals("û"))
                    {

                        if (MessageBox.Show("Are You sure ? " + idscan, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            try
                            {
                                using (HttpClient client = new HttpClient())
                                {
                                    client.BaseAddress = new Uri(txtserver.Text + '/');
                                    var request = new HttpRequestMessage(HttpMethod.Delete, "return/items/" + idscan);
                                    request.Content = new StringContent(JsonConvert.SerializeObject(new { userId = ASettings.getmyuserid() }), Encoding.UTF8, "application/json");
                                    using (HttpResponseMessage response2 = client.SendAsync(request).GetAwaiter().GetResult())
                                    {
                                        using (HttpContent content = response2.Content)
                                        {
                                            var json = content.ReadAsStringAsync().GetAwaiter().GetResult();
                                            JObject responseJobject = JObject.Parse(json);
                                            string sts = (string)responseJobject["status"][0]["cd"];
                                            string msg = (string)responseJobject["status"][0]["msg"];
                                            if (sts.Equals("1"))
                                            {
                                                ret_e_getlist();
                                            }
                                            MessageBox.Show(msg);
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                                txtbefqty.ReadOnly = false;
                            }
                        }

                    }
                    break;
                case 15:
                    switch (dGV.CurrentCell.Value.ToString())
                    {
                        case "HOLD":
                            sethold(idscan, "1");
                            break;
                        case "RELEASE":
                            sethold(idscan, "0");
                            break;
                    }
                    break;
            }
        }

        private void sethold(string pscanid, string state)
        {
            if (MessageBox.Show("Are You sure ? " + pscanid, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        client.BaseAddress = new Uri(txtserver.Text + '/');
                        var stringContent = new FormUrlEncodedContent(new[]
                        {
                           new KeyValuePair<string, string>("status", state)
                        });
                        HttpResponseMessage response = client.PutAsync("return/status/" + pscanid, stringContent).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            string product = response.Content.ReadAsStringAsync().Result;
                            JObject responseJobject = JObject.Parse(product);
                            string sts = (string)responseJobject["status"][0]["cd"];
                            string msg = (string)responseJobject["status"][0]["msg"];
                            if (sts.Equals("1"))
                            {
                                ret_e_getlist();
                            }
                            MessageBox.Show(msg);
                        }
                        else
                        {

                            MessageBox.Show(response.ReasonPhrase);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        txtbefqty.ReadOnly = false;
                    }

                }
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void trackbthick_ValueChanged(object sender, EventArgs e)
        {
            txthick.Text = trackbthick.Value.ToString();
        }

        private void trackbnarrow_ValueChanged(object sender, EventArgs e)
        {
            textnarrow.Text = trackbnarrow.Value.ToString();
        }

        private void trackbarspeed_ValueChanged(object sender, EventArgs e)
        {
            textspeed.Text = trackbarspeed.Value.ToString();
        }

        private void btnShwJoinLabelPnl_Click(object sender, EventArgs e)
        {
            lbljoinPnl.Show();
            txtitemcd.Focus();
        }

        private void btnCloseJoinPnl_Click(object sender, EventArgs e)
        {
            lbljoinPnl.Hide();
        }

        private void dGV_lbljoin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dGV_lbljoin_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void txtcombinedqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (txtcombinedqty.Text.Equals(""))
                {
                    txtcombinedqty.Focus();
                    MessageBox.Show("Please fill Actual Qty");
                    return;
                }
                int ttlRows = dGV_lbljoin.Rows.Count;
                if (ttlRows == 0)
                {
                    MessageBox.Show("Nothing to be processed");
                }
                else
                {
                    //validate qty
                    UInt32 ttlqty = 0;
                    foreach (DataGridViewRow row in dGV_lbljoin.Rows)
                    {
                        ttlqty += UInt32.Parse(row.Cells[1].Value.ToString());
                    }
                    if (UInt32.Parse(txtcombinedqty.Text) > ttlqty)
                    {
                        MessageBox.Show("After Qty > Before Qty (" + txtcombinedqty.Text + " > " + ttlqty.ToString() + ")");
                        txtcombinedqty.Focus();
                        txtcombinedqty.Select();
                    }
                    else
                    {
                        btnSaveCombine.Focus();
                    }
                }
            }
        }

        private void btnSaveCombine_Click(object sender, EventArgs e)
        {
            if (txtpsn.Text.Equals(""))
            {
                MessageBox.Show("Please fill PSN No");
                txtpsn.Focus();
                return;
            }
            if (txtcat.Text.Equals(""))
            {
                MessageBox.Show("Please fill Category");
                txtcat.Focus();
                return;
            }

            if (txtline.Text.Equals(""))
            {
                MessageBox.Show("Please fill Line");
                txtline.Focus();
                return;
            }

            string itmcode_print = "";
            string itmname_print = "";
            string itmcode = "";
            string qtybefore = "";
            string lotno = "";

            foreach (DataGridViewRow row in dGV_lbljoin.Rows)
            {
                itmcode_print = row.Cells[0].Value.ToString();
                itmcode += "item[]=" + row.Cells[0].Value.ToString() + "&";
                qtybefore += "qtyBefore[]=" + row.Cells[1].Value.ToString() + "&";
                lotno += "lotNumber[]=" + row.Cells[2].Value.ToString() + "&";
                itmname_print = row.Cells[3].Value.ToString();
            }
            if (itmcode.Equals(""))
            {
                MessageBox.Show("Please fill Item Code");
                return;
            }

            if (txtcombinedqty.Text.Equals(""))
            {
                txtaftqty.Focus();
                MessageBox.Show("Please fill Actual Qty");
                return;
            }

            string mrohs = radioButton1.Checked ? "1" : "0";

            using (WebClient wc = new WebClient())
            {
                try
                {
                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    string url = txtserver.Text + "/return/combine";
                    string myparam = String.Format("doc={0}&category={1}&line={2}&{3}roHs={4}&{5}qtyAfter={6}&{7}countryId={8}&userId={9}&machineName={10}",
                        txtpsn.Text,
                        txtcat.Text,
                        txtline.Text,
                        itmcode,
                        mrohs,
                        qtybefore,
                        txtcombinedqty.Text,
                        lotno,
                        comboBox1.SelectedValue.ToString(),
                        ASettings.getmyuserid(),
                        Environment.MachineName.ToString());
                    myparam = myparam.Replace("+", "%2B");
                    string res = wc.UploadString(url, myparam);

                    JObject res_jes = JObject.Parse(res);
                    string sts = (string)res_jes["status"][0]["cd"];
                    string msg = (string)res_jes["status"][0]["msg"];

                    MessageBox.Show(msg);

                    if (sts.Equals("11"))
                    {
                        string lotnoashome = (string)res_jes["status"][0]["lotno"];

                        mretitemcd = itmcode_print;
                        mretqty = txtcombinedqty.Text;
                        mretlot = lotnoashome;
                        mretitemnm = itmname_print;
                        mretrohs = mrohs;
                        mrackcd = txtRackcd.Text;
                        mUniqueCode = (string)res_jes["status"][0]["RETSCN_UNIQUEKEY"];
                        printsmtlabel();
                    }
                    ret_e_getlist();
                    txtcombinedqty.Text = "";
                    txtitmname.Text = "";
                    dGV_lbljoin.Rows.Clear();
                    lbljoinPnl.Hide();
                    txtitemcd.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    txtbefqty.ReadOnly = false;
                }
            }
        }
    }
}
