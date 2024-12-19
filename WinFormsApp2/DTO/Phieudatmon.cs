using QuanLySuShi.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QuanLySuShi.DTO
{
    public class PhieuDatMon
    {
        public string MaPhieu { get; set; } //   primary key
        public DateTime? NgayLap { get; set; } // [date] NULL
        public string LoaiPhieu { get; set; } // [nvarchar](50) NULL
        public string NhanVienLap { get; set; } //   NULL
        public string MaKhachHang { get; set; } //   NOT NULL
        public string MaChiNhanh { get; set; } //   NOT NULL

        // Constructor
        public PhieuDatMon(string maKhachHang, string maChiNhanh)
        {
            MaPhieu =  PhieudatmonDAO.GeNextPhieuDatMon(); 
            MaKhachHang = maKhachHang;
            MaChiNhanh = maChiNhanh;
        }

        // Optional constructor with all properties
        public PhieuDatMon(string maPhieu, DateTime? ngayLap, string loaiPhieu, string nhanVienLap, string maKhachHang, string maChiNhanh)
        {
            MaPhieu = maPhieu;
            NgayLap = ngayLap;
            LoaiPhieu = loaiPhieu;
            NhanVienLap = nhanVienLap;
            MaKhachHang = maKhachHang;
            MaChiNhanh = maChiNhanh;
        }

        // Constructor lấy dữ liệu từ DataRow
        public PhieuDatMon(DataRow row)
        {
            MaPhieu = row["MaPhieu"].ToString();
            NgayLap = row["NgayLap"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["NgayLap"]);
            LoaiPhieu = row["LoaiPhieu"].ToString();
            NhanVienLap = row["NhanVienLap"].ToString();
            MaKhachHang = row["MaKhachHang"].ToString();
            MaChiNhanh = row["MaChiNhanh"].ToString();
        }
    }
}
