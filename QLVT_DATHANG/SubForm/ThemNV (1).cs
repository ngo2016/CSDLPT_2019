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
    public partial class ThemNV : DevExpress.XtraEditors.XtraForm
    {
        public ThemNV()
        {
            InitializeComponent();
            int chiNhanh = Program.chiNhanh == 0 ? 1 : 2;
            this.textEditThemMaCN.Text = "CN" + chiNhanh;
        }
        
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.employeeForm.Visible = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string manv = this.numericThemMaNV.Text;
            string ho = this.textEditThemHoNV.Text;
            string ten = this.textEditThemTenNV.Text;
            string diaChi = this.textEditThemDiaChi.Text;
            DateTime ngaySinh = this.dateTimePicker1.Value;
            string ngaysinh = ngaySinh.Year.ToString() + "-" + ngaySinh.Month.ToString() + "-" + ngaySinh.Day.ToString();
            string macn = this.textEditThemMaCN.Text;
            decimal luong = this.numericLuong.Value;
            string xoa = this.textEditThemTrangThai.Text;

            //kiem tra xem trong db co ma nhan vien nay hay chua
            SqlCommand kiemtratontai = new SqlCommand("sp_KiemTraNhanVienTonTai", Program.connect);
            kiemtratontai.CommandType = CommandType.StoredProcedure;
            kiemtratontai.Parameters.Add("@MANV", SqlDbType.Int).Value = manv;
            if (Program.execStoreProcedureWithReturnValue(kiemtratontai) == 1)
            {
                MessageBox.Show("Đã tồn tại mã nhân viên " + manv);
                return;
            }
            
            //neu chua ton tai trong he thong ta se tao nhan vien
            SqlCommand sqlcmd = new SqlCommand("sp_taonhanvien", Program.connect);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.Add("@MANV", SqlDbType.Int).Value = manv;
            sqlcmd.Parameters.Add("@HO", SqlDbType.NVarChar).Value = ho;
            sqlcmd.Parameters.Add("@TEN", SqlDbType.NVarChar).Value = ten;
            sqlcmd.Parameters.Add("@DIACHI", SqlDbType.NVarChar).Value = diaChi;
            sqlcmd.Parameters.Add("@NGAYSINH", SqlDbType.DateTime).Value = ngaysinh;
            sqlcmd.Parameters.Add("@LUONG", SqlDbType.Float).Value = luong;
            sqlcmd.Parameters.Add("@MACN", SqlDbType.NChar).Value = macn;
            sqlcmd.Parameters.Add("@TrangThaiXoa", SqlDbType.Int).Value = xoa;
            Program.execStoreProcedure(sqlcmd);

            this.Visible = false;
            Program.employeeForm.Visible = true;
        }

        private void textEditThemHoNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)//nút enter
            {
                if (!(Program.isEmpty(this.textEditThemHoNV)))
                {
                    this.textEditThemHoNV.Text = Program.RemoveSpecialCharacters(this.textEditThemHoNV.Text);
                    this.textEditThemTenNV.Focus();
                }
            }
        }

        private void textEditThemTenNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)//nút enter
            {
                if (!(Program.isEmpty(this.textEditThemTenNV)))
                {
                    this.textEditThemTenNV.Text = Program.RemoveSpecialCharacters(this.textEditThemTenNV.Text);
                    this.numericThemMaNV.Focus();
                }
            }
        }

        private void textEditThemDiaChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)//nút enter
            {
                if (!(Program.isEmpty(this.textEditThemDiaChi)))
                {
                    this.textEditThemDiaChi.Text = Program.RemoveSpecialCharacters(this.textEditThemDiaChi.Text);
                    this.numericLuong.Focus();
                }
            }
        }

        private void numericThemMaNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)//nút enter
            {
                this.textEditThemDiaChi.Focus();
            }
        }

    }
}