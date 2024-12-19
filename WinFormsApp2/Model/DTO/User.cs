using QuanLySuShi.Controller.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QuanLySuShi.Model.DTO.User;

namespace QuanLySuShi.Model.DTO
{
    public abstract class User
    {
        public string MaDinhDanh { get; set; }       // Mã nhân viên (PK)
        public string HoTen { get; set; }           // Họ tên nhân viên
        public string GioiTinh { get; set; }        // Giới tính (cho phép null)
        public string TaiKhoan { get; set; }        // Tài khoản (unique)
        public string MatKhau { get; set; }         // Mật khẩu

        // Constructor không tham số
        public User() { }

        // Constructor với tham số
        public User(string maDinhDanh, string hoTen, string gioiTinh,
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
        public DateTime? NgaySinh { get; set; }     // Ngày sinh (cho phép null)
        public DateTime NgayVaoLam { get; set; }    // Ngày vào làm
        public DateTime? NgayKetThuc { get; set; }  // Ngày kết thúc làm việc (cho phép null)
        public string MaBoPhan { get; set; }        // Mã bộ phận (FK)
        public string MaChiNhanh { get; set; }      // Mã chi nhánh (FK)
        public string DiaChi { get; set; }          // Địa chỉ (cho phép null)
        public string BoPhan { get; set; }          // Địa chỉ (cho phép null)

        public bool QuanlyChiNhanh { get; set; } = false;      // Địa chỉ (cho phép null)


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
