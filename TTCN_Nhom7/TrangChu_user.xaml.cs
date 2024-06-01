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
using System.Windows.Documents.Serialization;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TTCN_Nhom7.MoHinhQuanLy;

namespace TTCN_Nhom7
{
    /// <summary>
    /// Interaction logic for TrangChu_user.xaml
    /// </summary>
    public partial class TrangChu_user : Window
    {

        private string taiKhoan, tieuDeTB = "";
        private object selectedRow;
        public TrangChu_user(string taiKhoan)
        {
            InitializeComponent();
            this.Left = 200;
            this.Top = 100;
            this.taiKhoan = taiKhoan;
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            xemthongtin_user xemthongtin_User = new xemthongtin_user(taiKhoan);
            xemthongtin_User.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            XemHoKhau_user xemthongtin = new XemHoKhau_user(taiKhoan);
            xemthongtin.Show();
            Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PhanAnh_user phanAnh_User = new PhanAnh_user(taiKhoan);
            phanAnh_User.Show();
            Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {


            DocThongBao Doc = new DocThongBao(taiKhoan,tieuDeTB);
            Doc.Show();
            Close();
        }
        private void loadData()
        {
            QldanCuNguyenXaContext db = new QldanCuNguyenXaContext();
            var query = from tk in db.TaiKhoans
                        from tb in tk.MaThongBaos
                        where tk.Email == taiKhoan ||tk.SoDienThoai==taiKhoan
                        select new
                        {
                            Stt = 0, // Placeholder, will be updated later
                            tb.TieuDeThongBao,
                            tb.NgayThongBao,
                            
                        };

            var result = query.ToList();
            for (int i = 0; i < result.Count; i++)
            {
                result[i] = new
                {
                    Stt = i + 1,
                    result[i].TieuDeThongBao,
                    result[i].NgayThongBao,
                    
                };
            }

            dataGridThongBao.ItemsSource = result;
        }

        private void dataGridThongBao_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedRow = dataGridThongBao.SelectedItem;

            if (selectedRow != null)
            {
                Type t = selectedRow.GetType();
                PropertyInfo[] a = t.GetProperties();

                tieuDeTB = a[1].GetValue(selectedRow).ToString();
                 

            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            LienHe lh = new LienHe(taiKhoan);
            lh.Show();
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadData();

            LienHe lh = new LienHe(taiKhoan);
            lh.Show();
            lh.Close();

        }
    }
}
