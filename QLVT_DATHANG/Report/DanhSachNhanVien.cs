using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLVT_DATHANG.Report
{
    public partial class DanhSachNhanVien : DevExpress.XtraReports.UI.XtraReport
    {
        //connect string của form
        private string connection_str;

        //gửi vào connect string của app
        public DanhSachNhanVien(string connection_str)
        {
            //gán connect của form là connect của app
            this.connection_str = connection_str;
            InitializeComponent();
        }

        private void DanhSachNhanVien_DataSourceDemanded(object sender, EventArgs e)
        {
            this.v_DS_NhanVien_ReportTableAdapter.Connection.ConnectionString = this.connection_str;
        }

    }
}
