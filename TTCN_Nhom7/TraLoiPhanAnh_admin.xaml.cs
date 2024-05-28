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
using TTCN_Nhom7.DuLieuQuanLyDanCu;

namespace TTCN_Nhom7
{
    /// <summary>
    /// Interaction logic for TraLoiPhanAnh_admin.xaml
    /// </summary>
    public partial class TraLoiPhanAnh_admin : Window
    {
        QldanCuNguyenXaContext db = new QldanCuNguyenXaContext();
        String noiDungCauHoi, nguoiPhanAnh;
        public TraLoiPhanAnh_admin(String nd,String ng)
        {
            InitializeComponent();
            this.Left = 200;
            this.Top = 100;
            this.noiDungCauHoi = nd;
            this.nguoiPhanAnh = ng;
        }

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            PhanAnh_admin phanAnh = new PhanAnh_admin();
            phanAnh.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var query = from hd in db.PhanAnhs
                        
                        where (hd.MaTaiKhoanNavigation.Ho + " " + hd.MaTaiKhoanNavigation.Ten) == nguoiPhanAnh
                        select hd;
            PhanAnh hoiDap = query.SingleOrDefault();
            hoiDap.NoiDungPhanHoi = NDtraloi.Text;
            db.SaveChanges();
            var query1 = from p in db.PhanAnhs
                        
                        select new
                        {
                            Stt = 0, // Placeholder, will be updated later
                            p.NoiDungPhanAnh,
                            p.NoiDungPhanHoi,
                            NguoiPhanAnh = p.MaTaiKhoanNavigation.Ho + " " + p.MaTaiKhoanNavigation.Ten
                        };

            var result = query1.ToList();
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
            PhanAnh_admin pa = new PhanAnh_admin();
            pa.dataGridPhanAnh.ItemsSource = result;
            pa.Show();
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            NDphananh.Text = noiDungCauHoi;

        }
    }
}
