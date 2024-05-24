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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            this.Left = 200;
            this.Top = 100;
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void Nhan_Khau(object sender, RoutedEventArgs e)
        {
            Window2 wd = new Window2();
            wd.Show();
            Close();
        }

        private void Ho_Khau(object sender, RoutedEventArgs e)
        {
            HoKhau hk = new HoKhau();
            hk.Show();
            Close();
        }

        private void Thong_Ke(object sender, RoutedEventArgs e)
        {
            ThongKe tk = new ThongKe();
            tk.Show();
            Close();
        }

        private void Phan_Anh(object sender, RoutedEventArgs e)
        {
            PhanAnh pa = new PhanAnh();
            pa.Show();
            Close();
        }

        private void QLTK(object sender, RoutedEventArgs e)
        {
            QuanLyTaiKhoan_admin QLTK = new QuanLyTaiKhoan_admin();
            QLTK.Show();
            Close();
        }
    }
}
