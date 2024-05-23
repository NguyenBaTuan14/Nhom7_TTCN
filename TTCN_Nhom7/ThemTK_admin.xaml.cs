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
using TTCN_Nhom7.QuanLyDanCu;

namespace TTCN_Nhom7
{
    /// <summary>
    /// Interaction logic for ThemTK_admin.xaml
    /// </summary>
    public partial class ThemTK_admin : Window
    {
        QlthongTinDanCuContext db = new QlthongTinDanCuContext();
        public ThemTK_admin()
        {
            InitializeComponent();
            this.Left = 200;
            this.Top = 100;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            QuanLyTaiKhoan_admin ql = new QuanLyTaiKhoan_admin();
            ql.Show();
            Close();
        }
        private void btnthem_Click(object sender, RoutedEventArgs e)
        {
            var query_check = from tk in db.TaiKhoans
                        join hk in db.HoKhaus on tk.MaTaiKhoan equals hk.MaTaiKhoan
                        join nk in db.NhanKhaus on hk.MaHoKhau equals nk.MaHoKhau
                        where nk.SoCmndCccd == txtcccd.Text
                        select tk;
            if (check())
            {
                if (query_check.Count() > 0)
                {
                    TaiKhoan tkmoi = new TaiKhoan();
                    var query_count = from tk in db.TaiKhoans
                                      select tk;
                    int count = query_count.Count();
                    string nextIndex = (count + 1).ToString().PadLeft(2, '0');
                    tkmoi.MaTaiKhoan = "TK0" + nextIndex;

                    tkmoi.Ho = txtho.Text;
                    tkmoi.Ten = txtten.Text;
                    tkmoi.SoDienThoai = txtsodt.Text;
                    tkmoi.Email = txtEmail.Text;
                    tkmoi.MatKhau = txtmatkhau.Text;
                    tkmoi.Role = txtrole.Text;

                    db.TaiKhoans.Add(tkmoi);
                    db.SaveChanges();

                    var query = from tk in db.TaiKhoans
                                orderby tk.MaTaiKhoan ascending
                                select new
                                {
                                    tk.MaTaiKhoan,
                                    tk.Ho,
                                    tk.Ten,
                                    tk.SoDienThoai,
                                    tk.Email,
                                    tk.MatKhau,
                                };

                    QuanLyTaiKhoan_admin ql = new QuanLyTaiKhoan_admin();
                    ql.dtgdanhsach.ItemsSource = query.ToList();
                    ql.Show();
                    Close();
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Hệ thống không chứa thông tin của người dân có số CCCD/CMND này", "THÔNG BÁO",
                                            MessageBoxButton.OKCancel, MessageBoxImage.Error);
                }
            }
        }
        private bool check()
        {
            if (txtcccd.Text.IsNullOrEmpty() || txtEmail.Text.IsNullOrEmpty() ||
                txtho.Text.IsNullOrEmpty() || txtten.Text.IsNullOrEmpty() ||
                txtmatkhau.Text.IsNullOrEmpty() || txtsodt.Text.IsNullOrEmpty() || 
                txtrole.Text.IsNullOrEmpty())
            {
                MessageBoxResult result = MessageBox.Show("Yêu cầu nhập đầy đủ thông tin", "THÔNG BÁO",
                                            MessageBoxButton.OKCancel, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}
