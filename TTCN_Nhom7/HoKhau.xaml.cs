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
    /// Interaction logic for HoKhau.xaml
    /// </summary>
    public partial class HoKhau : Window
    {
        public HoKhau()
        {
            InitializeComponent();
            this.Left = 200;
            this.Top = 100;
        }

        private void Quay_Ve(object sender, RoutedEventArgs e)
        {
            Window1 wd = new Window1();
            wd.Show();
            Close();
        }

        private void btnthem_onclick(object sender, RoutedEventArgs e)
        {
            ThemHoKhau them = new ThemHoKhau();
            them.Show();
            Close();
        }

        private void btnsua_onclick(object sender, RoutedEventArgs e)
        {
            SuaHoKhau suaHoKhau = new SuaHoKhau();
            suaHoKhau.Show();
            Close();
        }
    }
}
