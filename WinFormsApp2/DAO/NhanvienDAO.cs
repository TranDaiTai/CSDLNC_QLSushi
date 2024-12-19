using QuanLySuShi.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySuShi.DAO
{
    public class NhanvienDAO
    {
        // Lấy thông tin nhân viên theo mã nhân viên
        public static NhanVien GetNhanVienByMaNhanVien(string maNhanVien)
        {
            string query = "SELECT * FROM NhanVien  WHERE MaNhanVien = @MaNhanVien";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@MaNhanVien", maNhanVien }
            };

            DataTable dataTable = DataProvider.ExecuteSelectQuery(query, parameters);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                return NhanVien.FromDataRow(row);  // Sử dụng phương thức FromDataRow để tạo đối tượng từ DataRow
            }
            return null;
        }

        public static NhanVien GetNhanVienByTaiKhoan(string taiKhoan)
        {
            string query = "SELECT * FROM NhanVien WHERE TaiKhoan = @TaiKhoan";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@TaiKhoan", taiKhoan },
             
            };

            DataTable dataTable = DataProvider.ExecuteSelectQuery(query, parameters);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                return NhanVien.FromDataRow(row);  // Sử dụng phương thức FromDataRow để tạo đối tượng từ DataRow
            }
            return null;
        }

        public static List<NhanVien> GetAllNhanVien()
        {
            List<NhanVien> nhanViens = new List<NhanVien>();
            string query = "SELECT * FROM NhanVien";

            DataTable dataTable = DataProvider.ExecuteSelectQuery(query);

            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    NhanVien nhanVien = NhanVien.FromDataRow(row);  // Sử dụng phương thức FromDataRow để tạo đối tượng từ DataRow
                    nhanViens.Add(nhanVien);
                }
            }

            return nhanViens;
        }
        public static string GetTenBoPhan(string mabophan )
        {
            string tenbp = null;
            string query = "select tenbophan from bophan where mabophan =@mabophan";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@MaBoPhan", mabophan }
            };

            // Thực thi truy vấn
            DataTable dataTable = DataProvider.ExecuteSelectQuery(query, parameters);

            // Kiểm tra kết quả trả về
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                tenbp = dataTable.Rows[0]["TenBoPhan"]?.ToString();
            }

            return tenbp; // Trả về tên bộ phận (hoặc null nếu không tìm thấy)
        }
        public static bool Is_QuanLy(string manhanvien)
        {
            string query = "SELECT COUNT(1) FROM chinhanh JOIN nhanvien ON nhanvien.machinhanh = chinhanh.machinhanh WHERE Chinhanh.MaNhanVienQuanLy = @manhanvien";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@manhanvien", manhanvien }
            };

            // Thực thi truy vấn và lấy một giá trị duy nhất
            object result = DataProvider.ExecuteScalarQuery(query, parameters);

            // Kiểm tra nếu có kết quả
            if (result != null && Convert.ToInt32(result) > 0)
            {
                return true; // Nếu có dòng nào trả về, tức là nhân viên là quản lý
            }

            return false; // Nếu không có kết quả, nhân viên không phải quản lý
        }
        public static List<NhanVien> GetNhanVienByChiNhanhVaHoTen(string maChiNhanh, string hoTen)
        {
            List<NhanVien> nhanViens = new List<NhanVien>();

            // Truy vấn SQL để lấy nhân viên theo mã chi nhánh và họ tên
            string query = @"
            SELECT * FROM NhanVien 
            WHERE MaChiNhanh = @MaChiNhanh 
            AND HoTen LIKE @HoTen";

            // Tạo đối tượng chứa các tham số cho truy vấn
            Dictionary<string, object> parameters = new Dictionary<string, object>
        {
            { "@MaChiNhanh", maChiNhanh },
            { "@HoTen", "%" + hoTen + "%" } // Sử dụng LIKE để tìm kiếm theo họ tên
        };

            // Thực thi truy vấn và nhận kết quả từ cơ sở dữ liệu
            DataTable dataTable = DataProvider.ExecuteSelectQuery(query, parameters);

            // Kiểm tra nếu có dữ liệu trả về
            if (dataTable != null)
            {
                // Lặp qua các dòng dữ liệu và tạo đối tượng NhanVien
                foreach (DataRow row in dataTable.Rows)
                {
                    NhanVien nhanVien = NhanVien.FromDataRow(row);
                    nhanViens.Add(nhanVien); // Thêm vào danh sách kết quả
                }
            }

            return nhanViens;
        }
        public static bool ChuyenNhanSu(string maNhanVien, string maBoPhanMoi, string maChiNhanhMoi, DateTime ngayBatDau, DateTime? ngayKetThuc)
        {

            // Bước 1: Cập nhật thông tin của nhân viên trong bảng NhanVien
            string query = "sp_ChuyenNhanSu @MaNhanVien,@MaBoPhanMoi,@MaChiNhanhMoi,@NgayBatDau,@NgayKetThuc";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@MaNhanVien", maNhanVien },
                { "@MaBoPhanMoi", maBoPhanMoi },
                { "@MaChiNhanhMoi", maChiNhanhMoi },
                { "@NgayBatDau", ngayBatDau},
                { "@NgayKetThuc" , ngayKetThuc }
            };


            return DataProvider.ExecuteNonQuery(query, parameters);
            
        }

        public static string GetMaxLSLV()
        {
            // Câu truy vấn SQL để lấy giá trị lớn nhất của phần số trong mã phiếu
            string query = @"
                SELECT TOP 1 
                    MAX(CAST(SUBSTRING(MaLS, 3, LEN(MaLS)) AS INT)) AS MaxNum
                FROM LichSuLamViec
                WHERE MaLS LIKE 'LS%'
                GROUP BY MaLS
                ORDER BY MaxNum DESC;
            ";

            DataTable dataTable = DataProvider.ExecuteSelectQuery(query);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                int maxNum = Convert.ToInt32(dataTable.Rows[0]["MaxNum"]);

                // Tạo mã phiếu tiếp theo bằng cách tăng giá trị maxNum
                string newPhieu = "LS" + (maxNum + 1); // Đảm bảo định dạng 3 chữ số
                return newPhieu;
            }
            else
            {
                // Nếu không có phiếu nào, trả về mã phiếu đầu tiên là PD001
                return "LS001";
            }
        }

    }
}
