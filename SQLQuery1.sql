USE QLShiShu
   
GO

----------1
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
GO
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
-- Tạo sp_CreateTheKhachHang
CREATE PROCEDURE sp_CreateTheKhachHang
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
GO

------------------19
CREATE PROCEDURE sp_GetTheKhachHang
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


-- Thêm thực đơn mới
CREATE PROCEDURE sp_ThemThucDon
    @MaThucDon varchar(10),
    @TenThucDon nvarchar(100),
    @KhuVuc nvarchar(50)
AS
BEGIN
    INSERT INTO ThucDon(MaThucDon, TenThucDon, KhuVuc)
    VALUES(@MaThucDon, @TenThucDon, @KhuVuc)
END
GO

-- Cập nhật thực đơn
CREATE PROCEDURE sp_CapNhatThucDon
    @MaThucDon varchar(10),
    @TenThucDon nvarchar(100),
    @KhuVuc nvarchar(50)
AS
BEGIN
    UPDATE ThucDon 
    SET TenThucDon = @TenThucDon,
        KhuVuc = @KhuVuc
    WHERE MaThucDon = @MaThucDon
END
GO

-- Xóa thực đơn
CREATE PROCEDURE sp_XoaThucDon
    @MaThucDon varchar(10)
AS
BEGIN
    DELETE FROM ThucDon 
    WHERE MaThucDon = @MaThucDon
END
GO

-- Lấy danh sách thực đơn
CREATE PROCEDURE sp_LayDanhSachThucDon
AS
BEGIN
    SELECT * FROM ThucDon
END
GO
-- tìm thực đơn
CREATE PROCEDURE sp_TimKiemThucDon
    @TuKhoa nvarchar(100)
AS
BEGIN
    DECLARE @TuKhoaKhongDau nvarchar(100)
    SET @TuKhoaKhongDau = @TuKhoa

    SELECT * FROM ThucDon
    WHERE 
        LOWER(MaThucDon) LIKE LOWER(N'%' + @TuKhoa + '%')
        OR LOWER(TenThucDon) COLLATE Latin1_General_CI_AI LIKE LOWER(N'%' + @TuKhoa + '%')
        OR LOWER(KhuVuc) COLLATE Latin1_General_CI_AI LIKE LOWER(N'%' + @TuKhoa + '%')
END
GO


--Tạo mới mã thực đơn
CREATE PROCEDURE sp_GenerateNewMaThucDon
    @NewMaThucDon varchar(10) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        DECLARE @MaxMa varchar(10)
        DECLARE @NewNumber int
        
        -- Lấy mã thực đơn lớn nhất hiện tại
        SELECT @MaxMa = MAX(MaThucDon) 
        FROM ThucDon 
        WHERE MaThucDon LIKE 'TD%'
        
        IF @MaxMa IS NULL
            SET @NewMaThucDon = 'TD01'
        ELSE
        BEGIN
            -- Lấy số từ mã hiện tại và tăng lên 1
            SET @NewNumber = CAST(SUBSTRING(@MaxMa, 3, 2) AS int) + 1
            -- Đảm bảo số mới không vượt quá 99
            IF @NewNumber > 99
                THROW 50001, 'Đã đạt đến giới hạn mã thực đơn.', 1;
            SET @NewMaThucDon = 'TD' + RIGHT('00' + CAST(@NewNumber AS varchar(2)), 2)
        END
    END TRY
    BEGIN CATCH
        -- Nếu có lỗi, trả về mã mặc định
        SET @NewMaThucDon = 'TD01'
        -- Có thể log lỗi ở đây nếu cần
    END CATCH
END
go

-- thêm mới nhân viên