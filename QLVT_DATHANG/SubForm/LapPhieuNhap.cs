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
using DevExpress.XtraGrid.Views.Grid;

namespace QLVT_DATHANG.SubForm
{
    public partial class LapPhieuNhap : DevExpress.XtraEditors.XtraForm
    {
        public LapPhieuNhap()
        {
            InitializeComponent();

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

        private void LapPhieuNhap_Load(object sender, EventArgs e)
        {
            //tắt kiểm tra ràng buộc trước để tránh load lỗi  khi mã nhân viên không có
            cN1.EnforceConstraints = false;

            //thay đổi connectionstring để phù hợp với tài khoản mới khi chuyển chi nhánh or đăng nhập lại
            this.v_DS_NhanVienTableAdapter.Connection.ConnectionString = Program.connectString;
            this.v_DS_NhanVienTableAdapter.Fill(this.cN1.V_DS_NhanVien);

            //thay đổi connectionstring để phù hợp với tài khoản mới khi chuyển chi nhánh or đăng nhập lại
            this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connectString;
            this.phieuNhapTableAdapter.Fill(this.cN1.PhieuNhap);

            //thay đổi connectionstring để phù hợp với tài khoản mới khi chuyển chi nhánh or đăng nhập lại
            this.vattuTableAdapter.Connection.ConnectionString = Program.connectString;
            this.vattuTableAdapter.Fill(this.cN1.Vattu);

            //thay đổi connectionstring để phù hợp với tài khoản mới khi chuyển chi nhánh or đăng nhập lại
            this.cTPNTableAdapter.Connection.ConnectionString = Program.connectString;
            this.cTPNTableAdapter.Fill(this.cN1.CTPN);

            //thay đổi connectionstring để phù hợp với tài khoản mới khi chuyển chi nhánh or đăng nhập lại
            this.khoTableAdapter.Connection.ConnectionString = Program.connectString;
            this.khoTableAdapter.Fill(this.cN1.Kho);

            // TODO: This line of code loads data into the 'qLVT_DATHANGDataSet.V_DS_PHANMANH' table. You can move, or remove it, as needed.
            this.v_DS_PHANMANHTableAdapter.Fill(this.qLVT_DATHANGDataSet.V_DS_PHANMANH);

            this.tenCNComboBox.SelectedValue = Program.servername;
            this.ngayDateTimePicker.MaxDate = DateTime.Today;

            //bật lại kiểm tra ràng buộc
            cN1.EnforceConstraints = true;
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Program.mainForm.Visible = true;
            this.Visible = false;
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
                MessageBox.Show("Kết nối Server thất bại! " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void hoTenComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                maNVSpinEdit.Text = hoTenComboBox.SelectedValue.ToString();
            }
            catch (Exception)
            {
            }
        }

        private void maNVSpinEdit_TextChanged(object sender, EventArgs e)
        {
            //thay doi ten nhan vien trong combobox khi ma nhan vien thay doi
            //xu ly khi nhan vao row trong table don dat hang
            try
            {
                string manv = this.maNVSpinEdit.Text;
                this.hoTenComboBox.SelectedValue = int.Parse(manv);
            }
            catch (Exception)
            {

            }
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //thay đổi connectionstring để phù hợp với tài khoản mới khi chuyển chi nhánh or đăng nhập lại
            this.v_DS_NhanVienTableAdapter.Connection.ConnectionString = Program.connectString;
            this.v_DS_NhanVienTableAdapter.Fill(this.cN1.V_DS_NhanVien);

            //thay đổi connectionstring để phù hợp với tài khoản mới khi chuyển chi nhánh or đăng nhập lại
            this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connectString;
            this.phieuNhapTableAdapter.Fill(this.cN1.PhieuNhap);

            //thay đổi connectionstring để phù hợp với tài khoản mới khi chuyển chi nhánh or đăng nhập lại
            this.vattuTableAdapter.Connection.ConnectionString = Program.connectString;
            this.vattuTableAdapter.Fill(this.cN1.Vattu);

            //thay đổi connectionstring để phù hợp với tài khoản mới khi chuyển chi nhánh or đăng nhập lại
            this.cTPNTableAdapter.Connection.ConnectionString = Program.connectString;
            this.cTPNTableAdapter.Fill(this.cN1.CTPN);

            //thay đổi connectionstring để phù hợp với tài khoản mới khi chuyển chi nhánh or đăng nhập lại
            this.khoTableAdapter.Connection.ConnectionString = Program.connectString;
            this.khoTableAdapter.Fill(this.cN1.Kho);

            this.ngayDateTimePicker.MaxDate = DateTime.Today;
        }

        private void tenKhoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                maKhoTextEdit.Text = tenKhoComboBox.SelectedValue.ToString();
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
                this.tenKhoComboBox.SelectedValue = makho;
            }
            catch (Exception)
            {

            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (cTPNBindingSource.Count > 0)
            {
                MessageBox.Show("Phiếu nhập đã có chi tiết phiếu. Xin vui lòng xoá chi tiết phiếu trước.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!Program.checkValidate(maPhieuNhapTextEdit, "Field mã phiếu nhập không được để trống!")) return;
                if (!Program.checkValidate(maSoDonDatHangTextEdit, "Field mã số đơn đặt hàng không được để trống!")) return;

                string cmd = "EXEC sp_xoaphieunhap '" + this.maPhieuNhapTextEdit.Text + "'";
                SqlCommand sqlcmd = new SqlCommand(cmd, Program.connect);
                sqlcmd.CommandType = CommandType.Text;
                Program.execStoreProcedure(sqlcmd);
                btnReload.PerformClick();
            }
        }

        private void btnSubformWrite_Click(object sender, EventArgs e)
        {
            this.Validate();

            int soluong = int.Parse(this.cTPNDataGridView.CurrentRow.Cells["cellSoLuong"].Value.ToString());

            GridView gridView = phieuNhapGridControl.FocusedView as GridView;
            object row = gridView.GetRow(gridView.FocusedRowHandle);
            DataRowView row_data = row as DataRowView;
            string maDDH = row_data.Row.ItemArray[2].ToString();

            string maVT = this.cTPNDataGridView.CurrentRow.Cells["cellMaVT"].Value.ToString();

            String sp_laysoluongtrongddh = "EXEC sp_laysoluongtrongddh '" + maDDH + "', '" + maVT + "'";
            SqlDataReader soluongDDH = Program.ExecSqlDataReader(sp_laysoluongtrongddh);

            soluongDDH.Read();
            int soluongtrongDDH = soluongDDH.GetInt32(0);

            if (soluong > soluongtrongDDH)
            {
                MessageBox.Show("Không được nhập quá số lượng đã đặt (" + soluongtrongDDH + ")", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cTPNTableAdapter.Fill(this.cN1.CTPN);
                soluongDDH.Close();
                return;
            }

            this.cTPNBindingSource.EndEdit();
            soluongDDH.Close();
            this.cTPNTableAdapter.Update(this.cN1);
            // fill lại dữ liệu cho subform
            this.cTPNTableAdapter.Fill(this.cN1.CTPN);
        }

        private void btnSubformDel_Click(object sender, EventArgs e)
        {
            //xóa phần tử hiện tại trong bảng(con trỏ ở đâu xóa ở đó)
            this.cTPNBindingSource.RemoveCurrent();
            this.cTPNBindingSource.EndEdit();
            this.cTPNTableAdapter.Update(this.cN1);
            // fill lại dữ liệu cho subform
            this.cTPNTableAdapter.Fill(this.cN1.CTPN);
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Program.addNewPhieuNhap = new LapPhieuNhap_AddNew();
            Program.addNewPhieuNhap.Activate();
            Program.addNewPhieuNhap.Show();
            this.Visible = false;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // lay thong tin ddh hien tai
            string mapn = this.maPhieuNhapTextEdit.Text;
            DateTime ngaylap = this.ngayDateTimePicker.Value;
            string ngayLap = ngaylap.Year.ToString() + "-" + ngaylap.Month.ToString() + "-" + ngaylap.Day.ToString();
            string masoddh = this.maSoDonDatHangTextEdit.Text;
            string manv = this.maNVSpinEdit.Text;
            string makho = this.maKhoTextEdit.Text;

            //câu lệnh tạo sp để update đơn đặt hàng
            SqlCommand sqlcmd = new SqlCommand("sp_updatephieunhap", Program.connect);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.Add("@MAPN", SqlDbType.NChar).Value = mapn;
            sqlcmd.Parameters.Add("@NGAY", SqlDbType.Date).Value = ngayLap;
            sqlcmd.Parameters.Add("@MasoDDH", SqlDbType.NChar).Value = masoddh;
            sqlcmd.Parameters.Add("@MANV", SqlDbType.Int).Value = manv;
            sqlcmd.Parameters.Add("@MAKHO", SqlDbType.NChar).Value = makho;
            Program.execStoreProcedure(sqlcmd);
            this.btnReload.PerformClick();
        }
    }
}