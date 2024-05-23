using System;
using System.Collections.Generic;

namespace TTCN_Nhom7.QuanLyDanCu;

public partial class HoKhau
{
    public string MaHoKhau { get; set; } = null!;

    public DateTime? NgayDangKy { get; set; }

    public DateTime? NgayChuyenDi { get; set; }

    public string MaTaiKhoan { get; set; } = null!;

    public string MaChuHo { get; set; } = null!;

    public string MaVung { get; set; } = null!;
}
