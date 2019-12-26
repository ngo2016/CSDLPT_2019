using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLVT_DATHANG.Report
{
    public partial class TongHopNhapXuat : DevExpress.XtraReports.UI.XtraReport
    {
        public TongHopNhapXuat(DateTime start, DateTime end)
        {
            InitializeComponent();

            if (Program.group == "CONGTY")
            {
                this.sp_tongHopNhapXuatTableAdapterCN1.Connection.ConnectionString = "Data Source=HEROSEEKER\\MAINSERVER;Initial Catalog=QLVT_DATHANG;Integrated Security=True";
            }
            else
            {
                this.sp_tongHopNhapXuatTableAdapterCN1.Connection.ConnectionString = Program.connectString;
            }

            this.sp_tongHopNhapXuatTableAdapterCN1.Fill(Server1.sp_tongHopNhapXuat, start, end);
            this.lbNgayThang.Text = "TỪ " + String.Format("{0:dd/MM/yyyy}", start) + " ĐẾN " + String.Format("{0:dd/MM/yyyy}", end); ;
        }

    }
}
