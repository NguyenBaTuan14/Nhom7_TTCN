using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for ThongKe.xaml
    /// </summary>
    public partial class ThongKe : Window
    {
        public List<NhanKhau> NhanKhauList { get; set; }
        public ThongKe()
        {
            InitializeComponent();
        }
        private void QuayVe(object sender, RoutedEventArgs e)
        {
            Window1 wd = new Window1();
            wd.Show();
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string hoTen = txtHoTen.Text;
            string diaChi = txtDiaChi.Text;
            
            bool? gioiTinh = null;
            if (rdoNam.IsChecked == true)
            {
                gioiTinh = true;
            }
            else if (rdoNu.IsChecked == true)
            {
                gioiTinh = false;
            }

            using (QldanCuNguyenXaContext db = new QldanCuNguyenXaContext())
            {
                try
                {
                    var query = db.NhanKhaus
                    //.Include(nk => nk.MaTaiKhoanNavigation)
                    .Include(nk => nk.MaHoKhauNavigation)
                    .AsQueryable();

                    if (!string.IsNullOrEmpty(txtHoTen.Text))
                    {

                        query = query.Where(nk => nk.HoTen.Contains(txtHoTen.Text));

                    }

                    if (rdoNam.IsChecked == true)
                    {
                        query = query.Where(nk => nk.GioiTinh == true);
                    }
                    else if (rdoNu.IsChecked == true)
                    {
                        query = query.Where(nk => nk.GioiTinh == false);
                    }

                    if (int.TryParse(txtTuoi.Text, out int tuoi))
                    {
                        var minBirthDate = DateTime.Now.AddYears(-tuoi - 1).AddDays(1);
                        var maxBirthDate = DateTime.Now.AddYears(-tuoi);
                        query = query.Where(nk => nk.NgaySinh >= minBirthDate && nk.NgaySinh <= maxBirthDate);
                    }

                    if (!string.IsNullOrEmpty(txtDiaChi.Text))
                    {
                        query = query.Where(nk => nk.DiaChiThuongChu.Contains(txtDiaChi.Text));
                    }
                    var result = query.Select(tk => new
                    {
                        tk.SoCmndCccd,
                        tk.HoTen,
                        tk.DiaChiThuongChu,
                        GioiTinh = (bool)tk.GioiTinh ? "nam" : "nữ",

                      //  tk.Tuoi,
                        tk.MaHoKhauNavigation.MaHoKhau,
                    //    tk.MaTaiKhoanNavigation.SoDienThoai,
                     //   tk.MaTaiKhoanNavigation.Email

                    }).ToList();
                    
                    dataGridThongKe.ItemsSource = result;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối với cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }
    }
}
