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
    public partial class ReviewDanhSachVatTu : DevExpress.XtraEditors.XtraForm
    {
        public ReviewDanhSachVatTu()
        {
            InitializeComponent();
        }

        private void ReviewDanhSachVatTu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.mainForm.Visible = true;
        }
    }
}