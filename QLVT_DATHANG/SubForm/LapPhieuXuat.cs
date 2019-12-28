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
    public partial class LapPhieuXuat : DevExpress.XtraEditors.XtraForm
    {
        public LapPhieuXuat()
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
                this.tenCNComboBox1.Enabled = true;
            }
        }

        private void LapPhieuXuat_Load(object sender, EventArgs e)
        {
            //tắt kiểm tra ràng buộc trước để tránh load lỗi  khi mã nhân viên không có
            cN1.EnforceConstraints = false;

            //thay đổi connectionstring để phù hợp với tài khoản mới khi chuyển chi nhánh or đăng nhập lại
            this.v_DS_NhanVienTableAdapter.Connection.ConnectionString = Program.connectString;
            this.v_DS_NhanVienTableAdapter.Fill(this.cN1.V_DS_NhanVien);

            //thay đổi connectionstring để phù hợp với tài khoản mới khi chuyển chi nhánh or đăng nhập lại
            this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connectString;
            this.phieuXuatTableAdapter.Fill(this.cN1.PhieuXuat);

            //thay đổi connectionstring để phù hợp với tài khoản mới khi chuyển chi nhánh or đăng nhập lại
            this.vattuTableAdapter.Connection.ConnectionString = Program.connectString;
            this.vattuTableAdapter.Fill(this.cN1.Vattu);

            //thay đổi connectionstring để phù hợp với tài khoản mới khi chuyển chi nhánh or đăng nhập lại
            this.cTPXTableAdapter.Connection.ConnectionString = Program.connectString;
            this.cTPXTableAdapter.Fill(this.cN1.CTPX);

            //thay đổi connectionstring để phù hợp với tài khoản mới khi chuyển chi nhánh or đăng nhập lại
            this.khoTableAdapter.Connection.ConnectionString = Program.connectString;
            this.khoTableAdapter.Fill(this.cN1.Kho);

            // TODO: This line of code loads data into the 'qLVT_DATHANGDataSet.V_DS_PHANMANH' table. You can move, or remove it, as needed.
            this.v_DS_PHANMANHTableAdapter.Fill(this.qLVT_DATHANGDataSet.V_DS_PHANMANH);

            this.tenCNComboBox1.SelectedValue = Program.servername;

            this.ngayLapDateEdit.MaxDate = DateTime.Today;

            //bật lại kiểm tra ràng buộc
            cN1.EnforceConstraints = true;
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Program.mainForm.Visible = true;
            this.Visible = false;
        }

        private void tenCNComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //khi load form cac index thay doi
            //khi thay đổi có cái = null nên sẽ không thể tostring đc
            string server = this.tenCNComboBox1.SelectedValue != null ? this.tenCNComboBox1.SelectedValue.ToString() : "null";
            Program.chuyenChiNhanh(server);
            try
            {
                this.btnReload.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối Server thất bại! " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            cN1.EnforceConstraints = false;

            //thay đổi connectionstring để phù hợp với tài khoản mới khi chuyển chi nhánh or đăng nhập lại
            this.v_DS_NhanVienTableAdapter.Connection.ConnectionString = Program.connectString;
            this.v_DS_NhanVienTableAdapter.Fill(this.cN1.V_DS_NhanVien);

            //thay đổi connectionstring để phù hợp với tài khoản mới khi chuyển chi nhánh or đăng nhập lại
            this.phieuXuatTableAdapter.Connection.ConnectionString = Program.connectString;
            this.phieuXuatTableAdapter.Fill(this.cN1.PhieuXuat);

            //thay đổi connectionstring để phù hợp với tài khoản mới khi chuyển chi nhánh or đăng nhập lại
            this.vattuTableAdapter.Connection.ConnectionString = Program.connectString;
            this.vattuTableAdapter.Fill(this.cN1.Vattu);

            //thay đổi connectionstring để phù hợp với tài khoản mới khi chuyển chi nhánh or đăng nhập lại
            this.cTPXTableAdapter.Connection.ConnectionString = Program.connectString;
            this.cTPXTableAdapter.Fill(this.cN1.CTPX);

            //thay đổi connectionstring để phù hợp với tài khoản mới khi chuyển chi nhánh or đăng nhập lại
            this.khoTableAdapter.Connection.ConnectionString = Program.connectString;
            this.khoTableAdapter.Fill(this.cN1.Kho);

            this.ngayLapDateEdit.MaxDate = DateTime.Today;

            cN1.EnforceConstraints = true;
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
            if (cTPXBindingSource.Count > 0)
            {
                MessageBox.Show("Phiếu xuất đã có chi tiết phiếu. Xin vui lòng xoá chi tiết phiếu trước.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult dr = MessageBox.Show("Phiếu xuất sẽ bị xóa! \nBạn có chắn chắn muốn xóa?", "Cảnh báo",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.No)
                {
                    return;
                }
                else if (dr == DialogResult.Yes)
                {

                    string cmd = "EXEC sp_xoaphieuxuat '" + this.maPhieuXuatTextEdit.Text + "'";
                    SqlCommand sqlcmd = new SqlCommand(cmd, Program.connect);
                    sqlcmd.CommandType = CommandType.Text;
                    Program.execStoreProcedure(sqlcmd);

                    MessageBox.Show("Phiếu xuất đã bị xóa!", "Thông báo",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    btnReload.PerformClick();
                }
            }
        }

        private void btnSubformAdd_Click(object sender, EventArgs e)
        {
            //this.Validate();

            ////lấy data từ cellSoLuong của CTPN
            //int soluong = int.Parse(this.cTPXDataGridView.CurrentRow.Cells["cellSoLuong"].Value.ToString());
            //string maPX = this.cTPXDataGridView.CurrentRow.Cells["cellMaPX"].Value.ToString();
            //string maVT = this.cTPXDataGridView.CurrentRow.Cells["cellMaVT"].Value.ToString();

            //SqlCommand sqlCommand = new SqlCommand("sp_timSoLuongTonVatTu", Program.connect);
            //sqlCommand.CommandType = CommandType.StoredProcedure;
            //sqlCommand.Parameters.AddWithValue("@MAVT", maVT);

            //int soLuongTon = Program.execStoreProcedureWithReturnValue(sqlCommand);

            //if (soluong > soLuongTon)
            //{
            //    this.cTPXDataGridView.CurrentRow.Cells["cellSoLuong"].Value = soLuongTon;
            //    MessageBox.Show("Không được xuất số lượng vượt quá số lượng tồn trong kho", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            ////TODO: viết sp thêm ctpx

            //SqlCommand sqlCommand2 = new SqlCommand("sp_updateSoLuongTonVatTu", Program.connect);
            //sqlCommand2.CommandType = CommandType.StoredProcedure;
            //sqlCommand2.Parameters.AddWithValue("@MAVT", maVT);
            //sqlCommand2.Parameters.AddWithValue("@MAPX", maPX);
            //sqlCommand2.Parameters.AddWithValue("@SOLUONGMOI", soluong);
            //Program.execStoreProcedure(sqlCommand2);

            //// fill lại dữ liệu cho subform
            //this.cTPXTableAdapter.Fill(this.cN1.CTPX);
        }

        private void btnSubformWrite_Click(object sender, EventArgs e)
        {
            this.Validate();

            //lấy data từ cellSoLuong của CTPN
            int soluong = int.Parse(this.cTPXDataGridView.CurrentRow.Cells["cellSoLuong"].Value.ToString());
            string maPX = this.cTPXDataGridView.CurrentRow.Cells["cellMaPX"].Value.ToString();
            string maVT = this.cTPXDataGridView.CurrentRow.Cells["cellMaVT"].Value.ToString();

            SqlCommand sqlCommand = new SqlCommand("sp_timSoLuongTonVatTu", Program.connect);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@MAVT", maVT);

            //int soLuongTon = Program.execStoreProcedureWithReturnValue(sqlCommand);

            //if (soluong > soLuongTon)
            //{
            //    this.cTPXDataGridView.CurrentRow.Cells["cellSoLuong"].Value = soLuongTon;
            //    MessageBox.Show("Không được xuất số lượng vượt quá số lượng tồn trong kho", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            try
            {
                SqlCommand sqlCommand2 = new SqlCommand("sp_updateSoLuongTonVatTu", Program.connect);
                sqlCommand2.CommandType = CommandType.StoredProcedure;
                sqlCommand2.Parameters.AddWithValue("@MAVT", maVT);
                sqlCommand2.Parameters.AddWithValue("@MAPX", maPX);
                sqlCommand2.Parameters.AddWithValue("@SOLUONGMOI", soluong);

                Program.execStoreProcedure(sqlCommand2);
            }
            catch (Exception)
            {
                MessageBox.Show("Số lượng mới không hợp lệ\n- Không được < Số lượng tồn\n- Không được <= 0", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // fill lại dữ liệu cho subform
            this.cTPXTableAdapter.Fill(this.cN1.CTPX);
        }

        private void btnSubformDel_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Chi tiết phiếu xuất sẽ bị xóa! \nBạn có chắn chắn muốn xóa?", "Cảnh báo",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.No)
            {
                return;
            }
            else if (dr == DialogResult.Yes)
            {
                try
                {
                    //xóa phần tử hiện tại trong bảng(con trỏ ở đâu xóa ở đó)
                    this.cTPXBindingSource.RemoveCurrent();
                }
                catch (Exception)
                {
                    MessageBox.Show("Không có chi tiết phiếu xuất để xóa!", "Thông báo",
                             MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                this.cTPXBindingSource.EndEdit();
                this.cTPXTableAdapter.Update(this.cN1);
                this.cTPXTableAdapter.Fill(this.cN1.CTPX);

                MessageBox.Show("Chi tiết phiếu xuất đã bị xóa!", "Thông báo",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string hoten = this.hoTenComboBox.Text;
            if (hoten.Contains("Đã chuyển"))
            {
                MessageBox.Show("Nhân viên lập phiếu xuất đã chuyển sang chi nhánh khác. Xin vui lòng chọn nhân viên khác", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string mapx = this.maPhieuXuatTextEdit.Text;
            DateTime ngaylap = this.ngayLapDateEdit.Value;
            string ngayLap = ngaylap.Year.ToString() + "-" + ngaylap.Month.ToString() + "-" + ngaylap.Day.ToString();
            string hotenkhachhang = this.hoTenKhachHangTextEdit.Text;
            string manv = this.maNVSpinEdit.Text;
            string makho = this.maKhoTextEdit.Text;

            //câu lệnh tạo sp để lập đơn đặt hàng
            SqlCommand sqlcmd = new SqlCommand("sp_lapphieuxuat", Program.connect);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.Add("@MAPX", SqlDbType.NChar).Value = mapx;
            sqlcmd.Parameters.Add("@NGAY", SqlDbType.DateTime).Value = ngayLap;
            sqlcmd.Parameters.Add("@HOTENKH", SqlDbType.NVarChar).Value = hotenkhachhang;
            sqlcmd.Parameters.Add("@MANV", SqlDbType.Int).Value = manv;
            sqlcmd.Parameters.Add("@MAKHO", SqlDbType.NChar).Value = makho;

            int checkIf = Program.execStoreProcedureWithReturnValue(sqlcmd);
            //văng lỗi theo mã
            if (checkIf == 2627)
            {
                MessageBox.Show("Mã phiếu xuất đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (checkIf == 547)
            {
                MessageBox.Show("Mã nhân viên hoặc mã kho không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (checkIf == 0)
            {
                MessageBox.Show("Thêm phiếu xuất thành công", "Xong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.btnReload.PerformClick();
                return;
            }
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Program.checkValidate(maPhieuXuatTextEdit, "Field mã phiếu xuất không được để trống!")) return;
            if (!Program.checkValidate(hoTenKhachHangTextEdit, "Field họ tên khách hàng không được để trống!")) return;

            // lay thong tin phieu xuat hien tai
            string mapx = this.maPhieuXuatTextEdit.Text;
            DateTime ngaylap = this.ngayLapDateEdit.Value;
            string ngayLap = ngaylap.Year.ToString() + "-" + ngaylap.Month.ToString() + "-" + ngaylap.Day.ToString();
            string tenkhachhang = this.hoTenKhachHangTextEdit.Text;
            string manv = this.maNVSpinEdit.Text;
            string makho = this.maKhoTextEdit.Text;

            //câu lệnh tạo sp để update phieu xuat
            SqlCommand sqlcmd = new SqlCommand("sp_updatephieuxuat", Program.connect);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.Add("@MAPX", SqlDbType.NChar).Value = mapx;
            sqlcmd.Parameters.Add("@NGAY", SqlDbType.Date).Value = ngayLap;
            sqlcmd.Parameters.Add("@HOTENKH", SqlDbType.NVarChar).Value = tenkhachhang;
            sqlcmd.Parameters.Add("@MANV", SqlDbType.Int).Value = manv;
            sqlcmd.Parameters.Add("@MAKHO", SqlDbType.NChar).Value = makho;
            Program.execStoreProcedure(sqlcmd);
            this.btnReload.PerformClick();
        }

        private void maNVSpinEdit_TextChanged(object sender, EventArgs e)
        {
            //thay doi ten nhan vien trong combobox khi ma nhan vien thay doi
            try
            {
                string manv = this.maNVSpinEdit.Text;
                this.hoTenComboBox.SelectedValue = int.Parse(manv);
            }
            catch (Exception) { }
        }

        private void cTPXDataGridView_MouseUp(object sender, MouseEventArgs e)
        {
            //lấy data từ cellSoLuong của CTPN

            //if (this.cTPXDataGridView.CurrentRow.IsNewRow)
            //{
            //    btnSubformWrite.Enabled = false;

            //    object cell1 = this.cTPXDataGridView.CurrentRow.Cells["cellSoLuong"].Value;
            //    object cell2 = this.cTPXDataGridView.CurrentRow.Cells["cellMaPX"].Value;
            //    object cell3 = this.cTPXDataGridView.CurrentRow.Cells["cellMaVT"].Value;
            //    object cell4 = this.cTPXDataGridView.CurrentRow.Cells["cellDonGia"].Value;

            //    if (string.IsNullOrEmpty(cell1.ToString()) || string.IsNullOrEmpty(cell2.ToString()) ||
            //        string.IsNullOrEmpty(cell3.ToString()) || string.IsNullOrEmpty(cell4.ToString()))
            //    {
            //        btnSubformAdd.Enabled = false;
            //    }
            //    else
            //    {
            //        btnSubformAdd.Enabled = true;
            //    }

            //}
            //else
            //{
            //    btnSubformWrite.Enabled = true;
            //    btnSubformAdd.Enabled = false;
            //}
        }
    }
}