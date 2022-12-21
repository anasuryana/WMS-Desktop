using com.citizen.sdk.LabelPrint;
using IniParser;
using IniParser.Model;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;

namespace SMTCSHARP
{
    public partial class FReturnWithoutPSN : Form
    {
        string msupqty = "";
        string mretitemcd = "";
        string mrackcd = "";
        string mretqty = "";
        string mretlot = "";
        string mretitemnm = "";
        string mserverAddress = "";

        public FReturnWithoutPSN()
        {
            InitializeComponent();
        }

        private void btnsetting_Click(object sender, EventArgs e)
        {
            FSettings frm = new FSettings();
            frm.ShowDialog();

        }

        void initcolumn()
        {
            dGV.ColumnCount = 10;            
            dGV.Columns[0].Name = "ID";
            dGV.Columns[1].Name = "Line";
            dGV.Columns[1].Width = 45;
            dGV.Columns[2].Name = "Item Code";
            dGV.Columns[2].Width = 120;
            dGV.Columns[3].Name = "Description";
            dGV.Columns[3].Width = 150;
            dGV.Columns[4].Name = "Item Name";
            dGV.Columns[5].Name = "Lot No";
            dGV.Columns[6].Name = "Old QTY";
            dGV.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dGV.Columns[7].Name = "New QTY";
            dGV.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dGV.Columns[8].Name = "Rack";
            dGV.Columns[9].Name = "Date";

            foreach (DataGridViewColumn column in dGV.Columns)
            {
                column.ReadOnly = true;
            }

            DataGridViewCheckBoxColumn hcb = new DataGridViewCheckBoxColumn();
            hcb.ValueType = typeof(bool);
            hcb.Width = 50;
            hcb.ToolTipText = "Print Flag";
            dGV.Columns.Add(hcb);

            DataGridViewButtonColumn hbt = new DataGridViewButtonColumn();
            hbt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            hbt.Width = 100;
            dGV.Columns.Add(hbt);
        }

        private void FReturnWithoutPSN_Load(object sender, EventArgs e)
        {
            initcolumn();
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("config.ini");
            mserverAddress = data["SERVER"]["ADDRESS"];

            var cmbsourc = new Dictionary<string, string>();           
            cmbsourc.Add("PLANT1", "PLANT1");
            cmbsourc.Add("PLANT2", "PLANT2");
            cmbsourc.Add("PLANT_NA", "PLANT_NA");

            cmbLoc.DataSource = new BindingSource(cmbsourc, null);
            cmbLoc.DisplayMember = "Value";
            cmbLoc.ValueMember = "Key";
            ret_e_getlist();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txt3N1.Text = "";
            txt3N1.Focus();
            txt3N2.Text = "";
            txtitemname.Text = "";
            txtLotNum.Text = "";
            txtActualQty.Text = "";
        }

        private void txt3N1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {                

                if (txt3N1.Text == "")
                {
                    MessageBox.Show("Please fill Item Code");
                    return;
                }

                if (txt3N1.Text.Length <= 3)
                {
                    MessageBox.Show("Unknown Format C3 Label");
                    txt3N1.Text = "";
                    return;
                }

                if (txt3N1.Text.Substring(0, 3) != "3N1")
                {
                    MessageBox.Show("Unknown Format C3 Label");
                    txt3N1.Text = "";
                    txtitemname.Text = "";
                    return;
                }

                if (txt3N1.Text.Contains(" "))
                {
                    string[] an1 = txt3N1.Text.Split(' ');
                    msupqty = an1[1];
                    int strleng = an1[0].Length - 3;
                    txt3N1.Text = an1[0].Substring(3, strleng);
                }
                else
                {
                    int strleng = txt3N1.Text.Length - 3;
                    txt3N1.Text = txt3N1.Text.Substring(3, strleng);
                    msupqty = "";
                }

                using (WebClient wc = new WebClient())
                {
                    try
                    {
                        string url = String.Format(mserverAddress + "/ITMLOC/check_item_WithoutPSN?itemcd={0}", txt3N1.Text);
                        var res = wc.DownloadString(url);
                        Console.WriteLine(res);
                        JObject res_jes = JObject.Parse(res);
                        string sts = (string)res_jes["status"][0]["cd"];
                        if (sts.Equals("0"))
                        {
                            MessageBox.Show((string)res_jes["status"][0]["msg"]);
                            txt3N1.Text = "";                            
                        }
                        else
                        {
                            txt3N2.Focus();
                            txt3N2.ReadOnly = false;
                            txtitemname.Text = (string)res_jes["data"][0]["ITMD1"];
                            mrackcd = (string)res_jes["data"][0]["ITMLOC_LOC"];
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            txt3N1.Focus();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            string loca = "";
            loca = cmbLoc.SelectedValue.ToString();
            using (WebClient wc = new WebClient())
            {
                try
                {
                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    string url = mserverAddress + "/RETPRD/rtn_without_psn";
                    string myparam = String.Format("itmcd={0}&oldqty={1}&newqty={2}&lotnum={3}&usrid={4}", txt3N1.Text,txt3N2.Text,txtActualQty.Text,txtLotNum.Text, ASettings.getmyuserid());
                    myparam = myparam.Replace("+", "%2B");
                    string res = wc.UploadString(url, myparam);
                    JObject res_jes = JObject.Parse(res);
                    string sts = (string)res_jes["status"][0]["cd"];
                    string msg = (string)res_jes["status"][0]["msg"];                    
                    MessageBox.Show(msg);
                    if (sts.Equals("1"))
                    {
                        mretitemcd = txt3N1.Text.Trim();
                        mretqty = txtActualQty.Text.Trim();
                        mretlot = txtLotNum.Text.Trim().Length > 12 ? txtLotNum.Text.Trim().Substring(0, 12) : txtLotNum.Text.Trim();
                        mretitemnm = txtitemname.Text.Trim();                            
                        printsmtlabel();
                    }
                    ret_e_getlist();
                    txt3N2.Text = "";
                    txtitemname.Text = "";
                    txt3N1.Text = "";
                    txtLotNum.Text = "";
                    txt3N2.ReadOnly = false;
                    txt3N2.Text = "";
                    txtActualQty.Text = "";
                    txt3N1.Focus();
            }
                catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txt3N2.ReadOnly = false;
            }
        }
        }

        void ret_e_getlist()
        {
            using (WebClient wc = new WebClient())
            {
                string txtdt1 = dt1.Value.ToString("yyyy-MM-dd");
                string txtdt2 = dt2.Value.ToString("yyyy-MM-dd");
                string txtitemcd = txtSearchItemcd.Text;
                string url = String.Format(mserverAddress + "/RETPRD/rtn_without_psn_list_period?date1={0}&date2={1}&itemcd={2}&business={3}", txtdt1, txtdt2, txtitemcd, ASettings.getmyBusinessGroup()).ToString();
                try
                {                    
                    var res = wc.DownloadString(url);
                    JObject res_jes = JObject.Parse(res);
                    var rsdata = from p in res_jes["data"] select p;
                    dGV.Rows.Clear();
                    List<DataGridViewRow> rows = new List<DataGridViewRow>();
                    foreach (var rw in rsdata)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(dGV);
                        row.Cells[0].Value = rw["RETRM_DOC"];
                        row.Cells[1].Value = rw["RETRM_LINE"];
                        row.Cells[2].Value = rw["RETRM_ITMCD"];
                        row.Cells[3].Value = rw["ITMD1"];
                        row.Cells[4].Value = rw["SPTNO"];
                        row.Cells[5].Value = rw["RETRM_LOTNUM"];
                        row.Cells[6].Value = Convert.ToDouble(rw["RETRM_OLDQTY"]).ToString("#,#");
                        row.Cells[7].Value = Convert.ToDouble(rw["RETRM_NEWQTY"]).ToString("#,#");
                        row.Cells[8].Value = rw["ITMLOC_LOC"];
                        row.Cells[9].Value = rw["RETRM_CREATEDAT"];
                        row.Cells[10].Value = false;
                        row.Cells[11].Value = "Cancel";
                        rows.Add(row);
                    }
                    dGV.Rows.AddRange(rows.ToArray());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
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
                //return;
            }
            else
            {
                //MessageBox.Show("terhubung");
            }
            LabelDesign lbldsg = new LabelDesign();
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;
            dtfi.DateSeparator = "/";
            int startx = 35;
            int mhratio = 105; //105, 75
            int mvratio = 110; //150,75

            lbldsg.DrawTextPCFont(String.Format("RACK : {0}    {1}", mrackcd, Environment.MachineName.ToString()), "Times New Roman", LabelConst.CLS_RT_NORMAL, mhratio, mvratio, 7, (LabelConst.CLS_FNT_DEFAULT), startx, 410 + 20);
            lbldsg.DrawTextPCFont(String.Format("QTY : {0}    LOT NO : {1}", mretqty, mretlot), "Times New Roman", LabelConst.CLS_RT_NORMAL, mhratio, mvratio, 7, (LabelConst.CLS_FNT_DEFAULT), startx, 385 + 10);
            lbldsg.DrawTextPCFont(String.Format("(3N1) {0}", mretitemcd), "Times New Roman", LabelConst.CLS_RT_NORMAL, mhratio, mvratio, 7, (LabelConst.CLS_FNT_DEFAULT), startx, 360);
            lbldsg.DrawBarCode(String.Format("3N1{0}", mretitemcd.Trim()), LabelConst.CLS_BCS_CODE128, LabelConst.CLS_RT_NORMAL, myTHICKNESS, myNARROW, 55, startx, 300, LabelConst.CLS_BCS_TEXT_HIDE);
            lbldsg.DrawTextPCFont(String.Format("(3N2) {0} {1}", mretqty, mretlot.Trim()), "Times New Roman", LabelConst.CLS_RT_NORMAL, mhratio, mvratio, 7, (LabelConst.CLS_FNT_DEFAULT), startx, 255);
            lbldsg.DrawBarCode(String.Format("3N2 {0} {1} ", mretqty.Replace(",", string.Empty), mretlot.Trim()), LabelConst.CLS_BCS_CODE128, LabelConst.CLS_RT_NORMAL, myTHICKNESS, myNARROW, 55, startx, 200, LabelConst.CLS_BCS_TEXT_HIDE);
            lbldsg.DrawTextPCFont(String.Format("(1P) {0}", mretitemnm), "Times New Roman", LabelConst.CLS_RT_NORMAL, mhratio, mvratio, 7, (LabelConst.CLS_FNT_DEFAULT), startx, 155 + 5);
            lbldsg.DrawBarCode(String.Format("1P{0}", mretitemnm.Trim()), LabelConst.CLS_BCS_CODE128, LabelConst.CLS_RT_NORMAL, myTHICKNESS, myNARROW, 55, startx, 100 + 5, LabelConst.CLS_BCS_TEXT_HIDE);
            lbldsg.DrawTextPCFont(String.Format("PART NO : {0}", mretitemnm.Trim()), "Times New Roman", LabelConst.CLS_RT_NORMAL, (mhratio - 5), (mvratio - 5), 7, (LabelConst.CLS_FNT_DEFAULT), startx, 70);

            
            lbldsg.DrawTextPCFont("C/O Made in SMT", "Times New Roman", LabelConst.CLS_RT_NORMAL, (mhratio - 5), (mvratio - 5), 7, (LabelConst.CLS_FNT_DEFAULT), 310, 45);
            lbldsg.DrawTextPCFont(String.Format("{0} : {1}", ASettings.getmyuserid(), ASettings.getmyuserfname()), "Times New Roman", LabelConst.CLS_RT_NORMAL, (mhratio - 5), (mvratio - 5), 7, (LabelConst.CLS_FNT_DEFAULT), startx, 20);
            lbldsg.DrawTextPCFont(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", dtfi), "Times New Roman", LabelConst.CLS_RT_NORMAL, (mhratio - 5), (mvratio - 5), 7, (LabelConst.CLS_FNT_DEFAULT), 310, 20);

            //int result = lblprn.Connect(LabelConst.CLS_PORT_USB, "");
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
            //                        
        }


        private void txt3N2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (txt3N2.Text.Length <= 3)
                {
                    MessageBox.Show("Unknown Format C3 Label");
                    txt3N2.Text = "";
                    return;
                }

                if (txt3N2.Text.Substring(0, 3) != "3N2")
                {
                    MessageBox.Show("Unknown Format C3 Label lot");
                    txt3N2.Text = "";
                    return;
                }
                else
                {
                    string[] mthis_ar = txt3N2.Text.Split(' ');
                    if (msupqty != "")
                    {
                        txt3N2.Text = msupqty;

                        txt3N2.ReadOnly = true;
                        txtLotNum.Text = mthis_ar[1];
                    }
                    else
                    {
                        if (mthis_ar[1].All(char.IsNumber))
                        {
                            txt3N2.Text = mthis_ar[1];
                            txtLotNum.Text = mthis_ar[2];
                            txt3N2.ReadOnly = true;
                        }
                    }
                    txtActualQty.Focus();
                }
            }
        }

        private void txtActualQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (txtActualQty.Text == "")
                {
                    txtActualQty.Focus();
                    MessageBox.Show("Please fill Actual Qty");
                    return;
                }
                if (UInt32.Parse(txtActualQty.Text) > UInt32.Parse(txt3N2.Text))
                {
                    MessageBox.Show("Qty After > Qty Before");
                    txtActualQty.Focus();
                    txtActualQty.Select();                    
                    return;
                }
                btnsave.Focus();
            }
        }

        private void btnreturnprint_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dGV.Rows)
            {

                if (Convert.ToBoolean(row.Cells[9].Value))
                {
                    mretitemcd = row.Cells[2].Value.ToString().Trim();
                    mretqty = row.Cells[7].Value.ToString().Trim();
                    mretlot = row.Cells[5].Value.ToString().Trim();
                    mretitemnm = row.Cells[4].Value.ToString().Trim();
                    mrackcd = row.Cells[8].Value.ToString().Trim();
                    printsmtlabel();
                }
            }
        }

        private void dGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string idscan = dGV.Rows[dGV.CurrentCell.RowIndex].Cells[0].Value.ToString();
            string itemcd = dGV.Rows[dGV.CurrentCell.RowIndex].Cells[2].Value.ToString();
            switch (dGV.CurrentCell.ColumnIndex)
            {                                    
                case 10:
                    switch (dGV.CurrentCell.Value.ToString())
                    {
                        case "Cancel":
                            if (MessageBox.Show("Are You sure ? " + idscan, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            {
                                using (WebClient wc = new WebClient())
                                {
                                    string url = String.Format(mserverAddress+ "/RETPRD/cancel_rtn_without_psn");
                                    string myparam = String.Format("inid={0}&itemcd={1}", idscan, itemcd);
                                    try
                                    {
                                        wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                                        var res = wc.UploadString(url, myparam);
                                        JObject res_jes = JObject.Parse(res);
                                        string sts = (string)res_jes["status"][0]["cd"];
                                        string sts_message = (string)res_jes["status"][0]["msg"];
                                        MessageBox.Show(sts_message);
                                        ret_e_getlist();
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message + "[" + url + "]");
                                        txt3N2.ReadOnly = false;
                                    }
                                }
                            }
                            break;                       
                    }
                    break;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string txtdt1 = dt1.Value.ToString("yyyy-MM-dd");
            string txtdt2 = dt2.Value.ToString("yyyy-MM-dd");
            string txtitemcd = txtSearchItemcd.Text;
            using (WebClient wc = new WebClient())
            {
                string url = String.Format(mserverAddress + "/RETPRD/rtn_without_psn_list_period?date1={0}&date2={1}&itemcd={2}&business={3}", txtdt1, txtdt2, txtitemcd, ASettings.getmyBusinessGroup()).ToString();
                try
                {                    
                    var res = wc.DownloadString(url);
                    
                    JObject res_jes = JObject.Parse(res);
                    var rsdata = from p in res_jes["data"] select p;
                    dGV.Rows.Clear();
                    List<DataGridViewRow> rows = new List<DataGridViewRow>();
                    foreach (var rw in rsdata)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(dGV);
                        row.Cells[0].Value = rw["RETRM_DOC"];
                        row.Cells[1].Value = rw["RETRM_LINE"];
                        row.Cells[2].Value = rw["RETRM_ITMCD"];
                        row.Cells[3].Value = rw["ITMD1"];
                        row.Cells[4].Value = rw["SPTNO"];
                        row.Cells[5].Value = rw["RETRM_LOTNUM"];
                        row.Cells[6].Value = Convert.ToDouble(rw["RETRM_OLDQTY"]).ToString("#,#");
                        row.Cells[7].Value = Convert.ToDouble(rw["RETRM_NEWQTY"]).ToString("#,#");
                        row.Cells[8].Value = rw["ITMLOC_LOC"];
                        row.Cells[9].Value = rw["RETRM_CREATEDAT"];
                        row.Cells[10].Value = false;
                        row.Cells[11].Value = "Cancel";
                        rows.Add(row);                        
                    }
                    dGV.Rows.AddRange(rows.ToArray());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(url);
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnexport_Click(object sender, EventArgs e)
        {
            string txtdt1 = dt1.Value.ToString("yyyy-MM-dd");
            string txtdt2 = dt2.Value.ToString("yyyy-MM-dd");
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            DialogResult result = folderDlg.ShowDialog();
            string selectedPath = folderDlg.SelectedPath;            
            using (WebClient wc = new WebClient())
            {
                try
                {
                    string url = String.Format(mserverAddress + "/RETPRD/rtn_without_psn_list_period?date1={0}&date2={1}&itemcd=&business={2}", txtdt1, txtdt2,ASettings.getmyBusinessGroup()).ToString();
                    var res = wc.DownloadString(url);
                    JObject res_jes = JObject.Parse(res);
                    var rsdata = from p in res_jes["data"] select p;

                    using (var fs = new FileStream(selectedPath + "\\Return Without PSN " + txtdt1 + " to " + txtdt2 + ".xlsx", FileMode.Create, FileAccess.Write))
                    {
                        IWorkbook workbook = new XSSFWorkbook();
                        ISheet sheet = workbook.CreateSheet("RET-WITHOUT-PSN");
                        IRow row = sheet.CreateRow(0);
                        int rowx = 0;
                        row = sheet.CreateRow(rowx);
                        row.CreateCell(0).SetCellValue("ID");
                        row.CreateCell(1).SetCellValue("Line");
                        row.CreateCell(2).SetCellValue("Item Code");
                        row.CreateCell(3).SetCellValue("Description");
                        row.CreateCell(4).SetCellValue("Item Name");
                        row.CreateCell(5).SetCellValue("Lot No");
                        row.CreateCell(6).SetCellValue("Old QTY");
                        row.CreateCell(7).SetCellValue("New QTY");
                        row.CreateCell(8).SetCellValue("Rack");
                        row.CreateCell(9).SetCellValue("Date");
                        rowx = 1;
                        foreach (var rw in rsdata)
                        {
                            row = sheet.CreateRow(rowx);
                            row.CreateCell(0).SetCellValue(rw["RETRM_DOC"].ToString());
                            row.CreateCell(1).SetCellValue(rw["RETRM_LINE"].ToString());
                            row.CreateCell(2).SetCellValue(rw["RETRM_ITMCD"].ToString());
                            row.CreateCell(3).SetCellValue(rw["ITMD1"].ToString());
                            row.CreateCell(4).SetCellValue(rw["SPTNO"].ToString());
                            row.CreateCell(5).SetCellValue(rw["RETRM_LOTNUM"].ToString());
                            row.CreateCell(6).SetCellValue(rw["RETRM_OLDQTY"].ToString());
                            row.CreateCell(7).SetCellValue(rw["RETRM_NEWQTY"].ToString());
                            row.CreateCell(8).SetCellValue(rw["ITMLOC_LOC"].ToString());
                            rowx++;
                        }
                        workbook.Write(fs);                        
                    }
                    MessageBox.Show("Saved successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
