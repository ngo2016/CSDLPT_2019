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
            this.nhanVienBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.cN1);

        }

        private void MenuHoatDongNhanVien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cN1.V_DS_NhanVien' table. You can move, or remove it, as needed.
            this.v_DS_NhanVienTableAdapter.Fill(this.cN1.V_DS_NhanVien);
            // TODO: This line of code loads data into the 'cN1.NhanVien' table. You can move, or remove it, as needed.
            this.nhanVienTableAdapter.Fill(this.cN1.NhanVien);

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReview_Click(object sender, EventArgs e)
        {
            Report.DanhSachNhanVien n = new Report.DanhSachNhanVien();
            ReportPrintTool m = new ReportPrintTool(n);
            m.ShowPreviewDialog();
        }
    }
}