using com.citizen.sdk.LabelPrint;
using IniParser;
using IniParser.Model;
using Microsoft.Win32;
using System;
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
                    txtdarkness.Text = trackbdark.Value.ToString();
                    trackbthick.Value = UInt16.Parse(ckrk.GetValue("PRINTER_TICK").ToString());
                    txthick.Text = trackbthick.Value.ToString();
                    trackbnarrow.Value = UInt16.Parse(ckrk.GetValue("PRINTER_NARRROW").ToString());
                    textnarrow.Text = trackbnarrow.Value.ToString();
                    trackbarspeed.Value = UInt16.Parse(ckrk.GetValue("PRINTER_SPEED").ToString());
                    textspeed.Text = trackbarspeed.Value.ToString();
                }
            }
            ckrk.Close();
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("config.ini");
            txtserver.Text = data["SERVER"]["ADDRESS"];
        }

        private void FSettings_Load(object sender, EventArgs e)
        {
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


            MessageBox.Show("Saved");
            this.Close();
        }

        private void trackbdark_Scroll(object sender, EventArgs e)
        {

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
    }
}
