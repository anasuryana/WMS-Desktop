using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;
using IniParser;
using IniParser.Model;
using NPOI.SS.UserModel;
using System.IO;
using NPOI.XSSF.UserModel;

namespace SMTCSHARP
{
    public partial class FReturnAnalyze : Form
    {
        string mpsn = "";
        string mwarehouse = "";

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
        }

        void ShowConfig()
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("config.ini");
            txtserver.Text = data["SERVER"]["ADDRESS"];
            txtpath.Text = data["FILES"]["ADDRESS_RTN"];
        }

        private void FReturnAnalyze_Load(object sender, EventArgs e)
        {
            initcolumn();
            ShowConfig();
            datepc.Value = DateTime.Now;
        }

        private void btnbrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            txtpath.Text = folderBrowserDialog1.SelectedPath;
        }

        private void btnsave_config_Click(object sender, EventArgs e)
        {

            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("config.ini");
            data["FILES"]["ADDRESS_RTN"] = txtpath.Text;
            data["SERVER"]["ADDRESS"] = txtserver.Text;
            parser.WriteFile("config.ini", data);
            panel2.Hide();
        }

        private void btnshowhidesetting_Click(object sender, EventArgs e)
        {
            panel2.Show();
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

        private void txtpsn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                mpsn = txtpsn.Text;
                SetTextinfo("Please wait...");
                bgworksearch.RunWorkerAsync();
            }
        }

        private void ckall_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dGV.Rows)
            {
                row.Cells[5].Value = ckall.Checked;
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
                    var res = wc.DownloadString(String.Format(txtserver.Text + "/SPL/checkPSN_only?inpsn={0}", mpsn));
                    JObject res_jes = JObject.Parse(res);
                    string sts = (string)res_jes["status"][0]["cd"];
                    if (UInt16.Parse(sts) > 0)
                    {
                        SetTextinfo("Done");
                        var rsdata = from p in res_jes["datahead"] select p;
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
                        res = wc.DownloadString(String.Format(txtserver.Text + "/RETPRD/getlistrecap_psnonly?inpsn={0}", txtpsn.Text));
                        res_jes = JObject.Parse(res);
                        rsdata = from p in res_jes["data"] select p;
                        //end get detail
                        SetDgvinfo(rsdata);
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
                    var res = wc.DownloadString(String.Format(txtserver.Text + "/SPL/checkPSN_only?inpsn={0}", mpsn));
                    JObject res_jes = JObject.Parse(res);
                    string sts = (string)res_jes["status"][0]["cd"];
                    if (UInt16.Parse(sts) > 0)
                    {

                        var rsdata = from p in res_jes["datahead"] select p;
                        string joblist = "";
                        foreach (var rw in rsdata)
                        {
                            joblist += rw["PPSN1_WONO"] + ",";
                        }

                        SetTextinfojob(joblist.Substring(0, joblist.Length - 1));

                        //get detail
                        res = wc.DownloadString(String.Format(txtserver.Text + "/RETPRD/export_to_xls_desktop?inpsn={0}", txtpsn.Text));
                        res_jes = JObject.Parse(res);
                        rsdata = from p in res_jes["data"] select p;
                        //end get detail
                        using (var fs = new FileStream(txtpath.Text + "\\" + mpsn + ".xlsx", FileMode.Create, FileAccess.Write))
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
                            datas += "initemcd[]=" + row.Cells[0].Value.ToString() + "&";
                            ke++;
                        }
                    }

                    string url = txtserver.Text + "/RETPRD/editing_byitempsn_desktop";
                    string myparam = String.Format("inpsn={0}&{1}indate={2}&inuser={3}&inwh={4}", txtpsn.Text, datas, datepc.Value.ToString("yyyy-MM-dd"), ASettings.getmyuserid(), mwarehouse);
                    string res = wc.UploadString(url, myparam);
                    SetTextinfo(res);
                    SetTextBtnConform("");
                    //MessageBox.Show(res);


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
