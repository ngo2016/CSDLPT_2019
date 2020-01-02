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
        //stack để thực hiện chức năng undo
        private static Stack<string> _maNV = new Stack<string>();
        private static Stack<string> _ho = new Stack<string>();
        private static Stack<string> _ten = new Stack<string>();
        private static Stack<string> _diaChi = new Stack<string>();
        private static Stack<string> _ngaySinh = new Stack<string>();
        private static Stack<decimal> _luong = new Stack<decimal>();
        private static Stack<string> _xoa = new Stack<string>();

        private static string oldNVData = null;

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

            this.nhanVienTableAdapter.Fill(this.cN1.NhanVien);

            this.phieuNhapTableAdapter.Fill(this.cN1.PhieuNhap);

            this.phieuXuatTableAdapter.Fill(this.cN1.PhieuXuat);

            this.datHangTableAdapter.Fill(this.cN1.DatHang);

            //set chi nhánh là server name chọn trong combobox đăng nhập (cũng có trong connect string)
            this.tenChiNhanhComboBox.SelectedValue = Program.servername;

            //mới vào thì set old data để tránh bị lỗi null ref
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
            this.nhanVienTableAdapter.Fill(this.cN1.NhanVien);

            //thay đổi connectionstring để phù hợp với tài khoản mới khi chuyển chi nhánh or đăng nhập lại
            this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connectString;
            this.phieuNhapTableAdapter.Fill(this.cN1.PhieuNhap);

            //thay đổi connectionstring để phù hợp với tài khoản mới khi chuyển chi nhánh or đăng nhập lại
            this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connectString;
            this.phieuXuatTableAdapter.Fill(this.cN1.PhieuXuat);

            //thay đổi connectionstring để phù hợp với tài khoản mới khi chuyển chi nhánh or đăng nhập lại
            this.datHangTableAdapter.Connection.ConnectionString = Program.connectString;
            this.datHangTableAdapter.Fill(this.cN1.DatHang);
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
            catch (Exception)
            {
                MessageBox.Show("Kết nối Server thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void eraseButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //cho vào try catch để tránh lỗi null
            try
            {
                if (this.trangThaiXoaTextEdit.Text == "1")
                {
                    MessageBox.Show("Nhân viên đã bị xóa rồi. Xin vui lòng không xoá nữa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
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
                        updateNhanVien();
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        public String getDateTimeString(DateTime dateTime)
        {
            return dateTime.Year.ToString() + "-" + dateTime.Month.ToString() + "-" + dateTime.Day.ToString();
        }

        public void updateNhanVien()
        {
            //chuẩn hóa input
            hoTextEdit.Text = Program.RemoveSpecialCharacters(hoTextEdit.Text);
            tenTextEdit.Text = Program.RemoveSpecialCharacters(tenTextEdit.Text);
            diaChiTextEdit.Text = Program.RemoveSpecialCharacters(diaChiTextEdit.Text);

            //validate rỗng, minvalue
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
                //set lại old data để undo
                oldNVData = newNVData;
            }

            //reload lại dữ liệu ridview
            this.reloadButton.PerformClick();

            MessageBox.Show("Đã lưu thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void writeButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            updateNhanVien();
        }

        private void undoButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //lấy dữ liệu trong stack ra
                string manv = _maNV.Pop();
                string ho = _ho.Pop();
                string ten = _ten.Pop();
                string diachi = _diaChi.Pop();
                string ngaysinh = _ngaySinh.Pop();
                decimal luong = _luong.Pop();
                string xoa = _xoa.Pop();

                //update lại vào trong db
                SqlCommand sqlcmd = new SqlCommand("sp_updatenhanvien", Program.connect);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.Add("@MANV", SqlDbType.Int).Value = manv;
                sqlcmd.Parameters.Add("@HO", SqlDbType.NVarChar).Value = ho;
                sqlcmd.Parameters.Add("@TEN", SqlDbType.NVarChar).Value = ten;
                sqlcmd.Parameters.Add("@DIACHI", SqlDbType.NVarChar).Value = diachi;
                sqlcmd.Parameters.Add("@NGAYSINH", SqlDbType.DateTime).Value = ngaysinh;
                sqlcmd.Parameters.Add("@LUONG", SqlDbType.Float).Value = luong;
                sqlcmd.Parameters.AddWithValue("@TrangThaiXoa", xoa);

                Program.execStoreProcedure(sqlcmd);

                //reload lại dữ liệu ridview
                this.reloadButton.PerformClick();
            }
            catch (Exception)
            {
            }
        }

        //hàm lấy dữ liệu đưa vào stack để undo
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

        private void trangThaiXoaTextEdit_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void maNhanVienTextEdit_TextChanged(object sender, EventArgs e)
        {
            oldNVData = getNVCurrentData();
        }
    }
}