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
    public partial class ProductForm : DevExpress.XtraEditors.XtraForm
    {
        private static string oldVTData = null;

        private static Stack<string> _maVT = new Stack<string>();
        private static Stack<string> _tenVT = new Stack<string>();
        private static Stack<string> _dvt = new Stack<string>();
        private static Stack<int> _soLuongTon = new Stack<int>();

        public ProductForm()
        {
            InitializeComponent();

            this.labelMaNV.Text = "MÃ NHÂN VIÊN: " + Program.username;
            this.labelTenNV.Text = "TÊN: " + Program.hoten;
            this.labelNhomNV.Text = "NHÓM: " + Program.group;

            // Phân quyền login
            if (Program.group == "USER")
            {

            }
            else if (Program.group == "CHINHANH")
            {

            }
            else if (Program.group == "CONGTY")
            {
                this.btnAddProduct.Enabled = false;
                this.btnDelProduct.Enabled = false;
                this.btnUndo.Enabled = false;
                this.btnSaveProduct.Enabled = false;
            }
        }

        private void vattuBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.vattuBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.cN1);

        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cN1.CTDDH' table. You can move, or remove it, as needed.
            this.cTDDHTableAdapter.Fill(this.cN1.CTDDH);
            // TODO: This line of code loads data into the 'cN1.CTPN' table. You can move, or remove it, as needed.
            this.cTPNTableAdapter.Fill(this.cN1.CTPN);
            // TODO: This line of code loads data into the 'cN1.CTPX' table. You can move, or remove it, as needed.
            this.cTPXTableAdapter.Fill(this.cN1.CTPX);
            // TODO: This line of code loads data into the 'cN1.Vattu' table. You can move, or remove it, as needed.
            this.vattuTableAdapter.Fill(this.cN1.Vattu);
            oldVTData = getVTCurrentData();
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.vattuTableAdapter.Fill(this.cN1.Vattu);
        }

        private void btnSaveProduct_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Program.checkValidate(donViTinhTextEdit, "Field đơn vị tính không được để trống!")) return;
            if (!Program.checkValidate(tenVTTextEdit, "Field tên vật tư không được để trống!")) return;

            // lay thong tin nhan vien hien tai
            string mavt = this.maVTTextEdit.Text;
            string tenvt = this.tenVTTextEdit.Text;
            string dvt = this.donViTinhTextEdit.Text;
            decimal slt = this.soLuongTonSpinEdit.Value;

            // thuc thi sp de update nhan vien
            SqlCommand sqlcmd = new SqlCommand("sp_updatevattu", Program.connect);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.Add("@MAVT", SqlDbType.NChar).Value = mavt;
            sqlcmd.Parameters.Add("@TENVT", SqlDbType.NVarChar).Value = tenvt;
            sqlcmd.Parameters.Add("@DVT", SqlDbType.NVarChar).Value = dvt;
            sqlcmd.Parameters.Add("@SOLUONGTON", SqlDbType.Int).Value = (int)slt;
            Program.execStoreProcedure(sqlcmd);

            // xem du lieu hien tai co thay doi gi so voi du lieu tai thoi diem truoc khi thay doi khong
            string newVTData = mavt + "," + tenvt + "," + dvt + "," + slt.ToString();
            // neu du lieu thay doi ta thuc hien push du lieu cu vao stack
            if (oldVTData != newVTData)
            {
                string[] arrayOldVTData = oldVTData.Split(',');
                //lưu lại dữ liệu để undo
                _maVT.Push(arrayOldVTData[0]);
                _tenVT.Push(arrayOldVTData[1]);
                _dvt.Push(arrayOldVTData[2]);
                _soLuongTon.Push(int.Parse(arrayOldVTData[3]));

                oldVTData = newVTData;
            }

            MessageBox.Show("Đã lưu thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.btnReload.PerformClick();
        }

        private void btnDelProduct_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (cTDDHBindingSource.Count > 0)
            {
                MessageBox.Show("Vật tư đã có chi tiết đơn đặt hàng. Xin vui lòng xoá chi tiết đơn trước.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (cTPNBindingSource.Count > 0)
            {
                MessageBox.Show("Vật tư đã có chi tiết phiếu phiếu nhập. Xin vui lòng xoá chi tiết phiếu trước.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (cTPXBindingSource.Count > 0)
            {
                MessageBox.Show("Vật tư đã có chi tiết phiếu phiếu xuất. Xin vui lòng xoá chi tiết phiếu trước.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dr = MessageBox.Show("Vật tư sẽ bị xóa! \nBạn có chắn chắn muốn xóa?", "Cảnh báo",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.No)
                {
                    return;
                }
                else if (dr == DialogResult.Yes)
                {
                    MessageBox.Show("Vật tư đã bị xóa!", "Thông báo",
                                 MessageBoxButtons.OK, MessageBoxIcon.Information);

                    string cmd = "EXEC sp_xoavattu '" + this.maVTTextEdit.Text + "'";
                    SqlCommand sqlcmd = new SqlCommand(cmd, Program.connect);
                    sqlcmd.CommandType = CommandType.Text;
                    Program.execStoreProcedure(sqlcmd);
                    btnReload.PerformClick();
                }
            }
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string mavt = _maVT.Pop();
                string tenvt = _tenVT.Pop();
                string dvt = _dvt.Pop();
                int slt = _soLuongTon.Pop();

                SqlCommand sqlcmd = new SqlCommand("sp_updatevattu", Program.connect);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.Add("@MAVT", SqlDbType.NChar).Value = mavt;
                sqlcmd.Parameters.Add("@TENVT", SqlDbType.NVarChar).Value = tenvt;
                sqlcmd.Parameters.Add("@DVT", SqlDbType.NVarChar).Value = dvt;
                sqlcmd.Parameters.Add("@SOLUONGTON", SqlDbType.Int).Value = slt;

                Program.execStoreProcedure(sqlcmd);

                this.btnReload.PerformClick();
            }
            catch (Exception ex)
            {
            }
        }

        public string getVTCurrentData()
        {
            string chuoi = null;

            string mavt = this.maVTTextEdit.Text;
            string tenvt = this.tenVTTextEdit.Text;
            string dvt = this.donViTinhTextEdit.Text;
            decimal slt = this.soLuongTonSpinEdit.Value;

            chuoi = mavt + "," + tenvt + "," + dvt + "," + slt.ToString();

            return chuoi;
        }

        private void tenVTTextEdit_Enter(object sender, EventArgs e)
        {
            oldVTData = getVTCurrentData();
        }

        private void donViTinhTextEdit_Enter(object sender, EventArgs e)
        {
            oldVTData = getVTCurrentData();
        }

        private void soLuongTonSpinEdit_Enter(object sender, EventArgs e)
        {
            oldVTData = getVTCurrentData();
        }

        private void btnAddProduct_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Program.addProductForm = new SubForm.ThemVT();
            Program.addProductForm.ShowDialog(this);
        }

        private void vattuGridControl_VisibleChanged(object sender, EventArgs e)
        {
            this.btnReload.PerformClick();
        }

        private void soLuongTonSpinEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                MessageBox.Show("Số lượng tồn chỉ được nhập số nguyên");
            }
        }

        private void vattuGridControl_MouseDown(object sender, MouseEventArgs e)
        {
            this.tenVTTextEdit.Focus();
        }

        private void ProductForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Visible = false;
            Program.mainForm.Visible = true;
        }
    }
}