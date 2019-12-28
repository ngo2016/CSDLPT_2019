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

namespace QLVT_DATHANG
{
    public partial class EmployeeForm : DevExpress.XtraEditors.XtraForm
    {
        private static Stack<string> _maNV = new Stack<string>();
        private static Stack<string> _ho = new Stack<string>();
        private static Stack<string> _ten = new Stack<string>();
        private static Stack<string> _diaChi = new Stack<string>();
        private static Stack<string> _ngaySinh = new Stack<string>();
        private static Stack<decimal> _luong = new Stack<decimal>();
        private static Stack<string> _xoa = new Stack<string>();

        private static string oldNVData = null;

        private static bool canUpdate = false;

        public EmployeeForm()
        {
            InitializeComponent();

            this.labelMaNV.Text = "MÃ NHÂN VIÊN: " + Program.username;
            this.labelTenNV.Text = "TÊN: " + Program.hoten;
            this.labelNhomNV.Text = "NHÓM: " + Program.group;

            // Phân quyền login
            if (Program.group == "USER")
            {
                this.addButton.Enabled = false;
                this.btnMove.Enabled = false;
            }
            else if (Program.group == "CHINHANH")
            {

            }
            else if (Program.group == "CONGTY")
            {
                this.addButton.Enabled = false;
                this.eraseButton.Enabled = false;
                this.undoButton.Enabled = false;
                this.writeButton.Enabled = false;
                this.tenChiNhanhComboBox.Enabled = true;
                this.btnMove.Enabled = false;
            }
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            //tắt kiểm tra ràng buộc trước để tránh load lỗi  khi mã nhân viên không có
            cN1.EnforceConstraints = false;
            this.v_DS_PHANMANHTableAdapter.Fill(this.qLVT_DATHANGDataSet.V_DS_PHANMANH);
            // TODO: This line of code loads data into the 'cN1.NhanVien' table. You can move, or remove it, as needed.
            this.nhanVienTableAdapter.Fill(this.cN1.NhanVien);
            // TODO khi thay doi chi nhanh thi fill nhanVienTableAdapter voi this.cN2.NhanVien

            // TODO: This line of code loads data into the 'cN1.PhieuNhap' table. You can move, or remove it, as needed.
            this.phieuNhapTableAdapter.Fill(this.cN1.PhieuNhap);
            // TODO: This line of code loads data into the 'cN1.PhieuXuat' table. You can move, or remove it, as needed.
            this.phieuXuatTableAdapter.Fill(this.cN1.PhieuXuat);
            // TODO: This line of code loads data into the 'cN1.DatHang' table. You can move, or remove it, as needed.
            this.datHangTableAdapter.Fill(this.cN1.DatHang);
            this.tenChiNhanhComboBox.SelectedValue = Program.servername;
            oldNVData = getNVCurrentData();
        }

        private void exitButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void reloadButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //thay đổi connectionstring để phù hợp với tài khoản mới khi chuyển chi nhánh or đăng nhập lại
            this.nhanVienTableAdapter.Connection.ConnectionString = Program.connectString;
            // TODO: This line of code loads data into the 'cN1.NhanVien' table. You can move, or remove it, as needed.
            this.nhanVienTableAdapter.Fill(this.cN1.NhanVien);
        }

        private void addButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Program.addEmployeeForm = new SubForm.ThemNV();
            Program.addEmployeeForm.ShowDialog(this);
        }

        private void tenChiNhanhComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //khi load form cac index thay doi
            //khi thay đổi có cái = null nên sẽ không thể tostring đc
            string server = this.tenChiNhanhComboBox.SelectedValue != null ? this.tenChiNhanhComboBox.SelectedValue.ToString() : "null";
            Program.chuyenChiNhanh(server);

            try
            {
                this.reloadButton.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối Server thất bại! " + ex.StackTrace, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void eraseButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.trangThaiXoaTextEdit.Text == "1")
            {
                MessageBox.Show("Nhân viên đã bị xóa rồi. Xin vui lòng không xoá nữa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (phieuNhapBindingSource.Count > 0)
            {
                MessageBox.Show("Nhân viên đã lập phiếu nhập. Xin vui lòng xoá phiếu nhập trước.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (phieuXuatBindingSource.Count > 0)
            {
                MessageBox.Show("Nhân viên đã lập phiếu xuất. Xin vui lòng xoá phiếu xuất trước.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (datHangBindingSource.Count > 0)
            {
                MessageBox.Show("Nhân viên đã lập phiếu đơn đặt hàng. Xin vui lòng xoá đơn đặt hàng trước.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dr = MessageBox.Show("Nhân viên sẽ bị xóa! \nBạn có chắn chắn muốn xóa?", "Cảnh báo",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.No)
                {
                    return;
                }
                else if (dr == DialogResult.Yes)
                {
                    MessageBox.Show("Nhân viên đã bị xóa!", "Thông báo",
                                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.trangThaiXoaTextEdit.Text = "1";
                }
            }
        }

        public String getDateTimeString(DateTime dateTime)
        {
            return dateTime.Year.ToString() + "-" + dateTime.Month.ToString() + "-" + dateTime.Day.ToString();
        }

        public void updateNhanVien()
        {
            if (!Program.checkValidate(hoTextEdit, "Field họ không được để trống!")) return;
            if (!Program.checkValidate(tenTextEdit, "Field tên không được để trống!")) return;
            if (!Program.checkValidate(diaChiTextEdit, "Field địa chỉ không được để trống!")) return;
            if (luongSpinEdit.Value < 4000000)
            {
                MessageBox.Show("Lương tối thiểu của nhân viên là 4000000", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                luongSpinEdit.Focus();
                return;
            }

            // lay thong tin nhan vien hien tai
            string manv = this.maNhanVienTextEdit.Text;
            string ho = this.hoTextEdit.Text;
            string ten = this.tenTextEdit.Text;
            string diaChi = this.diaChiTextEdit.Text;
            DateTime ngaySinh = this.ngaySinhDateTImePicker.Value;
            string ngaysinh = getDateTimeString(ngaySinh);
            string macn = this.maChiNhanhComboBoxEdit.Text;
            decimal luong = this.luongSpinEdit.Value;
            string xoa = this.trangThaiXoaTextEdit.Text;

            // thuc thi sp de update nhan vien
            SqlCommand sqlcmd = new SqlCommand("sp_updatenhanvien", Program.connect);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.Add("@MANV", SqlDbType.Int).Value = manv;
            sqlcmd.Parameters.Add("@HO", SqlDbType.NVarChar).Value = ho;
            sqlcmd.Parameters.Add("@TEN", SqlDbType.NVarChar).Value = ten;
            sqlcmd.Parameters.Add("@DIACHI", SqlDbType.NVarChar).Value = diaChi;
            sqlcmd.Parameters.Add("@NGAYSINH", SqlDbType.DateTime).Value = ngaysinh;
            sqlcmd.Parameters.Add("@LUONG", SqlDbType.Float).Value = luong;
            sqlcmd.Parameters.Add("@TrangThaiXoa", SqlDbType.Int).Value = xoa;
            Program.execStoreProcedure(sqlcmd);

            // xem du lieu hien tai co thay doi gi so voi du lieu tai thoi diem truoc khi thay doi khong
            string newNVData = manv + "," + ho + "," + ten + "," + diaChi + "," + ngaysinh + "," + macn + "," + luong.ToString() + "," + xoa;
            // neu du lieu thay doi ta thuc hien push du lieu cu vao stack
            if (oldNVData != newNVData)
            {
                string[] arrayOldNVData = oldNVData.Split(',');
                //lưu lại dữ liệu để undo
                _maNV.Push(arrayOldNVData[0]);
                _ho.Push(arrayOldNVData[1]);
                _ten.Push(arrayOldNVData[2]);
                _diaChi.Push(arrayOldNVData[3]);
                _ngaySinh.Push(arrayOldNVData[4]);
                _luong.Push(decimal.Parse(arrayOldNVData[6]));
                _xoa.Push(arrayOldNVData[7]);

                oldNVData = newNVData;
            }

            canUpdate = true;

            MessageBox.Show("Đã lưu thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void writeButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            updateNhanVien();
            if (canUpdate)
            {
                this.reloadButton.PerformClick();
            }
        }

        private void undoButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string manv = _maNV.Pop();
                string ho = _ho.Pop();
                string ten = _ten.Pop();
                string diachi = _diaChi.Pop();
                string ngaysinh = _ngaySinh.Pop();
                decimal luong = _luong.Pop();
                string xoa = _xoa.Pop();

                SqlCommand sqlcmd = new SqlCommand("sp_updatenhanvien", Program.connect);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.Add("@MANV", SqlDbType.Int).Value = manv;
                sqlcmd.Parameters.Add("@HO", SqlDbType.NVarChar).Value = ho;
                sqlcmd.Parameters.Add("@TEN", SqlDbType.NVarChar).Value = ten;
                sqlcmd.Parameters.Add("@DIACHI", SqlDbType.NVarChar).Value = diachi;
                sqlcmd.Parameters.Add("@NGAYSINH", SqlDbType.DateTime).Value = ngaysinh;
                sqlcmd.Parameters.Add("@LUONG", SqlDbType.Float).Value = luong;
                sqlcmd.Parameters.Add("@TrangThaiXoa", SqlDbType.Int).Value = xoa;

                Program.execStoreProcedure(sqlcmd);

                this.reloadButton.PerformClick();
            }
            catch (Exception ex)
            {
            }
        }

        public string getNVCurrentData()
        {
            string chuoi = null;

            string manv = this.maNhanVienTextEdit.Text;
            string ho = this.hoTextEdit.Text;
            string ten = this.tenTextEdit.Text;
            string diaChi = this.diaChiTextEdit.Text;
            DateTime ngaySinh = this.ngaySinhDateTImePicker.Value;
            string ngaysinh = getDateTimeString(ngaySinh);
            string macn = this.maChiNhanhComboBoxEdit.Text;
            decimal luong = this.luongSpinEdit.Value;
            string xoa = this.trangThaiXoaTextEdit.Text;

            chuoi = manv + "," + ho + "," + ten + "," + diaChi + "," + ngaysinh + "," + macn + "," + luong.ToString() + "," + xoa;

            return chuoi;
        }

        private void maNhanVienTextEdit_Enter(object sender, EventArgs e)
        {
            oldNVData = getNVCurrentData();
        }

        private void hoTextEdit_Enter(object sender, EventArgs e)
        {
            oldNVData = getNVCurrentData();
        }

        private void tenTextEdit_Enter(object sender, EventArgs e)
        {
            oldNVData = getNVCurrentData();
        }

        private void diaChiTextEdit_Enter(object sender, EventArgs e)
        {
            oldNVData = getNVCurrentData();
        }

        private void ngaySinhDateTImePicker_Enter(object sender, EventArgs e)
        {
            oldNVData = getNVCurrentData();
        }

        private void luongSpinEdit_Enter(object sender, EventArgs e)
        {
            oldNVData = getNVCurrentData();
        }

        private void trangThaiXoaTextEdit_Enter(object sender, EventArgs e)
        {
            oldNVData = getNVCurrentData();
        }

        private void EmployeeForm_VisibleChanged(object sender, EventArgs e)
        {
            this.reloadButton.PerformClick();
        }

        private void btnMove_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string manv = this.maNhanVienTextEdit.Text;
            string macn = Program.chiNhanh == 1 ? "CN2" : "CN1";
            SqlCommand sqlcmd = new SqlCommand("sp_chuyenChiNhanhNhanVien", Program.connect);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@MANV", manv);
            sqlcmd.Parameters.AddWithValue("@MACN", macn);
            Program.execStoreProcedure(sqlcmd);
            reloadButton.PerformClick();
        }

        private void luongSpinEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (luongSpinEdit.Value < 4000000)
            {
                this.luongSpinEdit.Value = 4000000;
            }
        }
    }
}