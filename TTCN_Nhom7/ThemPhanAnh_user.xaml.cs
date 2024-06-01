using Microsoft.IdentityModel.Tokens;
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

using TTCN_Nhom7.MoHinhQuanLy;


namespace TTCN_Nhom7
{
    /// <summary>
    /// Interaction logic for ThemPhanAnh_user.xaml
    /// </summary>
    public partial class ThemPhanAnh_user : Window
    {
        QldanCuNguyenXaContext db = new QldanCuNguyenXaContext();
        private String taiKhoan;
        public ThemPhanAnh_user(string taiKhoan)
        {
            InitializeComponent();
            this.Left = 200;
            this.Top = 100;
            this.taiKhoan = taiKhoan;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (check())
            {
                PhanAnh paMoi = new PhanAnh();

                paMoi.NoiDungPhanAnh = NDphananh.Text;



                var query_count = from pa in db.PhanAnhs
                                  select pa;
                int count = query_count.Count();
                string nextIndex = (count + 1).ToString().PadLeft(2, '0');
                paMoi.MaPhanAnh = "PA" + nextIndex;
                var query = from tk in db.TaiKhoans
                            where tk.SoDienThoai == taiKhoan || tk.Email == taiKhoan
                            select tk.MaTaiKhoan;
                paMoi.MaTaiKhoan = query.FirstOrDefault();
                db.PhanAnhs.Add(paMoi);
                db.SaveChanges();
                var query1 = from p in db.PhanAnhs
                             where p.MaTaiKhoanNavigation.Email == taiKhoan || p.MaTaiKhoanNavigation.SoDienThoai == taiKhoan
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
                phanAnh_User.Show();
                Close();
            }
            
        }
        private bool check()
            {
                if (NDphananh.Text.IsNullOrEmpty())
                {
                    MessageBoxResult result = MessageBox.Show("Yêu cầu nhập đầy đủ thông tin", "THÔNG BÁO",
                                                MessageBoxButton.OKCancel, MessageBoxImage.Error);
                    return false;
                }
                return true;
            }
    }
}
