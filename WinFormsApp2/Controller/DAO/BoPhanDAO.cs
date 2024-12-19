using QuanLySuShi.Model.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySuShi.Controller.DAO
{
    public class BoPhanDAO
    {


        public static List<BoPhan> GetBoPhan(string? maBoPhan = null)
        {
            string query = "EXEC sp_getBoPhan @MaBoPhan";
            List<BoPhan> boPhans = new List<BoPhan>();

            // Định nghĩa tham số
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@MaBoPhan", (object)maBoPhan ?? DBNull.Value }
            };

            // Thực hiện truy vấn và lấy kết quả
            DataTable dataTable = DataProvider.ExecuteSelectQuery(query, parameters);

            foreach (DataRow item in dataTable.Rows)
            {
                boPhans.Add(BoPhan.FromDataRow(item));
            }
            return boPhans;

        }

        // Thêm mới một bộ phận
        public static bool InsertBoPhan(BoPhan boPhan)
        {
            string query = "INSERT INTO BoPhan (MaBoPhan, TenBoPhan, Luong) VALUES (@MaBoPhan, @TenBoPhan, @Luong)";

            // Định nghĩa tham số
            Dictionary<string, object> parameters = new Dictionary<string, object>
        {
            { "@MaBoPhan", boPhan.MaBoPhan },
            { "@TenBoPhan", boPhan.TenBoPhan },
            { "@Luong", boPhan.Luong }
        };

            // Thực hiện câu lệnh INSERT
            return DataProvider.ExecuteNonQuery(query, parameters);
        }

        // Cập nhật thông tin bộ phận
        public static bool UpdateBoPhan(BoPhan boPhan)
        {
            string query = "UPDATE BoPhan SET TenBoPhan = @TenBoPhan, Luong = @Luong WHERE MaBoPhan = @MaBoPhan";

            // Định nghĩa tham số
            Dictionary<string, object> parameters = new Dictionary<string, object>
        {
            { "@MaBoPhan", boPhan.MaBoPhan },
            { "@TenBoPhan", boPhan.TenBoPhan },
            { "@Luong", boPhan.Luong }
        };

            // Thực hiện câu lệnh UPDATE
            return DataProvider.ExecuteNonQuery(query, parameters);
        }


    }
}
