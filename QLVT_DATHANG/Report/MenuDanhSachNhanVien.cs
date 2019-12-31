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
    public partial class MenuDanhSachNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public MenuDanhSachNhanVien()
        {
            InitializeComponent();

            //phân quyền login
            if (Program.group == "CONGTY")
            {
                this.tenCNComboBox.Enabled = true;
            }
        }

        private void MenuDanhSachNhanVien_Load(object sender, EventArgs e)
        {
            this.v_DS_PHANMANHTableAdapter.Fill(this.qLVT_DATHANGDataSet.V_DS_PHANMANH);

            //đặt combobox là server đang đăng nhập
            this.tenCNComboBox.SelectedValue = Program.servername;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReview_Click(object sender, EventArgs e)
        {
            //quyền công ty đc chọn chi nhánh -> dùng htkn để đăng nhập vào tất cả chi nhánh
            string connection_str = "Data Source=" + this.tenCNComboBox.SelectedValue + ";Initial Catalog=" +
                          Program.database + ";User ID=" +
                          Program.remoteLogin + ";password=" + Program.remotePassword;
            Report.DanhSachNhanVien n = new Report.DanhSachNhanVien(connection_str);
            ReportPrintTool m = new ReportPrintTool(n);
            m.ShowPreviewDialog();
        }
    }
}