using IniParser;
using IniParser.Model;
using Newtonsoft.Json.Linq;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace SMTCSHARP
{
    public partial class FReturnResume : Form
    {      
        public FReturnResume()
        {
            InitializeComponent();
        }

        delegate void SetTextCallback(string text);

        void ShowConfig()
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("config.ini");
            txtserver.Text = data["SERVER"]["ADDRESS"];
            txtpath.Text = data["FILES"]["ADDRESS_RTN"];
        }

        void initcolumn()
        {
            dGV.ColumnCount = 5;
            dGV.Columns[0].Name = "Date";
            dGV.Columns[0].Width = 100;
            dGV.Columns[1].Name = "Part Request No";
            dGV.Columns[1].Width = 200;
            dGV.Columns[2].Name = "Item Code";
            dGV.Columns[2].Width = 230;            
            dGV.Columns[3].Name = "Qty";
            dGV.Columns[3].Width = 100;
            dGV.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dGV.Columns[4].Name = "Reff Document";
            dGV.Columns[4].Width = 200;

            foreach (DataGridViewColumn column in dGV.Columns)
            {
                column.ReadOnly = true;
            }          
        }

        private void FReturnResume_Load(object sender, EventArgs e)
        {
            initcolumn();
            datepc.Value = DateTime.Now;
            datefr.Value = DateTime.Now;
            ShowConfig();
        }

        private void btnfind_Click(object sender, EventArgs e)
        {
            dGV.Rows.Clear();
            SetTextinfo("Please wait...");
            bgworksearch.RunWorkerAsync();
        }

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
                   
                    dGV.Rows.Add(rw["RETSCN_DATE"].ToString()
                    , rw["RETSCN_SPLDOC"].ToString()
                    , rw["RETSCN_ITMCD"].ToString()
                    , rw["RTNQTY"].ToString().Substring(0, 1) == "." ? "0" : Convert.ToDouble(rw["RTNQTY"]).ToString("#,#")
                    , rw["REFFDOC"].ToString()                    
                    );
                }                
            }

        }

        private void btnshowhidesetting_Click(object sender, EventArgs e)
        {
            panel2.Show();
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

        private void bgworksearch_DoWork(object sender, DoWorkEventArgs e)
        {
            using (WebClient wc = new WebClient())
            {
                try
                {
                    var res = wc.DownloadString(String.Format(txtserver.Text + "/RETPRD/resume_desktop?date1={0}&date2={1}", datefr.Value.ToString("yyyy-MM-dd"), datepc.Value.ToString("yyyy-MM-dd")));
                    JObject res_jes = JObject.Parse(res);
                    string sts = (string)res_jes["status"][0]["cd"];
                    if (UInt16.Parse(sts) > 0)
                    {
                        SetTextinfo("Done");

                        //get detail                       
                        var rsdata = from p in res_jes["data"] select p;
                        //end get detail
                        SetDgvinfo(rsdata);
                    }
                    else
                    {
                        SetTextinfo((string)res_jes["status"][0]["msg"]);
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
                    var res = wc.DownloadString(String.Format(txtserver.Text + "/RETPRD/resume_desktop?date1={0}&date2={1}", datefr.Value.ToString("yyyy-MM-dd"), datepc.Value.ToString("yyyy-MM-dd")));
                    JObject res_jes = JObject.Parse(res);
                    string sts = (string)res_jes["status"][0]["cd"];
                    if (UInt16.Parse(sts) > 0)
                    {
                        SetTextinfo("Done");

                        //get detail                       
                        var rsdata = from p in res_jes["data"] select p;
                        //end get detail
                        using (var fs = new FileStream(txtpath.Text + "\\RESUME RETURN PART REQUEST " + datefr.Value.ToString("dd-MM-yyyy") + " TO "+ datepc.Value.ToString("dd-MM-yyyy") + ".xlsx", FileMode.Create, FileAccess.Write))
                        {
                            IWorkbook workbook = new XSSFWorkbook();
                            ISheet sheet = workbook.CreateSheet("RET-PART_REQUEST");
                            IRow row = sheet.CreateRow(0);
                            int rowx = 0;
                            row = sheet.CreateRow(rowx);
                            row.CreateCell(0).SetCellValue("DATE");
                            row.CreateCell(1).SetCellValue("PART REQUEST NO");
                            row.CreateCell(2).SetCellValue("ITEM CODE");
                            row.CreateCell(3).SetCellValue("RETURN QTY");
                            row.CreateCell(4).SetCellValue("REFF DOCUMENT");
                            rowx = 1;
                            foreach (var rw in rsdata)
                            {
                                row = sheet.CreateRow(rowx);
                                row.CreateCell(0).SetCellValue(rw["RETSCN_DATE"].ToString());
                                row.CreateCell(1).SetCellValue(rw["RETSCN_SPLDOC"].ToString());
                                row.CreateCell(2).SetCellValue(rw["RETSCN_ITMCD"].ToString());
                                row.CreateCell(3).SetCellValue(rw["RTNQTY"].ToString().Substring(0, 1) == "." ? "0" : Convert.ToDouble(rw["RTNQTY"]).ToString("#,#"));
                                row.CreateCell(4).SetCellValue(rw["REFFDOC"].ToString());
                                rowx++;
                            }                 
                            workbook.Write(fs);
                            SetTextinfo("Exported successfully");
                        }
                    }
                    else
                    {
                        SetTextinfo((string)res_jes["status"][0]["msg"]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnexport_Click(object sender, EventArgs e)
        {
            SetTextinfo("Please wait...");
            bgworkexport.RunWorkerAsync();
        }
    }
}
