using QuanLySuShi.Model.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace QuanLySuShi.Controller.DAO
{
    public class HoaDonDAO
    {
        // Thêm hóa đơn mới vào cơ sở dữ liệu
        public static bool AddHoaDon(string mahoadon, string machinhanh, string maphieu, UuDai uuDai)
        {
            string query = "EXEC dbo.sp_AddHoaDon @MaHoaDon, @SoTienGiamGia, @MaUuDai, @MaPhieu, @MaChiNhanh";

            var parameters = new Dictionary<string, object>
            {
                { "@MaHoaDon", mahoadon },
                { "@SoTienGiamGia", uuDai?.GiamGia ?? (object)DBNull.Value },  // Kiểm tra uuDai có null không
                { "@MaUuDai", uuDai?.MaUuDai ?? (object)DBNull.Value },  // Kiểm tra uuDai có null không
                { "@MaPhieu", maphieu },
                { "@MaChiNhanh", machinhanh }
            };

            // Thực thi truy vấn và trả về kết quả
            return DataProvider.ExecuteNonQuery(query, parameters);
        }
        public static HoaDon GetHoaDon(string? MaPhieu = null, string? maHoaDon = null)
        {
            string query = "SELECT * FROM HoaDon WHERE (@MaPhieu is null or  MaPhieu = @MaPhieu) and (@MaHoaDon is null or MaHoaDon = @MaHoaDon)";

            // Định nghĩa tham số cho truy vấn
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@MaPhieu", MaPhieu ?? (object)DBNull.Value},
                { "@MaHoaDon", maHoaDon ?? (object)DBNull.Value}

            };

            // Thực thi truy vấn và lấy dữ liệu
            DataTable dataTable = DataProvider.ExecuteSelectQuery(query, parameters);

            // Nếu tìm thấy dữ liệu, trả về đối tượng HoaDon
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                return HoaDon.FromDataRow(dataTable.Rows[0]);
            }

            return null; // Nếu không tìm thấy, trả về null
        }


        public static string GetNextHoaDon()
        {
            // Câu truy vấn SQL để lấy giá trị lớn nhất của phần số trong mã phiếu
            string query = "SELECT dbo.fn_GetNextHoaDon();";

            DataTable dataTable = DataProvider.ExecuteSelectQuery(query);

            string maxNum = (string)dataTable.Rows[0][0];

            return maxNum;
        }
        public static List<HoaDon> GetHoaDonFromTo(DateTime fromDate, DateTime toDate, string maChiNhanh)
        {
            // Tên Stored Procedure
            string query = "EXEC sp_GetHoaDonFromTo @FromDate, @ToDate, @MaChiNhanh";

            // Danh sách tham số
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@FromDate", fromDate },
                { "@ToDate", toDate },
                { "@MaChiNhanh", maChiNhanh }
            };

            // Thực thi truy vấn và lấy kết quả
            DataTable dataTable = DataProvider.ExecuteSelectQuery(query, parameters);

            // Danh sách kết quả trả về
            List<HoaDon> hoaDonList = new List<HoaDon>();

            // Chuyển đổi từng hàng trong DataTable thành đối tượng HoaDon
            foreach (DataRow row in dataTable.Rows)
            {
                HoaDon hoaDon = HoaDon.FromDataRow(row);
                hoaDonList.Add(hoaDon);
            }

            return hoaDonList;
        }


    }
}
