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

-- Thêm dữ liệu vào bảng KhachHang
INSERT INTO TheKhachHang (MaThe, LoaiThe, DiemTichLuy, NgayLap, MaNhanVienLapThe, MaKhachHang)
VALUES
('TH001', 'Gold', 150, '2023-01-15', 'NV001', 'KH01'),
('TH002', 'Silver', 80, '2023-02-20', 'NV002', 'KH02'),
('TH003', 'Membership', 30, '2023-03-05', 'NV001', 'KH01'),
('TH004', 'Gold', 200, '2023-04-10', 'NV003', 'KH02'),
('TH005', 'Silver', 120, '2023-05-25', 'NV002', 'KH01');
GO
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


