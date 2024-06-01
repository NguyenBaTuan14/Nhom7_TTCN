using Microsoft.EntityFrameworkCore.Query;
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
    /// Interaction logic for suanhankhau.xaml
    /// </summary>
    public partial class suanhankhau : Window
    {
        QldanCuNguyenXaContext db = new QldanCuNguyenXaContext();
        string hoten, mahk, mank, socccd, gt, diachi, quanhe, tongiao, dantoc, ngaysinh, nghe = "";

        public suanhankhau( string ht,string hk, string nk, string cccd, string gt, string dc, string qh, string tg, string dt, string ns, string nghe)
        {
            InitializeComponent();
            this.Left = 200;
            this.Top = 100;
            this.hoten = ht;
            this.mahk = hk;
            this.mank = nk;
            this.socccd = cccd;
            this.gt = gt;
            this.diachi = dc;
            this.quanhe = qh;
            this.tongiao = tg;
            this.dantoc = dt;
            this.ngaysinh = ns;
            this.nghe = nghe;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window2 wd = new Window2();
            wd.Show();
            Close();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txthoten.Text = hoten;
            txtmank.Text = mank;
            txtmank.IsEnabled = false;
            txtquanhe.Text = quanhe;
            txtmahk.Text = mahk;
            txtmahk.IsEnabled = false;
            txtcccd.Text = socccd;
            if (gt == "Nữ")
            {
                radnu.IsChecked = true;
            }
            else
                radnam.IsChecked = true;
            dtpngaysinh.Text = ngaysinh;
            txtdiachi.Text = diachi;

            txttongiao.Text = tongiao;
            txtdantoc.Text = dantoc;
            txtnghe.Text = nghe;
        }
        private void btnsua_onclick(object sender, RoutedEventArgs e)
        {
            var query = from nk in db.NhanKhaus
                        where nk.MaNhanKhau == txtmank.Text
                        select nk;

            NhanKhau nkmoi = query.SingleOrDefault();
            nkmoi.HoTen = txthoten.Text;
            nkmoi.SoCmndCccd = txtcccd.Text;

            nkmoi.MaHoKhau = txtmahk.Text;
            nkmoi.MaNhanKhau = txtmank.Text;

            if (radnam.IsChecked == true)
            {
                nkmoi.GioiTinh = false;
            }
            else if (radnu.IsChecked == true)
            {
                nkmoi.GioiTinh = true;
            }
            nkmoi.DiaChiThuongChu = txtdiachi.Text;
            nkmoi.QuanHeVoiChuHo = txtquanhe.Text;
            nkmoi.TonGiao = txttongiao.Text;
            nkmoi.DanToc = txtdantoc.Text;
            nkmoi.NgaySinh = dtpngaysinh.SelectedDate;
            nkmoi.NgheNghiep = txtnghe.Text;
            db.SaveChanges();

            var query1 = from nk in db.NhanKhaus
                        orderby nk.MaNhanKhau ascending
                        select new
                        {
                            nk.MaNhanKhau,
                            nk.HoTen,
                            nk.QuanHeVoiChuHo,
                            nk.MaHoKhau,
                            nk.SoCmndCccd,
                            GioiTinh = (bool)nk.GioiTinh ? "Nữ" : "Nam",
                            nk.NgaySinh,
                            nk.DiaChiThuongChu,
                        };
            Window2 wd = new Window2();
            wd.dtgdanhsach.ItemsSource = query1.ToList();
            wd.Show();
            Close();
        }
    }
}
