using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraReports.UI;

namespace QLVT_DATHANG
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MainForm()
        {
            InitializeComponent();

            this.labelMaNV.Text = "MÃ NHÂN VIÊN: " + Program.username;
            this.labelTenNV.Text = "TÊN: " + Program.hoten;
            this.labelNhomNV.Text = "NHÓM: " + Program.group;

            //phân quyền
            if (Program.group == "USER")
            {
                this.btnCreateAcc.Enabled = false;
                this.ribbonBaoCao.Visible = false;
            }
        }

        private void btnFormEmployee_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.employeeForm = new EmployeeForm();
            Program.employeeForm.ShowDialog();
        }

        private void btnExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.loginForm.Visible = true;
            this.Close();
        }

        private void btnWarehouse_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.storageForm = new StorageForm();
            Program.storageForm.ShowDialog();
        }

        private void btnSupplies_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.productForm = new ProductForm();
            Program.productForm.ShowDialog();
        }

        private void btnLapDonDatHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.addDDHForm = new SubForm.LapDonDatHang();
            Program.addDDHForm.ShowDialog();
        }

        private void btnCreateAcc_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.registerForm = new RegisterForm();
            Program.registerForm.ShowDialog(this);
        }

        private void btnInDanhMucVatTu_ItemClick(object sender, ItemClickEventArgs e)
        {
            Report.DanhSachVatTu n = new Report.DanhSachVatTu();
            ReportPrintTool m = new ReportPrintTool(n);
            m.ShowPreviewDialog();
        }

        private void btnInDanhSachNhanVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.menuDanhSachNhanVien = new Report.MenuDanhSachNhanVien();
            Program.menuDanhSachNhanVien.ShowDialog(this);
        }

        private void btnInBangKeChiTietSoLuong_TriGiaHangNhapHoacXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            Report.KeKhai_Select_From_To fromTo = new Report.KeKhai_Select_From_To();
            fromTo.ShowDialog(this);
        }

        private void btnBaoCaoTinhHinhHoatDongCua1NhanVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.menuHoatDongNhanVien = new Report.MenuHoatDongNhanVien();
            Program.menuHoatDongNhanVien.ShowDialog(this);
        }

        private void btnTongHopNhapXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.menuTongHopNhapXuat = new Report.MenuTongHopNhapXuat();
            Program.menuTongHopNhapXuat.ShowDialog(this);
        }

        private void btnInDanhSachCacDonDatHangChuaCoPhieuNhap_ItemClick(object sender, ItemClickEventArgs e)
        {
            Report.DanhSachDDHChuaCoPhieuNhap n = new Report.DanhSachDDHChuaCoPhieuNhap();
            ReportPrintTool m = new ReportPrintTool(n);
            m.ShowPreviewDialog();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.loginForm.Visible = true;
        }

        private void btnLapPhieuNhap_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.addPhieuNhapForm = new SubForm.LapPhieuNhap();
            Program.addPhieuNhapForm.ShowDialog();
        }

        private void btnLapPhieuXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.addPhieuXuatForm = new SubForm.LapPhieuXuat();
            Program.addPhieuXuatForm.ShowDialog();
        }
    }
}