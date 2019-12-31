using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLVT_DATHANG.Report
{
    public partial class HoatDongNhanVien : DevExpress.XtraReports.UI.XtraReport
    {
        public HoatDongNhanVien(int maNV, DateTime start, DateTime end)
        {
            InitializeComponent();
            //gán lại connect string đề phòng lỗi khi đăng nhập lại or đổi chi nhánh
            this.sp_hoatDongNhanVienTableAdapter.Connection.ConnectionString = Program.connectString;
            this.sp_hoatDongNhanVienTableAdapter.Fill(HoatDongNhanVienCN1.sp_hoatDongNhanVien, maNV, start, end);
        }
    }
}
