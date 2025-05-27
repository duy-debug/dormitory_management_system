namespace QuanLyKyTucXa.UI
{
    partial class FormXemThongTinSinhVien
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
            tbHopDong = new TabPage();
            btnDangXuat = new Button();
            dgvHopDong = new DataGridView();
            tbThongTinSinhVien = new TabPage();
            btnDangXuat1 = new Button();
            dgvThongTinSinhVien = new DataGridView();
            tabControl1 = new TabControl();
            tbHopDong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHopDong).BeginInit();
            tbThongTinSinhVien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvThongTinSinhVien).BeginInit();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // tbHopDong
            // 
            tbHopDong.BackColor = Color.White;
            tbHopDong.Controls.Add(btnDangXuat);
            tbHopDong.Controls.Add(dgvHopDong);
            tbHopDong.ForeColor = Color.Blue;
            tbHopDong.Location = new Point(4, 29);
            tbHopDong.Name = "tbHopDong";
            tbHopDong.Padding = new Padding(3);
            tbHopDong.Size = new Size(791, 338);
            tbHopDong.TabIndex = 1;
            tbHopDong.Text = "Hợp Đồng Sinh Viên";
            // 
            // btnDangXuat
            // 
            btnDangXuat.BackColor = SystemColors.ActiveCaption;
            btnDangXuat.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDangXuat.Location = new Point(619, 273);
            btnDangXuat.Name = "btnDangXuat";
            btnDangXuat.Size = new Size(165, 56);
            btnDangXuat.TabIndex = 1;
            btnDangXuat.Text = "Đăng xuất";
            btnDangXuat.UseVisualStyleBackColor = false;
            btnDangXuat.Click += btnDangXuat_Click;
            // 
            // dgvHopDong
            // 
            dgvHopDong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHopDong.Location = new Point(-4, 0);
            dgvHopDong.Name = "dgvHopDong";
            dgvHopDong.RowHeadersWidth = 51;
            dgvHopDong.Size = new Size(789, 267);
            dgvHopDong.TabIndex = 0;
            // 
            // tbThongTinSinhVien
            // 
            tbThongTinSinhVien.Controls.Add(btnDangXuat1);
            tbThongTinSinhVien.Controls.Add(dgvThongTinSinhVien);
            tbThongTinSinhVien.ForeColor = Color.Blue;
            tbThongTinSinhVien.Location = new Point(4, 29);
            tbThongTinSinhVien.Name = "tbThongTinSinhVien";
            tbThongTinSinhVien.Padding = new Padding(3);
            tbThongTinSinhVien.Size = new Size(791, 338);
            tbThongTinSinhVien.TabIndex = 0;
            tbThongTinSinhVien.Text = "Thông Tin Cá Nhân";
            tbThongTinSinhVien.UseVisualStyleBackColor = true;
            tbThongTinSinhVien.Click += tbThongTinSinhVien_Click;
            // 
            // btnDangXuat1
            // 
            btnDangXuat1.BackColor = SystemColors.ActiveCaption;
            btnDangXuat1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDangXuat1.ForeColor = SystemColors.ActiveCaptionText;
            btnDangXuat1.Location = new Point(617, 274);
            btnDangXuat1.Name = "btnDangXuat1";
            btnDangXuat1.Size = new Size(168, 54);
            btnDangXuat1.TabIndex = 1;
            btnDangXuat1.Text = "Đăng xuất";
            btnDangXuat1.UseVisualStyleBackColor = false;
            btnDangXuat1.Click += btnDangXuat1_Click;
            // 
            // dgvThongTinSinhVien
            // 
            dgvThongTinSinhVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvThongTinSinhVien.Location = new Point(1, 0);
            dgvThongTinSinhVien.Name = "dgvThongTinSinhVien";
            dgvThongTinSinhVien.RowHeadersWidth = 51;
            dgvThongTinSinhVien.Size = new Size(784, 268);
            dgvThongTinSinhVien.TabIndex = 0;
            dgvThongTinSinhVien.CellContentClick += dgvThongTinSinhVien_CellContentClick;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tbThongTinSinhVien);
            tabControl1.Controls.Add(tbHopDong);
            tabControl1.Location = new Point(0, -5);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(799, 371);
            tabControl1.TabIndex = 0;
            // 
            // FormXemThongTinSinhVien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 365);
            Controls.Add(tabControl1);
            Name = "FormXemThongTinSinhVien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormXemThongTinSinhVien";
            tbHopDong.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHopDong).EndInit();
            tbThongTinSinhVien.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvThongTinSinhVien).EndInit();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabPage tbHopDong;
        private DataGridView dgvHopDong;
        private TabPage tbThongTinSinhVien;
        private DataGridView dgvThongTinSinhVien;
        private TabControl tabControl1;
        private Button btnDangXuat;
        private Button btnDangXuat1;
    }
}