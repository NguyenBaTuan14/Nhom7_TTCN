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
using TTCN_Nhom7.Models;

namespace TTCN_Nhom7
{
    /// <summary>
    /// Interaction logic for XemHoKhau_user.xaml
    /// </summary>
    public partial class XemHoKhau_user : Window
    {
        private string taiKhoan = "";
        QldanCuNguyenXaContext db = new QldanCuNguyenXaContext();
        public XemHoKhau_user(String taikhoan)
        {
            InitializeComponent();
            this.Left = 200;
            this.Top = 100;
            this.taiKhoan = taikhoan;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TrangChu_user trangChuUser = new TrangChu_user(taiKhoan);
            trangChuUser.Show();
            Close();
        }
        private void window_load(object sender, RoutedEventArgs e)
        {
            var query = from ch in db.ChuHos
                        where ch.MaTaiKhoanNavigation.Email == taiKhoan || ch.MaTaiKhoanNavigation.SoDienThoai == taiKhoan
                        select new
                        {
                            MaHK = ch.MaHoKhau,
                            mach =ch.MaChuHo,
                            SoCCCD = ch.SoCmndCccd,
                            HoTen = ch.HoTen,
                            DiaChi = ch.DiaChiThuongChu,
                            dpNgayDK=ch.MaHoKhauNavigation.NgayDangKy
                        };
  
            txtcccd.Text = query.FirstOrDefault()?.SoCCCD ?? "";
            txtmahk.Text = query.FirstOrDefault()?.MaHK ?? "";
            txtmach.Text = query.FirstOrDefault()?.mach ?? "";
            txtNgayDK.Text = query.FirstOrDefault()?.dpNgayDK?.ToString("dd/MM/yyyy") ?? "";
            txttench.Text = query.FirstOrDefault()?.HoTen ?? "";
            txtdctc.Text = query.FirstOrDefault()?.DiaChi ?? "";
        }
    }
}
