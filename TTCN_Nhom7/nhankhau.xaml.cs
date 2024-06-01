using Microsoft.IdentityModel.Tokens;
using Microsoft.SqlServer.Server;
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
using System.Xml.Linq;
using TTCN_Nhom7.DuLieuDanCu;

namespace TTCN_Nhom7
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        QldanCuNguyenXa1Context db = new QldanCuNguyenXa1Context();
        private object selectedRow;
        string hoten, mahk, mank, socccd, gt, diachi, quanhe, tongiao, dantoc, ngaysinh, nghe = "";
        public Window2()
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
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HienThiDuLieu();
        }
        private void HienThiDuLieu()
        {
            try
            {
                var query = from nk in db.NhanKhaus 
                        orderby nk.MaNhanKhau ascending
                        select new
                        {
                            nk.MaNhanKhau,
                            nk.HoTen,
                            nk.QuanHeVoiChuHo,
                            nk.MaHoKhau,
                            nk.SoCmndCccd,
                            GioiTinh = (bool)nk.GioiTinh ? "Nữ" : "Nam",
                            nk.NgaySinh,
                            nk.DiaChiThuongChu,
                        };
            dtgdanhsach.ItemsSource = query.ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối với cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
        private void btntim_onclick(object sender, RoutedEventArgs e)
        {
            var query = from nk in db.NhanKhaus
                        orderby nk.MaNhanKhau ascending
                        select new
                        {
                            nk.MaNhanKhau,
                            nk.HoTen,
                            nk.QuanHeVoiChuHo,
                            nk.MaHoKhau,
                            nk.SoCmndCccd,
                            GioiTinh = (bool)nk.GioiTinh ? "Nữ" : "Nam",
                            nk.NgaySinh,
                            nk.DiaChiThuongChu,
                        };
            var query1 = from nk in query
                         orderby nk.MaNhanKhau ascending
                         where nk.HoTen == txttim.Text || nk.DiaChiThuongChu == txttim.Text ||
                                nk.MaNhanKhau == txttim.Text || nk.MaHoKhau == txttim.Text 
                         select nk;
            if (query1.IsNullOrEmpty())
            {
                MessageBoxResult result = MessageBox.Show("Không có mã nhân khẩu này", "THÔNG BÁO",
                                            MessageBoxButton.OKCancel, MessageBoxImage.Error);

            }else 
                dtgdanhsach.ItemsSource = query1.ToList();
        }
        private void dtgdanhsach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedRow = dtgdanhsach.SelectedItem;

            if (selectedRow != null)
            {
                Type t = selectedRow.GetType();
                PropertyInfo[] a = t.GetProperties();
                txttim.Text = a[0].GetValue(selectedRow).ToString();
               // mank = txttim.Text;
                hoten = a[1].GetValue(selectedRow).ToString();
                quanhe = a[2].GetValue(selectedRow).ToString();
                mahk = a[3].GetValue(selectedRow).ToString();
                socccd = a[4].GetValue(selectedRow).ToString();
                gt = a[5].GetValue(selectedRow).ToString();
                ngaysinh = a[6].GetValue(selectedRow).ToString();
                diachi = a[7].GetValue(selectedRow).ToString(); 
            }
        }
        private void btnxoa_onclick(object sender, RoutedEventArgs e)
        {
            var query = from nk in db.NhanKhaus
                        where nk.MaNhanKhau == txttim.Text
                        select nk;

            MessageBoxResult result = MessageBox.Show("Có xác nhận xóa không", "XÁC NHẬN XÓA",
                                            MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                if (query.Count() > 0)
                {
                    NhanKhau nkxoa = query.SingleOrDefault();
                    db.NhanKhaus.Remove(nkxoa);
                    db.SaveChanges();
                    HienThiDuLieu();
                }
            }
            else
            {
                HienThiDuLieu();
                txttim.Text = "";
                txttim.Focus();
            }
        }
        public void btnthem_onclick(object sender, RoutedEventArgs e)
        {
            them tnk = new them();
            tnk.Show();
            Close();
        }
        private void btnsua_onclick(object sender, RoutedEventArgs e)
        {
            var findma = from nk in db.NhanKhaus
                         where nk.SoCmndCccd == socccd
                         select nk.MaNhanKhau;
            mank = findma.First();

            var findtongiao = from nk in db.NhanKhaus
                              where nk.SoCmndCccd == socccd
                              select nk.TonGiao;
            tongiao = findtongiao.First();

            var finddantoc = from nk in db.NhanKhaus
                             where nk.SoCmndCccd == socccd
                             select nk.DanToc;
            dantoc = finddantoc.First();

            var findnghe = from nk in db.NhanKhaus
                           where nk.SoCmndCccd == socccd
                           select nk.NgheNghiep;
            nghe = findnghe.First();
            if (!string.IsNullOrEmpty(mank))
            {
                suanhankhau tnk = new suanhankhau(hoten, mahk, mank, socccd, gt, diachi, quanhe, tongiao, dantoc, ngaysinh, nghe);

                tnk.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân khẩu để sửa.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }
    }
}
