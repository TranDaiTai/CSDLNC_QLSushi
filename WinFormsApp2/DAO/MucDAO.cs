using QuanLySuShi.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySuShi.DAO
{
    public class MucDAO
    {
        // Hàm lấy tất cả các mục theo mã thực đơn
        public static List<Muc> GetMucs(string maThucDon = null , string maMuc = null )
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

     
    }
}
