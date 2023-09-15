using IniParser;
using IniParser.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMTCSHARP
{
    public partial class FBusinessGroup : Form
    {
        string mserverAddress = "";

        public FBusinessGroup()
        {
            InitializeComponent();
        }

        void get_countrylist()
        {
            using (WebClient wc = new WebClient())
            {
                try
                {
                    string url = mserverAddress + "/business-group";
                    var res = wc.DownloadString(url);
                    JObject res_jes = JObject.Parse(res);
                    var rsdata = from p in res_jes["data"] select p;
                    var cmbsourc = new Dictionary<string, string>();
                    foreach (var rw in rsdata)
                    {
                        cmbsourc.Add(rw["MBSG_BSGRP"].ToString().Trim(), (string)rw["MBSG_DESC"]);
                    }
                    comboBox1.DataSource = new BindingSource(cmbsourc, null);
                    comboBox1.DisplayMember = "Value";
                    comboBox1.ValueMember = "Key";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "[" + mserverAddress + "]");
                }

            }
        }

        private void FBusinessGroup_Load(object sender, EventArgs e)
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("config.ini");
            mserverAddress = data["SERVER"]["ADDRESS"];

            get_countrylist();
            comboBox1.SelectedValue = ASettings.getmyBusinessGroup();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ASettings.setmyBusinessGroup(comboBox1.SelectedValue.ToString());
            MessageBox.Show("OK");
            this.Close();       
        }
    }
}
