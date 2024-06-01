using Microsoft.IdentityModel.Tokens;
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
using System.Windows.Shapes;
using TTCN_Nhom7.DuLieuDanCu;

namespace TTCN_Nhom7
{
    /// <summary>
    /// Interaction logic for email_password.xaml
    /// </summary>
    public partial class email_password : Window
    {
        QldanCuNguyenXa1Context db = new QldanCuNguyenXa1Context();
        string hoten = "";
        public email_password(string hoten)
        {
            InitializeComponent();
            this.hoten = hoten;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ThemTK_admin them = new ThemTK_admin();
            them.Show();
            Close();
        }
        private void btn_add(object sender, RoutedEventArgs e)
        {
            if (check())
            {
                string ht = hoten;
                ht = ht.Trim();

                int len = ht.Length;
                int i = ht.LastIndexOf(" ");

                string Ten = ht.Substring(i + 1);
                string Ho = ht.Substring(0, i);
                
                TaiKhoan tkmoi = new TaiKhoan();

                var query_count = from tk in db.TaiKhoans
                                  select tk;
                int count = query_count.Count();
                string nextIndex = (count + 1).ToString().PadLeft(2, '0');
                tkmoi.MaTaiKhoan = "TK" + nextIndex;

                tkmoi.Ho = Ho;
                tkmoi.Ten = Ten;
                tkmoi.Email = txtemail.Text;
                tkmoi.SoDienThoai = txtsodt.Text;
                tkmoi.MatKhau = txtmatkhau.Password;
                tkmoi.Role = txtrule.Text;
                db.TaiKhoans.Add(tkmoi);
                db.SaveChanges();

                QuanLyTaiKhoan_admin ql = new QuanLyTaiKhoan_admin();
                ql.Show();
                Close();
            }
        }
        private bool check()
        {
            if (txtmatkhau.Password.IsNullOrEmpty() || txtrule.Text.IsNullOrEmpty())
            {
                MessageBoxResult result = MessageBox.Show("Yêu cầu nhập thông tin!!s", "THÔNG BÁO",
                                            MessageBoxButton.OKCancel, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}
