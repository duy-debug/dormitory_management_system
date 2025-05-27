namespace QuanLyKyTucXa.UI
{
    partial class FormQuanLySinhVien
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
            panel1 = new Panel();
            btnQuayLai = new Button();
            label1 = new Label();
            groupBox1 = new GroupBox();
            cboUuTien = new ComboBox();
            label12 = new Label();
            cboPhong = new ComboBox();
            label11 = new Label();
            cboTang = new ComboBox();
            label10 = new Label();
            cboKhu = new ComboBox();
            label9 = new Label();
            txtDiaChi = new TextBox();
            label8 = new Label();
            txtEmail = new TextBox();
            label7 = new Label();
            cboGioiTinh = new ComboBox();
            label6 = new Label();
            dtpNgaySinh = new DateTimePicker();
            label5 = new Label();
            txtTen = new TextBox();
            label4 = new Label();
            txtHoTenLot = new TextBox();
            label3 = new Label();
            txtMaSV = new TextBox();
            label2 = new Label();
            groupBox2 = new GroupBox();
            btnTimKiem = new Button();
            txtTimKiem = new TextBox();
            label13 = new Label();
            dgvSinhVien = new DataGridView();
            panel2 = new Panel();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 150, 136);
            panel1.Controls.Add(btnQuayLai);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(14, 16);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1343, 80);
            panel1.TabIndex = 0;
            // 
            // btnQuayLai
            // 
            btnQuayLai.BackColor = Color.Gray;
            btnQuayLai.FlatStyle = FlatStyle.Flat;
            btnQuayLai.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnQuayLai.ForeColor = Color.White;
            btnQuayLai.Location = new Point(1179, 11);
            btnQuayLai.Margin = new Padding(3, 4, 3, 4);
            btnQuayLai.Name = "btnQuayLai";
            btnQuayLai.Size = new Size(158, 51);
            btnQuayLai.TabIndex = 3;
            btnQuayLai.Text = "Quay lại";
            btnQuayLai.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(14, 12);
            label1.Name = "label1";
            label1.Size = new Size(245, 37);
            label1.TabIndex = 0;
            label1.Text = "Quản Lý Sinh Viên";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cboUuTien);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(cboPhong);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(cboTang);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(cboKhu);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(txtDiaChi);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(cboGioiTinh);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(dtpNgaySinh);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtTen);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtHoTenLot);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtMaSV);
            groupBox1.Controls.Add(label2);
            groupBox1.Font = new Font("Segoe UI", 9.75F);
            groupBox1.Location = new Point(14, 88);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(1344, 267);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin sinh viên";
            // 
            // cboUuTien
            // 
            cboUuTien.FormattingEnabled = true;
            cboUuTien.Location = new Point(1021, 209);
            cboUuTien.Margin = new Padding(3, 4, 3, 4);
            cboUuTien.Name = "cboUuTien";
            cboUuTien.Size = new Size(316, 29);
            cboUuTien.TabIndex = 21;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(906, 213);
            label12.Name = "label12";
            label12.Size = new Size(108, 23);
            label12.TabIndex = 20;
            label12.Text = "Diện ưu tiên:";
            // 
            // cboPhong
            // 
            cboPhong.FormattingEnabled = true;
            cboPhong.Location = new Point(1021, 156);
            cboPhong.Margin = new Padding(3, 4, 3, 4);
            cboPhong.Name = "cboPhong";
            cboPhong.Size = new Size(316, 29);
            cboPhong.TabIndex = 19;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(906, 160);
            label11.Name = "label11";
            label11.Size = new Size(64, 23);
            label11.TabIndex = 18;
            label11.Text = "Phòng:";
            // 
            // cboTang
            // 
            cboTang.FormattingEnabled = true;
            cboTang.Location = new Point(1021, 103);
            cboTang.Margin = new Padding(3, 4, 3, 4);
            cboTang.Name = "cboTang";
            cboTang.Size = new Size(316, 29);
            cboTang.TabIndex = 17;
            cboTang.SelectedIndexChanged += cboTang_SelectedIndexChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(906, 107);
            label10.Name = "label10";
            label10.Size = new Size(52, 23);
            label10.TabIndex = 16;
            label10.Text = "Tầng:";
            // 
            // cboKhu
            // 
            cboKhu.FormattingEnabled = true;
            cboKhu.Location = new Point(1021, 49);
            cboKhu.Margin = new Padding(3, 4, 3, 4);
            cboKhu.Name = "cboKhu";
            cboKhu.Size = new Size(316, 29);
            cboKhu.TabIndex = 15;
            cboKhu.SelectedIndexChanged += cboKhu_SelectedIndexChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(906, 53);
            label9.Name = "label9";
            label9.Size = new Size(44, 23);
            label9.TabIndex = 14;
            label9.Text = "Khu:";
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(527, 156);
            txtDiaChi.Margin = new Padding(3, 4, 3, 4);
            txtDiaChi.Multiline = true;
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(316, 85);
            txtDiaChi.TabIndex = 13;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(413, 160);
            label8.Name = "label8";
            label8.Size = new Size(66, 23);
            label8.TabIndex = 12;
            label8.Text = "Địa chỉ:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(527, 103);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(316, 29);
            txtEmail.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(413, 107);
            label7.Name = "label7";
            label7.Size = new Size(55, 23);
            label7.TabIndex = 10;
            label7.Text = "Email:";
            // 
            // cboGioiTinh
            // 
            cboGioiTinh.FormattingEnabled = true;
            cboGioiTinh.Location = new Point(527, 49);
            cboGioiTinh.Margin = new Padding(3, 4, 3, 4);
            cboGioiTinh.Name = "cboGioiTinh";
            cboGioiTinh.Size = new Size(316, 29);
            cboGioiTinh.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(413, 53);
            label6.Name = "label6";
            label6.Size = new Size(79, 23);
            label6.TabIndex = 8;
            label6.Text = "Giới tính:";
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.Location = new Point(122, 209);
            dtpNgaySinh.Margin = new Padding(3, 4, 3, 4);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(228, 29);
            dtpNgaySinh.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(7, 213);
            label5.Name = "label5";
            label5.Size = new Size(90, 23);
            label5.TabIndex = 6;
            label5.Text = "Ngày sinh:";
            // 
            // txtTen
            // 
            txtTen.Location = new Point(122, 156);
            txtTen.Margin = new Padding(3, 4, 3, 4);
            txtTen.Name = "txtTen";
            txtTen.Size = new Size(228, 29);
            txtTen.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(7, 160);
            label4.Name = "label4";
            label4.Size = new Size(40, 23);
            label4.TabIndex = 4;
            label4.Text = "Tên:";
            // 
            // txtHoTenLot
            // 
            txtHoTenLot.Location = new Point(122, 103);
            txtHoTenLot.Margin = new Padding(3, 4, 3, 4);
            txtHoTenLot.Name = "txtHoTenLot";
            txtHoTenLot.Size = new Size(228, 29);
            txtHoTenLot.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, 107);
            label3.Name = "label3";
            label3.Size = new Size(91, 23);
            label3.TabIndex = 2;
            label3.Text = "Họ tên lót:";
            // 
            // txtMaSV
            // 
            txtMaSV.Location = new Point(122, 49);
            txtMaSV.Margin = new Padding(3, 4, 3, 4);
            txtMaSV.Name = "txtMaSV";
            txtMaSV.Size = new Size(228, 29);
            txtMaSV.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 53);
            label2.Name = "label2";
            label2.Size = new Size(110, 23);
            label2.TabIndex = 0;
            label2.Text = "Mã sinh viên:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnTimKiem);
            groupBox2.Controls.Add(txtTimKiem);
            groupBox2.Controls.Add(label13);
            groupBox2.Font = new Font("Segoe UI", 9.75F);
            groupBox2.Location = new Point(14, 363);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(1344, 80);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Tìm kiếm";
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = Color.FromArgb(0, 150, 136);
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(1161, 24);
            btnTimKiem.Margin = new Padding(3, 4, 3, 4);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(176, 48);
            btnTimKiem.TabIndex = 2;
            btnTimKiem.Text = "Tìm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(122, 29);
            txtTimKiem.Margin = new Padding(3, 4, 3, 4);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(1031, 29);
            txtTimKiem.TabIndex = 1;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(7, 33);
            label13.Name = "label13";
            label13.Size = new Size(119, 23);
            label13.TabIndex = 0;
            label13.Text = "Nhập từ khóa:";
            // 
            // dgvSinhVien
            // 
            dgvSinhVien.AllowUserToAddRows = false;
            dgvSinhVien.AllowUserToDeleteRows = false;
            dgvSinhVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSinhVien.BackgroundColor = Color.White;
            dgvSinhVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSinhVien.Location = new Point(14, 451);
            dgvSinhVien.Margin = new Padding(3, 4, 3, 4);
            dgvSinhVien.Name = "dgvSinhVien";
            dgvSinhVien.ReadOnly = true;
            dgvSinhVien.RowHeadersWidth = 51;
            dgvSinhVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSinhVien.Size = new Size(1344, 333);
            dgvSinhVien.TabIndex = 3;
            dgvSinhVien.CellClick += dgvSinhVien_CellClick;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnXoa);
            panel2.Controls.Add(btnSua);
            panel2.Controls.Add(btnThem);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(14, 784);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(1343, 67);
            panel2.TabIndex = 4;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.FromArgb(192, 0, 0);
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(1109, 8);
            btnXoa.Margin = new Padding(3, 4, 3, 4);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(122, 51);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.FromArgb(255, 128, 0);
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(623, 8);
            btnSua.Margin = new Padding(3, 4, 3, 4);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(122, 51);
            btnSua.TabIndex = 1;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(0, 150, 136);
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(122, 8);
            btnThem.Margin = new Padding(3, 4, 3, 4);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(122, 51);
            btnThem.TabIndex = 0;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // FormQuanLySinhVien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1371, 867);
            Controls.Add(panel2);
            Controls.Add(dgvSinhVien);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            ForeColor = Color.Blue;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormQuanLySinhVien";
            Padding = new Padding(14, 16, 14, 16);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Sinh Viên";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboUuTien;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboPhong;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboTang;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboKhu;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboGioiTinh;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHoTenLot;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaSV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView dgvSinhVien;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnQuayLai;
    }
} 