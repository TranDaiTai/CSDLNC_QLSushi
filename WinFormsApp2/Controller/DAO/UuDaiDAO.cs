using QuanLySuShi.Model.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySuShi.Controller.DAO
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

        public static UuDai GetUuDaiByMaUuDai(string maUuDai)
        {
            if (string.IsNullOrWhiteSpace(maUuDai))
            {
                return null; // Không áp dụng ưu đãi
            }

            string query = "SELECT MaUuDai, GiamGia, ChuongTrinh, TangSanPham, UuDaiChietKhau, LoaiTheApDung, NgayBatDau, NgayKetThuc " +
                           "FROM UuDai WHERE MaUuDai = @MaUuDai";

            var parameters = new Dictionary<string, object>
            {
                { "@MaUuDai", maUuDai }
            };

            DataTable data = DataProvider.ExecuteSelectQuery(query, parameters);

            if (data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                return new UuDai
                {
                    MaUuDai = row["MaUuDai"].ToString(),
                    GiamGia = row["GiamGia"] == DBNull.Value ? null : (decimal?)row["GiamGia"],
                    ChuongTrinh = row["ChuongTrinh"].ToString(),
                    TangSanPham = row["TangSanPham"].ToString(),
                    //UuDaiChietKhau = row["UuDaiChietKhau"] == DBNull.Value ? null : (float?)row["UuDaiChietKhau"],
                    UuDaiChietKhau = row["UuDaiChietKhau"] == DBNull.Value ? null : (float?)(double?)row["UuDaiChietKhau"],
                    LoaiTheApDung = row["LoaiTheApDung"].ToString(),
                    NgayBatDau = (DateTime)row["NgayBatDau"],
                    NgayKetThuc = (DateTime)row["NgayKetThuc"]
                };
            }

            return null;
        }



    }
}
