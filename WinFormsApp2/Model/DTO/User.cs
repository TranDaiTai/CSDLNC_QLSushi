using QuanLySuShi.Controller.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySuShi.Model.DTO
{
    public abstract class User
    {
        public string MaDinhDanh { get; set; } = string.Empty;
        public string HoTen { get; set; } = string.Empty;
        public string? GioiTinh { get; set; }
        public string TaiKhoan { get; set; } = string.Empty;
        public string MatKhau { get; set; } = string.Empty;

        public User() { }

        public User(string maDinhDanh, string hoTen, string? gioiTinh,
                    string taiKhoan, string matKhau)
        {
            MaDinhDanh = maDinhDanh;
            HoTen = hoTen;
            GioiTinh = gioiTinh;
            TaiKhoan = taiKhoan;
            MatKhau = matKhau;
        }
    }

    public class NhanVien : User
    {
        public DateTime? NgaySinh { get; set; }
        public DateTime NgayVaoLam { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public string MaBoPhan { get; set; } = string.Empty;
        public string MaChiNhanh { get; set; } = string.Empty;
        public string? DiaChi { get; set; }
        public string BoPhan { get; set; } = string.Empty;
        public bool QuanlyChiNhanh { get; set; } = false;

        public NhanVien() { }

        public NhanVien(string maNhanVien, string hoTen, DateTime? ngaySinh, string gioiTinh,
                        DateTime ngayVaoLam, DateTime? ngayKetThuc, string maBoPhan,
                        string maChiNhanh, string diaChi, string taiKhoan, string matKhau)
            : base(maNhanVien, hoTen, gioiTinh, taiKhoan, matKhau)
        {
            NgaySinh = ngaySinh;
            NgayVaoLam = ngayVaoLam;
            NgayKetThuc = ngayKetThuc;
            MaBoPhan = maBoPhan;
            MaChiNhanh = maChiNhanh;
            DiaChi = diaChi;
            BoPhan = NhanvienDAO.GetTenBoPhan(maBoPhan);
        }

        public static NhanVien FromDataRow(DataRow row)
        {
            return new NhanVien
            {
                MaDinhDanh = row["MaNhanVien"].ToString(),
                HoTen = row["HoTen"].ToString(),
                GioiTinh = row["GioiTinh"]?.ToString(),
                TaiKhoan = row["TaiKhoan"].ToString(),
                MatKhau = row["MatKhau"].ToString(),
                NgaySinh = row["NgaySinh"] != DBNull.Value ? Convert.ToDateTime(row["NgaySinh"]) : null,
                NgayVaoLam = Convert.ToDateTime(row["NgayVaoLam"]),
                NgayKetThuc = row["NgayKetThuc"] != DBNull.Value ? Convert.ToDateTime(row["NgayKetThuc"]) : null,
                MaBoPhan = row["MaBoPhan"].ToString(),
                MaChiNhanh = row["MaChiNhanh"].ToString(),
                DiaChi = row["DiaChi"]?.ToString(),
                BoPhan = NhanvienDAO.GetTenBoPhan(row["MaBoPhan"].ToString())
            };
        }
    }
    public class KhachHang : User
    {
        public string SoDienThoai { get; set; }     // Số điện thoại
        public string Email { get; set; }           // Email
        public string CCCD { get; set; }            // Căn cước công dân (Unique)

        public KhachHang() { }

        public KhachHang(string maKhachHang, string? hoTen, string? soDienThoai, string? email,
                            string? cccd, string? gioiTinh, string? taiKhoan, string? matKhau)
            : base(maKhachHang, hoTen, gioiTinh, taiKhoan, matKhau)
        {
            SoDienThoai = soDienThoai;
            Email = email;
            CCCD = cccd;
        }
        public static KhachHang FromDataRow(DataRow row)
        {
            return new KhachHang
            {
                MaDinhDanh = row["MaKhachHang"].ToString(),
                HoTen = row["HoTen"].ToString(),
                GioiTinh = row["GioiTinh"]?.ToString(),
                TaiKhoan = row["TaiKhoan"].ToString(),
                MatKhau = row["MatKhau"].ToString(),
                SoDienThoai = row["SoDienThoai"].ToString(),
                Email = row["Email"].ToString(),
                CCCD = row["CCCD"].ToString()
            };

        }



    }
}
