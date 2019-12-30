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
using System.Data.SqlClient;
using DevExpress.XtraReports.UI;

namespace QLVT_DATHANG.Report
{
    public partial class KeKhai_Select_From_To : DevExpress.XtraEditors.XtraForm
    {
        public KeKhai_Select_From_To()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            //chưa chọn phiếu nào thì báo lỗi
            if (!(radioButtonPhieuNhap.Checked || radioButtonPhieuXuat.Checked))
            {
                MessageBox.Show("Phải chọn phiếu nhập hoặc phiếu xuất", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime startDate = this.dateTimePickerFrom.Value;
            DateTime endDate = this.dateTimePickerTo.Value;
            bool congty = Program.group == "CONGTY" ? true : false;
            //phieu nhap = false -> dang chon phieu xuat
            bool phieuNhap = this.radioButtonPhieuNhap.Checked;

            BangKeChiTietSoLuong_TriGiaHangNhapHoacXuat.congty = congty;
            BangKeChiTietSoLuong_TriGiaHangNhapHoacXuat.phieuNhap = phieuNhap;
            BangKeChiTietSoLuong_TriGiaHangNhapHoacXuat.startDate = startDate;
            BangKeChiTietSoLuong_TriGiaHangNhapHoacXuat.endDate = endDate;
            BangKeChiTietSoLuong_TriGiaHangNhapHoacXuat.lableTitle = phieuNhap ? "BẢNG KÊ KHAI CHI TIẾT NHẬP" :
                "BẢNG KÊ KHAI CHI TIẾT XUẤT";

            Report.BangKeChiTietSoLuong_TriGiaHangNhapHoacXuat n = new Report.BangKeChiTietSoLuong_TriGiaHangNhapHoacXuat();
            ReportPrintTool m = new ReportPrintTool(n);
            m.ShowPreviewDialog();
        }
    }
}