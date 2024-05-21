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

namespace TTCN_Nhom7
{
    /// <summary>
    /// Interaction logic for TrangChu_user.xaml
    /// </summary>
    public partial class TrangChu_user : Window
    {
        public TrangChu_user()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            xemthongtin_user xemthongtin_User = new xemthongtin_user();
            xemthongtin_User.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            XemHoKhau_user xemthongtin = new XemHoKhau_user();
            xemthongtin.Show();
            Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PhanAnh_user phanAnh_User = new PhanAnh_user();
            phanAnh_User.Show();
            Close();
        }
    }
}
