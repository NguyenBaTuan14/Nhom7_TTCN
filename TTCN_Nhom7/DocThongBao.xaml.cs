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

using TTCN_Nhom7.Models;


namespace TTCN_Nhom7
{
    /// <summary>
    /// Interaction logic for DocThongBao.xaml
    /// </summary>
    public partial class DocThongBao : Window
    {
        String taiKhoan;
        QldanCuNguyenXaContext db = new QldanCuNguyenXaContext();
        String tieuDeTB;
        public DocThongBao(string taiKhoan, string tieuDeTB)
        {
            InitializeComponent();
            this.Left = 200;
            this.Top = 100;
            this.taiKhoan = taiKhoan;
            this.tieuDeTB = tieuDeTB;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadData();
        }
        private void loadData()
        {
            // Lấy dữ liệu từ cơ sở dữ liệu mà không sử dụng điều kiện cho các trường text
            var query = from tk in db.TaiKhoans
                        from tb in tk.MaThongBaos
                        where tk.Email == taiKhoan || tk.SoDienThoai == taiKhoan
                        select new
                        {
                            tb.NoiDungChiTiet,
                            tb.TieuDeThongBao
                        };

            // Tải dữ liệu vào bộ nhớ và thực hiện so sánh trong mã C#
            var result = query.ToList();

            // Lọc dữ liệu dựa trên tiêu đề thông báo trong mã C#
            var filteredResult = result.Where(r => r.TieuDeThongBao == tieuDeTB).ToList();

            // Chuyển đổi kết quả thành chuỗi và hiển thị trong TextBox
            if (filteredResult.Any())
            {
                NDThongbao.Text = filteredResult.First().NoiDungChiTiet;
            }
            else
            {
                NDThongbao.Text = "Không tìm thấy thông báo với tiêu đề này.";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Logic to go back to the previous window
            TrangChu_user nw = new TrangChu_user(taiKhoan);
            nw.Show();
            this.Close();
        }
    }
}
