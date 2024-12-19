using QuanLySuShi.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySuShi.DAO
{
    public class UuDaiDAO
    {
        // Thêm ưu đãi vào cơ sở dữ liệu
        public static bool AddUuDai(UuDai uuDai)
        {
            string query = "INSERT INTO UuDai (MaUuDai, GiamGia, ChuongTrinh, TangSanPham, UuDaiChietKhau, LoaiTheApDung, NgayBatDau, NgayKetThuc) " +
                           "VALUES (@MaUuDai, @GiamGia, @ChuongTrinh, @TangSanPham, @UuDaiChietKhau, @LoaiTheApDung, @NgayBatDau, @NgayKetThuc)";

            // Định nghĩa tham số cho truy vấn
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@MaUuDai", uuDai.MaUuDai },
                { "@GiamGia", uuDai.GiamGia ?? (object)DBNull.Value },
                { "@ChuongTrinh", uuDai.ChuongTrinh ?? (object)DBNull.Value },
                { "@LoaiTheApDung", uuDai.LoaiTheApDung ?? (object)DBNull.Value },
                { "@NgayBatDau", uuDai.NgayBatDau },
                { "@NgayKetThuc", uuDai.NgayKetThuc }
            };

            // Thực thi truy vấn và trả về kết quả
            return DataProvider.ExecuteNonQuery(query, parameters);
        }

        // Lấy ưu đãi theo tùy chọn
        public static List<UuDai> GetUuDais(string maUuDai = null, string loaiTheApDung = null)
        {
            // Gọi stored procedure
            string query = "EXEC sp_GetUuDais @MaUuDai, @LoaiTheApDung, @NgayHienTai";

            // Khởi tạo tham số
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@MaUuDai", (object)maUuDai ?? DBNull.Value },
                { "@LoaiTheApDung", (object)loaiTheApDung ?? DBNull.Value },
                { "@NgayHienTai", DateTime.Now }
            };

            // Thực thi truy vấn và lấy dữ liệu
            DataTable dataTable = DataProvider.ExecuteSelectQuery(query, parameters);

            // Chuyển đổi dữ liệu thành danh sách đối tượng UuDai
            List<UuDai> result = new List<UuDai>();
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    result.Add(UuDai.FromDataRow(row));
                }
            }

            return result; // Trả về danh sách ưu đãi
        }




    }
}
