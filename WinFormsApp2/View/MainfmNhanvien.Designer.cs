namespace QuanLySuShi
{
    partial class MainfmNhanvien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            hệThốngToolStripMenuItem = new ToolStripMenuItem();
            đăngXuấtToolStripMenuItem = new ToolStripMenuItem();
            thoátToolStripMenuItem = new ToolStripMenuItem();
            quảnLýToolStripMenuItem = new ToolStripMenuItem();
            thôngTinToolStripMenuItem = new ToolStripMenuItem();
            trợGiúpToolStripMenuItem = new ToolStripMenuItem();
            btn_admin = new ToolStripMenuItem();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            label10 = new Label();
            label9 = new Label();
            tbgiamGia = new TextBox();
            tbtongtien = new TextBox();
            flpTable = new FlowLayoutPanel();
            button1 = new Button();
            comboBox4 = new ComboBox();
            btnthanhtoan = new Button();
            btnUuDai = new Button();
            listchitiet = new ListView();
            groupBox4 = new GroupBox();
            cbbmonan = new ComboBox();
            btXoa = new Button();
            soluong = new NumericUpDown();
            btThem = new Button();
            cbbmuc = new ComboBox();
            cbbthucdon = new ComboBox();
            tabPage2 = new TabPage();
            btnTao = new Button();
            groupBox2 = new GroupBox();
            label8 = new Label();
            label7 = new Label();
            tbMatKhau_taothe = new TextBox();
            label6 = new Label();
            tbTaiKhoan_taothe = new TextBox();
            groupBox1 = new GroupBox();
            cbbGioitinh_taothe = new ComboBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            tbCCCD_taothe = new TextBox();
            tbEmail_taothe = new TextBox();
            tbSDT_taothe = new TextBox();
            label1 = new Label();
            tbHoVaTen_taothe = new TextBox();
            tabPage3 = new TabPage();
            listchitiet_donhang = new ListView();
            dtgvDonHang = new DataGridView();
            label12 = new Label();
            label14 = new Label();
            label13 = new Label();
            tbGiamGia_donhang = new TextBox();
            label11 = new Label();
            tbTongTien_donhang = new TextBox();
            textBox1 = new TextBox();
            btTim_donhang = new Button();
            btnDuyet_donhang = new Button();
            menuStrip1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)soluong).BeginInit();
            tabPage2.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvDonHang).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { hệThốngToolStripMenuItem, quảnLýToolStripMenuItem, trợGiúpToolStripMenuItem, btn_admin });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(882, 28);
            menuStrip1.TabIndex = 10;
            menuStrip1.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            hệThốngToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { đăngXuấtToolStripMenuItem, thoátToolStripMenuItem });
            hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            hệThốngToolStripMenuItem.Size = new Size(88, 24);
            hệThốngToolStripMenuItem.Text = "Hệ Thống";
            // 
            // đăngXuấtToolStripMenuItem
            // 
            đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            đăngXuấtToolStripMenuItem.Size = new Size(224, 26);
            đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            đăngXuấtToolStripMenuItem.Click += đăngXuấtToolStripMenuItem_Click;
            // 
            // thoátToolStripMenuItem
            // 
            thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            thoátToolStripMenuItem.Size = new Size(224, 26);
            thoátToolStripMenuItem.Text = "Thoát";
            thoátToolStripMenuItem.Click += thoátToolStripMenuItem_Click;
            // 
            // quảnLýToolStripMenuItem
            // 
            quảnLýToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { thôngTinToolStripMenuItem });
            quảnLýToolStripMenuItem.Name = "quảnLýToolStripMenuItem";
            quảnLýToolStripMenuItem.Size = new Size(73, 24);
            quảnLýToolStripMenuItem.Text = "Quản lý";
            // 
            // thôngTinToolStripMenuItem
            // 
            thôngTinToolStripMenuItem.Name = "thôngTinToolStripMenuItem";
            thôngTinToolStripMenuItem.Size = new Size(155, 26);
            thôngTinToolStripMenuItem.Text = "Thông tin";
            // 
            // trợGiúpToolStripMenuItem
            // 
            trợGiúpToolStripMenuItem.Name = "trợGiúpToolStripMenuItem";
            trợGiúpToolStripMenuItem.Size = new Size(78, 24);
            trợGiúpToolStripMenuItem.Text = "Trợ giúp";
            // 
            // btn_admin
            // 
            btn_admin.Name = "btn_admin";
            btn_admin.Size = new Size(67, 24);
            btn_admin.Text = "Admin";
            btn_admin.Click += adminToolStripMenuItem_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(12, 31);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(870, 457);
            tabControl1.TabIndex = 22;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label10);
            tabPage1.Controls.Add(label9);
            tabPage1.Controls.Add(tbgiamGia);
            tabPage1.Controls.Add(tbtongtien);
            tabPage1.Controls.Add(flpTable);
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(comboBox4);
            tabPage1.Controls.Add(btnthanhtoan);
            tabPage1.Controls.Add(btnUuDai);
            tabPage1.Controls.Add(listchitiet);
            tabPage1.Controls.Add(groupBox4);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(862, 424);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Quán lí nhà hàng";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(656, 355);
            label10.Name = "label10";
            label10.Size = new Size(69, 20);
            label10.TabIndex = 30;
            label10.Text = "Giảm giá";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(545, 355);
            label9.Name = "label9";
            label9.Size = new Size(72, 20);
            label9.TabIndex = 30;
            label9.Text = "Tổng tiền";
            // 
            // tbgiamGia
            // 
            tbgiamGia.Location = new Point(645, 386);
            tbgiamGia.Name = "tbgiamGia";
            tbgiamGia.ReadOnly = true;
            tbgiamGia.Size = new Size(107, 27);
            tbgiamGia.TabIndex = 29;
            tbgiamGia.Text = "0";
            tbgiamGia.TextAlign = HorizontalAlignment.Right;
            // 
            // tbtongtien
            // 
            tbtongtien.Location = new Point(531, 386);
            tbtongtien.Name = "tbtongtien";
            tbtongtien.ReadOnly = true;
            tbtongtien.Size = new Size(107, 27);
            tbtongtien.TabIndex = 29;
            tbtongtien.Text = "0";
            tbtongtien.TextAlign = HorizontalAlignment.Right;
            // 
            // flpTable
            // 
            flpTable.AutoScroll = true;
            flpTable.Location = new Point(8, 16);
            flpTable.Name = "flpTable";
            flpTable.Size = new Size(417, 398);
            flpTable.TabIndex = 28;
            // 
            // button1
            // 
            button1.Location = new Point(431, 351);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 27;
            button1.Text = "Chuyển Bàn";
            button1.UseVisualStyleBackColor = true;
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(431, 386);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(94, 28);
            comboBox4.TabIndex = 26;
            // 
            // btnthanhtoan
            // 
            btnthanhtoan.Location = new Point(758, 386);
            btnthanhtoan.Name = "btnthanhtoan";
            btnthanhtoan.Size = new Size(94, 29);
            btnthanhtoan.TabIndex = 25;
            btnthanhtoan.Text = "Thanh Toán";
            btnthanhtoan.UseVisualStyleBackColor = true;
            btnthanhtoan.Click += btnthanhtoan_Click;
            // 
            // btnUuDai
            // 
            btnUuDai.Location = new Point(758, 351);
            btnUuDai.Name = "btnUuDai";
            btnUuDai.Size = new Size(94, 29);
            btnUuDai.TabIndex = 24;
            btnUuDai.Text = "Ưu Đãi";
            btnUuDai.UseVisualStyleBackColor = true;
            btnUuDai.Click += btnUuDai_Click;
            // 
            // listchitiet
            // 
            listchitiet.GridLines = true;
            listchitiet.Location = new Point(431, 92);
            listchitiet.Name = "listchitiet";
            listchitiet.Size = new Size(421, 248);
            listchitiet.TabIndex = 22;
            listchitiet.UseCompatibleStateImageBehavior = false;
            listchitiet.View = View.Details;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(cbbmonan);
            groupBox4.Controls.Add(btXoa);
            groupBox4.Controls.Add(soluong);
            groupBox4.Controls.Add(btThem);
            groupBox4.Controls.Add(cbbmuc);
            groupBox4.Controls.Add(cbbthucdon);
            groupBox4.Location = new Point(431, 10);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(423, 76);
            groupBox4.TabIndex = 23;
            groupBox4.TabStop = false;
            // 
            // cbbmonan
            // 
            cbbmonan.FormattingEnabled = true;
            cbbmonan.Location = new Point(193, 15);
            cbbmonan.Name = "cbbmonan";
            cbbmonan.Size = new Size(143, 28);
            cbbmonan.TabIndex = 5;
            cbbmonan.Text = "Món";
            // 
            // btXoa
            // 
            btXoa.Location = new Point(342, 48);
            btXoa.Name = "btXoa";
            btXoa.Size = new Size(79, 28);
            btXoa.TabIndex = 4;
            btXoa.Text = "Xoá";
            btXoa.UseVisualStyleBackColor = true;
            btXoa.Click += btXoa_Click;
            // 
            // soluong
            // 
            soluong.Location = new Point(350, 15);
            soluong.Name = "soluong";
            soluong.Size = new Size(58, 27);
            soluong.TabIndex = 3;
            soluong.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btThem
            // 
            btThem.Location = new Point(190, 47);
            btThem.Name = "btThem";
            btThem.Size = new Size(70, 28);
            btThem.TabIndex = 2;
            btThem.Text = "Thêm";
            btThem.UseVisualStyleBackColor = true;
            btThem.Click += btThem_Click;
            // 
            // cbbmuc
            // 
            cbbmuc.FormattingEnabled = true;
            cbbmuc.Location = new Point(6, 48);
            cbbmuc.Name = "cbbmuc";
            cbbmuc.Size = new Size(167, 28);
            cbbmuc.TabIndex = 1;
            cbbmuc.Text = "Mục";
            cbbmuc.SelectedIndexChanged += cbbMuc_SelectedIndexChanged;
            // 
            // cbbthucdon
            // 
            cbbthucdon.FormattingEnabled = true;
            cbbthucdon.Location = new Point(6, 15);
            cbbthucdon.Name = "cbbthucdon";
            cbbthucdon.Size = new Size(167, 28);
            cbbthucdon.TabIndex = 0;
            cbbthucdon.Text = "Thực đơn";
            cbbthucdon.SelectedIndexChanged += cbbthucdon_SelectedIndexChanged;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(btnTao);
            tabPage2.Controls.Add(groupBox2);
            tabPage2.Controls.Add(groupBox1);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(862, 424);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Tạo thẻ";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnTao
            // 
            btnTao.Location = new Point(15, 389);
            btnTao.Name = "btnTao";
            btnTao.Size = new Size(94, 29);
            btnTao.TabIndex = 8;
            btnTao.Text = "Tạo";
            btnTao.UseVisualStyleBackColor = true;
            btnTao.Click += btnTao_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(tbMatKhau_taothe);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(tbTaiKhoan_taothe);
            groupBox2.Location = new Point(251, 6);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(286, 116);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Tài Khoản";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(9, 36);
            label8.Name = "label8";
            label8.Size = new Size(71, 20);
            label8.TabIndex = 6;
            label8.Text = "Tài khoản";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(9, 73);
            label7.Name = "label7";
            label7.Size = new Size(74, 20);
            label7.TabIndex = 5;
            label7.Text = "Mật khẩu ";
            // 
            // tbMatKhau_taothe
            // 
            tbMatKhau_taothe.Location = new Point(155, 73);
            tbMatKhau_taothe.Name = "tbMatKhau_taothe";
            tbMatKhau_taothe.Size = new Size(125, 27);
            tbMatKhau_taothe.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(9, 31);
            label6.Name = "label6";
            label6.Size = new Size(0, 20);
            label6.TabIndex = 3;
            // 
            // tbTaiKhoan_taothe
            // 
            tbTaiKhoan_taothe.Location = new Point(155, 35);
            tbTaiKhoan_taothe.Name = "tbTaiKhoan_taothe";
            tbTaiKhoan_taothe.Size = new Size(125, 27);
            tbTaiKhoan_taothe.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbbGioitinh_taothe);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(tbCCCD_taothe);
            groupBox1.Controls.Add(tbEmail_taothe);
            groupBox1.Controls.Add(tbSDT_taothe);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(tbHoVaTen_taothe);
            groupBox1.Location = new Point(13, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(213, 292);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin cá nhân";
            // 
            // cbbGioitinh_taothe
            // 
            cbbGioitinh_taothe.FormattingEnabled = true;
            cbbGioitinh_taothe.Items.AddRange(new object[] { "Nam", "Nữ" });
            cbbGioitinh_taothe.Location = new Point(73, 201);
            cbbGioitinh_taothe.Name = "cbbGioitinh_taothe";
            cbbGioitinh_taothe.Size = new Size(125, 28);
            cbbGioitinh_taothe.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(2, 204);
            label5.Name = "label5";
            label5.Size = new Size(65, 20);
            label5.TabIndex = 3;
            label5.Text = "Giới tính";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 161);
            label4.Name = "label4";
            label4.Size = new Size(47, 20);
            label4.TabIndex = 3;
            label4.Text = "CCCD";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 128);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 3;
            label3.Text = "Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 83);
            label2.Name = "label2";
            label2.Size = new Size(31, 20);
            label2.TabIndex = 3;
            label2.Text = "Sđt";
            // 
            // tbCCCD_taothe
            // 
            tbCCCD_taothe.Location = new Point(73, 161);
            tbCCCD_taothe.Name = "tbCCCD_taothe";
            tbCCCD_taothe.Size = new Size(125, 27);
            tbCCCD_taothe.TabIndex = 2;
            // 
            // tbEmail_taothe
            // 
            tbEmail_taothe.Location = new Point(73, 125);
            tbEmail_taothe.Name = "tbEmail_taothe";
            tbEmail_taothe.Size = new Size(125, 27);
            tbEmail_taothe.TabIndex = 2;
            // 
            // tbSDT_taothe
            // 
            tbSDT_taothe.Location = new Point(73, 80);
            tbSDT_taothe.Name = "tbSDT_taothe";
            tbSDT_taothe.Size = new Size(125, 27);
            tbSDT_taothe.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 39);
            label1.Name = "label1";
            label1.Size = new Size(56, 20);
            label1.TabIndex = 1;
            label1.Text = "Họ Tên";
            // 
            // tbHoVaTen_taothe
            // 
            tbHoVaTen_taothe.Location = new Point(73, 36);
            tbHoVaTen_taothe.Name = "tbHoVaTen_taothe";
            tbHoVaTen_taothe.Size = new Size(125, 27);
            tbHoVaTen_taothe.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(listchitiet_donhang);
            tabPage3.Controls.Add(dtgvDonHang);
            tabPage3.Controls.Add(label12);
            tabPage3.Controls.Add(label14);
            tabPage3.Controls.Add(label13);
            tabPage3.Controls.Add(tbGiamGia_donhang);
            tabPage3.Controls.Add(label11);
            tabPage3.Controls.Add(tbTongTien_donhang);
            tabPage3.Controls.Add(textBox1);
            tabPage3.Controls.Add(btTim_donhang);
            tabPage3.Controls.Add(btnDuyet_donhang);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(862, 424);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Đơn hàng";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // listchitiet_donhang
            // 
            listchitiet_donhang.Location = new Point(556, 64);
            listchitiet_donhang.Name = "listchitiet_donhang";
            listchitiet_donhang.Size = new Size(298, 292);
            listchitiet_donhang.TabIndex = 5;
            listchitiet_donhang.UseCompatibleStateImageBehavior = false;
            // 
            // dtgvDonHang
            // 
            dtgvDonHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvDonHang.Location = new Point(3, 64);
            dtgvDonHang.Name = "dtgvDonHang";
            dtgvDonHang.RowHeadersWidth = 51;
            dtgvDonHang.Size = new Size(526, 341);
            dtgvDonHang.TabIndex = 4;
            dtgvDonHang.RowHeaderMouseClick += dtgvDonHang_RowHeaderMouseClick;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(556, 8);
            label12.Name = "label12";
            label12.Size = new Size(123, 20);
            label12.TabIndex = 3;
            label12.Text = "Chi tiết đơn hàng";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(669, 368);
            label14.Name = "label14";
            label14.Size = new Size(69, 20);
            label14.TabIndex = 3;
            label14.Text = "Giảm giá";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(556, 368);
            label13.Name = "label13";
            label13.Size = new Size(72, 20);
            label13.TabIndex = 3;
            label13.Text = "Tổng tiền";
            // 
            // tbGiamGia_donhang
            // 
            tbGiamGia_donhang.Location = new Point(669, 391);
            tbGiamGia_donhang.Name = "tbGiamGia_donhang";
            tbGiamGia_donhang.ReadOnly = true;
            tbGiamGia_donhang.Size = new Size(98, 27);
            tbGiamGia_donhang.TabIndex = 2;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(6, 8);
            label11.Name = "label11";
            label11.Size = new Size(97, 20);
            label11.TabIndex = 3;
            label11.Text = "Số điện thoại";
            // 
            // tbTongTien_donhang
            // 
            tbTongTien_donhang.Location = new Point(556, 391);
            tbTongTien_donhang.Name = "tbTongTien_donhang";
            tbTongTien_donhang.ReadOnly = true;
            tbTongTien_donhang.Size = new Size(98, 27);
            tbTongTien_donhang.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(6, 31);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(205, 27);
            textBox1.TabIndex = 2;
            // 
            // btTim_donhang
            // 
            btTim_donhang.Location = new Point(217, 30);
            btTim_donhang.Name = "btTim_donhang";
            btTim_donhang.Size = new Size(94, 29);
            btTim_donhang.TabIndex = 1;
            btTim_donhang.Text = "Tìm";
            btTim_donhang.UseVisualStyleBackColor = true;
            // 
            // btnDuyet_donhang
            // 
            btnDuyet_donhang.Location = new Point(760, 29);
            btnDuyet_donhang.Name = "btnDuyet_donhang";
            btnDuyet_donhang.Size = new Size(94, 29);
            btnDuyet_donhang.TabIndex = 1;
            btnDuyet_donhang.Text = "Duyệt";
            btnDuyet_donhang.UseVisualStyleBackColor = true;
            btnDuyet_donhang.Click += btnDuyet_donhang_Click;
            // 
            // MainfmNhanvien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 572);
            Controls.Add(tabControl1);
            Controls.Add(menuStrip1);
            Name = "MainfmNhanvien";
            Text = "MainfmNhanvien";
            FormClosing += MainfmNhanvien_FormClosing;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)soluong).EndInit();
            tabPage2.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvDonHang).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem hệThốngToolStripMenuItem;
        private ToolStripMenuItem quảnLýToolStripMenuItem;
        private ToolStripMenuItem trợGiúpToolStripMenuItem;
        private ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private ToolStripMenuItem thoátToolStripMenuItem;
        private ToolStripMenuItem btn_admin;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TextBox tbtongtien;
        private Button button1;
        private ComboBox comboBox4;
        private Button btnthanhtoan;
        private Button btnUuDai;
        private ListView listchitiet;
        private GroupBox groupBox4;
        private ComboBox cbbmonan;
        private Button btXoa;
        private NumericUpDown soluong;
        private Button btThem;
        private ComboBox cbbmuc;
        private ComboBox cbbthucdon;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private ToolStripMenuItem thôngTinToolStripMenuItem;
        private GroupBox groupBox2;
        private Label label8;
        private Label label7;
        private TextBox tbMatKhau_taothe;
        private Label label6;
        private TextBox tbTaiKhoan_taothe;
        private GroupBox groupBox1;
        private ComboBox cbbGioitinh_taothe;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox tbCCCD_taothe;
        private TextBox tbEmail_taothe;
        private TextBox tbSDT_taothe;
        private Label label1;
        private TextBox tbHoVaTen_taothe;
        private FlowLayoutPanel flpTable;
        private Button btnTao;
        private Label label9;
        private TextBox tbgiamGia;
        private Label label10;
        private Label label11;
        private TextBox textBox1;
        private Button btTim_donhang;
        private Button btnDuyet_donhang;
        private DataGridView dtgvDonHang;
        private ListView listchitiet_donhang;
        private Label label12;
        private Label label14;
        private Label label13;
        private TextBox tbGiamGia_donhang;
        private TextBox tbTongTien_donhang;
    }
}