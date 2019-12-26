using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;

namespace QLVT_DATHANG.Report
{
    public partial class MenuTongHopNhapXuat : DevExpress.XtraEditors.XtraForm
    {
        public MenuTongHopNhapXuat()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Report.TongHopNhapXuat n = new Report.TongHopNhapXuat(dateTimePickerFrom.Value, dateTimePickerTo.Value);
            ReportPrintTool m = new ReportPrintTool(n);
            m.ShowPreviewDialog();
        }
    }
}