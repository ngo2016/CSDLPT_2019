using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using System.Data;
using System.Data.SqlClient;
using DevExpress.XtraEditors;
using System.Text;

namespace QLVT_DATHANG
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary> 
        /// 
        // forms declaration
        public static MainForm mainForm;
        public static EmployeeForm employeeForm;
        public static StorageForm storageForm;
        public static ProductForm productForm;
        public static LoginForm loginForm;
        public static RegisterForm registerForm;
        public static SubForm.ThemVT addProductForm;
        public static SubForm.ThemKho addStorageForm;
        public static SubForm.LapDonDatHang addDDHForm;
        public static SubForm.LapPhieuNhap addPhieuNhapForm;
        public static SubForm.LapPhieuXuat addPhieuXuatForm;
        public static SubForm.ThemNV addEmployeeForm;
        public static SubForm.LapPhieuNhap_AddNew addNewPhieuNhap;

        public static Report.ReviewDanhSachVatTu reviewDanhSachVatTu;
        public static Report.MenuDanhSachNhanVien menuDanhSachNhanVien;
        public static Report.ReviewDanhSachNhanVien reviewDanhSachNhanVien;
        public static Report.DanhSachNhanVien danhSachNhanVien;
        public static Report.ReviewKeKhai reviewKeKhai;
        public static Report.MenuHoatDongNhanVien menuHoatDongNhanVien;
        public static Report.MenuTongHopNhapXuat menuTongHopNhapXuat;
        public static Report.TongHopNhapXuat tongHopNhapXuat;

        public static bool flagCloseRegisterForm;
        public static bool flagCloseFormThemNV;
        public static bool flagCloseFormThemVT;
        public static bool flagCloseFormThemKho;

        public static int reportFlag = 0;

        public static SqlConnection connect = new SqlConnection();
        public static String connectString = "";
        public static SqlDataReader dataReader;
        public static String servername = "";
        public static String username = "";
        public static String password = "";

        public static String serverLogin = "";

        public static String database = "QLVT_DATHANG";

        public static String remoteLogin = "HTKN";
        public static String remotePassword = "z";

        public static String usernameCurrent = "";
        public static String passwordCurrent = "";

        public static String group = "";
        public static String hoten = "";
        public static int chiNhanh = 0;

        public static BindingSource bdsDanhSachPhanManh = new BindingSource();  // giữ bdsPhanManh khi đăng nhập

        //kiem tra chuoi rong
        public static bool isEmpty(TextEdit value)
        {
            bool empty = value.Text.Length == 0;
            if (empty)
            {
                MessageBox.Show("Trường này không được để rỗng");
                value.Focus();
            }
            return empty;
        }
        //xoa cac ky tu dac biet trong chuoi
        public static string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_' || c == ' ')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public static SqlDataReader ExecSqlDataReader(String strLenh)
        {
            SqlDataReader myreader;
            SqlCommand sqlcmd = new SqlCommand(strLenh, Program.connect);
            sqlcmd.CommandType = CommandType.Text;

            if (Program.connect.State == ConnectionState.Closed) Program.connect.Open();

            try
            {
                myreader = sqlcmd.ExecuteReader();
                return myreader;
            }
            catch (SqlException ex)
            {
                Program.connect.Close();
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        //update, insert sp
        public static void execStoreProcedure(SqlCommand sqlcmd)
        {
            if (Program.connect.State == ConnectionState.Closed) Program.connect.Open();
            sqlcmd.ExecuteNonQuery();
        }

        public static int execStoreProcedureWithReturnValue(SqlCommand sqlcmd)
        {
            if (Program.connect.State == ConnectionState.Closed) Program.connect.Open();
            SqlParameter retval = sqlcmd.Parameters.Add("@return_value", SqlDbType.Int);
            retval.Direction = ParameterDirection.ReturnValue;
            try { sqlcmd.ExecuteNonQuery(); }
            catch (Exception) { }
            return int.Parse(sqlcmd.Parameters["@return_value"].Value.ToString());

        }

        public static DataTable ExecSqlDataTable(String cmd)
        {
            DataTable dt = new DataTable();
            if (Program.connect.State == ConnectionState.Closed) Program.connect.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd, Program.connect);
            da.Fill(dt);
            connect.Close();
            return dt;
        }

        public static int KetNoi()
        {
            //neu chung ta dang co connection va trang thai ket noi hien tai dang mo
            if (Program.connect != null && Program.connect.State == ConnectionState.Open)
            {
                Program.connect.Close();// dong ket noi
            }

            try
            {
                Program.connectString = "Data Source=" + Program.servername + ";Initial Catalog=" +
                          Program.database + ";User ID=" +
                          Program.serverLogin + ";password=" + Program.password;
                Program.connect.ConnectionString = Program.connectString;
                Program.connect.Open();
                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu.\n-Xem lại user name và password.\n-Xem lại chi nhánh!\n" + e.Message, "DoAn.exe", MessageBoxButtons.OK);
                return 0;
            }
        }

        //chuyen chi nhanh de xem du lieu
        public static void chuyenChiNhanh(string server)
        {
            if (server == "null")
            {
                return;
            }
            //neu server ma user chon dang la server dang truy cap thi bao loi va out
            if (server == Program.servername)
            {
                return;
            }


            Program.servername = server;

            // luu lai vi tri server dang dung
            String temp = Program.serverLogin;

            // thiet lap vi tri hien tai la o remote
            Program.serverLogin = Program.remoteLogin;
            Program.password = Program.remotePassword;
            Program.connectString = "Data Source=" + Program.servername + ";Initial Catalog=" +
                      Program.database + ";User ID=" + Program.serverLogin + ";password=" + Program.password;
            // chuyen remote thanh server da luu o tren
            Program.remoteLogin = temp;
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            loginForm = new LoginForm();
            Application.Run(loginForm);
        }
    }

}
