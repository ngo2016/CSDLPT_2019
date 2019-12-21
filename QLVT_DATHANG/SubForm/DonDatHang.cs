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

namespace QLVT_DATHANG.SubForm
{
    public partial class DonDatHang : DevExpress.XtraEditors.XtraForm
    {
        public DonDatHang()
        {
            InitializeComponent();
        }

        private void datHangBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.datHangBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.cN1);

        }

        private void DonDatHang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cN1.CTDDH' table. You can move, or remove it, as needed.
            this.cTDDHTableAdapter.Fill(this.cN1.CTDDH);
            // TODO: This line of code loads data into the 'cN1.DatHang' table. You can move, or remove it, as needed.
            this.datHangTableAdapter.Fill(this.cN1.DatHang);

        }

        private void mAKHOTextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void mANVSpinEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void nhaCCTextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void datHangBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.datHangBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.cN1);

        }

        private void cTDDHDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}