using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySuShi.DTO
{
    internal class PhieuDatMonTrucTuyen
    {
        public string MaPhieu { get; set; } // Primary key
        public DateTime? NgayGio { get; set; } // [datetime] NULL
        public string TinhTrang { get; set; } //  public int? Phi { get; set; } // [int] NULL
        public string DiaChi { get; set; } //   NOT NULL

         public PhieuDatMonTrucTuyen(DataRow row)
         {
            MaPhieu = row["MaPhieu"].ToString();
            NgayGio = row["NgayGio"] == DBNull.Value ? null : (DateTime?)row["NgayGio"];
            TinhTrang = row["TinhTrang"].ToString();
            Phi = row["Phi"] == DBNull.Value ? null : (int?)row["Phi"];
            DiaChi = row["DiaChi"].ToString();
         }

        // Default constructor
        public PhieuDatMonTrucTuyen() { }
    }

    internal class PhieuDatMonGiaoDi: PhieuDatMonTrucTuyen
    {
        public DateTime? NgayGio { get; set; } // [datetime] NULL
        public string TinhTrang { get; set; } //      public int? Phi { get; set; } // [int] NULL
        public string DiaChi { get; set; } //   NOT NULL

        public PhieuDatMonGiaoDi(DataRow row) : base(row)
        {
            NgayGio = row["NgayGio"] == DBNull.Value ? null : (DateTime?)row["NgayGio"];
            TinhTrang = row["TinhTrang"].ToString();
            Phi = row["Phi"] == DBNull.Value ? null : (int?)row["Phi"];
            DiaChi = row["DiaChi"].ToString();
        }
    }


    internal class PhieuDatMonTaiQuan : PhieuDatMonTrucTuyen
    {
        public int? SoLuongKhach { get; set; } // [int] NULL
        public string MaBan { get; set; } //   NULL
        public DateTime? get; set; } // [date] NULL

        // Constructor to create from DataRow
        public PhieuDatMonTaiQuan(DataRow row) : base(row)
        {
            SoLuongKhach = row["SoLuongKhach"] == DBNull.Value ? null : (int?)row["SoLuongKhach"];
            MaBan = row["MaBan"].ToString();
            NgayDat = row["NgayDat"] == DBNull.Value ? null : (DateTime?)row["NgayDat"];
        }
    }

}
