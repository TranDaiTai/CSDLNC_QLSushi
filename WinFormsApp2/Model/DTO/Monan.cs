using QuanLySuShi.Controller.DAO;
using System;

namespace QuanLySuShi.Model.DTO
{
    public class MonAn
    {
        public string MaMonAn { get; set; }  // Mã món ăn
        public string TenMonAn { get; set; } // Tên món ăn
        public decimal GiaTien { get; set; } // Giá tiền
        public bool HoTroGiao { get; set; }  // Hỗ trợ giao
        public string MaMuc { get; set; }    // Mã mức (Liên kết với bảng mức nếu có)

        // Constructor mặc định
        public MonAn() { }

        // Constructor có tham số để khởi tạo từ dữ liệu
        public MonAn(string maMonAn, string tenMonAn, decimal giaTien, bool hoTroGiao, string maMuc)
        {
            MaMonAn = maMonAn;
            TenMonAn = tenMonAn;
            GiaTien = giaTien;
            HoTroGiao = hoTroGiao;
            MaMuc = maMuc;
        }

        // Phương thức khởi tạo từ DataRow (có thể sử dụng để chuyển dữ liệu từ DataTable thành đối tượng)
        public MonAn(System.Data.DataRow row)
        {
            MaMonAn = row["MaMonAn"].ToString();
            TenMonAn = row["TenMonAn"].ToString();
            GiaTien = Convert.ToDecimal(row["GiaTien"]);
            HoTroGiao = Convert.ToBoolean(row["HoTroGiao"]);
            MaMuc = row["MaMuc"].ToString();
        }
        public static void LoadMonAnByMuc(ComboBox cbbmuc, ComboBox cbbmonan)
        {
            cbbmonan.Items.Clear();
            // Lấy MaMuc của mục thực đơn đã chọn
            string maMuc = ((Muc)cbbmuc.SelectedItem).MaMuc;

            // Lấy danh sách món ăn theo MaMuc
            List<MonAn> listMonAn = MonAnDAO.GetMonAn(maMuc: maMuc);

            // Hiển thị danh sách món ăn vào combobox hoặc danh sách món ăn
            cbbmonan.DisplayMember = "TenMonAn"; // Hiển thị tên món ăn
            foreach (var item in listMonAn)
            {
                cbbmonan.Items.Add(item);
                cbbmonan.DisplayMember = "TenMonAn";

            }
        }
        public MonAn(DataGridViewRow row)
        {
            MaMonAn = row.Cells["MaMonAn"].Value.ToString();
            TenMonAn = row.Cells["TenMonAn"].Value.ToString();
            GiaTien = Convert.ToDecimal(row.Cells["GiaTien"].Value);
            HoTroGiao = Convert.ToBoolean(row.Cells["HoTroGiao"].Value);
            MaMuc = row.Cells["MaMuc"].Value.ToString();
        }

        // Phương thức thêm món ăn
        public void AddDish()
        {
            MonAnDAO.AddDish(this);
        }

        // Phương thức cập nhật món ăn
        public void UpdateDish()
        {
            MonAnDAO.UpdateDish(this);
        }
    }
}
