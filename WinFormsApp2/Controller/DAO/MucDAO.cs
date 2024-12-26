using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySuShi.Model.DTO;

namespace QuanLySuShi.Controller.DAO
{
    public class MucDAO
    {
        // Hàm lấy tất cả các mục theo mã thực đơn
        public static List<Muc> GetMucs(string maThucDon = null, string maMuc = null)
        {
            List<Muc> mucs = new List<Muc>();

            // Câu truy vấn SQL
            string query = "EXEC sp_getMuc @mathucdon,@mamuc ";

            // Tạo tham số cho câu truy vấn
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@mathucdon", (object)maThucDon ?? DBNull.Value);
            parameters.Add("@mamuc", (object)maMuc ?? DBNull.Value);


            // Thực hiện truy vấn và lấy dữ liệu
            DataTable result = DataProvider.ExecuteSelectQuery(query, parameters);

            // Nếu có dữ liệu, chuyển đổi từng dòng thành đối tượng Muc
            foreach (DataRow row in result.Rows)
            {
                Muc muc = new Muc(row);
                mucs.Add(muc);
            }
            return mucs;
        }

        public static bool AddMuc(Muc muc)
        {
            string query = "EXEC sp_AddMuc @MaMuc, @TenMuc, @MaThucDon";
            var parameters = new Dictionary<string, object>
            {
                { "@MaMuc", muc.MaMuc },
                { "@TenMuc", muc.TenMuc },
                { "@MaThucDon", muc.MaThucDon }
            };

            return DataProvider.ExecuteNonQuery(query, parameters);
        }

        public static bool UpdateMuc(Muc muc)
        {
            string query = "EXEC sp_UpdateMuc @MaMuc, @TenMuc, @MaThucDon";
            var parameters = new Dictionary<string, object>
            {
                { "@MaMuc", muc.MaMuc },
                { "@TenMuc", muc.TenMuc },
                { "@MaThucDon", muc.MaThucDon }
            };

            return DataProvider.ExecuteNonQuery(query, parameters);
        }

        public static bool DeleteMuc(string maMuc)
        {
            string query = "EXEC sp_DeleteMuc @MaMuc";
            var parameters = new Dictionary<string, object>
            {
                { "@MaMuc", maMuc }
            };

            return DataProvider.ExecuteNonQuery(query, parameters);
        }

        public static List<Muc> SearchMuc(string tuKhoa)
        {
            List<Muc> ketQua = new List<Muc>();
            string query = "EXEC sp_SearchMuc @TuKhoa";
            var parameters = new Dictionary<string, object>
            {
                { "@TuKhoa", tuKhoa }
            };

            try
            {
                DataTable data = DataProvider.ExecuteSelectQuery(query, parameters);

                foreach (DataRow row in data.Rows)
                {
                    Muc m = new Muc
                    {
                        MaMuc = row["MaMuc"].ToString(),
                        TenMuc = row["TenMuc"].ToString(),
                        MaThucDon = row["MaThucDon"].ToString()
                    };
                    ketQua.Add(m);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm thực đơn: {ex.Message}");
            }
            return ketQua;
        }

        public static string GenerateNewMaMuc()
        {
            List<Muc> newMuc = new List<Muc>();

            try
            {
                using (SqlConnection conn = new SqlConnection(DataProvider.GetConnectionString()))
                {
                    conn.Open();
                    string query = @"
                        DECLARE @MaxMa varchar(10)
                        SELECT @MaxMa = MAX(MaMuc) 
                        FROM Muc 
                        WHERE MaMuc LIKE 'M%'

                        IF @MaxMa IS NULL
                            SELECT 'M01'
                        ELSE
                            SELECT 'M' + RIGHT('00' + CAST(CAST(SUBSTRING(@MaxMa, 2, 2) AS int) + 1 AS varchar(2)), 2)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        var result = cmd.ExecuteScalar()?.ToString();
                        return result ?? "M01";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo mã mục: {ex.Message}");
                return "M01";
            }
        }
    }
}
