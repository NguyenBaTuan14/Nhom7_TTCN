using System;
using System.Collections.Generic;

namespace TTCN_Nhom7.DuLieuQuanLyDanCu;

public partial class ChuHo
{
    public string MaChuHo { get; set; } = null!;

    public string? HoTen { get; set; }

    public DateTime? NgaySinh { get; set; }

    public bool? GioiTinh { get; set; }

    public string? QueQuan { get; set; }

    public string? DanToc { get; set; }

    public string? TonGiao { get; set; }

    public string? SoCmndCccd { get; set; }

    public string? NgheNghiep { get; set; }

    public string? NoiLamViec { get; set; }

    public DateTime? NgayChuyenDen { get; set; }

    public string? DiaChiThuongChu { get; set; }

    public string? TinhTrangHonNhan { get; set; }

    public string MaHoKhau { get; set; } = null!;

    public string? MaTaiKhoan { get; set; }

    public virtual HoKhau MaHoKhauNavigation { get; set; } = null!;

    public virtual TaiKhoan? MaTaiKhoanNavigation { get; set; }
}
