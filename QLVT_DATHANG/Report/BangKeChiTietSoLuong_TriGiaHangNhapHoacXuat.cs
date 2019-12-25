using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLVT_DATHANG.Report
{
    public partial class BangKeChiTietSoLuong_TriGiaHangNhapHoacXuat : DevExpress.XtraReports.UI.XtraReport
    {

        public static bool congty;
        public static DateTime startDate, endDate;

        public BangKeChiTietSoLuong_TriGiaHangNhapHoacXuat()
        {
            InitializeComponent();
            this.sp_keKhaiChiTietTongHopTableAdapter.Connection.ConnectionString = Program.connectString;
            this.sp_keKhaiChiTietTongHopTableAdapter.Fill(KeKhaiCN1.sp_keKhaiChiTietTongHop, congty, startDate, endDate);
        }

    }
}
