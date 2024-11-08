using IniParser.Model;
using IniParser;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Net;
using Microsoft.Win32;
using System.Net.Http;

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
        int timeOutClearing = 0;
        public FSplitLabel()
        {
            InitializeComponent();
        }

        private async void txt3n1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (!txtNIK.ReadOnly)
                {
                    txtNIK.Focus();
                    return;
                }
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
                    int[] intsArray = { 16, 17 };
                    if (intsArray.Contains(txt3n1.Text.Trim().Length))
                    {
                        using (HttpClient hc = new HttpClient())
                        {
                            var response = await hc.GetAsync(String.Format(this.serverURLEnpoint + "/label/c3?id={0}", txt3n1.Text.Trim()));
                            if (response.IsSuccessStatusCode)
                            {
                                var content = await response.Content.ReadAsStringAsync();
                                JObject jobject = JObject.Parse(content);
                                if (jobject["data"].Any(x => x.Type != JTokenType.Null))
                                {
                                    txt3n1.Text = string.Format("Z3N1{0}|3N2 {1} {2}|{3}",
                                        jobject["data"]["item_code"].ToString(),
                                        Convert.ToDouble(jobject["data"]["quantity"].ToString()).ToString(),
                                        jobject["data"]["lot_code"].ToString(),
                                        jobject["data"]["code"].ToString()
                                        );
                                    SendKeys.Send("{ENTER}");
                                } else
                                {
                                    MessageBox.Show("Unique Code is not found");
                                }
                            } else
                            {
                                MessageBox.Show("failed to contact server API");
                            }
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
        }

        private void FSplitLabel_Load(object sender, EventArgs e)
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("config.ini");
            serverURLEnpoint = data["SERVER"]["ADDRESS"];
            timeOutClearing = 300;
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
            txtNIK.Focus();
            lblInfo.Text = "...";

            radTwo.Checked = false;
            radMulti.Checked = false;

            timeOutClearing = 300;
            txtNIK.Text = "";
            txtName.Text = "";
            txtNIK.ReadOnly = false;

            txtCopies.Value = 1;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtQty.Equals(msupqty))
            {
                txtQty.Focus();
                MessageBox.Show("Could not be splitted");
                return;
            }

            if (!txtNIK.ReadOnly)
            {
                txtNIK.Focus();
                MessageBox.Show("NIK is required");
                return;
            }

            if (!txt3n1.ReadOnly)
            {
                txt3n1.Focus();
                MessageBox.Show("3N1 is required");
                return;
            }

            if (!txt3n2.ReadOnly)
            {
                txt3n2.Focus();
                MessageBox.Show("3N2 is required");
                return;
            }

            if (txtQty.Value.ToString().Equals(msupqty))
            {
                lblInfo.Text = "Reprint";
                DialogResult dialogResult = MessageBox.Show("It will reprint, are you sure ?", "Decide", MessageBoxButtons.YesNo);
                if (dialogResult != DialogResult.Yes)
                {
                    return;
                }
            }
            else
            {
                if (!radTwo.Checked && !radMulti.Checked)
                {
                    MessageBox.Show("Please select mode");
                    return;
                }
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
                        txtNIK.Text,
                        uniqueKey,
                        lotNumber,
                        Environment.MachineName.ToString());

                    myparam = myparam.Replace("+", "%2B");
                    string res = wc.UploadString(url, myparam);


                    JObject res_jes = JObject.Parse(res);
                    string sts = (string)res_jes["cd"];
                    string msg = (string)res_jes["msg"];

                    MessageBox.Show(msg);

                    if (sts.Equals("1"))
                    {
                        txt3n1.ReadOnly = false;
                        txt3n2.ReadOnly = false;

                        txt3n2.Text = string.Empty;
                        txtQty.Text = string.Empty;
                        txtQty.Maximum = 0;
                        uniqueKey = string.Empty;
                        txt3n1.Focus();
                        lblInfo.Text = "...";
                        radTwo.Checked = false;
                        radMulti.Checked = false;
                        var rsdata = from p in res_jes["data"] select p;

                        foreach (var rw in rsdata)
                        {
                            mrackcd = rw["LOC"].ToString();
                            mretqty = rw["quantity"].ToString();
                            mUniqueCode = rw["code"].ToString();
                            mretitemnm = rw["SPTNO"].ToString();
                            printsmtlabel();
                        }

                        txt3n1.Text = string.Empty;
                        txtCopies.Value = 1;
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
            datanya.Add("nik", txtNIK.Text);
            datanya.Add("user_name", txtName.Text);
            datanya.Add("mretrohs", "1");
            datanya.Add("copies", txtCopies.Value.ToString());
            PSIprinter.setData(datanya);
            PSIprinter.print(ckrk.GetValue("PRINTER_DEFAULT_BRAND").ToString().ToLower());
        }

        private void txtQty_Leave(object sender, EventArgs e)
        {
            setLabelInfo();
        }


        private void setLabelInfo()
        {
            if (txtQty.Value <= 1 || !txt3n1.ReadOnly || !txt3n2.ReadOnly)
            {
                return;
            }
            if (radTwo.Checked)
            {
                lblInfo.Text = "Will print 2 labels";
            }
            else
            {
                int supQty = msupqty.Equals("") ? 0 : int.Parse(msupqty);
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

        private void txt3n1_TextChanged(object sender, EventArgs e)
        {
            timeOutClearing = 300;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(txtNIK, String.Format("{0} seconds remain", timeOutClearing));
            if (timeOutClearing > 0)
            {
                timeOutClearing--;
            }
            else
            {
                timeOutClearing = 300;
                txtNIK.Text = "";
                txtNIK.ReadOnly = false;
                txtNIK.Focus();
                txtName.Text = "";
            }
        }

        private void txtNIK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                using (WebClient wc = new WebClient())
                {
                    try
                    {
                        var res = wc.DownloadString(serverURLEnpoint + "/users/" + txtNIK.Text);
                        JObject res_jes = JObject.Parse(res);
                        string sts = (string)res_jes["cd"];
                        if (sts.Equals("1"))
                        {
                            txtNIK.ReadOnly = true;
                            txtName.Text = (string)res_jes["data"]["user_nicename"];
                            txt3n1.Focus();
                            timeOutClearing = 300;
                        }
                        else
                        {
                            MessageBox.Show("NIK is not registered");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void radTwo_Click(object sender, EventArgs e)
        {
            btnSave.Focus();
        }

        private void radMulti_Click(object sender, EventArgs e)
        {
            btnSave.Focus();
        }

        private void txtQty_Enter(object sender, EventArgs e)
        {
            txtQty.Select(0, txtQty.Text.Length);
        }

        private void txtQty_Click(object sender, EventArgs e)
        {
            txtQty.Select(0, txtQty.Text.Length);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FLabelMasterHistory fLabelMasterHistory = new FLabelMasterHistory();
            fLabelMasterHistory.ShowDialog();
        }
    }
}
