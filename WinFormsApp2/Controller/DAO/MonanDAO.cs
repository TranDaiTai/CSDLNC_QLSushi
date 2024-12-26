using System;
using System.Data;
using System.Data.SqlClient;
using QuanLySuShi.Model.DTO;

namespace QuanLySuShi.Controller.DAO
{
    public class MonAnDAO
    {

        public static List<MonAn> GetMonAn(string maThucDon = null, string maMuc = null, string maMonAn = null, string maChiNhanh = null)
        {
            string query = " EXEC sp_GetMonAn @MaThucDon,@MaMuc,@MaMonAn,@MaChiNhanh";
            List<MonAn> monAns = new List<MonAn>();

            // Tạo danh sách tham số
            Dictionary<string, object> parameters = new Dictionary<string, object>
    {
        { "@MaThucDon", (object)maThucDon ?? DBNull.Value },
        { "@MaMuc", (object)maMuc ?? DBNull.Value },
        { "@MaMonAn", (object)maMonAn ?? DBNull.Value },
        { "@MaChiNhanh", (object)maChiNhanh ?? DBNull.Value }
    };

            // Gọi Stored Procedure
            DataTable result = DataProvider.ExecuteSelectQuery(query, parameters);

            // Chuyển đổi dữ liệu thành danh sách đối tượng MonAn
            foreach (DataRow row in result.Rows)
            {
                MonAn monAn = new MonAn(row);
                monAns.Add(monAn);
            }

            return monAns;
        }


        public static DataTable GetMonAnDaBanFromTo(DateTime from, DateTime to, string chinhanh, string tenmonan = null)
        {
            string query = "EXEC sp_GetMonAnDaBanFromTo @FromDate, @ToDate, @MaChiNhanh, @TenMonAn";

            Dictionary<string, object> parameters = new Dictionary<string, object>
    {
        { "@FromDate", from },
        { "@ToDate", to },
        { "@MaChiNhanh", chinhanh },
        { "@TenMonAn", string.IsNullOrEmpty(tenmonan) ? DBNull.Value : $"%{tenmonan}%" }
    };

            return DataProvider.ExecuteSelectQuery(query, parameters);
        }

        public static bool AddMonAn(MonAn monAn)
        {
            string query = "INSERT INTO MonAn (MaMon, TenMon, Gia, MaMuc, MaThucDon) VALUES (@MaMon, @TenMon, @Gia, @MaMuc, @MaThucDon)";
            using (SqlConnection conn = new SqlConnection(DataProvider.GetConnectionString()))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaMon", monAn.MaMonAn);
                    cmd.Parameters.AddWithValue("@TenMon", monAn.TenMonAn);
                    cmd.Parameters.AddWithValue("@Gia", monAn.GiaTien);
                    cmd.Parameters.AddWithValue("@MaMuc", monAn.MaMuc);
                    cmd.Parameters.AddWithValue("@MaThucDon", monAn.MaThucDon);
                    return cmd.ExecuteNonQuery() > 0; // Trả về true nếu thêm thành công
                }
            }
        }

        public static bool UpdateMonAn(MonAn monAn)
        {
            string query = "UPDATE MonAn SET TenMon = @TenMon, Gia = @Gia, MaMuc = @MaMuc, MaThucDon = @MaThucDon WHERE MaMon = @MaMon";
            using (SqlConnection conn = new SqlConnection(DataProvider.GetConnectionString()))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaMon", monAn.MaMonAn);
                    cmd.Parameters.AddWithValue("@TenMon", monAn.TenMonAn);
                    cmd.Parameters.AddWithValue("@Gia", monAn.GiaTien);
                    cmd.Parameters.AddWithValue("@MaMuc", monAn.MaMuc);
                    cmd.Parameters.AddWithValue("@MaThucDon", monAn.MaThucDon);
                    return cmd.ExecuteNonQuery() > 0; // Trả về true nếu cập nhật thành công
                }
            }
        }

        public static bool DeleteMonAn(string maMon)
        {
            string query = "DELETE FROM MonAn WHERE MaMon = @MaMon";
            using (SqlConnection conn = new SqlConnection(DataProvider.GetConnectionString()))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaMon", maMon);
                    return cmd.ExecuteNonQuery() > 0; // Trả về true nếu xóa thành công
                }
            }
        }

        public static string GenerateNewMaMonAn()
        {
            string newMaMonAn = "MA01"; 
            string query = "SELECT MAX(MaMonAn) FROM MonAn"; 

            using (SqlConnection conn = new SqlConnection(DataProvider.GetConnectionString()))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    var result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        string maxMaMonAn = result.ToString();
                        int nextId = int.Parse(maxMaMonAn.Substring(2)) + 1; 
                        newMaMonAn = "MA" + nextId.ToString("D2"); 
                    }
                }
            }
            return newMaMonAn;
        }
        public static List<MonAn> SearchMonAn(string tuKhoa)
        {
            List<MonAn> ketQua = new List<MonAn>();
            string query = "EXEC sp_SearchMonAn @TuKhoa"; // Giả sử bạn có stored procedure này
            var parameters = new Dictionary<string, object>
            {
                { "@TuKhoa", tuKhoa }
            };

            try
            {
                DataTable data = DataProvider.ExecuteSelectQuery(query, parameters);

                foreach (DataRow row in data.Rows)
                {
                    MonAn monAn = new MonAn
                    {
                        MaMonAn = row["MaMonAn"].ToString(),
                        TenMonAn = row["TenMonAn"].ToString(),
                        GiaTien = Convert.ToDecimal(row["GiaTien"]),
                        MaMuc = row["MaMuc"].ToString(),
                        MaThucDon = row["MaThucDon"].ToString(),
                    };
                    ketQua.Add(monAn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm món ăn: {ex.Message}");
            }
            return ketQua;
        }
    }
}
