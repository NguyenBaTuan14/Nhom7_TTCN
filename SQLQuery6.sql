use master

create database QLDanCuNguyenXa
go
use QLDanCuNguyenXa
go
-- Create tables
CREATE TABLE DiaChi (
    MaVung NVARCHAR(50) NOT NULL PRIMARY KEY,
    Tinh_ThanhPho NVARCHAR(50),
    Quan_Huyen NVARCHAR(50),
    Phuong_Xa NVARCHAR(50),
    Thon_Xom_Duong NVARCHAR(50),
    SoNha NVARCHAR(10),
    MaHoKhau NVARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE HoKhau (
    MaHoKhau NVARCHAR(50) NOT NULL PRIMARY KEY,
    NgayDangKy DATETIME,
    NgayChuyenDi DATETIME
);

CREATE TABLE TaiKhoan (
    MaTaiKhoan NVARCHAR(50) NOT NULL PRIMARY KEY,
    Ho NVARCHAR(50),
    Ten NVARCHAR(50),
    SoDienThoai NVARCHAR(10),
    Email NVARCHAR(225),
    AnhChanDung IMAGE,
    MatKhau NVARCHAR(50),
    Role NVARCHAR(50)
);

CREATE TABLE ChuHo (
    MaChuHo NVARCHAR(50) NOT NULL PRIMARY KEY,
    HoTen NVARCHAR(50),
    NgaySinh DATETIME,
    GioiTinh BIT,
    QueQuan NVARCHAR(100),
    DanToc NVARCHAR(50),
    TonGiao NVARCHAR(50),
    SoCMND_CCCD NVARCHAR(20),
    NgheNghiep NVARCHAR(50),
    NoiLamViec NVARCHAR(100),
    NgayChuyenDen DATETIME,
    DiaChiThuongChu NVARCHAR(225),
    TinhTrangHonNhan NVARCHAR(50),
    MaHoKhau NVARCHAR(50) NOT NULL,
    MaTaiKhoan NVARCHAR(50),
    FOREIGN KEY (MaHoKhau) REFERENCES HoKhau(MaHoKhau),
    FOREIGN KEY (MaTaiKhoan) REFERENCES TaiKhoan(MaTaiKhoan)
);

CREATE TABLE NhanKhau (
    MaNhanKhau NVARCHAR(50) NOT NULL PRIMARY KEY,
    HoTen NVARCHAR(50),
    QuanHeVoiChuHo NVARCHAR(50),
    SoCMND_CCCD NVARCHAR(20),
    GioiTinh BIT,
    NgaySinh DATETIME,
    TrinhDoHocVan NVARCHAR(50),
    NgheNghiep NVARCHAR(50),
    DiaChiThuongChu NVARCHAR(100),
    TinhTrangHonNhan NVARCHAR(50),
    DanToc NVARCHAR(50),
    TonGiao NVARCHAR(50),
    MaHoKhau NVARCHAR(50) NOT NULL,
    FOREIGN KEY (MaHoKhau) REFERENCES HoKhau(MaHoKhau),
);

CREATE TABLE ThongBao (
    MaThongBao NVARCHAR(50) NOT NULL PRIMARY KEY,
    NoiDungChiTiet TEXT,
    NgayThongBao DATETIME,
    TieuDeThongBao TEXT
);

CREATE TABLE ThongBao_TaiKhoan (
    MaThongBao NVARCHAR(50) NOT NULL,
    MaTaiKhoan NVARCHAR(50) NOT NULL,
    PRIMARY KEY (MaThongBao, MaTaiKhoan),
    FOREIGN KEY (MaThongBao) REFERENCES ThongBao(MaThongBao),
    FOREIGN KEY (MaTaiKhoan) REFERENCES TaiKhoan(MaTaiKhoan)
);

CREATE TABLE PhanAnh (
    MaPhanAnh NVARCHAR(50) NOT NULL PRIMARY KEY,
    NoiDungPhanAnh TEXT,
    NoiDungPhanHoi TEXT,
    MaTaiKhoan NVARCHAR(50) NOT NULL,
    FOREIGN KEY (MaTaiKhoan) REFERENCES TaiKhoan(MaTaiKhoan)
);

-- Insert data

-- Insert data into DiaChi
INSERT INTO DiaChi (MaVung, Tinh_ThanhPho, Quan_Huyen, Phuong_Xa, Thon_Xom_Duong, SoNha, MaHoKhau) VALUES
('V01', 'Ha Noi', 'Bac Tu lien', 'Nguyen Xa', 'Xom Ca', '139', 'HK01'),
('V02', 'Ha Noi', 'Bac Tu lien', 'Nguyen Xa', 'Xom Ca', '10', 'HK02'),
('V03', 'Ha Noi', 'Bac Tu lien', 'Nguyen Xa', 'Xom Ca', '19', 'HK03'),
('V04', 'Ha Noi', 'Bac Tu lien', 'Nguyen Xa', 'Xom Ca', '13', 'HK04'),
('V05', 'Ha Noi', 'Bac Tu lien', 'Nguyen Xa', 'Xom Ca', '15', 'HK05'),
('V06', 'Ha Noi', 'Bac Tu lien', 'Nguyen Xa', 'Xom Ca', '39', 'HK06'),
('V07', 'Ha Noi', 'Bac Tu lien', 'Nguyen Xa', 'Xom Ca', '45', 'HK07'),
('V08', 'Ha Noi', 'Bac Tu lien', 'Nguyen Xa', 'Xom Ca', '23', 'HK08'),
('V09', 'Ha Noi', 'Bac Tu lien', 'Nguyen Xa', 'Xom Ca', '96', 'HK09'),
('V010', 'Ha Noi', 'Bac Tu lien', 'Nguyen Xa', 'Xom Ca', '109', 'HK10')

-- Insert data into HoKhau
INSERT INTO HoKhau (MaHoKhau, NgayDangKy, NgayChuyenDi) VALUES
('HK01', '2010-01-01', NULL),
('HK02', '2011-01-01', NULL),
('HK03', '2012-01-01', NULL),
('HK04', '2013-01-01', NULL),
('HK05', '2014-01-01', NULL),
('HK06', '2015-01-01', NULL),
('HK07', '2016-01-01', NULL),
('HK08', '2017-01-01', NULL),
('HK09', '2018-01-01', NULL),
('HK10', '2019-01-01', NULL);

-- Insert data into TaiKhoan
INSERT INTO TaiKhoan (MaTaiKhoan, Ho, Ten, SoDienThoai, Email, AnhChanDung, MatKhau, Role) VALUES
('TK01', 'Nguyen', 'Van A', '0912345670', 'a@gmail.com', NULL, 'password1', 'user'),
('TK02', 'Tran', 'Van B', '0912345671', 'b@gmail.com', NULL, 'password2', 'user'),
('TK03', 'Le', 'Van C', '0912345672', 'c@gmail.com', NULL, 'password3', 'user'),
('TK04', 'Pham', 'Van D', '0912345673', 'd@gmail.com', NULL, 'password4', 'user'),
('TK05', 'Hoang', 'Van E', '0912345674', 'e@gmail.com', NULL, 'password5', 'user'),
('TK06', 'Admin', 'User', '0912345680', 'admin@gmail.com', NULL, 'adminpass', 'admin');

-- Insert data into ChuHo
INSERT INTO ChuHo (MaChuHo, HoTen, NgaySinh, GioiTinh, QueQuan, DanToc, TonGiao, SoCMND_CCCD, NgheNghiep, NoiLamViec, NgayChuyenDen, DiaChiThuongChu, TinhTrangHonNhan, MaHoKhau, MaTaiKhoan) VALUES
('CH01', 'Nguyen Van A', '1980-01-01', 1, 'Ha Noi', 'Kinh', 'None', '001198001', 'Giao vien', 'THPT ABC', '2010-01-01', 'Ha Noi', 'Da ket hon', 'HK01', 'TK01'),
('CH02', 'Tran Van B', '1981-01-01', 1, 'Ha Noi', 'Kinh', 'None', '002198101', 'Ky su', 'Cong ty XYZ', '2011-01-01', 'Ha Noi', 'Da ket hon', 'HK02', 'TK02'),
('CH03', 'Le Van C', '1982-01-01', 1, 'Ha Noi', 'Kinh', 'None', '003198201', 'Bac si', 'Benh vien 123', '2012-01-01', 'Ha Noi', 'Da ket hon', 'HK03', 'TK03'),
('CH04', 'Pham Van D', '1983-01-01', 1, 'Ha Noi', 'Kinh', 'None', '004198301', 'Lu su', 'Cong ty Luat 456', '2013-01-01', 'Ha Noi', 'Da ket hon', 'HK04', 'TK04'),
('CH05', 'Hoang Van E', '1984-01-01', 1, 'Ha Noi', 'Kinh', 'None', '005198401', 'Kinh doanh', 'Cua hang E', '2014-01-01', 'Ha Noi', 'Da ket hon', 'HK05', 'TK05'),
('CH06', 'Vu Van F', '1985-01-01', 1, 'Ha Noi', 'Kinh', 'None', '006198501', 'Giam doc', 'Cong ty F', '2015-01-01', 'Ha Noi', 'Da ket hon', 'HK06', NULL),
('CH07', 'Dang Van G', '1986-01-01', 1, 'Ha Noi', 'Kinh', 'None', '007198601', 'Nhan vien', 'Cong ty G', '2016-01-01', 'Ha Noi', 'Da ket hon', 'HK07', NULL),
('CH08', 'Do Van H', '1987-01-01', 1, 'Ha Noi', 'Kinh', 'None', '008198701', 'Cong nhan', 'Nha may H', '2017-01-01', 'Ha Noi', 'Da ket hon', 'HK08', NULL),
('CH09', 'Ngo Van I', '1988-01-01', 1, 'Ha Noi', 'Kinh', 'None', '009198801', 'Thu ky', 'Cong ty I', '2018-01-01', 'Ha Noi', 'Da ket hon', 'HK09', NULL),
('CH10', 'Dinh Van J', '1989-01-01', 1, 'Ha Noi', 'Kinh', 'None', '010198901', 'Bao ve', 'Cong ty J', '2019-01-01', 'Ha Noi', 'Da ket hon', 'HK10', NULL);

-- Insert data into NhanKhau (each household will have 4 members)
INSERT INTO NhanKhau (MaNhanKhau, HoTen, QuanHeVoiChuHo, SoCMND_CCCD, GioiTinh, NgaySinh, TrinhDoHocVan, NgheNghiep, DiaChiThuongChu, TinhTrangHonNhan, DanToc, TonGiao, MaHoKhau) VALUES
('NK01', 'Nguyen Thi A', 'Vo', '001198011', 0, '1982-01-01', 'Dai hoc', 'Giao vien', 'Ha Noi', 'Da ket hon', 'Kinh', 'None', 'HK01'),
('NK02', 'Nguyen Van B', 'Con', '001199501', 1, '2005-01-01', 'THPT', 'Hoc sinh', 'Ha Noi', 'Chua ket hon', 'Kinh', 'None', 'HK01'),
('NK03', 'Nguyen Thi C', 'Con', '001199601', 0, '2007-01-01', 'THCS', 'Hoc sinh', 'Ha Noi', 'Chua ket hon', 'Kinh', 'None', 'HK01'),
('NK04', 'Tran Thi B', 'Vo', '002198111', 0, '1983-01-01', 'Dai hoc', 'Ky su', 'Ha Noi', 'Da ket hon', 'Kinh', 'None', 'HK02'),
('NK05', 'Tran Van C', 'Con', '002199511', 1, '2006-01-01', 'THPT', 'Hoc sinh', 'Ha Noi', 'Chua ket hon', 'Kinh', 'None', 'HK02'),
('NK06', 'Tran Thi D', 'Con', '002199611', 0, '2008-01-01', 'THCS', 'Hoc sinh', 'Ha Noi', 'Chua ket hon', 'Kinh', 'None', 'HK02'),
('NK07', 'Le Thi C', 'Vo', '003198211', 0, '1984-01-01', 'Dai hoc', 'Bac si', 'Ha Noi', 'Da ket hon', 'Kinh', 'None', 'HK03'),
('NK08', 'Le Van D', 'Con', '003199511', 1, '2007-01-01', 'THPT', 'Hoc sinh', 'Ha Noi', 'Chua ket hon', 'Kinh', 'None', 'HK03'),
('NK09', 'Le Thi E', 'Con', '003199611', 0, '2009-01-01', 'THCS', 'Hoc sinh', 'Ha Noi', 'Chua ket hon', 'Kinh', 'None', 'HK03'),
('NK10', 'Pham Thi D', 'Vo', '004198311', 0, '1985-01-01', 'Dai hoc', 'Lu su', 'Ha Noi', 'Da ket hon', 'Kinh', 'None', 'HK04'),
('NK11', 'Pham Van E', 'Con', '004199511', 1, '2008-01-01', 'THPT', 'Hoc sinh', 'Ha Noi', 'Chua ket hon', 'Kinh', 'None', 'HK04'),
('NK12', 'Pham Thi F', 'Con', '004199611', 0, '2010-01-01', 'THCS', 'Hoc sinh', 'Ha Noi', 'Chua ket hon', 'Kinh', 'None', 'HK04'),
('NK13', 'Hoang Thi E', 'Vo', '005198411', 0, '1986-01-01', 'Dai hoc', 'Kinh doanh', 'Ha Noi', 'Da ket hon', 'Kinh', 'None', 'HK05'),
('NK14', 'Hoang Van F', 'Con', '005199511', 1, '2009-01-01', 'THPT', 'Hoc sinh', 'Ha Noi', 'Chua ket hon', 'Kinh', 'None', 'HK05'),
('NK15', 'Hoang Thi G', 'Con', '005199611', 0, '2011-01-01', 'THCS', 'Hoc sinh', 'Ha Noi', 'Chua ket hon', 'Kinh', 'None', 'HK05'),
('NK16', 'Vu Thi F', 'Vo', '006198511', 0, '1987-01-01', 'Dai hoc', 'Giam doc', 'Ha Noi', 'Da ket hon', 'Kinh', 'None', 'HK06'),
('NK17', 'Vu Van G', 'Con', '006199511', 1, '2010-01-01', 'THPT', 'Hoc sinh', 'Ha Noi', 'Chua ket hon', 'Kinh', 'None', 'HK06'),
('NK18', 'Vu Thi H', 'Con', '006199611', 0, '2012-01-01', 'THCS', 'Hoc sinh', 'Ha Noi', 'Chua ket hon', 'Kinh', 'None', 'HK06'),
('NK21', 'Dang Thi I', 'Con', '007199611', 0, '2013-01-01', 'THCS', 'Hoc sinh', 'Ha Noi', 'Chua ket hon', 'Kinh', 'None', 'HK07'),
('NK19', 'Dang Thi G', 'Vo', '007198611', 0, '1988-01-01', 'Dai hoc', 'Nhan vien', 'Ha Noi', 'Da ket hon', 'Kinh', 'None', 'HK07'),
('NK20', 'Dang Van H', 'Con', '007199511', 1, '2011-01-01', 'THPT', 'Hoc sinh', 'Ha Noi', 'Chua ket hon', 'Kinh', 'None', 'HK07'),
('NK23', 'Do Van I', 'Con', '008199511', 1, '2012-01-01', 'THPT', 'Hoc sinh', 'Ha Noi', 'Chua ket hon', 'Kinh', 'None', 'HK08'),
('NK24', 'Do Thi J', 'Con', '008199611', 0, '2014-01-01', 'THCS', 'Hoc sinh', 'Ha Noi', 'Chua ket hon', 'Kinh', 'None', 'HK08'),
('NK25', 'Ngo Thi I', 'Vo', '009198811', 0, '1990-01-01', 'Dai hoc', 'Thu ky', 'Ha Noi', 'Da ket hon', 'Kinh', 'None', 'HK09'),
('NK26', 'Ngo Van J', 'Con', '009199511', 1, '2013-01-01', 'THPT', 'Hoc sinh', 'Ha Noi', 'Chua ket hon', 'Kinh', 'None', 'HK09'),
('NK27', 'Ngo Thi K', 'Con', '009199611', 0, '2015-01-01', 'THCS', 'Hoc sinh', 'Ha Noi', 'Chua ket hon', 'Kinh', 'None', 'HK09'),
('NK28', 'Dinh Thi J', 'Vo', '010198911', 0, '1991-01-01', 'Dai hoc', 'Bao ve', 'Ha Noi', 'Da ket hon', 'Kinh', 'None', 'HK10'),
('NK29', 'Dinh Van K', 'Con', '010199511', 1, '2014-01-01', 'THPT', 'Hoc sinh', 'Ha Noi', 'Chua ket hon', 'Kinh', 'None', 'HK10'),
('NK30', 'Dinh Thi L', 'Con', '010199611', 0, '2016-01-01', 'THCS', 'Hoc sinh', 'Ha Noi', 'Chua ket hon', 'Kinh', 'None', 'HK10');

-- Insert data into ThongBao
INSERT INTO ThongBao (MaThongBao, NoiDungChiTiet, NgayThongBao, TieuDeThongBao) VALUES
('TB01', 'Noi dung thong bao 1', '2024-01-01', 'Thong bao 1'),
('TB02', 'Noi dung thong bao 2', '2024-01-02', 'Thong bao 2'),
('TB03', 'Noi dung thong bao 3', '2024-01-03', 'Thong bao 3'),
('TB04', 'Noi dung thong bao 4', '2024-01-04', 'Thong bao 4'),
('TB05', 'Noi dung thong bao 5', '2024-01-05', 'Thong bao 5'),
('TB06', 'Noi dung thong bao 6', '2024-01-06', 'Thong bao 6'),
('TB07', 'Noi dung thong bao 7', '2024-01-07', 'Thong bao 7'),
('TB08', 'Noi dung thong bao 8', '2024-01-08', 'Thong bao 8'),
('TB09', 'Noi dung thong bao 9', '2024-01-09', 'Thong bao 9'),
('TB10', 'Noi dung thong bao 10', '2024-01-10', 'Thong bao 10');

-- Insert data into ThongBao_TaiKhoan (each account can view all 10 notifications)
INSERT INTO ThongBao_TaiKhoan (MaThongBao, MaTaiKhoan) VALUES
('TB01', 'TK01'), ('TB02', 'TK01'), ('TB03', 'TK01'), ('TB04', 'TK01'), ('TB05', 'TK01'), ('TB06', 'TK01'), ('TB07', 'TK01'), ('TB08', 'TK01'), ('TB09', 'TK01'), ('TB10', 'TK01'),
('TB01', 'TK02'), ('TB02', 'TK02'), ('TB03', 'TK02'), ('TB04', 'TK02'), ('TB05', 'TK02'), ('TB06', 'TK02'), ('TB07', 'TK02'), ('TB08', 'TK02'), ('TB09', 'TK02'), ('TB10', 'TK02'),
('TB01', 'TK03'), ('TB02', 'TK03'), ('TB03', 'TK03'), ('TB04', 'TK03'), ('TB05', 'TK03'), ('TB06', 'TK03'), ('TB07', 'TK03'), ('TB08', 'TK03'), ('TB09', 'TK03'), ('TB10', 'TK03'),
('TB01', 'TK04'), ('TB02', 'TK04'), ('TB03', 'TK04'), ('TB04', 'TK04'), ('TB05', 'TK04'), ('TB06', 'TK04'), ('TB07', 'TK04'), ('TB08', 'TK04'), ('TB09', 'TK04'), ('TB10', 'TK04'),
('TB01', 'TK05'), ('TB02', 'TK05'), ('TB03', 'TK05'), ('TB04', 'TK05'), ('TB05', 'TK05'), ('TB06', 'TK05'), ('TB07', 'TK05'), ('TB08', 'TK05'), ('TB09', 'TK05'), ('TB10', 'TK05');

-- Insert data into PhanAnh
INSERT INTO PhanAnh (MaPhanAnh, NoiDungPhanAnh, NoiDungPhanHoi, MaTaiKhoan) VALUES
('PA01', 'Phan anh 1', 'Phan hoi 1', 'TK01'),
('PA02', 'Phan anh 2', 'Phan hoi 2', 'TK02'),
('PA03', 'Phan anh 3', 'Phan hoi 3', 'TK03'),
('PA04', 'Phan anh 4', 'Phan hoi 4', 'TK04'),
('PA05', 'Phan anh 5', 'Phan hoi 5', 'TK05');












