using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QuanLySuShi.DTO;

namespace QuanLySuShi.DAO
{
    public class DangNhapDAO
    {
     
        public static bool TryDangNhapKH(string taikhoan, string matkhau)
        {
           
            string query = "SELECT taikhoan, matkhau FROM khachhang where taikhoan =@taikhoan and matkhau = @matkhau";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@taikhoan",taikhoan},
                {"@matkhau",matkhau}
            };
            DataTable data= DataProvider.ExecuteSelectQuery(query, parameters);
            return data.Rows.Count > 0;
        }

        public static bool TryDangNhapNV(string taikhoan, string matkhau)
        {

            string query = "SELECT taikhoan, matkhau FROM nhanvien where taikhoan =@taikhoan and matkhau = @matkhau";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@taikhoan",taikhoan},
                {"@matkhau",matkhau}
            };
            DataTable data = DataProvider.ExecuteSelectQuery(query, parameters);

            return data.Rows.Count > 0;

        }
    }
}
