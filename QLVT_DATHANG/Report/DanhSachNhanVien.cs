using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLVT_DATHANG.Report
{
    public partial class DanhSachNhanVien : DevExpress.XtraReports.UI.XtraReport
    {
        public DanhSachNhanVien()
        {
            InitializeComponent();
        }

        private void DanhSachNhanVien_DataSourceDemanded(object sender, EventArgs e)
        {
            if (Program.reportFlag == 1)
            {
                this.DataSource = Server1;
                return;
            }
            if (Program.reportFlag == 2)
            {
                this.DataSource = Server2;
                return;
            }
        }

    }
}
