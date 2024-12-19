using QuanLySuShi.DAO;
using System;
using System.Data;

namespace QuanLySuShi.DTO
{
    public class Muc
    {
        public string MaMuc { get; set; }
        public string TenMuc { get; set; }
        public string MaThucDon { get; set; }

        // Constructor để khởi tạo đối tượng Muc từ các giá trị
        public Muc(string maMuc, string tenMuc, string maThucDon)
        {
            MaMuc = maMuc;
            TenMuc = tenMuc;
            MaThucDon = maThucDon;
        }
        public Muc(DataRow row)
        {

            MaMuc = row["MaMuc"].ToString();
            TenMuc = row["TenMuc"].ToString();
            MaThucDon = row["MaThucDon"].ToString();
        }

        public static void LoadMucByThucdon(ComboBox cbbmuc ,ComboBox cbbthucdon)
        {
            // Lấy MaThucDon của thực đơn đã chọn
            string maThucDon = ((ThucDon)cbbthucdon.SelectedItem).MaThucDon;
            cbbmuc.Items.Clear();
            // Lấy danh sách các mục (mục thực đơn) theo MaThucDon
            List<Muc> listMuc = MucDAO.GetMucs(maThucDon:maThucDon);

           
            foreach (var item in listMuc)
            {
                cbbmuc.Items.Add(item);
                cbbmuc.DisplayMember = "TenMuc";

            }
        }
    }

}
