using com.citizen.sdk.LabelPrint;
using IniParser;
using IniParser.Model;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace SMTCSHARP
{
    public partial class FCombineRMLabel : Form
    {
        string itemcode = "";
        string itemname = "";
        string itemqty = "";
        string itemlotno = "";
        string msupqty = "";

        string mretitemcd = "";
        string mretqty = "";
        string mretlot = "";
        string mretitemnm = "";
        string mUniqueCode = "";
        public FCombineRMLabel()
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
        }

        void initcolumn()
        {
            //DG Joined Label
            dGV_lbljoin.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dGV_lbljoin.ColumnCount = 4;
            dGV_lbljoin.Columns[0].Name = "Item Code";
            dGV_lbljoin.Columns[0].Width = 200;
            dGV_lbljoin.Columns[1].Name = "Qty";
            dGV_lbljoin.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dGV_lbljoin.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dGV_lbljoin.Columns[2].Name = "Lot No";
            dGV_lbljoin.Columns[2].Width = 250;
            dGV_lbljoin.Columns[3].Width = 250;
            dGV_lbljoin.Columns[3].Name = "Item Name";

        }

        void printsmtlabel()
        {
            LabelPrinter printer = new LabelPrinter();
            printer.SetMeasurementUnit(LabelConst.CLS_UNIT_MILLI);
            printer.SetFormatAttribute(1);

            RegistryKey ckrk = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\" + Application.ProductName);
            string myaddr = ckrk.GetValue("PRINTER_ADDRESS").ToString();
            int mytype = UInt16.Parse(ckrk.GetValue("PRINTER_TYPE").ToString());
            string myDARk = ckrk.GetValue("PRINTER_DARK").ToString();
            UInt16 myTHICKNESS = UInt16.Parse(ckrk.GetValue("PRINTER_TICK").ToString());
            UInt16 myNARROW = UInt16.Parse(ckrk.GetValue("PRINTER_NARRROW").ToString());
            UInt16 mySPEED = UInt16.Parse(ckrk.GetValue("PRINTER_SPEED").ToString());

            int ret = printer.Connect(mytype, myaddr);
            if (ret != LabelConst.CLS_SUCCESS)
            {
                MessageBox.Show("Connect error: " + ret.ToString(), "Error");
            }

            LabelDesign lbldsg = new LabelDesign();
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;
            dtfi.DateSeparator = "/";
            int startx = 35;
            int mhratio = 105; //105, 75
            int mvratio = 110; //150,75



            lbldsg.DrawTextPCFont(String.Format("ITEM CODE : {0}    {1}", mretitemcd, Environment.MachineName.ToString()), "Times New Roman", LabelConst.CLS_RT_NORMAL, mhratio, mvratio, 7, (LabelConst.CLS_FNT_DEFAULT), startx, 410 + 20);
            lbldsg.DrawTextPCFont(String.Format("QTY : {0}    LOT NO : {1}", mretqty, mretlot), "Times New Roman", LabelConst.CLS_RT_NORMAL, mhratio, mvratio, 7, (LabelConst.CLS_FNT_DEFAULT), startx, 385 + 10);
            lbldsg.DrawTextPCFont(String.Format("(3N1) {0}", mretitemcd), "Times New Roman", LabelConst.CLS_RT_NORMAL, mhratio, mvratio, 7, (LabelConst.CLS_FNT_DEFAULT), startx, 360);
            lbldsg.DrawBarCode(String.Format("3N1{0}", mretitemcd.Trim()), LabelConst.CLS_BCS_CODE128, LabelConst.CLS_RT_NORMAL, myTHICKNESS, myNARROW, 55, startx, 300, LabelConst.CLS_BCS_TEXT_HIDE);
            lbldsg.DrawTextPCFont(String.Format("(3N2) {0} {1}", mretqty, mretlot.Trim()), "Times New Roman", LabelConst.CLS_RT_NORMAL, mhratio, mvratio, 7, (LabelConst.CLS_FNT_DEFAULT), startx, 255);
            lbldsg.DrawBarCode(String.Format("3N2 {0} {1} ", mretqty.Replace(",", string.Empty), mretlot.Trim()), LabelConst.CLS_BCS_CODE128, LabelConst.CLS_RT_NORMAL, myTHICKNESS, myNARROW, 55, startx, 200, LabelConst.CLS_BCS_TEXT_HIDE);
            lbldsg.DrawTextPCFont(String.Format("(UC) {0}", mUniqueCode), "Times New Roman", LabelConst.CLS_RT_NORMAL, mhratio, mvratio, 7, (LabelConst.CLS_FNT_DEFAULT), startx, 155 + 5);
            lbldsg.DrawBarCode(String.Format(mUniqueCode), LabelConst.CLS_BCS_CODE128, LabelConst.CLS_RT_NORMAL, myTHICKNESS, myNARROW, 55, startx, 100 + 5, LabelConst.CLS_BCS_TEXT_HIDE);
            lbldsg.DrawTextPCFont(String.Format("PART NO : {0}", mretitemnm.Trim()), "Times New Roman", LabelConst.CLS_RT_NORMAL, (mhratio - 5), (mvratio - 5), 7, (LabelConst.CLS_FNT_DEFAULT), startx, 70);
            lbldsg.DrawQRCode(String.Format("Z3N1{0}|3N2 {1} {2}|{3}", mretitemcd, mretqty.Replace(",", string.Empty), mretlot.Trim(), mUniqueCode), LabelConst.CLS_ENC_CDPG_IBM850, LabelConst.CLS_RT_NORMAL, 2, LabelConst.CLS_QRCODE_EC_LEVEL_H, startx + 520, 29);

            lbldsg.DrawTextPCFont("RoHS Compliant", "Times New Roman", LabelConst.CLS_RT_NORMAL, (mhratio - 5), (mvratio - 5), 7, (LabelConst.CLS_FNT_DEFAULT), startx, 45);
            lbldsg.DrawTextPCFont("C/O Made in SMT", "Times New Roman", LabelConst.CLS_RT_NORMAL, (mhratio - 5), (mvratio - 5), 7, (LabelConst.CLS_FNT_DEFAULT), 310, 45);
            lbldsg.DrawTextPCFont(String.Format("{0} : {1}", ASettings.getmyuserid(), ASettings.getmyuserfname()), "Times New Roman", LabelConst.CLS_RT_NORMAL, (mhratio - 5), (mvratio - 5), 7, (LabelConst.CLS_FNT_DEFAULT), startx, 20);
            lbldsg.DrawTextPCFont(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", dtfi), "Times New Roman", LabelConst.CLS_RT_NORMAL, (mhratio - 5), (mvratio - 5), 7, (LabelConst.CLS_FNT_DEFAULT), 310, 20);

            if (ret == LabelConst.CLS_SUCCESS)
            {
                printer.SetPrintDarkness(UInt16.Parse(myDARk));
                printer.SetPrintSpeed(mySPEED);
                printer.Print(lbldsg, 1);
                printer.Disconnect();
            }
            else
            {
                printer.Preview(lbldsg, LabelConst.CLS_PRT_RES_203, LabelConst.CLS_UNIT_MILLI, 700, 500);
            }
        }

        private void FCombineRMLabel_Load(object sender, EventArgs e)
        {
            initcolumn();
            ShowConfig();
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
                    txtdarkness.Text = trackbdark.Value.ToString();
                    txthick.Text = trackbthick.Value.ToString();
                    textnarrow.Text = trackbnarrow.Value.ToString();
                    textspeed.Text = trackbarspeed.Value.ToString();
                    ifCmbBox.SelectedValue = ckrk.GetValue("PRINTER_TYPE");
                }
            }
            ckrk.Close();
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("config.ini");
            txtserver.Text = data["SERVER"]["ADDRESS"];
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (textBox1.Text.Length > 3)
                {
                    if (textBox1.Text.Substring(0, 3) != "3N1")
                    {
                        MessageBox.Show("Unknown Format C3 Label");
                        textBox1.Text = "";
                        return;
                    }


                }
                else
                {
                    MessageBox.Show("Unknown Format C3 Label.");
                    return;
                }
                if (textBox1.Text.Contains(" "))
                {
                    string[] an1 = textBox1.Text.Split(' ');
                    msupqty = an1[1];
                    int strleng = an1[0].Length - 3;
                    itemcode = an1[0].Substring(3, strleng);
                }
                else
                {
                    int strleng = textBox1.Text.Length - 3;
                    itemcode = textBox1.Text.Substring(3, strleng);
                    msupqty = "";
                }
                textBox1.Text = itemcode;


                if (dGV_lbljoin.Rows.Count > 0)
                {
                    string currentItemcode = "";
                    foreach (DataGridViewRow row in dGV_lbljoin.Rows)
                    {
                        currentItemcode = row.Cells[0].Value.ToString();
                    }
                    if (!currentItemcode.Equals(itemcode))
                    {
                        MessageBox.Show("Could not join different Item Code");
                        return;
                    }
                }

                using (WebClient wc = new WebClient())
                {
                    try
                    {
                        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(itemcode);
                        string url = String.Format(txtserver.Text + "/item/{0}/location", Convert.ToBase64String(plainTextBytes));
                        var res = wc.DownloadString(url);

                        JObject res_jes = JObject.Parse(res);
                        string sts = (string)res_jes["status"][0]["cd"];
                        if (sts.Equals("0"))
                        {
                            MessageBox.Show((string)res_jes["status"][0]["msg"]);
                            textBox1.Text = "";
                        }
                        else
                        {
                            textBox1.ReadOnly = true;
                            txtlotno.Focus();
                            itemname = (string)res_jes["data"][0]["SPTNO"];
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            textBox1.Text = "";
            textBox1.Focus();
            txtlotno.ReadOnly = false;
            txtlotno.Text = "";

            itemcode = "";
            itemqty = "";
            itemlotno = "";
            itemname = "";
            dGV_lbljoin.Rows.Clear();

            mretitemcd = "";
            mretqty = "";
            mretlot = "";
            mretitemnm = "";
        }

        private void txtlotno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (txtlotno.Text.Length > 3)
                {
                    if (txtlotno.Text.Substring(0, 3) != "3N2")
                    {
                        MessageBox.Show("Unknown Format C3 Label");
                        txtlotno.Text = "";
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Unknown Format C3 Label.");
                    return;
                }

                string[] mthis_ar = txtlotno.Text.Split(' ');
                if (msupqty != "")
                {
                    itemqty = msupqty;

                    txtlotno.ReadOnly = true;
                    txtlotno.Text = mthis_ar[1];
                    itemlotno = mthis_ar[1];
                }
                else
                {
                    if (mthis_ar[1].All(char.IsNumber))
                    {
                        itemqty = mthis_ar[1];
                        itemlotno = mthis_ar[2];
                        txtlotno.ReadOnly = true;
                    }
                }


                //validate difference itemcode                                    
                if (dGV_lbljoin.Rows.Count > 0)
                {
                    string currentItemcode = "";
                    foreach (DataGridViewRow row in dGV_lbljoin.Rows)
                    {
                        currentItemcode = row.Cells[0].Value.ToString();
                    }
                    if (currentItemcode.Equals(itemcode))
                    {
                        dGV_lbljoin.Rows.Add(itemcode, itemqty, itemlotno, itemname);
                    }
                    else
                    {
                        MessageBox.Show("Could not join different Item Code");
                    }
                }
                else
                {
                    dGV_lbljoin.Rows.Add(itemcode, itemqty, itemlotno, itemname);
                }
                textBox1.ReadOnly = false;
                textBox1.Text = "";
                textBox1.Focus();
                txtlotno.ReadOnly = false;
                txtlotno.Text = "";

                itemcode = "";
                itemqty = "";
                itemlotno = "";
                itemname = "";
            }
        }

        private void btnSaveCombine_Click(object sender, EventArgs e)
        {
            if (dGV_lbljoin.Rows.Count > 1)
            {
                if (MessageBox.Show("Are You sure ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    string itmcode_print = "";
                    string itmname_print = "";
                    string itmcode = "";
                    string qtybefore = "";
                    string lotno = "";

                    foreach (DataGridViewRow row in dGV_lbljoin.Rows)
                    {
                        itmcode_print = row.Cells[0].Value.ToString();
                        itmcode += "item[]=" + row.Cells[0].Value.ToString() + "&";
                        qtybefore += "qty[]=" + row.Cells[1].Value.ToString() + "&";
                        lotno += "lotNumber[]=" + row.Cells[2].Value.ToString() + "&";
                        itmname_print = row.Cells[3].Value.ToString();
                    }
                    using (WebClient wc = new WebClient())
                    {
                        try
                        {
                            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                            string url = txtserver.Text + "/label/combine-raw-material";
                            string myparam = String.Format("{0}{1}{2}userId={3}&machineName={4}",
                                itmcode,
                                lotno,
                                qtybefore,
                                ASettings.getmyuserid(),
                                Environment.MachineName.ToString());
                            myparam = myparam.Replace("+", "%2B");
                            string res = wc.UploadString(url, myparam);

                            JObject res_jes = JObject.Parse(res);
                            string sts = (string)res_jes["status"][0]["cd"];
                            string msg = (string)res_jes["status"][0]["msg"];
                            string newqty = (string)res_jes["data"][0]["NEWQTY"];
                            string lotnoashome = (string)res_jes["data"][0]["NEWLOT"];
                            MessageBox.Show(msg);
                            if (sts.Equals("1"))
                            {
                                mretitemcd = itmcode_print;
                                mretqty = newqty;
                                mretlot = lotnoashome;
                                mretitemnm = itmname_print;
                                mUniqueCode = (string)res_jes["data"][0]["SER_ID"];
                                printsmtlabel();
                            }
                            dGV_lbljoin.Rows.Clear();
                            textBox1.Focus();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }

        private void btnsetting_Click(object sender, EventArgs e)
        {
            panel2.Show();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            panel2.Hide();
        }

        private void btnsearchprinter_Click(object sender, EventArgs e)
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

        private void btnreturnprint_Click(object sender, EventArgs e)
        {
            if (mretitemcd.Length == 0 ||
            mretqty.Length == 0 ||
            mretlot.Length == 0 ||
            mretitemnm.Length == 0)
            {
                MessageBox.Show("Nothing to be printed");
                return;
            }
            printsmtlabel();
        }

        private void btnCancelScan_Click(object sender, EventArgs e)
        {
            int ttlrows = dGV_lbljoin.Rows.Count;
            if (ttlrows > 0)
            {
                if (MessageBox.Show("Cancel last scan ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    dGV_lbljoin.Rows.Remove(dGV_lbljoin.Rows[ttlrows - 1]);
                }
            }
        }
    }
}
