using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySuShi.Model.DTO
{
    public class TheKhachHang
    {
        public string MaThe { get; set; }           // Mã thẻ (Primary Key)
        public string LoaiThe { get; set; }        // Loại thẻ (cho phép null)
        public int? DiemTichLuy { get; set; }      // Điểm tích lũy (cho phép null)
        public DateTime NgayLap { get; set; }      // Ngày lập thẻ (NOT NULL)
        public string MaNhanVienLapThe { get; set; }     // Mã nhân viên (FK)
        public string MaKhachHang { get; set; }    // Mã khách hàng (FK)

        // Constructor không tham số
        public TheKhachHang() { }

        // Constructor với tham số
        public TheKhachHang(string maThe, string loaiThe, int? diemTichLuy, DateTime ngayLap, string maNhanVien, string maKhachHang)
        {
            MaThe = maThe;
            LoaiThe = loaiThe;
            DiemTichLuy = diemTichLuy;
            NgayLap = ngayLap;
            MaNhanVienLapThe = maNhanVien;
            MaKhachHang = maKhachHang;
        }
    }
}
