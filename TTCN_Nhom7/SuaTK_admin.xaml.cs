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
    /// Interaction logic for SuaTK_admin.xaml
    /// </summary>
    public partial class SuaTK_admin : Window
    {
        QldanCuNguyenXaContext db = new QldanCuNguyenXaContext();
        string matk, ho, ten, sodt, email, matkhau, ngaycap, vaitro = "";
        public SuaTK_admin()
        {
            InitializeComponent();
            this.Left = 200;
            this.Top = 100;
        }
        public SuaTK_admin(string matk, string ho, string ten, string sodt, string email, string mk, string vaitro)
        {
            InitializeComponent();
            this.Left = 200;
            this.Top = 100;
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
             var query_tim = from tk in db.TaiKhoans
                            where tk.MaTaiKhoan == txtmatk.Text
                            select tk;

                TaiKhoan tkmoi = query_tim.SingleOrDefault();

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
    }
}
