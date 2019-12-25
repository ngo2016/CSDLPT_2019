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

namespace QLVT_DATHANG.SubForm
{
    public partial class LapDonDatHang : DevExpress.XtraEditors.XtraForm
    {
        public LapDonDatHang()
        {
            InitializeComponent();

            this.labelMaNV.Text = "MÃ NHÂN VIÊN: " + Program.username;
            this.labelTenNV.Text = "TÊN: " + Program.hoten;
            this.labelNhomNV.Text = "NHÓM: " + Program.group;
        }

        private void datHangBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.datHangBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.cN1);
        }

        private void LapDonDatHang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cN1.DatHang' table. You can move, or remove it, as needed.
            this.datHangTableAdapter.Fill(this.cN1.DatHang);
            //tắt kiểm tra ràng buộc trước để tránh load lỗi  khi mã nhân viên không có
            cN1.EnforceConstraints = false;

            //thay đổi connectionstring để phù hợp với tài khoản mới khi chuyển chi nhánh or đăng nhập lại
            this.v_DS_PHANMANHTableAdapter1.Fill(this.qLVT_DATHANGDataSet.V_DS_PHANMANH);

            //thay đổi connectionstring để phù hợp với tài khoản mới khi chuyển chi nhánh or đăng nhập lại
            this.v_DS_NhanVienTableAdapter.Connection.ConnectionString = Program.connectString;
            this.v_DS_NhanVienTableAdapter.Fill(this.cN1.V_DS_NhanVien);

            //thay đổi connectionstring để phù hợp với tài khoản mới khi chuyển chi nhánh or đăng nhập lại
            this.vattuTableAdapter.Connection.ConnectionString = Program.connectString;
            this.vattuTableAdapter.Fill(this.cN1.Vattu);

            //thay đổi connectionstring để phù hợp với tài khoản mới khi chuyển chi nhánh or đăng nhập lại
            this.datHangTableAdapter.Connection.ConnectionString = Program.connectString;
            this.datHangTableAdapter.Fill(this.cN1.DatHang);

            //thay đổi connectionstring để phù hợp với tài khoản mới khi chuyển chi nhánh or đăng nhập lại
            this.khoTableAdapter.Connection.ConnectionString = Program.connectString;
            this.khoTableAdapter.Fill(this.cN1.Kho);

            //thay đổi connectionstring để phù hợp với tài khoản mới khi chuyển chi nhánh or đăng nhập lại
            this.nhanVienTableAdapter.Connection.ConnectionString = Program.connectString;
            this.nhanVienTableAdapter.Fill(this.cN1.NhanVien);

            //thay đổi connectionstring để phù hợp với tài khoản mới khi chuyển chi nhánh or đăng nhập lại
            this.cTDDHTableAdapter.Connection.ConnectionString = Program.connectString;
            this.cTDDHTableAdapter.Fill(this.cN1.CTDDH);

            //bật lại kiểm tra ràng buộc
            cN1.EnforceConstraints = true;
        }

        private void hoTenComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                maNVTextEdit.Text = hoTenComboBox.SelectedValue.ToString();
            }
            catch (Exception)
            {
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Program.mainForm.Visible = true;
            this.Visible = false;
        }

        private void maNVTextEdit_TextChanged(object sender, EventArgs e)
        {
            //thay doi ten nhan vien trong combobox khi ma nhan vien thay doi
            //xu ly khi nhan vao row trong table don dat hang
            try
            {
                string manv = this.maNVTextEdit.Text;
                this.hoTenComboBox.SelectedValue = int.Parse(manv);
            }
            catch (Exception)
            {

            }
        }

        private void tenCNComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //khi load form cac index thay doi
            //khi thay đổi có cái = null nên sẽ không thể tostring đc
            Program.servername = this.tenCNComboBox.SelectedValue != null ? this.tenCNComboBox.SelectedValue.ToString() : "null";
            if (Program.servername == "null")
            {
                return;
            }

            if (Program.serverLogin != Program.remoteLogin)
            {
                Program.serverLogin = Program.remoteLogin;
                Program.password = Program.remotePassword;
                Program.connectString = "Data Source=" + Program.servername + ";Initial Catalog=" +
                          Program.database + ";User ID=" +
                          Program.serverLogin + ";password=" + Program.password;
            }
            try
            {
                //tắt kiểm tra ràng buộc trước để tránh load lỗi  khi mã nhân viên không có
                cN1.EnforceConstraints = false;

                //thay đổi connectionstring để phù hợp với tài khoản mới khi chuyển chi nhánh or đăng nhập lại
                this.v_DS_PHANMANHTableAdapter1.Fill(this.qLVT_DATHANGDataSet.V_DS_PHANMANH);

                //thay đổi connectionstring để phù hợp với tài khoản mới khi chuyển chi nhánh or đăng nhập lại
                this.v_DS_NhanVienTableAdapter.Connection.ConnectionString = Program.connectString;
                this.v_DS_NhanVienTableAdapter.Fill(this.cN1.V_DS_NhanVien);

                //thay đổi connectionstring để phù hợp với tài khoản mới khi chuyển chi nhánh or đăng nhập lại
                this.vattuTableAdapter.Connection.ConnectionString = Program.connectString;
                this.vattuTableAdapter.Fill(this.cN1.Vattu);

                //thay đổi connectionstring để phù hợp với tài khoản mới khi chuyển chi nhánh or đăng nhập lại
                this.datHangTableAdapter.Connection.ConnectionString = Program.connectString;
                this.datHangTableAdapter.Fill(this.cN1.DatHang);

                //thay đổi connectionstring để phù hợp với tài khoản mới khi chuyển chi nhánh or đăng nhập lại
                this.khoTableAdapter.Connection.ConnectionString = Program.connectString;
                this.khoTableAdapter.Fill(this.cN1.Kho);

                //thay đổi connectionstring để phù hợp với tài khoản mới khi chuyển chi nhánh or đăng nhập lại
                this.nhanVienTableAdapter.Connection.ConnectionString = Program.connectString;
                this.nhanVienTableAdapter.Fill(this.cN1.NhanVien);

                //thay đổi connectionstring để phù hợp với tài khoản mới khi chuyển chi nhánh or đăng nhập lại
                this.cTDDHTableAdapter.Connection.ConnectionString = Program.connectString;
                this.cTDDHTableAdapter.Fill(this.cN1.CTDDH);

                //bật lại kiểm tra ràng buộc
                cN1.EnforceConstraints = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối Server thất bại! " + ex.Message, "Notification", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //tắt kiểm tra ràng buộc trước để tránh load lỗi  khi mã nhân viên không có
            cN1.EnforceConstraints = false;

            //thay đổi connectionstring để phù hợp với tài khoản mới khi chuyển chi nhánh or đăng nhập lại
            this.v_DS_NhanVienTableAdapter.Connection.ConnectionString = Program.connectString;
            this.v_DS_NhanVienTableAdapter.Fill(this.cN1.V_DS_NhanVien);

            //thay đổi connectionstring để phù hợp với tài khoản mới khi chuyển chi nhánh or đăng nhập lại
            this.vattuTableAdapter.Connection.ConnectionString = Program.connectString;
            this.vattuTableAdapter.Fill(this.cN1.Vattu);

            //thay đổi connectionstring để phù hợp với tài khoản mới khi chuyển chi nhánh or đăng nhập lại
            this.datHangTableAdapter.Connection.ConnectionString = Program.connectString;
            this.datHangTableAdapter.Fill(this.cN1.DatHang);

            //thay đổi connectionstring để phù hợp với tài khoản mới khi chuyển chi nhánh or đăng nhập lại
            this.khoTableAdapter.Connection.ConnectionString = Program.connectString;
            this.khoTableAdapter.Fill(this.cN1.Kho);

            //thay đổi connectionstring để phù hợp với tài khoản mới khi chuyển chi nhánh or đăng nhập lại
            this.nhanVienTableAdapter.Connection.ConnectionString = Program.connectString;
            this.nhanVienTableAdapter.Fill(this.cN1.NhanVien);

            //thay đổi connectionstring để phù hợp với tài khoản mới khi chuyển chi nhánh or đăng nhập lại
            this.cTDDHTableAdapter.Connection.ConnectionString = Program.connectString;
            this.cTDDHTableAdapter.Fill(this.cN1.CTDDH);

            //bật lại kiểm tra ràng buộc
            cN1.EnforceConstraints = true;
        }

        private void khoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                maKhoTextEdit.Text = khoComboBox.SelectedValue.ToString();
            }
            catch (Exception)
            {
            }
        }

        private void maKhoTextEdit_TextChanged(object sender, EventArgs e)
        {
            //thay doi ten nhan vien trong combobox khi ma nhan vien thay doi
            //xu ly khi nhan vao row trong table don dat hang
            try
            {
                string makho = this.maKhoTextEdit.Text;
                this.khoComboBox.SelectedValue = makho;
            }
            catch (Exception)
            {

            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (cTDDHBindingSource.Count > 0)
            {
                MessageBox.Show("Đơn đặt hàng đã có chi tiết đơn. Xin vui lòng xoá chi tiết đơn trước.", "Lỗi", MessageBoxButtons.OK);
            }
        }
    }
}