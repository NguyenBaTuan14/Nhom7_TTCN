using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for PhanAnh_user.xaml
    /// </summary>
    public partial class PhanAnh_user : Window
    {
        QldanCuNguyenXaContext db = new QldanCuNguyenXaContext();
        private String taiKhoan;
        private object selectedRow;
        private string noiDungPhanAnh;

        public PhanAnh_user(String taiKhoan)
        {
            InitializeComponent();
            this.Left = 200;
            this.Top = 100;
            this.taiKhoan = taiKhoan;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TrangChu_user qv = new TrangChu_user(taiKhoan);
            qv.Show();
            Close();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            ThemPhanAnh_user them = new ThemPhanAnh_user(taiKhoan);
            them.Show();
            Close();
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(noiDungPhanAnh))
            {
                SuaPhanAnh_user sua = new SuaPhanAnh_user(taiKhoan, noiDungPhanAnh);
                sua.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một phản ánh để sửa.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void LoadData()
        {
            var query = from p in db.PhanAnhs
                        where p.MaTaiKhoanNavigation.Email == taiKhoan || p.MaTaiKhoanNavigation.SoDienThoai == taiKhoan
                        select new
                        {
                            Stt = 0, // Placeholder, will be updated later
                            p.NoiDungPhanAnh,
                            p.NoiDungPhanHoi,
                        };

            var result = query.ToList();
            for (int i = 0; i < result.Count; i++)
            {
                result[i] = new
                {
                    Stt = i + 1,
                    result[i].NoiDungPhanAnh,
                    result[i].NoiDungPhanHoi,
                };
            }

            dataGridPhanAnh.ItemsSource = result;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string searchText = txtSearch.Text;

            var query = from hd in db.PhanAnhs
                        join tk in db.TaiKhoans on hd.MaTaiKhoan equals tk.MaTaiKhoan
                        where tk.Email == taiKhoan || tk.SoDienThoai == taiKhoan
                        select new
                        {
                            hd.NoiDungPhanAnh,
                            hd.NoiDungPhanHoi,
                            tk.SoDienThoai,
                            tk.Email
                        };

            // Thực hiện truy vấn và chuyển dữ liệu về phía máy khách
            var resultList = query.ToList();

            // Lọc dữ liệu trên phía máy khách
            var result = resultList
                .Where(hd => hd.NoiDungPhanAnh.Contains(searchText))
                .Select((hd, index) => new
                {
                    Stt = index + 1,
                    hd.NoiDungPhanAnh,
                    hd.NoiDungPhanHoi
                })
                .ToList();

            if (!result.Any())
            {
                MessageBox.Show("Tên người phản ánh không tồn tại.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            dataGridPhanAnh.ItemsSource = result;
        }

        private void dataGridPhanAnh_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedRow = dataGridPhanAnh.SelectedItem;

            if (selectedRow != null)
            {
                Type t = selectedRow.GetType();
                PropertyInfo noiDungProp = t.GetProperty("NoiDungPhanAnh");

                if (noiDungProp != null)
                {
                    noiDungPhanAnh = noiDungProp.GetValue(selectedRow)?.ToString();
                }
            }
        }
    }
}
