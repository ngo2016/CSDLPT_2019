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
using DevExpress.XtraGrid.Views.Grid;

namespace QLVT_DATHANG.SubForm
{
    public partial class LapPhieuNhap_AddNew : DevExpress.XtraEditors.XtraForm
    {
        public LapPhieuNhap_AddNew()
        {
            InitializeComponent();
        }

        private void datHangBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.dDH_ChuaCo_PNBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.cN1);
        }

        private void LapPhieuNhap_AddNew_Load(object sender, EventArgs e)
        {
            //tắt ràng buộc để load form ko bị lỗi null ref
            cN1.EnforceConstraints = false;

            //set lại connect string để khi đăng nhập lại or đổi chi nhánh
            this.dDH_ChuaCo_PNTableAdapter.Connection.ConnectionString = Program.connectString;
            this.dDH_ChuaCo_PNTableAdapter.Fill(this.cN1.DDH_ChuaCo_PN);

            //bật lại ràng buộc
            cN1.EnforceConstraints = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLapPhieuNhap_Click(object sender, EventArgs e)
        {
            //lấy mã đơn đặt hàng dựa vào item đầu [0] của gridView
            GridView gridView = datHangGridControl.FocusedView as GridView;
            object row = gridView.GetRow(gridView.FocusedRowHandle);
            DataRowView row_data = row as DataRowView;
            string maDDH = row_data.Row.ItemArray[0].ToString();

            DateTime ngay = Convert.ToDateTime(row_data.Row.ItemArray[1].ToString());

            LapPhieuNhap_AddNew_Confirm confirm = new LapPhieuNhap_AddNew_Confirm(maDDH, ngay);
            confirm.ShowDialog();
        }
    }
}