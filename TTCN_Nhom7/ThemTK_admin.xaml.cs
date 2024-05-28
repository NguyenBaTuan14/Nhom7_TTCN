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
using TTCN_Nhom7.MoHinhDuLieu;

namespace TTCN_Nhom7
{
    /// <summary>
    /// Interaction logic for ThemTK_admin.xaml
    /// </summary>
    public partial class ThemTK_admin : Window
    {
        QldanCuNguyenXaContext db = new QldanCuNguyenXaContext();
        string hoten;
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
        private bool check()
        {
            if (txtcccd.Text.IsNullOrEmpty())
            {
                MessageBoxResult result = MessageBox.Show("Yêu cầu nhập thông tin!!s", "THÔNG BÁO",
                                            MessageBoxButton.OKCancel, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private void btntim_onclick(object sender, RoutedEventArgs e)
        {
            var query_cccd_nk  = from tk in db.TaiKhoans
                             join nk in db.NhanKhaus on tk.MaTaiKhoan equals nk.MaTaiKhoan
                             select new
                             {
                                 SoCMND = nk.SoCmndCccd,
                             };
            var query_cccd_ch = from ch in db.ChuHos
                                select new
                                {
                                    SoCMND = ch.SoCmndCccd,
                                };
            var query_find = from nk2 in db.NhanKhaus
                                 where nk2.SoCmndCccd == txtcccd.Text &&
                                    !query_cccd_nk.Any(q_nk => q_nk.SoCMND == nk2.SoCmndCccd) &&
                                    !query_cccd_ch.Any(q_ch => q_ch.SoCMND == nk2.SoCmndCccd)
                                 select nk2;
            if (check())
            {
                if (query_find.Count() > 0)
                {             
                    var query = from nk in db.NhanKhaus
                                select new
                                {
                                    Ma = nk.MaNhanKhau,
                                    HoTen = nk.HoTen,
                                    nk.MaHoKhau,
                                    nk.GioiTinh,
                                    nk.NgaySinh,
                                    nk.DiaChiThuongChu,
                                };
                    var firstResult = query.FirstOrDefault();
                    string hoten = firstResult?.HoTen;

                    dtgdanhsach.ItemsSource = query.ToList();
                    Close();
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Hệ thống không chứa thông tin của người dân có số CCCD/CMND này", "THÔNG BÁO",
                                            MessageBoxButton.OKCancel, MessageBoxImage.Error);
                }
            }
        }
        private void btnadd_Click(object sender, RoutedEventArgs e)
        {
            if(dtgdanhsach.Items.Count == 0)
{
                MessageBoxResult result = MessageBox.Show("Yêu cầu chọn nhập số CMND để cấp quyền", "THÔNG BÁO",
                                            MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
            else
            {
                email_password ep = new email_password(hoten);
                ep.Show();
                Close();
            }
        }
    }
}
