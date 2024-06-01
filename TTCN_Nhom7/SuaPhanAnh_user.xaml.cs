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

using TTCN_Nhom7.DuLieuDanCu;


namespace TTCN_Nhom7
{
    /// <summary>
    /// Interaction logic for SuaPhanAnh_user.xaml
    /// </summary>
    public partial class SuaPhanAnh_user : Window
    {
        private String taiKhoan;
        QldanCuNguyenXa1Context db = new QldanCuNguyenXa1Context();
        private String noiDungPhanAnh;

        public SuaPhanAnh_user(String taiKhoan, String noiDungPhanAnh)
        {
            InitializeComponent();
            this.Left = 200;
            this.Top = 100;
            this.taiKhoan = taiKhoan;
            this.noiDungPhanAnh = noiDungPhanAnh;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var query = from pa in db.PhanAnhs
                        where pa.MaTaiKhoanNavigation.Email == taiKhoan || pa.MaTaiKhoanNavigation.SoDienThoai == taiKhoan
                        select pa;

            // Retrieve the records and perform the comparison in C#
            var hoiDap = query.ToList().SingleOrDefault(pa => pa.NoiDungPhanAnh == noiDungPhanAnh);
            if (hoiDap != null)
            {
                hoiDap.NoiDungPhanAnh = NDphananhmoi.Text;
                db.SaveChanges();

                var query1 = from p in db.PhanAnhs
                             select new
                             {
                                 Stt = 0, // Placeholder, will be updated later
                                 p.NoiDungPhanAnh,
                                 p.NoiDungPhanHoi,
                             };

                var result = query1.ToList();
                for (int i = 0; i < result.Count; i++)
                {
                    result[i] = new
                    {
                        Stt = i + 1,
                        result[i].NoiDungPhanAnh,
                        result[i].NoiDungPhanHoi,
                    };
                }

                PhanAnh_user phanAnh_User = new PhanAnh_user(taiKhoan);
                phanAnh_User.dataGridPhanAnh.ItemsSource = result;
                phanAnh_User.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Không tìm thấy phản ánh cần sửa.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            NDphananh.Text = noiDungPhanAnh;
        }
    }
}
