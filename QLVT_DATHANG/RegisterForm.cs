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
    public partial class RegisterForm : DevExpress.XtraEditors.XtraForm
    {
        public RegisterForm()
        {
            InitializeComponent();

            if (Program.group == "CONGTY")
            {
                rdChiNhanh.Enabled = rdUser.Enabled = false;
            }
            else if (Program.group == "CHINHANH")
            {
                rdCongTy.Enabled = false;
            }
        }

        private bool checkValidate(TextBox tb, string str)
        {
            if (tb.Text.Trim().Equals(""))
            {
                MessageBox.Show(str, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tb.Focus();
                return false;
            }
            return true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!checkValidate(tbLogin, "Login name không được để trống!")) return;
            if (!checkValidate(tbPassword, "Password không được để trống!")) return;
            if (!(rdCongTy.Checked || rdChiNhanh.Checked || rdUser.Checked))
            {
                MessageBox.Show("Role không được để trống!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (tbLogin.Text.Contains(" "))
            {
                MessageBox.Show("Login name không được chứa khoảng trắng!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            String role = rdCongTy.Checked ? "CONGTY" : (rdChiNhanh.Checked ? "CHINHANH" : "USER");

            SqlCommand sqlCommand = new SqlCommand("sp_TaoTaiKhoan", Program.connect);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@LGNAME", tbLogin.Text);
            sqlCommand.Parameters.AddWithValue("@PASS", tbPassword.Text);
            sqlCommand.Parameters.AddWithValue("@USERNAME", tbUser.Text);
            sqlCommand.Parameters.AddWithValue("@ROLE", role);

            int result = Program.execStoreProcedureWithReturnValue(sqlCommand);
            if (result == 0)
            {
                MessageBox.Show("Tạo tài khoản thành công!", "Thông báo",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbLogin.Clear();
                tbPassword.Clear();
                rdCongTy.Checked = rdChiNhanh.Checked = rdUser.Checked = false;
                tbLogin.Focus();
            }
            else if (result == 1)
            {
                MessageBox.Show("Login name bị trùng!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (result == 2)
            {
                MessageBox.Show("User đã có login name!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            if (Program.flagCloseRegisterForm == true)
            {
                Program.mainForm.Visible = true;
            }
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            //thay đổi connectionstring để phù hợp với tài khoản mới khi chuyển chi nhánh or đăng nhập lại
            this.v_DS_NhanVienTableAdapter.Connection.ConnectionString = Program.connectString;
            this.v_DS_NhanVienTableAdapter.Fill(this.cN1.V_DS_NhanVien);

        }

        private void cbShow_CheckedChanged(object sender, EventArgs e)
        {
            tbPassword.UseSystemPasswordChar = (cbShow.Checked) ? false : true;
        }

        private void RegisterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool checkNonEmpty = !tbLogin.Text.Equals("") || !tbPassword.Text.Equals("");
            bool checkNonCheck = rdCongTy.Checked || rdChiNhanh.Checked || rdUser.Checked;
            Program.flagCloseRegisterForm = (checkNonEmpty || checkNonCheck) ? false : true;

            if (Program.flagCloseRegisterForm == false)
            {
                DialogResult dr = MessageBox.Show("Dữ liệu Form tạo tài Khoản vẫn chưa được lưu! \nBạn có chắn chắn muốn thoát?", "Cảnh báo",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else if (dr == DialogResult.Yes)
                {
                    Program.flagCloseRegisterForm = true;
                }
            }
        }
    }
}