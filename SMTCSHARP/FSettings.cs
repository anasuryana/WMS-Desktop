using com.citizen.sdk.LabelPrint;
using IniParser;
using IniParser.Model;
using Microsoft.Win32;
using NPOI.HSSF.Record;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SMTCSHARP
{
    public partial class FSettings : Form
    {
        public FSettings()
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
                rk.SetValue("PRINTER_DEFAULT_BRAND", "citizen");
                rk.SetValue("PRINTER_BRAND_TSC_NAME", "");
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
                    rk.SetValue("PRINTER_DEFAULT_BRAND", "citizen");
                    rk.SetValue("PRINTER_BRAND_TSC_NAME", "");
                }
                else
                {
                    trackbdark.Value = UInt16.Parse(ckrk.GetValue("PRINTER_DARK").ToString());
                    txtdarkness.Text = trackbdark.Value.ToString();
                    trackbthick.Value = UInt16.Parse(ckrk.GetValue("PRINTER_TICK").ToString());
                    txthick.Text = trackbthick.Value.ToString();
                    trackbnarrow.Value = UInt16.Parse(ckrk.GetValue("PRINTER_NARRROW").ToString());
                    textnarrow.Text = trackbnarrow.Value.ToString();
                    trackbarspeed.Value = UInt16.Parse(ckrk.GetValue("PRINTER_SPEED").ToString());
                    textspeed.Text = trackbarspeed.Value.ToString();
                }


                // adaptation new key related printer
                var kchild2 = ckrk.GetValue("PRINTER_DEFAULT_BRAND");
                if (kchild2 == null)
                {
                    RegistryKey rk = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\" + Application.ProductName);
                    rk.SetValue("PRINTER_DARK", trackbdark.Value);
                    rk.SetValue("PRINTER_TICK", trackbthick.Value);
                    rk.SetValue("PRINTER_NARRROW", trackbnarrow.Value);
                    rk.SetValue("PRINTER_TYPE", "");
                    rk.SetValue("PRINTER_ADDRESS", "");
                    rk.SetValue("PRINTER_SPEED", "17");
                    rk.SetValue("PRINTER_DEFAULT_BRAND", "CITIZEN");
                    rk.SetValue("PRINTER_BRAND_TSC_NAME", "");
                    rk.SetValue("PRINTER_BRAND_TSC_SIZE", "2.87,1.97");
                    rk.SetValue("PRINTER_BRAND_TSC_SPEED", "2");
                    rk.SetValue("PRINTER_BRAND_TSC_DENSITY", "8");
                }
                else
                {
                    cmbDefaultPrinter.Text = ckrk.GetValue("PRINTER_DEFAULT_BRAND").ToString();
                    cmbPrinterTSC.Text = ckrk.GetValue("PRINTER_BRAND_TSC_NAME").ToString();
                    txtPrinterTSCSize.Text = ckrk.GetValue("PRINTER_BRAND_TSC_SIZE").ToString();
                    nudSpeed.Text = ckrk.GetValue("PRINTER_BRAND_TSC_SPEED").ToString();
                    tbDensity.Value = UInt16.Parse(ckrk.GetValue("PRINTER_BRAND_TSC_DENSITY").ToString().Length == 0 ? "0" : ckrk.GetValue("PRINTER_BRAND_TSC_DENSITY").ToString());
                    toolTip1.SetToolTip(tbDensity, tbDensity.Value.ToString());
                }
            }
            ckrk.Close();
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("config.ini");
            txtserver.Text = data["SERVER"]["ADDRESS"];
        }

        private void FSettings_Load(object sender, EventArgs e)
        {
            // get printer TSC List
            foreach (string printerName in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                if (printerName.ToUpper().Contains("TSC"))
                {
                    cmbPrinterTSC.Items.Add(printerName);
                }
            }

            ShowConfig();
        }

        private void btnSaveconfig_Click(object sender, EventArgs e)
        {
            int type = (int)ifCmbBox.SelectedValue;
            string straddres = listView1.SelectedItems.Count <= 0 ? "" : listView1.SelectedItems[0].Text;
            RegistryKey rk = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\" + Application.ProductName);
            rk.SetValue("PRINTER_DARK", trackbdark.Value.ToString());
            rk.SetValue("PRINTER_TICK", trackbthick.Value.ToString());
            rk.SetValue("PRINTER_NARRROW", trackbnarrow.Value.ToString());
            rk.SetValue("PRINTER_TYPE", type.ToString());
            rk.SetValue("PRINTER_ADDRESS", straddres);
            rk.SetValue("PRINTER_SPEED", trackbarspeed.Value.ToString());

            rk.SetValue("PRINTER_DEFAULT_BRAND", cmbDefaultPrinter.Text);
            rk.SetValue("PRINTER_BRAND_TSC_NAME", cmbPrinterTSC.Text);
            rk.SetValue("PRINTER_BRAND_TSC_SIZE", txtPrinterTSCSize.Text);
            rk.SetValue("PRINTER_BRAND_TSC_SPEED", nudSpeed.Text);
            rk.SetValue("PRINTER_BRAND_TSC_DENSITY", tbDensity.Value.ToString());

            MessageBox.Show("Saved");
            this.Close();
        }

        private void cmbDefaultPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDefaultPrinter.Text.ToUpper().Equals("TSC"))
            {
                tabControl2.SelectedIndex = 1;
            }
            else
            {
                tabControl2.SelectedIndex = 0;
            }
        }

        private void btnPrintTestpage_Click(object sender, EventArgs e)
        {
            if (cmbDefaultPrinter.Text.Length == 0)
            {
                MessageBox.Show("Please select default printer");
                return;
            }
            PSIPrinter PSIprinter = new PSIPrinter();
            Dictionary<string, string> datanya = new Dictionary<string, string>();
            datanya.Add("rackCode", "rack01");
            datanya.Add("itemQty", "150");
            datanya.Add("itemCode", "21334");
            datanya.Add("itemLot", "lot01");
            datanya.Add("itemKey", "24041");
            datanya.Add("itemName", "MCR");
            datanya.Add("mretrohs", "1");
            PSIprinter.setData(datanya);
            PSIprinter.print(cmbDefaultPrinter.Text.ToLower());
        }

        private void trackbdark_ValueChanged(object sender, EventArgs e)
        {
            txtdarkness.Text = trackbdark.Value.ToString();
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

        private void tbDensity_Scroll(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(tbDensity, tbDensity.Value.ToString());
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
    }
}
