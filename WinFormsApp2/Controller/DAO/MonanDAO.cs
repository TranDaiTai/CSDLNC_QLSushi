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

        public static void AddDish(MonAn dish)
        {
            string query = "INSERT INTO MonAn (TenMonAn, GiaTien) VALUES (@TenMonAn, @GiaTien)";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@TenMonAn", dish.TenMonAn },
                { "@GiaTien", dish.GiaTien }
            };
            DataProvider.ExecuteNonQuery(query, parameters);
        }

        public static void UpdateDish(MonAn dish)
        {
            string query = "UPDATE MonAn SET TenMonAn = @TenMonAn, GiaTien = @GiaTien WHERE MaMonAn = @MaMonAn";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@TenMonAn", dish.TenMonAn },
                { "@GiaTien", dish.GiaTien },
                { "@MaMonAn", dish.MaMonAn }
            };
            DataProvider.ExecuteNonQuery(query, parameters);
        }

        public static void DeleteDish(string maMonAn)
        {
            string query = "DELETE FROM MonAn WHERE MaMonAn = @MaMonAn";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@MaMonAn", maMonAn }
            };
            DataProvider.ExecuteNonQuery(query, parameters);
        }

    }
}
