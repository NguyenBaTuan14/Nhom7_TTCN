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
    /// Interaction logic for QuanLyTaiKhoan_admin.xaml
    /// </summary>
    public partial class QuanLyTaiKhoan_admin : Window
    {
        public QuanLyTaiKhoan_admin()
        {
            InitializeComponent();
            this.Left = 200;
            this.Top = 100;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 wd = new Window1();
            wd.Show();
            Close();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            ThemTK_admin themTK_Admin = new ThemTK_admin();
            themTK_Admin.Show();
            Close();
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            SuaTK_admin themSK_Admin = new SuaTK_admin();
            themSK_Admin.Show();
            Close();
        }
    }
}
