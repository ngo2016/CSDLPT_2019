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
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using DevExpress.XtraPrinting;

namespace QLVT_DATHANG.Report
{
    public partial class MenuHoatDongNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public MenuHoatDongNhanVien()
        {
            InitializeComponent();
        }

        private void nhanVienBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tableAdapterManager.UpdateAll(this.cN1);

        }

        private void MenuHoatDongNhanVien_Load(object sender, EventArgs e)
        {
            //nếu là login công ty thì gán constring của main server
            if (Program.group == "CONGTY")
            {
                this.v_DS_NhanVienTableAdapter.Connection.ConnectionString = "Data Source=HEROSEEKER\\MAINSERVER;Initial Catalog=QLVT_DATHANG;Integrated Security=True";
            }
            else
            {
                //login còn lại thì gán constring hiện tại
                this.v_DS_NhanVienTableAdapter.Connection.ConnectionString = Program.connectString;
            }

            this.v_DS_NhanVienTableAdapter.Fill(this.cN1.V_DS_NhanVien);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReview_Click(object sender, EventArgs e)
        {
            //lấy mã nhân viên dựa vào text của combobox
            int maNV = int.Parse(this.maNVComboBox.Text);
            //gán vào tham số truyền đi để cho vào sp
            Report.HoatDongNhanVien n = new Report.HoatDongNhanVien(maNV, dateTimePickerFrom.Value, dateTimePickerTo.Value);
            //gán vào label
            n.lbMaNV.Text = this.maNVComboBox.Text;

            String sp_layThongTinNhanVien = "EXEC sp_layThongTinNhanVien '" + maNV + "'";
            SqlDataReader dataReader = Program.ExecSqlDataReader(sp_layThongTinNhanVien);
            if (dataReader == null)
            {
                MessageBox.Show("Không có mã nhân viên " + maNV, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataReader.Close();
                return;
            }
            try
            {
                //doc ket qua tu sp_layThongTinNhanVien có 4 cột ("HOTEN", "[DIACHI]", "[NGAYSINH]", "[LUONG]")
                dataReader.Read();
            }
            catch (Exception)
            {
                MessageBox.Show("Không tìm thấy thông tin của mã nhân viên " + maNV, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //đóng dataReader để khi sử dụng lại ko lỗi
                dataReader.Close();
                return;
            }
            //sau khi thuc thi sp_layThongTinNhanVien ta co    0           1           2           3
            //                                                 HOTEN       DIACHI      NGAYSINH    LUONG
            n.lbHoTen.Text = dataReader.GetString(0);

            n.lbDiaChi.Text = dataReader.GetString(1);
            n.lbNgaySinh.Text = dataReader[2].ToString();
            n.lbLuong.Text = dataReader[3].ToString();

            //đóng bảng chỉ đọc và ngắt kết nối
            dataReader.Close();

            ReportPrintTool m = new ReportPrintTool(n);
            m.ShowPreviewDialog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //lấy mã nhân viên dựa vào text của combobox
            int maNV = int.Parse(this.maNVComboBox.Text);
            //gán vào tham số truyền đi để cho vào sp
            Report.HoatDongNhanVien n = new Report.HoatDongNhanVien(maNV, dateTimePickerFrom.Value, dateTimePickerTo.Value);
            //gán vào label            
            n.lbMaNV.Text = this.maNVComboBox.Text;

            String sp_layThongTinNhanVien = "EXEC sp_layThongTinNhanVien '" + maNV + "'";
            SqlDataReader dataReader = Program.ExecSqlDataReader(sp_layThongTinNhanVien);
            if (dataReader == null)
            {
                MessageBox.Show("Không có mã nhân viên " + maNV, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataReader.Close();
                return;
            }
            try
            {
                //doc ket qua tu sp_layThongTinNhanVien có 4 cột ("HOTEN", "[DIACHI]", "[NGAYSINH]", "[LUONG]")
                dataReader.Read();
            }
            catch (Exception)
            {
                MessageBox.Show("Không tìm thấy thông tin của mã nhân viên " + maNV, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //đóng dataReader để khi sử dụng lại ko lỗi
                dataReader.Close();
                return;
            }
            //sau khi thuc thi sp_layThongTinNhanVien ta co    0           1           2           3
            //                                                 HOTEN       DIACHI      NGAYSINH    LUONG
            n.lbHoTen.Text = dataReader.GetString(0);

            n.lbDiaChi.Text = dataReader.GetString(1);
            n.lbNgaySinh.Text = dataReader[2].ToString();
            n.lbLuong.Text = dataReader[3].ToString();

            //đóng bảng chỉ đọc và ngắt kết nối
            dataReader.Close();

            //hiện dialog chọn chổ lưu file
            SaveFileDialog svg = new SaveFileDialog();
            svg.Title = "Lưu file pdf";
            svg.Filter = "PDF(*.pdf)|*.pdf";
            svg.ShowDialog();

            //nếu đường dẫn là hợp lệ (ko null / rỗng)
            if (!String.IsNullOrEmpty(svg.FileName))
            {
                string reportPath = svg.FileName;
                PdfExportOptions pdfOptions = n.ExportOptions.Pdf;
                pdfOptions.ConvertImagesToJpeg = false;
                pdfOptions.ImageQuality = PdfJpegImageQuality.Medium;

                pdfOptions.PdfACompatibility = PdfACompatibility.PdfA2b;
                n.ExportToPdf(reportPath, pdfOptions);

                System.Diagnostics.Process.Start(reportPath);

                MessageBox.Show("In report thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}