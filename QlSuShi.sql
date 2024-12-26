use master
go
-- Kiểm tra xem cơ sở dữ liệu có tồn tại không
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'QLShiShu')
BEGIN
    -- Nếu có, xoá cơ sở dữ liệu
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

