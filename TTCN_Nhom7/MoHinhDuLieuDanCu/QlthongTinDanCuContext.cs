using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TTCN_Nhom7.MoHinhDuLieuDanCu;

public partial class QlthongTinDanCuContext : DbContext
{
    public QlthongTinDanCuContext()
    {
    }

    public QlthongTinDanCuContext(DbContextOptions<QlthongTinDanCuContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChuHo> ChuHos { get; set; }

    public virtual DbSet<DiaChi> DiaChis { get; set; }

    public virtual DbSet<HoKhau> HoKhaus { get; set; }

    public virtual DbSet<HoiDap> HoiDaps { get; set; }

    public virtual DbSet<NhanKhau> NhanKhaus { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    public virtual DbSet<ThongBaoXaGui> ThongBaoXaGuis { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-HDT67J9;Initial Catalog=QLThongTinDanCu;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChuHo>(entity =>
        {
            entity.HasKey(e => e.MaChuHo).HasName("PK__ChuHo__358562824BF360C9");

            entity.ToTable("ChuHo");

            entity.Property(e => e.MaChuHo).HasMaxLength(50);
            entity.Property(e => e.DanToc).HasMaxLength(50);
            entity.Property(e => e.NgayChuyenDen).HasColumnType("date");
            entity.Property(e => e.NgaySinh).HasColumnType("date");
            entity.Property(e => e.NgheNghiep).HasMaxLength(50);
            entity.Property(e => e.NoiLamViec).HasMaxLength(50);
            entity.Property(e => e.NoiThuongChu).HasMaxLength(50);
            entity.Property(e => e.QueQuan).HasMaxLength(50);
            entity.Property(e => e.SoCmndCccd)
                .HasMaxLength(50)
                .HasColumnName("SoCMND_CCCD");
            entity.Property(e => e.TenChuHo).HasMaxLength(50);
            entity.Property(e => e.TinhTrangHonNhan).HasMaxLength(50);
            entity.Property(e => e.TonGiao).HasMaxLength(50);
        });

        modelBuilder.Entity<DiaChi>(entity =>
        {
            entity.HasKey(e => e.MaVung).HasName("PK__DiaChi__BF118FFBD03A7DE8");

            entity.ToTable("DiaChi");

            entity.Property(e => e.MaVung).HasMaxLength(50);
            entity.Property(e => e.SoNha).HasMaxLength(10);
            entity.Property(e => e.TenPhuongXa)
                .HasMaxLength(50)
                .HasColumnName("TenPhuong_Xa");
            entity.Property(e => e.TenQuanHuyen)
                .HasMaxLength(50)
                .HasColumnName("TenQuan_Huyen");
            entity.Property(e => e.TenThonXom)
                .HasMaxLength(50)
                .HasColumnName("TenThon_Xom");
            entity.Property(e => e.TenTinhThanhPho)
                .HasMaxLength(50)
                .HasColumnName("TenTinh_ThanhPho");
        });

        modelBuilder.Entity<HoKhau>(entity =>
        {
            entity.HasKey(e => e.MaHoKhau).HasName("PK__HoKhau__C8B08692BD222ECA");

            entity.ToTable("HoKhau");

            entity.Property(e => e.MaHoKhau).HasMaxLength(50);
            entity.Property(e => e.MaChuHo).HasMaxLength(50);
            entity.Property(e => e.MaTaiKhoan).HasMaxLength(50);
            entity.Property(e => e.MaVung).HasMaxLength(50);
            entity.Property(e => e.NgayChuyenDi).HasColumnType("date");
            entity.Property(e => e.NgayDangKy).HasColumnType("date");
        });

        modelBuilder.Entity<HoiDap>(entity =>
        {
            entity.HasKey(e => e.MaCauHoi).HasName("PK__HoiDap__1937D77B48EC88E8");

            entity.ToTable("HoiDap");

            entity.Property(e => e.MaCauHoi).HasMaxLength(50);
            entity.Property(e => e.MaTaiKhoan).HasMaxLength(50);
            entity.Property(e => e.NoiDungCauHoi).HasColumnType("text");
            entity.Property(e => e.NoiDungCauTraLoi).HasColumnType("text");
        });

        modelBuilder.Entity<NhanKhau>(entity =>
        {
            entity.HasKey(e => e.MaNhanKhau).HasName("PK__NhanKhau__7EE100871DC3D559");

            entity.ToTable("NhanKhau");

            entity.Property(e => e.MaNhanKhau).HasMaxLength(50);
            entity.Property(e => e.DanToc).HasMaxLength(50);
            entity.Property(e => e.DiaChiThuongChu).HasMaxLength(100);
            entity.Property(e => e.HoTen).HasMaxLength(50);
            entity.Property(e => e.MaHoKhau).HasMaxLength(50);
            entity.Property(e => e.NgaySinh).HasColumnType("date");
            entity.Property(e => e.NgheNghiep).HasMaxLength(50);
            entity.Property(e => e.QuanHeVoiChuHo).HasMaxLength(60);
            entity.Property(e => e.SoCmndCccd)
                .HasMaxLength(50)
                .HasColumnName("SoCMND_CCCD");
            entity.Property(e => e.TinhTrangHonNhan).HasMaxLength(50);
            entity.Property(e => e.TonGiao).HasMaxLength(50);
            entity.Property(e => e.TrinhDoHocVan).HasMaxLength(50);
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.MaTaiKhoan).HasName("PK__TaiKhoan__AD7C6529F9593020");

            entity.ToTable("TaiKhoan");

            entity.Property(e => e.MaTaiKhoan).HasMaxLength(50);
            entity.Property(e => e.AnhChanDung).HasColumnType("image");
            entity.Property(e => e.Email).HasMaxLength(225);
            entity.Property(e => e.Ho).HasMaxLength(35);
            entity.Property(e => e.MatKhau).HasMaxLength(50);
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.SoDienThoai).HasMaxLength(10);
            entity.Property(e => e.Ten).HasMaxLength(15);
        });

        modelBuilder.Entity<ThongBaoXaGui>(entity =>
        {
            entity.HasKey(e => e.MaThongBao).HasName("PK__ThongBao__04DEB54E340A85F1");

            entity.ToTable("ThongBaoXaGui");

            entity.Property(e => e.MaThongBao).HasMaxLength(50);
            entity.Property(e => e.MaTaiKhoan).HasMaxLength(50);
            entity.Property(e => e.NgayThongBao).HasColumnType("date");
            entity.Property(e => e.NoiDungThongBao).HasColumnType("text");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
