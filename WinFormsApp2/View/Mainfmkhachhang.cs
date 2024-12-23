using QuanLySuShi.Controller.DAO;
using QuanLySuShi.Model.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLySuShi
{

    public partial class Mainfmkhachhang : Form
    {
        ListViewItem selectedItem = null;
        DataGridViewRow select_row_dtgv_mon_an = null;
        DataGridViewRow select_row_dtgv_don_hang = null;
        string mauudai = null;

        public Mainfmkhachhang()
        {
            InitializeComponent();
            ChiNhanh.LoadChinhanh(cbbchinhanh);

            listView2.View = View.Details;

            listView2.Columns.Add("Mã món ăn", 100);
            listView2.Columns.Add("Tên món ăn", 100);

            listView2.Columns.Add("Giá", 100);
            listView2.Columns.Add("Số lượng", 100);


            listView1.View = View.Details;
            listView1.Columns.Clear();
            listView1.Columns.Add("Mã phiếu", 100);
            listView1.Columns.Add("Mã món ăn", 100);
            listView1.Columns.Add("Tên món ăn", 100);

            listView1.Columns.Add("Giá", 100);
            listView1.Columns.Add("Số lượng", 100);

            LoadDonHang();
            LoadThongtinThe();
            LoadThongtinKhach();
        }
        void LoadThongtinThe() //Tải thông tin của một thẻ khách hàng
        {
            TheKhachHang tkh = TheKhachHangDAO.GetTheKhachHang(maKhachHang: Dangnhap.user.MaDinhDanh);
            if (tkh != null)
            {
                tbDiem.Text = tkh.DiemTichLuy?.ToString() ?? "";
                tbLoaiThe.Text = tkh.LoaiThe ?? "";
            }
        }

        void LoadThongtinKhach() //Tải thông tin khách hàng
        {
            KhachHang kh = KhachHangDAO.GetKhachHangByMakhachHang(makhach: Dangnhap.user.MaDinhDanh);
            if (kh != null)
            {
                tbhovaten_ql.Text = kh.HoTen;
                tbemail_ql.Text = kh.Email;
                tb_taikhoan.Text = kh.TaiKhoan;
                tbsdt_ql.Text = kh.SoDienThoai;
                cbbgioitinh_ql.Text = kh.GioiTinh;
                tbcccd_ql.Text = kh.CCCD;
            }
        }
        void LoadDonHang() //Tải đơn hànghàng
        {
            dataGridView2.DataSource = PhieudatmonDAO.GetPhieuDatMonByMaKhachHang((Dangnhap.user as KhachHang).MaDinhDanh);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }


        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)  //Đóng cửa sổ hiện tại
        {
            this.Close();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e) // thoát chương trình
        {
            if (MessageBox.Show("Ban co muon thoat chuong trinh", "Canh Bao", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit(); //Kết thúc toàn bộ chương trình
            }
        }

        private void btUuDai_Click(object sender, EventArgs e)
        {
            
        }


        //cập nhật danh sách các mục trong giao diện
        private void cbbthucdon_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Khi người dùng thay đổi thực đơn, tải lại các mục theo thực đơn đã chọn
            Muc.LoadMucByThucdon(cbbmuc, cbbthucdon);
            ThucDon thucdon = cbbthucdon.SelectedItem as ThucDon;

            dataGridView1.DataSource = MonAnDAO.GetMonAn(thucdon.MaThucDon);
        }

        private void cbbMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Khi người dùng thay đổi mục, tải lại các món ăn theo mục đã chọn
            MonAn.LoadMonAnByMuc(cbbmuc, cbbmonan);
            Muc muc = cbbmuc.SelectedItem as Muc;
            ThucDon thucdon = cbbthucdon.SelectedItem as ThucDon;
            dataGridView1.DataSource = MonAnDAO.GetMonAn(thucdon.MaThucDon, muc.MaMuc);
        }

        private void cbbmonan_SelectedIndexChanged(object sender, EventArgs e)
        {
            Muc muc = cbbmuc.SelectedItem as Muc;
            ThucDon thucdon = cbbthucdon.SelectedItem as ThucDon;
            MonAn monan = cbbmonan.SelectedItem as MonAn;

            dataGridView1.DataSource = MonAnDAO.GetMonAn(thucdon.MaThucDon, muc.MaMuc, monan.MaMonAn);
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Kiểm tra xem sự kiện có phải là click vào tiêu đề hàng hay không
            if (e.RowIndex >= 0)
            {
                select_row_dtgv_mon_an = dataGridView1.Rows[e.RowIndex];
                // Tiến hành thao tác với dòng select_row_dtgv
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            // Đảm bảo ListView được cấu hình đúng chế độ hiển thị chi tiết

            // Kiểm tra xem dòng được chọn trong DataGridView có null hay không
            if (select_row_dtgv_mon_an == null)
            {
                return;
            }

            // Lấy món ăn từ dòng được chọn
            MonAn choose = new MonAn(select_row_dtgv_mon_an);

            // Kiểm tra xem mã món ăn đã tồn tại trong ListView hay chưa
            bool isExisting = false;
            foreach (ListViewItem item in listView2.Items)
            {
                if (item.SubItems[0].Text == choose.MaMonAn) // Cột "Mã món ăn" (SubItem[1])
                {
                    // Nếu đã tồn tại, tăng số lượng
                    int currentQuantity = int.Parse(item.SubItems[3].Text); // Cột "Số lượng" (SubItem[3])
                    currentQuantity += Convert.ToInt32(numericUpDown1.Value);
                    item.SubItems[3].Text = currentQuantity.ToString();
                    isExisting = true;
                    break;
                }
            }

            // Nếu mã món ăn chưa tồn tại, thêm mới một dòng
            if (!isExisting)
            {
                // Sử dụng object tạm để lưu thông tin
                var tempItem = new
                {
                    MaMonAn = choose.MaMonAn,
                    TenMonAn = choose.TenMonAn,
                    Gia = choose.GiaTien,
                    SoLuong = Convert.ToInt32(numericUpDown1.Value)
                };

                ListViewItem newItem = new ListViewItem(tempItem.MaMonAn);
                newItem.SubItems.Add(tempItem.TenMonAn.ToString());
                newItem.SubItems.Add(tempItem.Gia.ToString());
                newItem.SubItems.Add(tempItem.SoLuong.ToString());
                listView2.Items.Add(newItem);
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (selectedItem != null)
            {
                listView2.Items.Remove(selectedItem);
                MessageBox.Show("Mục đã được xóa!");
            }
            else
            {
                MessageBox.Show("Không có mục nào để xóa.");
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                // Lấy dòng (item) được chọn
                selectedItem = listView2.SelectedItems[0];
            }
        }

        private void btdathang_Click(object sender, EventArgs e)
        {
            string loaiphieudat = "Trực Tuyến";
            if (cbbchinhanh.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn chi nhánh!");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ!");
                return;
            }
            if (listView2.Items.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn món ăn!");
                return;
            }
            string ghichu = tbghichu.Text; // Lấy giá trị ghi chú từ TextBox
            string maphieumoi = PhieudatmonDAO.GeNextPhieuDatMon();

            // Tạo phiếu đặt món
            bool isSuccess = PhieudatmonDAO.CreatePhieuDatMon(null, Dangnhap.user.MaDinhDanh, (cbbchinhanh.SelectedItem as ChiNhanh).MaChiNhanh, maphieumoi, loaiphieudat);

            if (isSuccess)
            {
                // Tạo phiếu giao đi
                if (PhieuDatMonGiaoDiDAO.CreatePhieuDatMonGiaoDi(maphieumoi, DateTime.Now, null, tbghichu.Text, null, txtDiaChi.Text))
                {
                    MessageBox.Show("Tạo Phiếu và Thêm món ăn vào phiếu thành công!", "Thông báo");

                    // Duyệt qua các món ăn trong ListView để thêm chi tiết vào phiếu
                    foreach (ListViewItem item in listView2.Items)
                    {
                        // Lấy mã món ăn từ item
                        string maMonAn = item.SubItems[0].Text;

                        // Lấy số lượng từ item
                        int soLuong = int.Parse(item.SubItems[3].Text); // Chú ý đến chỉ mục đúng

                        // Tạo chi tiết phiếu đặt món

                        // Thêm chi tiết phiếu vào cơ sở dữ liệu
                        // (Ví dụ: gọi phương thức để lưu chi tiết vào cơ sở dữ liệu)
                        bool isDetailAdded = ChitietphieuDAO.AddChitietPhieu(maphieumoi, maMonAn, soLuong);

                        // Bạn có thể kiểm tra việc thêm chi tiết thành công ở đây nếu cần
                    }
                }
                CultureInfo culture = new CultureInfo("vi-VN");
                string mahoadon = HoaDonDAO.GetNextHoaDon();
                HoaDonDAO.AddHoaDon(mahoadon, (cbbchinhanh.SelectedItem as ChiNhanh).MaChiNhanh, maphieumoi, UuDaiDAO.GetUuDais(maUuDai: mauudai)[0]);

                listView2.Items.Clear();
                txtDiaChi.Clear();
                tbghichu.Clear();
                LoadDonHang();
            }
        }

        private void cbbchinhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChiNhanh cn = cbbchinhanh.SelectedItem as ChiNhanh; ;
            ThucDon.LoadThucdon(cbbthucdon, cn.MaChiNhanh);
            dataGridView1.DataSource = MonAnDAO.GetMonAn(maChiNhanh: (cn).MaChiNhanh);

        }

        private void btDatBan_Click(object sender, EventArgs e)
        {
            
        }


        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void Mainfmkhachhang_Load(object sender, EventArgs e)
        {
            
        }

        private void btTimkiem_Click(object sender, EventArgs e)
        {
            // Lấy từ khóa từ TextBox
            string keyword = tbTimkiem.Text.Trim();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Thông Báo");
                return;
            }

            // Gọi phương thức tìm kiếm
            List<Chitietphieudat> result = ChitietphieuDAO.searchChiTietPhieuDatMon(keyword);

            if (result != null && result.Count > 0)
            {
                // Hiển thị kết quả lên ListView
                listView1.Items.Clear();

                foreach (var chiTiet in result)
                {
                    ListViewItem item = new ListViewItem(chiTiet.MaMonAn);
                    item.SubItems.Add(chiTiet.MaPhieu);
                    item.SubItems.Add(chiTiet.SoLuong.ToString());
                    item.SubItems.Add(chiTiet.Gia.ToString("C")); // Format tiền tệ

                    listView1.Items.Add(item);
                }
            }
        }


        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy dòng được chọn
                select_row_dtgv_don_hang = dataGridView2.Rows[e.RowIndex];

                // Lấy giá trị MaPhieu từ dòng được chọn
                string maPhieu = select_row_dtgv_don_hang.Cells["MaPhieu"].Value.ToString();

                // Gọi hàm lấy danh sách chi tiết phiếu đặt món theo MaPhieu
                List<Chitietphieudat> chiTietPhieu = ChitietphieuDAO.GetChitietPhieuByMaPhieu(maPhieu);

                // Cập nhật listView1
                listView1.Items.Clear(); // Xóa toàn bộ các mục cũ trong listView2
                foreach (var ct in chiTietPhieu)
                {
                    // Tạo item mới từ chi tiết phiếu đặt
                    ListViewItem item = new ListViewItem(ct.MaPhieu);
                    item.SubItems.Add(ct.MaMonAn);
                    MonAn monAn = MonAnDAO.GetMonAn(maMonAn: ct.MaMonAn)[0];
                    item.SubItems.Add(monAn.TenMonAn);
                    item.SubItems.Add(ct.Gia.ToString());
                    item.SubItems.Add(ct.SoLuong.ToString());

                    // Thêm item vào listView2
                    listView1.Items.Add(item);
                }
            }
        }

        private void btuudai_Click_1(object sender, EventArgs e)
        {
            TheKhachHang tkh = TheKhachHangDAO.GetTheKhachHang(maKhachHang: Dangnhap.user.MaDinhDanh);
            if (tkh == null)
            {
                MessageBox.Show("Tài khoản chưa đăng ký thẻ khách hàng", "Thông Báo");
                return;
            }

            List<UuDai> lsUuDai = UuDaiDAO.GetUuDais(loaiTheApDung: tkh.LoaiThe);

            // Kiểm tra nếu không có ưu đãi nào
            if (lsUuDai == null || lsUuDai.Count == 0)
            {
                MessageBox.Show("Không có ưu đãi áp dụng cho loại thẻ của bạn", "Thông Báo");
                return;
            }

            // Mở form phụ để hiển thị danh sách ưu đãi
            fmUuDais frm = new fmUuDais(lsUuDai);
            frm.ShowDialog();

            // Kiểm tra nếu người dùng chọn một ưu đãi
            if (frm.uuDai != null)
            {
                mauudai = frm.uuDai.Cells["MaUuDai"].Value?.ToString();
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn ưu đãi nào.", "Thông Báo");
            }

        }

        private void btdatban_Click_1(object sender, EventArgs e)
        {

        }

        private void btdanhgia_Click(object sender, EventArgs e)
        {
             
        }

        private void Mainfmkhachhang_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.dangnhapForm.Show();
        }
    }
}
