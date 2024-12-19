using System;
using System.Data;
using System.Data.SqlClient;
using QuanLySuShi.DTO;

namespace QuanLySuShi
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
        { "@TenMonAn", string.IsNullOrEmpty(tenmonan) ? DBNull.Value : (object)$"%{tenmonan}%" }
    };

            return DataProvider.ExecuteSelectQuery(query, parameters);
        }


    }
}
