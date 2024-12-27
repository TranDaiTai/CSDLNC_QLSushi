using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySuShi.Model.DTO;
using System.Configuration;

namespace QuanLySuShi.Controller.DAO
{
    public class ThucDonDAO
    {
        private static string GetConnectionString()
        {
            try
            {
                return "Data Source=.;Initial Catalog=QLShiShu;Integrated Security=True";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối database: {ex.Message}");
                return string.Empty;
            }
        }

        public static List<ThucDon> GetThucDon(string machinhanh = null)
        {
            List<ThucDon> thucDons = new List<ThucDon>();

            string query = "exec sp_GetThucDon @machinhanh";
            var parameters = new Dictionary<string, object>
            {
                { "@machinhanh", (object)machinhanh ?? DBNull.Value }
            };

            DataTable result = DataProvider.ExecuteSelectQuery(query, parameters);

            foreach (DataRow row in result.Rows)
            {
                ThucDon thucDon = new ThucDon(
                    Convert.ToString(row["MaThucDon"]) ?? string.Empty,
                    Convert.ToString(row["TenThucDon"]) ?? string.Empty,
                    Convert.ToString(row["KhuVuc"]) ?? string.Empty
                );
                thucDons.Add(thucDon);
            }

            return thucDons;
        }

        public static bool AddThucDon(ThucDon thucDon)
        {
            try
            {
                string query = "EXEC sp_ThemThucDon @MaThucDon, @TenThucDon, @KhuVuc";
                
                var parameters = new Dictionary<string, object>
                {
                    { "@MaThucDon", thucDon.MaThucDon },
                    { "@TenThucDon", thucDon.TenThucDon },
                    { "@KhuVuc", thucDon.KhuVuc }
                };

                return DataProvider.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm thực đơn: {ex.Message}");
                return false;
            }
        }

        public static bool UpdateThucDon(ThucDon thucdon)
        {
            try
            {
                string query = "EXEC sp_CapNhatThucDon @MaThucDon, @TenThucDon, @KhuVuc";
                var parameters = new Dictionary<string, object>
                {
                    {"@MaThucDon", thucdon.MaThucDon},
                    {"@TenThucDon", thucdon.TenThucDon},
                    {"@KhuVuc", thucdon.KhuVuc}
                };

                return DataProvider.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật thực đơn: {ex.Message}");
                return false;
            }
        }

        public static bool DeleteThucDon(string maThucDon)
        {
            try
            {
                string query = "EXEC sp_XoaThucDon @MaThucDon";
                
                var parameters = new Dictionary<string, object>
                {
                    {"@MaThucDon", maThucDon ?? string.Empty}
                };

                return DataProvider.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa thực đơn: {ex.Message}");
                return false;
            }
        }

        public static List<ThucDon> GetAllThucDon() 
        {
            List<ThucDon> danhSachThucDon = new List<ThucDon>();
            string query = "SELECT * FROM ThucDon";
            
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ThucDon thucDon = new ThucDon(
                                    reader["MaThucDon"]?.ToString() ?? string.Empty,
                                    reader["TenThucDon"]?.ToString() ?? string.Empty,
                                    reader["KhuVuc"]?.ToString() ?? string.Empty
                                );
                                danhSachThucDon.Add(thucDon);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy danh sách thực đơn: {ex.Message}");
            }
            return danhSachThucDon;
        }

        public static List<ThucDon> SearchThucDon(string tuKhoa)
        {
            List<ThucDon> ketQua = new List<ThucDon>();
            string query = "EXEC sp_TimKiemThucDon @TuKhoa";
            
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@TuKhoa", tuKhoa }
            };

            try 
            {
                DataTable data = DataProvider.ExecuteSelectQuery(query, parameters);
                
                foreach (DataRow row in data.Rows)
                {
                    ThucDon td = new ThucDon
                    {
                        MaThucDon = row["MaThucDon"].ToString(),
                        TenThucDon = row["TenThucDon"].ToString(),
                        KhuVuc = row["KhuVuc"].ToString()
                    };
                    ketQua.Add(td);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm thực đơn: {ex.Message}");
            }

            return ketQua;
        }

        public static string GenerateNewMaThucDon()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    conn.Open();
                    
                    // Thử truy vấn trực tiếp thay vì dùng stored procedure
                    string query = @"
                        DECLARE @MaxMa varchar(10)
                        SELECT @MaxMa = MAX(MaThucDon) 
                        FROM ThucDon 
                        WHERE MaThucDon LIKE 'TD%'
                        
                        IF @MaxMa IS NULL
                            SELECT 'TD01'
                        ELSE
                            SELECT 'TD' + RIGHT('00' + CAST(CAST(SUBSTRING(@MaxMa, 3, 2) AS int) + 1 AS varchar(2)), 2)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        var result = cmd.ExecuteScalar()?.ToString();
                        return result ?? "TD01";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo mã thực đơn: {ex.Message}");
                return "TD01";
            }
        }
        public static bool AddPhucVu(string maChiNhanh, string maThucDon)
        {
            try
            {
                // Câu lệnh SQL chèn trực tiếp
                string query = "INSERT INTO PhucVu (MaChiNhanh, MaThucDon) VALUES (@MaChiNhanh, @MaThucDon)";

                // Khởi tạo tham số
                var parameters = new Dictionary<string, object>
        {
            { "@MaChiNhanh", maChiNhanh },
            { "@MaThucDon", maThucDon }
        };

                // Thực hiện truy vấn
                return DataProvider.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi nếu có
                MessageBox.Show($"Lỗi khi thêm phục vụ: {ex.Message}");
                return false;
            }
        }


    }
}
