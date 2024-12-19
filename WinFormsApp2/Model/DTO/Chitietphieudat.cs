using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySuShi.Model.DTO
{
    internal class Chitietphieudat
    {
        public string MaMonAn { get; set; } // Primary key (part 1)
        public string MaPhieu { get; set; } // Primary key (part 2)
        public int SoLuong { get; set; } // NOT NULL
        public decimal Gia { get; set; } // NOT NULL (money in SQL)

        // Constructor
        public Chitietphieudat(string maPhieu, string maMonAn, int soLuong, decimal gia)
        {
            MaPhieu = maPhieu;
            MaMonAn = maMonAn;
            SoLuong = soLuong;
            Gia = gia;
        }
        public Chitietphieudat() { }
        // Default constructor
        public Chitietphieudat(DataRow data)
        {
            MaMonAn = data["MaMonAn"].ToString();
            MaPhieu = data["MaPhieu"].ToString();
            SoLuong = Convert.ToInt32(data["SoLuong"]);
            Gia = Convert.ToInt32(data["Gia"]);
        }

    }
}
