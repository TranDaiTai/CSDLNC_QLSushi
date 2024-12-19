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
    public class ThucDonDAO
    {
        // Hàm lấy tất cả các thực đơn
        public static List<ThucDon> GetThucDon(string machinhanh = null)
        {
            List<ThucDon> thucDons = new List<ThucDon>();

            // Câu truy vấn SQL liên kết bảng ThucDon qua bảng DichVu
            string query = "exec sp_GetThucDon @machinhanh";

            // Thêm tham số cho truy vấn
            var parameters = new Dictionary<string, object>
            {
                { "@machinhanh", (object)machinhanh ??DBNull.Value }
            };

            // Thực hiện truy vấn và lấy dữ liệu
            DataTable result = DataProvider.ExecuteSelectQuery(query, parameters);

            // Nếu có dữ liệu, chuyển đổi từng dòng thành đối tượng ThucDon
            foreach (DataRow row in result.Rows)
            {
                ThucDon thucDon = new ThucDon(
                    row["MaThucDon"].ToString(),
                    row["TenThucDon"].ToString(),
                    row["KhuVuc"].ToString()
                );
                thucDons.Add(thucDon);
            }

            return thucDons;
        }

    }
}
