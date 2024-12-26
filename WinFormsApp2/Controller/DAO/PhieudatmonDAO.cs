using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Intrinsics.Arm;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;
using QuanLySuShi.Model.DTO;
namespace QuanLySuShi.Controller.DAO
{
    internal class PhieudatmonDAO
    {
        public static string GetPhieuDatMonByTableId(string id)
        {
            var query = "SELECT pdm.maphieu " +
                        "FROM PhieuDatMon pdm " +
                        "LEFT JOIN HoaDon hd ON pdm.MaPhieu = hd.MaPhieu " +
                        "JOIN PhieuDatMonTrucTiep tt ON pdm.MaPhieu = tt.MaPhieu " +
                        "WHERE hd.MaHoaDon IS NULL AND tt.maban = @TableId";

            var parameters = new Dictionary<string, object>
            {
                { "@TableId", id }
            };

            DataTable dataTable = DataProvider.ExecuteSelectQuery(query, parameters);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                return dataTable.Rows[0]["maphieu"]?.ToString(); // Sử dụng ?.ToString() để tránh lỗi null.
            }

            return null; // Trả về null nếu không có dữ liệu.
        }
        // Hàm tạo phiếu đặt món mới
        public static bool CreatePhieuDatMon(string maNhanVien, string maKhachhang, string machinhanh, string maPhieuMoi, string loaiphieu)
        {
            string query = "EXEC dbo.sp_CreatePhieuDatMon @MaPhieu, @NhanVienLap, @MaChiNhanh, @MaKhachhang ,@LoaiPhieu";

            var parameters = new Dictionary<string, object>
            {
                { "@MaPhieu", maPhieuMoi },
                { "@NhanVienLap", maNhanVien ?? (object)DBNull.Value },  // Nếu null, chèn NULL vào cột
                { "@MaChiNhanh", machinhanh },
                { "@MaKhachhang", maKhachhang},
                { "@LoaiPhieu", loaiphieu}
            };

            // Thực thi câu lệnh SQL và trả về kết quả
            DataTable dataTable = DataProvider.ExecuteSelectQuery(query, parameters);

            // Kiểm tra kết quả trả về (nếu cần)
            return dataTable.Rows.Count > 0;
        }

        public static string GeNextPhieuDatMon()
        {
            // Câu truy vấn SQL để lấy giá trị lớn nhất của phần số trong mã phiếu
            string query = "select dbo.fn_GetNextPhieuDatMon();";


            DataTable dataTable = DataProvider.ExecuteSelectQuery(query);

            return (string)dataTable.Rows[0][0];
        }
        public static List<PhieuDatMon> GetPhieuDatMonByMaKhachHang(string maKhachHang)
        {
            List<PhieuDatMon> phieuDatMons = new List<PhieuDatMon>();

            // Câu truy vấn SQL
            string query = "SELECT * FROM PhieuDatMon WHERE MaKhachHang = @MaKhachHang";

            // Tạo tham số truy vấn
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@MaKhachHang", maKhachHang);

            // Thực thi truy vấn
            DataTable result = DataProvider.ExecuteSelectQuery(query, parameters);

            // Duyệt qua các dòng kết quả và chuyển thành đối tượng PhieuDatMon
            foreach (DataRow row in result.Rows)
            {
                PhieuDatMon phieuDatMon = new PhieuDatMon(row);

                phieuDatMons.Add(phieuDatMon);
            }

            return phieuDatMons;
        }
        public static List<PhieuDatMon> GetPhieuDatMonChuaLap(string MaChiNhanh = null)
        {
            List<PhieuDatMon> phieuDatMons = new List<PhieuDatMon>();

            var query = "SELECT  pdm.* " +
                        "FROM PhieuDatMon pdm " +
                        "WHERE (@MaChiNhanh IS NULL or pdm.machinhanh = @MaChiNhanh) and (pdm.NhanVienlap is null)";

            var parameters = new Dictionary<string, object>
            {
                { "@MaChiNhanh", MaChiNhanh }
            };

            DataTable result = DataProvider.ExecuteSelectQuery(query, parameters);

            // Duyệt qua các dòng kết quả và chuyển thành đối tượng PhieuDatMon
            foreach (DataRow row in result.Rows)
            {
                PhieuDatMon phieuDatMon = new PhieuDatMon(row);

                phieuDatMons.Add(phieuDatMon);
            }

            return phieuDatMons;
        }
        // Hàm cập nhật mã nhân viên cho phiếu đặt món
        public static bool UpdatePhieuDatMon(string maPhieu, string maNhanVien)
        {
            string query = "UPDATE PhieuDatMon SET NhanVienLap = @MaNhanVien WHERE MaPhieu = @MaPhieu";

            var parameters = new Dictionary<string, object>
            {
                { "@MaPhieu", maPhieu },
                { "@MaNhanVien", maNhanVien }
            };

            return DataProvider.ExecuteNonQuery(query, parameters);


        }
    }
}

