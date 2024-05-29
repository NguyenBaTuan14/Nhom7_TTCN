using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection;
using System.Security.Cryptography;
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
using TTCN_Nhom7.DuLieuQuanLyDanCu;

namespace TTCN_Nhom7
{
    /// <summary>
    /// Interaction logic for QuanLyTaiKhoan_admin.xaml
    /// </summary>
    public partial class QuanLyTaiKhoan_admin : Window
    {
        QldanCuNguyenXaContext db = new QldanCuNguyenXaContext();
        private object selectedRow;
        string matk, ho, ten, sodt, email, matkhau, vaitro = "";
        public QuanLyTaiKhoan_admin()
        {
            InitializeComponent();
            this.Left = 200;
            this.Top = 100;

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HienThiDuLieu();
        }
        private void HienThiDuLieu()
        {
            try
            {
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

                dtgdanhsach.ItemsSource = query.ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối với cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 wd = new Window1();
            wd.Show();
            Close();
        }
        private void btntim_onclick(object sender, RoutedEventArgs e)
        {
            var query = from tk in db.TaiKhoans
                        where tk.MaTaiKhoan == txttim.Text
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
            if (query.IsNullOrEmpty())
            {
                MessageBoxResult result = MessageBox.Show("Không có mã nhân khẩu này", "THÔNG BÁO",
                                            MessageBoxButton.OKCancel, MessageBoxImage.Error);

            }
            else
                dtgdanhsach.ItemsSource = query.ToList();
        }
        private void dtgdanhsach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedRow = dtgdanhsach.SelectedItem;

            if (selectedRow != null)
            {
                Type t = selectedRow.GetType();
                PropertyInfo[] a = t.GetProperties();
                matk = a[0].GetValue(selectedRow).ToString();
                txttim.Text = matk;
                ho = a[1].GetValue(selectedRow).ToString();
                ten = a[2].GetValue(selectedRow).ToString();
                sodt = a[3].GetValue(selectedRow).ToString();
                email = a[4].GetValue(selectedRow).ToString();
                matkhau = a[5].GetValue(selectedRow).ToString();
            }
        }
        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            var query = from tk in db.TaiKhoans
                        where tk.MaTaiKhoan == txttim.Text
                        select tk;

            MessageBoxResult result = MessageBox.Show("Có xác nhận xóa không", "XÁC NHẬN XÓA",
                                            MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                if (query.Count() > 0)
                {
                    TaiKhoan tkxoa = query.SingleOrDefault();
                    db.TaiKhoans.Remove(tkxoa);
                    db.SaveChanges();
                    HienThiDuLieu();
                }
            }
            else
            {
                HienThiDuLieu();
                txttim.Text = "";
                txttim.Focus();
            }
        }
        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            ThemTK_admin themTK_Admin = new ThemTK_admin();
            themTK_Admin.Show();
            Close();
        }
        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            var query = from tk in db.TaiKhoans
                        select new
                        {
                            MaTK = tk.MaTaiKhoan,
                            HoTen = tk.Ho + " " + tk.Ten
                        };

            var query_role = from tk in db.TaiKhoans
                             where tk.MaTaiKhoan == matk
                             select tk.Role;
            vaitro = query_role.First();

            SuaTK_admin themSK_Admin = new SuaTK_admin(matk, ho, ten, sodt, email, matkhau, vaitro);
            themSK_Admin.Show();
            Close();
        }
    }
}
