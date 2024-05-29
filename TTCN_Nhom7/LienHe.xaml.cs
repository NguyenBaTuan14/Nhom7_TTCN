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
    public class lien_he
    {
        public string CoQuan { get; set; }
        public string NguoiPhuTrach { get; set; }
        public string GioiTinh { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
    }
    public partial class LienHe : Window
    {
        String taiKhoan;
        public LienHe(string taiKhoan)
        {
            InitializeComponent();
            this.Left = 200;
            this.Top = 100;
            List<lien_he> list = new List<lien_he>() {
                new lien_he { CoQuan = "Công an", NguoiPhuTrach = "Nguyễn Duy Tân", GioiTinh = "Nam", SDT = "0123456789", Email = "Toy@gmail.com" },
                new lien_he { CoQuan = "Địa chính", NguoiPhuTrach = "Nguyễn Bá Tuấn", GioiTinh = "Nam", SDT = "0987654321", Email = "Tuan@gmail.com.com" },
                new lien_he { CoQuan = "Văn phòng kế toán", NguoiPhuTrach = "Nguyễn Thị Hải Phương", GioiTinh = "Nữ", SDT = "0186736725", Email = "Lonheo@gmail.com" },
                new lien_he { CoQuan = "Tư pháp", NguoiPhuTrach = "Nguyễn Xuân Đức", GioiTinh = "Nam", SDT = "0987648657", Email = "Duck@gmail.com.com" },
                new lien_he { CoQuan = "Văn hóa-xã hội", NguoiPhuTrach = "Đàm Thị Thủy", GioiTinh = "Nữ", SDT = "09883675676", Email = "Thuy@gmail.com.com" }

            };
            list_lh.ItemsSource = list;
            this.taiKhoan = taiKhoan;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TrangChu_user tc = new TrangChu_user(taiKhoan);
            tc.Show();
            Close();
        }
    }
}
