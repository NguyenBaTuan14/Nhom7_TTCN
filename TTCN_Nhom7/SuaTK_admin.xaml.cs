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
    /// Interaction logic for SuaTK_admin.xaml
    /// </summary>
    public partial class SuaTK_admin : Window
    {
        public SuaTK_admin()
        {
            InitializeComponent();
            this.Left = 200;
            this.Top = 100;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.Show();
            Close();
        }
    }
}
