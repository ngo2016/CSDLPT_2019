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
    public partial class ThemKho : DevExpress.XtraEditors.XtraForm
    {
        public ThemKho()
        {
            InitializeComponent();
            this.textEditThemMaCN.Text = "CN" + Program.chiNhanh;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            if (Program.flagCloseFormThemKho==true)
            {
                Program.storageForm.Visible = true;
            }
        }

        private void textEditThemMaKho_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)//nút enter
            {
                if (!(Program.isEmpty(this.textEditThemMaKho)))
                {
                    this.textEditThemMaKho.Text = Program.RemoveSpecialCharacters(this.textEditThemMaKho.Text);
                    this.textEditThemTenKho.Focus();
                }
            }
        }

        private void textEditThemTenKho_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)//nút enter
            {
                if (!(Program.isEmpty(this.textEditThemTenKho)))
                {
                    this.textEditThemTenKho.Text = Program.RemoveSpecialCharacters(this.textEditThemTenKho.Text);
                    this.textEditThemDiachi.Focus();
                }
            }
        }

        private void textEditThemDiachi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)//nút enter
            {
                if (!(Program.isEmpty(this.textEditThemDiachi)))
                {
                    this.textEditThemDiachi.Text = Program.RemoveSpecialCharacters(this.textEditThemDiachi.Text);
                    this.textEditThemMaCN.Focus();
                }
            }
        }

        private void textEditThemMaCN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)//nút enter
            {
                if (!(Program.isEmpty(this.textEditThemMaCN)))
                {
                    this.textEditThemMaCN.Text = Program.RemoveSpecialCharacters(this.textEditThemMaCN.Text);
                    this.btnSave.PerformClick();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool canUpdate = !textEditThemMaKho.Text.Equals("") && !textEditThemTenKho.Text.Equals("")
                && !textEditThemDiachi.Text.Equals("");

            if (!canUpdate)
            {
                MessageBox.Show("Vui lòng kiểm tra lại các field đã nhập\nCác field không được bỏ trống",
                    "Cảnh báo", MessageBoxButtons.OK);
                return;
            }

            string makho = this.textEditThemMaKho.Text;
            string tenkho = this.textEditThemTenKho.Text;
            string diachi = this.textEditThemDiachi.Text;
            string macn = this.textEditThemMaCN.Text;

            //kiem tra xem trong db co ma vat tu nay hay chua
            SqlCommand kiemtratontai = new SqlCommand("sp_KiemTraKhoTonTai", Program.connect);
            kiemtratontai.CommandType = CommandType.StoredProcedure;
            kiemtratontai.Parameters.Add("@MAKHO", SqlDbType.NChar).Value = makho;
            kiemtratontai.Parameters.Add("@TENKHO", SqlDbType.NVarChar).Value = tenkho;
            if (Program.execStoreProcedureWithReturnValue(kiemtratontai) == 1)
            {
                MessageBox.Show("Đã tồn tại mã kho " + makho);
                return;
            }
            if (Program.execStoreProcedureWithReturnValue(kiemtratontai) == 2)
            {
                MessageBox.Show("Đã tồn tại tên kho " + tenkho);
                return;
            }

            //neu chua ton tai trong he thong ta se tao nhan vien
            SqlCommand sqlcmd = new SqlCommand("sp_themkho", Program.connect);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.Add("@MAKHO", SqlDbType.NChar).Value = makho;
            sqlcmd.Parameters.Add("@TENKHO", SqlDbType.NVarChar).Value = tenkho;
            sqlcmd.Parameters.Add("@DIACHI", SqlDbType.NVarChar).Value = diachi;
            sqlcmd.Parameters.Add("@MACN", SqlDbType.NChar).Value = macn;
            Program.execStoreProcedure(sqlcmd);

            MessageBox.Show("Thêm mới thành công",
                    "Thông báo", MessageBoxButtons.OK);
            this.Visible = false;
            Program.storageForm.Visible = true;
        }

        private void ThemKho_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool checkNonEmpty = !textEditThemMaKho.Text.Equals("") || !textEditThemTenKho.Text.Equals("")
                || !textEditThemDiachi.Text.Equals("");

            Program.flagCloseFormThemKho = checkNonEmpty ? false : true;

            if (Program.flagCloseFormThemKho == false)
            {
                DialogResult dr = MessageBox.Show("Dữ liệu Form thêm kho vẫn chưa được lưu! \nBạn có chắn chắn muốn thoát?", "Cảnh báo",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else if (dr == DialogResult.Yes)
                {
                    Program.flagCloseFormThemKho = true;
                }
            }
        }

        private void ThemKho_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
            if (Program.flagCloseFormThemKho == true)
            {
                Program.storageForm.Visible = true;
            }
        }
    }
}