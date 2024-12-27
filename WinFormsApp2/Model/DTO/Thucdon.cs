using QuanLySuShi.Controller.DAO;
using System;

namespace QuanLySuShi.Model.DTO
{
    public class ThucDon
    {
        public string MaThucDon { get; set; }
        public string TenThucDon { get; set; }
        public string KhuVuc { get; set; }

        public ThucDon(string maThucDon, string tenThucDon, string khuVuc)
        {
            MaThucDon = maThucDon ?? string.Empty;
            TenThucDon = tenThucDon ?? string.Empty;
            KhuVuc = khuVuc ?? string.Empty;
        }

        public ThucDon()
        {
            MaThucDon = string.Empty;
            TenThucDon = string.Empty;
            KhuVuc = string.Empty;
        }

        public static void LoadThucdon(ComboBox? cbbthucdon, string? machinhanh = null )
        {
            
            var listtd = ThucDonDAO.GetThucDon(machinhanh);
            if (listtd == null) return;

            cbbthucdon.Items.Clear();
            foreach (var item in listtd)
            {
                cbbthucdon.Items.Add(item);
                cbbthucdon.DisplayMember = "TenThucDon";
            }
        }
    }
}
