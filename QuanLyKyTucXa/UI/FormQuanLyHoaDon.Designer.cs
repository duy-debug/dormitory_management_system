namespace QuanLyKyTucXa.UI
{
    partial class FormQuanLyHoaDon
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panel1 = new Panel();
            btnQuayLai = new Button();
            label1 = new Label();
            groupBox1 = new GroupBox();
            cboDichVu = new ComboBox();
            label9 = new Label();
            numChiSoCuoi = new NumericUpDown();
            label8 = new Label();
            numChiSoDau = new NumericUpDown();
            label7 = new Label();
            numNam = new NumericUpDown();
            label6 = new Label();
            numThang = new NumericUpDown();
            label5 = new Label();
            txtPhong = new TextBox();
            label4 = new Label();
            txtTang = new TextBox();
            label3 = new Label();
            cboKhu = new ComboBox();
            label2 = new Label();
            dgvHoaDon = new DataGridView();
            panel2 = new Panel();
            btnXuatHoaDon = new Button();
            btnXemLichSu = new Button();
            btnTinhTien = new Button();
            btnThemHoaDon = new Button();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numChiSoCuoi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numChiSoDau).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numNam).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numThang).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).BeginInit();
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
            btnQuayLai.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnQuayLai.ForeColor = Color.White;
            btnQuayLai.Location = new Point(1158, 5);
            btnQuayLai.Margin = new Padding(3, 4, 3, 4);
            btnQuayLai.Name = "btnQuayLai";
            btnQuayLai.Size = new Size(171, 65);
            btnQuayLai.TabIndex = 3;
            btnQuayLai.Text = "Quay lại";
            btnQuayLai.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(23, 12);
            label1.Name = "label1";
            label1.Size = new Size(239, 37);
            label1.TabIndex = 0;
            label1.Text = "Quản Lý Hóa Đơn";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cboDichVu);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(numChiSoCuoi);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(numChiSoDau);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(numNam);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(numThang);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtPhong);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtTang);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cboKhu);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(14, 104);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(1344, 160);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin hóa đơn";
            // 
            // cboDichVu
            // 
            cboDichVu.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDichVu.Location = new Point(971, 36);
            cboDichVu.Margin = new Padding(3, 4, 3, 4);
            cboDichVu.Name = "cboDichVu";
            cboDichVu.Size = new Size(171, 28);
            cboDichVu.TabIndex = 15;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(880, 40);
            label9.Name = "label9";
            label9.Size = new Size(61, 20);
            label9.TabIndex = 14;
            label9.Text = "Dịch vụ:";
            // 
            // numChiSoCuoi
            // 
            numChiSoCuoi.Location = new Point(971, 89);
            numChiSoCuoi.Margin = new Padding(3, 4, 3, 4);
            numChiSoCuoi.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            numChiSoCuoi.Name = "numChiSoCuoi";
            numChiSoCuoi.Size = new Size(171, 27);
            numChiSoCuoi.TabIndex = 0;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(880, 93);
            label8.Name = "label8";
            label8.Size = new Size(84, 20);
            label8.TabIndex = 1;
            label8.Text = "Chỉ số cuối:";
            // 
            // numChiSoDau
            // 
            numChiSoDau.Location = new Point(686, 89);
            numChiSoDau.Margin = new Padding(3, 4, 3, 4);
            numChiSoDau.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            numChiSoDau.Name = "numChiSoDau";
            numChiSoDau.Size = new Size(171, 27);
            numChiSoDau.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(594, 93);
            label7.Name = "label7";
            label7.Size = new Size(81, 20);
            label7.TabIndex = 3;
            label7.Text = "Chỉ số đầu:";
            // 
            // numNam
            // 
            numNam.Location = new Point(400, 89);
            numNam.Margin = new Padding(3, 4, 3, 4);
            numNam.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            numNam.Minimum = new decimal(new int[] { 2000, 0, 0, 0 });
            numNam.Name = "numNam";
            numNam.Size = new Size(171, 27);
            numNam.TabIndex = 4;
            numNam.Value = new decimal(new int[] { 2025, 0, 0, 0 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(309, 93);
            label6.Name = "label6";
            label6.Size = new Size(44, 20);
            label6.TabIndex = 5;
            label6.Text = "Năm:";
            // 
            // numThang
            // 
            numThang.Location = new Point(114, 89);
            numThang.Margin = new Padding(3, 4, 3, 4);
            numThang.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            numThang.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numThang.Name = "numThang";
            numThang.Size = new Size(171, 27);
            numThang.TabIndex = 6;
            numThang.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(23, 93);
            label5.Name = "label5";
            label5.Size = new Size(53, 20);
            label5.TabIndex = 7;
            label5.Text = "Tháng:";
            // 
            // txtPhong
            // 
            txtPhong.Location = new Point(686, 36);
            txtPhong.Margin = new Padding(3, 4, 3, 4);
            txtPhong.Name = "txtPhong";
            txtPhong.Size = new Size(171, 27);
            txtPhong.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(594, 40);
            label4.Name = "label4";
            label4.Size = new Size(54, 20);
            label4.TabIndex = 9;
            label4.Text = "Phòng:";
            // 
            // txtTang
            // 
            txtTang.Location = new Point(400, 36);
            txtTang.Margin = new Padding(3, 4, 3, 4);
            txtTang.Name = "txtTang";
            txtTang.Size = new Size(171, 27);
            txtTang.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(309, 40);
            label3.Name = "label3";
            label3.Size = new Size(45, 20);
            label3.TabIndex = 11;
            label3.Text = "Tầng:";
            // 
            // cboKhu
            // 
            cboKhu.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKhu.Location = new Point(114, 36);
            cboKhu.Margin = new Padding(3, 4, 3, 4);
            cboKhu.Name = "cboKhu";
            cboKhu.Size = new Size(171, 28);
            cboKhu.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 40);
            label2.Name = "label2";
            label2.Size = new Size(37, 20);
            label2.TabIndex = 13;
            label2.Text = "Khu:";
            // 
            // dgvHoaDon
            // 
            dgvHoaDon.AllowUserToAddRows = false;
            dgvHoaDon.AllowUserToDeleteRows = false;
            dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoaDon.BackgroundColor = Color.White;
            dgvHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoaDon.Location = new Point(14, 280);
            dgvHoaDon.Margin = new Padding(3, 4, 3, 4);
            dgvHoaDon.Name = "dgvHoaDon";
            dgvHoaDon.ReadOnly = true;
            dgvHoaDon.RowHeadersWidth = 51;
            dgvHoaDon.Size = new Size(1344, 496);
            dgvHoaDon.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnXuatHoaDon);
            panel2.Controls.Add(btnXemLichSu);
            panel2.Controls.Add(btnTinhTien);
            panel2.Controls.Add(btnThemHoaDon);
            panel2.Location = new Point(14, 784);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(1344, 67);
            panel2.TabIndex = 3;
            // 
            // btnXuatHoaDon
            // 
            btnXuatHoaDon.BackColor = Color.FromArgb(192, 0, 0);
            btnXuatHoaDon.FlatStyle = FlatStyle.Flat;
            btnXuatHoaDon.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnXuatHoaDon.ForeColor = Color.White;
            btnXuatHoaDon.Location = new Point(766, -3);
            btnXuatHoaDon.Margin = new Padding(3, 4, 3, 4);
            btnXuatHoaDon.Name = "btnXuatHoaDon";
            btnXuatHoaDon.Size = new Size(171, 69);
            btnXuatHoaDon.TabIndex = 0;
            btnXuatHoaDon.Text = "Xuất hóa đơn";
            btnXuatHoaDon.UseVisualStyleBackColor = false;
            // 
            // btnXemLichSu
            // 
            btnXemLichSu.BackColor = Color.FromArgb(0, 150, 136);
            btnXemLichSu.FlatStyle = FlatStyle.Flat;
            btnXemLichSu.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnXemLichSu.ForeColor = Color.White;
            btnXemLichSu.Location = new Point(1103, -3);
            btnXemLichSu.Margin = new Padding(3, 4, 3, 4);
            btnXemLichSu.Name = "btnXemLichSu";
            btnXemLichSu.Size = new Size(171, 69);
            btnXemLichSu.TabIndex = 1;
            btnXemLichSu.Text = "Xem lịch sử";
            btnXemLichSu.UseVisualStyleBackColor = false;
            // 
            // btnTinhTien
            // 
            btnTinhTien.BackColor = Color.FromArgb(255, 128, 0);
            btnTinhTien.FlatStyle = FlatStyle.Flat;
            btnTinhTien.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnTinhTien.ForeColor = Color.White;
            btnTinhTien.Location = new Point(431, 0);
            btnTinhTien.Margin = new Padding(3, 4, 3, 4);
            btnTinhTien.Name = "btnTinhTien";
            btnTinhTien.Size = new Size(171, 67);
            btnTinhTien.TabIndex = 2;
            btnTinhTien.Text = "Tính tiền";
            btnTinhTien.UseVisualStyleBackColor = false;
            // 
            // btnThemHoaDon
            // 
            btnThemHoaDon.BackColor = Color.Blue;
            btnThemHoaDon.FlatStyle = FlatStyle.Flat;
            btnThemHoaDon.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnThemHoaDon.ForeColor = Color.White;
            btnThemHoaDon.Location = new Point(102, 1);
            btnThemHoaDon.Margin = new Padding(3, 4, 3, 4);
            btnThemHoaDon.Name = "btnThemHoaDon";
            btnThemHoaDon.Size = new Size(171, 65);
            btnThemHoaDon.TabIndex = 4;
            btnThemHoaDon.Text = "Thêm hóa đơn";
            btnThemHoaDon.UseVisualStyleBackColor = false;
            // 
            // FormQuanLyHoaDon
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1371, 867);
            Controls.Add(panel2);
            Controls.Add(dgvHoaDon);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            ForeColor = Color.Blue;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormQuanLyHoaDon";
            Padding = new Padding(14, 16, 14, 16);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Hóa Đơn";
            Load += FormQuanLyHoaDon_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numChiSoCuoi).EndInit();
            ((System.ComponentModel.ISupportInitialize)numChiSoDau).EndInit();
            ((System.ComponentModel.ISupportInitialize)numNam).EndInit();
            ((System.ComponentModel.ISupportInitialize)numThang).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numChiSoCuoi;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numChiSoDau;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numNam;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numThang;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPhong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboKhu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnXuatHoaDon;
        private System.Windows.Forms.Button btnXemLichSu;
        private System.Windows.Forms.Button btnTinhTien;
        private System.Windows.Forms.ComboBox cboDichVu;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnQuayLai;
        private System.Windows.Forms.Button btnThemHoaDon;

        #endregion
    }
} 