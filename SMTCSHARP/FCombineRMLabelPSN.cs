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
    public partial class FCombineRMLabelPSN : Form
    {
        public FCombineRMLabelPSN()
        {
            InitializeComponent();
        }

        void initcolumn()
        {
            //DG Joined Label
            dGV_lbljoin.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dGV_lbljoin.ColumnCount = 3;
            dGV_lbljoin.Columns[0].Name = "Lot Number";
            dGV_lbljoin.Columns[0].Width = 250;
            dGV_lbljoin.Columns[1].Name = "Qty";
            dGV_lbljoin.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dGV_lbljoin.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dGV_lbljoin.Columns[2].Name = "Old Uniquekey";
            dGV_lbljoin.Columns[2].Width = 300;

        }

        private void FCombineRMLabelPSN_Load(object sender, EventArgs e)
        {
            initcolumn();
        }
    }
}
