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
    public partial class ReviewDanhSachNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public ReviewDanhSachNhanVien()
        {
            InitializeComponent();
        }

        private void ReviewDanhSachNhanVien_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.menuDanhSachNhanVien.Visible = true;
        }
    }
}