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
        QldanCuNguyenXaContext db = new QldanCuNguyenXaContext();
        string taikhoan = "";
        public xemthongtin_user()
        {
            InitializeComponent();
            this.Left = 200;
            this.Top = 100;
        }
        public xemthongtin_user(string tk)
        {
            InitializeComponent();
            this.Left = 200;
            this.Top = 100;
            this.taikhoan = tk;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TrangChu_user trangChuUser = new TrangChu_user();
            trangChuUser.Show();
            Close();
        }
        private void window_load(object sender, RoutedEventArgs e)
        {
            var query = from nk in db.NhanKhaus
                        where nk.MaTaiKhoanNavigation.Email == taikhoan || nk.MaTaiKhoanNavigation.SoDienThoai == taikhoan
                        select new
                        {   
                            MaHK = nk.MaHoKhau,
                            SoCCCD = nk.SoCmndCccd,
                            HoTen = nk.HoTen,
                            GioiTinh = (bool)nk.GioiTinh ? "Nữ" : "Nam",
                            NgaySinh = nk.NgaySinh,
                            QuanHe = nk.QuanHeVoiChuHo,
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
            txtquanhe.Text = query.FirstOrDefault()?.QuanHe ?? "";
            txtmahk.Text = query.FirstOrDefault()?.MaHK.ToString() ?? "";
            txtdiachi.Text = query.FirstOrDefault()?.DiaChi ?? "";
            txtsodt.Text = query.FirstOrDefault()?.SoDT ?? "";
            txtemail.Text = query.FirstOrDefault()?.Email ?? "";
        }
    }
}
