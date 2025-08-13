using IniParser.Model;
using IniParser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMTCSHARP
{
    public partial class FP_ReportValueChecking : Form
    {
        string mServerApi = "";

        public FP_ReportValueChecking()
        {
            InitializeComponent();
        }

        void loadConfig()
        {

            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("config.ini");
            mServerApi = data["SERVER"]["ADDRESS"];
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(String.Format("{0}/report/value-checking?dateFrom={1}&dateTo={2}",
                mServerApi,
                DTPFrom.Value.ToString("yyyy-MM-dd"),
                DTPTo.Value.ToString("yyyy-MM-dd"))
                );
        }

        private void FP_ReportValueChecking_Load(object sender, EventArgs e)
        {
            loadConfig();
        }
    }
}
