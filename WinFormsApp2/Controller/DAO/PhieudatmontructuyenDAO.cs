using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySuShi.Controller.DAO
{
    internal class PhieudatmonTrucTuyenDAO
    {
        public static bool CreatePhieuDatMonTrucTuyen(
        string maPhieu, DateTime thoiDiemTruyCap, DateTime? thoiGianTruyCap, string? ghiChu, string loaiDichVu)
        {
            // Tên stored procedure
            string query = "EXEC dbo.sp_CreatePhieuDatMonTrucTuyen " +
                           "@MaPhieu, @ThoiDiemTruyCap, @ThoiGianTruyCap, @GhiChu, @LoaiDichVu";

            // Tạo dictionary chứa tham số
            var parameters = new Dictionary<string, object>
            {
                { "@MaPhieu", maPhieu },
                { "@ThoiDiemTruyCap", thoiDiemTruyCap },
                { "@ThoiGianTruyCap", thoiGianTruyCap ?? (object)DBNull.Value }, // Kiểm tra null
                { "@GhiChu", string.IsNullOrEmpty(ghiChu) ? DBNull.Value : ghiChu },
                { "@LoaiDichVu", string.IsNullOrEmpty(loaiDichVu) ? DBNull.Value : loaiDichVu }
            };

            // Thực thi stored procedure
            return DataProvider.ExecuteNonQuery(query, parameters);
        }
    }

    internal class PhieuDatMonGiaoDiDAO : PhieudatmonTrucTuyenDAO
    {
        public static bool CreatePhieuDatMonGiaoDi(string maPhieu, DateTime thoiDiemTruyCap, DateTime? thoiGianTruyCap, string? ghiChu, int? phi, string diaChi)
        {
            string loaiDichVu = "Giao di";
            DateTime ngayGio = DateTime.Now;
            string tinhTrang = "Chưa Giao";


            CreatePhieuDatMonTrucTuyen(maPhieu, thoiDiemTruyCap, thoiGianTruyCap, ghiChu, loaiDichVu);
            // Câu truy vấn SQL
            string query = "INSERT INTO [dbo].[PhieuDatMonTrucTuyenGiaoDi] (MaPhieu, NgayGio, TinhTrang, Phi, DiaChi) " +
                        "VALUES (@MaPhieu, @NgayGio, @TinhTrang, @Phi, @DiaChi);";

            // Tạo dictionary chứa tham số
            var parameters = new Dictionary<string, object>
            {
                { "@MaPhieu", maPhieu },
                { "@NgayGio", ngayGio == null ? DBNull.Value : ngayGio },
                { "@TinhTrang", tinhTrang== null ? DBNull.Value : tinhTrang },
                { "@Phi", phi == null ? DBNull.Value : phi },
                { "@DiaChi", diaChi  }
            };

            // Gọi hàm thực thi lệnh SQL
            return DataProvider.ExecuteNonQuery(query, parameters);
        }
    }

    internal class PhieuDatMonTaiQuanDAO : PhieudatmonTrucTuyenDAO
    {
        public static bool CreatePhieuDatMonTaiQuan(string maPhieu, int? soLuongKhach, string maBan, DateTime? ngayDat)
        {
            // Câu truy vấn SQL
            string query = "INSERT INTO PhieuDatMonTrucTuyenTaiQuan (MaPhieu, SoLuongKhach, MaBan, NgayDat) " +
                           "VALUES (@MaPhieu, @SoLuongKhach, @MaBan, @NgayDat);";

            // Tạo dictionary chứa tham số
            var parameters = new Dictionary<string, object>
            {
                { "@MaPhieu", maPhieu },
                { "@SoLuongKhach", soLuongKhach == null ? DBNull.Value : soLuongKhach },
                { "@MaBan", string.IsNullOrEmpty(maBan) ? DBNull.Value : maBan },
                { "@NgayDat", ngayDat == null ? DBNull.Value : ngayDat }
            };

            // Gọi hàm thực thi lệnh SQL
            return DataProvider.ExecuteNonQuery(query, parameters);
        }
        public static string GetNextMaBan()
        {
            // Câu truy vấn SQL để gọi hàm lấy mã bàn tiếp theo
            string query = "SELECT dbo.fn_GetNextMaBan();";

            // Thực thi truy vấn và lấy kết quả
            DataTable dataTable = DataProvider.ExecuteSelectQuery(query);

            // Lấy giá trị mã bàn từ kết quả truy vấn
            string nextMaBan = (string)dataTable.Rows[0][0];

            return nextMaBan;
        }

    }
}
