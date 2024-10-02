using IniParser.Model;
using IniParser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using NPOI.SS.Formula.Functions;
using NPOI.XSSF.UserModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net;
using Microsoft.Win32;

namespace SMTCSHARP
{
    public partial class FSplitLabel : Form
    {
        string msupqty = "";
        string serverURLEnpoint = "";
        string uniqueKey = string.Empty;
        string lotNumber = string.Empty;

        string mrackcd = string.Empty;
        string mretqty = string.Empty;
        string mUniqueCode = string.Empty;
        string mretitemnm = string.Empty;

        public FSplitLabel()
        {
            InitializeComponent();
        }

        private void txt3n1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (txt3n1.Text.Length <= 3)
                {
                    MessageBox.Show("Unknown Format C3 Label");
                    txt3n1.Text = "";
                    return;
                }


                if (txt3n1.Text.Contains("|"))
                {
                    // parse qr code
                    string[] QRArray = txt3n1.Text.Split('|');
                    if (QRArray[0].Substring(0, 4).Equals("Z3N1"))
                    {
                        txt3n1.Text = QRArray[0].Substring(4, QRArray[0].Length - 1 - 3);
                        txt3n1.ReadOnly = true;
                        txt3n2.Text = QRArray[1];
                        txt3n2.ReadOnly = true;

                        string[] array3N2 = txt3n2.Text.Split(' ');
                        txtQty.Maximum = int.Parse(array3N2[1]);
                        lotNumber = array3N2[2];
                        msupqty = array3N2[1];
                        uniqueKey = QRArray[2];
                        txtQty.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Invalid C3 Label (UC)");
                    }
                }
                else
                {
                    if (txt3n1.Text.Substring(0, 3) != "3N1")
                    {
                        MessageBox.Show("Unknown Format C3 Label");
                        txt3n1.Text = "";
                        return;
                    }

                    if (txt3n1.Text.Contains(" "))
                    {
                        string[] an1 = txt3n1.Text.Split(' ');
                        msupqty = an1[1];
                        int strleng = an1[0].Length - 3;
                        txt3n1.Text = an1[0].Substring(3, strleng);
                    }
                    else
                    {
                        int strleng = txt3n1.Text.Length - 3;
                        txt3n1.Text = txt3n1.Text.Substring(3, strleng);
                        msupqty = "";
                    }
                    txt3n1.ReadOnly = true;
                    txt3n2.Focus();
                }

            }
        }

        private void FSplitLabel_Load(object sender, EventArgs e)
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("config.ini");
            serverURLEnpoint = data["SERVER"]["ADDRESS"];
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txt3n1.ReadOnly = false;
            txt3n2.ReadOnly = false;
            txt3n1.Text = string.Empty;
            txt3n2.Text = string.Empty;
            txtQty.Text = string.Empty;
            txtQty.Maximum = 0;
            uniqueKey = string.Empty;
            txt3n1.Focus();
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (!txt3n2.ReadOnly)
                {
                    MessageBox.Show("3N2 is required");
                    return;
                }

                btnSave.Focus();
            }
        }

        private void txt3n2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (!txt3n2.ReadOnly)
                {
                    if (txt3n2.Text.Length <= 3)
                    {
                        MessageBox.Show("Unknown Format C3 Label");
                        txt3n2.Text = "";
                        return;
                    }

                    if (!txt3n2.Text.ToUpper().Substring(0, 3).Equals("3N2"))
                    {
                        MessageBox.Show("Unknown Format C3 Label lot");
                        txt3n2.Text = "";
                        return;
                    }
                    else
                    {
                        string[] mthis_ar = txt3n2.Text.Split(' ');
                        if (msupqty != "")
                        {
                            txt3n2.ReadOnly = true;
                            lotNumber = mthis_ar[1];
                        }
                        else
                        {
                            if (mthis_ar[1].All(char.IsNumber))
                            {
                                msupqty = mthis_ar[1];
                                lotNumber = mthis_ar[2];
                                txt3n2.ReadOnly = true;
                            }
                        }
                        txtQty.Focus();
                        txtQty.Maximum = int.Parse(msupqty);
                    }
                }
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (txtQty.Equals(msupqty))
            {
                MessageBox.Show("Could not be splitted");
                return;
            }

            using (WebClient wc = new WebClient())
            {
                try
                {
                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    string url = serverURLEnpoint + "/item/split";
                    string myparam = String.Format("item_code={0}&old_qty={1}&mode={2}&new_qty={3}&user_id={4}&uniqueBefore={5}&lot_number={6}&machineName={7}",
                        txt3n1.Text,
                        msupqty,
                        radTwo.Checked ? '1' : '2',
                        txtQty.Value.ToString(),
                        ASettings.getmyuserid(),
                        uniqueKey,
                        lotNumber,
                        Environment.MachineName.ToString());
                    myparam = myparam.Replace("+", "%2B");
                    string res = wc.UploadString(url, myparam);
                    Console.WriteLine(res);
                    JObject res_jes = JObject.Parse(res);
                    string sts = (string)res_jes["cd"];
                    string msg = (string)res_jes["msg"];

                    MessageBox.Show(msg);

                    if (sts.Equals("1"))
                    {
                        var rsdata = from p in res_jes["data"] select p;

                        foreach (var rw in rsdata)
                        {
                            mrackcd = rw["LOC"].ToString();
                            mretqty = rw["quantity"].ToString();
                            mUniqueCode = rw["code"].ToString();
                            mretitemnm = rw["SPTNO"].ToString();
                            printsmtlabel();
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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
            datanya.Add("itemCode", txt3n1.Text);
            datanya.Add("itemLot", lotNumber);
            datanya.Add("itemKey", mUniqueCode);
            datanya.Add("itemName", mretitemnm);
            datanya.Add("mretrohs", "1");
            PSIprinter.setData(datanya);
            PSIprinter.print(ckrk.GetValue("PRINTER_DEFAULT_BRAND").ToString().ToLower());
        }

        private void txtQty_Leave(object sender, EventArgs e)
        {
            if (txtQty.Value.ToString().Equals(msupqty))
            {
                MessageBox.Show("Could not be splitted");
                txtQty.Focus();
                return;
            }
            setLabelInfo();
        }


        private void setLabelInfo()
        {
            if (txtQty.Value <= 1)
            {
                return;
            }
            if (radTwo.Checked)
            {
                lblInfo.Text = "Will print 2 labels";
            }
            else
            {
                int supQty = int.Parse(msupqty);
                int restValue = supQty % int.Parse(txtQty.Value.ToString()) != 0 ? 1 : 0;
                int labelQty = supQty / int.Parse(txtQty.Value.ToString());
                if (restValue > 0)
                {
                    lblInfo.Text = string.Format("Will print {0} + {1} labels", labelQty, restValue);
                }
                else
                {
                    lblInfo.Text = string.Format("Will print {0} labels.", labelQty, restValue);
                }

            }
        }

        private void radTwo_CheckedChanged(object sender, EventArgs e)
        {
            setLabelInfo();
        }

        private void radMulti_CheckedChanged(object sender, EventArgs e)
        {
            setLabelInfo();
        }
    }
}
