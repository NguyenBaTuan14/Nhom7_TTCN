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
using TTCN_Nhom7.DuLieuQuanLyDanCu;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TTCN_Nhom7
{
    /// <summary>
    /// Interaction logic for SuaHoKhau.xaml
    /// </summary>
    public partial class SuaHoKhau : Window
    {
        QldanCuNguyenXaContext db = new QldanCuNguyenXaContext();
        string mahk,mach, tench,cccd,dctc  = "";
        DateTime ndk= DateTime.Now;
        private string ngaydk;

        
        private bool check()
        {
            if (txtmahk.Text.IsNullOrEmpty() || txtcccd.Text.IsNullOrEmpty() || txttench.Text.IsNullOrEmpty() ||
                txtmach.Text.IsNullOrEmpty() || txtdctc.Text.IsNullOrEmpty() || dpNgayDK.Text.IsNullOrEmpty())
            {
                MessageBoxResult result = MessageBox.Show("Yêu cầu nhập đầy đủ thông tin", "THÔNG BÁO",
                                            MessageBoxButton.OKCancel, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        public SuaHoKhau(string mhk, string mch, string tench, string cccd, DateTime ndk, string dctc)
        {
            InitializeComponent();
            this.Left = 200;
            this.Top = 100;
            this.mahk = mhk;
            this.mach = mch;
            this.tench = tench;
            this.cccd = cccd;
            this.ndk = ndk;
            this.dctc = dctc;

        }

        public SuaHoKhau(string mahk, string mach, string tench, string cccd, string ngaydk, string dctc)
        {
            this.mahk = mahk;
            this.mach = mach;
            this.tench = tench;
            this.cccd = cccd;
            this.ngaydk = ngaydk;
            this.dctc = dctc;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HoKhau_admin HK = new HoKhau_admin();
            HK.Show();
            Close();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtmahk.Text = mahk;
            dpNgayDK.SelectedDate= ndk ;
            txttench.Text = tench;
            txtmach.Text = mach;
            txtcccd.Text = cccd;
            txtdctc.Text = dctc;

        }
        private void btnsua_Click(object sender, RoutedEventArgs e)
        {
            if (check())
            {
                var query = from hk in db.HoKhaus
                            where hk.MaHoKhau == txtmahk.Text
                            select hk;
                HoKhau hkmoi = query.SingleOrDefault();
                var querych = from ch in db.ChuHos
                            where ch.MaHoKhau == txtmahk.Text
                            select ch;
                ChuHo chmoi = querych.SingleOrDefault();
                hkmoi.MaHoKhau = txtmahk.Text;
                chmoi.MaChuHo = txtmach.Text;
                chmoi.SoCmndCccd = txtcccd.Text;
                chmoi.HoTen = txttench.Text;
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
    }
}
