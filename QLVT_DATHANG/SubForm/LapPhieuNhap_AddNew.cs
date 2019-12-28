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
            // TODO: This line of code loads data into the 'cN1.DDH_ChuaCo_PN' table. You can move, or remove it, as needed.
            this.dDH_ChuaCo_PNTableAdapter.Fill(this.cN1.DDH_ChuaCo_PN);
            cN1.EnforceConstraints = false;

            // TODO: This line of code loads data into the 'cN1.DatHang' table. You can move, or remove it, as needed.
            this.dDH_ChuaCo_PNTableAdapter.Connection.ConnectionString = Program.connectString;
            this.dDH_ChuaCo_PNTableAdapter.Fill(this.cN1.DDH_ChuaCo_PN);

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.addPhieuNhapForm.Visible = true;
        }

        private void btnLapPhieuNhap_Click(object sender, EventArgs e)
        {
            GridView gridView = datHangGridControl.FocusedView as GridView;
            object row = gridView.GetRow(gridView.FocusedRowHandle);
            DataRowView row_data = row as DataRowView;
            string maDDH = row_data.Row.ItemArray[0].ToString();

            DateTime ngay = Convert.ToDateTime(row_data.Row.ItemArray[1].ToString());

            LapPhieuNhap_AddNew_Confirm confirm = new LapPhieuNhap_AddNew_Confirm(maDDH, ngay);
            confirm.Activate();
            confirm.Show();
            this.Visible = false;
        }
    }
}