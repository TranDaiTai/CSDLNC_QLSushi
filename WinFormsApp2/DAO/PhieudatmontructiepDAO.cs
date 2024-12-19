using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySuShi.DAO
{
    internal class PhieudatmontructiepDAO
    {
        public static bool CreatePhieuDatMonTrucTiep(string Maphieu, string maban)
        {
            string query = "INSERT INTO PhieuDatMontructiep (MaPhieu, Maban) " +
                           "VALUES (@MaPhieu, @Maban);";

            // Tạo mã phiếu mới
            ;

            // Tạo dictionary chứa tham số
            var parameters = new Dictionary<string, object>
            {
                { "@MaPhieu", Maphieu },
                { "@Maban", maban }
            
            };

            // Gọi hàm thực thi lệnh SQL
            return DataProvider.ExecuteNonQuery(query, parameters);
        }

    }
}
