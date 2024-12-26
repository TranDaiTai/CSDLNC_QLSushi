using QuanLySuShi.Controller.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySuShi.Model.DTO
{
    public class BoPhan
    {
        public string MaBoPhan { get; set; }   // Mã bộ phận (PK)
        public string TenBoPhan { get; set; }  // Tên bộ phận (UNIQUE)
        public decimal Luong { get; set; }     // Lương (money)

        // Constructor mặc định
        public BoPhan() { }

        // Constructor với tham số
        public BoPhan(string maBoPhan, string tenBoPhan, decimal luong)
        {
            MaBoPhan = maBoPhan;
            TenBoPhan = tenBoPhan;
            Luong = luong;
        }

        // Phương thức chuyển đổi từ DataRow sang đối tượng BoPhan
        public static BoPhan FromDataRow(DataRow row)
        {
            return new BoPhan
            {
                MaBoPhan = row["MaBoPhan"].ToString(),
                TenBoPhan = row["TenBoPhan"].ToString(),
                Luong = Convert.ToDecimal(row["Luong"])
            };
        }
        public static void LoadBoPhan(ComboBox cbx)
        {
            cbx.Items.Clear();
            List<BoPhan> listbophans = BoPhanDAO.GetBoPhan();
            
            foreach (var item in listbophans)
            {
                cbx.Items.Add(item);
                cbx.DisplayMember = "TenBoPhan";
            }
        }

        public override string ToString()
        {
            return TenBoPhan; // Trả về tên bộ phận để hiển thị trong ComboBox
        }
    }
}
