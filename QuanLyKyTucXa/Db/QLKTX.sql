CREATE DATABASE QLKTX;
USE QLKTX;
CREATE TABLE KHU (
    MaKhu VARCHAR(3) PRIMARY KEY,
    SLTang TINYINT,
    PhanLoai NVARCHAR(100)
);

CREATE TABLE Tang (
    MaKhu VARCHAR(3),
    MaTang TINYINT,
    SLPhong TINYINT,
    DoiTuong NVARCHAR(50),
    CONSTRAINT pk_Tang PRIMARY KEY (MaKhu, MaTang),
    CONSTRAINT fk_Tang_KHU FOREIGN KEY (MaKhu) REFERENCES KHU(MaKhu)
);

CREATE TABLE Phong (
    MaKhu VARCHAR(3),
    MaTang TINYINT,
    MaPhong TINYINT,
    GiaPhong MONEY,
    SucChua TINYINT,
    CONSTRAINT pk_Phong PRIMARY KEY (MaKhu, MaTang, MaPhong),
    CONSTRAINT fk_Phong_Tang FOREIGN KEY (MaKhu, MaTang) REFERENCES Tang(MaKhu, MaTang)
);

CREATE TABLE QuanLiKTX (
    MaQuanLi VARCHAR(5) PRIMARY KEY,
    MaKhu VARCHAR(3),
    HovaTenLot NVARCHAR(100),
    TenQuanLi NVARCHAR(20),
    GioiTinh NVARCHAR(5),
    SDT VARCHAR(20),
    QueQuan NVARCHAR(100),
    CONSTRAINT fk_QuanLi_KHU FOREIGN KEY (MaKhu) REFERENCES KHU(MaKhu)
);

CREATE TABLE QuyDinhUuTien (
    MaUuTien VARCHAR(5) PRIMARY KEY,
    MoTa NVARCHAR(100),
    PhanTramGiam TINYINT
);

CREATE TABLE SinhVien (
    MaSV VARCHAR(8) PRIMARY KEY,
    MaKhu VARCHAR(3),
    MaTang TINYINT,
    MaPhong TINYINT,
    HovaTenLot NVARCHAR(100),
    Ten NVARCHAR(20),
    NgaySinh DATE,
    GioiTinh NVARCHAR(5),
    Email VARCHAR(50),
    DiaChi NVARCHAR(100),
    MaUuTien VARCHAR(5),
    CONSTRAINT fk_SV_KHU FOREIGN KEY (MaKhu) REFERENCES KHU(MaKhu),
    CONSTRAINT fk_SV_Tang FOREIGN KEY (MaKhu, MaTang) REFERENCES Tang(MaKhu, MaTang),
    CONSTRAINT fk_SV_Phong FOREIGN KEY (MaKhu, MaTang, MaPhong) REFERENCES Phong(MaKhu, MaTang, MaPhong),
    CONSTRAINT fk_SV_UuTien FOREIGN KEY (MaUuTien) REFERENCES QuyDinhUuTien(MaUuTien)
);

CREATE TABLE HopDongKTX (
    MaHD VARCHAR(5) PRIMARY KEY,
    MaSV VARCHAR(8),
    NgayApDung DATE,
    NgayHetHan DATE,
    CONSTRAINT fk_HD_SV FOREIGN KEY (MaSV) REFERENCES SinhVien(MaSV)
);

CREATE TABLE DichVu (
    MaDV VARCHAR(5) PRIMARY KEY,
    TenDV NVARCHAR(20),
    DonViTinh NVARCHAR(20)
);

CREATE TABLE HoaDon (
    MaKhu VARCHAR(3),
    MaTang TINYINT,
    MaPhong TINYINT,
    Thang TINYINT,
    Nam SMALLINT,
    MaDV VARCHAR(5),
    ChiSoDau INT,
    ChiSoCuoi INT,
    CONSTRAINT pk_HoaDon PRIMARY KEY (MaKhu, MaTang, MaPhong, Thang, Nam , MaDV),
    CONSTRAINT fk_HD_Phong FOREIGN KEY (MaKhu, MaTang, MaPhong) REFERENCES Phong(MaKhu, MaTang, MaPhong),
    CONSTRAINT fk_HD_DV FOREIGN KEY (MaDV) REFERENCES DichVu(MaDV)
);
CREATE TABLE NguoiDung (
    TenDangNhap VARCHAR(50) PRIMARY KEY,
    MatKhau VARCHAR(255) NOT NULL,
    VaiTro NVARCHAR(10) NOT NULL CHECK (VaiTro IN (N'Quản trị', N'Nhân viên', N'Sinh viên')),
    MaSV VARCHAR(8),
    MaQuanLi VARCHAR(5),

    CONSTRAINT fk_NguoiDung_SV FOREIGN KEY (MaSV) REFERENCES SinhVien(MaSV),
    CONSTRAINT fk_NguoiDung_QL FOREIGN KEY (MaQuanLi) REFERENCES QuanLiKTX(MaQuanLi)
);

-- Thêm bản ghi vào bảng KHU
INSERT INTO KHU (MaKhu, SLTang, PhanLoai) VALUES
('K1', 3, N'Sinh Viên và Khách'),
('K2', 2, N'Sinh Viên Nữ'),
('K3', 3, N'Sinh Viên Nam'),
('K4', 3, N'Sinh Viên Nữ'),
('K5', 3, N'Sinh Viên Nữ'),
('K7', 3, N'Sinh Viên Nam'),
('K8', 5, N'Sinh Viên Nữ');

-- Thêm bản ghi vào bảng Tang
INSERT INTO Tang (MaKhu, MaTang, SLPhong, DoiTuong) VALUES
('K1', 1, 2, N'Sinh Viên'),
('K1', 2, 2, N'Khách'),
('K1', 3, 2, N'Sinh Viên'),
('K2', 1, 3, N'Sinh Viên Nữ'),
('K2', 2, 4, N'Sinh Viên Nữ'),
('K3', 1, 5, N'Sinh Viên Nam'),
('K3', 2, 5, N'Sinh Viên Nam'),
('K3', 3, 5, N'Sinh Viên Nam'),
('K4', 2, 4, N'Sinh Viên Nước Ngoài'),
('K4', 3, 4, N'Sinh Viên Nữ'),
('K5', 1, 3, N'Sinh Viên Nữ'),
('K5', 2, 3, N'Sinh Viên Nữ'),
('K5', 3, 2, N'Sinh Viên Nữ'),
('K7', 1, 4, N'Nam'),
('K7', 2, 4, N'Nam'),
('K7', 3, 4, N'Nam'),
('K8', 1, 3, N'Nữ'),
('K8', 2, 3, N'Nữ'),
('K8', 3, 3, N'Nữ'),
('K8', 4, 3, N'Nữ'),
('K8', 5, 3, N'Nữ');

-- Thêm bản ghi vào bảng Phong
INSERT INTO Phong (MaKhu, MaTang, MaPhong, GiaPhong, SucChua) VALUES
-- Bảng Tang K1
('K1', 1, 1, 1500000, 1),
('K1', 1, 2, 2000000, 2),
('K1', 2, 1, 2000000, 1),
('K1', 2, 2, 2500000, 2),
('K1', 3, 1, 2000000, 2),
('K1', 3, 2, 1500000, 1),
-- Bảng Tang K2
('K2', 1, 1, 1200000, 4),
('K2', 1, 2, 1200000, 4),
('K2', 1, 3, 1200000, 4),
('K2', 2, 1, 1200000, 4),
('K2', 2, 2, 1200000, 4),
('K2', 2, 3, 1200000, 4),
('K2', 2, 4, 1200000, 4),
-- Bảng Tang K3
('K3', 1, 1, 1200000, 6),
('K3', 1, 2, 1000000, 5),
('K3', 1, 3, 1200000, 6),
('K3', 1, 4, 1000000, 5),
('K3', 1, 5, 1200000, 6),
('K3', 2, 1, 1200000, 6),
('K3', 2, 2, 1000000, 5),
('K3', 2, 3, 1200000, 6),
('K3', 2, 4, 1000000, 5),
('K3', 2, 5, 1200000, 6),
-- Bảng Tang K4
('K4', 2, 1, 1500000, 2),
('K4', 2, 2, 1500000, 2),
('K4', 2, 3, 1500000, 2),
('K4', 2, 4, 1500000, 2),
('K4', 3, 1, 1300000, 5),
('K4', 3, 2, 1300000, 5),
('K4', 3, 3, 1500000, 6),
('K4', 3, 4, 1500000, 6),
-- Bảng Tang K5
('K5', 1, 1, 1750000, 6),
('K5', 1, 2, 1750000, 6),
('K5', 1, 3, 1500000, 5),
('K5', 2, 1, 1400000, 4),
('K5', 2, 2, 1400000, 4),
('K5', 2, 3, 1400000, 4),
-- Bảng Tang K7
('K7', 1, 1, 1500000, 6),
('K7', 1, 2, 1500000, 6),
('K7', 1, 3, 1500000, 6),
('K7', 1, 4, 1500000, 6),
('K7', 2, 1, 1350000, 5),
('K7', 2, 2, 1350000, 5),
('K7', 2, 3, 1350000, 6),
('K7', 2, 4, 1350000, 6),
-- Bảng Tang K8
('K8', 1, 1, 1600000, 8),
('K8', 1, 2, 1600000, 8),
('K8', 1, 3, 1000000, 5),
('K8', 2, 1, 1800000, 8),
('K8', 2, 2, 1800000, 8),
('K8', 2, 3, 1800000, 8),
('K8', 3, 1, 1800000, 8),
('K8', 3, 2, 1800000, 8),
('K8', 3, 3, 1800000, 8),
('K8', 4, 1, 1600000, 6),
('K8', 4, 2, 1600000, 6),
('K8', 4, 3, 1600000, 6),
('K8', 5, 1, 1400000, 5),
('K8', 5, 2, 1400000, 5),
('K8', 5, 3, 1400000, 5);

-- Thêm bản ghi vào bảng QuanLiKTX
INSERT INTO QuanLiKTX (MaQuanLi, MaKhu, HovaTenLot, TenQuanLi, GioiTinh, SDT, QueQuan) VALUES
('QL1', 'K1', N'Nguyễn Văn', N'An', N'Nam', '0987654321', N'Phố Huế, Hà Nội'),
('QL2', 'K2', N'Trần Thị', N'Bình', N'Nữ', '0912345678', N'Số 10, Đường Láng, Hà Nội'),
('QL3', 'K3', N'Nguyễn Văn', N'Chung', N'Nam', '0934567890', N'Ngõ 123, Phố Vọng, Hà Nội'),
('QL4', 'K4', N'Trần Thị', N'Dân', N'Nữ', '0976543210', N'Khu đô thị Mỹ Đình, Hà Nội'),
('QL5', 'K5', N'Nguyễn Văn', N'Em', N'Nam', '0901234567', N'Số 5, Đường Nguyễn Trãi, Hà Nội'),
('QL7', 'K7', N'Nguyễn Văn', N'Giang', N'Nam', '0945678901', N'Phố Trần Duy Hưng, Hà Nội'),
('QL8', 'K8', N'Trần Thị', N'Hòa', N'Nữ', '0961234567', N'Số 20, Đường Lê Văn Lương, Hà Nội');
-- Thêm bản ghi vào bảng QuyDinhUuTien
INSERT INTO QuyDinhUuTien (MaUuTien, MoTa, PhanTramGiam) VALUES
('UT0', N'Sinh viên bình thường', 0),
('UT1', N'Sinh viên có hoàn cảnh khó khăn', 70),
('UT2', N'Sinh viên xuất sắc', 60),
('UT3', N'Sinh viên học các ngành truyền thống của trường', 100);


-- Thêm bản ghi vào bảng SinhVien
INSERT INTO SinhVien (MaSV, MaKhu, MaTang, MaPhong, HovaTenLot, Ten, NgaySinh, GioiTinh, Email, DiaChi, MaUuTien) VALUES
('SV000001', 'K1', 1, 1, N'Nguyễn Văn', N'Anh', '2002-05-10', N'Nam', 'anh.nv@example.com', N'Hà Nội', 'UT0'),
('SV000002', 'K1', 1, 2, N'Trần Thị', N'Bích', '2003-07-14', N'Nữ', 'bich.tt@example.com', N'Hồ Chí Minh', 'UT1'),
('SV000005', 'K1', 3, 1, N'Vũ Văn', N'Đạt', '2004-01-25', N'Nam', 'dat.vv@example.com', N'Hải Phòng', 'UT1'),
('SV000006', 'K2', 1, 1, N'Lê Thị', N'Lan', '2003-03-12', N'Nữ', 'lan.lt@example.com', N'Thái Bình', 'UT2'),
('SV000009', 'K2', 2, 1, N'Bùi Văn', N'Phong', '2004-06-20', N'Nam', 'phong.bv@example.com', N'Tây Ninh', 'UT3'),
('SV000010', 'K2', 2, 2, N'Phan Thị', N'Lệ', '2002-10-15', N'Nữ', 'le.pt@example.com', N'Bình Định', 'UT0'),
('SV000011', 'K3', 1, 1, N'Ngô Văn', N'Hải', '2003-02-22', N'Nam', 'hai.nv@example.com', N'Cần Thơ', 'UT1'),
('SV000014', 'K3', 2, 1, N'Đặng Thị', N'Kiều', '2001-05-13', N'Nữ', 'kieu.dt@example.com', N'Phú Yên', 'UT1'),
('SV000015', 'K3', 2, 2, N'Mai Văn', N'Tín', '2003-09-03', N'Nam', 'tin.mv@example.com', N'Đồng Nai', 'UT2'),
('SV000016', 'K4', 2, 1, N'John', N'Doe', '2002-01-17', N'Nam', 'john.doe@example.com', N'USA', 'UT2'),
('SV000017', 'K4', 2, 2, N'Maria', N'Gonzalez', '2003-06-07', N'Nữ', 'maria.gonzalez@example.com', N'Spain', 'UT1'),
('SV000018', 'K4', 2, 3, N'Chen', N'Wei', '2001-03-27', N'Nam', 'chen.wei@example.com', N'China', 'UT2'),
('SV000019', 'K4', 2, 4, N'Alice', N'Brown', '2004-11-11', N'Nữ', 'alice.brown@example.com', N'UK', 'UT0'),
('SV000020', 'K4', 3, 1, N'Dương Văn', N'Bảo', '2002-08-09', N'Nam', 'bao.dv@example.com', N'Bắc Giang', 'UT1'),
('SV000021', 'K5', 1, 1, N'Đỗ Thị', N'Thảo', '2003-05-14', N'Nữ', 'thao.dt@example.com', N'Kiên Giang', 'UT2'),
('SV000022', 'K5', 1, 2, N'Tôn Văn', N'Cường', '2001-10-06', N'Nam', 'cuong.tv@example.com', N'Kon Tum', 'UT0'),
('SV000023', 'K7', 1, 1, N'Hà Văn', N'Lộc', '2002-09-02', N'Nam', 'loc.hv@example.com', N'Quảng Ngãi', 'UT3'),
('SV000026', 'K8', 4, 1, N'Tạ Thị', N'Thu', '2002-07-19', N'Nữ', 'thu.tt@example.com', N'Cao Bằng', 'UT0'),
('SV000027', 'K8', 5, 1, N'Phan Văn', N'Diễn', '2001-05-23', N'Nam', 'dien.pv@example.com', N'Bạc Liêu', 'UT2');

-- Thêm bản ghi vào bảng HopDongKTX
INSERT INTO HopDongKTX (MaHD, MaSV, NgayApDung, NgayHetHan) VALUES
('HD001', 'SV000001', '2023-09-10', '2024-06-01'),
('HD002', 'SV000002', '2024-09-10', '2025-06-01'),
('HD003', 'SV000005', '2025-09-10', '2026-06-01'),
('HD004', 'SV000006', '2022-07-01', '2022-09-01'),
('HD005', 'SV000009', '2023-07-01', '2023-09-01'),
('HD006', 'SV000010', '2024-07-01', '2024-09-01'),
('HD007', 'SV000011', '2025-07-01', '2025-09-01'),
('HD008', 'SV000014', '2022-09-10', '2023-06-01'),
('HD009', 'SV000015', '2023-09-10', '2024-06-01'),
('HD010', 'SV000016', '2024-09-10', '2025-06-01'),
('HD011', 'SV000017', '2025-09-10', '2026-06-01'),
('HD012', 'SV000018', '2022-07-01', '2022-09-01'),
('HD013', 'SV000019', '2023-07-01', '2023-09-01'),
('HD014', 'SV000020', '2024-07-01', '2024-09-01'),
('HD015', 'SV000021', '2025-07-01', '2025-09-01');

-- Thêm bản ghi vào bảng DichVu
INSERT INTO DichVu (MaDV, TenDV, DonViTinh) VALUES
('DV001', N'Điện', N'kWh'),
('DV002', N'Nước', N'm3');

-- Thêm bản ghi vào bảng HoaDon
INSERT INTO HoaDon (MaKhu, MaTang, MaPhong, Thang, Nam, MaDV, ChiSoDau, ChiSoCuoi) VALUES
('K1', 1, 1, 3, 2025, 'DV001', 120, 145),
('K1', 1, 2, 3, 2025, 'DV002', 15, 20),
('K1', 3, 1, 4, 2025, 'DV001', 98, 120),
('K2', 1, 1, 4, 2025, 'DV002', 12, 18),
('K2', 2, 1, 5, 2025, 'DV001', 150, 170),
('K2', 2, 2, 5, 2025, 'DV002', 25, 30),
('K3', 2, 2, 7, 2025, 'DV001', 145, 170),
('K4', 2, 1, 7, 2025, 'DV002', 8, 12),
('K4', 2, 2, 8, 2025, 'DV001', 110, 135),
('K4', 2, 3, 8, 2025, 'DV002', 14, 19),
('K4', 3, 1, 9, 2025, 'DV001', 100, 130),
('K5', 1, 1, 9, 2025, 'DV002', 22, 28),
('K5', 1, 2, 10, 2025, 'DV001', 125, 150);

-- Thêm người dùng: 2 Quản trị viên
INSERT INTO NguoiDung (TenDangNhap, MatKhau, VaiTro, MaQuanLi)
VALUES
('admin1', 'Admin@123', N'Quản trị', 'QL1'),
('admin2', 'Admin@123', N'Quản trị', 'QL2');

-- Thêm người dùng: 2 Nhân viên
INSERT INTO NguoiDung (TenDangNhap, MatKhau, VaiTro, MaQuanLi)
VALUES
('nv1', 'NV@123', N'Nhân viên', 'QL3'),
('nv2', 'NV@123', N'Nhân viên', 'QL4');

-- Thêm người dùng: 2 Sinh viên
INSERT INTO dbo.NguoiDung (TenDangNhap, MatKhau, VaiTro, MaSV)
VALUES
  ('SV000001', 'SV@123', N'Sinh viên', 'SV000001'),
  ('SV000002', 'SV@123', N'Sinh viên', 'SV000002');
--Lực
-- Phân Quyền 3 User
--Tạo 3 database role
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'QuanTri')
    CREATE ROLE [QuanTri];
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'NhanVien')
    CREATE ROLE [NhanVien];
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'SinhVien')
    CREATE ROLE [SinhVien];
GO

-- Role QuanTri
-- Quản lý KTX (bảng KHU): INSERT, UPDATE, SELECT
-- Quản lý Phòng (bảng Phong): UPDATE, SELECT
-- Quản lý người quản trị (bảng NguoiDung & QuanLiKTX): INSERT, UPDATE, DELETE, SELECT

-- Tạo CRUD (Create, Read, Update, Delete)  trên KHU
GRANT INSERT, UPDATE, SELECT 
    ON dbo.KHU TO [QuanTri];
-- Thêm báo cáo và kiểm tra bảng tầng
GRANT SELECT ON dbo.Tang TO [QuanTri];
-- Quản lý Phòng chỉ sửa và xem
GRANT UPDATE, SELECT 
    ON dbo.Phong TO [QuanTri];
-- Quản lý người quản trị
GRANT INSERT, UPDATE, DELETE, SELECT 
    ON dbo.NguoiDung TO [QuanTri];
GRANT INSERT, UPDATE, DELETE, SELECT 
    ON dbo.QuanLiKTX TO [QuanTri];

-- Báo cáo thống kê và cấp quyền truy cập
-- Thống kê tổng số sinh viên
IF OBJECT_ID('dbo.v_ThongKe_SinhVien', 'V') IS NOT NULL DROP VIEW dbo.v_ThongKe_SinhVien;
GO
CREATE VIEW dbo.v_ThongKe_SinhVien
AS
SELECT COUNT(*) AS SoLuongSV
FROM dbo.SinhVien;
GO
GRANT SELECT ON dbo.v_ThongKe_SinhVien TO [QuanTri];
GO

-- Thống kê tình trạng (số phòng đầy/Trống)
IF OBJECT_ID('dbo.v_ThongKe_TinhTrang', 'V') IS NOT NULL DROP VIEW dbo.v_ThongKe_TinhTrang;
GO
CREATE VIEW dbo.v_ThongKe_TinhTrang
AS
SELECT 
  p.MaKhu, p.MaTang, p.MaPhong,
  CASE WHEN EXISTS (
    SELECT 1 FROM dbo.SinhVien sv
    WHERE sv.MaKhu=p.MaKhu AND sv.MaTang=p.MaTang AND sv.MaPhong=p.MaPhong
  ) THEN N'Đã có SV' ELSE N'Trống' END AS TinhTrang
FROM dbo.Phong p;
GO
GRANT SELECT ON dbo.v_ThongKe_TinhTrang TO [QuanTri];
GO

-- Thống kê doanh thu theo dịch vụ
IF OBJECT_ID('dbo.v_ThongKe_DoanhThu', 'V') IS NOT NULL DROP VIEW dbo.v_ThongKe_DoanhThu;
GO
CREATE VIEW dbo.v_ThongKe_DoanhThu
AS
SELECT 
  hd.MaDV, dv.TenDV,
  SUM((hd.ChiSoCuoi - hd.ChiSoDau) * 1.0) AS TongDichVu
FROM dbo.HoaDon hd
JOIN dbo.DichVu dv ON hd.MaDV=dv.MaDV
GROUP BY hd.MaDV, dv.TenDV;
GO
GRANT SELECT ON dbo.v_ThongKe_DoanhThu TO [QuanTri];
GO

-- Thống kê doanh thu theo phòng
IF OBJECT_ID('dbo.v_ThongKe_DoanhThu_Phong','V') IS NOT NULL
    DROP VIEW dbo.v_ThongKe_DoanhThu_Phong;
GO
CREATE VIEW dbo.v_ThongKe_DoanhThu_Phong AS
SELECT 
    hd.MaKhu, 
    hd.MaTang, 
    hd.MaPhong,
    SUM((hd.ChiSoCuoi - hd.ChiSoDau) * 1.0) AS TongDoanhThu
FROM dbo.HoaDon hd
GROUP BY hd.MaKhu, hd.MaTang, hd.MaPhong;
GO
GRANT SELECT ON dbo.v_ThongKe_DoanhThu_Phong TO [QuanTri];
GO


-- Role NhanVien
--    + Quản lý SinhVien: INSERT, UPDATE, DELETE, SELECT
--    + Quản lý HopDongKTX: INSERT, UPDATE, DELETE, SELECT
--    + Quản lý HoaDon: INSERT, UPDATE, DELETE, SELECT
GRANT INSERT, UPDATE, DELETE, SELECT 
    ON dbo.SinhVien     TO [NhanVien];
GRANT INSERT, UPDATE, DELETE, SELECT 
    ON dbo.HopDongKTX   TO [NhanVien];
GRANT INSERT, UPDATE, DELETE, SELECT 
    ON dbo.HoaDon       TO [NhanVien];
GO

-- Role SinhVien
--    + Chỉ xem thông tin cá nhân, hợp đồng, hóa đơn của chính mình qua VIEW
--    + DENY mọi DML trực tiếp lên 3 bảng trên

-- Xem thông tin cá nhân
IF OBJECT_ID('dbo.v_SV_ThongTin', 'V') IS NOT NULL DROP VIEW dbo.v_SV_ThongTin;
GO
CREATE VIEW dbo.v_SV_ThongTin
AS
SELECT * 
FROM dbo.SinhVien 
WHERE MaSV = SUSER_SNAME();
GO
GRANT SELECT ON dbo.v_SV_ThongTin TO [SinhVien];
GO

-- Xem hợp đồng
IF OBJECT_ID('dbo.v_SV_HopDong', 'V') IS NOT NULL DROP VIEW dbo.v_SV_HopDong;
GO
CREATE VIEW dbo.v_SV_HopDong
AS
SELECT MaHD, NgayApDung, NgayHetHan
FROM dbo.HopDongKTX
WHERE MaSV = SUSER_SNAME();
GO
GRANT SELECT ON dbo.v_SV_HopDong TO [SinhVien];
GO

-- Xem hóa đơn
IF OBJECT_ID('dbo.v_SV_HoaDon', 'V') IS NOT NULL DROP VIEW dbo.v_SV_HoaDon;
GO
CREATE VIEW dbo.v_SV_HoaDon
AS
SELECT hd.MaKhu, hd.MaTang, hd.MaPhong, hd.Thang, hd.Nam, hd.MaDV, hd.ChiSoDau, hd.ChiSoCuoi
FROM dbo.HoaDon hd
JOIN dbo.SinhVien sv
  ON sv.MaKhu=hd.MaKhu AND sv.MaTang=hd.MaTang AND sv.MaPhong=hd.MaPhong
WHERE sv.MaSV = SUSER_SNAME();
GO
GRANT SELECT ON dbo.v_SV_HoaDon TO [SinhVien];
GO

-- Không cho Sinh Viên Thêm Sửa Xóa
DENY INSERT, UPDATE, DELETE 
    ON dbo.SinhVien
    TO [SinhVien];
GO

DENY INSERT, UPDATE, DELETE 
    ON dbo.HopDongKTX 
    TO [SinhVien];
GO

DENY INSERT, UPDATE, DELETE 
    ON dbo.HoaDon 
    TO [SinhVien];
GO

-- Tạo login + user mẫu

-- Quản trị
IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = N'admin1')
BEGIN
    CREATE LOGIN [admin1] WITH PASSWORD = N'Admin@123';
    CREATE USER  [admin1] FOR LOGIN [admin1];
END
EXEC sp_addrolemember N'QuanTri',   N'admin1';
GO

-- Nhân viên
IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = N'nv1')
BEGIN
    CREATE LOGIN [nv1] WITH PASSWORD = N'NV@123';
    CREATE USER  [nv1] FOR LOGIN [nv1];
END
EXEC sp_addrolemember N'NhanVien',  N'nv1';
GO

-- Sinh viên
IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = N'SV000001')
BEGIN
    CREATE LOGIN [SV000001] WITH PASSWORD = N'SV@123';
    CREATE USER  [SV000001] FOR LOGIN [SV000001];
END
EXEC sp_addrolemember N'SinhVien',  N'SV000001';
GO

--HOÀNG
-- Truy vấn đơn giản
--Hiển thị thông tin sinh viên nữ đang ở KTX
SELECT MaSV, HovaTenLot, Ten, NgaySinh, Email
FROM SinhVien
WHERE GioiTinh = N'Nữ';

--Liệt kê các phòng có giá phòng trên 1.5 triệu
SELECT MaKhu, MaTang, MaPhong, GiaPhong, SucChua
FROM Phong
WHERE GiaPhong > 1500000
ORDER BY GiaPhong DESC;

--Hiển thị thông tin các hợp đồng hết hạn trong năm 2024
SELECT MaHD, MaSV, NgayApDung, NgayHetHan
FROM HopDongKTX
WHERE YEAR(NgayHetHan) = 2024;

-- Truy vấn với Aggregate Functions

--Tính tổng số sinh viên trong từng khu
SELECT MaKhu, COUNT(*) as SoLuongSV
FROM SinhVien
GROUP BY MaKhu;

-- Tính giá phòng trung bình theo từng khu
SELECT MaKhu, AVG(GiaPhong) as GiaPhongTrungBinh
FROM Phong
GROUP BY MaKhu;

--Thống kê số lượng phòng theo sức chứa
SELECT SucChua, COUNT(*) as SoLuongPhong
FROM Phong
GROUP BY SucChua
ORDER BY SucChua;

--Tính tổng tiêu thụ điện của từng khu trong tháng 3/2025
SELECT h.MaKhu, SUM(h.ChiSoCuoi - h.ChiSoDau) as TongTieuThuDien
FROM HoaDon h
WHERE h.MaDV = 'DV001' AND h.Thang = 3 AND h.Nam = 2025
GROUP BY h.MaKhu;

--Thống kê số lượng sinh viên theo từng loại ưu tiên
SELECT ut.MoTa, COUNT(sv.MaSV) as SoLuongSV
FROM QuyDinhUuTien ut
LEFT JOIN SinhVien sv ON ut.MaUuTien = sv.MaUuTien
GROUP BY ut.MaUuTien, ut.MoTa;

--Tính tổng số phòng trong mỗi tầng của từng khu
SELECT MaKhu, MaTang, COUNT(*) as SoPhong
FROM Phong
GROUP BY MaKhu, MaTang
ORDER BY MaKhu, MaTang;

--Thống kê số lượng quản lý theo giới tính
SELECT GioiTinh, COUNT(*) as SoLuongQuanLy
FROM QuanLiKTX
GROUP BY GioiTinh;

--Truy vấn với mệnh đề HAVING
--Tìm các khu có trên 3 sinh viên đang ở
SELECT MaKhu, COUNT(*) as SoLuongSV
FROM SinhVien
GROUP BY MaKhu
HAVING COUNT(*) > 3;

--Hiển thị các tầng có tổng giá phòng trên 5 triệu
SELECT MaKhu, MaTang, SUM(GiaPhong) as TongGiaPhong
FROM Phong
GROUP BY MaKhu, MaTang
HAVING SUM(GiaPhong) > 5000000;

--Tìm các phòng có mức tiêu thụ điện trung bình trên 30 đơn vị/tháng
SELECT MaKhu, MaTang, MaPhong, AVG(ChiSoCuoi - ChiSoDau) as TrungBinhTieuThu
FROM HoaDon
WHERE MaDV = 'DV001'
GROUP BY MaKhu, MaTang, MaPhong
HAVING AVG(ChiSoCuoi - ChiSoDau) > 30;

--Hiển thị các khu có ít nhất 2 quản lý
SELECT MaKhu, COUNT(*) as SoLuongQL
FROM QuanLiKTX
GROUP BY MaKhu
HAVING COUNT(*) >= 2;

--Tìm các tầng có nhiều hơn 3 sinh viên có ưu tiên
SELECT MaKhu, MaTang, COUNT(*) as SoSVUuTien
FROM SinhVien
WHERE MaUuTien != 'UT0'
GROUP BY MaKhu, MaTang
HAVING COUNT(*) > 3;

--DUY
--Truy vấn lớn nhất, nhỏ nhất (3 câu)
--Phòng có giá thuê cao nhất
SELECT TOP 1 * 
FROM Phong
ORDER BY GiaPhong DESC;
--Sinh viên lớn tuổi nhất
SELECT * 
FROM SinhVien
WHERE NgaySinh = (SELECT MIN(NgaySinh) FROM SinhVien);
--Tầng có số lượng phòng nhiều nhất
SELECT TOP 1 *
FROM Tang
ORDER BY SLPhong DESC;
--Truy vấn Không/chưa có – sử dụng NOT IN, LEFT JOIN, RIGHT JOIN (5 câu)
--Sinh viên chưa có hợp đồng KTX
SELECT * 
FROM SinhVien 
WHERE MaSV NOT IN (SELECT MaSV FROM HopDongKTX);
--Phòng không có sinh viên nào đang ở
SELECT p.*
FROM Phong p
LEFT JOIN SinhVien sv ON p.MaKhu = sv.MaKhu AND p.MaTang = sv.MaTang AND p.MaPhong = sv.MaPhong
WHERE sv.MaSV IS NULL;
--Quản lý chưa có tài khoản người dùng
SELECT q.*
FROM QuanLiKTX q
LEFT JOIN NguoiDung nd ON q.MaQuanLi = nd.MaQuanLi
WHERE nd.TenDangNhap IS NULL;
--Tìm các phòng chưa có hóa đơn nào được ghi (theo mã khu, tầng, phòng)
SELECT p.*
FROM HoaDon hd
RIGHT JOIN Phong p ON hd.MaKhu = p.MaKhu AND hd.MaTang = p.MaTang AND hd.MaPhong = p.MaPhong
WHERE hd.MaKhu IS NULL;
--Sinh viên không được giảm giá (ưu tiên 0%) UT0
SELECT sv.*
FROM SinhVien sv
JOIN QuyDinhUuTien qd ON sv.MaUuTien = qd.MaUuTien
WHERE qd.PhanTramGiam = 0;
--Truy vấn Hợp/Giao/Trừ (3 câu)
--Hợp (UNION): Sinh viên ở khu K1 hoặc khu K2
SELECT * FROM SinhVien WHERE MaKhu = 'K1'
UNION
SELECT * FROM SinhVien WHERE MaKhu = 'K2';
-- Giao (INTERSECT) Sinh viên có tài khoản người dùng
SELECT MaSV FROM SinhVien
INTERSECT
SELECT MaSV FROM NguoiDung WHERE MaSV IS NOT NULL;
--Trừ (EXCEPT): Sinh viên không ở khu K1
SELECT * FROM SinhVien
EXCEPT
SELECT * FROM SinhVien WHERE MaKhu = 'K1';



--LINH
--1 Cập nhật số điện thoại của quản lý K8
UPDATE QuanLiKTX SET SDT = '0912345679' WHERE MaKhu = 'K8' AND MaQuanLi = 'QL8';
--2 Cập nhật giá phòng của phòng 'K2', tầng 1, phòng 1 lên 1.300.000
UPDATE Phong
SET GiaPhong = 1300000
WHERE MaKhu = 'K2' AND MaTang = 1 AND MaPhong = 1;
--3 Cập nhật GiaPhong của tất cả các phòng trong khu 'K8' có sức chứa dưới 6 người, tăng thêm 5%
UPDATE Phong
SET GiaPhong = GiaPhong * 1.05
WHERE MaKhu = 'K8' AND SucChua < 6;
--4 Cập nhật giá phòng cho các phòng có sức chứa lớn hơn 4 và đang có sinh viên ưu tiên 'UT1' (hoàn cảnh khó khăn) ở, giảm giá phòng đi 15% cho những phòng này.
UPDATE Phong 
SET Phong.GiaPhong = Phong.GiaPhong * 0.85
WHERE Phong.SucChua > 4
  AND EXISTS (
    SELECT 1
    FROM SinhVien SV
    JOIN QuyDinhUuTien QDU ON SV.MaUuTien = QDU.MaUuTien
    WHERE QDU.MaUuTien = 'UT1'
      AND SV.MaKhu = Phong.MaKhu
      AND SV.MaTang = Phong.MaTang
      AND SV.MaPhong = Phong.MaPhong
  );
-- 5 Xóa các quản lý KTX không quản lý bất kỳ khu nào hoặc khu họ quản lý không còn tồn tại trong bảng KHU.
-- Lưu ý: Cần xóa ràng buộc khóa ngoại trong bảng NguoiDung trước.
DELETE FROM NguoiDung
WHERE MaQuanLi IN (
    SELECT QL.MaQuanLi
    FROM QuanLiKTX QL
    LEFT JOIN KHU K ON QL.MaKhu = K.MaKhu
    WHERE K.MaKhu IS NULL
);
DELETE FROM QuanLiKTX
WHERE MaKhu IS NULL OR MaKhu NOT IN (SELECT MaKhu FROM KHU);
--6 Xóa các hóa đơn điện từ năm 2022 trở về trước
DELETE FROM HoaDon
WHERE MaDV = 'DV001' AND Nam <= 2022;
--7 Xóa các sinh viên có ngày sinh trước năm 2000
-- Lưu ý: Cần xóa các bản ghi liên quan trong bảng HopDongKTX và NguoiDung trước
DELETE FROM HopDongKTX
WHERE MaSV IN (SELECT MaSV FROM SinhVien WHERE YEAR(NgaySinh) < 2000);
DELETE FROM NguoiDung
WHERE MaSV IN (SELECT MaSV FROM SinhVien WHERE YEAR(NgaySinh) < 2000);
DELETE FROM SinhVien
WHERE YEAR(NgaySinh) < 2000;
--Thủ tục/Hàm
--1. sp_ThemSinhVien: Thêm sinh viên mới
go
CREATE PROCEDURE sp_ThemSinhVien
    @MaSV VARCHAR(8),
    @MaKhu VARCHAR(2),
    @MaTang TINYINT,
    @MaPhong TINYINT,
    @HovaTenLot NVARCHAR(100),
    @Ten NVARCHAR(20),
    @NgaySinh DATE,
    @GioiTinh NVARCHAR(5),
    @Email VARCHAR(50),
    @DiaChi NVARCHAR(100),
    @MaUuTien VARCHAR(5)
AS
BEGIN
    INSERT INTO SinhVien
    VALUES (@MaSV, @MaKhu, @MaTang, @MaPhong, @HovaTenLot, @Ten, @NgaySinh, @GioiTinh, @Email, @DiaChi, @MaUuTien);
END;
--2. fn_TinhTienPhong: Tính tiền phòng theo mã sinh viên (có ưu tiên)
go
CREATE FUNCTION fn_TinhTienPhong (@MaSV VARCHAR(8))
RETURNS MONEY
AS
BEGIN
    DECLARE @GiaPhong MONEY, @PhanTramGiam TINYINT, @TongTien MONEY;

    SELECT @GiaPhong = GiaPhong
    FROM SinhVien SV
    JOIN Phong P ON SV.MaKhu = P.MaKhu AND SV.MaTang = P.MaTang AND SV.MaPhong = P.MaPhong
    WHERE SV.MaSV = @MaSV;

    SELECT @PhanTramGiam = ISNULL(PhanTramGiam, 0)
    FROM SinhVien SV
    JOIN QuyDinhUuTien QD ON SV.MaUuTien = QD.MaUuTien
    WHERE SV.MaSV = @MaSV;

    SET @TongTien = @GiaPhong * (1 - (@PhanTramGiam * 1.0 / 100));
    RETURN @TongTien;
END;
go
--3. fn_KiemTraPhongDay: Kiểm tra phòng đã đầy chưa (trả về 1 nếu đầy, 0 nếu chưa)
CREATE FUNCTION fn_KiemTraPhongDay (
    @MaKhu VARCHAR(2),
    @MaTang TINYINT,
    @MaPhong TINYINT
)
RETURNS BIT
AS
BEGIN
    DECLARE @SoLuongHienTai INT, @SucChua INT;

    SELECT @SoLuongHienTai = COUNT(*) 
    FROM SinhVien 
    WHERE MaKhu = @MaKhu AND MaTang = @MaTang AND MaPhong = @MaPhong;

    SELECT @SucChua = SucChua 
    FROM Phong 
    WHERE MaKhu = @MaKhu AND MaTang = @MaTang AND MaPhong = @MaPhong;

    IF @SoLuongHienTai >= @SucChua
        RETURN 1;
    RETURN 0;
END;
go
--4. fn_KiemTraHopDongHetHan: Kiểm tra xem một hợp đồng đã hết hạn hay chưa dựa trên ngày hiện tại.
CREATE FUNCTION fn_KiemTraHopDongHetHan
(
    @MaHD VARCHAR(5)
)
RETURNS BIT
AS
BEGIN
    DECLARE @NgayHetHan DATE;
    DECLARE @KetQua BIT;

    SELECT @NgayHetHan = NgayHetHan
    FROM HopDongKTX
    WHERE MaHD = @MaHD;

    IF @NgayHetHan IS NULL
        SET @KetQua = 0; -- hoặc NULL tùy ý
    ELSE IF GETDATE() > @NgayHetHan
        SET @KetQua = 1;
    ELSE
        SET @KetQua = 0;

    RETURN @KetQua;
END;
go

--5. fn_TinhTongTienDienNuoc: Hàm tính tổng tiền điện + nước theo tháng/năm theo phòng
CREATE FUNCTION fn_TongTienDienNuoc_Thang (
    @MaKhu VARCHAR(2),
    @MaTang TINYINT,
    @MaPhong TINYINT,
    @Thang TINYINT,
    @Nam SMALLINT
)
RETURNS INT
AS
BEGIN
    DECLARE @SoKw INT = 0, @SoM3 INT = 0;
    DECLARE @TienDien INT = 0, @TienNuoc INT = 0;
    DECLARE @TongTien INT = 0;

    -- Số điện (kWh) – DV001
    SELECT @SoKw = ISNULL(ChiSoCuoi - ChiSoDau, 0)
    FROM HoaDon
    WHERE MaKhu = @MaKhu AND MaTang = @MaTang AND MaPhong = @MaPhong
      AND Thang = @Thang AND Nam = @Nam AND MaDV = 'DV001';

    -- Số nước (m³) – DV002
SELECT @SoM3 = ISNULL(ChiSoCuoi - ChiSoDau, 0)
    FROM HoaDon
    WHERE MaKhu = @MaKhu AND MaTang = @MaTang AND MaPhong = @MaPhong
      AND Thang = @Thang AND Nam = @Nam AND MaDV = 'DV002';

    -- Tính tiền điện
    IF @SoKw <= 50
        SET @TienDien = @SoKw * 1806;
    ELSE IF @SoKw <= 100
        SET @TienDien = 50 * 1806 + (@SoKw - 50) * 1866;
    ELSE IF @SoKw <= 200
        SET @TienDien = 50 * 1806 + 50 * 1866 + (@SoKw - 100) * 2167;
    ELSE IF @SoKw <= 300
        SET @TienDien = 50 * 1806 + 50 * 1866 + 100 * 2167 + (@SoKw - 200) * 2729;
    ELSE
        SET @TienDien = 50 * 1806 + 50 * 1866 + 100 * 2167 + 100 * 2729 + (@SoKw - 300) * 3000;

    -- Tính tiền nước
    SET @TienNuoc = @SoM3 * 8600;

    -- Tổng tiền
    SET @TongTien = @TienDien + @TienNuoc;

    RETURN @TongTien;
END;
--Trigger 

go
--1. trg_KiemTraSucChua: Ngăn thêm sinh viên nếu phòng đã đầy
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE type = 'TR' AND name = 'trg_KiemTraSucChua')
DROP TRIGGER trg_KiemTraSucChua
GO
CREATE TRIGGER trg_KiemTraSucChua
ON SinhVien
INSTEAD OF INSERT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM INSERTED i
        JOIN (
            SELECT MaKhu, MaTang, MaPhong, COUNT(*) AS SoSV
            FROM SinhVien
            GROUP BY MaKhu, MaTang, MaPhong
        ) s ON i.MaKhu = s.MaKhu AND i.MaTang = s.MaTang AND i.MaPhong = s.MaPhong
        JOIN Phong p ON p.MaKhu = i.MaKhu AND p.MaTang = i.MaTang AND p.MaPhong = i.MaPhong
        WHERE s.SoSV >= p.SucChua
    )
    BEGIN
        RAISERROR(N'Phòng đã đủ sinh viên!', 16, 1);
        ROLLBACK TRANSACTION;
    END
    ELSE
    BEGIN
        INSERT INTO SinhVien
        SELECT * FROM INSERTED;
    END
END;
--2. trg_TaoNguoiDungKhiThemSinhVien: Tạo tài khoản khi thêm sinh viên
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE type = 'TR' AND name = 'trg_TaoNguoiDung')
DROP TRIGGER trg_TaoNguoiDung
go
CREATE TRIGGER trg_TaoNguoiDung
ON SinhVien
AFTER INSERT
AS
BEGIN
    INSERT INTO NguoiDung (TenDangNhap, MatKhau, VaiTro, MaSV)
    SELECT MaSV, '123456', N'Sinh viên', MaSV
    FROM INSERTED;
END;
--3. trg_CapNhatSLPhong: Tự động cập nhật số lượng phòng mỗi tầng khi thêm phòng mới
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE type = 'TR' AND name = 'trg_CapNhatSLPhong')
DROP TRIGGER trg_CapNhatSLPhong
go
CREATE TRIGGER trg_CapNhatSLPhong
ON Phong
AFTER INSERT
AS
BEGIN
    UPDATE Tang
    SET SLPhong = (
        SELECT COUNT(*)
        FROM Phong
        WHERE MaKhu = i.MaKhu AND MaTang = i.MaTang
    )
    FROM Tang t
    JOIN INSERTED i ON t.MaKhu = i.MaKhu AND t.MaTang = i.MaTang;
END;
go
--4. Trigger kiểm tra dữ liệu nhập vào bảng HoaDon:

CREATE TRIGGER trg_KiemTraHoaDon_Insert
ON HoaDon
INSTEAD OF INSERT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted
        WHERE ChiSoCuoi < ChiSoDau
            OR MaDV NOT IN ('DV001', 'DV002')
    )
    BEGIN
        RAISERROR(N'Dữ liệu không hợp lệ: Chi số cuối phải >= chi số đầu, dịch vụ phải là DV001 (điện) hoặc DV002 (nước).', 16, 1);
        ROLLBACK;
        RETURN;
    END;

    -- Nếu dữ liệu hợp lệ thì chèn vào bảng
    INSERT INTO HoaDon (MaKhu, MaTang, MaPhong, Thang, Nam, MaDV, ChiSoDau, ChiSoCuoi)
    SELECT MaKhu, MaTang, MaPhong, Thang, Nam, MaDV, ChiSoDau, ChiSoCuoi
    FROM inserted;
END;


--LỰC
-- h Truy vấn 2 câu sử dụng phép chia
-- Tìm các Khu đã có hóa đơn cho tất cả các dịch vụ trong bảng DichVu
SELECT k.MaKhu
FROM dbo.KHU AS k
WHERE NOT EXISTS (
    SELECT 1 
    FROM dbo.DichVu AS dv
    WHERE NOT EXISTS (
        SELECT 1
        FROM dbo.HoaDon AS hd
        WHERE hd.MaKhu = k.MaKhu
          AND hd.MaDV  = dv.MaDV
    )
);

-- Tìm các Khu mà mọi tầng trong khu đó đều có ít nhất một hóa đơn bất kỳ
SELECT k.MaKhu
FROM dbo.KHU AS k
WHERE NOT EXISTS (
    SELECT 1
    FROM dbo.Tang AS t
    WHERE t.MaKhu = k.MaKhu
      AND NOT EXISTS (
          SELECT 1
          FROM dbo.HoaDon AS hd
          WHERE hd.MaKhu  = t.MaKhu
            AND hd.MaTang = t.MaTang
      )
);

