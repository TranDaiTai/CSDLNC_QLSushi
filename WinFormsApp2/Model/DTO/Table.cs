using QuanLySuShi.Controller.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySuShi.Model.DTO
{
    public class Table
    {
        public string TableID { get; set; }
        public string TableName { get; set; }
        public string Status { get; set; } // Trống, Đang dùng, Đã đặt

        public static int btnWidth = 90;
        public static int btnHeight = 90;

        public Table(string id, string name, string status)
        {
            TableID = id;
            TableName = name;
            Status = status;

        }
        // Phương thức để kiểm tra trạng thái của bàn
        public static string GetTableStatus(string tableId)
        {
            var query = "SELECT pdm.maphieu " +
                        "FROM PhieuDatMon pdm " +
                        "LEFT JOIN HoaDon hd ON pdm.MaPhieu = hd.MaPhieu " +
                        "JOIN PhieuDatMonTrucTiep tt ON pdm.MaPhieu = tt.MaPhieu " +
                        "WHERE hd.MaHoaDon IS NULL AND tt.maban = @TableId";

            var parameters = new Dictionary<string, object>
    {
        { "@TableId", tableId }
    };

            DataTable dataTable = DataProvider.ExecuteSelectQuery(query, parameters);

            // Nếu có kết quả trả về, bàn có khách (không trống)
            return dataTable.Rows.Count > 0 ? "Có khách" : "Trống";
        }

        // Cập nhật danh sách Tables với trạng thái thực tế
        public static List<Table> Tables = new List<Table>
        {
            new Table("B01", "Bàn 1", GetTableStatus("B01")),
            new Table("B02", "Bàn 2", GetTableStatus("B02")),
            new Table("B03", "Bàn 3", GetTableStatus("B03")),
            new Table("B04", "Bàn 4", GetTableStatus("B04")),
            new Table("B05", "Bàn 5", GetTableStatus("B05")),
            new Table("B06", "Bàn 6", GetTableStatus("B06")),
            new Table("B07", "Bàn 7", GetTableStatus("B07")),
            new Table("B08", "Bàn 8", GetTableStatus("B08")),
            new Table("B09", "Bàn 9", GetTableStatus("B09")),
            new Table("B010", "Bàn 10", GetTableStatus("B010")),
            new Table("B011", "Bàn 11", GetTableStatus("B011")),
            new Table("B012", "Bàn 12", GetTableStatus("B012")),
            new Table("B013", "Bàn 13", GetTableStatus("B013")),
            new Table("B014", "Bàn 14", GetTableStatus("B014")),
            new Table("B015", "Bàn 15", GetTableStatus("B015")),
            new Table("B016", "Bàn 16", GetTableStatus("B016"))
        };




    }
}

