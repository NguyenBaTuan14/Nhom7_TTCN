using System;
using System.Collections.Generic;

namespace TTCN_Nhom7.MoHinhDuLieu;

public partial class ThongBao
{
    public string MaThongBao { get; set; } = null!;

    public string? NoiDungChiTiet { get; set; }

    public DateTime? NgayThongBao { get; set; }

    public string? TieuDeThongBao { get; set; }

    public virtual ICollection<TaiKhoan> MaTaiKhoans { get; set; } = new List<TaiKhoan>();
}
