using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuanLySuShi.DTO;

namespace QuanLySuShi.DAO
{

    public class TheKhachHangDAO
    {
        // Thêm thẻ khách hàng mới
        public static bool CreateTheKhachHang(string maThe, string maNhanVien, string maKhachHang)
        {

            string query = "EXEC sp_CreateTheKhachHang @MaThe,@MaNhanVien,@MaKhachHang";
            Dictionary<string, object> parameters = new Dictionary<string, object>
        {
            { "@MaThe", maThe },
            { "@MaNhanVien", maNhanVien },
            { "@MaKhachHang", maKhachHang }
        };

            return DataProvider.ExecuteNonQuery(query, parameters);
        }
        public static string GetNextTheKhachHang()
        {

            string query = "select dbo.fn_GetNextTheKhachHang();"; 
       
            DataTable datatable = DataProvider.ExecuteSelectQuery(query);
            return (string)datatable.Rows[0][0]; 
        }
        public static bool UpdateCardStatus(string MaKhachHang)
        {

            string query = "EXEC sp_UpdateCardStatus @MaKhachHang";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@MaKhachHang", MaKhachHang }
            };

            return DataProvider.ExecuteNonQuery(query, parameters);
        }


        // Cập nhật thông tin thẻ khách hàng
        public static bool UpdateTheKhachHang(string maThe, string loaiThe, int diemTichLuy, string maNhanVien, string maKhachHang)
        {
            string query = @"
            UPDATE TheKhachHang
            SET LoaiThe = @LoaiThe,
                DiemTichLuy = @DiemTichLuy,
            WHERE MaThe = @MaThe";

            Dictionary<string, object> parameters = new Dictionary<string, object>
        {
            { "@MaThe", maThe },
            { "@LoaiThe", loaiThe },
            { "@DiemTichLuy", diemTichLuy }
         
        };

            return DataProvider.ExecuteNonQuery(query, parameters);
        }

        // Xóa thẻ khách hàng
        public static bool DeleteTheKhachHang(string maThe)
        {
            string query = "DELETE FROM TheKhachHang WHERE MaThe = @MaThe";

            Dictionary<string, object> parameters = new Dictionary<string, object>
        {
            { "@MaThe", maThe }
        };

            return DataProvider.ExecuteNonQuery(query, parameters);
        }

        // Lấy thông tin chi tiết thẻ khách hàng theo mã thẻ
        public static TheKhachHang GetTheKhachHang(string maThe = null, string maKhachHang = null, string cccd = null)
        {
            // Câu lệnh SQL với logic sửa
            string query = "Exec sp_GetTheKhachHang @MaThe,@MaKhachHang,@CCCD;";

            // Khởi tạo tham số
            Dictionary<string, object> parameters = new Dictionary<string, object>
    {
        { "@MaThe", (object)maThe ?? DBNull.Value },
        { "@MaKhachHang", (object)maKhachHang ?? DBNull.Value },
        { "@CCCD", (object)cccd ?? DBNull.Value }
    };

            // Thực thi truy vấn
            DataTable result = DataProvider.ExecuteSelectQuery(query, parameters);

            // Kiểm tra kết quả
            if (result.Rows.Count > 0)
            {
                DataRow row = result.Rows[0];
                return new TheKhachHang(
                    row["MaThe"]?.ToString(),
                    row["LoaiThe"]?.ToString(),
                    Convert.ToInt32(row["DiemTichLuy"]),
                    Convert.ToDateTime(row["NgayLap"]),
                    row["MaNhanVienLapThe"]?.ToString(),
                    row["MaKhachHang"]?.ToString()
                );
            }

            // Không tìm thấy kết quả
            return null;
        }



    }
}