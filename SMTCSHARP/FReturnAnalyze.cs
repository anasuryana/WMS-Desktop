using IniParser;
using IniParser.Model;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace SMTCSHARP
{
    public partial class FReturnAnalyze : Form
    {
        string mpsn = string.Empty;
        string LCRPortName = string.Empty;
        string LCRBaudRate = string.Empty;
        bool isLCRConnected = false;
        private RS_232C_USB comm;
        string meas = string.Empty;
        bool isScanQR = false;
        string OldUniqueCode = string.Empty;
        string itemCode = string.Empty;
        string itemQty = string.Empty;
        string itemLotno = string.Empty;
        string itemName = string.Empty;
        string msupqty = string.Empty;
        string MsgBuf = string.Empty;
        string mServerApi = string.Empty;
        string mLocalPath = string.Empty;


        public FReturnAnalyze()
        {
            InitializeComponent();

        }
        delegate void SetTextCallback(string text);
        private void SetTextinfo(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.lblinfo.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetTextinfo);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                lblinfo.Text = text;
            }

        }

        private void SetTextinfojob(string text)
        {
            if (this.txtjob.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetTextinfojob);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                txtjob.Text = text;
            }
        }

        private void SetTextinfoReffdoc(string text)
        {
            if (this.txtReffDoc.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetTextinfoReffdoc);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                txtReffDoc.Text = text;
            }
        }

        private void SetTextinfopsn(string text)
        {
            if (this.txtpsn.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetTextinfopsn);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                txtpsn.ReadOnly = true;
            }
        }

        private void SetTextBtnConform(string text)
        {
            if (this.btnconform.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetTextBtnConform);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                btnconform.Enabled = true;
            }
        }

        void initcolumn()
        {
            dGV.ColumnCount = 5;
            dGV.Columns[0].Name = "Item Code";
            dGV.Columns[0].Width = 200;
            dGV.Columns[1].Name = "Item Name";
            dGV.Columns[1].Width = 200;
            dGV.Columns[2].Name = "Logical Return Qty";
            dGV.Columns[2].Width = 230;
            dGV.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dGV.Columns[3].Name = "Actual Return Qty";
            dGV.Columns[3].Width = 230;
            dGV.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dGV.Columns[4].Name = "Discrepancy";
            dGV.Columns[4].Width = 100;
            dGV.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            foreach (DataGridViewColumn column in dGV.Columns)
            {
                column.ReadOnly = true;
            }

            DataGridViewCheckBoxColumn hcb = new DataGridViewCheckBoxColumn();
            hcb.ValueType = typeof(bool);
            hcb.Width = 50;
            dGV.Columns.Add(hcb);


            dgvLogs.ColumnCount = 2;
            dgvLogs.Columns[0].Name = "Time";
            dgvLogs.Columns[0].Width = 200;
            dgvLogs.Columns[1].Name = "Value";


            DGVDetail.ColumnCount = 13;
            DGVDetail.Columns[0].Name = "ID";
            DGVDetail.Columns[1].Name = "PSN No";
            DGVDetail.Columns[2].Name = "Category";
            DGVDetail.Columns[3].Name = "Line";
            DGVDetail.Columns[3].Width = 70;
            DGVDetail.Columns[4].Name = "F/R";
            DGVDetail.Columns[4].Width = 40;
            DGVDetail.Columns[5].Name = "Machine";
            DGVDetail.Columns[6].Name = "Item Code";
            DGVDetail.Columns[7].Name = "Item Name";
            DGVDetail.Columns[8].Name = "Lot No";
            DGVDetail.Columns[9].Name = "Sup. QTY";
            DGVDetail.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGVDetail.Columns[10].Name = "Ret. QTY";
            DGVDetail.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGVDetail.Columns[11].Name = "RoHS";
            DGVDetail.Columns[11].Width = 70;
            DGVDetail.Columns[12].Name = "Value";

            foreach (DataGridViewColumn column in DGVDetail.Columns)
            {
                column.ReadOnly = true;
            }
        }

        void ShowConfig()
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("config.ini");
            mServerApi = data["SERVER"]["ADDRESS"];
            mLocalPath = data["FILES"]["ADDRESS_RTN"];
        }

        private void FReturnAnalyze_Load(object sender, EventArgs e)
        {
            initcolumn();
            ShowConfig();
            datepc.Value = DateTime.Now;
            picStatus.BackColor = Color.Aqua;
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            txtpsn.Text = "";
            txtjob.Text = "";
            txtReffDoc.Text = "";
            txtpsn.ReadOnly = false;
            txtpsn.Focus();
            dGV.Rows.Clear();
            lblinfo.Text = "";
            DGVDetail.Rows.Clear();
        }

        private void SetDgvinfo(IEnumerable<JToken> text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.dGV.InvokeRequired)
            {
                this.dGV.Invoke(new Action(() => SetDgvinfo(text)));
            }
            else
            {
                dGV.Rows.Clear();
                foreach (var rw in text)
                {
                    var mdiff = Convert.ToDouble(rw["TTLRET"]) - Convert.ToDouble(rw["LOGIC"]);
                    dGV.Rows.Add(rw["SPL_ITMCD"]
                    , rw["MITM_SPTNO"].ToString().Trim()
                    , rw["LOGIC"].ToString().Substring(0, 1) == "." ? "0" : Convert.ToDouble(rw["LOGIC"]).ToString("#,#")
                    , rw["TTLRET"].ToString().Substring(0, 1) == "." ? "0" : Convert.ToDouble(rw["TTLRET"]).ToString("#,#")
                    , mdiff.ToString() == "0" ? "0" : Convert.ToDouble(mdiff).ToString("#,#")
                    , false
                    );
                }

                foreach (DataGridViewRow row in dGV.Rows)
                {
                    if (Int16.Parse(row.Cells[4].Value.ToString().Replace(",", "")) < 0)
                    {
                        row.Cells[4].Style.ForeColor = Color.Red;
                    }
                }
            }
        }

        private void btnexport_Click(object sender, EventArgs e)
        {
            if (txtpsn.ReadOnly)
            {
                mpsn = txtpsn.Text;
                SetTextinfo("Please wait...");
                bgworkexport.RunWorkerAsync();
            }
            else
            {
                txtpsn.Focus();
                MessageBox.Show("Please press enter");
            }

        }

        private void bgworksearch_DoWork(object sender, DoWorkEventArgs e)
        {
            using (WebClient wc = new WebClient())
            {
                try
                {
                    var res = wc.DownloadString(String.Format(mServerApi + "/supply/validate-document?doc={0}", mpsn));
                    JObject res_jes = JObject.Parse(res);
                    string sts = (string)res_jes["status"][0]["cd"];
                    if (UInt16.Parse(sts) > 0)
                    {
                        SetTextinfo("Done");
                        var rsdata = from p in res_jes["WorkOrder"] select p;
                        var rsdataReff = from p in res_jes["dataReff"] select p;
                        string joblist = "";
                        foreach (var rw in rsdata)
                        {
                            joblist += rw["PPSN1_WONO"] + ",";
                        }
                        if (joblist.Length != 0)
                        {
                            SetTextinfojob(joblist.Substring(0, joblist.Length - 1));
                        }
                        joblist = "";
                        foreach (var rw in rsdataReff)
                        {
                            joblist += rw["SPL_REFDOCNO"] + ",";
                        }
                        if (joblist.Length != 0)
                        {
                            SetTextinfoReffdoc(joblist.Substring(0, joblist.Length - 1));
                        }

                        SetTextinfopsn("");

                        //get detail
                        res = wc.DownloadString(String.Format(mServerApi + "/return/resume?doc={0}&outstanding={1}", txtpsn.Text, ckOutstaningOnly.Checked ? '0' : '1'));
                        res_jes = JObject.Parse(res);
                        rsdata = from p in res_jes["data"] select p;
                        //end get detail
                        SetDgvinfo(rsdata);

                        //get detail per unique
                        res = wc.DownloadString(String.Format(mServerApi + "/return/counted?doc={0}", txtpsn.Text));
                        res_jes = JObject.Parse(res);
                        rsdata = from p in res_jes["data"] select p;
                        this.DGVDetail.Invoke((MethodInvoker)delegate
                        {
                            DGVDetail.Rows.Clear();
                            List<DataGridViewRow> rows = new List<DataGridViewRow>();
                            foreach (var rw in rsdata)
                            {
                                DataGridViewRow row = new DataGridViewRow();
                                row.CreateCells(DGVDetail);
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
                                row.Cells[12].Value = rw["item_value"];
                                rows.Add(row);
                            }

                            DGVDetail.Rows.AddRange(rows.ToArray());
                        });
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

        private void bgworkexport_DoWork(object sender, DoWorkEventArgs e)
        {
            using (WebClient wc = new WebClient())
            {
                try
                {
                    var res = wc.DownloadString(String.Format(mServerApi + "/supply/validate-document?doc={0}", mpsn));
                    JObject res_jes = JObject.Parse(res);
                    string sts = (string)res_jes["status"][0]["cd"];
                    if (UInt16.Parse(sts) > 0)
                    {

                        var rsdata = from p in res_jes["WorkOrder"] select p;
                        string joblist = "";
                        foreach (var rw in rsdata)
                        {
                            joblist += rw["PPSN1_WONO"] + ",";
                        }

                        SetTextinfojob(joblist.Substring(0, joblist.Length - 1));

                        //get detail
                        res = wc.DownloadString(String.Format(mServerApi + "/return/resume?doc={0}&output=spreadsheet", txtpsn.Text));
                        res_jes = JObject.Parse(res);
                        rsdata = from p in res_jes["data"] select p;
                        //end get detail
                        using (var fs = new FileStream(mLocalPath + "\\" + mpsn + ".xlsx", FileMode.Create, FileAccess.Write))
                        {
                            IWorkbook workbook = new XSSFWorkbook();
                            ISheet sheet = workbook.CreateSheet("RET-PSN");
                            IRow row = sheet.CreateRow(0);
                            int rowx = 0;
                            row = sheet.CreateRow(rowx);
                            row.CreateCell(0).SetCellValue("ITEMCODE");
                            row.CreateCell(1).SetCellValue("GRN QTY");
                            rowx = 1;
                            foreach (var rw in rsdata)
                            {
                                row = sheet.CreateRow(rowx);
                                row.CreateCell(0).SetCellValue(rw["RETSCN_ITMCD"].ToString());
                                row.CreateCell(1).SetCellValue(rw["RETQTY"].ToString());
                                rowx++;
                            }
                            workbook.Write(fs);
                            SetTextinfo("Exported successfully");
                        }
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

        private void btnconform_Click(object sender, EventArgs e)
        {
            if (txtpsn.ReadOnly)
            {

                if (MessageBox.Show("Are You sure ? ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    SetTextinfo("Please wait...");
                    btnconform.Enabled = false;
                    bgworkconform.RunWorkerAsync();
                }
            }
        }

        private void bgworkconform_DoWork(object sender, DoWorkEventArgs e)
        {
            using (WebClient wc = new WebClient())
            {
                try
                {
                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    int ke = 1;
                    string datas = "";
                    foreach (DataGridViewRow row in dGV.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[5].Value))
                        {
                            datas += "item[]=" + row.Cells[0].Value.ToString() + "&";
                            ke++;
                        }
                    }

                    string url = mServerApi + "/return/confirm";
                    string myparam = String.Format("doc={0}&{1}dateConfirm={2}&userId={3}", txtpsn.Text, datas, datepc.Value.ToString("yyyy-MM-dd"), ASettings.getmyuserid());
                    string res = wc.UploadString(url, myparam);
                    JObject res_jes = JObject.Parse(res);
                    string sts = (string)res_jes["message"];
                    SetTextinfo(sts);
                    SetTextBtnConform("");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnFindpsn_Click(object sender, EventArgs e)
        {
            ASettings.setmyflag(ckOutstaningOnly.Checked ? '0' : '1');
            ASettings.setmyContext('r');
            using (var pf = new FP_PSNList())
            {
                var res = pf.ShowDialog();
                if (res == DialogResult.OK)
                {
                    txtpsn.Text = pf.ReturnValue1;

                    mpsn = txtpsn.Text;
                    SetTextinfo("Please wait...");
                    bgworksearch.RunWorkerAsync();

                }
            }
        }

        private void ckOutstaningOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (txtpsn.Text.Length > 0)
            {
                SetTextinfo("Please wait...");
                bgworksearch.RunWorkerAsync();
            }
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

        private void btnConnect_Click(object sender, EventArgs e)
        {
            loadLCRConfig();
            try
            {
                if (!isLCRConnected)
                {
                    serialPort1.BaudRate = Convert.ToInt16(LCRBaudRate);
                    serialPort1.PortName = LCRPortName;
                    serialPort1.NewLine = Environment.NewLine;
                    serialPort1.Handshake = Handshake.None;
                    serialPort1.Open();
                    btnConnect.Text = "Disconnect";
                    lblPortStatus.Text = string.Format("Connected to {0}", LCRPortName);
                    txtValue.Focus();

                    dgvLogs.Rows.Clear();
                    picStatus.BackColor = Color.Aqua;
                    tabPage2.BackColor = Color.White;
                }
                else
                {
                    btnConnect.Text = "Connect";
                    lblPortStatus.Text = "....";
                    serialPort1.Close();
                }
                isLCRConnected = !isLCRConnected;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void sendData(string message)
        {
            try
            {
                message += Environment.NewLine;
                serialPort1.WriteLine(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isLCRConnected && txtLabelID.ReadOnly)
            {
                try
                {
                    sendData("*TRG;:MEASure?");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (serialPort1.BytesToRead > 0 && txtLabelID.ReadOnly && meas.Length >= 1)
            {
                string rcv = string.Empty;
                StringBuilder buf = new StringBuilder();
                rcv = serialPort1.ReadExisting();                                // Read data from the receive buffer
                rcv = rcv.Replace("\r", "");                                    // Delete CR in received data
                if (rcv.IndexOf("\n") >= 0)                                     // End the loop when LF is received
                {
                    rcv = rcv.Substring(0, rcv.IndexOf("\n"));                  // Extract data without LF and the following from the original received data
                    buf.Append(rcv);                                            // Save the data
                    MsgBuf = buf.ToString();

                    if (meas.Equals("PF") || meas.Equals("UF"))
                    {
                        measureCapacitor(MsgBuf);
                    }
                    else
                    {
                        measureResistor(MsgBuf);
                    }

                    MsgBuf = string.Empty;
                }
                else
                {
                    buf.Append(rcv);                                            // Save the data                    
                }
            }
        }

        private void txtLabelID_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                picStatus.BackColor = Color.Aqua;
                tabPage2.BackColor = Color.White;
                if (txtLabelID.Text.Contains("|"))
                {
                    isScanQR = true;
                    // parse qr code
                    string[] QRArray = txtLabelID.Text.ToUpper().Split('|');

                    int strLength3N1 = 0;
                    switch (QRArray[0].Substring(0, 2).ToString())
                    {
                        case "Z3":
                            strLength3N1 = QRArray[0].Length - 4;
                            itemCode = QRArray[0].Substring(4, strLength3N1);
                            break;
                        case "3N":
                            strLength3N1 = QRArray[0].Length - 3;
                            itemCode = QRArray[0].Substring(3, strLength3N1);
                            break;
                        default:
                            itemCode = QRArray[0];
                            break;
                    }

                    string[] Array3N2;

                    OldUniqueCode = QRArray[2];

                    Array3N2 = QRArray[1].Split(' ');
                    switch (QRArray[1].Substring(0, 3).ToString())
                    {
                        case "3N2":
                            if (Array3N2[1].All(char.IsNumber))
                            {
                                itemQty = Array3N2[1];
                                itemLotno = Array3N2[2];
                            }
                            break;

                        default:
                            if (Array3N2[0].All(char.IsNumber))
                            {
                                itemLotno = Array3N2[1];
                            }
                            break;
                    }

                }
                else
                {
                    int[] relevantLength = { 16, 17 };
                    string id = txtLabelID.Text.Trim();
                    if (relevantLength.Contains(id.Length))
                    {
                        getFullQRById(id);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Invalid Input, Only QR content or UC is acceptable");
                        txtLabelID.Text = "";
                        return;
                    }
                }

                using (WebClient wc = new WebClient())
                {
                    try
                    {
                        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(itemCode);
                        string url = String.Format(mServerApi + "/item/{0}/location", Convert.ToBase64String(plainTextBytes));
                        var res = wc.DownloadString(url);

                        JObject res_jes = JObject.Parse(res);
                        string sts = (string)res_jes["status"][0]["cd"];
                        if (sts.Equals("0"))
                        {
                            MessageBox.Show((string)res_jes["status"][0]["msg"]);
                            txtLabelID.Text = "";
                        }
                        else
                        {
                            txtLabelID.ReadOnly = true;

                            itemName = (string)res_jes["data"][0]["SPTNO"];
                            txtMin.Text = (string)res_jes["data"][0]["STDMIN"];
                            txtMax.Text = (string)res_jes["data"][0]["STDMAX"];
                            lblMeasure.Text = (string)res_jes["data"][0]["MEAS"];
                            meas = (string)res_jes["data"][0]["MEAS"];
                            lblItemDescription.Text = (string)res_jes["data"][0]["ITMD1"];

                            if (isScanQR)
                            {
                                txtValue.Focus();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private async void getFullQRById(string uniqueCode)
        {
            using (HttpClient hc = new HttpClient())
            {
                var response = await hc.GetAsync(String.Format(this.mServerApi + "/label/c3?id={0}", uniqueCode));
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    JObject jobject = JObject.Parse(content);
                    if (jobject["data"].Any(x => x.Type != JTokenType.Null))
                    {
                        txtLabelID.Text = string.Format("Z3N1{0}|3N2 {1} {2}|{3}",
                            jobject["data"]["item_code"].ToString(),
                            Convert.ToDouble(jobject["data"]["quantity"].ToString()).ToString(),
                            jobject["data"]["lot_code"].ToString(),
                            jobject["data"]["code"].ToString()
                            );
                        SendKeys.Send("{ENTER}");
                    }
                    else
                    {
                        MessageBox.Show("Unique Code is not found");
                    }
                }
                else
                {
                    MessageBox.Show("failed to contact server API");
                }
            }
        }

        private void btnNewCheck_Click(object sender, EventArgs e)
        {
            newProcess();
        }

        private void newProcess()
        {
            txtLabelID.Text = "";
            txtMin.Text = "";
            txtMax.Text = "";
            txtValue.Text = "";
            lblMeasure.Text = "";
            meas = string.Empty;
            txtLabelID.Focus();
            txtLabelID.ReadOnly = false;
            dgvLogs.Rows.Clear();
            lblItemDescription.Text = "";
            picStatus.BackColor = Color.Aqua;
            tabPage2.BackColor = Color.White;
        }

        private void measureResistor(string readValue)
        {
            string[] LCRDataArr = readValue.Split(',');
            double LCRval;

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
            if (LCRval < 50E+6 & LCRval >= 0)
            {
                LCRval /= MeasVal;

                this.dgvLogs.Invoke((MethodInvoker)delegate
                {
                    dgvLogs.Rows.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), LCRval);
                });

                getAverage();
            }
        }

        private void measureCapacitor(string readValue)
        {
            string[] LCRDataArr = readValue.Split(',');
            double LCRval;

            LCRval = Convert.ToDouble(LCRDataArr[1]);
            double measValC = meas.Equals("PF") ? 1E-12 : 1E-06; // initial value                           
            if (LCRval > 1E-12)
            {
                LCRval /= measValC;

                dgvLogs.Invoke((MethodInvoker)delegate
                {
                    dgvLogs.Rows.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), LCRval);
                });

                getAverage();
            }
        }

        private void getAverage()
        {
            if (dgvLogs.Rows.Count > 5)
            {
                string[] Arr1 = { dgvLogs.Rows[0].Cells[1].Value.ToString(),
                                  dgvLogs.Rows[1].Cells[1].Value.ToString(),
                                  dgvLogs.Rows[2].Cells[1].Value.ToString(),
                                  dgvLogs.Rows[3].Cells[1].Value.ToString(),
                                  dgvLogs.Rows[4].Cells[1].Value.ToString() };
                Array.Sort(Arr1);

                this.txtValue.Invoke((MethodInvoker)delegate
                {
                    txtValue.Text = Arr1[2];
                });

                this.dgvLogs.Invoke((MethodInvoker)delegate
                {
                    this.dgvLogs.Rows.Clear();
                });

                var labelIDToUpdate = txtLabelID.Text.Split('|')[2];

                this.txtLabelID.Invoke((MethodInvoker)delegate
                {
                    txtLabelID.Text = string.Empty;
                    txtLabelID.ReadOnly = false;
                    txtLabelID.Focus();
                });

                Double StdMin = Convert.ToDouble(txtMin.Text);
                Double StdMax = Convert.ToDouble(txtMax.Text);
                Double ValCal = Convert.ToDouble(txtValue.Text);

                if (ValCal >= StdMin && ValCal <= StdMax)
                {
                    picStatus.BackColor = Color.Green;
                    tabPage2.BackColor = Color.Green;
                    updateValueInDB(labelIDToUpdate, ValCal.ToString(), 'O');
                }
                else
                {
                    updateValueInDB(labelIDToUpdate, ValCal.ToString(), 'N');
                    picStatus.BackColor = Color.Red;
                    tabPage2.BackColor = Color.Red;
                }
            }
        }

        private async void updateValueInDB(string code, string codeValue, char measurementStatus)
        {
            using (HttpClient hc = new HttpClient())
            {
                dynamic dataInput = new JObject();
                dataInput.userId = ASettings.getmyuserid();
                dataInput.code = code;
                dataInput.itemValue = codeValue;
                dataInput.measurementStatus = measurementStatus.ToString();

                string values_1 = JsonConvert.SerializeObject(dataInput);
                var valuesRequest = new StringContent(values_1, Encoding.UTF8, "application/json");

                var response = await hc.PutAsync(String.Format(this.mServerApi + "/label"), valuesRequest);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    MessageBox.Show("failed to contact server API");
                    return;
                }
            }
        }

        private void txtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                string valValue = txtValue.Text.Trim();
                if (meas.Length == 0 && valValue.Length > 0)
                {
                    string labelIDToUpdate = txtLabelID.Text.Split('|')[2];
                    updateValueInDB(labelIDToUpdate, valValue, 'T');
                    txtValue.Text = string.Empty;
                    txtLabelID.Text = string.Empty;
                    txtLabelID.ReadOnly = false;
                    txtLabelID.Focus();
                    lblItemDescription.Text = string.Empty; 
                }
            }
        }

        private void txtpsn_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                mpsn = txtpsn.Text;
                SetTextinfo("Please wait...");
                bgworksearch.RunWorkerAsync();
            }
        }

        private void ckall_CheckedChanged_1(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dGV.Rows)
            {
                row.Cells[5].Value = ckall.Checked;
            }
        }

        private void FReturnAnalyze_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isLCRConnected)
            {
                serialPort1.Close();
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            FP_ReportValueChecking fmitem = new FP_ReportValueChecking();
            fmitem.ShowDialog();
        }
    }
}
