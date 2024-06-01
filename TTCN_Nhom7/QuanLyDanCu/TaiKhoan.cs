using System;
using System.Collections.Generic;

namespace TTCN_Nhom7.QuanLyDanCu;

public partial class TaiKhoan
{
    public string MaTaiKhoan { get; set; } = null!;

    public string? Ho { get; set; }

    public string? Ten { get; set; }

    public string? SoDienThoai { get; set; }

    public string? Email { get; set; }

    public byte[]? AnhChanDung { get; set; }

    public string? MatKhau { get; set; }

    public string? Role { get; set; }

    public virtual ICollection<ChuHo> ChuHos { get; set; } = new List<ChuHo>();

    public virtual ICollection<PhanAnh> PhanAnhs { get; set; } = new List<PhanAnh>();

    public virtual ICollection<ThongBao> MaThongBaos { get; set; } = new List<ThongBao>();
}
