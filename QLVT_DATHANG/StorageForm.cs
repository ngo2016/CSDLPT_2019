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
    public partial class StorageForm : DevExpress.XtraEditors.XtraForm
    {
        private static string oldKhoData = null;

        private static Stack<string> _maKho = new Stack<string>();
        private static Stack<string> _tenKho = new Stack<string>();
        private static Stack<string> _diaChi = new Stack<string>();
        private static Stack<string> _maCN = new Stack<string>();

        public StorageForm()
        {
            InitializeComponent();

            this.labelMaNV.Text = "MÃ NHÂN VIÊN: " + Program.username;
            this.labelTenNV.Text = "TÊN: " + Program.hoten;
            this.labelNhomNV.Text = "NHÓM: " + Program.group;

            // Phân quyền login
            if (Program.group == "USER")
            {
                this.btnAddStorage.Enabled = false;
            }
            else if (Program.group == "CHINHANH")
            {

            }
            else if (Program.group == "CONGTY")
            {
                this.btnAddStorage.Enabled = false;
                this.btnDelStorage.Enabled = false;
                this.btnUndo.Enabled = false;
                this.btnSaveStorage.Enabled = false;
                this.tenCNComboBox.Enabled = true;
            }
        }

        private void StorageForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cN1.Kho' table. You can move, or remove it, as needed.
            this.khoTableAdapter.Fill(this.cN1.Kho);
            // TODO: This line of code loads data into the 'qLVT_DATHANGDataSet.V_DS_PHANMANH' table. You can move, or remove it, as needed.
            this.v_DS_PHANMANHTableAdapter.Fill(this.qLVT_DATHANGDataSet.V_DS_PHANMANH);

            this.tenCNComboBox.SelectedValue = Program.servername;
            oldKhoData = getKhoCurrentData();
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnSaveStorage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Program.checkValidate(tenKhoTextEdit, "Field tên kho không được để trống!")) return;
            if (!Program.checkValidate(diaChiTextEdit, "Field địa chỉ không được để trống!")) return;

            // lay thong tin kho hien tai
            string makho = this.maKhoTextEdit.Text;
            string tenkho = this.tenKhoTextEdit.Text;
            string diachi = this.diaChiTextEdit.Text;
            string macn = this.maCNTextEdit.Text;

            // thuc thi sp de update kho
            SqlCommand sqlcmd = new SqlCommand("sp_updatekho", Program.connect);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.Add("@MAKHO", SqlDbType.NChar).Value = makho;
            sqlcmd.Parameters.Add("@TENKHO", SqlDbType.NVarChar).Value = tenkho;
            sqlcmd.Parameters.Add("@DIACHI", SqlDbType.NVarChar).Value = diachi;
            sqlcmd.Parameters.Add("@MACN", SqlDbType.NChar).Value = macn;
            Program.execStoreProcedure(sqlcmd);

            // xem du lieu hien tai co thay doi gi so voi du lieu tai thoi diem truoc khi thay doi khong
            string newKhoData = makho + "," + tenkho + "," + diachi + "," + macn;
            // neu du lieu thay doi ta thuc hien push du lieu cu vao stack
            try
            {
                if (oldKhoData != newKhoData)
                {
                    string[] arrayOldKhoData = oldKhoData.Split(',');
                    //lưu lại dữ liệu để undo
                    _maKho.Push(arrayOldKhoData[0]);
                    _tenKho.Push(arrayOldKhoData[1]);
                    _diaChi.Push(arrayOldKhoData[2]);
                    _maCN.Push(arrayOldKhoData[3]);

                    oldKhoData = newKhoData;
                }
                this.btnReload.PerformClick();
            }
            catch (Exception)
            {
            }
            MessageBox.Show("Đã lưu thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            //thay đổi connectionstring để phù hợp với tài khoản mới khi chuyển chi nhánh or đăng nhập lại
            this.khoTableAdapter.Connection.ConnectionString = Program.connectString;
            this.khoTableAdapter.Fill(this.cN1.Kho);
        }

        public string getKhoCurrentData()
        {
            string chuoi = null;

            string makho = this.maKhoTextEdit.Text;
            string tenkho = this.tenKhoTextEdit.Text;
            string diachi = this.diaChiTextEdit.Text;
            string macn = this.maCNTextEdit.Text;

            chuoi = makho + "," + tenkho + "," + diachi + "," + macn;

            return chuoi;
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string makho = _maKho.Pop();
                string tenkho = _tenKho.Pop();
                string diachi = _diaChi.Pop();
                string macn = _maCN.Pop();

                SqlCommand sqlcmd = new SqlCommand("sp_updatekho", Program.connect);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.Add("@MAKHO", SqlDbType.NChar).Value = makho;
                sqlcmd.Parameters.Add("@TENKHO", SqlDbType.NVarChar).Value = tenkho;
                sqlcmd.Parameters.Add("@DIACHI", SqlDbType.NVarChar).Value = diachi;
                sqlcmd.Parameters.Add("@MACN", SqlDbType.NChar).Value = macn;

                Program.execStoreProcedure(sqlcmd);

                this.btnReload.PerformClick();
            }
            catch (Exception)
            {
            }
        }

        private void tenKhoTextEdit_Enter(object sender, EventArgs e)
        {
            oldKhoData = getKhoCurrentData();
        }

        private void diaChiTextEdit_Enter(object sender, EventArgs e)
        {
            oldKhoData = getKhoCurrentData();
        }

        private void StorageForm_VisibleChanged(object sender, EventArgs e)
        {
            this.btnReload.PerformClick();
        }

        private void khoGridControl_MouseDown(object sender, MouseEventArgs e)
        {
            this.tenKhoTextEdit.Focus();
        }

        private void btnDelStorage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Kho sẽ bị xóa! \nBạn có chắn chắn muốn xóa?", "Cảnh báo",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.No)
            {
                return;
            }
            else if (dr == DialogResult.Yes)
            {
                MessageBox.Show("Kho đã bị xóa!", "Thông báo",
                             MessageBoxButtons.OK, MessageBoxIcon.Information);

                string cmd = "EXEC sp_xoakho '" + this.maKhoTextEdit.Text + "'";
                SqlCommand sqlcmd = new SqlCommand(cmd, Program.connect);
                sqlcmd.CommandType = CommandType.Text;
                Program.execStoreProcedure(sqlcmd);
                btnReload.PerformClick();
            }
        }

        private void btnAddStorage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Program.addStorageForm = new SubForm.ThemKho();
            Program.addStorageForm.ShowDialog(this);
        }

        private void tenCNCNComboBox_SelectedIndexChanged(object sender, EventArgs e)
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
                MessageBox.Show("Kết nối Server thất bại! " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void StorageForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Visible = false;
            Program.mainForm.Visible = true;
        }
    }
}