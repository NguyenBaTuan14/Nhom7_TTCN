﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TTCN_Nhom7.QuanLyDanCu;

public partial class QldanCuNguyenXaContext : DbContext
{
    public QldanCuNguyenXaContext()
    {
    }

    public QldanCuNguyenXaContext(DbContextOptions<QldanCuNguyenXaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChuHo> ChuHos { get; set; }

    public virtual DbSet<DiaChi> DiaChis { get; set; }

    public virtual DbSet<HoKhau> HoKhaus { get; set; }

    public virtual DbSet<NhanKhau> NhanKhaus { get; set; }

    public virtual DbSet<PhanAnh> PhanAnhs { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    public virtual DbSet<ThongBao> ThongBaos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-F758C5U;Initial Catalog=QLDanCuNguyenXa;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChuHo>(entity =>
        {
            entity.HasKey(e => e.MaChuHo).HasName("PK__ChuHo__35856282484FCC48");

            entity.ToTable("ChuHo");

            entity.Property(e => e.MaChuHo).HasMaxLength(50);
            entity.Property(e => e.DanToc).HasMaxLength(50);
            entity.Property(e => e.DiaChiThuongChu).HasMaxLength(225);
            entity.Property(e => e.HoTen).HasMaxLength(50);
            entity.Property(e => e.MaHoKhau).HasMaxLength(50);
            entity.Property(e => e.MaTaiKhoan).HasMaxLength(50);
            entity.Property(e => e.NgayChuyenDen).HasColumnType("datetime");
            entity.Property(e => e.NgaySinh).HasColumnType("datetime");
            entity.Property(e => e.NgheNghiep).HasMaxLength(50);
            entity.Property(e => e.NoiLamViec).HasMaxLength(100);
            entity.Property(e => e.QueQuan).HasMaxLength(100);
            entity.Property(e => e.SoCmndCccd)
                .HasMaxLength(20)
                .HasColumnName("SoCMND_CCCD");
            entity.Property(e => e.TinhTrangHonNhan).HasMaxLength(50);
            entity.Property(e => e.TonGiao).HasMaxLength(50);

            entity.HasOne(d => d.MaHoKhauNavigation).WithMany(p => p.ChuHos)
                .HasForeignKey(d => d.MaHoKhau)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChuHo__MaHoKhau__3E52440B");

            entity.HasOne(d => d.MaTaiKhoanNavigation).WithMany(p => p.ChuHos)
                .HasForeignKey(d => d.MaTaiKhoan)
                .HasConstraintName("FK__ChuHo__MaTaiKhoa__3F466844");
        });

        modelBuilder.Entity<DiaChi>(entity =>
        {
            entity.HasKey(e => e.MaVung).HasName("PK__DiaChi__BF118FFBAE661DF8");

            entity.ToTable("DiaChi");

            entity.HasIndex(e => e.MaHoKhau, "UQ__DiaChi__C8B08693ABDB4BF2").IsUnique();

            entity.Property(e => e.MaVung).HasMaxLength(50);
            entity.Property(e => e.MaHoKhau).HasMaxLength(50);
            entity.Property(e => e.PhuongXa)
                .HasMaxLength(50)
                .HasColumnName("Phuong_Xa");
            entity.Property(e => e.QuanHuyen)
                .HasMaxLength(50)
                .HasColumnName("Quan_Huyen");
            entity.Property(e => e.SoNha).HasMaxLength(10);
            entity.Property(e => e.ThonXomDuong)
                .HasMaxLength(50)
                .HasColumnName("Thon_Xom_Duong");
            entity.Property(e => e.TinhThanhPho)
                .HasMaxLength(50)
                .HasColumnName("Tinh_ThanhPho");
        });

        modelBuilder.Entity<HoKhau>(entity =>
        {
            entity.HasKey(e => e.MaHoKhau).HasName("PK__HoKhau__C8B0869207190354");

            entity.ToTable("HoKhau");

            entity.Property(e => e.MaHoKhau).HasMaxLength(50);
            entity.Property(e => e.NgayChuyenDi).HasColumnType("datetime");
            entity.Property(e => e.NgayDangKy).HasColumnType("datetime");
        });

        modelBuilder.Entity<NhanKhau>(entity =>
        {
            entity.HasKey(e => e.MaNhanKhau).HasName("PK__NhanKhau__7EE1008710D37850");

            entity.ToTable("NhanKhau");

            entity.Property(e => e.MaNhanKhau).HasMaxLength(50);
            entity.Property(e => e.DanToc).HasMaxLength(50);
            entity.Property(e => e.DiaChiThuongChu).HasMaxLength(100);
            entity.Property(e => e.HoTen).HasMaxLength(50);
            entity.Property(e => e.MaHoKhau).HasMaxLength(50);
            entity.Property(e => e.NgaySinh).HasColumnType("datetime");
            entity.Property(e => e.NgheNghiep).HasMaxLength(50);
            entity.Property(e => e.QuanHeVoiChuHo).HasMaxLength(50);
            entity.Property(e => e.SoCmndCccd)
                .HasMaxLength(20)
                .HasColumnName("SoCMND_CCCD");
            entity.Property(e => e.TinhTrangHonNhan).HasMaxLength(50);
            entity.Property(e => e.TonGiao).HasMaxLength(50);
            entity.Property(e => e.TrinhDoHocVan).HasMaxLength(50);

            entity.HasOne(d => d.MaHoKhauNavigation).WithMany(p => p.NhanKhaus)
                .HasForeignKey(d => d.MaHoKhau)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NhanKhau__MaHoKh__4F7CD00D");
        });

        modelBuilder.Entity<PhanAnh>(entity =>
        {
            entity.HasKey(e => e.MaPhanAnh).HasName("PK__PhanAnh__0701D06FF2D03A0F");

            entity.ToTable("PhanAnh");

            entity.Property(e => e.MaPhanAnh).HasMaxLength(50);
            entity.Property(e => e.MaTaiKhoan).HasMaxLength(50);
            entity.Property(e => e.NoiDungPhanAnh).HasColumnType("text");
            entity.Property(e => e.NoiDungPhanHoi).HasColumnType("text");

            entity.HasOne(d => d.MaTaiKhoanNavigation).WithMany(p => p.PhanAnhs)
                .HasForeignKey(d => d.MaTaiKhoan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PhanAnh__MaTaiKh__4BAC3F29");
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.MaTaiKhoan).HasName("PK__TaiKhoan__AD7C6529C46A42E9");

            entity.ToTable("TaiKhoan");

            entity.Property(e => e.MaTaiKhoan).HasMaxLength(50);
            entity.Property(e => e.AnhChanDung).HasColumnType("image");
            entity.Property(e => e.Email).HasMaxLength(225);
            entity.Property(e => e.Ho).HasMaxLength(50);
            entity.Property(e => e.MatKhau).HasMaxLength(50);
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.SoDienThoai).HasMaxLength(10);
            entity.Property(e => e.Ten).HasMaxLength(50);
        });

        modelBuilder.Entity<ThongBao>(entity =>
        {
            entity.HasKey(e => e.MaThongBao).HasName("PK__ThongBao__04DEB54EDAF119A9");

            entity.ToTable("ThongBao");

            entity.Property(e => e.MaThongBao).HasMaxLength(50);
            entity.Property(e => e.NgayThongBao).HasColumnType("datetime");
            entity.Property(e => e.NoiDungChiTiet).HasColumnType("text");
            entity.Property(e => e.TieuDeThongBao).HasColumnType("text");

            entity.HasMany(d => d.MaTaiKhoans).WithMany(p => p.MaThongBaos)
                .UsingEntity<Dictionary<string, object>>(
                    "ThongBaoTaiKhoan",
                    r => r.HasOne<TaiKhoan>().WithMany()
                        .HasForeignKey("MaTaiKhoan")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ThongBao___MaTai__48CFD27E"),
                    l => l.HasOne<ThongBao>().WithMany()
                        .HasForeignKey("MaThongBao")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ThongBao___MaTho__47DBAE45"),
                    j =>
                    {
                        j.HasKey("MaThongBao", "MaTaiKhoan").HasName("PK__ThongBao__8E09731C95ED9927");
                        j.ToTable("ThongBao_TaiKhoan");
                        j.IndexerProperty<string>("MaThongBao").HasMaxLength(50);
                        j.IndexerProperty<string>("MaTaiKhoan").HasMaxLength(50);
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}