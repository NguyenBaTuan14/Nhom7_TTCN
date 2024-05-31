using System;
using System.Collections.Generic;

namespace TTCN_Nhom7.QuanLyDanCu;

public partial class NhanKhau
{
    public string MaNhanKhau { get; set; } = null!;

    public string? HoTen { get; set; }

    public string? QuanHeVoiChuHo { get; set; }

    public string? SoCmndCccd { get; set; }

    public bool? GioiTinh { get; set; }

    public DateTime? NgaySinh { get; set; }

    public string? TrinhDoHocVan { get; set; }

    public string? NgheNghiep { get; set; }

    public string? DiaChiThuongChu { get; set; }

    public string? TinhTrangHonNhan { get; set; }

    public string? DanToc { get; set; }

    public string? TonGiao { get; set; }

    public string MaHoKhau { get; set; } = null!;

    public virtual HoKhau MaHoKhauNavigation { get; set; } = null!;
}
