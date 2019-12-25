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

namespace QLVT_DATHANG.Report
{
    public partial class KeKhai_Select_From_To : DevExpress.XtraEditors.XtraForm
    {
        public KeKhai_Select_From_To()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DateTime startDate = this.dateTimePickerFrom.Value;
            DateTime endDate = this.dateTimePickerTo.Value;
            bool congty = Program.group == "CONGTY" ? true : false;

            BangKeChiTietSoLuong_TriGiaHangNhapHoacXuat.congty = congty;
            BangKeChiTietSoLuong_TriGiaHangNhapHoacXuat.startDate = startDate;
            BangKeChiTietSoLuong_TriGiaHangNhapHoacXuat.endDate = endDate; 
            
            Program.reviewKeKhai = new Report.ReviewKeKhai();
            Program.reviewKeKhai.ShowDialog(this);
        }
    }
}