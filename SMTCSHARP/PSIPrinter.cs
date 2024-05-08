using com.citizen.sdk.LabelPrint;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace SMTCSHARP
{
    internal class PSIPrinter
    {
        Dictionary<string, string> data;
        public void setData(Dictionary<string, string> dataInput)
        {
            this.data = dataInput;
        }

        public void print(string printerBrand)
        {
            switch (printerBrand)
            {
                case "citizen":
                    printCitizen();
                    break;
                case "tsc":
                    printTSC();
                    break;
            }
        }

        private void printCitizen()
        {
            LabelPrinter printer = new LabelPrinter();
            printer.SetMeasurementUnit(LabelConst.CLS_UNIT_MILLI);
            printer.SetFormatAttribute(1);

            RegistryKey ckrk = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\" + Application.ProductName);
            string ribbonSize = ckrk.GetValue("PRINTER_RIBBON_SIZE").ToString();
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
            }
            LabelDesign lbldsg = new LabelDesign();
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;
            dtfi.DateSeparator = "/";
            int startx = 35;
            int mhratio = 105; //105, 75
            int mvratio = 110; //150,75

            if (ribbonSize.Equals("115x210mm"))
            {
                lbldsg.DrawTextPCFont(String.Format("RACK : {0}    {1}", this.data["rackCode"], Environment.MachineName.ToString()), "Times New Roman", LabelConst.CLS_RT_NORMAL, mhratio, mvratio, 7, (LabelConst.CLS_FNT_DEFAULT), startx, 410 + 20);
                lbldsg.DrawTextPCFont(String.Format("QTY : {0}    LOT NO : {1}", this.data["itemQty"], this.data["itemLot"]), "Times New Roman", LabelConst.CLS_RT_NORMAL, mhratio, mvratio, 7, (LabelConst.CLS_FNT_DEFAULT), startx, 385 + 10);
                lbldsg.DrawTextPCFont(String.Format("(3N1) {0}", this.data["itemCode"]), "Times New Roman", LabelConst.CLS_RT_NORMAL, mhratio, mvratio, 7, (LabelConst.CLS_FNT_DEFAULT), startx, 360);
                lbldsg.DrawBarCode(String.Format("3N1{0}", this.data["itemCode"]), LabelConst.CLS_BCS_CODE128, LabelConst.CLS_RT_NORMAL, myTHICKNESS, myNARROW, 55, startx, 300, LabelConst.CLS_BCS_TEXT_HIDE);
                lbldsg.DrawTextPCFont(String.Format("(3N2) {0} {1}", this.data["itemQty"], this.data["itemLot"]), "Times New Roman", LabelConst.CLS_RT_NORMAL, mhratio, mvratio, 7, (LabelConst.CLS_FNT_DEFAULT), startx, 255);
                lbldsg.DrawBarCode(String.Format("3N2 {0} {1} ", this.data["itemQty"].Replace(",", string.Empty), this.data["itemLot"]), LabelConst.CLS_BCS_CODE128, LabelConst.CLS_RT_NORMAL, myTHICKNESS, myNARROW, 55, startx, 200, LabelConst.CLS_BCS_TEXT_HIDE);
                lbldsg.DrawTextPCFont(String.Format("(UC) {0}", this.data["itemKey"]), "Times New Roman", LabelConst.CLS_RT_NORMAL, mhratio, mvratio, 7, (LabelConst.CLS_FNT_DEFAULT), startx, 155 + 5);
                lbldsg.DrawBarCode(String.Format(this.data["itemKey"]), LabelConst.CLS_BCS_CODE128, LabelConst.CLS_RT_NORMAL, myTHICKNESS, myNARROW, 55, startx, 100 + 5, LabelConst.CLS_BCS_TEXT_HIDE);
                lbldsg.DrawTextPCFont(String.Format("PART NO : {0}", this.data["itemName"]), "Times New Roman", LabelConst.CLS_RT_NORMAL, (mhratio - 5), (mvratio - 5), 7, (LabelConst.CLS_FNT_DEFAULT), startx, 70);
                lbldsg.DrawQRCode(String.Format("Z3N1{0}|3N2 {1} {2}|{3}", this.data["itemCode"], this.data["itemQty"].Replace(",", string.Empty), this.data["itemLot"], this.data["itemKey"]), LabelConst.CLS_ENC_CDPG_WINDOWS_1252, LabelConst.CLS_RT_NORMAL, 2, LabelConst.CLS_QRCODE_EC_LEVEL_H, startx + 520, 29);


                if (this.data["mretrohs"].Equals("1"))
                {
                    lbldsg.DrawTextPCFont("RoHS Compliant", "Times New Roman", LabelConst.CLS_RT_NORMAL, (mhratio - 5), (mvratio - 5), 7, (LabelConst.CLS_FNT_DEFAULT), startx, 45);
                }
                lbldsg.DrawTextPCFont("C/O Made in SMT", "Times New Roman", LabelConst.CLS_RT_NORMAL, (mhratio - 5), (mvratio - 5), 7, (LabelConst.CLS_FNT_DEFAULT), 310, 45);
                lbldsg.DrawTextPCFont(String.Format("{0} : {1}", ASettings.getmyuserid(), ASettings.getmyuserfname()), "Times New Roman", LabelConst.CLS_RT_NORMAL, (mhratio - 5), (mvratio - 5), 7, (LabelConst.CLS_FNT_DEFAULT), startx, 20);
                lbldsg.DrawTextPCFont(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", dtfi), "Times New Roman", LabelConst.CLS_RT_NORMAL, (mhratio - 5), (mvratio - 5), 7, (LabelConst.CLS_FNT_DEFAULT), 310, 20);
            }
            else
            {
                lbldsg.DrawTextPCFont(String.Format("RACK : {0}   {1}", this.data["rackCode"], Environment.MachineName.ToString()), "Times New Roman", LabelConst.CLS_RT_NORMAL, mhratio, mvratio, 7, (LabelConst.CLS_FNT_DEFAULT), startx, 410 + 20);
                lbldsg.DrawTextPCFont(String.Format("QTY : {0}    LOT NO : {1}", this.data["itemQty"], this.data["itemLot"]), "Times New Roman", LabelConst.CLS_RT_NORMAL, mhratio, mvratio, 7, (LabelConst.CLS_FNT_DEFAULT), startx, 385 + 10);
                lbldsg.DrawTextPCFont(String.Format("(3N1) {0}", this.data["itemCode"]), "Times New Roman", LabelConst.CLS_RT_NORMAL, mhratio, mvratio, 7, (LabelConst.CLS_FNT_DEFAULT), startx, 360);
                lbldsg.DrawBarCode(String.Format("3N1{0}", this.data["itemCode"]), LabelConst.CLS_BCS_CODE128, LabelConst.CLS_RT_NORMAL, myTHICKNESS, myNARROW, 55, startx, 300, LabelConst.CLS_BCS_TEXT_HIDE);
                lbldsg.DrawTextPCFont(String.Format("(3N2) {0} {1}", this.data["itemQty"], this.data["itemLot"]), "Times New Roman", LabelConst.CLS_RT_NORMAL, mhratio, mvratio, 7, (LabelConst.CLS_FNT_DEFAULT), startx, 255);
                lbldsg.DrawBarCode(String.Format("3N2 {0} {1} ", this.data["itemQty"].Replace(",", string.Empty), this.data["itemLot"]), LabelConst.CLS_BCS_CODE128, LabelConst.CLS_RT_NORMAL, myTHICKNESS, myNARROW, 55, startx, 200, LabelConst.CLS_BCS_TEXT_HIDE);
                lbldsg.DrawTextPCFont(String.Format("(UC) {0}", this.data["itemKey"]), "Times New Roman", LabelConst.CLS_RT_NORMAL, mhratio, mvratio, 7, (LabelConst.CLS_FNT_DEFAULT), startx, 155 + 5);
                lbldsg.DrawBarCode(String.Format(this.data["itemKey"]), LabelConst.CLS_BCS_CODE128, LabelConst.CLS_RT_NORMAL, myTHICKNESS, myNARROW, 55, startx, 100 + 5, LabelConst.CLS_BCS_TEXT_HIDE);
                lbldsg.DrawTextPCFont(String.Format("PART NO : {0}", this.data["itemName"]), "Times New Roman", LabelConst.CLS_RT_NORMAL, (mhratio - 5), (mvratio - 5), 6, (LabelConst.CLS_FNT_DEFAULT), startx, 70);
                lbldsg.DrawQRCode(String.Format("Z3N1{0}|3N2 {1} {2}|{3}", this.data["itemCode"], this.data["itemQty"].Replace(",", string.Empty), this.data["itemLot"], this.data["itemKey"]), LabelConst.CLS_ENC_CDPG_WINDOWS_1252, LabelConst.CLS_RT_NORMAL, 2, LabelConst.CLS_QRCODE_EC_LEVEL_H, startx + 325, 85);


                if (this.data["mretrohs"].Equals("1"))
                {
                    lbldsg.DrawTextPCFont("RoHS Compliant", "Times New Roman", LabelConst.CLS_RT_NORMAL, (mhratio - 5), (mvratio - 5), 6, (LabelConst.CLS_FNT_DEFAULT), startx, 45);
                }
                lbldsg.DrawTextPCFont("C/O Made in SMT", "Times New Roman", LabelConst.CLS_RT_NORMAL, (mhratio - 5), (mvratio - 5), 6, (LabelConst.CLS_FNT_DEFAULT), 250, 45);
                lbldsg.DrawTextPCFont(String.Format("{0} : {1}", ASettings.getmyuserid(), ASettings.getmyuserfname()), "Times New Roman", LabelConst.CLS_RT_NORMAL, (mhratio - 5), (mvratio - 5), 6, (LabelConst.CLS_FNT_DEFAULT), startx, 20);
                lbldsg.DrawTextPCFont(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", dtfi), "Times New Roman", LabelConst.CLS_RT_NORMAL, (mhratio - 5), (mvratio - 5), 6, (LabelConst.CLS_FNT_DEFAULT), 250, 20);
            }


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
        }

        private void printTSC()
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;
            dtfi.DateSeparator = "/";

            RegistryKey ckrk = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\" + Application.ProductName);
            string printerName = ckrk.GetValue("PRINTER_BRAND_TSC_NAME").ToString();
            string papperSize = ckrk.GetValue("PRINTER_BRAND_TSC_SIZE").ToString();
            string printSpeed = ckrk.GetValue("PRINTER_BRAND_TSC_SPEED").ToString();
            string density = ckrk.GetValue("PRINTER_BRAND_TSC_DENSITY").ToString();
            string ribbonSize = ckrk.GetValue("PRINTER_RIBBON_SIZE").ToString();

            int startx = 35;

            TSCSDK.driver aDriver = new TSCSDK.driver();
            aDriver.openport(printerName);
            aDriver.sendcommand(String.Format("SIZE {0}", papperSize));
            aDriver.sendcommand(String.Format("SPEED {0}", printSpeed));
            aDriver.sendcommand(String.Format("DENSITY {0}", density));
            aDriver.sendcommand(String.Format("DIRECTION 1"));
            aDriver.sendcommand(String.Format("SET STRIPER ON"));
            aDriver.sendcommand(String.Format("CODEPAGE UTF-8"));
            aDriver.clearbuffer();
            if (ribbonSize.Equals("115x210mm"))
            {
                aDriver.windowsfont(startx, 20, 25, 0, 0, 0, "Times New Roman", String.Format("RACK : {0}   {1}", this.data["rackCode"], Environment.MachineName.ToString()));
                aDriver.windowsfont(startx, 45, 25, 0, 0, 0, "Times New Roman", String.Format("QTY : {0}  LOT NO: {1}", this.data["itemQty"], this.data["itemLot"]));

                aDriver.windowsfont(startx, 70, 25, 0, 0, 0, "Times New Roman", String.Format("(3N1) {0}", this.data["itemCode"]));
                aDriver.barcode(startx.ToString(), "95", "128", "40", "0", "0", "2", "2", String.Format("3N1{0}", this.data["itemCode"]));

                aDriver.windowsfont(startx, 135, 25, 0, 0, 0, "Times New Roman", String.Format("(3N2) {0} {1}", this.data["itemQty"], this.data["itemLot"]));
                aDriver.barcode(startx.ToString(), "160", "128", "40", "0", "0", "2", "2", String.Format("3N2 {0} {1}", this.data["itemQty"].Replace(",", ""), this.data["itemLot"]));

                aDriver.windowsfont(startx, 200, 25, 0, 0, 0, "Times New Roman", String.Format("(UC) {0}", this.data["itemKey"]));
                aDriver.barcode(startx.ToString(), "225", "128", "40", "0", "0", "2", "2", String.Format("{0}", this.data["itemKey"]));

                aDriver.windowsfont(startx, 265, 25, 0, 0, 0, "Times New Roman", String.Format("PART NO : {0}", this.data["itemName"]));
                aDriver.windowsfont(startx, 290, 25, 0, 0, 0, "Times New Roman", String.Format("RoHS Compliant        C/O Made in SMT"));
                aDriver.windowsfont(startx, 315, 25, 0, 0, 0, "Times New Roman", String.Format("{0} : {1}", ASettings.getmyuserid(), ASettings.getmyuserfname()));
                aDriver.windowsfont(210, 315, 25, 0, 0, 0, "Times New Roman", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", dtfi));

                aDriver.sendcommand(String.Format("QRCODE 415,250,H,2,A,0,M2, \"Z3N1{0}|3N2 {1} {2}|{3}\"", this.data["itemCode"], this.data["itemQty"].Replace(",", string.Empty), this.data["itemLot"], this.data["itemKey"]));
            }
            else
            {
                aDriver.windowsfont(startx, 20, 25, 0, 0, 0, "Times New Roman", String.Format("RACK : {0}   {1}", this.data["rackCode"], Environment.MachineName.ToString()));
                aDriver.windowsfont(startx, 45, 25, 0, 0, 0, "Times New Roman", String.Format("QTY : {0}  LOT NO: {1}", this.data["itemQty"], this.data["itemLot"]));

                aDriver.windowsfont(startx, 70, 25, 0, 0, 0, "Times New Roman", String.Format("(3N1) {0}", this.data["itemCode"]));
                aDriver.barcode(startx.ToString(), "95", "128", "40", "0", "0", "1", "1", String.Format("3N1{0}", this.data["itemCode"]));

                aDriver.windowsfont(startx, 135, 25, 0, 0, 0, "Times New Roman", String.Format("(3N2) {0} {1}", this.data["itemQty"], this.data["itemLot"]));
                aDriver.barcode(startx.ToString(), "160", "128", "40", "0", "0", "1", "1", String.Format("3N2 {0} {1}", this.data["itemQty"].Replace(",", ""), this.data["itemLot"]));

                aDriver.windowsfont(startx, 200, 25, 0, 0, 0, "Times New Roman", String.Format("(UC) {0}", this.data["itemKey"]));
                aDriver.barcode(startx.ToString(), "225", "128", "40", "0", "0", "1", "1", String.Format("{0}", this.data["itemKey"]));

                aDriver.windowsfont(startx, 320, 20, 0, 0, 0, "Times New Roman", String.Format("PART NO : {0}", this.data["itemName"]));
                aDriver.windowsfont(startx, 290+50, 20, 0, 0, 0, "Times New Roman", String.Format("RoHS Compliant        C/O Made in SMT"));
                aDriver.windowsfont(startx, 315+50, 20, 0, 0, 0, "Times New Roman", String.Format("{0} : {1}", ASettings.getmyuserid(), ASettings.getmyuserfname()));
                aDriver.windowsfont(210, 315+50, 20, 0, 0, 0, "Times New Roman", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", dtfi));

                aDriver.sendcommand(String.Format("QRCODE 320,205,H,2,A,0,M2, \"Z3N1{0}|3N2 {1} {2}|{3}\"", this.data["itemCode"], this.data["itemQty"].Replace(",", string.Empty), this.data["itemLot"], this.data["itemKey"]));
            }

            aDriver.printlabel("1", "1");
            aDriver.closeport();
        }
    }
}
