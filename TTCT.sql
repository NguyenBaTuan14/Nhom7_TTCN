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
Create database QLThongTinDanCu
go
use QLThongTinDanCu
go
/*Drop table [ThongBaoXaGui] 
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
*/

Create table [TaiKhoan] (
	[MaTaiKhoan] nvarChar(50) NOT NULL,
	[Ho] nvarChar(35) NULL,
	[Ten] nvarChar(15) NULL,
	[SoDienThoai] nvarChar(10) NULL,
	[Email] nvarChar(225) NULL,
	[AnhChanDung] image NULL,
	[MatKhau] nvarChar(50) NULL,
Primary Key  ([MaTaiKhoan])
) 

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
	[NoiDungCauHoi] text NULL,
	[NoiDungCauTraLoi] text NULL,
	[MaTaiKhoan] nvarChar(50) NOT NULL,
Primary Key  ([MaCauHoi])
) 
go

Create table [ThongBaoXaGui] (
	[MaThongBao] nvarChar(50) NOT NULL,
	[NoiDungThongBao] text NULL,
	[NgayThongBao] date NOT NULL,
	[MaTaiKhoan] nvarChar(50) NOT NULL,
Primary Key  ([MaThongBao])
) 
go
--Set quoted_identifier on
--go
--Set quoted_identifier off
--go

-- Use the database
use QLThongTinDanCu
go

-- Insert data into TaiKhoan
INSERT INTO [TaiKhoan] ([MaTaiKhoan], [Ho], [Ten], [SoDienThoai], [Email], [AnhChanDung], [MatKhau]) VALUES
('TK001', 'Nguyen Van', 'An', '0912345678', 'nguyenan@example.com', NULL, 'password123'),
('TK002', 'Tran Thi', 'Binh', '0987654321', 'tranbinh@example.com', NULL, 'password456'),
('TK003', 'Le Van', 'Cuong', '0922333444', 'lecuong@example.com', NULL, 'password789');

-- Insert data into DiaChi
INSERT INTO [DiaChi] ([MaVung], [TenTinh_ThanhPho], [TenQuan_Huyen], [TenPhuong_Xa], [SoNha], [TenThon_Xom]) VALUES
('DC001', 'Hanoi', 'Nam Tu Liem', 'Cau Dien', '12A', 'Thon 1'),
('DC002', 'Hanoi', 'Nam Tu Liem', 'Cau Dien', '45B', 'Thon 2'),
('DC003', 'Hanoi', 'Nam Tu Liem', 'Cau Dien', '678', 'Thon 3');

-- Insert data into ChuHo
INSERT INTO [ChuHo] ([MaChuHo], [TenChuHo], [NgaySinh], [GioiTinh], [QueQuan], [DanToc], [TonGiao], [SoCMND_CCCD], [NgheNghiep], [NoiLamViec], [NgayChuyenDen], [NoiThuongChu], [TinhTrangHonNhan]) VALUES
('CH001', 'Nguyen Van An', '1970-01-01', 1, 'Hanoi', 'Kinh', 'Khong', '123456789', 'Giao vien', 'Truong THPT Cau Dien', '1990-05-05', '12A Nguyen Xa', 'Da ket hon'),
('CH002', 'Tran Thi Binh', '1980-02-02', 0, 'Hanoi', 'Kinh', 'Khong', '987654321', 'Bac si', 'Benh vien 108', '2000-06-06', '45B Nguyen Xa', 'Da ket hon'),
('CH003', 'Le Van Cuong', '1990-03-03', 1, 'Hanoi', 'Kinh', 'Khong', '111222333', 'Ky su', 'Cong ty Xay Dung Nam Tu Liem', '2010-07-07', '67 Nguyen Xa', 'Da ket hon');

-- Insert data into HoKhau
INSERT INTO [HoKhau] ([MaHoKhau], [NgayDangKy], [NgayChuyenDi], [MaTaiKhoan], [MaChuHo], [MaVung]) VALUES
('HK001', '2000-01-01', NULL, 'TK001', 'CH001', 'DC001'),
('HK002', '2005-02-02', NULL, 'TK002', 'CH002', 'DC002'),
('HK003', '2010-03-03', NULL, 'TK003', 'CH003', 'DC003');

-- Insert data into NhanKhau
INSERT INTO [NhanKhau] ([MaNhanKhau], [HoTen], [QuanHeVoiChuHo], [SoCMND_CCCD], [GioiTinh], [NgaySinh], [TrinhDoHocVan], [NgheNghiep], [TonGiao], [DiaChiThuongChu], [TinhTrangHonNhan], [DanToc], [MaHoKhau]) VALUES
('NK001', 'Nguyen Van An', 'Chu ho', '123456789', 1, '1970-01-01', 'Dai hoc', 'Giao vien', 'Khong', '12A Nguyen Xa', 'Da ket hon', 'Kinh', 'HK001'),
('NK002', 'Nguyen Thi Binh', 'Vo', '987654321', 0, '1980-02-02', 'Dai hoc', 'Bac si', 'Khong', '12A Nguyen Xa', 'Da ket hon', 'Kinh', 'HK001'),
('NK003', 'Tran Van Cuong', 'Con', '111222333', 1, '2005-05-05', 'THPT', 'Sinh vien', 'Khong', '45B Nguyen Xa', 'Doc than', 'Kinh', 'HK002'),
('NK004', 'Le Thi Dung', 'Chu ho', '111222333', 0, '1990-03-03', 'Dai hoc', 'Ky su', 'Khong', '67 Nguyen Xa', 'Da ket hon', 'Kinh', 'HK003');

-- Insert data into HoiDap
INSERT INTO [HoiDap] ([MaCauHoi], [NoiDungCauHoi], [NoiDungCauTraLoi], [MaTaiKhoan]) VALUES
('Q001', 'Cau hoi 1', 'Tra loi 1', 'TK001'),
('Q002', 'Cau hoi 2', 'Tra loi 2', 'TK002'),
('Q003', 'Cau hoi 3', 'Tra loi 3', 'TK003');

-- Insert data into ThongBaoXaGui
INSERT INTO [ThongBaoXaGui] ([MaThongBao], [NoiDungThongBao], [NgayThongBao], [MaTaiKhoan]) VALUES
('TB001', 'Thong bao 1', '2024-01-01', 'TK001'),
('TB002', 'Thong bao 2', '2024-02-02', 'TK002'),
('TB003', 'Thong bao 3', '2024-03-03', 'TK003');


