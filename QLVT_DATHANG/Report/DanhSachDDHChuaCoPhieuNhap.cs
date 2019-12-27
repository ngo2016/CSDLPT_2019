using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLVT_DATHANG.Report
{
    public partial class DanhSachDDHChuaCoPhieuNhap : DevExpress.XtraReports.UI.XtraReport
    {
        public DanhSachDDHChuaCoPhieuNhap()
        {
            InitializeComponent();

            if (Program.group == "CONGTY")
            {
                this.danhSachDDHChuaCoPhieuNhapTableAdapter1.Connection.ConnectionString = "Data Source=HEROSEEKER\\MAINSERVER;Initial Catalog=QLVT_DATHANG;Integrated Security=True";
            }
            else
            {
                this.danhSachDDHChuaCoPhieuNhapTableAdapter1.Connection.ConnectionString = Program.connectString;
            }

            this.danhSachDDHChuaCoPhieuNhapTableAdapter1.Fill(Server1.DanhSachDDHChuaCoPhieuNhap);
        }

    }
}
