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
            int? tuoi = null;
            if (int.TryParse(txtTuoi.Text, out int parsedTuoi))
            {
                tuoi = parsedTuoi;
            }
            bool? gioiTinh = null;
            if (rdoNam.IsChecked == true)
            {
                gioiTinh = true;
            }
            else if (rdoNu.IsChecked == true)
            {
                gioiTinh = false;
            }

            using (QlthongTinDanCuContext db = new QlthongTinDanCuContext())
            {
                try
                {
                    var query = db.NhanKhaus.AsQueryable();

                    if (!string.IsNullOrEmpty(hoTen))
                    {
                        query = query.Where(tk => tk.HoTen.Contains(hoTen, StringComparison.OrdinalIgnoreCase));
                    }
                    if (!string.IsNullOrEmpty(diaChi))
                    {
                        query = query.Where(tk => tk.DiaChiThuongChu.Contains(diaChi, StringComparison.OrdinalIgnoreCase));
                    }
                    if (gioiTinh.HasValue)
                    {
                        query = query.Where(tk => tk.GioiTinh == gioiTinh.Value);
                    }
                    if (tuoi.HasValue)
                    {
                 //       query = query.Where(tk => tk.Tuoi == tuoi.Value);
                    }

                    var result = query.Select(tk => new
                    {
                        tk.MaNhanKhau,
                        tk.HoTen,
                        GioiTinh = (bool)tk.GioiTinh ? "nam" : "nữ",
                   //     tk.Tuoi,
                        tk.DiaChiThuongChu,
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
