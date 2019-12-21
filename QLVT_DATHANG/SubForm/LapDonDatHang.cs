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

            // Phân quyền login
            if (Program.group == "USER")
            {
                this.btnThem.Enabled = false;
            }
            else if (Program.group == "CHINHANH")
            {

            }
            else if (Program.group == "CONGTY")
            {
                this.btnThem.Enabled = false;
                this.btnXoa.Enabled = false;
                this.btnGhi.Enabled = false;
                this.tenCNComboBox.Enabled = true;
            }
        }

        private void datHangBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.datHangBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.cN1);
        }

        private void LapDonDatHang_Load(object sender, EventArgs e)
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

            this.tenCNComboBox.SelectedValue = Program.servername;

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
            string server = this.tenCNComboBox.SelectedValue != null ? this.tenCNComboBox.SelectedValue.ToString() : "null";
            Program.chuyenChiNhanh(server);
            try
            {
                this.btnReload.PerformClick();
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

        private bool checkValidate(TextEdit tb, string str)
        {
            if (tb.Text.Trim().Equals(""))
            {
                MessageBox.Show(str, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tb.Focus();
                return false;
            }
            return true;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (cTDDHBindingSource.Count > 0)
            {
                MessageBox.Show("Đơn đặt hàng đã có chi tiết đơn. Xin vui lòng xoá chi tiết đơn trước.", "Lỗi", MessageBoxButtons.OK);
            }
            else
            {
                if (!checkValidate(maSoDDHTextEdit, "Field mã số đơn đặt hàng không được để trống!")) return;
                if (!checkValidate(nhaCungCapTextEdit, "Field nhà cung cấp không được để trống!")) return;

                string cmd = "EXEC sp_xoaddh '" + this.maSoDDHTextEdit.Text + "'";
                SqlCommand sqlcmd = new SqlCommand(cmd, Program.connect);
                sqlcmd.CommandType = CommandType.Text;
                Program.execStoreProcedure(sqlcmd);
                btnReload.PerformClick();
            }
        }

        private void btnSubformAdd_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.cTDDHBindingSource.EndEdit();
            this.cTDDHTableAdapter.Update(this.cN1);
            // fill lại dữ liệu cho subform
            this.cTDDHTableAdapter.Fill(this.cN1.CTDDH);
        }

        private void btnSubformWrite_Click(object sender, EventArgs e)
        {
            this.btnSubformAdd.PerformClick();
        }

        private void btnSubformDel_Click(object sender, EventArgs e)
        {
            //xóa phần tử hiện tại trong bảng(con trỏ ở đâu xóa ở đó)
            this.cTDDHBindingSource.RemoveCurrent();
            this.btnSubformAdd.PerformClick();
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string maddh = this.maSoDDHTextEdit.Text;
            DateTime ngaylap = this.ngayLapDateEdit.Value;
            string ngayLap = ngaylap.Year.ToString() + "-" + ngaylap.Month.ToString() + "-" + ngaylap.Day.ToString();
            string nhacc = this.nhaCungCapTextEdit.Text;
            string manv = this.maNVTextEdit.Text;
            string makho = this.maKhoTextEdit.Text;

            //câu lệnh tạo sp để lập đơn đặt hàng
            SqlCommand sqlcmd = new SqlCommand("sp_lapdondathang", Program.connect);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.Add("@MasoDDH", SqlDbType.NChar).Value = maddh;
            sqlcmd.Parameters.Add("@NGAY", SqlDbType.DateTime).Value = ngayLap;
            sqlcmd.Parameters.Add("@NhaCC", SqlDbType.NVarChar).Value = nhacc;
            sqlcmd.Parameters.Add("@MANV", SqlDbType.Int).Value = manv;
            sqlcmd.Parameters.Add("@MAKHO", SqlDbType.NChar).Value = makho;

            int checkIf = Program.execStoreProcedureWithReturnValue(sqlcmd);
            //văng lỗi theo mã
            if (checkIf == 2627)
            {
                MessageBox.Show("Mã đơn đặt hàng đã tồn tại", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            if (checkIf == 547)
            {
                MessageBox.Show("Mã nhân viên hoặc mã kho không tồn tại", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            if (checkIf == 0)
            {
                MessageBox.Show("Thêm đơn đặt hàng thành công", "Xong", MessageBoxButtons.OK);
                this.btnReload.PerformClick();
                return;
            }
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // lay thong tin ddh hien tai
            string maddh = this.maSoDDHTextEdit.Text;
            DateTime ngaylap = this.ngayLapDateEdit.Value;
            string ngayLap = ngaylap.Year.ToString() + "-" + ngaylap.Month.ToString() + "-" + ngaylap.Day.ToString();
            string nhacc = this.nhaCungCapTextEdit.Text;
            string manv = this.maNVTextEdit.Text;
            string makho = this.maKhoTextEdit.Text;

            //câu lệnh tạo sp để update đơn đặt hàng
            SqlCommand sqlcmd = new SqlCommand("sp_updateddh", Program.connect);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.Add("@MasoDDH", SqlDbType.NChar).Value = maddh;
            sqlcmd.Parameters.Add("@NGAY", SqlDbType.Date).Value = ngayLap;
            sqlcmd.Parameters.Add("@NhaCC", SqlDbType.NVarChar).Value = nhacc;
            sqlcmd.Parameters.Add("@MANV", SqlDbType.Int).Value = manv;
            sqlcmd.Parameters.Add("@MAKHO", SqlDbType.NChar).Value = makho;
            Program.execStoreProcedure(sqlcmd);
            this.btnReload.PerformClick();
        }
    }
}