using IniParser.Model;
using IniParser;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Microsoft.Win32;

namespace SMTCSHARP
{
    public partial class FCombineRMLabelPSN : Form
    {

        string mServerApi = "";
        string msupqty = string.Empty;
        string itemcode = "";
        string mrackcd = "";

        string mretitemcd = "";
        string mitemValue = string.Empty;
        string mretqty = "";
        string mretlot = "";
        string mretitemnm = "";
        string mUniqueCode = "";
        string OldUniqueCode = "";
        string mValue = "";
        JObject _content;

        bool isLCRConnected = false;
        string LCRPortName = string.Empty;
        string LCRBaudRate = string.Empty;
        string LCRMessage = string.Empty;

        private RS_232C_USB comm;

        string meas = string.Empty;

        public FCombineRMLabelPSN()
        {
            InitializeComponent();
        }

        void initcolumn()
        {
            //DG Joined Label
            dGV_lbljoin.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dGV_lbljoin.ColumnCount = 4;
            dGV_lbljoin.Columns[0].Name = "Lot Number";
            dGV_lbljoin.Columns[0].Width = 250;
            dGV_lbljoin.Columns[1].Name = "Qty";
            dGV_lbljoin.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dGV_lbljoin.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dGV_lbljoin.Columns[2].Name = "Old Uniquekey";
            dGV_lbljoin.Columns[2].Width = 300;
            dGV_lbljoin.Columns[3].Name = "Value";
            dGV_lbljoin.Columns[3].Width = 300;

            dgvLogs.ColumnCount = 2;
            dgvLogs.Columns[0].Name = "Time";
            dgvLogs.Columns[0].Width = 550;
            dgvLogs.Columns[1].Name = "Value";
        }

        private void FCombineRMLabelPSN_Load(object sender, EventArgs e)
        {
            initcolumn();

            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("config.ini");
            mServerApi = data["SERVER"]["ADDRESS"];

            loadLCRConfig();
        }

        void loadLCRConfig()
        {
            try
            {
                RegistryKey ckrk = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\" + Application.ProductName);
                LCRPortName = ckrk.GetValue("LCR_PORT").ToString();
                LCRBaudRate = ckrk.GetValue("LCR_BAUD_RATE").ToString();
            }
            catch (Exception ex)
            {
                RegistryKey rk = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\" + Application.ProductName);
                rk.SetValue("LCR_PORT", "");
                rk.SetValue("LCR_BAUD_RATE", "9600");

                LCRBaudRate = "9600";
                MessageBox.Show("Go to Tools > Settings > [LCR Meter]");
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtDocument.Text = "";
            txtDocument.ReadOnly = false;


            clearInputs();
        }

        void clearInputs()
        {
            txt3n1.Text = string.Empty;
            itemcode = string.Empty;
            txt3n2.Text = string.Empty;
            txtProcess.Text = string.Empty;
            txtMC.Text = string.Empty;
            txtMCZ.Text = string.Empty;
            txtValue.Text = string.Empty;

            txt3n1.ReadOnly = false;
            dGV_lbljoin.Rows.Clear();

            txtMin.Text = string.Empty;
            txtMax.Text = string.Empty;
        }


        bool isAbleToAdded(JArray data)
        {
            bool isFound = false;
            if (txtProcess.Text.Length > 0)
            {
                if (!data[0]["SPLSCN_PROCD"].ToString().Equals(txtProcess.Text))
                {
                    MessageBox.Show("unable to join reel because Process is different");
                    return false;
                }
                if (!data[0]["SPLSCN_MC"].ToString().Equals(txtMC.Text))
                {
                    MessageBox.Show("unable to join reel because MC is different");
                    return false;
                }
                if (!data[0]["SPLSCN_ORDERNO"].ToString().Equals(txtMCZ.Text))
                {
                    MessageBox.Show("unable to join reel because MCZ is different");
                    return false;
                }
            }

            // validate uniquekey
            foreach (DataGridViewRow row in dGV_lbljoin.Rows)
            {
                if (row.Cells[2].Value.ToString().Equals(data[0]["SPLSCN_UNQCODE"].ToString()))
                {
                    MessageBox.Show("the label is already in the list below");
                    isFound = true;
                    break;
                }
            }

            if (isFound)
            {
                return false;
            }
            else
            {
                // valiate non uniquekey
                if (data.Count == 1)
                {
                    foreach (DataGridViewRow row in dGV_lbljoin.Rows)
                    {
                        if (row.Cells[0].Value.ToString().Equals(data[0]["SPLSCN_LOTNO"].ToString())
                            && (int)row.Cells[1].Value == (int)data[0]["SPLSCN_QTY"])

                        {
                            MessageBox.Show("the label is already in the list below");
                            isFound = true;
                            break;
                        }
                    }
                }
                return !isFound;
            }
        }

        bool validateBefore3N2(JObject response)
        {
            Console.WriteLine(response.ToString());
            JArray data = (JArray)response["status"][0]["data"];
            return isAbleToAdded(data);
        }

        void validateAfter3N2(JObject response)
        {
            JArray data = (JArray)response["status"][0]["data"];

            txtProcess.Text = (response["status"][0]["data"][0]["SPLSCN_PROCD"] ?? "").ToString();
            txtMC.Text = (response["status"][0]["data"][0]["SPLSCN_MC"] ?? "").ToString();
            txtMCZ.Text = (response["status"][0]["data"][0]["SPLSCN_ORDERNO"] ?? "").ToString();
            mValue = txtValue.Text;

            addToList(data);

            txt3n1.Text = "";
            txt3n2.Text = "";
            txtValue.Text = string.Empty;

            txt3n1.ReadOnly = false;
            txt3n2.ReadOnly = false;

            txt3n1.Focus();

        }

        void addToList(JArray data)
        {
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            var RSData = from r in data select r;
            foreach (var r in RSData)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dGV_lbljoin);
                row.Cells[0].Value = r["SPLSCN_LOTNO"];
                row.Cells[1].Value = Convert.ToDouble(r["SPLSCN_QTY"]).ToString("#,#");
                row.Cells[2].Value = r["SPLSCN_UNQCODE"];
                row.Cells[3].Value = mValue;
                rows.Add(row);
            }
            dGV_lbljoin.Rows.AddRange(rows.ToArray());
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (dGV_lbljoin.Rows.Count <= 1)
            {
                MessageBox.Show("nothing to be saved");
                return;
            }

            dynamic dataInput = new JObject();
            dataInput.userId = ASettings.getmyuserid();
            dataInput.machineName = Environment.MachineName.ToString();
            dataInput.doc = txtDocument.Text;

            JArray jArrayItem = new JArray();
            JArray jArrayItemLot = new JArray();
            JArray jArrayItemQty = new JArray();
            JArray jArrayItemKey = new JArray();
            JArray jArrayItemValue = new JArray();

            foreach (DataGridViewRow row in dGV_lbljoin.Rows)
            {
                jArrayItem.Add(itemcode);
                jArrayItemLot.Add(row.Cells[0].Value.ToString());
                jArrayItemQty.Add(row.Cells[1].Value.ToString().Replace(",", string.Empty));
                jArrayItemKey.Add(row.Cells[2].Value.ToString());
                jArrayItemValue.Add(row.Cells[3].Value.ToString());
            }

            dataInput.item = jArrayItem;
            dataInput.lotNumber = jArrayItemLot;
            dataInput.qty = jArrayItemQty;
            dataInput.oldUniqueKey = jArrayItemKey;
            dataInput.itemValue = jArrayItemValue;

            using (HttpClient hc = new HttpClient())
            {
                string values_1 = JsonConvert.SerializeObject(dataInput);
                var valuesRequest = new StringContent(values_1, Encoding.UTF8, "application/json");

                var response = await hc.PostAsync(String.Format(mServerApi + "/label/combine-raw-material"), valuesRequest);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    JObject jobject = JObject.Parse(content);

                    MessageBox.Show(jobject["status"][0]["msg"].ToString());
                    if (jobject["status"][0]["cd"].ToString().Equals("0"))
                    {
                        return;
                    }
                    else
                    {
                        mretitemcd = itemcode;
                        mretqty = (string)jobject["data"][0]["NEWQTY"];
                        mretlot = (string)jobject["data"][0]["NEWLOT"];
                        mretitemnm = (string)jobject["data"][0]["itemName"];
                        mUniqueCode = (string)jobject["data"][0]["SER_ID"];
                        mrackcd = (string)jobject["data"][0]["rackCode"];
                        mitemValue = (string)jobject["data"][0]["NEWVALUE"];

                        printsmtlabel();
                        dGV_lbljoin.Rows.Clear();
                    }

                    MessageBox.Show(jobject["status"][0]["msg"].ToString());
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(content);
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
            datanya.Add("itemCode", mretitemcd.Trim());
            datanya.Add("itemLot", mretlot.Trim());
            datanya.Add("itemKey", mUniqueCode);
            datanya.Add("itemName", mretitemnm.Trim());
            datanya.Add("mretrohs", "1");
            datanya.Add("itemValue", mitemValue);
            PSIprinter.setData(datanya);
            PSIprinter.print(ckrk.GetValue("PRINTER_DEFAULT_BRAND").ToString().ToLower());
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            loadLCRConfig();

            try
            {
                if (!isLCRConnected)
                {
                    comm = new RS_232C_USB();
                    if (comm.OpenInterface(LCRPortName, LCRBaudRate) == false)
                    {
                        return;
                    }
                    btnConnect.Text = "Disconnect";
                    lblPortStatus.Text = string.Format("Connected to {0}", LCRPortName);
                    txtValue.Focus();
                }
                else
                {
                    btnConnect.Text = "Connect";
                    lblPortStatus.Text = "....";
                    comm.CloseInterface();
                }

                isLCRConnected = !isLCRConnected;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FCombineRMLabelPSN_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isLCRConnected)
            {
                comm.CloseInterface();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isLCRConnected && txtValue.Focused)
            {
                //comm.SendQueryMsg("*TRG;:MEASure?", 1000);
                comm.SendQueryMsg(":MEASure?", 1000);
                string receivedMessage = comm.MsgBuf;
                if (receivedMessage.Length > 0)
                {
                    if (!receivedMessage.Substring(0, 1).Equals("-"))
                    {
                        string[] LCRDataArr = receivedMessage.Split(',');

                        double LCRval;
                        if (meas.Equals("PF") || meas.Equals("UF"))
                        {
                            // FOR CAPACITOR
                            LCRval = Convert.ToDouble(LCRDataArr[1]);
                            double measValC = meas.Equals("PF") ? 1E-12 : 1E-06; // initial value                           
                            if (LCRval > 1E-12)
                            {
                                LCRval /= measValC;
                            }
                        }
                        else
                        {
                            // FOR RESISTOR
                            double MeasVal = 0;
                            LCRval = Convert.ToDouble(LCRDataArr[0]);
                            switch (meas)
                            {
                                case "MOHM":
                                    MeasVal = 1E+06;
                                    break;
                                case "KOHM":
                                    MeasVal = 1E+03;
                                    break;
                                case "OHM":
                                    MeasVal = 1;
                                    break;
                            }
                            if (LCRval < 50E+6)
                            {
                                LCRval /= MeasVal;
                            }
                        }

                        dgvLogs.Rows.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), LCRval);
                    }
                }
            }

            if (dgvLogs.Rows.Count > 5)
            {
                txtValue.Text = dgvLogs.Rows[2].Cells[1].Value.ToString();
                txtValue.Focus();
                SendKeys.Send("{ENTER}");
                dgvLogs.Rows.Clear();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel1.Visible = true;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel1.Visible = false;
        }

        private void btnClearLogs_Click(object sender, EventArgs e)
        {
            dgvLogs.Rows.Clear();
        }

        private async void txtDocument_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtDocument.ReadOnly = true;
                using (HttpClient hc = new HttpClient())
                {
                    var response = await hc.GetAsync(String.Format(this.mServerApi + "/supply/validate-document?doc={0}", txtDocument.Text));
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        JObject jobject = JObject.Parse(content);
                        if (jobject["status"][0]["cd"].ToString().Equals("1"))
                        {
                            txt3n1.Focus();
                        }
                        else
                        {
                            txtDocument.ReadOnly = false;
                            MessageBox.Show(jobject["status"][0]["msg"].ToString());
                        }
                    }
                    else
                    {
                        txtDocument.ReadOnly = false;
                        string message = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Please contact admin " + message);
                    }
                }
            }
        }

        private async void txt3n1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (!txtDocument.ReadOnly)
                {
                    MessageBox.Show("Document is required");
                    return;
                }

                if (txt3n1.Text.Trim().Contains("Z3N1"))
                {
                    string[] QRArray = txt3n1.Text.ToUpper().Split('|');

                    int strLength3N1 = 0;
                    strLength3N1 = QRArray[0].Length - 4;


                    string[] _3n2 = QRArray[1].ToUpper().Split(' ');
                    if (itemcode.Length > 1)
                    {
                        if (!itemcode.Equals(QRArray[0].Substring(4, strLength3N1)))
                        {
                            MessageBox.Show("part code is different");
                            return;
                        }
                    }
                    else
                    {
                        itemcode = QRArray[0].Substring(4, strLength3N1);
                    }

                    Dictionary<string, string> dataInput = new Dictionary<string, string>();
                    dataInput.Add("doc", txtDocument.Text);
                    dataInput.Add("item", itemcode);
                    dataInput.Add("lotNumber", _3n2[2]);
                    dataInput.Add("qty", _3n2[1]);
                    dataInput.Add("uniquekey", QRArray[2]);

                    txt3n1.ReadOnly = true;
                    using (HttpClient hc = new HttpClient())
                    {
                        var valuesRequest = new FormUrlEncodedContent(dataInput);
                        var response = await hc.PostAsync(String.Format(mServerApi + "/supply/validate-supplied-item"), valuesRequest);
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            JObject jobject = JObject.Parse(content);

                            if (jobject["status"][0]["cd"].ToString().Equals("0"))
                            {
                                MessageBox.Show(jobject["status"][0]["msg"].ToString());
                                if (dGV_lbljoin.Rows.Count == 0)
                                {
                                    itemcode = string.Empty;
                                }
                                return;
                            }

                            if (jobject["status"][0]["dataMeasurement"]["PRTCD"] != null)
                            {
                                txtMin.Text = jobject["status"][0]["dataMeasurement"]["STDMIN"].ToString();
                                txtMax.Text = jobject["status"][0]["dataMeasurement"]["STDMAX"].ToString();
                                meas = jobject["status"][0]["dataMeasurement"]["MEAS"].ToString();
                            }
                            else
                            {
                                txtMin.Text = string.Empty;
                                txtMax.Text = string.Empty;
                                meas = string.Empty;
                            }

                            _content = jobject;
                            if (validateBefore3N2(_content))
                            {
                                txtValue.Focus();
                            }
                            else
                            {
                                txt3n1.ReadOnly = false;
                            }
                        }
                        else
                        {
                            _content = null;
                            txt3n1.ReadOnly = false;
                        }
                    }
                }
                else
                {
                    if (txt3n1.Text.Length > 3)
                    {
                        if (txt3n1.Text.Substring(0, 3) != "3N1")
                        {
                            MessageBox.Show("Unknown Format C3 Label");
                            txt3n1.Text = "";
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Unknown Format C3 Label.");
                        return;
                    }


                    if (txt3n1.Text.Contains(" "))
                    {

                        string[] an1 = txt3n1.Text.Split(' ');
                        msupqty = an1[1];
                        int strleng = an1[0].Length - 3;

                        //validate previous added item
                        if (itemcode.Length > 1)
                        {
                            if (!itemcode.Equals(an1[0].Substring(3, strleng)))
                            {
                                MessageBox.Show("Part code is different");
                                return;
                            }
                        }
                        else
                        {
                            itemcode = an1[0].Substring(3, strleng);
                        }

                    }
                    else
                    {
                        int strleng = txt3n1.Text.Length - 3;
                        //validate previous added item
                        if (itemcode.Length > 1)
                        {
                            if (!itemcode.Equals(txt3n1.Text.Substring(3, strleng)))
                            {
                                MessageBox.Show("Part code is different...");
                                return;
                            }
                        }
                        else
                        {
                            itemcode = txt3n1.Text.Substring(3, strleng);
                        }

                        msupqty = "";
                    }

                    txt3n1.Text = itemcode;

                    txt3n1.ReadOnly = true;
                    using (HttpClient hc = new HttpClient())
                    {
                        var response = await hc.GetAsync(String.Format(this.mServerApi + "/supply/validate-item?doc={0}&item={1}", txtDocument.Text, itemcode));
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            JObject jobject = JObject.Parse(content);
                            if (jobject["data"][0]["cd"].ToString().Equals("0"))
                            {
                                txt3n1.ReadOnly = false;
                                MessageBox.Show(jobject["data"][0]["msg"].ToString());
                                if (dGV_lbljoin.Rows.Count == 0)
                                {
                                    itemcode = string.Empty;
                                }
                            }
                            else
                            {
                                txt3n2.Focus();
                            }
                        }
                        else
                        {
                            txt3n1.ReadOnly = false;
                            string message = await response.Content.ReadAsStringAsync();
                            MessageBox.Show("Please contact admin " + message);
                        }
                    }
                }
            }
        }

        private async void txt3n2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (!txt3n1.ReadOnly)
                {
                    txt3n1.Focus();
                    return;
                }

                if (txt3n2.Text.Substring(0, 3) != "3N2")
                {
                    MessageBox.Show("Unknown Format C3 Label");
                    return;
                }

                if (!txt3n2.Text.Contains(' '))
                {
                    MessageBox.Show("invalid 3N2 format");
                    return;
                }

                string[] rawValueArray = txt3n2.Text.Split(' ');

                string _qty = "0";
                string _lot = string.Empty;
                if (msupqty.Length == 0)
                {
                    _qty = rawValueArray[1];
                    _lot = rawValueArray[2];
                }
                else
                {
                    _qty = msupqty;
                    _lot = rawValueArray[1];
                }

                Dictionary<string, string> dataInput = new Dictionary<string, string>();
                dataInput.Add("doc", txtDocument.Text);
                dataInput.Add("item", itemcode);
                dataInput.Add("lotNumber", _lot);
                dataInput.Add("qty", _qty);

                using (HttpClient hc = new HttpClient())
                {
                    var valuesRequest = new FormUrlEncodedContent(dataInput);
                    var response = await hc.PostAsync(String.Format(mServerApi + "/supply/validate-supplied-item"), valuesRequest);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        JObject jobject = JObject.Parse(content);

                        if (jobject["status"][0]["cd"].ToString().Equals("0"))
                        {
                            MessageBox.Show(jobject["status"][0]["msg"].ToString());
                            return;
                        }
                        else
                        {
                            if (jobject["status"][0]["dataMeasurement"]["PRTCD"] != null)
                            {
                                txtMin.Text = jobject["status"][0]["dataMeasurement"]["STDMIN"].ToString();
                                txtMax.Text = jobject["status"][0]["dataMeasurement"]["STDMAX"].ToString();
                                meas = jobject["status"][0]["dataMeasurement"]["MEAS"].ToString();
                            }
                            else
                            {
                                txtMin.Text = string.Empty;
                                txtMax.Text = string.Empty;
                                meas = string.Empty;
                            }
                        }

                        _content = jobject;
                        if (validateBefore3N2(_content))
                        {
                            txtValue.Focus();
                        }
                        else
                        {
                            txt3n1.ReadOnly = false;
                        }
                    }
                    else
                    {
                        _content = null;
                    }
                }
            }
        }

        private void txtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (_content != null && txt3n1.ReadOnly)
                {
                    validateAfter3N2(_content);
                }
            }
        }

        private void txtValue_Leave(object sender, EventArgs e)
        {

        }
    }
}
