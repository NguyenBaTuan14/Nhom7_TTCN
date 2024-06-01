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
using TTCN_Nhom7.MoHinhQuanLy;

namespace TTCN_Nhom7
{
    /// <summary>
    /// Interaction logic for ThemTK_admin.xaml
    /// </summary>
    public partial class ThemTK_admin : Window
    {
        QldanCuNguyenXaContext db = new QldanCuNguyenXaContext();
        string hoten = "";
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
                MessageBoxResult result = MessageBox.Show("Yêu cầu nhập thông tin!!", "THÔNG BÁO",
                                            MessageBoxButton.OKCancel, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private void btntim_onclick(object sender, RoutedEventArgs e)
        {
            var query_find = from ch in db.ChuHos
                             where ch.SoCmndCccd == txtcccd.Text
                             //  !query_cccd_ch.Any(q_ch => q_ch.SoCMND == nk2.SoCmndCccd)
                             select new
                             {
                                 Ma = ch.MaChuHo,
                                 MaTaiKhoan = ch.MaTaiKhoan,
                                 HoTen = ch.HoTen,
                                 ch.MaHoKhau,
                                 GioiTinh = (bool)ch.GioiTinh ? "Nữ" : "Nam",
                                 ch.NgaySinh,
                                 ch.DiaChiThuongChu,
                             };
            if (check())
            {
                if (query_find.Count() > 0)
                {             
                    var firstResult = query_find.FirstOrDefault();
                    hoten = firstResult?.HoTen;

                    dtgdanhsach.ItemsSource = query_find.ToList();
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
                var query_mtk = from ch in db.ChuHos
                                where ch.SoCmndCccd == txtcccd.Text &&
                                    ch.MaTaiKhoan == null
                                select ch;
                
                if(query_mtk.Count() > 0)
                {
                    email_password ep = new email_password(hoten);
                    ep.Show();
                    Close();
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Chủ hộ này được cấp quyền rồi", "THÔNG BÁO",
                                                                MessageBoxButton.OKCancel, MessageBoxImage.Error);
                }
            }
        }
    }
}
