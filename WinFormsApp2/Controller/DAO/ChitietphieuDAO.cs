using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuanLySuShi.Model.DTO;

namespace QuanLySuShi.Controller.DAO
{
    internal class ChitietphieuDAO
    {
        public static bool AddChitietPhieu(string MaPhieu, string MaMonAn, int SoLuong)
        {
            // Tên stored procedure
            string storedProcedure = "EXEC sp_AddOrUpdateChiTietPhieu @id_phieu, @id_mon_an, @so_luong";

            // Tạo dictionary chứa các tham số
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@id_phieu", MaPhieu },
                { "@id_mon_an", MaMonAn },
                { "@so_luong", SoLuong }
            };

            // Gọi stored procedure và trả về kết quả
            return DataProvider.ExecuteNonQuery(storedProcedure, parameters);
        }



        public static bool XoaMonAnTheoPhieu(string maMonAn, string maPhieu)
        {
            // Câu lệnh gọi stored procedure với hai tham số
            string query = "EXEC sp_XoaMonAnTheoMaPhieu @MaMonAn, @MaPhieu";

            // Tạo tham số đầu vào cho stored procedure
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@MaMonAn", maMonAn },
                {"@MaPhieu", maPhieu }
            };

            // Thực thi câu lệnh
            return DataProvider.ExecuteNonQuery(query, parameters);
        }

        public static List<Chitietphieudat> GetChitietPhieuByMaPhieu(string maPhieu)
        {
            if (string.IsNullOrEmpty(maPhieu))
            {
                throw new ArgumentException("maPhieu cannot be null or empty");
            }

            List<Chitietphieudat> list = new List<Chitietphieudat>();
            string query = "SELECT * FROM Chitietphieudat WHERE MaPhieu = @MaPhieu";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@MaPhieu", maPhieu }
            };

            DataTable data = DataProvider.ExecuteSelectQuery(query, parameters);

            if (data != null)
            {
                foreach (DataRow datarow in data.Rows)
                {
                    Chitietphieudat ctpd = new Chitietphieudat(datarow);
                    list.Add(ctpd);
                }
            }

            return list;
        }

        public static List<Chitietphieudat> searchChiTietPhieuDatMon(string keyword)
        {
            List<Chitietphieudat> list = new List<Chitietphieudat>();

            string query = @"
            SELECT ctpdm.MaPhieu, ctpdm.MaMonAn, ctpdm.Gia, ctpdm.SoLuong
            FROM ChiTietPhieuDat ctpdm
            WHERE ctpdm.MaMonAn LIKE @keyword 
            OR ctpdm.MaPhieu LIKE @keyword";

            var parameters = new Dictionary<string, object>
            {
                { "@keyword", "%" + keyword + "%" }
            };

            DataTable data = DataProvider.ExecuteSelectQuery(query, parameters);

            if (data != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    Chitietphieudat chiTiet = new Chitietphieudat(row);
                    list.Add(chiTiet);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy chi tiết phiếu đặt món phù hợp!", "Thông Báo");
            }

            return list;
        }

        public static Chitietphieudat Get1ChitietPhieuByMaPhieu(string maPhieu)
        {
            if (string.IsNullOrEmpty(maPhieu))
            {
                throw new ArgumentException("maPhieu cannot be null or empty");
            }

            Chitietphieudat ct = new Chitietphieudat();
            string query = "SELECT * FROM Chitietphieudat WHERE MaPhieu = @MaPhieu";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@MaPhieu", maPhieu }
            };

            DataTable data = DataProvider.ExecuteSelectQuery(query, parameters);

            if (data != null)
            {
                foreach (DataRow datarow in data.Rows)
                {
                    Chitietphieudat ctpd = new Chitietphieudat(datarow);
                    ct = ctpd;
                }
            }

            return ct;
        }

        public static decimal GetTongSoTienByMaPhieu(string maPhieu)
        {
            string query = "SELECT SUM(Gia) AS TongSoTien FROM ChiTietPhieuDat WHERE MaPhieu = @MaPhieu";

            var parameters = new Dictionary<string, object>
            {
                { "@MaPhieu", maPhieu }
            };

            DataTable data = DataProvider.ExecuteSelectQuery(query, parameters);

            if (data.Rows.Count > 0 && data.Rows[0]["TongSoTien"] != DBNull.Value)
            {
                return Convert.ToDecimal(data.Rows[0]["TongSoTien"]);
            }

            return 0; // Trả về 0 nếu không có dữ liệu
        }

    }
}
