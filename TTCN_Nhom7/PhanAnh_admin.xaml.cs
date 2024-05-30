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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TTCN_Nhom7.DuLieuQuanLyDanCu;

namespace TTCN_Nhom7
{
    /// <summary>
    /// Interaction logic for PhanAnh.xaml
    /// </summary>
    public partial class PhanAnh_admin : Window
    {
        QldanCuNguyenXaContext db = new QldanCuNguyenXaContext();
        String noiDungCauHoi, nguoiPhanAnh;
        private object selectedRow;
        public PhanAnh_admin()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Logic to go back to the previous window
            Window1 nw = new Window1();
            nw.Show();
            this.Close();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var query = from hd in db.PhanAnhs 

                        where hd.MaTaiKhoanNavigation.Ten == phananh.Text
                        select new
                        {
                            Stt = 0,
                            hd.NoiDungPhanAnh,
                            hd.NoiDungPhanHoi,
                            NguoiPhanAnh = hd.MaTaiKhoanNavigation.Ho +" "+ hd.MaTaiKhoanNavigation.Ten
                        };

            if(query.Count() <= 0 )
            {
                MessageBox.Show("Tên người phản ánh không tồn tại.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else
            {
                var result = query.ToList();
                for(int i = 0 ; i < result.Count; i++)
                {
                    result[i] = new
                    {
                        Stt = i + 1,
                        result[i].NoiDungPhanAnh,
                        result[i].NoiDungPhanHoi,
                        result[i].NguoiPhanAnh
                    };
                }
                dataGridPhanAnh.ItemsSource = result;
            }
            
                        
        }

        private void LoadData()
        {
            
                var query = from p in db.PhanAnhs
                            
                            select new
                            {
                                Stt = 0, // Placeholder, will be updated later
                                p.NoiDungPhanAnh,
                                p.NoiDungPhanHoi,
                                NguoiPhanAnh = p.MaTaiKhoanNavigation.Ho + " " + p.MaTaiKhoanNavigation.Ten
                            };

                var result = query.ToList();
                for (int i = 0; i < result.Count; i++)
                {
                    result[i] = new
                    {
                        Stt = i + 1,
                        result[i].NoiDungPhanAnh,
                        result[i].NoiDungPhanHoi,
                        result[i].NguoiPhanAnh
                    };
                }

                dataGridPhanAnh.ItemsSource = result;
            
        }
        private void dtgdanhsach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedRow = dataGridPhanAnh.SelectedItem;

            if (selectedRow != null)
            {
                Type t = selectedRow.GetType();
                PropertyInfo[] a = t.GetProperties();
                
                noiDungCauHoi = a[1].GetValue(selectedRow).ToString();
                nguoiPhanAnh = a[3].GetValue(selectedRow).ToString();
                
            }
        }

        private void ReplyButton_Click(object sender, RoutedEventArgs e)
        {
            /*var button = sender as Button;
            var selectedPhanAnh = button?.DataContext;

            if (selectedPhanAnh != null)
            {
                // Assuming selectedPhanAnh is of an anonymous type and we cannot access its properties directly.
                // We would need a more concrete type for full access.
                NDphananh.Text = selectedPhanAnh.NoiDungCauHoi.ToString();
                // Show the reply section
                btnTraLoi.Visibility = Visibility.Visible;
                btnSua.Visibility = Visibility.Visible;
            }*/
            var findTl = from hd in db.PhanAnhs
                         
                         where (hd.MaTaiKhoanNavigation.Ho + " " + hd.MaTaiKhoanNavigation.Ten) == nguoiPhanAnh
                         select hd.NoiDungPhanAnh;
            noiDungCauHoi = findTl.First();
            TraLoiPhanAnh_admin tl = new TraLoiPhanAnh_admin(noiDungCauHoi,nguoiPhanAnh);
            tl.Show();
        }

        private void SaveReply_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridPhanAnh.SelectedItem is not null)
            {
               /* var selectedPhanAnh = dataGridPhanAnh.SelectedItem;
                string replyContent = NDtraloi.Text;

                if (string.IsNullOrWhiteSpace(replyContent))
                {
                    MessageBox.Show("Nội dung trả lời không được để trống.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                using (var db = new QlthongTinDanCuContext())
                {
                    // Assuming that selectedPhanAnh contains the relevant ID or can be matched uniquely in the database.
                    // You will need to replace the below line with actual fetching and updating logic.
                    var phanAnhToUpdate = db.HoiDaps.SingleOrDefault(pa => pa.MaCauHoi == selectedPhanAnh.MaCauHoi);
                    if (phanAnhToUpdate != null)
                    {
                        phanAnhToUpdate.NoiDungCauTraloi = replyContent;
                        db.SaveChanges();
                        MessageBox.Show("Phản hồi đã được gửi thành công.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy phản ánh để cập nhật.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }*/
            }
        }

        
    }
}
