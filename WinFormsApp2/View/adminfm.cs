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
            SetInputState(false);
            LoadComboBoxData();
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
            try
            {
                if (cbbchinhanhcns?.SelectedIndex == -1 || cbbchinhanhcns?.SelectedItem == null)
                {
                    return;
                }

                var selectedChiNhanh = cbbchinhanhcns.SelectedItem as ChiNhanh;
                if (selectedChiNhanh == null)
                {
                    MessageBox.Show("Vui lòng chọn chi nhánh hợp lệ", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string searchText = tbHovatencns?.Text?.Trim() ?? string.Empty;
                List<NhanVien> nv = NhanvienDAO.GetNhanVienByChiNhanhVaHoTen(
                    selectedChiNhanh.MaChiNhanh, 
                    searchText);

                if (dtgvcns != null)
                {
                    dtgvcns.DataSource = nv;
                    dtgvcns.Columns["Quanlychinhanh"].Visible = false;
                    dtgvcns.Columns["taikhoan"].Visible = false;
                    dtgvcns.Columns["matkhau"].Visible = false;
                    dtgvcns.Columns["Diachi"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách nhân sự: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            if (e.RowIndex >= 0)
            {
                select_row_dtgv = dtgvcns.Rows[e.RowIndex];

                string maNhanVien = select_row_dtgv.Cells["MaDinhDanh"].Value.ToString();
                string hoTen = select_row_dtgv.Cells["HoTen"].Value.ToString();
                string maBoPhan = select_row_dtgv.Cells["MaBoPhan"].Value?.ToString();
                string maChiNhanh = select_row_dtgv.Cells["MaChiNhanh"].Value?.ToString();
                string gioiTinh = select_row_dtgv.Cells["GioiTinh"].Value?.ToString();
                string TenBophan = select_row_dtgv.Cells["Bophan"].Value?.ToString();

                string tenChiNhanh = ChiNhanhDAO.GetChiNhanhByMaChiNhanh(maChiNhanh).TenChiNhanh;

                txchinhanhcnsREAD.Text = tenChiNhanh;
                txhovatencnsREAD.Text = hoTen;
                txmanhanviencnsREAD.Text = maNhanVien;
                txgioitinhREAD.Text = gioiTinh;
                txbophanREAD.Text = TenBophan;
            }
        }

        private void btnchuyencns_Click(object sender, EventArgs e)
        {
            if (select_row_dtgv == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần chuyển.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbbchuyenchinhanhcns.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn chi nhánh mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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

            if (ngayBatDau.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Vui lòng chọn ngày bắt đầu tính từ hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            
            string maNhanVien = txmanhanviencnsREAD.Text;
            string maBoPhanMoi =(( cbbchuyenbophancns.SelectedItem as BoPhan).MaBoPhan).ToString();
            string maChiNhanhMoi = ((cbbchuyenchinhanhcns.SelectedItem as ChiNhanh).MaChiNhanh).ToString();
           

            bool isSuccess = NhanvienDAO.ChuyenNhanSu(maNhanVien, maBoPhanMoi, maChiNhanhMoi, ngayBatDau, ngayKetThuc);

            if (isSuccess)
            {
                MessageBox.Show("Chuyển nhân sự thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadNhansu();
            }
            else
            {
                MessageBox.Show("Chuyển nhân sự thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ các textbox (sử dụng tên thật của control)
            string tenThucDon = textBox13.Text?.Trim();
            string khuVuc = textBox12.Text?.Trim();

            // Kiểm tra dữ liệu đầu vào chi tiết hơn
            if (string.IsNullOrEmpty(tenThucDon))
            {
                MessageBox.Show("Vui lòng nhập tên thực đơn!");
                textBox13.Focus();
                return;
            }

            if (string.IsNullOrEmpty(khuVuc))
            {
                MessageBox.Show("Vui lòng nhập khu vực!");
                textBox12.Focus();
                return;
            }

            try
            {
                // Tạo mã thực đơn mới
                string maThucDon = ThucDonDAO.GenerateNewMaThucDon();

                // Tạo đối tượng thực đơn mới
                var thucDon = new ThucDon
                {
                    MaThucDon = maThucDon,
                    TenThucDon = tenThucDon,
                    KhuVuc = khuVuc
                };

                // Thêm vào CSDL
                if (ThucDonDAO.AddThucDon(thucDon))
                {
                    MessageBox.Show("Thêm thực đơn thành công!");
                    // Nếu đang có từ khóa tìm kiếm thì load lại kết quả tìm kiếm
                    string tuKhoa = textBox15?.Text?.Trim() ?? string.Empty;
                    if (!string.IsNullOrEmpty(tuKhoa))
                    {
                        var ketQua = ThucDonDAO.SearchThucDon(tuKhoa);
                        dataGridView5.DataSource = ketQua;
                    }
                    else
                    {
                        LoadDanhSachThucDon(); // Load tất cả nếu không có từ khóa
                    }
                    
                    ClearInputs();
                    LoadDataThucDon();
                    // Clear các textbox
                    textBox13.Clear();
                    textBox12.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private void btnXoaThucDon_Click(object sender, EventArgs e)
        {
            try 
            {
                // Kiểm tra xem đã chọn dòng nào chưa
                if (dataGridView5.CurrentRow == null || dataGridView5.CurrentRow.Index < 0)
                {
                    MessageBox.Show("Vui lòng chọn thực đơn cần xóa!");
                    return;
                }

                // Lấy mã thực đơn từ dòng được chọn
                string maThucDon = dataGridView5.CurrentRow.Cells["MaThucDon"].Value?.ToString();
                
                if (string.IsNullOrEmpty(maThucDon))
                {
                    MessageBox.Show("Không tìm thấy mã thực đơn!");
                    return;
                }

                // Hiển thị hộp thoại xác nhận
                var result = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa thực đơn này?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    if (ThucDonDAO.DeleteThucDon(maThucDon))
                    {
                        MessageBox.Show("Xóa thực đơn thành công!");
                        // Nếu đang có từ khóa tìm kiếm thì load lại kết quả tìm kiếm
                        string tuKhoa = textBox15?.Text?.Trim() ?? string.Empty;
                        if (!string.IsNullOrEmpty(tuKhoa))
                        {
                            var ketQua = ThucDonDAO.SearchThucDon(tuKhoa);
                            dataGridView5.DataSource = ketQua;
                        }
                        else
                        {
                            LoadDanhSachThucDon(); // Load tất cả nếu không có từ khóa
                        }
                        
                        ClearInputs();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thực đơn thất bại!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa thực đơn: {ex.Message}");
            }
        }

        private void btnSuaThucDon_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox14?.Text) ||
                    string.IsNullOrWhiteSpace(textBox13?.Text) || 
                    string.IsNullOrWhiteSpace(textBox12?.Text))
                {
                    MessageBox.Show("Vui lòng chọn thực đơn cần sửa và nhập đầy đủ thông tin!");
                    return;
                }

                var thucDon = new ThucDon
                {
                    MaThucDon = textBox14.Text.Trim(),
                    TenThucDon = textBox13.Text.Trim(),
                    KhuVuc = textBox12.Text.Trim()
                };

                if (ThucDonDAO.UpdateThucDon(thucDon))
                {
                    MessageBox.Show("Cập nhật thực đơn thành công!");
                    
                    // Nếu đang có từ khóa tìm kiếm thì load lại kết quả tìm kiếm
                    string tuKhoa = textBox15?.Text?.Trim() ?? string.Empty;
                    if (!string.IsNullOrEmpty(tuKhoa))
                    {
                        var ketQua = ThucDonDAO.SearchThucDon(tuKhoa);
                        dataGridView5.DataSource = ketQua;
                    }
                    else
                    {
                        LoadDanhSachThucDon(); // Load tất cả nếu không có từ khóa
                    }
                    
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("Cập nhật thực đơn thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật thực đơn: {ex.Message}");
            }
        }

        private void btnTimThucDon_Click(object sender, EventArgs e)
        {
            try 
            {
                string tuKhoa = textBox15.Text.Trim();
                
                if (string.IsNullOrEmpty(tuKhoa))
                {
                    MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!");
                    return;
                }

                var ketQua = ThucDonDAO.SearchThucDon(tuKhoa);
                
                if (ketQua != null && ketQua.Any())
                {
                    dataGridView5.DataSource = ketQua;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy kết quả nào!");
                    LoadDanhSachThucDon();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}");
            }
        }

        private void LoadThucDon()
        {
            try
            {
                if (dgvThucDon != null)
                {
                    var danhSach = ThucDonDAO.GetAllThucDon();
                    dgvThucDon.DataSource = danhSach;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load thực đơn: {ex.Message}");
            }
        }

        private void LoadDanhSachThucDon()
        {
            try
            {
                if (dgvThucDon != null)
                {
                    var danhSach = ThucDonDAO.GetAllThucDon();
                    if (danhSach != null)
                    {
                        dgvThucDon.DataSource = null;
                        dgvThucDon.DataSource = danhSach;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách thực đơn: {ex.Message}");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try 
            {
                string tuKhoa = txtTimKiem.Text.Trim();
                
                if (string.IsNullOrEmpty(tuKhoa))
                {
                    MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!");
                    return;
                }

                tuKhoa = "%" + tuKhoa + "%";
                var ketQua = ThucDonDAO.SearchThucDon(tuKhoa);
                
                if (ketQua != null && ketQua.Any())
                {
                    dgvThucDon.DataSource = ketQua;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy kết quả nào!");
                    LoadDanhSachThucDon();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}");
            }
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView5.Rows[e.RowIndex];
                
                textBox14.Text = row.Cells["MaThucDon"].Value?.ToString();
                textBox13.Text = row.Cells["TenThucDon"].Value?.ToString();
                textBox12.Text = row.Cells["KhuVuc"].Value?.ToString();
                SetInputState(true);
            }
        }

        private void ClearInputs()
        {
            textBox14.Clear();
            textBox13.Clear();
            textBox12.Clear();
        }

        private void SetInputState(bool isEditing)
        {
            if (textBox14 != null) textBox14.ReadOnly = true;
            if (textBox13 != null) textBox13.ReadOnly = false;
            if (textBox12 != null) textBox12.ReadOnly = false;
        }

        private void Debug_ShowTextBoxValues()
        {
            MessageBox.Show($"Tên thực đơn: '{textBox13.Text}'\n" +
                           $"Độ dài: {textBox13.Text.Length}\n" +
                           $"Có khoảng trắng đầu/cuối: {textBox13.Text != textBox13.Text.Trim()}");
        }

        private void LoadData()
        {
            dgvThucDon.DataSource = ThucDonDAO.GetThucDon();
        }

        private void LoadDataThucDon()
        {
            var danhSachThucDon = ThucDonDAO.GetAllThucDon();
            dgvThucDon.DataSource = null;
            dgvThucDon.DataSource = danhSachThucDon;
        }

        private void adminfm_Load(object sender, EventArgs e)
        {
            // Các xử lý khác nếu có
        }

        private void btnThemNhanVien_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedBoPhan = cboBoPhan.SelectedItem as BoPhan;
                var selectedChiNhanh = cboChiNhanh.SelectedItem as ChiNhanh;

                if (string.IsNullOrEmpty(txtHoTen?.Text?.Trim()) || 
                    string.IsNullOrEmpty(txtTaiKhoan?.Text?.Trim()) ||
                    string.IsNullOrEmpty(txtMatKhau?.Text?.Trim()) ||
                    cboGioiTinh?.SelectedIndex == -1 ||
                    selectedChiNhanh == null ||
                    selectedBoPhan == null ||
                    dtpNgaySinh?.Value == null)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo đối tượng NhanVien mới
                NhanVien nhanVien = new NhanVien
                {
                    HoTen = txtHoTen.Text.Trim(),
                    DiaChi = txtDiaChi?.Text?.Trim() ?? string.Empty,
                    NgaySinh = dtpNgaySinh.Value,
                    NgayVaoLam = dtpNgayVaoLam?.Value ?? DateTime.Now,
                    GioiTinh = cboGioiTinh.Text,
                    MaBoPhan = selectedBoPhan.MaBoPhan,
                    MaChiNhanh = selectedChiNhanh.MaChiNhanh,
                    TaiKhoan = txtTaiKhoan.Text.Trim(),
                    MatKhau = txtMatKhau.Text.Trim()
                };

                // Thêm nhân viên
                if (NhanvienDAO.ThemNhanVien(nhanVien))
                {
                    MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearNhanVienForm();
                    LoadNhansu();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearNhanVienForm()
        {
            txtHoTen.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            txtDiaChi.Clear();
            txtTaiKhoan.Clear();
            txtMatKhau.Clear();
            cboGioiTinh.SelectedIndex = -1;
            cboChiNhanh.SelectedIndex = -1;
            cboBoPhan.SelectedIndex = -1;
            dtpNgayVaoLam.Value = DateTime.Now;
        }

        private void LoadComboBoxData()
        {
            // Load dữ liệu cho ComboBox Giới tính
            cboGioiTinh.Items.Clear();
            cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ" });

            // Load dữ liệu cho ComboBox Chi nhánh
            ChiNhanh.LoadChinhanh(cboChiNhanh);
            ChiNhanh.LoadChinhanh(cbbchinhanhcns);
            ChiNhanh.LoadChinhanh(cbbchuyenchinhanhcns);

            // Load dữ liệu cho ComboBox Bộ phận
            BoPhan.LoadBoPhan(cboBoPhan);
            BoPhan.LoadBoPhan(cbbchuyenbophancns);
        }
    }
}
