namespace QLVT_DATHANG
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnFormEmployee = new DevExpress.XtraBars.BarButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarButtonItem();
            this.btnSupplies = new DevExpress.XtraBars.BarButtonItem();
            this.btnWarehouse = new DevExpress.XtraBars.BarButtonItem();
            this.btnCreateAcc = new DevExpress.XtraBars.BarButtonItem();
            this.btnLapDonDatHang = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnInDanhMucVatTu = new DevExpress.XtraBars.BarButtonItem();
            this.btnInDanhSachNhanVien = new DevExpress.XtraBars.BarButtonItem();
            this.btnInBangKeChiTietSoLuong_TriGiaHangNhapHoacXuat = new DevExpress.XtraBars.BarButtonItem();
            this.btnInDanhSachCacDonDatHangChuaCoPhieuNhap = new DevExpress.XtraBars.BarButtonItem();
            this.btnBaoCaoTinhHinhHoatDongCua1NhanVien = new DevExpress.XtraBars.BarButtonItem();
            this.btnTongHopNhapXuat = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.labelMaNV = new DevExpress.XtraEditors.LabelControl();
            this.labelTenNV = new DevExpress.XtraEditors.LabelControl();
            this.labelNhomNV = new DevExpress.XtraEditors.LabelControl();
            this.applicationMenu1 = new DevExpress.XtraBars.Ribbon.ApplicationMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.btnFormEmployee,
            this.btnExit,
            this.btnSupplies,
            this.btnWarehouse,
            this.btnCreateAcc,
            this.btnLapDonDatHang,
            this.barButtonItem2,
            this.barButtonItem1,
            this.btnInDanhMucVatTu,
            this.btnInDanhSachNhanVien,
            this.btnInBangKeChiTietSoLuong_TriGiaHangNhapHoacXuat,
            this.btnInDanhSachCacDonDatHangChuaCoPhieuNhap,
            this.btnBaoCaoTinhHinhHoatDongCua1NhanVien,
            this.btnTongHopNhapXuat});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ribbon.MaxItemId = 21;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2,
            this.ribbonPage3});
            this.ribbon.Size = new System.Drawing.Size(1224, 179);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Above;
            // 
            // btnFormEmployee
            // 
            this.btnFormEmployee.Caption = "Nhân viên";
            this.btnFormEmployee.Glyph = ((System.Drawing.Image)(resources.GetObject("btnFormEmployee.Glyph")));
            this.btnFormEmployee.Id = 2;
            this.btnFormEmployee.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnFormEmployee.LargeGlyph")));
            this.btnFormEmployee.Name = "btnFormEmployee";
            this.btnFormEmployee.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFormEmployee_ItemClick);
            // 
            // btnExit
            // 
            this.btnExit.Caption = "Đăng xuất";
            this.btnExit.Glyph = ((System.Drawing.Image)(resources.GetObject("btnExit.Glyph")));
            this.btnExit.Id = 7;
            this.btnExit.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnExit.LargeGlyph")));
            this.btnExit.Name = "btnExit";
            this.btnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExit_ItemClick);
            // 
            // btnSupplies
            // 
            this.btnSupplies.Caption = "Vật tư";
            this.btnSupplies.Id = 9;
            this.btnSupplies.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSupplies.LargeGlyph")));
            this.btnSupplies.Name = "btnSupplies";
            this.btnSupplies.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSupplies_ItemClick);
            // 
            // btnWarehouse
            // 
            this.btnWarehouse.Caption = "Kho";
            this.btnWarehouse.Id = 10;
            this.btnWarehouse.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnWarehouse.LargeGlyph")));
            this.btnWarehouse.Name = "btnWarehouse";
            this.btnWarehouse.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnWarehouse_ItemClick);
            // 
            // btnCreateAcc
            // 
            this.btnCreateAcc.Caption = "Tạo tài khoản";
            this.btnCreateAcc.Id = 11;
            this.btnCreateAcc.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCreateAcc.LargeGlyph")));
            this.btnCreateAcc.Name = "btnCreateAcc";
            this.btnCreateAcc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCreateAcc_ItemClick);
            // 
            // btnLapDonDatHang
            // 
            this.btnLapDonDatHang.Caption = "Lập đơn đặt hàng";
            this.btnLapDonDatHang.Glyph = ((System.Drawing.Image)(resources.GetObject("btnLapDonDatHang.Glyph")));
            this.btnLapDonDatHang.Id = 12;
            this.btnLapDonDatHang.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnLapDonDatHang.LargeGlyph")));
            this.btnLapDonDatHang.Name = "btnLapDonDatHang";
            this.btnLapDonDatHang.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLapDonDatHang_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Lập phiếu nhập";
            this.barButtonItem2.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.Glyph")));
            this.barButtonItem2.Id = 13;
            this.barButtonItem2.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.LargeGlyph")));
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Lập phiếu xuất";
            this.barButtonItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.Glyph")));
            this.barButtonItem1.Id = 14;
            this.barButtonItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.LargeGlyph")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // btnInDanhMucVatTu
            // 
            this.btnInDanhMucVatTu.Caption = "In danh mục vật tư";
            this.btnInDanhMucVatTu.Glyph = ((System.Drawing.Image)(resources.GetObject("btnInDanhMucVatTu.Glyph")));
            this.btnInDanhMucVatTu.Id = 15;
            this.btnInDanhMucVatTu.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnInDanhMucVatTu.LargeGlyph")));
            this.btnInDanhMucVatTu.Name = "btnInDanhMucVatTu";
            this.btnInDanhMucVatTu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnInDanhMucVatTu_ItemClick);
            // 
            // btnInDanhSachNhanVien
            // 
            this.btnInDanhSachNhanVien.Caption = "In danh sách nhân viên";
            this.btnInDanhSachNhanVien.Id = 16;
            this.btnInDanhSachNhanVien.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnInDanhSachNhanVien.LargeGlyph")));
            this.btnInDanhSachNhanVien.Name = "btnInDanhSachNhanVien";
            this.btnInDanhSachNhanVien.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnInDanhSachNhanVien_ItemClick);
            // 
            // btnInBangKeChiTietSoLuong_TriGiaHangNhapHoacXuat
            // 
            this.btnInBangKeChiTietSoLuong_TriGiaHangNhapHoacXuat.Caption = "In Bảng kê chi tiết số lượng – trị giá hàng nhập hoặc xuất";
            this.btnInBangKeChiTietSoLuong_TriGiaHangNhapHoacXuat.Id = 17;
            this.btnInBangKeChiTietSoLuong_TriGiaHangNhapHoacXuat.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnInBangKeChiTietSoLuong_TriGiaHangNhapHoacXuat.LargeGlyph")));
            this.btnInBangKeChiTietSoLuong_TriGiaHangNhapHoacXuat.Name = "btnInBangKeChiTietSoLuong_TriGiaHangNhapHoacXuat";
            // 
            // btnInDanhSachCacDonDatHangChuaCoPhieuNhap
            // 
            this.btnInDanhSachCacDonDatHangChuaCoPhieuNhap.Caption = "In Danh sách các đơn đặt hàng chưa có phiếu nhập";
            this.btnInDanhSachCacDonDatHangChuaCoPhieuNhap.Id = 18;
            this.btnInDanhSachCacDonDatHangChuaCoPhieuNhap.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnInDanhSachCacDonDatHangChuaCoPhieuNhap.LargeGlyph")));
            this.btnInDanhSachCacDonDatHangChuaCoPhieuNhap.Name = "btnInDanhSachCacDonDatHangChuaCoPhieuNhap";
            // 
            // btnBaoCaoTinhHinhHoatDongCua1NhanVien
            // 
            this.btnBaoCaoTinhHinhHoatDongCua1NhanVien.Caption = "Báo cáo tình hình hoạt động của 1 nhân viên";
            this.btnBaoCaoTinhHinhHoatDongCua1NhanVien.Id = 19;
            this.btnBaoCaoTinhHinhHoatDongCua1NhanVien.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnBaoCaoTinhHinhHoatDongCua1NhanVien.LargeGlyph")));
            this.btnBaoCaoTinhHinhHoatDongCua1NhanVien.Name = "btnBaoCaoTinhHinhHoatDongCua1NhanVien";
            // 
            // btnTongHopNhapXuat
            // 
            this.btnTongHopNhapXuat.Caption = "Tổng hợp nhập xuất";
            this.btnTongHopNhapXuat.Id = 20;
            this.btnTongHopNhapXuat.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnTongHopNhapXuat.LargeGlyph")));
            this.btnTongHopNhapXuat.Name = "btnTongHopNhapXuat";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Menu";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowMinimize = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.btnFormEmployee);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnSupplies);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnWarehouse);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnCreateAcc);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnExit);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Báo cáo";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnInDanhSachNhanVien);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnInDanhMucVatTu);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnInBangKeChiTietSoLuong_TriGiaHangNhapHoacXuat);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnInDanhSachCacDonDatHangChuaCoPhieuNhap);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnBaoCaoTinhHinhHoatDongCua1NhanVien);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnTongHopNhapXuat);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "Nghiệp vụ";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnLapDonDatHang);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 649);
            this.ribbonStatusBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1224, 35);
            // 
            // labelMaNV
            // 
            this.labelMaNV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelMaNV.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMaNV.Location = new System.Drawing.Point(14, 653);
            this.labelMaNV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelMaNV.Name = "labelMaNV";
            this.labelMaNV.Size = new System.Drawing.Size(112, 23);
            this.labelMaNV.TabIndex = 2;
            this.labelMaNV.Text = "Mã nhân viên";
            // 
            // labelTenNV
            // 
            this.labelTenNV.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelTenNV.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTenNV.Location = new System.Drawing.Point(460, 653);
            this.labelTenNV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelTenNV.Name = "labelTenNV";
            this.labelTenNV.Size = new System.Drawing.Size(32, 23);
            this.labelTenNV.TabIndex = 3;
            this.labelTenNV.Text = "Tên";
            // 
            // labelNhomNV
            // 
            this.labelNhomNV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNhomNV.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNhomNV.Location = new System.Drawing.Point(983, 653);
            this.labelNhomNV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelNhomNV.Name = "labelNhomNV";
            this.labelNhomNV.Size = new System.Drawing.Size(49, 23);
            this.labelNhomNV.TabIndex = 4;
            this.labelNhomNV.Text = "Nhóm";
            // 
            // applicationMenu1
            // 
            this.applicationMenu1.Name = "applicationMenu1";
            this.applicationMenu1.Ribbon = this.ribbon;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 684);
            this.ControlBox = false;
            this.Controls.Add(this.labelNhomNV);
            this.Controls.Add(this.labelTenNV);
            this.Controls.Add(this.labelMaNV);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem btnFormEmployee;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraEditors.LabelControl labelMaNV;
        private DevExpress.XtraEditors.LabelControl labelTenNV;
        private DevExpress.XtraEditors.LabelControl labelNhomNV;
        private DevExpress.XtraBars.BarButtonItem btnExit;
        private DevExpress.XtraBars.BarButtonItem btnSupplies;
        private DevExpress.XtraBars.BarButtonItem btnWarehouse;
        private DevExpress.XtraBars.BarButtonItem btnCreateAcc;
        private DevExpress.XtraBars.Ribbon.ApplicationMenu applicationMenu1;
        private DevExpress.XtraBars.BarButtonItem btnLapDonDatHang;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem btnInDanhMucVatTu;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem btnInDanhSachNhanVien;
        private DevExpress.XtraBars.BarButtonItem btnInBangKeChiTietSoLuong_TriGiaHangNhapHoacXuat;
        private DevExpress.XtraBars.BarButtonItem btnInDanhSachCacDonDatHangChuaCoPhieuNhap;
        private DevExpress.XtraBars.BarButtonItem btnBaoCaoTinhHinhHoatDongCua1NhanVien;
        private DevExpress.XtraBars.BarButtonItem btnTongHopNhapXuat;
    }
}