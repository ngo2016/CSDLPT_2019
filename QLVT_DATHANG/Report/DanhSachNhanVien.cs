using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLVT_DATHANG.Report
{
    public partial class DanhSachNhanVien : DevExpress.XtraReports.UI.XtraReport
    {
        private string connection_str;
        public DanhSachNhanVien(string connection_str)
        {
            this.connection_str = connection_str;
            InitializeComponent();
        }

        private void DanhSachNhanVien_DataSourceDemanded(object sender, EventArgs e)
        {
            this.v_DS_NhanVien_ReportTableAdapter.Connection.ConnectionString = this.connection_str;
        }

    }
}
