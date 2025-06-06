namespace QuanLyKyTucXa.UI
{
    partial class FormQuanLyHopDong
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
            dtpNgayHetHan = new DateTimePicker();
            label4 = new Label();
            dtpNgayApDung = new DateTimePicker();
            label3 = new Label();
            txtMaSV = new TextBox();
            label2 = new Label();
            txtMaHD = new TextBox();
            label5 = new Label();
            groupBox2 = new GroupBox();
            btnTimKiem = new Button();
            txtTimKiem = new TextBox();
            label6 = new Label();
            dgvHopDong = new DataGridView();
            panel2 = new Panel();
            btnChamDut = new Button();
            btnGiaHan = new Button();
            btnLapHopDong = new Button();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHopDong).BeginInit();
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
            btnQuayLai.Location = new Point(1166, 4);
            btnQuayLai.Margin = new Padding(3, 4, 3, 4);
            btnQuayLai.Name = "btnQuayLai";
            btnQuayLai.Size = new Size(171, 63);
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
            label1.Size = new Size(258, 37);
            label1.TabIndex = 0;
            label1.Text = "Quản Lý Hợp Đồng";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dtpNgayHetHan);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(dtpNgayApDung);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtMaSV);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtMaHD);
            groupBox1.Controls.Add(label5);
            groupBox1.Font = new Font("Segoe UI", 9.75F);
            groupBox1.Location = new Point(14, 88);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(1344, 133);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin hợp đồng";
            // 
            // dtpNgayHetHan
            // 
            dtpNgayHetHan.CustomFormat = "dd/MM/yyyy";
            dtpNgayHetHan.Format = DateTimePickerFormat.Custom;
            dtpNgayHetHan.Location = new Point(1009, 60);
            dtpNgayHetHan.Margin = new Padding(3, 4, 3, 4);
            dtpNgayHetHan.Name = "dtpNgayHetHan";
            dtpNgayHetHan.Size = new Size(316, 29);
            dtpNgayHetHan.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(886, 68);
            label4.Name = "label4";
            label4.Size = new Size(118, 23);
            label4.TabIndex = 6;
            label4.Text = "Ngày hết hạn:";
            // 
            // dtpNgayApDung
            // 
            dtpNgayApDung.CustomFormat = "dd/MM/yyyy";
            dtpNgayApDung.Format = DateTimePickerFormat.Custom;
            dtpNgayApDung.Location = new Point(540, 62);
            dtpNgayApDung.Margin = new Padding(3, 4, 3, 4);
            dtpNgayApDung.Name = "dtpNgayApDung";
            dtpNgayApDung.Size = new Size(316, 29);
            dtpNgayApDung.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(411, 68);
            label3.Name = "label3";
            label3.Size = new Size(123, 23);
            label3.TabIndex = 4;
            label3.Text = "Ngày áp dụng:";
            // 
            // txtMaSV
            // 
            txtMaSV.Location = new Point(122, 76);
            txtMaSV.Margin = new Padding(3, 4, 3, 4);
            txtMaSV.Name = "txtMaSV";
            txtMaSV.Size = new Size(228, 29);
            txtMaSV.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 80);
            label2.Name = "label2";
            label2.Size = new Size(110, 23);
            label2.TabIndex = 2;
            label2.Text = "Mã sinh viên:";
            // 
            // txtMaHD
            // 
            txtMaHD.Location = new Point(122, 36);
            txtMaHD.Margin = new Padding(3, 4, 3, 4);
            txtMaHD.Name = "txtMaHD";
            txtMaHD.Size = new Size(228, 29);
            txtMaHD.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(7, 40);
            label5.Name = "label5";
            label5.Size = new Size(118, 23);
            label5.TabIndex = 0;
            label5.Text = "Mã hợp đồng:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnTimKiem);
            groupBox2.Controls.Add(txtTimKiem);
            groupBox2.Controls.Add(label6);
            groupBox2.Font = new Font("Segoe UI", 9.75F);
            groupBox2.Location = new Point(14, 229);
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
            btnTimKiem.Location = new Point(1167, 16);
            btnTimKiem.Margin = new Padding(3, 4, 3, 4);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(170, 56);
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
            txtTimKiem.Size = new Size(1023, 29);
            txtTimKiem.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(7, 33);
            label6.Name = "label6";
            label6.Size = new Size(119, 23);
            label6.TabIndex = 0;
            label6.Text = "Nhập từ khóa:";
            // 
            // dgvHopDong
            // 
            dgvHopDong.AllowUserToAddRows = false;
            dgvHopDong.AllowUserToDeleteRows = false;
            dgvHopDong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHopDong.BackgroundColor = SystemColors.ControlLightLight;
            dgvHopDong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHopDong.Location = new Point(14, 317);
            dgvHopDong.Margin = new Padding(3, 4, 3, 4);
            dgvHopDong.Name = "dgvHopDong";
            dgvHopDong.ReadOnly = true;
            dgvHopDong.RowHeadersWidth = 51;
            dgvHopDong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHopDong.Size = new Size(1344, 459);
            dgvHopDong.TabIndex = 3;
            dgvHopDong.CellClick += dgvHopDong_CellClick;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnChamDut);
            panel2.Controls.Add(btnGiaHan);
            panel2.Controls.Add(btnLapHopDong);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(14, 784);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(1343, 67);
            panel2.TabIndex = 4;
            // 
            // btnChamDut
            // 
            btnChamDut.BackColor = Color.FromArgb(192, 0, 0);
            btnChamDut.FlatStyle = FlatStyle.Flat;
            btnChamDut.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnChamDut.ForeColor = Color.White;
            btnChamDut.Location = new Point(1104, 0);
            btnChamDut.Margin = new Padding(3, 4, 3, 4);
            btnChamDut.Name = "btnChamDut";
            btnChamDut.Size = new Size(187, 63);
            btnChamDut.TabIndex = 2;
            btnChamDut.Text = "Chấm dứt";
            btnChamDut.UseVisualStyleBackColor = false;
            btnChamDut.Click += btnChamDut_Click;
            // 
            // btnGiaHan
            // 
            btnGiaHan.BackColor = SystemColors.ButtonFace;
            btnGiaHan.FlatStyle = FlatStyle.Flat;
            btnGiaHan.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnGiaHan.ForeColor = SystemColors.ButtonFace;
            btnGiaHan.Location = new Point(569, 4);
            btnGiaHan.Margin = new Padding(3, 4, 3, 4);
            btnGiaHan.Name = "btnGiaHan";
            btnGiaHan.Size = new Size(223, 59);
            btnGiaHan.TabIndex = 1;
            btnGiaHan.Text = "Gia hạn";
            btnGiaHan.UseVisualStyleBackColor = false;
            btnGiaHan.Click += btnGiaHan_Click;
            // 
            // btnLapHopDong
            // 
            btnLapHopDong.BackColor = Color.FromArgb(0, 150, 136);
            btnLapHopDong.FlatStyle = FlatStyle.Flat;
            btnLapHopDong.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnLapHopDong.ForeColor = Color.White;
            btnLapHopDong.Location = new Point(46, 4);
            btnLapHopDong.Margin = new Padding(3, 4, 3, 4);
            btnLapHopDong.Name = "btnLapHopDong";
            btnLapHopDong.Size = new Size(158, 59);
            btnLapHopDong.TabIndex = 0;
            btnLapHopDong.Text = "Lập mới";
            btnLapHopDong.UseVisualStyleBackColor = false;
            btnLapHopDong.Click += btnLapHopDong_Click;
            // 
            // FormQuanLyHopDong
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(1371, 867);
            Controls.Add(panel2);
            Controls.Add(dgvHopDong);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            ForeColor = Color.Blue;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormQuanLyHopDong";
            Padding = new Padding(14, 16, 14, 16);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Hợp Đồng";
            Load += FormQuanLyHopDong_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHopDong).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpNgayHetHan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpNgayApDung;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaSV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaHD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvHopDong;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnChamDut;
        private System.Windows.Forms.Button btnGiaHan;
        private System.Windows.Forms.Button btnLapHopDong;
        private System.Windows.Forms.Button btnQuayLai;
    }
} 