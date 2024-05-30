using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
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
    /// Interaction logic for xemthongtin_user.xaml
    /// </summary>
    public partial class xemthongtin_user : Window
    {

        private String taiKhoan;
        QldanCuNguyenXaContext db = new QldanCuNguyenXaContext();
        public xemthongtin_user(String taikhoan)
        {
            InitializeComponent();
            this.Left = 200;
            this.Top = 100;
            this.taiKhoan = taiKhoan;
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TrangChu_user trangChuUser = new TrangChu_user(taiKhoan);
            trangChuUser.Show();
            Close();
        }
        private void window_load(object sender, RoutedEventArgs e)
        {
            var query = from nk in db.ChuHos
                        where nk.MaTaiKhoanNavigation.Email == taiKhoan || nk.MaTaiKhoanNavigation.SoDienThoai == taiKhoan
                        select new
                        {   
                            MaHK = nk.MaHoKhau,
                            SoCCCD = nk.SoCmndCccd,
                            HoTen = nk.HoTen,
                            GioiTinh = (bool)nk.GioiTinh ? "Nữ" : "Nam",
                            NgaySinh = nk.NgaySinh,
                            HoKhau = nk.MaHoKhau,
                            DiaChi = nk.DiaChiThuongChu,
                            SoDT = nk.MaTaiKhoanNavigation.SoDienThoai,
                            Email = nk.MaTaiKhoanNavigation.Email,
                        };
            // Gán giá trị từ query vào các textbox
            txtcccd.Text = query.FirstOrDefault()?.SoCCCD ?? "";
            txthoten.Text = query.FirstOrDefault()?.HoTen ?? "";
            txtgioitinh.Text = query.FirstOrDefault()?.GioiTinh ?? "";
            txtngay.Text = query.FirstOrDefault()?.NgaySinh?.ToString("dd/MM/yyyy") ?? "";
            txtmahk.Text = query.FirstOrDefault()?.MaHK.ToString() ?? "";
            txtdiachi.Text = query.FirstOrDefault()?.DiaChi ?? "";
            txtsodt.Text = query.FirstOrDefault()?.SoDT ?? "";
            txtemail.Text = query.FirstOrDefault()?.Email ?? "";
        }
    }
}
