namespace QLVT_DATHANG
{
    partial class StorageForm
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
            System.Windows.Forms.Label tENCNLabel;
            System.Windows.Forms.Label mAKHOLabel;
            System.Windows.Forms.Label tENKHOLabel;
            System.Windows.Forms.Label dIACHILabel;
            System.Windows.Forms.Label mACNLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StorageForm));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAddStorage = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelStorage = new DevExpress.XtraBars.BarButtonItem();
            this.btnSaveStorage = new DevExpress.XtraBars.BarButtonItem();
            this.btnUndo = new DevExpress.XtraBars.BarButtonItem();
            this.btnReload = new DevExpress.XtraBars.BarButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.qLVT_DATHANGDataSet = new QLVT_DATHANG.QLVT_DATHANGDataSet();
            this.v_DS_PHANMANHBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.v_DS_PHANMANHTableAdapter = new QLVT_DATHANG.QLVT_DATHANGDataSetTableAdapters.V_DS_PHANMANHTableAdapter();
            this.tableAdapterManager = new QLVT_DATHANG.QLVT_DATHANGDataSetTableAdapters.TableAdapterManager();
            this.tenCNComboBox = new System.Windows.Forms.ComboBox();
            this.cN1 = new QLVT_DATHANG.CN1();
            this.khoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.khoTableAdapter = new QLVT_DATHANG.CN1TableAdapters.KhoTableAdapter();
            this.tableAdapterManager1 = new QLVT_DATHANG.CN1TableAdapters.TableAdapterManager();
            this.khoGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMAKHO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTENKHO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDIACHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMACN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.maKhoTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.maCNTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.diaChiTextEdit = new System.Windows.Forms.TextBox();
            this.tenKhoTextEdit = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelNhomNV = new DevExpress.XtraEditors.LabelControl();
            this.labelTenNV = new DevExpress.XtraEditors.LabelControl();
            this.labelMaNV = new DevExpress.XtraEditors.LabelControl();
            tENCNLabel = new System.Windows.Forms.Label();
            mAKHOLabel = new System.Windows.Forms.Label();
            tENKHOLabel = new System.Windows.Forms.Label();
            dIACHILabel = new System.Windows.Forms.Label();
            mACNLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLVT_DATHANGDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_DS_PHANMANHBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cN1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.khoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.khoGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maKhoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maCNTextEdit.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tENCNLabel
            // 
            tENCNLabel.AutoSize = true;
            tENCNLabel.Location = new System.Drawing.Point(25, 80);
            tENCNLabel.Name = "tENCNLabel";
            tENCNLabel.Size = new System.Drawing.Size(75, 17);
            tENCNLabel.TabIndex = 5;
            tENCNLabel.Text = "Chi nhánh:";
            // 
            // mAKHOLabel
            // 
            mAKHOLabel.AutoSize = true;
            mAKHOLabel.Location = new System.Drawing.Point(235, 50);
            mAKHOLabel.Name = "mAKHOLabel";
            mAKHOLabel.Size = new System.Drawing.Size(57, 17);
            mAKHOLabel.TabIndex = 7;
            mAKHOLabel.Text = "Mã kho:";
            // 
            // tENKHOLabel
            // 
            tENKHOLabel.AutoSize = true;
            tENKHOLabel.Location = new System.Drawing.Point(224, 112);
            tENKHOLabel.Name = "tENKHOLabel";
            tENKHOLabel.Size = new System.Drawing.Size(63, 17);
            tENKHOLabel.TabIndex = 9;
            tENKHOLabel.Text = "Tên kho:";
            // 
            // dIACHILabel
            // 
            dIACHILabel.AutoSize = true;
            dIACHILabel.Location = new System.Drawing.Point(527, 55);
            dIACHILabel.Name = "dIACHILabel";
            dIACHILabel.Size = new System.Drawing.Size(53, 17);
            dIACHILabel.TabIndex = 11;
            dIACHILabel.Text = "Địa chỉ:";
            // 
            // mACNLabel
            // 
            mACNLabel.AutoSize = true;
            mACNLabel.Location = new System.Drawing.Point(490, 112);
            mACNLabel.Name = "mACNLabel";
            mACNLabel.Size = new System.Drawing.Size(94, 17);
            mACNLabel.TabIndex = 13;
            mACNLabel.Text = "Mã chi nhánh:";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnAddStorage,
            this.btnDelStorage,
            this.btnSaveStorage,
            this.btnUndo,
            this.btnReload,
            this.btnExit});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 7;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnAddStorage, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDelStorage, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSaveStorage, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnUndo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnReload, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnExit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnAddStorage
            // 
            this.btnAddStorage.Caption = "Thêm kho";
            this.btnAddStorage.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAddStorage.Glyph")));
            this.btnAddStorage.Id = 1;
            this.btnAddStorage.Name = "btnAddStorage";
            this.btnAddStorage.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddStorage_ItemClick);
            // 
            // btnDelStorage
            // 
            this.btnDelStorage.Caption = "Xóa kho";
            this.btnDelStorage.Glyph = ((System.Drawing.Image)(resources.GetObject("btnDelStorage.Glyph")));
            this.btnDelStorage.Id = 2;
            this.btnDelStorage.Name = "btnDelStorage";
            this.btnDelStorage.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelStorage_ItemClick);
            // 
            // btnSaveStorage
            // 
            this.btnSaveStorage.Caption = "Lưu kho";
            this.btnSaveStorage.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSaveStorage.Glyph")));
            this.btnSaveStorage.Id = 3;
            this.btnSaveStorage.Name = "btnSaveStorage";
            this.btnSaveStorage.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSaveStorage_ItemClick);
            // 
            // btnUndo
            // 
            this.btnUndo.Caption = "Undo";
            this.btnUndo.Glyph = ((System.Drawing.Image)(resources.GetObject("btnUndo.Glyph")));
            this.btnUndo.Id = 4;
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUndo_ItemClick);
            // 
            // btnReload
            // 
            this.btnReload.Caption = "Reload";
            this.btnReload.Glyph = ((System.Drawing.Image)(resources.GetObject("btnReload.Glyph")));
            this.btnReload.Id = 5;
            this.btnReload.Name = "btnReload";
            this.btnReload.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReload_ItemClick);
            // 
            // btnExit
            // 
            this.btnExit.Caption = "Thoát";
            this.btnExit.Glyph = ((System.Drawing.Image)(resources.GetObject("btnExit.Glyph")));
            this.btnExit.Id = 6;
            this.btnExit.Name = "btnExit";
            this.btnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExit_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(798, 71);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 737);
            this.barDockControlBottom.Size = new System.Drawing.Size(798, 25);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 71);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 666);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(798, 71);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 666);
            // 
            // qLVT_DATHANGDataSet
            // 
            this.qLVT_DATHANGDataSet.DataSetName = "QLVT_DATHANGDataSet";
            this.qLVT_DATHANGDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // v_DS_PHANMANHBindingSource
            // 
            this.v_DS_PHANMANHBindingSource.DataMember = "V_DS_PHANMANH";
            this.v_DS_PHANMANHBindingSource.DataSource = this.qLVT_DATHANGDataSet;
            // 
            // v_DS_PHANMANHTableAdapter
            // 
            this.v_DS_PHANMANHTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ChiNhanhTableAdapter = null;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.CTDDHTableAdapter = null;
            this.tableAdapterManager.CTPNTableAdapter = null;
            this.tableAdapterManager.CTPXTableAdapter = null;
            this.tableAdapterManager.DatHangTableAdapter = null;
            this.tableAdapterManager.KhoTableAdapter = null;
            this.tableAdapterManager.NhanVienTableAdapter = null;
            this.tableAdapterManager.PhieuNhapTableAdapter = null;
            this.tableAdapterManager.PhieuXuatTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = QLVT_DATHANG.QLVT_DATHANGDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.VattuTableAdapter = null;
            // 
            // tenCNComboBox
            // 
            this.tenCNComboBox.DataSource = this.v_DS_PHANMANHBindingSource;
            this.tenCNComboBox.DisplayMember = "TENCN";
            this.tenCNComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tenCNComboBox.Enabled = false;
            this.tenCNComboBox.FormattingEnabled = true;
            this.tenCNComboBox.Location = new System.Drawing.Point(106, 77);
            this.tenCNComboBox.Name = "tenCNComboBox";
            this.tenCNComboBox.Size = new System.Drawing.Size(671, 24);
            this.tenCNComboBox.TabIndex = 6;
            this.tenCNComboBox.ValueMember = "TENSERVER";
            this.tenCNComboBox.SelectedIndexChanged += new System.EventHandler(this.tenCNCNComboBox_SelectedIndexChanged);
            // 
            // cN1
            // 
            this.cN1.DataSetName = "CN1";
            this.cN1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // khoBindingSource
            // 
            this.khoBindingSource.DataMember = "Kho";
            this.khoBindingSource.DataSource = this.cN1;
            // 
            // khoTableAdapter
            // 
            this.khoTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.ChiNhanhTableAdapter = null;
            this.tableAdapterManager1.CTDDHTableAdapter = null;
            this.tableAdapterManager1.CTPNTableAdapter = null;
            this.tableAdapterManager1.CTPXTableAdapter = null;
            this.tableAdapterManager1.DatHangTableAdapter = null;
            this.tableAdapterManager1.KhoTableAdapter = this.khoTableAdapter;
            this.tableAdapterManager1.NhanVienTableAdapter = null;
            this.tableAdapterManager1.PhieuNhapTableAdapter = null;
            this.tableAdapterManager1.PhieuXuatTableAdapter = null;
            this.tableAdapterManager1.UpdateOrder = QLVT_DATHANG.CN1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager1.VattuTableAdapter = null;
            // 
            // khoGridControl
            // 
            this.khoGridControl.DataSource = this.khoBindingSource;
            this.khoGridControl.Location = new System.Drawing.Point(0, 107);
            this.khoGridControl.MainView = this.gridView1;
            this.khoGridControl.MenuManager = this.barManager1;
            this.khoGridControl.Name = "khoGridControl";
            this.khoGridControl.Size = new System.Drawing.Size(797, 445);
            this.khoGridControl.TabIndex = 6;
            this.khoGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.khoGridControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.khoGridControl_MouseDown);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMAKHO,
            this.colTENKHO,
            this.colDIACHI,
            this.colMACN});
            this.gridView1.GridControl = this.khoGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            // 
            // colMAKHO
            // 
            this.colMAKHO.Caption = "Mã kho";
            this.colMAKHO.FieldName = "MAKHO";
            this.colMAKHO.Name = "colMAKHO";
            this.colMAKHO.Visible = true;
            this.colMAKHO.VisibleIndex = 0;
            // 
            // colTENKHO
            // 
            this.colTENKHO.Caption = "Tên kho";
            this.colTENKHO.FieldName = "TENKHO";
            this.colTENKHO.Name = "colTENKHO";
            this.colTENKHO.Visible = true;
            this.colTENKHO.VisibleIndex = 1;
            // 
            // colDIACHI
            // 
            this.colDIACHI.Caption = "Địa chỉ";
            this.colDIACHI.FieldName = "DIACHI";
            this.colDIACHI.Name = "colDIACHI";
            this.colDIACHI.Visible = true;
            this.colDIACHI.VisibleIndex = 2;
            // 
            // colMACN
            // 
            this.colMACN.Caption = "Mã chi nhánh";
            this.colMACN.FieldName = "MACN";
            this.colMACN.Name = "colMACN";
            this.colMACN.Visible = true;
            this.colMACN.VisibleIndex = 3;
            // 
            // maKhoTextEdit
            // 
            this.maKhoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.khoBindingSource, "MAKHO", true));
            this.maKhoTextEdit.Enabled = false;
            this.maKhoTextEdit.Location = new System.Drawing.Point(295, 47);
            this.maKhoTextEdit.MenuManager = this.barManager1;
            this.maKhoTextEdit.Name = "maKhoTextEdit";
            this.maKhoTextEdit.Size = new System.Drawing.Size(170, 22);
            this.maKhoTextEdit.TabIndex = 8;
            // 
            // maCNTextEdit
            // 
            this.maCNTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.khoBindingSource, "MACN", true));
            this.maCNTextEdit.Enabled = false;
            this.maCNTextEdit.Location = new System.Drawing.Point(590, 109);
            this.maCNTextEdit.MenuManager = this.barManager1;
            this.maCNTextEdit.Name = "maCNTextEdit";
            this.maCNTextEdit.Size = new System.Drawing.Size(170, 22);
            this.maCNTextEdit.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.diaChiTextEdit);
            this.groupBox1.Controls.Add(this.tenKhoTextEdit);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(mACNLabel);
            this.groupBox1.Controls.Add(mAKHOLabel);
            this.groupBox1.Controls.Add(this.maCNTextEdit);
            this.groupBox1.Controls.Add(dIACHILabel);
            this.groupBox1.Controls.Add(tENKHOLabel);
            this.groupBox1.Controls.Add(this.maKhoTextEdit);
            this.groupBox1.Location = new System.Drawing.Point(0, 558);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(797, 183);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // diaChiTextEdit
            // 
            this.diaChiTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.khoBindingSource, "DIACHI", true));
            this.diaChiTextEdit.Location = new System.Drawing.Point(590, 52);
            this.diaChiTextEdit.MaxLength = 100;
            this.diaChiTextEdit.Name = "diaChiTextEdit";
            this.diaChiTextEdit.Size = new System.Drawing.Size(170, 23);
            this.diaChiTextEdit.TabIndex = 2;
            // 
            // tenKhoTextEdit
            // 
            this.tenKhoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.khoBindingSource, "TENKHO", true));
            this.tenKhoTextEdit.Location = new System.Drawing.Point(294, 112);
            this.tenKhoTextEdit.MaxLength = 30;
            this.tenKhoTextEdit.Name = "tenKhoTextEdit";
            this.tenKhoTextEdit.Size = new System.Drawing.Size(171, 23);
            this.tenKhoTextEdit.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(76, 41);
            this.label1.MaximumSize = new System.Drawing.Size(112, 112);
            this.label1.MinimumSize = new System.Drawing.Size(112, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 112);
            this.label1.TabIndex = 15;
            // 
            // labelNhomNV
            // 
            this.labelNhomNV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNhomNV.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNhomNV.Location = new System.Drawing.Point(653, 739);
            this.labelNhomNV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelNhomNV.Name = "labelNhomNV";
            this.labelNhomNV.Size = new System.Drawing.Size(49, 23);
            this.labelNhomNV.TabIndex = 23;
            this.labelNhomNV.Text = "Nhóm";
            // 
            // labelTenNV
            // 
            this.labelTenNV.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelTenNV.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTenNV.Location = new System.Drawing.Point(295, 739);
            this.labelTenNV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelTenNV.Name = "labelTenNV";
            this.labelTenNV.Size = new System.Drawing.Size(32, 23);
            this.labelTenNV.TabIndex = 22;
            this.labelTenNV.Text = "Tên";
            // 
            // labelMaNV
            // 
            this.labelMaNV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelMaNV.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMaNV.Location = new System.Drawing.Point(14, 739);
            this.labelMaNV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelMaNV.Name = "labelMaNV";
            this.labelMaNV.Size = new System.Drawing.Size(112, 23);
            this.labelMaNV.TabIndex = 21;
            this.labelMaNV.Text = "Mã nhân viên";
            // 
            // StorageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 762);
            this.Controls.Add(this.labelNhomNV);
            this.Controls.Add(this.labelTenNV);
            this.Controls.Add(this.labelMaNV);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.khoGridControl);
            this.Controls.Add(tENCNLabel);
            this.Controls.Add(this.tenCNComboBox);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.LookAndFeel.SkinName = "Metropolis";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MaximizeBox = false;
            this.Name = "StorageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StorageForm";
            this.Load += new System.EventHandler(this.StorageForm_Load);
            this.VisibleChanged += new System.EventHandler(this.StorageForm_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLVT_DATHANGDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_DS_PHANMANHBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cN1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.khoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.khoGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maKhoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maCNTextEdit.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnAddStorage;
        private DevExpress.XtraBars.BarButtonItem btnDelStorage;
        private DevExpress.XtraBars.BarButtonItem btnSaveStorage;
        private DevExpress.XtraBars.BarButtonItem btnUndo;
        private DevExpress.XtraBars.BarButtonItem btnReload;
        private System.Windows.Forms.BindingSource v_DS_PHANMANHBindingSource;
        private QLVT_DATHANGDataSet qLVT_DATHANGDataSet;
        private QLVT_DATHANGDataSetTableAdapters.V_DS_PHANMANHTableAdapter v_DS_PHANMANHTableAdapter;
        private QLVT_DATHANGDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.ComboBox tenCNComboBox;
        private DevExpress.XtraBars.BarButtonItem btnExit;
        private CN1 cN1;
        private System.Windows.Forms.BindingSource khoBindingSource;
        private CN1TableAdapters.KhoTableAdapter khoTableAdapter;
        private CN1TableAdapters.TableAdapterManager tableAdapterManager1;
        private DevExpress.XtraGrid.GridControl khoGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit maCNTextEdit;
        private DevExpress.XtraEditors.TextEdit maKhoTextEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colMAKHO;
        private DevExpress.XtraGrid.Columns.GridColumn colTENKHO;
        private DevExpress.XtraGrid.Columns.GridColumn colDIACHI;
        private DevExpress.XtraGrid.Columns.GridColumn colMACN;
        private DevExpress.XtraEditors.LabelControl labelNhomNV;
        private DevExpress.XtraEditors.LabelControl labelTenNV;
        private DevExpress.XtraEditors.LabelControl labelMaNV;
        private System.Windows.Forms.TextBox diaChiTextEdit;
        private System.Windows.Forms.TextBox tenKhoTextEdit;


    }
}