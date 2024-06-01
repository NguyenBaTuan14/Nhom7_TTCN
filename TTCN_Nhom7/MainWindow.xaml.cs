using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TTCN_Nhom7.DuLieuDanCu;

namespace TTCN_Nhom7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
            this.Left = 200;
            this.Top = 100;
        }

        private String kiemTraDangNhap(String taiKhoan, String matKhau)
        {
            string role = null;
            try
            {
                using (QldanCuNguyenXa1Context db = new QldanCuNguyenXa1Context())
                {
                    var query = from tk in db.TaiKhoans
                                where (tk.Email == taiKhoan || tk.SoDienThoai == taiKhoan) && tk.MatKhau == matKhau
                                select tk.Role;

                    role = query.FirstOrDefault();  // Retrieve the first matching role
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối với cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return role;
        }
        private void Login(object sender, RoutedEventArgs e)
        {

            string taiKhoan = txtTaiKhoan.Text;
            string matKhau = txtMatKhau.Password;

            var userRole = kiemTraDangNhap(taiKhoan, matKhau);

            if (userRole != null)
            {
                if (userRole == "admin")
                {
                    MessageBox.Show("Đăng nhập thành công với vai trò Admin!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    Window1 adminWindow = new Window1();
                    adminWindow.Show();
                    Close();
                }
                else if (userRole == "user")
                {

                    MessageBox.Show("Đăng nhập thành công với vai trò User!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

                    TrangChu_user userWindow = new TrangChu_user(taiKhoan);
                    userWindow.Show();
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            

        }
    }
}
