using System;
using System.Collections.Generic;

namespace TTCN_Nhom7.MoHinhDuLieu;

public partial class PhanAnh
{
    public string MaPhanAnh { get; set; } = null!;

    public string? NoiDungPhanAnh { get; set; }

    public string? NoiDungPhanHoi { get; set; }

    public string MaTaiKhoan { get; set; } = null!;

    public virtual TaiKhoan MaTaiKhoanNavigation { get; set; } = null!;
}
