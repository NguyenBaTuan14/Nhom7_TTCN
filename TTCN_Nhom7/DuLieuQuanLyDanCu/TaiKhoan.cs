﻿using System;
using System.Collections.Generic;

namespace TTCN_Nhom7.DuLieuQuanLyDanCu;

public partial class TaiKhoan
{
    public string MaTaiKhoan { get; set; } = null!;

    public string? Ho { get; set; }

    public string? Ten { get; set; }

    public string? SoDienThoai { get; set; }

    public string? Email { get; set; }

    public byte[]? AnhChanDung { get; set; }

    public string? MatKhau { get; set; }
}
