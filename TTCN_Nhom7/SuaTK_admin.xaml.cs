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
    /// Interaction logic for SuaTK_admin.xaml
    /// </summary>
    public partial class SuaTK_admin : Window
    {
        QlthongTinDanCuContext db = new QlthongTinDanCuContext();
        string matk, socccd, ho, ten, sodt, email, matkhau, ngaycap, vaitro = "";
        public SuaTK_admin()
        {
            InitializeComponent();
            this.Left = 200;
            this.Top = 100;
        }
        public SuaTK_admin(string matk, string socccd, string ho, string ten, string sodt, string email, string mk, string vaitro)
        {
            InitializeComponent();
            this.Left = 200;
            this.Top = 100;
            this.socccd = socccd;
            this.ho = ho;
            this.ten = ten;
            this.sodt = sodt;
            this.email = email;
            this.matkhau = mk;
            this.vaitro = vaitro;
            this.matk = matk;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            QuanLyTaiKhoan_admin ql = new QuanLyTaiKhoan_admin();
            ql.Show();
            Close();
        }
        private void window_load(object sender, RoutedEventArgs e)
        {
            txtcccd.Text = socccd;
            txtho.Text = ho;
            txtten.Text = ten;
            txtsodt.Text = sodt;
            txtEmail.Text = email;
            txtmatkhau.Text = matkhau;
            txtrole.Text = vaitro;
            txtmatk.Text = matk;
            txtmatk.IsEnabled = false;
        }
        private void btnsua_Click(object sender, RoutedEventArgs e)
        {
            var query_check = from tk in db.TaiKhoans
                              join hk in db.HoKhaus on tk.MaTaiKhoan equals hk.MaTaiKhoan
                              join nk in db.NhanKhaus on hk.MaHoKhau equals nk.MaHoKhau
                              where nk.SoCmndCccd == txtcccd.Text
                              select tk;
            if (query_check.Count() > 0)
            {
                var query_tim = from tk in db.TaiKhoans
                            where tk.MaTaiKhoan == txtmatk.Text
                            select tk;

                TaiKhoan tkmoi = query_tim.SingleOrDefault();

                var query1 = from tk in db.TaiKhoans
                            join hk in db.HoKhaus on tk.MaTaiKhoan equals hk.MaTaiKhoan
                            join nk in db.NhanKhaus on hk.MaHoKhau equals nk.MaHoKhau
                            select new
                            {
                                MaTK = tk.MaTaiKhoan,
                                HoTen = tk.Ho + " " + tk.Ten
                            };
  /*              var query_nk = from q in query1
                                 join hk in db.HoKhaus on q.MaTK equals hk.MaTaiKhoan
                                 join nk in db.NhanKhaus on hk.MaHoKhau equals nk.MaHoKhau
                                 where nk.HoTen.Contains(q.HoTen)
                                 select nk;

                NhanKhau nksua = query_nk.SingleOrDefault();
                nksua.SoCmndCccd = txtcccd.Text;*/

                tkmoi.Ho = txtho.Text;
                tkmoi.Ten = txtten.Text;
                tkmoi.SoDienThoai = txtsodt.Text;
                tkmoi.Email = txtEmail.Text;
                tkmoi.MatKhau = txtmatkhau.Text;
                tkmoi.Role = txtrole.Text;

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
}
