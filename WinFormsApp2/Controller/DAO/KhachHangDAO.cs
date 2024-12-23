using QuanLySuShi.Model.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySuShi.Controller.DAO
{
    internal class KhachHangDAO
    {
        //Lấy khách hàng bằng tài khoảnkhoản
        public static KhachHang GetKhachHangByTaiKhoan(string taiKhoan)
        {
            string query = "SELECT * FROM KhachHang WHERE TaiKhoan = @TaiKhoan";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@TaiKhoan", taiKhoan },

            };

            DataTable dataTable = DataProvider.ExecuteSelectQuery(query, parameters);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                return KhachHang.FromDataRow(row);  // Sử dụng phương thức FromDataRow để tạo đối tượng từ DataRow
            }
            return null;
        }

        //Lấy khách hàng 
        public static string GetNextMakhachhang()
        {
            // Câu truy vấn SQL để lấy giá trị lớn nhất của phần số trong mã phiếu
            string query = "select dbo.fn_GetNextKhachHang() ;";


            DataTable dataTable = DataProvider.ExecuteSelectQuery(query);

            return (string)dataTable.Rows[0][0];
        }

        //Tạo khách hàng
        public static bool CreatKhachHang(KhachHang khachHang)
        {
            string query = "EXEC sp_CreateKhachHang @MaKhachHang,@HoTen,@SoDienThoai,@Email,@CCCD,@GioiTinh,@MatKhau,@TaiKhoan";
            
            //Tạo tham số truy vấn
            var parameters = new Dictionary<string, object>
            {
                { "@MaKhachHang", khachHang.MaDinhDanh },
                { "@HoTen", (object)khachHang.HoTen ?? DBNull.Value },
                { "@SoDienThoai", (object)khachHang.SoDienThoai?? DBNull.Value },
                { "@Email", (object)khachHang.Email?? DBNull.Value },
                { "@CCCD", (object)khachHang.CCCD ?? DBNull.Value},
                { "@GioiTinh", string.IsNullOrEmpty(khachHang.GioiTinh) ? DBNull.Value : khachHang.GioiTinh },
                { "@TaiKhoan", (object)khachHang.TaiKhoan ?? DBNull.Value},
                { "@MatKhau",(object) khachHang.MatKhau ?? DBNull.Value}
            };

            // Gọi hàm thực thi câu lệnh SQL
            return DataProvider.ExecuteNonQuery(query, parameters);
        }

        // 
        public static string MaKhachHangByMaPhieu(string Maphieu)
        {
            // Câu truy vấn SQL
            string query = "SELECT * FROM KhachHang join PhieuDatMon on KhachHang.MaKhachHang = PhieuDatMon.MaKhachHang AND @MaPhieu =PhieuDatMon.MaPhieu ";

            // Tạo tham số truy vấn
            var parameters = new Dictionary<string, object>()
            {
                {"@MaPhieu", Maphieu}
            };

            // Thực thi truy vấn
            DataTable result = DataProvider.ExecuteSelectQuery(query, parameters);
            return (string)result.Rows[0]["MaKhachHang"];
        }
        public static KhachHang GetKhachHangByMakhachHang(string makhach)
        {
            string query = "SELECT * FROM KhachHang WHERE Makhachhang = @Makhachhang";

            // Tạo tham số truy vấn
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@Makhachhang", makhach },

            };

            DataTable dataTable = DataProvider.ExecuteSelectQuery(query, parameters);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                return KhachHang.FromDataRow(row);  // Sử dụng phương thức FromDataRow để tạo đối tượng từ DataRow
            } 
            return null;
        }


    }
}
