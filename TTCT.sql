/*
Created		4/27/2024
Modified		5/12/2024
Project		
Model		
Company		
Author		
Version		
Database		MS SQL 7 
*/
use master
go
Create database QLDanCu
go
use QLDanCu
go
Drop table [ThongBaoXaGui] 
go
Drop table [HoiDap] 
go
Drop table [DiaChi] 
go
Drop table [ChuHo] 
go
Drop table [HoKhau] 
go
Drop table [NhanKhau] 
go
Drop table [TaiKhoan] 
go


Create table [TaiKhoan] (
	[MaTaiKhoan] nvarChar(50) NOT NULL,
	[Ho] nvarChar(10) NULL,
	[Ten] nvarChar(20) NULL,
	[SoDienThoai] nvarChar(225) NULL,
	[Email] nvarChar(225) NULL,
	[AnhChanDung] nvarChar(10) NULL,
	[MatKhau] nvarChar(50) NULL,
Primary Key  ([MaTaiKhoan])
) 
go

Create table [NhanKhau] (
	[MaNhanKhau] nvarChar(50) NOT NULL,
	[HoTen] nvarChar(50) NULL,
	[QuanHeVoiChuHo] nvarChar(60) NULL,
	[SoCMND_CCCD] nvarChar(50) NULL,
	[GioiTinh] bit NULL,
	[NgaySinh] date NULL,
	[TrinhDoHocVan] nvarChar(50) NULL,
	[NgheNghiep] nvarChar(50) NULL,
	[TonGiao] nvarChar(50) NULL,
	[DiaChiThuongChu] nvarChar(100) NULL,
	[TinhTrangHonNhan] nvarChar(50) NULL,
	[DanToc] nvarChar(50) NULL,
	
	[MaHoKhau] nvarChar(50) NOT NULL,
Primary Key  ([MaNhanKhau])
) 
go

Create table [HoKhau] (
	[MaHoKhau] nvarChar(50) NOT NULL,
	[NgayDangKy] date NULL,
	[NgayChuyenDi] date NULL,
	[MaTaiKhoan] nvarChar(50) NOT NULL,
	[MaChuHo] nvarChar(50) NOT NULL,
	[MaVung] nvarChar(50) NOT NULL,
Primary Key  ([MaHoKhau])
) 
go

Create table [ChuHo] (
	[MaChuHo] nvarChar(50) NOT NULL,
	[TenChuHo] nvarChar(50) NULL,
	[NgaySinh] date NULL,
	[GioiTinh] bit NULL,
	[QueQuan] nvarChar(50) NULL,
	[DanToc] nvarChar(50) NULL,
	[TonGiao] nvarChar(50) NULL,
	[SoCMND_CCCD] nvarChar(50) NULL,
	[NgheNghiep] nvarChar(50) NULL,
	[NoiLamViec] nvarChar(50) NULL,
	[NgayChuyenDen] date NULL,
	[NoiThuongChu] nvarChar(50) NULL,
	[TinhTrangHonNhan] nvarChar(50) NULL,
Primary Key  ([MaChuHo])
) 
go

Create table [DiaChi] (
	[MaVung] nvarChar(50) NOT NULL,
	[TenTinh_ThanhPho] nvarChar(50) NULL,
	[TenQuan_Huyen] nvarChar(50) NULL,
	[TenPhuong_Xa] nvarChar(50) NULL,
	[SoNha] nvarChar(10) NULL,
	[TenThon_Xom] nvarChar(50) NULL,
Primary Key  ([MaVung])
) 
go

Create table [HoiDap] (
	[MaCauHoi] nvarChar(50) NOT NULL,
	[NoiDungCauHoi] nvarChar(225) NULL,
	[NoiDungCauTraLoi] nvarChar(225) NULL,
	[MaTaiKhoan] nvarChar(50) NOT NULL,
Primary Key  ([MaCauHoi])
) 
go

Create table [ThongBaoXaGui] (
	[MaThongBao] nvarChar(50) NOT NULL,
	[NoiDungThongBao] nvarChar(225) NULL,
	[MaTaiKhoan] nvarChar(50) NOT NULL,
Primary Key  ([MaThongBao])
) 
go
--Set quoted_identifier on
--go
--Set quoted_identifier off
--go



