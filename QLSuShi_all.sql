USE master;
GO
-- Kiểm tra xem cơ sở dữ liệu có tồn tại không
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'QLShiShu')
BEGIN
    -- Ngắt tất cả các kết nối đến cơ sở dữ liệu
    ALTER DATABASE QLShiShu SET SINGLE_USER WITH ROLLBACK IMMEDIATE;

    -- Xóa cơ sở dữ liệu
    DROP DATABASE QLShiShu;
END;

create database QLShiShu
go
use QLShiShu
go
CREATE TABLE [dbo].[BoPhan](
	 MaBoPhan char(10) primary key, 
	[TenBoPhan] [nvarchar](50) NOT NULL unique,
	[Luong] money NOT NULL 
 )
GO
CREATE TABLE [dbo].[ChiNhanh](
	[MaChiNhanh] [char](10) primary key,
	[TenChiNhanh] [nvarchar](50) NOT NULL,
	[ThoiGianMoCua] [time](0) NOT NULL, 
	[ThoiGianDongCua] [time](0) NOT NULL,
	[SoDienThoai] [nvarchar](10) NULL,
	[BaiDoXeMay] [bit] NULL,
	[BaiDoXeHoi] [bit] NULL,
	DiaChi nvarchar(100)  not null,
	MaNhanVienQuanLy char(10) null 
 )
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHoaDon] [char](10) primary key,
	[NgayLap] date NOT NULL,
	[TongTien] money NOT NULL,
	[SoTienGiamGia] money NULL,
	[MaUuDai] [char](10) NULL,
	[MaPhieu] [char](10)NOT NULL,
	[MaChiNhanh] [char](10)NOT NULL
)

GO
CREATE TABLE [dbo].[NhanVien](
	[MaNhanVien] [char](10) primary key,
	[HoTen] [nvarchar](50) NOT NULL,
	[NgaySinh] [date] NULL,
	[GioiTinh] [nvarchar](10) NULL,
	[NgayVaoLam] [date] NOT NULL,
	[NgayKetThuc] [date] NULL,
	[MaBoPhan] [char](10) NOT NULL,
	[MaChiNhanh] [char](10) NOT NULL,
	DiaChi nvarchar(100)  null,
	TaiKhoan nvarchar(50)  not null UNIQUE,
	MatKhau nvarchar(50)  not null
 )

GO
CREATE TABLE [dbo].[PhucVu](
	[MaChiNhanh] [char](10) NOT NULL,
	[MaThucDon] [char](10) NOT NULL,
	primary key ( [MaChiNhanh],[MaThucDon]) 
)

GO

create TABLE [dbo].[PhieuDatMon] (
	[MaPhieu] [char](10) primary key,
	[NgayLap] [date] NULL,
	[LoaiPhieu] [nvarchar](50) NULL,
	[NhanVienLap] [char](10) NULL,
	[MaKhachHang] [char](10)  NULL,
	[MaChiNhanh] [char](10) NOT NULL
)

GO
CREATE TABLE [dbo].[PhieuDatMonTrucTiep](
	[MaPhieu] [char](10) primary key,
	[MaBan] [char](10)NOT NULL,
 )

GO
CREATE TABLE [dbo].[PhieuDatMonTrucTuyen](
	[MaPhieu] [char](10) primary key,
	[ThoiDiemTruyCap] [datetime] NULL,
	[ThoiGianTruyCap] [datetime] NULL,
	[GhiChu] [nvarchar](50) NULL,
	[LoaiDichVu] [nchar](10) NOT NULL
 )



GO
CREATE TABLE [dbo].[PhieuDatMonTrucTuyenGiaoDi](
	[MaPhieu] [char](10) primary key,
	[NgayGio] [datetime] NULL,
	[TinhTrang] [nvarchar](10) not NULL,
	[Phi] [int] NULL,
	DiaChi nvarchar(100) not null,
 )

GO
CREATE TABLE [dbo].[PhieuDatMonTrucTuyenTaiQuan](
	[MaPhieu] [char](10) primary key,
	[SoLuongKhach] int NULL,
	[MaBan] [char](10) NULL,
	[NgayDat] date NULL,
 )

GO
---------*******----------

CREATE TABLE [dbo].[DanhGiaDichVu](
	[ID_DanhGia] int primary key,
	[DiemPhucVu] int NULL,
	[DiemViTriChiNhanh] int NULL,
	[DiemChatLuongMonAn] int NULL,
	[DiemGiaCa]  int,
	[DiemKhongGianNhaHang] int NULL,
	[BinhLuan] [nvarchar](500) NULL,
	[MaKhachHang] [char](10) NOT NULL,
	[MaChiNhanh] [char](10) NOT NULL,
)

GO
CREATE TABLE [dbo].[KhachHang] (
    MaKhachHang CHAR(10) PRIMARY KEY,
    HoTen NVARCHAR(100)  NULL,
    SoDienThoai CHAR(10) NULL,
    Email NCHAR(50) NULL ,
    CCCD CHAR(12) NULL ,
	GioiTinh NVARCHAR(10)  NULL,
	TaiKhoan nvarchar(50)   null ,
	MatKhau nvarchar(50)  null
);

GO
CREATE TABLE [dbo].[LichSuLamViec](
	[MaLS] char(10) primary key,
	[MaNhanVien] [char](10) NOT NULL,
	[MaChiNhanh] [char](10) NOT NULL,
	[NgayBatDau] [date] NOT NULL,
	[NgayKetThuc] [date] NULL,
 )

GO
CREATE TABLE [dbo].[TheKhachHang](
	[MaThe] char(10) primary key,
	[LoaiThe] [varchar](50) NULL,
	[DiemTichLuy] [int] NULL,
	[NgayLap] [date] NOT NULL,
	[MaNhanVienLapThe] [char](10) NOT NULL,
	[MaKhachHang] [char](10) NOT NULL,
)

GO
CREATE TABLE [dbo].[UuDai](
	[MaUuDai] [char](10) primary key,
	[GiamGia] money NULL,
	[ChuongTrinh] [nvarchar](50) NULL,
	[TangSanPham] [nvarchar](100) NULL,
	[UuDaiChietKhau] [float] NULL,
	[LoaiTheApDung] [nvarchar](50) NULL,
	[NgayBatDau] [date] NOT NULL,
	[NgayKetThuc] [date] NOT NULL,
)
go
create table Muc(
	MaMuc char(10) ,
	TenMuc nvarchar(50) not null,
	MaThucDon char(10) not null, 
	primary key (MaMuc)
);

--B?ng MónAn
create table MonAn(
	MaMonAn char(10),
	TenMonAn nvarchar(50) not null,
	GiaTien money not null,
	HoTroGiao bit not null,
	MaMuc char(10) not null , 
	primary key (MaMonAn)

);

--B?ng Th?cÐon
create table ThucDon (
	MaThucDon char(10),
	TenThucDon nvarchar(50) not null,
	KhuVuc nvarchar(50) not null,
	primary key (MaThucDon)
);

--B?ng ChiTi?tPhi?uÐ?t
CREATE TABLE ChiTietPhieuDat (
    MaMonAn CHAR(10) NOT NULL,
    MaPhieu CHAR(10) NOT NULL,
    SoLuong INT NOT NULL,
    Gia money NOT NULL,
    PRIMARY KEY (MaMonAn, MaPhieu),
  
);

-- Ràng bu?c b?ng MonAn
ALTER TABLE MonAn
ADD CONSTRAINT CK_MonAn_GiaTien CHECK (GiaTien >= 0);

ALTER TABLE MonAn
ADD CONSTRAINT CK_MonAn_HoTroGiao CHECK (HoTroGiao IN (0, 1));


alter table ChiTietPhieuDat 
ADD CONSTRAINT CK_ChiTietPhieuDat_SoLuong  CHECK (SoLuong > 0)

alter table ChiTietPhieuDat 
 ADD CONSTRAINT CK_ChiTietPhieuDat_Gia  CHECK (Gia >= 0)
 go 
 GO
ALTER TABLE [dbo].[DanhGiaDichVu]  WITH CHECK ADD CHECK  (([DiemChatLuongMonAn]>=(1) AND [DiemChatLuongMonAn]<=(5)))
GO
ALTER TABLE [dbo].[DanhGiaDichVu]  WITH CHECK ADD CHECK  (([DiemGiaCa]>=(1) AND [DiemGiaCa]<=(5)))
GO
ALTER TABLE [dbo].[DanhGiaDichVu]  WITH CHECK ADD CHECK  (([DiemKhongGianNhaHang]>=(1) AND [DiemKhongGianNhaHang]<=(5)))
GO
ALTER TABLE [dbo].[DanhGiaDichVu]  WITH CHECK ADD CHECK  (([DiemPhucVu]>=(1) AND [DiemPhucVu]<=(5)))
GO
ALTER TABLE [dbo].[DanhGiaDichVu]  WITH CHECK ADD CHECK  (([DiemViTriChiNhanh]>=(1) AND [DiemViTriChiNhanh]<=(5)))

--ràng bu?c giá tr? khách hàng 
GO
ALTER TABLE [dbo].[KhachHang]  WITH CHECK ADD CHECK  ((len([CCCD])=(12) AND NOT [CCCD] like '%[^0-9]%'))
GO
ALTER TABLE [dbo].[KhachHang]  WITH CHECK ADD CHECK  (([Email] like '%@%.%'))
GO
ALTER TABLE [dbo].[KhachHang]  WITH CHECK ADD CHECK  (([GioiTinh]=N'Nữ' OR [GioiTinh]=N'Nam'))
GO
ALTER TABLE [dbo].[KhachHang]  WITH CHECK ADD CHECK  (([SoDienThoai] like '0%' AND len([SoDienThoai])=(10)))


GO
ALTER TABLE [dbo].[TheKhachHang]  WITH CHECK ADD CHECK  (([DiemTichLuy]>=(0)))
GO

GO
ALTER TABLE [dbo].[UuDai]  WITH CHECK ADD CHECK  (([GiamGia]>=(0) AND [GiamGia]<=(100)))
GO
ALTER TABLE [dbo].[UuDai]  WITH CHECK ADD CHECK  (([LoaiTheApDung]='Gold' OR [LoaiTheApDung]='Silver' OR [LoaiTheApDung]='Membership'))
GO
ALTER TABLE [dbo].[UuDai]  WITH CHECK ADD CHECK  (([UuDaiChietKhau]>=(0)))
ALTER TABLE [dbo].[UuDai]


WITH CHECK ADD CONSTRAINT CK_UuDai_NgayBatDau_NgayKetThuc 
CHECK ([NgayBatDau] < [NgayKetThuc]);
GO
ALTER TABLE [dbo].[LichSuLamViec]
WITH CHECK ADD CONSTRAINT CK_LichSuLamViec_NgayBatDau_NgayKetThuc
CHECK ([NgayBatDau] < [NgayKetThuc])
GO


ALTER TABLE PhieuDatMon
ADD CONSTRAINT CK_LoaiPhieu
CHECK (LoaiPhieu IN (N'Trực Tiếp', N'Trực tuyến'));

go 
ALTER TABLE [PhieuDatMonTrucTuyen]
ADD CONSTRAINT CK_LoaiDichVu
CHECK (LoaiDichVu IN (N'Giao di', N'Tại quán'));

GO
ALTER TABLE [dbo].[PhieuDatMonTrucTuyenGiaoDi]  WITH CHECK ADD  CONSTRAINT [CK_PhieuDatMonTrucTuyenGiaoDi] CHECK  (([TinhTrang]=N'Ðã giao' OR [TinhTrang]=N'Chưa Giao'))
GO
ALTER TABLE [dbo].[PhieuDatMonTrucTuyenGiaoDi] CHECK CONSTRAINT [CK_PhieuDatMonTrucTuyenGiaoDi]
GO
ALTER TABLE [dbo].[PhieuDatMonTrucTuyenGiaoDi]  WITH CHECK ADD  CONSTRAINT [CK_PhieuDatMonTrucTuyenGiaoDi_1] CHECK  (([Phi]>=(0)))
GO
ALTER TABLE [dbo].[PhieuDatMonTrucTuyenGiaoDi] CHECK CONSTRAINT [CK_PhieuDatMonTrucTuyenGiaoDi_1]
GO
ALTER TABLE [dbo].[PhieuDatMonTrucTuyenTaiQuan]  WITH CHECK ADD  CONSTRAINT [CK_PhieuDatMonTrucTuyenTaiQuan] CHECK  (([SoLuongKhach]>(0)))
GO
ALTER TABLE [dbo].[PhieuDatMonTrucTuyenTaiQuan] CHECK CONSTRAINT [CK_PhieuDatMonTrucTuyenTaiQuan]

go

ALTER TABLE [dbo].[ChiNhanh] 
WITH CHECK ADD CONSTRAINT CK_ChiNhanh_Info_ThoiGian CHECK ([ThoiGianDongCua] > [ThoiGianMoCua]);

GO
ALTER TABLE [dbo].[HoaDon] 
WITH CHECK ADD CONSTRAINT CK_HoaDon_SoTienGiamGia CHECK ([SoTienGiamGia] <= [TongTien]);


ALTER TABLE [dbo].[HoaDon] 
WITH CHECK ADD CONSTRAINT CK_HoaDon_TongTien CHECK ([TongTien] >= 0);


GO
ALTER TABLE [dbo].[NhanVien] 
WITH CHECK ADD CONSTRAINT CK_NhanVien_Info_GioiTinh CHECK ([GioiTinh] = N'Nữ' OR [GioiTinh] = N'Nam');

GO
ALTER TABLE [dbo].[NhanVien] 
WITH CHECK ADD CONSTRAINT CK_NhanVien_Info_Ngay CHECK ([NgayVaoLam] <= [NgayKetThuc] OR [NgayKetThuc] IS NULL);



----------*----------*---------
-- Ràng bu?c tham chi?u gi?a b?ng Chi nhánh và Nhân viên
ALTER TABLE [dbo].ChiNhanh
ADD CONSTRAINT FK_ChiNhanh_NhanVien FOREIGN KEY (MaNhanVienQuanLy) REFERENCES [dbo].[NhanVien](MaNhanVien);


-- Ràng bu?c tham chi?u gi?a b?ng ThucDon và M?c
ALTER TABLE [dbo].[Muc]
ADD CONSTRAINT FK_Muc_ThucDon FOREIGN KEY (MaThucDon) REFERENCES [dbo].[ThucDon](MaThucDon);

-- Ràng bu?c tham chi?u gi?a b?ng MónAn và M?c
ALTER TABLE [dbo].[MonAn]
ADD CONSTRAINT FK_MonAn_Muc FOREIGN KEY (MaMuc) REFERENCES [dbo].[Muc](MaMuc);


-- Ràng bu?c tham chi?u gi?a b?ng Thêm (Chi Ti?t Phi?u Ð?t) và MónAn, Phi?uÐ?tMon
ALTER TABLE [dbo].[ChiTietPhieuDat]
ADD CONSTRAINT FK_ChiTietPhieuDat_MonAn FOREIGN KEY (MaMonAn) REFERENCES [dbo].[MonAn](MaMonAn),
    CONSTRAINT FK_ChiTietPhieuDat_PhieuDatMon FOREIGN KEY (MaPhieu) REFERENCES [dbo].[PhieuDatMon](MaPhieu);

-- Ràng bu?c tham chi?u gi?a b?ng Phi?uÐ?tMon và NhânViên, KháchHàng, ChiNhánh
ALTER TABLE [dbo].[PhieuDatMon]
ADD CONSTRAINT FK_PhieuDatMon_NhanVien FOREIGN KEY (NhanVienLap) REFERENCES [dbo].[NhanVien](MaNhanVien),
    CONSTRAINT FK_PhieuDatMon_KhachHang FOREIGN KEY (MaKhachHang) REFERENCES [dbo].[KhachHang](MaKhachHang),
	 CONSTRAINT FK_PhieuDatMon_ChiNhanh FOREIGN KEY (MaChiNhanh) REFERENCES [dbo].ChiNhanh(MaChiNhanh)

-- Ràng bu?c tham chi?u gi?a b?ng NhânViên và B?Ph?n, ChiNhánh
ALTER TABLE [dbo].[NhanVien]
ADD CONSTRAINT FK_NhanVien_BoPhan FOREIGN KEY (MaBoPhan) REFERENCES [dbo].[BoPhan](MaBoPhan),
    CONSTRAINT FK_NhanVien_ChiNhanh FOREIGN KEY (MaChiNhanh) REFERENCES [dbo].[ChiNhanh](MaChiNhanh);

-- Ràng bu?c tham chi?u gi?a b?ng Ph?cV? và ChiNhánh, Th?cÐon
ALTER TABLE [dbo].[PhucVu]
ADD CONSTRAINT FK_PhucVu_ChiNhanh FOREIGN KEY (MaChiNhanh) REFERENCES [dbo].[ChiNhanh](MaChiNhanh),
    CONSTRAINT FK_PhucVu_ThucDon FOREIGN KEY (MaThucDon) REFERENCES [dbo].ThucDon(MaThucDon);

-- Ràng bu?c tham chi?u gi?a b?ng HóaÐon và UuÐãi, Phi?uÐ?tMon, ChiNhánh, nhân Viên in
ALTER TABLE [dbo].[HoaDon]
ADD CONSTRAINT FK_HoaDon_UuDai FOREIGN KEY (MaUuDai) REFERENCES [dbo].[UuDai](MaUuDai),
    CONSTRAINT FK_HoaDon_Phieu FOREIGN KEY (MaPhieu) REFERENCES [dbo].[PhieuDatMon](MaPhieu),
	CONSTRAINT FK_HoaDon_ChiNhanh FOREIGN KEY (MaChiNhanh) REFERENCES [dbo].[ChiNhanh](MaChiNhanh)
-- Ràng bu?c tham chi?u gi?a b?ng ÐánhGiáD?chV? và KháchHàng, ChiNhánh
ALTER TABLE [dbo].[DanhGiaDichVu]
ADD CONSTRAINT FK_DanhGiaDichVu_KhachHang FOREIGN KEY (MaKhachHang) REFERENCES [dbo].[KhachHang](MaKhachHang),
    CONSTRAINT FK_DanhGiaDichVu_ChiNhanh FOREIGN KEY (MaChiNhanh) REFERENCES [dbo].[ChiNhanh](MaChiNhanh);

-- Ràng bu?c tham chi?u gi?a b?ng Th?KháchHàng và NhânViên, KháchHàng
ALTER TABLE [dbo].[TheKhachHang]
ADD CONSTRAINT FK_TheKhachHang_NhanVien FOREIGN KEY (MaNhanVienLapThe) REFERENCES [dbo].[NhanVien](MaNhanVien),
    CONSTRAINT FK_TheKhachHang_KhachHang FOREIGN KEY (MaKhachHang) REFERENCES [dbo].[KhachHang](MaKhachHang);

-- Ràng bu?c tham chi?u gi?a b?ng L?chS?LàmVi?c và NhânViên, ChiNhánh
ALTER TABLE [dbo].[LichSuLamViec]
ADD CONSTRAINT FK_LichSuLamViec_NhanVien FOREIGN KEY (MaNhanVien) REFERENCES [dbo].[NhanVien](MaNhanVien),
    CONSTRAINT FK_LichSuLamViec_ChiNhanh FOREIGN KEY (MaChiNhanh) REFERENCES [dbo].[ChiNhanh](MaChiNhanh);


ALTER TABLE [dbo].[PhieuDatMonTrucTuyenGiaoDi]
ADD CONSTRAINT FK_PhieuDatMonTrucTuyenGiaoDi_MaPhieu
FOREIGN KEY (MaPhieu) REFERENCES [dbo].[PhieuDatMonTrucTuyen](MaPhieu);

ALTER TABLE [dbo].[PhieuDatMonTrucTuyenTaiQuan]
ADD CONSTRAINT FK_PhieuDatMonTrucTuyenTaiQuan_MaPhieu
FOREIGN KEY (MaPhieu) REFERENCES [dbo].[PhieuDatMonTrucTuyen](MaPhieu);

ALTER TABLE [dbo].[PhieuDatMonTrucTiep]
ADD CONSTRAINT FK_PhieuDatMonTrucTiep_MaPhieu
FOREIGN KEY (MaPhieu) REFERENCES [dbo].PhieuDatMon(MaPhieu);

ALTER TABLE [dbo].[PhieuDatMonTrucTuyen]
ADD CONSTRAINT FK_PhieuDatMonTrucTuyen_MaPhieu
FOREIGN KEY (MaPhieu) REFERENCES [dbo].PhieuDatMon(MaPhieu);

-- Vô hiệu hóa ràng buộc khóa ngoại
ALTER TABLE ChiNhanh NOCHECK CONSTRAINT ALL;
ALTER TABLE NhanVien NOCHECK CONSTRAINT ALL;
ALTER TABLE BoPhan NOCHECK CONSTRAINT ALL;
ALTER TABLE ThucDon NOCHECK CONSTRAINT ALL;
ALTER TABLE Muc NOCHECK CONSTRAINT ALL;
ALTER TABLE MonAn NOCHECK CONSTRAINT ALL;
ALTER TABLE PhieuDatMon NOCHECK CONSTRAINT ALL;
ALTER TABLE ChiTietPhieuDat NOCHECK CONSTRAINT ALL;
ALTER TABLE DanhGiaDichVu NOCHECK CONSTRAINT ALL;
ALTER TABLE PhieuDatMonTrucTuyen NOCHECK CONSTRAINT ALL;
ALTER TABLE PhieuDatMonTrucTiep NOCHECK CONSTRAINT ALL;
ALTER TABLE UuDai NOCHECK CONSTRAINT ALL;
ALTER TABLE KhachHang NOCHECK CONSTRAINT ALL;

GO
-- Xóa toàn bộ dữ liệu trong các bảng trước khi chèn dữ liệu mới
DELETE FROM ChiTietPhieuDat;
DELETE FROM DanhGiaDichVu;
DELETE FROM PhieuDatMonTrucTuyen;
DELETE FROM PhieuDatMonTrucTiep;
DELETE FROM PhieuDatMon;
DELETE FROM MonAn;
DELETE FROM Muc;
DELETE FROM ThucDon;
DELETE FROM NhanVien;
DELETE FROM BoPhan;
DELETE FROM ChiNhanh;
DELETE FROM  UuDai ;

go

-- Thêm dữ liệu mới vào bảng ChiNhanh
INSERT INTO ChiNhanh (MaChiNhanh, TenChiNhanh, ThoiGianMoCua, ThoiGianDongCua, SoDienThoai, BaiDoXeMay, BaiDoXeHoi, DiaChi, MaNhanVienQuanLy) 
VALUES
('CN01', N'Chi nhánh A', '08:00', '22:00', '0901112233', 1, 1, N'Số 12, đường ABC, Quận 1', 'NV001'),
('CN02', N'Chi nhánh B', '08:30', '23:00', '0902223344', 1, 0, N'Số 34, đường XYZ, Quận 2', 'NV002');

GO

-- Thêm dữ liệu vào bảng BoPhan
INSERT INTO BoPhan (MaBoPhan, TenBoPhan, Luong)
VALUES
('BP01', N'Bộ phận Lễ tân', 10000000),
('BP02', N'Bộ phận Bếp', 15000000),
('BP03', N'Bộ phận Phục vụ', 12000000),
('BP04', N'Bộ phận Quản lý', 20000000);

GO

-- Thêm dữ liệu vào bảng NhanVien
INSERT INTO NhanVien (MaNhanVien, HoTen, NgaySinh, GioiTinh, NgayVaoLam, NgayKetThuc, MaBoPhan, MaChiNhanh, DiaChi, TaiKhoan, MatKhau) 
VALUES
('NV001', N'Nguyễn Văn A', '1990-01-01', 'Nam', '2015-05-01', NULL, 'BP01', 'CN01', N'Số 12, đường ABC', 'nguyenvana', 'password123'),
('NV002', N'Trần Thị B', '1992-02-15', N'Nữ', '2017-06-01', NULL, 'BP02', 'CN02', N'Số 34, đường XYZ', 'tranthib', 'password456'),
('NV003', N'Trần Thị c', '1992-02-15', N'Nữ', '2017-06-01', NULL, 'BP02', 'CN02', N'Số 34, đường XYZ', 'tranthic', 'password456');


GO

-- Thêm dữ liệu vào bảng ThucDon
INSERT INTO ThucDon (MaThucDon, TenThucDon, KhuVuc)
VALUES
('TD01', N'Thực đơn trưa', N'Khu vực A'),
('TD02', N'Thực đơn tối', N'Khu vực B');

GO

-- Thêm dữ liệu vào bảng Muc
INSERT INTO Muc (MaMuc, TenMuc, MaThucDon)
VALUES
('M01', N'Món chính', 'TD01'),
('M02', N'Món khai vị', 'TD02');

GO

-- Thêm dữ liệu vào bảng MonAn
INSERT INTO MonAn (MaMonAn, TenMonAn, GiaTien, HoTroGiao, MaMuc)
VALUES
('MA01', N'Cơm tấm', 50000, 1, 'M01'),
('MA02', N'Gà xối mỡ', 70000, 1, 'M01'),
('MA03', N'Gỏi cuốn', 30000, 1, 'M02');

GO

-- Thêm dữ liệu vào bảng KhachHang
INSERT INTO KhachHang (MaKhachHang, HoTen, SoDienThoai, Email, CCCD, GioiTinh, TaiKhoan, MatKhau)
VALUES
('KH01', N'Nguyễn Văn C', '0901234567', 'nguyenvanc@gmail.com', '123456789012', 'Nam', 'nguyenvanc', 'password789'),
('KH02', N'Trần Thị D', '0902345678', 'tranthid@gmail.com', '234567890123', N'Nữ', 'tranthid', 'password101');


GO
-- Thêm dữ liệu vào bảng KhachHang
INSERT INTO TheKhachHang (MaThe, LoaiThe, DiemTichLuy, NgayLap, MaNhanVienLapThe, MaKhachHang)
VALUES
('TH001', 'Gold', 150, '2023-01-15', 'NV001', 'KH01'),
('TH002', 'Silver', 80, '2023-02-20', 'NV002', 'KH02'),
('TH003', 'Membership', 30, '2023-03-05', 'NV001', 'KH01'),
('TH004', 'Gold', 200, '2023-04-10', 'NV003', 'KH02'),
('TH005', 'Silver', 120, '2023-05-25', 'NV002', 'KH01');
GO
-- Thêm dữ liệu vào bảng PhieuDatMon
INSERT INTO PhieuDatMon (MaPhieu, NgayLap, LoaiPhieu, NhanVienLap, MaKhachHang, MaChiNhanh)
VALUES
('PD01', '2024-12-15',N'Trực tuyến', 'NV001', 'KH01', 'CN01'),
('PD02', '2024-12-15', N'Trực tiếp', 'NV002', 'KH02', 'CN02');

GO

-- Thêm dữ liệu vào bảng ChiTietPhieuDat
INSERT INTO ChiTietPhieuDat (MaMonAn, MaPhieu, SoLuong, Gia)
VALUES
('MA01', 'PD01', 2, 50000),
('MA02', 'PD01', 1, 70000),
('MA03', 'PD02', 3, 30000);

GO

-- Thêm dữ liệu vào bảng DanhGiaDichVu
INSERT INTO DanhGiaDichVu (ID_DanhGia, DiemPhucVu, DiemViTriChiNhanh, DiemChatLuongMonAn, DiemGiaCa, DiemKhongGianNhaHang, BinhLuan, MaKhachHang, MaChiNhanh)
VALUES
(1, 5, 4, 5, 4, 5, N'Dịch vụ tuyệt vời!', 'KH01', 'CN01'),
(2, 4, 3, 4, 3, 4, N'Món ăn ngon nhưng không gian cần cải thiện', 'KH02', 'CN02');

GO

-- Thêm dữ liệu vào bảng UuDai
INSERT INTO UuDai (MaUuDai, GiamGia, ChuongTrinh, TangSanPham, UuDaiChietKhau, LoaiTheApDung, NgayBatDau, NgayKetThuc)
VALUES
('UD01', 50000, N'Giảm giá 50% cho khách hàng mới', N'Cơm tấm', 10, N'Membership', '2024-12-01', '2024-12-31'),
('UD02', 20000, N'Giảm giá 50% cho khách hàng mới', N'Cơm tấm', 10, N'Membership', '2024-12-01', '2024-12-31'),
('UD03', 130000, N'Giảm giá 50% cho khách hàng mới', N'Cơm tấm', 10, N'Silver', '2024-12-01', '2024-12-31'),
('UD04', 130000, N'Giảm giá 50% cho khách hàng mới', N'Cơm tấm', 10, N'Gold', '2024-12-01', '2024-12-31')


GO

-- Thêm dữ liệu vào bảng PhieuDatMonTrucTiep
INSERT INTO PhieuDatMonTrucTiep (MaPhieu, MaBan)
VALUES
('PD01', 'B01'),
('PD02', 'B02');

GO

  INSERT INTO [QLShiShu].[dbo].[PhucVu] ([MaChiNhanh], [MaThucDon])
VALUES 
    ('CN01', 'TD01'), -- Chi nhánh 01 phục vụ Thực đơn 001
    ('CN01', 'TD02'), -- Chi nhánh 01 phục vụ Thực đơn 002
    ('CN02', 'TD01'), -- Chi nhánh 02 phục vụ Thực đơn 003
    ('CN02', 'TD02') -- Chi nhánh 02 phục vụ Thực đơn 004
   
go

-- Thêm dữ liệu vào bảng PhieuDatMonTrucTuyen
INSERT INTO PhieuDatMonTrucTuyen (MaPhieu, ThoiDiemTruyCap, ThoiGianTruyCap, GhiChu, LoaiDichVu)
VALUES
('PD01', '2024-12-15 10:00', '2024-12-15 10:30', N'Đặt online', N'Giao đi'),
('PD02', '2024-12-15 11:00', '2024-12-15 11:15', N'Đặt qua app', N'Tại quán');

go
-- Kích hoạt lại ràng buộc khóa ngoại
ALTER TABLE ChiNhanh CHECK CONSTRAINT ALL;
ALTER TABLE NhanVien CHECK CONSTRAINT ALL;
ALTER TABLE BoPhan CHECK CONSTRAINT ALL;
ALTER TABLE ThucDon CHECK CONSTRAINT ALL;
ALTER TABLE Muc CHECK CONSTRAINT ALL;
ALTER TABLE MonAn CHECK CONSTRAINT ALL;
ALTER TABLE PhieuDatMon CHECK CONSTRAINT ALL;
ALTER TABLE ChiTietPhieuDat CHECK CONSTRAINT ALL;
ALTER TABLE DanhGiaDichVu CHECK CONSTRAINT ALL


----------1
go
CREATE PROCEDURE sp_XoaMonAnTheoMaPhieu
    @MaMonAn CHAR(10),  -- tham số mã món ăn
    @MaPhieu CHAR(10)   -- tham số mã phiếu
AS
BEGIN
    -- Xóa chi tiết phiếu đặt món ăn theo mã món và mã phiếu
    DELETE FROM Chitietphieudat
    WHERE MaMonAn = @MaMonAn
      AND MaPhieu = @MaPhieu;

    PRINT 'Chi tiết món ăn đã được xóa thành công.';
END;
go
---------------2
create PROCEDURE sp_AddOrUpdateChiTietPhieu
    @id_phieu CHAR(10),
    @id_mon_an CHAR(10),
    @so_luong INT
AS
BEGIN

    -- Tính giá
    DECLARE @gia MONEY;
    SELECT @gia = CAST(@so_luong * GiaTien AS MONEY)
    FROM MonAn
    WHERE MaMonAn = @id_mon_an;

    -- Kiểm tra xem món ăn đã tồn tại trong phiếu đặt hay chưa
    IF EXISTS (SELECT 1 
               FROM ChiTietPhieuDat 
               WHERE MaPhieu = @id_phieu AND MaMonAn = @id_mon_an)
    BEGIN
        -- Nếu tồn tại, cập nhật số lượng và giá
        UPDATE ChiTietPhieuDat
        SET SoLuong = SoLuong + @so_luong,
            Gia = SoLuong * @gia
        WHERE MaPhieu = @id_phieu AND MaMonAn = @id_mon_an;

    END
    ELSE
    BEGIN
        -- Nếu không tồn tại, thêm mới
        INSERT INTO ChiTietPhieuDat (MaPhieu, MaMonAn, SoLuong, Gia)
        VALUES (@id_phieu, @id_mon_an, @so_luong, @gia);

    END
END;
go
-----------------3

CREATE PROCEDURE sp_GetMonAn
    @MaThucDon CHAR(10) = NULL,
    @MaMuc CHAR(10) = NULL,
    @MaMonAn CHAR(10) = NULL,
    @MaChiNhanh CHAR(10) = NULL
AS
BEGIN

    -- Truy vấn dữ liệu
    SELECT DISTINCT MonAn.*
    FROM MonAn
    INNER JOIN Muc ON MonAn.MaMuc = Muc.MaMuc
    INNER JOIN ThucDon ON Muc.MaThucDon = ThucDon.MaThucDon
    INNER JOIN PhucVu ON ThucDon.MaThucDon = PhucVu.MaThucDon
    WHERE (@MaMonAn IS NULL OR MonAn.MaMonAn = @MaMonAn)
      AND (@MaMuc IS NULL OR MonAn.MaMuc = @MaMuc)
      AND (@MaThucDon IS NULL OR ThucDon.MaThucDon = @MaThucDon)
      AND (@MaChiNhanh IS NULL OR PhucVu.MaChiNhanh = @MaChiNhanh);
END;

go
--------------------------4
create PROCEDURE sp_GetMonAnDaBanFromTo
    @FromDate DATETIME,
    @ToDate DATETIME,
    @MaChiNhanh CHAR(10),
    @TenMonAn NVARCHAR(255) = NULL
AS
BEGIN
    DECLARE @sql VARCHAR(MAX);
    
    -- Xây dựng câu lệnh SQL
    SELECT DISTINCT 
        MA.MaMonAn, 
        MA.TenMonAn, 
        (
            SELECT COUNT(*)
            FROM ChiTietPhieuDat AS ctpdtemp
            INNER JOIN HoaDon hdtemp ON hdtemp.MaPhieu = ctpdtemp.MaPhieu
            INNER JOIN MonAn matemp ON matemp.MaMonAn = ctpdtemp.MaMonAn
            WHERE 
                hdtemp.NgayLap BETWEEN @FromDate AND @ToDate
                AND hdtemp.MaChiNhanh = @MaChiNhanh
                AND matemp.MaMonAn = MA.MaMonAn 
        ) AS SoLuong,
        m.tenmuc AS TenMuc,
        td.tenthucdon AS TenThucDon
    FROM 
        HoaDon HD
        INNER JOIN ChiTietPhieuDat CT ON HD.MaPhieu = CT.MaPhieu
        INNER JOIN MonAn MA ON CT.MaMonAn = MA.MaMonAn
        INNER JOIN Muc m ON m.Mamuc = MA.MaMuc
        INNER JOIN thucdon td ON td.mathucdon = m.Mathucdon
    WHERE 
        HD.NgayLap BETWEEN @FromDate AND @ToDate
        AND HD.MaChiNhanh = @MaChiNhanh
		and @TenMonAn is null or MA.TenMonAn LIKE @TenMonAn
    
END
go
------------------5
create procedure sp_getBoPhan 
	@MaBoPhan char(10)
AS 
begin 
	select *
	from BoPhan 
	where @MaBoPhan IS NULL OR @MaBoPhan = BoPhan.mabophan
end
go

-----------6
create FUNCTION dbo.fn_GetNextHoaDon()
RETURNS CHAR(10)
AS
BEGIN
    DECLARE @MaxNum INT;
    DECLARE @NewHoaDon CHAR(10);

    -- Lấy giá trị lớn nhất của phần số trong mã hóa đơn
    SELECT 
        @MaxNum = MAX(CAST(SUBSTRING(MaHoaDon, 3, LEN(MaHoaDon) - 2) AS INT))
    FROM HoaDon
    WHERE MaHoaDon LIKE 'HD%';

    -- Nếu có mã hóa đơn, tạo mã hóa đơn mới, nếu không khởi tạo HD001
    IF @MaxNum IS NOT NULL
        SET @NewHoaDon = 'HD' + CAST(@MaxNum + 1 AS CHAR);
    ELSE
        SET @NewHoaDon = 'HD001';

    RETURN @NewHoaDon;
END;
go

------------------------7

create PROCEDURE sp_GetHoaDonFromTo
    @FromDate DATETIME,
    @ToDate DATETIME,
    @MaChiNhanh CHAR(10)
AS
BEGIN
    SELECT 
       *
    FROM HoaDon
    WHERE NgayLap BETWEEN @FromDate AND @ToDate
      AND MaChiNhanh = @MaChiNhanh;
END;
go

-----------------8
create procedure sp_getMuc
	@mathucdon char(10) , 
	@mamuc char(10) 
as
begin 
	SELECT *
	FROM Muc 
	WHERE @mathucdon is null or MaThucDon = @mathucdon
	and @mamuc is null or MaMuc = @mamuc
end 
go

--------------9

create PROCEDURE sp_GetThucDon
    @MaChiNhanh CHAR(10)
AS
BEGIN
    SELECT distinct td.*
    FROM ThucDon td
    INNER JOIN PhucVu dv ON td.MaThucDon = dv.MaThucDon
    WHERE @MaChiNhanh is null or  dv.MaChiNhanh = @MaChiNhanh;
END;

go

-----------------10

create FUNCTION dbo.fn_GetNextPhieuDatMon()
RETURNS CHAR(10)
AS
BEGIN
    DECLARE @MaxNum INT;
    DECLARE @NextPhieu CHAR(10);

    -- Lấy giá trị lớn nhất của phần số trong MaPhieu
    SELECT @MaxNum= MAX(CAST(SUBSTRING(MaPhieu, 3, LEN(MaPhieu)-2) AS INT))
    FROM PhieuDatMon
    WHERE MaPhieu LIKE 'PD%';

    IF @MaxNum IS NOT NULL
        SET @NextPhieu = 'PD' +CAST(@MaxNum + 1 AS CHAR);
    ELSE
        SET @NextPhieu = 'PD001';

    RETURN @NextPhieu;
END;
go
---------------------11

CREATE PROCEDURE dbo.sp_CreatePhieuDatMon
    @MaPhieu CHAR(10),
    @NhanVienLap CHAR(10) = NULL,
    @MaChiNhanh CHAR(10),
    @MaKhachhang CHAR(10) = NULL,
    @LoaiPhieu NVARCHAR(50) = N'Trực Tiếp' -- Thêm tham số @LoaiPhieu
AS
BEGIN
    DECLARE @NgayLap DATETIME = GETDATE(); 

    -- Thực hiện câu lệnh INSERT
    INSERT INTO PhieuDatMon (MaPhieu, NhanVienLap, NgayLap, MaChiNhanh, LoaiPhieu, MaKhachhang)
    VALUES (@MaPhieu, @NhanVienLap, @NgayLap, @MaChiNhanh, @LoaiPhieu, @MaKhachhang);
    
    SELECT 'Phieu Dat Mon Created Successfully' AS Status;
END;
go

--------------12
CREATE PROCEDURE dbo.sp_AddHoaDon
    @MaHoaDon CHAR(10),
    @TongTien DECIMAL,
    @SoTienGiamGia DECIMAL = NULL,
    @MaUuDai CHAR(10) = NULL,
    @MaPhieu CHAR(10),
    @MaChiNhanh CHAR(10)
AS
BEGIN
    DECLARE @NgayLap DATETIME = GETDATE();  -- Lấy thời gian hiện tại
    
    -- Chèn dữ liệu vào bảng HoaDon
    INSERT INTO HoaDon (MaHoaDon, NgayLap, TongTien, SoTienGiamGia, MaUuDai, MaPhieu, MaChiNhanh)
    VALUES (@MaHoaDon, @NgayLap, @TongTien, @SoTienGiamGia, @MaUuDai, @MaPhieu, @MaChiNhanh);
    
    -- Trả về thông báo thành công
    SELECT 'Hoa Don Created Successfully' AS Status;
END;
go

-----------------13
CREATE PROCEDURE dbo.sp_CreatePhieuDatMonTrucTuyen
    @MaPhieu CHAR(50),
    @ThoiDiemTruyCap DATETIME,
    @ThoiGianTruyCap DATETIME = NULL,
    @GhiChu NVARCHAR(MAX) = NULL,
    @LoaiDichVu NVARCHAR(50) = NULL
AS
BEGIN
    -- Chèn dữ liệu vào bảng PhieuDatMonTrucTuyen
    INSERT INTO PhieuDatMonTrucTuyen (MaPhieu, ThoiDiemTruyCap, ThoiGianTruyCap, GhiChu, LoaiDichVu)
    VALUES (@MaPhieu, @ThoiDiemTruyCap, @ThoiGianTruyCap, @GhiChu, @LoaiDichVu);

    -- Trả về kết quả thành công
    SELECT 'Phieu Dat Mon Truc Tuyen Created Successfully' AS Status;
END;
go

-------------------------14

create PROCEDURE sp_UpdateCardStatus
    @MaKhachHang CHAR(10)
AS
BEGIN
    DECLARE @TongTienMuaHang MONEY;
    DECLARE @DiemTichLuy INT;
    DECLARE @LoaiThe NVARCHAR(50);
    DECLARE @NgayLap DATE;
    DECLARE @DiemMoi INT;

    -- Kiểm tra khách hàng có tồn tại không
    IF NOT EXISTS (
        SELECT 1 
        FROM KhachHang 
        JOIN TheKhachHang ON KhachHang.MaKhachHang = TheKhachHang.MaKhachHang 
        WHERE KhachHang.MaKhachHang = @MaKhachHang
    )
    BEGIN
        RETURN;
    END

    -- Lấy tổng giá trị tiêu dùng tích lũy của khách hàng trong vòng 1 năm
    SELECT @TongTienMuaHang = SUM(CT.Gia * CT.SoLuong)
    FROM HoaDon HD
    JOIN ChiTietPhieuDat CT ON HD.MaPhieu = CT.MaPhieu
    JOIN PhieuDatMon PD ON PD.MaPhieu = CT.MaPhieu
    WHERE PD.MaKhachHang = @MaKhachHang
    AND HD.NgayLap >= DATEADD(YEAR, -1, GETDATE());

    -- Lấy điểm tích lũy và loại thẻ hiện tại của khách hàng
    SELECT @DiemTichLuy = DiemTichLuy, @LoaiThe = LoaiThe, @NgayLap = NgayLap
    FROM TheKhachHang
    WHERE MaKhachHang = @MaKhachHang;

    -- Nếu thông tin thẻ hiện tại không tồn tại
    IF @LoaiThe IS NULL RETURN;

    -- Tính số điểm mới tích lũy
    SET @DiemMoi = FLOOR(@TongTienMuaHang / 100000);

    -- Cộng dồn điểm vào thẻ khách hàng
    UPDATE TheKhachHang
    SET DiemTichLuy = ISNULL(DiemTichLuy, 0) + @DiemMoi
    WHERE MaKhachHang = @MaKhachHang;

    -- Kiểm tra điều kiện đạt hạng SILVER hoặc GOLD
    IF (@TongTienMuaHang >= 10000000 AND @NgayLap IS NOT NULL AND DATEDIFF(YEAR, @NgayLap, GETDATE()) >= 1) -- Đạt thẻ SILVER hoặc GOLD
    BEGIN
        IF (@LoaiThe = 'Silver' )
        BEGIN
            -- Nâng hạng lên GOLD
            UPDATE TheKhachHang
            SET LoaiThe = 'Gold'
            WHERE MaKhachHang = @MaKhachHang;
        END
        ELSE IF (@LoaiThe = 'Gold')
        BEGIN
            -- Giữ hạng GOLD
            return; 
        END
    END
    ELSE IF (@TongTienMuaHang < 5000000 AND @NgayLap IS NOT NULL AND DATEDIFF(YEAR, @NgayLap, GETDATE()) <= 1)
    BEGIN
		IF (@LoaiThe = 'Silver')
        BEGIN
           -- Hạ hạng xuống Membership
			UPDATE TheKhachHang
			SET LoaiThe = 'Membership', DiemTichLuy = 0
			WHERE MaKhachHang = @MaKhachHang;
        END
        ELSE IF (@LoaiThe = 'Gold' )
        BEGIN
            -- Hạ hạng xuống SILVER
			UPDATE TheKhachHang
			SET LoaiThe = 'Silver', DiemTichLuy = 0
			WHERE MaKhachHang = @MaKhachHang;
        END

       
    END
END;

go

----------------15
CREATE PROCEDURE sp_CreateKhachHang
    @MaKhachHang CHAR(10),  
    @HoTen NVARCHAR(100),
    @SoDienThoai CHAR(10),
    @Email NCHAR(50),
    @CCCD CHAR(12),
    @GioiTinh NVARCHAR(10),
    @TaiKhoan NVARCHAR(50),
    @MatKhau NVARCHAR(50)
AS
BEGIN
    -- Chèn dữ liệu vào bảng KhachHang
    INSERT INTO KhachHang (MaKhachHang, HoTen, SoDienThoai, Email, CCCD, GioiTinh, TaiKhoan, MatKhau)
    VALUES (@MaKhachHang, @HoTen, @SoDienThoai, @Email, @CCCD, @GioiTinh, @TaiKhoan, @MatKhau);
    SELECT 'Khach Hang Created Successfully' AS Status;
END;
go

--------------------16

create FUNCTION dbo.fn_GetNextKhachHang()
RETURNS CHAR(10)
AS
BEGIN
    DECLARE @MaxNum INT;
    DECLARE @NextPhieu CHAR(10);

    -- Lấy giá trị lớn nhất của phần số trong MaPhieu
    SELECT @MaxNum= MAX(CAST(SUBSTRING(Makhachhang, 3, LEN(Makhachhang)-2) AS INT))
    FROM KhachHang
    WHERE Makhachhang LIKE 'KH%';

    IF @MaxNum IS NOT NULL
        SET @NextPhieu = 'KH' +CAST(@MaxNum + 1 AS CHAR);
    ELSE
        SET @NextPhieu = 'KH001';

    RETURN @NextPhieu;
END;
go

-----------------17
create FUNCTION dbo.fn_GetNextTheKhachHang()
RETURNS CHAR(10)
AS
BEGIN
    DECLARE @MaxNum INT;
    DECLARE @NextPhieu CHAR(10);

    -- Lấy giá trị lớn nhất của phần số trong MaPhieu
    SELECT @MaxNum= MAX(CAST(SUBSTRING(MaThe, 3, LEN(MaThe)-2) AS INT))
    FROM TheKhachHang
    WHERE MaThe LIKE 'MT%';

    IF @MaxNum IS NOT NULL
        SET @NextPhieu = 'MT' +CAST(@MaxNum + 1 AS CHAR);
    ELSE
        SET @NextPhieu = 'MT001';

    RETURN @NextPhieu;
END;
go
------------------------18
create PROCEDURE sp_CreateTheKhachHang
    @MaThe CHAR(10),
    @MaNhanVien CHAR(10),
    @MaKhachHang CHAR(10)
AS
BEGIN
    -- Khai báo giá trị cố định
    DECLARE @LoaiThe NVARCHAR(50) = 'Membership';
    DECLARE @DiemTichLuy INT = 0;
    DECLARE @NgayLap DATE = GETDATE();

    -- Kiểm tra mã khách hàng và mã nhân viên có tồn tại không
    IF NOT EXISTS (SELECT 1 FROM KhachHang WHERE MaKhachHang = @MaKhachHang)
    BEGIN
        RAISERROR(N'Khách hàng không tồn tại.', 16, 1);
        RETURN;
    END

    IF NOT EXISTS (SELECT 1 FROM NhanVien WHERE MaNhanVien = @MaNhanVien)
    BEGIN
        RAISERROR(N'Nhân viên không tồn tại.', 16, 1);
        RETURN;
    END

    -- Thêm mới thẻ khách hàng
    INSERT INTO TheKhachHang (MaThe, LoaiThe, DiemTichLuy, NgayLap, MaNhanVienLapThe, MaKhachHang)
    VALUES (@MaThe, @LoaiThe, @DiemTichLuy, @NgayLap, @MaNhanVien, @MaKhachHang);
   
END;
------------------19
go
create PROCEDURE sp_GetTheKhachHang
    @MaThe CHAR(10) = NULL,
    @MaKhachHang CHAR(10) = NULL,
    @CCCD NVARCHAR(50) = NULL
AS
BEGIN
    -- Lấy thông tin thẻ khách hàng
    SELECT tkh.*
    FROM TheKhachHang tkh
    JOIN KhachHang kh ON kh.MaKhachHang = tkh.MaKhachHang
    WHERE 
        (@MaThe IS NULL OR tkh.MaThe = @MaThe) AND
        (@MaKhachHang IS NULL OR tkh.MaKhachHang = @MaKhachHang) AND
        (@CCCD IS NULL OR kh.CCCD = @CCCD);
END;
GO

---------------------20
CREATE PROCEDURE sp_GetUuDais
    @MaUuDai NVARCHAR(50) = NULL,
    @LoaiTheApDung NVARCHAR(50) = NULL,
    @NgayHienTai DATETIME
AS
BEGIN
    -- Truy vấn dữ liệu từ bảng UuDai với các điều kiện lọc
    SELECT *
    FROM UuDai
    WHERE 
        (@MaUuDai IS NULL OR MaUuDai = @MaUuDai) AND
        (@LoaiTheApDung IS NULL OR LoaiTheApDung = @LoaiTheApDung) AND
        NgayKetThuc > @NgayHienTai;
END;
GO
-----------------------21
create PROCEDURE sp_ChuyenNhanSu
    @MaNhanVien NVARCHAR(50),
    @MaBoPhanMoi NVARCHAR(50),
    @MaChiNhanhMoi NVARCHAR(50),
    @NgayBatDau DATETIME,
    @NgayKetThuc DATETIME = NULL
AS
BEGIN
    -- Bước 1: Kiểm tra và cập nhật lịch sử làm việc cũ nếu chưa có ngày kết thúc
    DECLARE @MaLS NVARCHAR(50)

    -- Kiểm tra xem có lịch sử làm việc nào chưa có ngày kết thúc không
    IF EXISTS (
        SELECT 1 
        FROM LichSuLamViec 
        WHERE MaNhanVien = @MaNhanVien AND NgayKetThuc IS NULL
    )
    BEGIN
        -- Cập nhật ngày kết thúc cho lịch sử làm việc cũ (ngày bắt đầu của lịch sử mới)
        UPDATE LichSuLamViec
        SET NgayKetThuc = @NgayBatDau
        WHERE MaNhanVien = @MaNhanVien AND NgayKetThuc IS NULL
    END

    -- Bước 2: Cập nhật thông tin nhân viên trong bảng NhanVien
    UPDATE NhanVien
    SET 
        MaBoPhan = @MaBoPhanMoi,
        MaChiNhanh = @MaChiNhanhMoi
    WHERE MaNhanVien = @MaNhanVien

    -- Bước 3: Lấy mã lịch sử làm việc mới (có thể tự động sinh mã này)
    SET @MaLS = (SELECT 'LS' + CAST(ISNULL(MAX(CAST(SUBSTRING(MaLS, 3, LEN(MaLS)) AS INT)), 0) + 1 AS NVARCHAR)
                 FROM LichSuLamViec)

    -- Bước 4: Thêm bản ghi lịch sử chuyển công tác vào bảng LichSuLamViec
    INSERT INTO LichSuLamViec (MaLS, MaNhanVien, MaChiNhanh, NgayBatDau, NgayKetThuc)
    VALUES (@MaLS, @MaNhanVien, @MaChiNhanhMoi, @NgayBatDau, @NgayKetThuc)

END
GO

SELECT @@SERVERNAME AS ServerName;
select * from KhachHang
select * from UuDai

SELECT TABLE_NAME 
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE'
ORDER BY TABLE_NAME;

select * from HoaDon