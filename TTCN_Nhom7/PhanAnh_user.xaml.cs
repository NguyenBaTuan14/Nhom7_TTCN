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
    /// Interaction logic for PhanAnh_user.xaml
    /// </summary>
    public partial class PhanAnh_user : Window
    {
        public PhanAnh_user()
        {
            InitializeComponent();
            this.Left = 200;
            this.Top = 100;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TrangChu_user qv = new TrangChu_user();
            qv.Show();
            Close();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            ThemPhanAnh_user them = new ThemPhanAnh_user();
            them.Show();
            Close();
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            SuaPhanAnh_user sua = new SuaPhanAnh_user();
            sua.Show();
            Close();
        }
    }
}
