using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using QuanLySuShi.Controller.DAO;
using QuanLySuShi.Model.DTO;

namespace QuanLySuShi
{
    public partial class adminfm : Form
    {
        DataGridViewRow select_row_dtgv = null;
        public adminfm()
        {
            InitializeComponent();
            ChiNhanh.LoadChinhanh(cbbchinhanhdt);
            ChiNhanh.LoadChinhanh(cbbchinhanhds);

            ChiNhanh.LoadChinhanh(cbbchinhanhcns);
            ChiNhanh.LoadChinhanh(cbbchuyenchinhanhcns);

            BoPhan.LoadBoPhan(cbbchuyenbophancns);

        }

     
       
        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void btthongke_Click(object sender, EventArgs e)
        {
            if (cbbchinhanhdt.SelectedIndex == -1)
            {
                MessageBox.Show("vui lòng chọn chi nhánh ");
                return;
            }

            HoaDon.GetHoaDonFromTo(dtbpFromdt, dtbptodt, cbbchinhanhdt, dtgvDoanhthu);
            dtgvDoanhthu.Columns["MaUuDai"].Visible = false;
            dtgvDoanhthu.Columns["MaChiNhanh"].Visible = false;
            decimal tongtien = 0;
            foreach (HoaDon hd in (dtgvDoanhthu.DataSource as List<HoaDon>))
            {
                tongtien += hd.TongTien;
            }
            tbtongdanhthu.Text = tongtien.ToString("c", new CultureInfo("vi-VN"));
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnthongkemonan_Click(object sender, EventArgs e)
        {
            if (cbbchinhanhds.SelectedIndex == -1)
            {
                MessageBox.Show("vui lòng chọn chi nhánh ");
                return;
            }


            DateTime from = DateTime.Parse(dtfromds.Text);
            DateTime to = DateTime.Parse(dtptods.Text);
            string tenmon = tbtenmonands.Text;

            dtgDoanhso.DataSource = MonAnDAO.GetMonAnDaBanFromTo(from, to, (cbbchinhanhds.SelectedItem as ChiNhanh).MaChiNhanh, tenmon);
        }

        private void dtfromds_ValueChanged(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }
        public void LoadNhansu()
        {
            if (cbbchinhanhcns.SelectedIndex == -1)
            {

                return;
            }
            List<NhanVien> nv = NhanvienDAO.GetNhanVienByChiNhanhVaHoTen((cbbchinhanhcns.SelectedItem as ChiNhanh).MaChiNhanh, tbHovatencns.Text);

            dtgvcns.DataSource = nv;
            dtgvcns.Columns["Quanlychinhanh"].Visible = false;
            dtgvcns.Columns["taikhoan"].Visible = false;
            dtgvcns.Columns["matkhau"].Visible = false;
            dtgvcns.Columns["Diachi"].Visible = false;
        }
        private void btTimkiem_Click(object sender, EventArgs e)
        {
           
         LoadNhansu();  
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtgvcns_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Kiểm tra nếu người dùng click vào một dòng hợp lệ (e.RowIndex >= 0)
            if (e.RowIndex >= 0)
            {
                // Lấy dữ liệu từ dòng đã click
                select_row_dtgv = dtgvcns.Rows[e.RowIndex];

                // Lấy dữ liệu từ các cột trong dòng
                string maNhanVien = select_row_dtgv.Cells["MaDinhDanh"].Value.ToString();
                string hoTen = select_row_dtgv.Cells["HoTen"].Value.ToString();
                string maBoPhan = select_row_dtgv.Cells["MaBoPhan"].Value?.ToString();
                string maChiNhanh = select_row_dtgv.Cells["MaChiNhanh"].Value?.ToString();
                string gioiTinh = select_row_dtgv.Cells["GioiTinh"].Value?.ToString();
                string TenBophan = select_row_dtgv.Cells["Bophan"].Value?.ToString();

                // Gọi các phương thức DAO để lấy thông tin chi nhánh, bộ phận nếu cần
                string tenChiNhanh = ChiNhanhDAO.GetChiNhanhByMaChiNhanh(maChiNhanh).TenChiNhanh;

                // Hiển thị thông tin vào các TextBox
                txchinhanhcnsREAD.Text = tenChiNhanh;
                txhovatencnsREAD.Text = hoTen;
                txmanhanviencnsREAD.Text = maNhanVien;
                txgioitinhREAD.Text = gioiTinh;
                txbophanREAD.Text = TenBophan;


                // Nếu cần, bạn có thể hiển thị thêm các thông tin khác.
            }
        }

        private void btnchuyencns_Click(object sender, EventArgs e)
        {
            // Kiểm tra dòng đã được chọn trong DataGridView
            if (select_row_dtgv == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần chuyển.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra chi nhánh mới đã được chọn chưa
            if (cbbchuyenchinhanhcns.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn chi nhánh mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra bộ phận mới đã được chọn chưa
            if (cbbchuyenbophancns.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn bộ phận mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DateTime ngayBatDau = DateTime.Parse(dtpcnsfrom.Text);


            DateTime ngayKetThuc = DateTime.Parse(dtpcnsTo.Text);
            if (ngayKetThuc<= ngayBatDau )
            {
                MessageBox.Show("Vui lòng chọn ngày bắt đầu nhỏ hơn ngày kết thúc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            if (ngayBatDau < DateTime.Now)
            {
                MessageBox.Show("Vui lòng chọn ngày bắt đầu tính từ hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            /// kiem tra lich su lam viec truoc do ngay bat dau phai be hon ngay bau dau cua hien tai 
            
            // Lấy dữ liệu từ các điều khiển
            string maNhanVien = txmanhanviencnsREAD.Text;
            string maBoPhanMoi =(( cbbchuyenbophancns.SelectedItem as BoPhan).MaBoPhan).ToString();
            string maChiNhanhMoi = ((cbbchuyenchinhanhcns.SelectedItem as ChiNhanh).MaChiNhanh).ToString();
           


            // Gọi hàm chuyển nhân sự từ DAO
            bool isSuccess = NhanvienDAO.ChuyenNhanSu(maNhanVien, maBoPhanMoi, maChiNhanhMoi, ngayBatDau, ngayKetThuc);

            // Kiểm tra kết quả
            if (isSuccess)
            {
                MessageBox.Show("Chuyển nhân sự thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadNhansu();
                // Làm mới dữ liệu (nếu cần)
            }
            else
            {
                MessageBox.Show("Chuyển nhân sự thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
