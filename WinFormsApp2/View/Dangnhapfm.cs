using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySuShi.Controller.DAO;
using QuanLySuShi.Model.DTO;

namespace QuanLySuShi

{
    public partial class Dangnhap : Form
    {
        public static User user = null;


        public Dangnhap()
        {
            InitializeComponent();
        }


        private void btdangnhap_Click(object sender, EventArgs e)
        {
            string tendangnhap = txtTaiKhoan.Text;
            string matkhau = txtMatKhau.Text;
            int loai = cbbloai.SelectedIndex;
            if (!kiemtranhap())
            {
                return;
            }
            bool isFound = false;
            if (loai == 1)
            {
                isFound = DangNhapDAO.TryDangNhapKH(tendangnhap, matkhau);
            }
            else if (loai == 0)
            {
                isFound = DangNhapDAO.TryDangNhapNV(tendangnhap, matkhau);
            }
            if (isFound)
            {
                if (loai == 0)
                {
                   
                    Dangnhap.user = NhanvienDAO.GetNhanVienByTaiKhoan(tendangnhap);
                    (Dangnhap.user as NhanVien).QuanlyChiNhanh = NhanvienDAO.Is_QuanLy((Dangnhap.user as NhanVien).MaDinhDanh);

                    MainfmNhanvien f = new MainfmNhanvien();
                    f.Show();

                }
                else
                {
                    Dangnhap.user = KhachHangDAO.GetKhachHangByTaiKhoan(tendangnhap);
                    Mainfmkhachhang f = new Mainfmkhachhang();
                    f.Show();

                }
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sai Ten tai khoan hoac mat khau ");
            }
        }

        private void btthoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private bool kiemtranhap()
        {
            if (txtTaiKhoan.Text == "")
            {
                MessageBox.Show("vui long nhap tai khoan ");
                txtTaiKhoan.Focus();
                return false;
            }
            if (txtMatKhau.Text == "")
            {
                MessageBox.Show("vui long nhap mat khau");
                txtMatKhau.Focus();
                return false;
            }
            if (cbbloai.SelectedIndex == -1)
            {
                MessageBox.Show("vui long chon loai tai khoan ");
                cbbloai.Focus();
                return false;
            }


            return true;
        }

        private void Dangnhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Ban co muon thoat chuong trinh", "Canh Bao", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void cbbloai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbloai.SelectedIndex == 0)
               { txtMatKhau.Text = "password456";
                txtTaiKhoan.Text = "tranthib";
            }
            else
              {  txtMatKhau.Text = "password789";
                txtTaiKhoan.Text = "nguyenvanc";
            }
           
        }
    }
}
