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

namespace QLVT_DATHANG.Report
{
    public partial class MenuDanhSachNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public MenuDanhSachNhanVien()
        {
            InitializeComponent();

            if (Program.group == "CONGTY")
            {
                this.tenCNComboBox.Enabled = true;
            }
        }

        private void MenuDanhSachNhanVien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLVT_DATHANGDataSet.V_DS_PHANMANH' table. You can move, or remove it, as needed.
            this.v_DS_PHANMANHTableAdapter.Fill(this.qLVT_DATHANGDataSet.V_DS_PHANMANH);
            this.tenCNComboBox.SelectedValue = Program.servername;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Program.mainForm.Visible = true;
            this.Close();
        }

        private void btnReview_Click(object sender, EventArgs e)
        {
            if (this.tenCNComboBox.Enabled != false)
            {
                Program.servername = this.tenCNComboBox.SelectedValue.ToString();
                Program.reportFlag = int.Parse(Program.servername[Program.servername.Length - 1].ToString());
            }

            // load form review
            Program.reviewDanhSachNhanVien = new ReviewDanhSachNhanVien();
            Program.reviewDanhSachNhanVien.Activate();
            Program.reviewDanhSachNhanVien.Show();
            this.Visible = false;
        }
    }
}