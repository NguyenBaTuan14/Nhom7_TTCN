using System;
using System.Collections.Generic;

namespace TTCN_Nhom7.MoHinhQuanLyDanCu;

public partial class ChuHo
{
    public string MaChuHo { get; set; } = null!;

    public string? TenChuHo { get; set; }

    public DateTime? NgaySinh { get; set; }

    public bool? GioiTinh { get; set; }

    public string? QueQuan { get; set; }

    public string? DanToc { get; set; }

    public string? TonGiao { get; set; }

    public string? SoCmndCccd { get; set; }

    public string? NgheNghiep { get; set; }

    public string? NoiLamViec { get; set; }

    public DateTime? NgayChuyenDen { get; set; }

    public string? NoiThuongChu { get; set; }

    public string? TinhTrangHonNhan { get; set; }
}
