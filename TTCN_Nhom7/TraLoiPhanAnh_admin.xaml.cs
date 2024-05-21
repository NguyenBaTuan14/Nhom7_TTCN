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
    /// Interaction logic for TraLoiPhanAnh_admin.xaml
    /// </summary>
    public partial class TraLoiPhanAnh_admin : Window
    {
        public TraLoiPhanAnh_admin()
        {
            InitializeComponent();
            this.Left = 200;
            this.Top = 100;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PhanAnh phanAnh = new PhanAnh();
            phanAnh.Show();
            Close();
        }
    }
}
