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
    public partial class LapPhieuNhap_AddNew_Confirm : DevExpress.XtraEditors.XtraForm
    {
        //set động các field dữ liệu
        private TextBox maPhieuNhapTextBox;
        private TextBox maDDHTextBox;
        private TextBox maNVTextBox;

        private DateTimePicker dateTimePicker;
        private List<NumericUpDown> items = new List<NumericUpDown>();

        private string maDDH;

        public LapPhieuNhap_AddNew_Confirm(string maDDH, DateTime ngay)
        {
            this.maDDH = maDDH;
            InitializeComponent();

            maDDHTextBox = new TextBox();
            maDDHTextBox.Text = maDDH;
            maDDHTextBox.Enabled = false;

            maPhieuNhapTextBox = new TextBox();
            maPhieuNhapTextBox.Text = "";
            maPhieuNhapTextBox.MaxLength = 8;

            dateTimePicker = new DateTimePicker();
            dateTimePicker.CustomFormat = "yyyy-MM-dd";
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker.MaxDate = DateTime.Today;
            this.dateTimePicker.MinDate = ngay;

            maNVTextBox = new TextBox();
            maNVTextBox.Text = Program.username;

            this.layoutControl2.AddItem("Mã đơn đặt hàng", maDDHTextBox);
            this.layoutControl2.AddItem("Mã phiếu nhập", maPhieuNhapTextBox);
            this.layoutControl2.AddItem("Ngày nhập", dateTimePicker);
            this.layoutControl2.AddItem("Mã nhân viên nhập phiếu", maNVTextBox);

            String sp_laychitietDDH = "EXEC sp_laychitietDDH '" + maDDH + "'";
            SqlDataReader chiTietDDH = Program.ExecSqlDataReader(sp_laychitietDDH);
            if (chiTietDDH == null)
            {
                MessageBox.Show("Đơn đặt hàng chưa có chi tiết đơn. Vui lòng lập chi tiết đơn để tiếp tục!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            while (true)
            {
                try
                {
                    //doc ket qua tu sp_dangnhap có 3 cột ("MAVT", "TENVT", "SOLUONG")
                    chiTietDDH.Read();
                    NumericUpDown nud = new NumericUpDown();
                    nud.Maximum = chiTietDDH.GetInt32(2);
                    nud.Value = chiTietDDH.GetInt32(2);
                    nud.Name = chiTietDDH.GetString(0);
                    this.layoutControl2.AddItem(chiTietDDH.GetString(1), nud);
                    this.items.Add(nud);
                }
                catch (Exception)
                {
                    chiTietDDH.Close();
                    break;
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            //tao phieu nhap cho don dat hang
            string mapn = this.maPhieuNhapTextBox.Text;

            //ma nhan vien lap phieu nhap
            string manvLapPhieuNhap = maNVTextBox.Text;

            if (mapn == "")
            {
                MessageBox.Show("Mã phiếu nhập không được để trống", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime ngaylap = this.dateTimePicker.Value;
            string ngayLap = ngaylap.Year.ToString() + "-" + ngaylap.Month.ToString() + "-" + ngaylap.Day.ToString();
            SqlCommand sqlcmd1 = new SqlCommand("sp_taophieunhap", Program.connect);
            sqlcmd1.CommandType = CommandType.StoredProcedure;
            sqlcmd1.Parameters.AddWithValue("@MAPN", mapn);
            sqlcmd1.Parameters.AddWithValue("@NGAY", ngayLap);
            sqlcmd1.Parameters.AddWithValue("@MasoDDH", this.maDDH);
            sqlcmd1.Parameters.AddWithValue("@MANV", manvLapPhieuNhap);

            try
            {
                Program.execStoreProcedure(sqlcmd1);
            }
            catch (Exception)
            {
                MessageBox.Show("Mã phiếu nhập đã tồn tại\nHoặc nhân viên đã chuyển chi nhánh\nHoặc không có nhân viên có mã " + manvLapPhieuNhap, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //tao chi tiet phieu nhap cho tung mat hang trong chi tiet don dat hang
            foreach (var item in this.items)
            {
                string mavt = item.Name;
                int soluong = decimal.ToInt32(item.Value);
                SqlCommand sqlcmd = new SqlCommand("sp_taochitietphieunhap", Program.connect);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@MAPN", mapn);
                sqlcmd.Parameters.AddWithValue("@MAVT", mavt);
                sqlcmd.Parameters.AddWithValue("@MasoDDH", this.maDDH);
                sqlcmd.Parameters.AddWithValue("@SOLUONG", soluong);
                Program.execStoreProcedure(sqlcmd);
            }
            Program.addPhieuNhapForm.btnReload.PerformClick();

            Program.addNewPhieuNhap.Close();
            this.Close();
        }

    }
}