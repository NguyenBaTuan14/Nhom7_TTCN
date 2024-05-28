using System;
using System.Collections.Generic;

namespace TTCN_Nhom7.DuLieuQuanLyDanCu;

public partial class HoKhau
{
    public string MaHoKhau { get; set; } = null!;

    public DateTime? NgayDangKy { get; set; }

    public DateTime? NgayChuyenDi { get; set; }

    public virtual ICollection<ChuHo> ChuHos { get; set; } = new List<ChuHo>();

    public virtual ICollection<NhanKhau> NhanKhaus { get; set; } = new List<NhanKhau>();
}
