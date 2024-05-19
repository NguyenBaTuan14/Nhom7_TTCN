using Microsoft.IdentityModel.Tokens;
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
using TTCN_Nhom7.MoHinhQuanLyDanCu;
using static System.Net.Mime.MediaTypeNames;

namespace TTCN_Nhom7
{
    /// <summary>
    /// Interaction logic for them.xaml
    /// </summary>
    public partial class them : Window
    {
        QlthongTinDanCuContext db = new QlthongTinDanCuContext();
        public them()
        {
            InitializeComponent();
        }
        private void Quay_Ve(object sender, RoutedEventArgs e)
        {
            Window2 wd = new Window2();
            wd.Show();
            Close();
        }
        private void btnthem_onclick(object sender, RoutedEventArgs e)
        {
            if (check())
            {
                NhanKhau nkmoi = new NhanKhau();
                nkmoi.HoTen = txthoten.Text;
                nkmoi.SoCmndCccd = txtcccd.Text;

                nkmoi.MaHoKhau = txtmahk.Text;

                var query_count = from nk in db.NhanKhaus
                                  select nk;
                int count = query_count.Count();
                string nextIndex = (count + 1).ToString().PadLeft(2, '0');
                nkmoi.MaNhanKhau = "NK0" + nextIndex;

                if (radnam.IsChecked == true)
                {
                    nkmoi.GioiTinh = false;
                }
                else if (radnu.IsChecked == true)
                {
                    nkmoi.GioiTinh = true;
                }
                nkmoi.DiaChiThuongChu = txtdiachi.Text;
                nkmoi.QuanHeVoiChuHo = txtquanhe.Text;
                nkmoi.TonGiao = txttongiao.Text;
                nkmoi.DanToc = txtdantoc.Text;
                nkmoi.NgaySinh = dtpngaysinh.SelectedDate;
                nkmoi.NgheNghiep = txtnghe.Text;
                db.NhanKhaus.Add(nkmoi);
                db.SaveChanges();

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
                Window2 wd = new Window2();
                wd.dtgdanhsach.ItemsSource = query.ToList();
                wd.Show();
                Close();
            }
        }

        private bool check()
        {
            if(txthoten.Text.IsNullOrEmpty() || txtcccd.Text.IsNullOrEmpty() || txtdiachi.Text.IsNullOrEmpty()
               || (radnam.IsChecked == false && radnu.IsChecked == false) || txtdiachi.Text.IsNullOrEmpty() 
               || txtquanhe.Text.IsNullOrEmpty() || txttongiao.Text.IsNullOrEmpty() || txtdantoc.Text.IsNullOrEmpty()
               || dtpngaysinh.Text.IsNullOrEmpty() || txtnghe.Text.IsNullOrEmpty())
            {
                MessageBoxResult result = MessageBox.Show("Yêu cầu nhập đầy đủ thông tin", "THÔNG BÁO",
                                            MessageBoxButton.OKCancel, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}
