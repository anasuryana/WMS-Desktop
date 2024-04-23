using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using com.citizen.sdk.LabelPrint;
using IniParser;
using IniParser.Model;
using Microsoft.Win32;
using MySqlConnector;
using Newtonsoft.Json.Linq;
namespace SMTCSHARP
{
    public partial class FKittingReturnXRay : Form
    {
        string msupqty = "";
        string mretitemcd = "";
        string mrackcd = "";
        string mretqty = "";
        string mretlot = "";
        string mretitemnm = "";

        string mUniqueCode = "";
        string mServerApi = "";
        bool isScanQR = false;
        struct MyStruct
        {
            public string id { get; set; }
            public string itemCode { get; set; }
            public string itemLot { get; set; }
            public int qtyBefore { get; set; }
            public int qtyAfter { get; set; }
            public string usageRow { get; set; }
            public string uniqueKey { get; set; }
        }

        void ShowConfig()
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("config.ini");
            this.mServerApi = data["SERVER"]["ADDRESS"];
        }

        void initColumn()
        {
            dGV.ColumnCount = 13;
            dGV.Columns[0].Name = "ID";
            dGV.Columns[1].Name = "PSN No";
            dGV.Columns[2].Name = "Category";
            dGV.Columns[3].Name = "Line";
            dGV.Columns[3].Width = 70;
            dGV.Columns[4].Name = "F/R";
            dGV.Columns[4].Width = 40;
            dGV.Columns[5].Name = "Machine";
            dGV.Columns[6].Name = "Item Code";
            dGV.Columns[7].Name = "Item Name";
            dGV.Columns[8].Name = "Lot No";
            dGV.Columns[9].Name = "Sup. QTY";
            dGV.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dGV.Columns[10].Name = "Ret. QTY";
            dGV.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dGV.Columns[11].Name = "RoHS";
            dGV.Columns[11].Width = 70;
            dGV.Columns[12].Name = "Country";

            foreach (DataGridViewColumn column in dGV.Columns)
            {
                column.ReadOnly = true;
            }

            DataGridViewCheckBoxColumn hcb = new DataGridViewCheckBoxColumn();
            hcb.ValueType = typeof(bool);
            hcb.Width = 50;
            hcb.ToolTipText = "Print Flag";
            dGV.Columns.Add(hcb);

            DataGridViewTextBoxColumn htx = new DataGridViewTextBoxColumn();
            htx.DefaultCellStyle.Font = new Font("Wingdings", 22, GraphicsUnit.Pixel);
            htx.DefaultCellStyle.ForeColor = Color.Blue;
            htx.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            htx.Width = 50;
            htx.ReadOnly = true;
            dGV.Columns.Add(htx);



            DataGridViewButtonColumn hbt = new DataGridViewButtonColumn();
            hbt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            hbt.Width = 100;
            dGV.Columns.Add(hbt);

            htx = new DataGridViewTextBoxColumn();
            htx.Name = "Rack";
            htx.Width = 150;
            htx.ReadOnly = true;
            dGV.Columns.Add(htx);

            htx = new DataGridViewTextBoxColumn();
            htx.Name = "Key";
            htx.Width = 150;
            htx.ReadOnly = true;
            dGV.Columns.Add(htx);


            // define column datagrid temp
            // this datagrid is dedicated for retriveing data from x ray counter

            DGVTemp.ColumnCount = 6;
            DGVTemp.Columns[0].Name = "Item Code";
            DGVTemp.Columns[1].Name = "Lot No";
            DGVTemp.Columns[1].Width = 150;
            DGVTemp.Columns[2].Name = "Sup. QTY";
            DGVTemp.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGVTemp.Columns[3].Name = "Ret. QTY";
            DGVTemp.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGVTemp.Columns[4].Name = "Key";
            DGVTemp.Columns[4].Width = 200;
            DGVTemp.Columns[5].Name = "Status";
            DGVTemp.Columns[5].Width = 200;

            foreach (DataGridViewColumn column in DGVTemp.Columns)
            {
                column.ReadOnly = true;
            }

            hbt = new DataGridViewButtonColumn();
            hbt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            hbt.Width = 100;
            DGVTemp.Columns.Add(hbt);
        }

        void getDocumentDetails()
        {
            using (WebClient wc = new WebClient())
            {
                try
                {
                    string url = String.Format(this.mServerApi + "/return/counted?doc={0}&category={1}&line={2}", txtpsn.Text, txtcat.Text, txtline.Text).ToString();
                    var res = wc.DownloadString(url);
                    JObject res_jes = JObject.Parse(res);
                    var rsdata = from p in res_jes["data"] select p;
                    dGV.Rows.Clear();
                    List<DataGridViewRow> rows = new List<DataGridViewRow>();
                    foreach (var rw in rsdata)
                    {

                        string savedorno = rw["RETSCN_SAVED"].ToString();
                        string flghold = rw["FLG_HOLD"].ToString();
                        if (savedorno == "1")
                        {
                            savedorno = "ü";
                            flghold = "";
                        }
                        else
                        {
                            savedorno = "û";
                            if (flghold.Equals("0"))
                            {
                                flghold = "HOLD";
                            }
                            else
                            {
                                flghold = "RELEASE";
                            }
                        }
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(dGV);
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
                        row.Cells[12].Value = rw["MMADE_NM"];
                        row.Cells[13].Value = false;
                        row.Cells[14].Value = savedorno;
                        row.Cells[15].Value = flghold;
                        row.Cells[16].Value = rw["SPL_RACKNO"];
                        row.Cells[17].Value = rw["RETSCN_UNIQUEKEY"];
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

        public FKittingReturnXRay()
        {
            InitializeComponent();
        }

        private void FKittingReturnXRay_Load(object sender, EventArgs e)
        {
            ShowConfig();
            initColumn();
        }

        private void txtpsn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                using (WebClient wc = new WebClient())
                {
                    try
                    {
                        var res = wc.DownloadString(this.mServerApi + "/supply/validate-document?doc=" + txtpsn.Text);
                        JObject res_jes = JObject.Parse(res);
                        string sts = (string)res_jes["status"][0]["cd"];
                        if (!sts.Equals("0"))
                        {
                            txtcat.Focus();
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
        }

        private void txtcat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                using (WebClient wc = new WebClient())
                {
                    try
                    {
                        var res = wc.DownloadString(String.Format(this.mServerApi + "/supply/validate-document?doc={0}&category={1}", txtpsn.Text, txtcat.Text));
                        JObject res_jes = JObject.Parse(res);
                        string sts = (string)res_jes["status"][0]["cd"];
                        if (!sts.Equals("0"))
                        {
                            txtline.Focus();
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
        }

        private void txtline_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                using (WebClient wc = new WebClient())
                {
                    try
                    {
                        var res = wc.DownloadString(String.Format(this.mServerApi + "/supply/validate-document?doc={0}&category={1}&line={2}", txtpsn.Text, txtcat.Text, txtline.Text));
                        JObject res_jes = JObject.Parse(res);
                        string sts = (string)res_jes["status"][0]["cd"];
                        if (sts.Equals("1"))
                        {
                            txtitemcd.Focus();
                            var rsdata = from p in res_jes["WorkOrder"] select p;
                            string joblist = "";
                            foreach (var rw in rsdata)
                            {
                                joblist += rw["PPSN1_WONO"] + ",";
                            }
                            txtjoblist.Text = joblist.Substring(0, joblist.Length - 1);

                            getDocumentDetails();
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
        }

        private void btnRefreshSavedDoc_Click(object sender, EventArgs e)
        {
            getDocumentDetails();
        }

        private void txtitemcd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (txtpsn.Text == "")
                {
                    MessageBox.Show("Please fill PSN No");
                    txtpsn.Focus();
                    return;
                }
                if (txtcat.Text == "")
                {
                    MessageBox.Show("Please fill Category");
                    txtcat.Focus();
                    return;
                }

                if (txtline.Text == "")
                {
                    MessageBox.Show("Please fill Line");
                    txtline.Focus();
                    return;
                }

                if (txtitemcd.Text == "")
                {
                    MessageBox.Show("Please fill Item Code");
                    return;
                }

                if (txtitemcd.Text.Length <= 3)
                {
                    MessageBox.Show("Unknown Format C3 Label");
                    txtitemcd.Text = "";
                    return;
                }

                if (txtitemcd.Text.Contains("|"))
                {
                    isScanQR = true;

                    // parse qr code
                    string[] QRArray = txtitemcd.Text.ToUpper().Split('|');
                    int strLength3N1 = 0;
                    switch (QRArray[0].Substring(0, 2).ToString())
                    {
                        case "Z3":
                            strLength3N1 = QRArray[0].Length - 4;
                            txtitemcd.Text = QRArray[0].Substring(4, strLength3N1);
                            break;
                        case "3N":
                            strLength3N1 = QRArray[0].Length - 3;
                            txtitemcd.Text = QRArray[0].Substring(3, strLength3N1);
                            break;
                        default:
                            txtitemcd.Text = QRArray[0];
                            break;
                    }

                    string[] Array3N2;

                    if (QRArray.Length == 4)
                    {
                        txtbefqty.Text = QRArray[1];
                        txtlot.Text = QRArray[2];
                        txtbefqty.ReadOnly = true;
                    }
                    else
                    {
                        Array3N2 = QRArray[1].Split(' ');
                        switch (QRArray[1].Substring(0, 3).ToString())
                        {
                            case "3N2":
                                if (Array3N2[1].All(char.IsNumber))
                                {
                                    txtbefqty.Text = Array3N2[1];
                                    txtlot.Text = Array3N2[2];
                                    txtbefqty.ReadOnly = true;
                                }
                                break;

                            default:
                                if (Array3N2[0].All(char.IsNumber))
                                {
                                    txtbefqty.Text = Array3N2[0];
                                    txtlot.Text = Array3N2[1];
                                    txtbefqty.ReadOnly = true;
                                }
                                break;
                        }
                    }

                }
                else
                {
                    if (txtitemcd.Text.Substring(0, 3) != "3N1")
                    {
                        MessageBox.Show("Unknown Format C3 Label");
                        txtitemcd.Text = "";
                        txtitmname.Text = "";
                        return;
                    }

                    if (txtitemcd.Text.Contains(" "))
                    {
                        string[] an1 = txtitemcd.Text.Split(' ');
                        msupqty = an1[1];
                        int strleng = an1[0].Length - 3;
                        txtitemcd.Text = an1[0].Substring(3, strleng);
                    }
                    else
                    {
                        int strleng = txtitemcd.Text.Length - 3;
                        txtitemcd.Text = txtitemcd.Text.Substring(3, strleng);
                        msupqty = "";
                    }
                }

                using (WebClient wc = new WebClient())
                {
                    try
                    {
                        string url = String.Format(this.mServerApi + "/supply/validate-item?doc={0}&category={1}&line={2}&item={3}", txtpsn.Text, txtcat.Text, txtline.Text, txtitemcd.Text);
                        var res = wc.DownloadString(url);

                        JObject res_jes = JObject.Parse(res);
                        string sts = (string)res_jes["data"][0]["cd"];
                        if (sts.Equals("0"))
                        {
                            MessageBox.Show((string)res_jes["data"][0]["msg"]);
                            txtitemcd.Text = "";
                            txtitmname.Text = "";
                        }
                        else
                        {
                            txtbefqty.Focus();
                            txtbefqty.ReadOnly = false;
                            txtitmname.Text = (string)res_jes["data"][0]["ref"];
                        }
                        if (isScanQR)
                        {
                            validateSuppliedItemByAPI();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void txtbefqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (txtbefqty.Text.Length <= 3)
                {
                    MessageBox.Show("Unknown Format C3 Label");
                    txtbefqty.Text = "";
                    return;
                }

                if (txtbefqty.Text.Substring(0, 3) != "3N2")
                {
                    MessageBox.Show("Unknown Format C3 Label lot");
                    txtbefqty.Text = "";
                    return;
                }
                else
                {
                    string[] mthis_ar = txtbefqty.Text.Split(' ');
                    if (msupqty != "")
                    {
                        txtbefqty.Text = msupqty;

                        txtbefqty.ReadOnly = true;
                        txtlot.Text = mthis_ar[1];
                    }
                    else
                    {
                        if (mthis_ar[1].All(char.IsNumber))
                        {
                            txtbefqty.Text = mthis_ar[1];
                            txtlot.Text = mthis_ar[2];
                            txtbefqty.ReadOnly = true;
                        }
                    }

                    validateSuppliedItemByAPI();
                }
            }
        }

        private void validateSuppliedItemByAPI()
        {
            using (WebClient wc = new WebClient())
            {
                string url = String.Format(this.mServerApi + "/supply/validate-supplied-item");
                string myparam = String.Format("doc={0}&category={1}&line={2}&item={3}&lotNumber={4}&qty={5}", txtpsn.Text, txtcat.Text, txtline.Text, txtitemcd.Text, txtlot.Text, txtbefqty.Text);
                myparam = myparam.Replace("+", "%2B");
                try
                {
                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    var res = wc.UploadString(url, myparam);
                    JObject res_jes = JObject.Parse(res);
                    string sts = (string)res_jes["status"][0]["cd"];
                    if (!sts.Equals("0"))
                    {
                        // Tambah baris ke datagrid temp
                        // sebagai data penampung sementara sampai counting result dari x ray didapatkan
                        if (DGVTemp.Rows.Count < 4)
                        {
                            DGVTemp.Rows.Add(txtitemcd.Text, txtlot.Text, txtbefqty.Text, null, null, "Not Saved", "Cancel");
                        }
                        else
                        {
                            MessageBox.Show("Maximum rows is 4");
                        }
                        txtbefqty.Text = "";
                        txtlot.Text = "";
                        txtitemcd.Text = "";
                        txtitmname.Text = "";
                        txtbefqty.ReadOnly = false;
                        txtitemcd.Focus();
                    }
                    else
                    {
                        txtbefqty.Text = "";
                        txtlot.Text = "";
                        MessageBox.Show("Item and PSN were not match");
                        txtbefqty.ReadOnly = false;

                        if (isScanQR)
                        {
                            txtitemcd.Text = "";
                            txtitmname.Text = "";
                            txtitemcd.Focus();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "[" + url + "]");
                    txtbefqty.ReadOnly = false;
                }
            }
        }


        private void btnXRayGetter_Click(object sender, EventArgs e)
        {
            try
            {
                btnXRayGetter.Enabled = false;
                string connectionString = string.Format(ASettings.getconstrX(), ASettings.getMysserverX(), ASettings.getMysdbX(), ASettings.getMysuserX(), ASettings.getMyspwX());
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {

                    conn.Open();
                    using (MySqlCommand command = new MySqlCommand("SELECT * FROM countings WHERE document_number=@DOC ORDER BY created_at DESC", conn))
                    {
                        command.Parameters.Add("@DOC", System.Data.DbType.String);
                        command.Parameters["@DOC"].Value = txtpsn.Text;

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            List<MyStruct> lio = new List<MyStruct>();
                            while (reader.Read())
                            {
                                lio.Add(new MyStruct
                                {
                                    id = reader["id"].ToString(),
                                    itemCode = reader["item_code"].ToString(),
                                    itemLot = reader["lot_number"].ToString(),
                                    uniqueKey = reader["uniquekey_after"].ToString(),
                                    qtyBefore = Int32.Parse(reader["quantity_before"].ToString()),
                                    qtyAfter = Int32.Parse(reader["quantity_after"].ToString()),
                                    usageRow = "0"
                                }
                                );
                            }

                            // komparasi antara data temp dengan data counting result
                            foreach (DataGridViewRow row in DGVTemp.Rows)
                            {
                                for (var i = 0; i < lio.Count; i++)
                                {
                                    if (lio[i].itemCode.Equals(row.Cells[0].Value) &&
                                        lio[i].usageRow.Equals("0") &&
                                        lio[i].itemLot.Equals(row.Cells[1].Value)

                                        )
                                    {
                                        row.Cells[3].Value = lio[i].qtyAfter;
                                        row.Cells[4].Value = lio[i].uniqueKey;

                                        MyStruct _mystruct = lio[i];
                                        _mystruct.usageRow = "1";
                                        lio[i] = _mystruct;
                                        break;
                                    }
                                }
                            }
                        }
                    }

                    // save 
                    string itmcode_print = "";
                    string itmcode = "";
                    string qtybefore = "";
                    string qtyAfter = "";
                    string lotno = "";
                    string uniqueKey = "";

                    int _i = 1;
                    foreach (DataGridViewRow row in DGVTemp.Rows)
                    {
                        if (row.Cells[3].Value == null)
                        {
                            MessageBox.Show(String.Format("Qty still null found line {0}", _i));
                            btnXRayGetter.Enabled = true;
                            return;
                        }
                        itmcode_print = row.Cells[0].Value.ToString();
                        itmcode += "item[]=" + row.Cells[0].Value.ToString() + "&";
                        qtybefore += "qtyBefore[]=" + row.Cells[2].Value.ToString() + "&";
                        qtyAfter += "qtyAfter[]=" + row.Cells[3].Value.ToString() + "&";
                        lotno += "lotNumber[]=" + row.Cells[1].Value.ToString() + "&";
                        uniqueKey += "uniqueKey[]=" + row.Cells[4].Value.ToString() + "&";
                        _i++;
                    }


                    using (WebClient wc = new WebClient())
                    {
                        try
                        {
                            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                            string url = this.mServerApi + "/return/by-xray";
                            string myparam = String.Format("doc={0}&category={1}&line={2}&{3}{4}{5}{6}{7}userId={8}&machineName={9}",
                                txtpsn.Text,
                                txtcat.Text,
                                txtline.Text,
                                itmcode,
                                qtybefore, //4
                                qtyAfter, //5
                                lotno,   //6
                                uniqueKey,   //7
                                ASettings.getmyuserid(), // 8
                                Environment.MachineName.ToString()); // 9
                            myparam = myparam.Replace("+", "%2B");
                            string res = wc.UploadString(url, myparam);

                            JObject res_jes = JObject.Parse(res);
                            int totalStatus = res_jes["status"].Count();
                            for (int i = 0; i < totalStatus; i++)
                            {
                                string sts = (string)res_jes["status"][i]["cd"];
                                string msg = (string)res_jes["status"][i]["msg"];
                                string _uniqueKey = (string)res_jes["status"][i]["_unique"];
                                foreach (DataGridViewRow row in DGVTemp.Rows)
                                {
                                    if (_uniqueKey.Equals(row.Cells[4].Value.ToString()))
                                    {
                                        row.Cells[5].Value = msg;
                                    }
                                }
                            }
                            using (MySqlCommand cmd = new MySqlCommand("INSERT INTO countings_history (document_number," +
                                "item_code," +
                                "quantity_before," +
                                "lot_number," +
                                "uniquekey_before," +
                                "quantity_after," +
                                "uniquekey_after," +
                                "created_at," +
                                "user_id," +
                                "remark" +
                                ") " +
                                "SELECT document_number," +
                                "item_code," +
                                "quantity_before," +
                                "lot_number," +
                                "uniquekey_before," +
                                "quantity_after," +
                                "uniquekey_after," +
                                "created_at," +
                                "user_id," +
                                "'BACKUP'" +
                                " FROM countings WHERE document_number='" + txtpsn.Text + "'", conn))
                            {
                                cmd.ExecuteNonQuery();
                            }

                            using (MySqlCommand cmd = new MySqlCommand("truncate table countings ", conn))
                            {
                                cmd.ExecuteNonQuery();
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            txtbefqty.ReadOnly = false;
                        }
                    }

                }
            }
            catch (MySqlException exx)
            {
                MessageBox.Show(exx.Message);
            }
            catch (Exception exx)
            {
                MessageBox.Show(exx.Message);
            }

        }

        private void DGVTemp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string uniqueKey = (string)DGVTemp.Rows[DGVTemp.CurrentCell.RowIndex].Cells[4].Value ?? "";
            switch (DGVTemp.CurrentCell.ColumnIndex)
            {
                case 6:
                    if (uniqueKey.Length > 0)
                    {
                        MessageBox.Show("Could not cancel as the key is already retrieved");
                    }
                    else
                    {
                        if (MessageBox.Show("Are you sure want to cancel ?", "Decide", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            DataGridViewRow dataGridViewRow = DGVTemp.Rows[e.RowIndex];
                            DGVTemp.Rows.Remove(dataGridViewRow);
                        }
                    }
                    break;
            }
        }

        private void DGVTemp_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)        /*If a header cell*/
                return;
            if (!(e.ColumnIndex == 3 || e.ColumnIndex == 4)) /*If not our desired columns*/
                return;
            if (e.Value == null || e.Value == DBNull.Value)  /*If value is null*/
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All
                    & ~(DataGridViewPaintParts.ContentForeground));

                TextRenderer.DrawText(e.Graphics, "Waiting Counting Result", new System.Drawing.Font(e.CellStyle.Font.Name, e.CellStyle.Font.Size, FontStyle.Italic),
                    e.CellBounds, Color.DeepSkyBlue, TextFormatFlags.Left);

                e.Handled = true;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            dGV.Rows.Clear();
            DGVTemp.Rows.Clear();
            txtpsn.Text = "";
            txtcat.Text = "";
            txtline.Text = "";
            txtjoblist.Text = "";
            txtitemcd.Text = "";
            txtitmname.Text = "";
            txtbefqty.Text = "";
            txtbefqty.ReadOnly = false;
            txtlot.Text = "";
            msupqty = "";
            txtpsn.Focus();
            btnXRayGetter.Enabled = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            DGVTemp.Rows.Clear();
            txtitemcd.Focus();
            btnXRayGetter.Enabled = true;
        }

        private void btnreturnprint_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dGV.Rows)
            {
                if (Convert.ToBoolean(row.Cells[13].Value))
                {
                    mretitemcd = row.Cells[6].Value.ToString().Trim();
                    mretqty = row.Cells[10].Value.ToString().Trim();
                    mretlot = row.Cells[8].Value.ToString().Trim();
                    mretitemnm = row.Cells[7].Value.ToString().Trim();

                    mrackcd = row.Cells[16].Value.ToString().Trim();
                    mUniqueCode = row.Cells[17].Value.ToString().Trim();
                    printsmtlabel();
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
            PSIprinter.setData(datanya);
            PSIprinter.print(ckrk.GetValue("PRINTER_DEFAULT_BRAND").ToString().ToLower());
        }

    }
}
