namespace QLVT_DATHANG.Report
{
    partial class MenuHoatDongNhanVien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cN1 = new QLVT_DATHANG.CN1();
            this.nhanVienBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nhanVienTableAdapter = new QLVT_DATHANG.CN1TableAdapters.NhanVienTableAdapter();
            this.tableAdapterManager = new QLVT_DATHANG.CN1TableAdapters.TableAdapterManager();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.v_DS_NhanVienBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.v_DS_NhanVienTableAdapter = new QLVT_DATHANG.CN1TableAdapters.V_DS_NhanVienTableAdapter();
            this.maNVComboBox = new System.Windows.Forms.ComboBox();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.hoTenTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnReview = new System.Windows.Forms.Button();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnPrint = new System.Windows.Forms.Button();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnExit = new System.Windows.Forms.Button();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.cN1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhanVienBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_DS_NhanVienBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hoTenTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // cN1
            // 
            this.cN1.DataSetName = "CN1";
            this.cN1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // nhanVienBindingSource
            // 
            this.nhanVienBindingSource.DataMember = "NhanVien";
            this.nhanVienBindingSource.DataSource = this.cN1;
            // 
            // nhanVienTableAdapter
            // 
            this.nhanVienTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ChiNhanhTableAdapter = null;
            this.tableAdapterManager.CTDDHTableAdapter = null;
            this.tableAdapterManager.CTPNTableAdapter = null;
            this.tableAdapterManager.CTPXTableAdapter = null;
            this.tableAdapterManager.DatHangTableAdapter = null;
            this.tableAdapterManager.KhoTableAdapter = null;
            this.tableAdapterManager.NhanVienTableAdapter = this.nhanVienTableAdapter;
            this.tableAdapterManager.PhieuNhapTableAdapter = null;
            this.tableAdapterManager.PhieuXuatTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = QLVT_DATHANG.CN1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.VattuTableAdapter = null;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnExit);
            this.layoutControl1.Controls.Add(this.btnPrint);
            this.layoutControl1.Controls.Add(this.btnReview);
            this.layoutControl1.Controls.Add(this.dateTimePickerFrom);
            this.layoutControl1.Controls.Add(this.dateTimePicker1);
            this.layoutControl1.Controls.Add(this.hoTenTextEdit);
            this.layoutControl1.Controls.Add(this.maNVComboBox);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(546, 173);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.emptySpaceItem1,
            this.layoutControlItem3,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup1.Size = new System.Drawing.Size(546, 173);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // v_DS_NhanVienBindingSource
            // 
            this.v_DS_NhanVienBindingSource.DataMember = "V_DS_NhanVien";
            this.v_DS_NhanVienBindingSource.DataSource = this.cN1;
            // 
            // v_DS_NhanVienTableAdapter
            // 
            this.v_DS_NhanVienTableAdapter.ClearBeforeFill = true;
            // 
            // maNVComboBox
            // 
            this.maNVComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.v_DS_NhanVienBindingSource, "MANV", true));
            this.maNVComboBox.FormattingEnabled = true;
            this.maNVComboBox.Location = new System.Drawing.Point(90, 5);
            this.maNVComboBox.Name = "maNVComboBox";
            this.maNVComboBox.Size = new System.Drawing.Size(80, 24);
            this.maNVComboBox.TabIndex = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.maNVComboBox;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(175, 36);
            this.layoutControlItem2.Text = "Mã nhân viên:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(81, 16);
            // 
            // hoTenTextEdit
            // 
            this.hoTenTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.v_DS_NhanVienBindingSource, "HOTEN", true));
            this.hoTenTextEdit.Enabled = false;
            this.hoTenTextEdit.Location = new System.Drawing.Point(265, 5);
            this.hoTenTextEdit.Name = "hoTenTextEdit";
            this.hoTenTextEdit.Size = new System.Drawing.Size(276, 24);
            this.hoTenTextEdit.StyleController = this.layoutControl1;
            this.hoTenTextEdit.TabIndex = 6;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.hoTenTextEdit;
            this.layoutControlItem3.CustomizationFormText = "Họ & Tên:";
            this.layoutControlItem3.Location = new System.Drawing.Point(175, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(371, 36);
            this.layoutControlItem3.Text = "Họ và Tên:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(81, 17);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(363, 41);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(178, 23);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.dateTimePicker1;
            this.layoutControlItem1.Location = new System.Drawing.Point(273, 36);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(273, 35);
            this.layoutControlItem1.Text = "Đến ngày:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(81, 17);
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.CustomFormat = "yyyy-MM-dd";
            this.dateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerFrom.Location = new System.Drawing.Point(90, 41);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(178, 23);
            this.dateTimePickerFrom.TabIndex = 8;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.dateTimePickerFrom;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 36);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(273, 35);
            this.layoutControlItem4.Text = "Từ ngày:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(81, 17);
            // 
            // btnReview
            // 
            this.btnReview.Location = new System.Drawing.Point(5, 126);
            this.btnReview.Name = "btnReview";
            this.btnReview.Size = new System.Drawing.Size(183, 42);
            this.btnReview.TabIndex = 9;
            this.btnReview.Text = "Review";
            this.btnReview.UseVisualStyleBackColor = true;
            this.btnReview.Click += new System.EventHandler(this.btnReview_Click);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnReview;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 121);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(193, 52);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(198, 126);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(162, 42);
            this.btnPrint.TabIndex = 10;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnPrint;
            this.layoutControlItem6.Location = new System.Drawing.Point(193, 121);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(172, 52);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(370, 126);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(171, 42);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnExit;
            this.layoutControlItem7.Location = new System.Drawing.Point(365, 121);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(181, 52);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 71);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(546, 50);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // MenuHoatDongNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 173);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.LookAndFeel.SkinName = "Office 2016 Colorful";
            this.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MaximizeBox = false;
            this.Name = "MenuHoatDongNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuHoatDongNhanVien";
            this.Load += new System.EventHandler(this.MenuHoatDongNhanVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cN1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhanVienBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_DS_NhanVienBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hoTenTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CN1 cN1;
        private System.Windows.Forms.BindingSource nhanVienBindingSource;
        private CN1TableAdapters.NhanVienTableAdapter nhanVienTableAdapter;
        private CN1TableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private System.Windows.Forms.BindingSource v_DS_NhanVienBindingSource;
        private CN1TableAdapters.V_DS_NhanVienTableAdapter v_DS_NhanVienTableAdapter;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnReview;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private DevExpress.XtraEditors.TextEdit hoTenTextEdit;
        private System.Windows.Forms.ComboBox maNVComboBox;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}