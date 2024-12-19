using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Phieudatmontructiep
{
    public string MaPhieu { get; set; } // primary key
    public string MaBan { get; set; } //   NOT NULL

    // Constructor
    public Phieudatmontructiep(string maPhieu, string maBan)
    {
        MaPhieu = maPhieu;
        MaBan = maBan;
    }

    // Default constructor
    public Phieudatmontructiep(DataRow data) 
    {
        
    }
}

