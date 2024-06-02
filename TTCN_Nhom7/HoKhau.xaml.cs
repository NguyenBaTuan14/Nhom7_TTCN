using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using Microsoft.IdentityModel.Tokens;
using TTCN_Nhom7.Models;

namespace TTCN_Nhom7
{
    /// <summary>
    /// Interaction logic for HoKhau.xaml
    /// </summary>
    public partial class HoKhau_admin : Window
    {
        QldanCuNguyenXaContext db= new QldanCuNguyenXaContext();
        private object selectedRow;
        string mahk, tench, tongtv, diachi,mach,ngaydk, cccd, dctc = "";
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HienThiDuLieu();
        }
        public HoKhau_admin()
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

        private void btnxoa_Click(object sender, RoutedEventArgs e)
        {
            var query = from hk in db.HoKhaus
                        where hk.MaHoKhau == txttim.Text
                        select hk;

            MessageBoxResult result = MessageBox.Show("Có xác nhận xóa không?", "Xác nhận", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                var hoKhauToRemove = query.SingleOrDefault();
                if (hoKhauToRemove != null)
                {
                   
                    var relatedChuHoRecords = db.ChuHos.Where(ch => ch.MaHoKhau == hoKhauToRemove.MaHoKhau);
                    db.ChuHos.RemoveRange(relatedChuHoRecords);

                   
                    db.HoKhaus.Remove(hoKhauToRemove);
                    db.SaveChanges();

                    MessageBox.Show("Xóa thành công!");
                    txttim.Text = string.Empty;
                    txttim.Focus();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy hộ khẩu để xóa.", "Thông báo", MessageBoxButton.OK);
                    HienThiDuLieu();
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var searchText = txttim.Text.ToLower();

            var query = from hk in db.HoKhaus
                        join ch in db.ChuHos on hk.MaHoKhau equals ch.MaHoKhau
                        orderby hk.MaHoKhau ascending
                        select new
                        {
                            Mahokhau = hk.MaHoKhau,
                            HoTenChuHo = ch.HoTen,
                            DiaChi = ch.DiaChiThuongChu,
                            tongTV = hk.NhanKhaus.Count() + 1
                        };

            var query1 = from hk in query
                         orderby hk.Mahokhau ascending
                         where hk.HoTenChuHo == txttim.Text || hk.DiaChi == txttim.Text ||
                               hk.Mahokhau == txttim.Text
                         select hk;

            if (query1.Any())
            {
                MessageBoxResult result = MessageBox.Show("Có thông tin cần tìm", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                dtgdanhsach1.ItemsSource = query1.ToList();
            }
            else
            {
                MessageBox.Show("Không có thông tin cần tìm", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }


        }

        private void btnthem_onclick(object sender, RoutedEventArgs e)
        {
            ThemHoKhau them = new ThemHoKhau();
            them.Show();
            Close();
        }

        private void btnsua_onclick(object sender, RoutedEventArgs e)
        {
            string mahk = txttim.Text;
            var findNhanKhau = db.HoKhaus.FirstOrDefault(hk => hk.MaHoKhau == mahk);

            if (findNhanKhau != null)
            {
                mahk = findNhanKhau.MaHoKhau;
                DateTime ngaydk = (DateTime)findNhanKhau.NgayDangKy;
            }
            var findChuHo = db.ChuHos.FirstOrDefault(ch => ch.MaHoKhau == mahk);
            if (findChuHo != null)
            {
                string tench = findChuHo.HoTen;
                string cccd = findChuHo.SoCmndCccd;
                string mach = findChuHo.MaChuHo;
                string dctc = findChuHo.DiaChiThuongChu;

            }

           
                if (!string.IsNullOrEmpty(mahk))
            {
                SuaHoKhau thk = new SuaHoKhau(mahk, mach, tench, cccd, ngaydk,dctc);

                thk.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân khẩu để sửa.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            Close();
        }
        private void HienThiDuLieu()
        {
            try
            {
                var query = from hk in db.HoKhaus
                            join ch in db.ChuHos on hk.MaHoKhau equals ch.MaHoKhau
                            orderby hk.MaHoKhau ascending
                            select new
                            {
                                Mahokhau = hk.MaHoKhau,
                                HoTenChuHo = ch.HoTen,
                                DiaChi = ch.DiaChiThuongChu,
                                tongTV = hk.NhanKhaus.Count() + 1
                            };
                dtgdanhsach1.ItemsSource = query.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối với cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void dtgdanhsach1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedRow = dtgdanhsach1.SelectedItem;

            if (selectedRow != null)
            {
                Type t = selectedRow.GetType();
                PropertyInfo[] a = t.GetProperties();
                txttim.Text = a[0].GetValue(selectedRow).ToString();
                mahk = a[1].GetValue(selectedRow).ToString();
                tench = a[2].GetValue(selectedRow).ToString();
                tongtv = a[3].GetValue(selectedRow).ToString();
                diachi = a[4].GetValue(selectedRow).ToString();
            }
        }
    }
}
