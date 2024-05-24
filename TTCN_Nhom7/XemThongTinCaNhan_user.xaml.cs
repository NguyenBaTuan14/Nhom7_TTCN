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
using TTCN_Nhom7.QuanLyDanCu;

namespace TTCN_Nhom7
{
    /// <summary>
    /// Interaction logic for xemthongtin_user.xaml
    /// </summary>
    public partial class xemthongtin_user : Window
    {
        QlthongTinDanCuContext db = new QlthongTinDanCuContext();
        string taikhoan = "";
        public xemthongtin_user()
        {
            InitializeComponent();
            this.Left = 200;
            this.Top = 100;
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
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
            var query = from tk in db.TaiKhoans
                        join hk in db.HoKhaus on tk.MaTaiKhoan equals hk.MaTaiKhoan
                        join nk in db.NhanKhaus on hk.MaHoKhau equals nk.MaHoKhau
                        where tk.Email == taikhoan || tk.SoDienThoai == taikhoan
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
                            SoDT = tk.SoDienThoai,
                            Email = tk.Email,
                        };
            txtcccd.Text = from q in query
                           select q.SoCCCD;
            txthoten.Text = from q in query
                            select q.HoTen;
            txtgioitinh.Text = from q in query
                               select q.GioiTinh;
            txtngay.Text = from q in query
                           select q.NgaySinh;
            txtquanhe.Text = from q in query
                             select q.QuanHe;
            txtmahk.Text = from q in query
                           select q.MaHK;
            txtdiachi.Text = from q in query
                             select q.DiaChi;
            txtsodt.Text = from q in query
                           select q.SoDT;
            txtemail.Text = from q in query
                            select q.Email;
        }
    }
}
