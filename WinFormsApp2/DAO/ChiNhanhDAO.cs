using QuanLySuShi.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySuShi.DAO
{
    public class ChiNhanhDAO
    {
        public static List<ChiNhanh> GetAllChiNhanh()
        {
            string query = "SELECT * FROM ChiNhanh";
            DataTable dataTable = DataProvider.ExecuteSelectQuery(query);

            List<ChiNhanh> chiNhanhList = new List<ChiNhanh>();
            foreach (DataRow row in dataTable.Rows)
            {
                chiNhanhList.Add(new ChiNhanh(row));
            }

            return chiNhanhList;
        }
        public static ChiNhanh GetChiNhanhByMaChiNhanh(string maChiNhanh)
        {
            string query = "SELECT * FROM ChiNhanh WHERE MaChiNhanh = @MaChiNhanh";

            Dictionary<string, object> parameters = new Dictionary<string, object>
    {
        { "@MaChiNhanh", maChiNhanh }
    };

            DataTable dataTable = DataProvider.ExecuteSelectQuery(query, parameters);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                // Trả về ChiNhanh từ DataRow đầu tiên
                return new ChiNhanh(dataTable.Rows[0]);
            }

            return null; // Trả về null nếu không tìm thấy chi nhánh
        }

    }

}
