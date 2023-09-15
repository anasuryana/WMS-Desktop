using IniParser;
using IniParser.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace SMTCSHARP
{
    public partial class FKitting : Form
    {
        string mpsn = "";
        string mcat = "";
        string mline = "";
        string mpath = "";
        public FKitting()
        {
            InitializeComponent();
        }

        delegate void SetTextCallback(string text);
        delegate void SetdgvCallback(IEnumerable<JToken> text);

        private void SetTextinfo(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.txtinfo.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetTextinfo);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                txtinfo.Text = text;
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
                foreach (var rw in text)
                {
                    dGV.Rows.Add(rw["SPLSCN_ID"]
                    , rw["SPLSCN_USRID"]
                    , rw["PPSN2_DATANO"]
                    , mpsn
                    , mcat
                    , rw["SPLSCN_FEDR"]
                    , rw["SPLSCN_ITMCD"]
                    , Convert.ToDouble(rw["SPLSCN_QTY"]).ToString("#,#")
                    , rw["SPLSCN_LUPDT"]
                    , rw["SPLSCN_LOTNO"]
                    , rw["SPLSCN_ORDERNO"]
                    , rw["SPLSCN_LINE"]
                    );
                }
            }
        }

        void initcolumn()
        {
            dGV.ColumnCount = 12;
            dGV.Columns[0].Name = "SPLSCNID";
            dGV.Columns[1].Name = "NIK";
            dGV.Columns[2].Name = "DATANO";
            dGV.Columns[3].Name = "PSN";
            dGV.Columns[3].Width = 70;
            dGV.Columns[4].Name = "CATEGORY";
            dGV.Columns[4].Width = 70;
            dGV.Columns[5].Name = "FR";
            dGV.Columns[5].Width = 35;
            dGV.Columns[6].Name = "ITEMCODE";
            dGV.Columns[7].Name = "QTY";
            dGV.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dGV.Columns[8].Name = "LAST UPDATE";
            dGV.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dGV.Columns[9].Name = "LOT NUMBER";
            dGV.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dGV.Columns[10].Name = "MCZ";
            dGV.Columns[10].Width = 70;
            dGV.Columns[11].Name = "LINE";

            foreach (DataGridViewColumn column in dGV.Columns)
            {
                column.ReadOnly = true;
            }
        }

        void ShowConfig()
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("config.ini");
            txtserver.Text = data["SERVER"]["ADDRESS"];
            txtpath.Text = data["FILES"]["ADDRESS"];
        }

        private void btnshowhidesetting_Click(object sender, EventArgs e)
        {
            panel2.Show();
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
            data["SERVER"]["ADDRESS"] = txtserver.Text;
            data["FILES"]["ADDRESS"] = txtpath.Text;
            parser.WriteFile("config.ini", data);
            panel2.Hide();
        }

        private void FKitting_Load(object sender, EventArgs e)
        {
            ShowConfig();
            initcolumn();
        }

        private void txtcat_DropDown(object sender, EventArgs e)
        {
            txtcat.Items.Clear();
            txtline.Items.Clear();
            txtinfo.Text = "";
            using (WebClient wc = new WebClient())
            {
                try
                {
                    string url = String.Format(txtserver.Text + "/supply/part-category?doc={0}&outstanding={1}", txtpsn.Text, ckOutstaningOnly.Checked ? 1 : 0);

                    var res = wc.DownloadString(url);
                    JObject res_jes = JObject.Parse(res);
                    var rsdata = from p in res_jes["data"] select p;

                    foreach (var rw in rsdata)
                    {
                        txtcat.Items.Add((string)rw["SPL_CAT"]);
                    }
                    if (txtcat.Items.Count == 0)
                    {
                        txtinfo.Text = "Nothing Category";
                    }
                    else
                    {
                        txtinfo.Text = "";
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtline_DropDown(object sender, EventArgs e)
        {
            txtline.Items.Clear();
            txtinfo.Text = "";
            using (WebClient wc = new WebClient())
            {
                try
                {
                    string url = String.Format(txtserver.Text + "/supply/part-line?doc={0}&category={1}", txtpsn.Text, txtcat.Text);
                    var res = wc.DownloadString(url);
                    JObject res_jes = JObject.Parse(res);
                    var rsdata = from p in res_jes["data"] select p;

                    foreach (var rw in rsdata)
                    {
                        txtline.Items.Add((string)rw["SPL_LINE"]);
                    }
                    if (txtline.Items.Count == 0)
                    {
                        txtinfo.Text = "Nothing Category";
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            dGV.Rows.Clear();
            txtinfo.Text = "Please wait...";
            mpsn = txtpsn.Text;
            mcat = txtcat.Text;
            mline = txtline.Text;
            bgworksearch.RunWorkerAsync();
        }

        private void btnexport_csv_Click(object sender, EventArgs e)
        {
            mpath = txtpath.Text + "\\RESULT_" + txtpsn.Text + ".csv";
            txtinfo.Text = "Please wait...exporting...";
            mpsn = txtpsn.Text;
            mcat = txtcat.Text;
            mline = txtline.Text;
            bgworkexport.RunWorkerAsync();

        }

        private void bgworksearch_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            using (WebClient wc = new WebClient())
            {
                string url = String.Format(txtserver.Text + "/supply/outstanding-upload?doc={0}&category={1}&line={2}", mpsn, mcat, mline);
                var res = wc.DownloadString(url);
                JObject res_jes = JObject.Parse(res);
                var rsdata = from p in res_jes["data"] select p;
                SetTextinfo("Done");
                SetDgvinfo(rsdata);
            }
        }

        private void bgworkexport_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (File.Exists(mpath))
            {
                using (WebClient wc = new WebClient())
                {
                    try
                    {
                        string url = String.Format(txtserver.Text + "/supply/outstanding-upload?doc={0}&category={1}&line={2}", mpsn, mcat, mline);
                        var res = wc.DownloadString(url);
                        JObject res_jes = JObject.Parse(res);
                        var rsdata = from p in res_jes["data"] select p;
                        SetTextinfo("Exported successfully, updated");
                        string tosave = "";
                        foreach (var rw in rsdata)
                        {
                            string databaris = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14}",
                                rw["SPLSCN_ID"],
                                rw["SPLSCN_USRID"],
                                "",
                                rw["PPSN2_DATANO"],
                                mpsn,
                                mcat,
                                 rw["SPLSCN_FEDR"],
                                 rw["SPLSCN_ITMCD"],
                                 Convert.ToDouble(rw["SPLSCN_QTY"]).ToString(""),
                                 rw["SPLSCN_LUPDT"],
                                 "OK",
                                 "1",
                                 rw["SPLSCN_LOTNO"],
                                 rw["SPLSCN_ORDERNO"],
                                 rw["SPLSCN_LINE"]
                                );
                            tosave += databaris + "\n";
                        }
                        using (StreamWriter writer = new StreamWriter(mpath))
                        {
                            writer.Write(tosave);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                MessageBox.Show("Updated");
            }
            else
            {
                using (WebClient wc = new WebClient())
                {
                    try
                    {
                        string url = String.Format(txtserver.Text + "/supply/outstanding-upload?doc={0}&category={1}&line={2}", mpsn, mcat, mline);
                        var res = wc.DownloadString(url);
                        JObject res_jes = JObject.Parse(res);
                        var rsdata = from p in res_jes["data"] select p;
                        SetTextinfo("Exported successfully, saved");
                        string tosave = "";
                        foreach (var rw in rsdata)
                        {//
                            string databaris = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14}",
                                rw["SPLSCN_ID"],
                                rw["SPLSCN_USRID"],
                                "",
                                rw["PPSN2_DATANO"],
                                mpsn,
                                mcat,
                                 rw["SPLSCN_FEDR"],
                                 rw["SPLSCN_ITMCD"],
                                 rw["SPLSCN_QTY"],
                                 rw["SPLSCN_LUPDT"],
                                 "OK",
                                 "1",
                                 rw["SPLSCN_LOTNO"],
                                 rw["SPLSCN_ORDERNO"],
                                 rw["SPLSCN_LINE"]
                                );
                            tosave += databaris + "\n";
                        }
                        using (StreamWriter writer = new StreamWriter(mpath))
                        {
                            writer.Write(tosave);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                MessageBox.Show("Saved");
            }
        }

        private void btnFindpsn_Click(object sender, EventArgs e)
        {
            ASettings.setmyflag(ckOutstaningOnly.Checked ? '0' : '1');
            using (var pf = new FP_PSNList())
            {
                var res = pf.ShowDialog();
                if (res == DialogResult.OK)
                {
                    txtpsn.Text = pf.ReturnValue1;
                }
            }

        }
    }
}
