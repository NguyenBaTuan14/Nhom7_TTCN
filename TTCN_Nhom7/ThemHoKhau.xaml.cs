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
using Microsoft.IdentityModel.Tokens;
using TTCN_Nhom7.Models;

namespace TTCN_Nhom7
{
    /// <summary>
    /// Interaction logic for ThemHoKhau.xaml
    /// </summary>
    public partial class ThemHoKhau : Window
    {
        QldanCuNguyenXaContext db = new QldanCuNguyenXaContext();
        public ThemHoKhau()
        {
            InitializeComponent();
            this.Left = 200;
            this.Top = 100;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HoKhau_admin HK = new HoKhau_admin();
            HK.Show();
            Close();
        }

        private void btnthem_Click(object sender, RoutedEventArgs e)
        {
            if (check())
            {
                NhanKhau nkmoi = new NhanKhau();
                HoKhau hkmoi= new HoKhau();
                ChuHo chmoi= new ChuHo();   
                hkmoi.MaHoKhau=txtmahk.Text;
                chmoi.MaChuHo= txtmach.Text;
                chmoi.SoCmndCccd= txtcccd.Text;
                chmoi.HoTen=txttench.Text;
                hkmoi.NgayDangKy = dpNgayDK.SelectedDate;

                db.ChuHos.Add(chmoi);
                db.SaveChanges();
                db.HoKhaus.Add(hkmoi);
                db.SaveChanges();

                HoKhau_admin wd = new HoKhau_admin();
                wd.Show();
                Close();
            }
        }
        private bool check()
        {
            if (txtmahk.Text.IsNullOrEmpty()|| txtcccd.Text.IsNullOrEmpty()|| txttench.Text.IsNullOrEmpty()||
                txtmach.Text.IsNullOrEmpty()|| txtdc.Text.IsNullOrEmpty()||dpNgayDK.Text.IsNullOrEmpty())
            {
                MessageBoxResult result = MessageBox.Show("Yêu cầu nhập đầy đủ thông tin", "THÔNG BÁO",
                                            MessageBoxButton.OKCancel, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

    }
}
