using QuanLySuShi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QuanLySuShi.DTO
{
    public class UuDai
    {
        public string MaUuDai { get; set; } // primary key
        public decimal? GiamGia { get; set; } // [money] NULL
        public string ChuongTrinh { get; set; } //  public string TangSanPham { get; set; } //   NULL
        public double? UuDaiChietKhau { get; set; } // [float] NULL
        public string LoaiTheApDung { get; set; } //   NULL
        public DateTime NgayBatDau { get; set; } // [date] NOT NULL
        public DateTime NgayKetThuc { get; set; } // [date] NOT NULL

    // Constructor
        public UuDai(string maUuDai, DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            MaUuDai = maUuDai;
            NgayBatDau = ngayBatDau;
            NgayKetThuc = ngayKetThuc;
        }

        // Optional constructor with all properties
        public UuDai(string maUuDai, decimal? giamGia, string chuongTrinh, string tangSanPham,
                     double? uuDaiChietKhau, string loaiTheApDung, DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            MaUuDai = maUuDai;
            GiamGia = giamGia;
            ChuongTrinh = chuongTrinh;
            UuDaiChietKhau = uuDaiChietKhau;
            LoaiTheApDung = loaiTheApDung;
            NgayBatDau = ngayBatDau;
            NgayKetThuc = ngayKetThuc;
        }

        // Default constructor
        public UuDai() { }

        // Convert DataRow to UuDai object
        public static UuDai FromDataRow(System.Data.DataRow row)
        {
            return new UuDai
            {
                MaUuDai = row["MaUuDai"].ToString(),
                GiamGia = row["GiamGia"] != DBNull.Value ? (decimal?)row["GiamGia"] : null,
                ChuongTrinh = row["ChuongTrinh"].ToString(),
                UuDaiChietKhau = row["UuDaiChietKhau"] != DBNull.Value ? (double?)row["UuDaiChietKhau"] : null,
                LoaiTheApDung = row["LoaiTheApDung"].ToString(),
                NgayBatDau = Convert.ToDateTime(row["NgayBatDau"]),
                NgayKetThuc = Convert.ToDateTime(row["NgayKetThuc"])
            };
        }
    }
}