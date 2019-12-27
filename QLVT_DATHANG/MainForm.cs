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

            if (Program.group == "USER")
            {
                this.btnCreateAcc.Enabled = false;
            }
        }

        private void btnFormEmployee_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.employeeForm = new EmployeeForm();
            Program.employeeForm.Activate();
            Program.employeeForm.Show();
            this.Visible = false;

        }

        private void btnExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.loginForm.Visible = true;
            this.Visible = false;
        }

        private void btnWarehouse_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.storageForm = new StorageForm();
            Program.storageForm.Activate();
            Program.storageForm.Show();
            this.Visible = false;
        }

        private void btnSupplies_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.productForm = new ProductForm();
            Program.productForm.Activate();
            Program.productForm.Show();
            this.Visible = false;
        }

        private void btnLapDonDatHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.addDDHForm = new SubForm.LapDonDatHang();
            Program.addDDHForm.Activate();
            Program.addDDHForm.Show();
            this.Visible = false;
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.addPhieuNhapForm = new SubForm.LapPhieuNhap();
            Program.addPhieuNhapForm.Activate();
            Program.addPhieuNhapForm.Show();
            this.Visible = false;
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.addPhieuXuatForm = new SubForm.LapPhieuXuat();
            Program.addPhieuXuatForm.Activate();
            Program.addPhieuXuatForm.Show();
            this.Visible = false;
        }

        private void btnCreateAcc_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.registerForm = new RegisterForm();
            Program.registerForm.Activate();
            Program.registerForm.Show();
            this.Visible = false;
        }

        private void btnInDanhMucVatTu_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.reviewDanhSachVatTu = new Report.ReviewDanhSachVatTu();
            Program.reviewDanhSachVatTu.Activate();
            Program.reviewDanhSachVatTu.Show();
            this.Visible = false;
        }

        private void btnInDanhSachNhanVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.menuDanhSachNhanVien = new Report.MenuDanhSachNhanVien();
            Program.menuDanhSachNhanVien.Activate();
            Program.menuDanhSachNhanVien.Show();
            this.Visible = false;
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
    }
}