namespace QLVT_DATHANG
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbUser = new DevExpress.XtraEditors.TextEdit();
            this.v_DS_NhanVienBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cN1 = new QLVT_DATHANG.CN1();
            this.hOTENComboBox = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.rdUser = new System.Windows.Forms.RadioButton();
            this.rdChiNhanh = new System.Windows.Forms.RadioButton();
            this.rdCongTy = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.cbShow = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.v_DS_NhanVienTableAdapter = new QLVT_DATHANG.CN1TableAdapters.V_DS_NhanVienTableAdapter();
            this.tableAdapterManager = new QLVT_DATHANG.CN1TableAdapters.TableAdapterManager();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_DS_NhanVienBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cN1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbUser);
            this.groupBox1.Controls.Add(this.hOTENComboBox);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnSubmit);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.rdUser);
            this.groupBox1.Controls.Add(this.rdChiNhanh);
            this.groupBox1.Controls.Add(this.rdCongTy);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbShow);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbPassword);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbLogin);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(948, 439);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tạo tài khoản";
            // 
            // tbUser
            // 
            this.tbUser.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.v_DS_NhanVienBindingSource, "MANV", true));
            this.tbUser.Enabled = false;
            this.tbUser.Location = new System.Drawing.Point(580, 289);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(64, 22);
            this.tbUser.TabIndex = 16;
            // 
            // v_DS_NhanVienBindingSource
            // 
            this.v_DS_NhanVienBindingSource.DataMember = "V_DS_NhanVien";
            this.v_DS_NhanVienBindingSource.DataSource = this.cN1;
            // 
            // cN1
            // 
            this.cN1.DataSetName = "CN1";
            this.cN1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // hOTENComboBox
            // 
            this.hOTENComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.v_DS_NhanVienBindingSource, "HOTEN", true));
            this.hOTENComboBox.DataSource = this.v_DS_NhanVienBindingSource;
            this.hOTENComboBox.DisplayMember = "HOTEN";
            this.hOTENComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hOTENComboBox.FormattingEnabled = true;
            this.hOTENComboBox.Location = new System.Drawing.Point(339, 287);
            this.hOTENComboBox.Name = "hOTENComboBox";
            this.hOTENComboBox.Size = new System.Drawing.Size(233, 24);
            this.hOTENComboBox.TabIndex = 15;
            this.hOTENComboBox.ValueMember = "MANV";
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(911, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.MinimumSize = new System.Drawing.Size(37, 39);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(37, 39);
            this.btnClose.TabIndex = 14;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmit.Location = new System.Drawing.Point(386, 394);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(105, 31);
            this.btnSubmit.TabIndex = 12;
            this.btnSubmit.Text = "Tạo Login";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Image = ((System.Drawing.Image)(resources.GetObject("label5.Image")));
            this.label5.Location = new System.Drawing.Point(383, 33);
            this.label5.MinimumSize = new System.Drawing.Size(149, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 158);
            this.label5.TabIndex = 13;
            // 
            // rdUser
            // 
            this.rdUser.AutoSize = true;
            this.rdUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdUser.Location = new System.Drawing.Point(521, 346);
            this.rdUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdUser.Name = "rdUser";
            this.rdUser.Size = new System.Drawing.Size(56, 21);
            this.rdUser.TabIndex = 11;
            this.rdUser.TabStop = true;
            this.rdUser.Text = "User";
            this.rdUser.UseVisualStyleBackColor = true;
            // 
            // rdChiNhanh
            // 
            this.rdChiNhanh.AutoSize = true;
            this.rdChiNhanh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdChiNhanh.Location = new System.Drawing.Point(419, 346);
            this.rdChiNhanh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdChiNhanh.Name = "rdChiNhanh";
            this.rdChiNhanh.Size = new System.Drawing.Size(91, 21);
            this.rdChiNhanh.TabIndex = 10;
            this.rdChiNhanh.TabStop = true;
            this.rdChiNhanh.Text = "Chi nhánh";
            this.rdChiNhanh.UseVisualStyleBackColor = true;
            // 
            // rdCongTy
            // 
            this.rdCongTy.AutoSize = true;
            this.rdCongTy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdCongTy.Location = new System.Drawing.Point(329, 346);
            this.rdCongTy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdCongTy.Name = "rdCongTy";
            this.rdCongTy.Size = new System.Drawing.Size(79, 21);
            this.rdCongTy.TabIndex = 9;
            this.rdCongTy.TabStop = true;
            this.rdCongTy.Text = "Công ty";
            this.rdCongTy.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(285, 349);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Role:";
            // 
            // cbShow
            // 
            this.cbShow.AutoSize = true;
            this.cbShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbShow.Location = new System.Drawing.Point(580, 247);
            this.cbShow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbShow.Name = "cbShow";
            this.cbShow.Size = new System.Drawing.Size(64, 21);
            this.cbShow.TabIndex = 5;
            this.cbShow.Text = "Show";
            this.cbShow.UseVisualStyleBackColor = true;
            this.cbShow.CheckedChanged += new System.EventHandler(this.cbShow_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(293, 290);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "User:";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(338, 245);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(234, 23);
            this.tbPassword.TabIndex = 3;
            this.tbPassword.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(265, 249);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password:";
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(338, 203);
            this.tbLogin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(234, 23);
            this.tbLogin.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(289, 207);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login:";
            // 
            // v_DS_NhanVienTableAdapter
            // 
            this.v_DS_NhanVienTableAdapter.ClearBeforeFill = true;
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
            this.tableAdapterManager.UpdateOrder = QLVT_DATHANG.CN1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.VattuTableAdapter = null;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 467);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegisterForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RegisterForm_FormClosing);
            this.Load += new System.EventHandler(this.RegisterForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.v_DS_NhanVienBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cN1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rdUser;
        private System.Windows.Forms.RadioButton rdChiNhanh;
        private System.Windows.Forms.RadioButton rdCongTy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbShow;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.Label label1;
        private CN1 cN1;
        private System.Windows.Forms.BindingSource v_DS_NhanVienBindingSource;
        private CN1TableAdapters.V_DS_NhanVienTableAdapter v_DS_NhanVienTableAdapter;
        private CN1TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.ComboBox hOTENComboBox;
        private DevExpress.XtraEditors.TextEdit tbUser;
    }
}