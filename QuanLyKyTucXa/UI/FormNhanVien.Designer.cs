namespace QuanLyKyTucXa.UI
{
    partial class FormNhanVien
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
            panelLeft = new Panel();
            btnDangXuat = new Button();
            lblStaffInfo = new Label();
            panelRight = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnQuanLySinhVien = new Button();
            btnQuanLyHopDong = new Button();
            btnQuanLyHoaDon = new Button();
            lblTitle = new Label();
            label1 = new Label();
            panelLeft.SuspendLayout();
            panelRight.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelLeft
            // 
            panelLeft.BackColor = SystemColors.Info;
            panelLeft.Controls.Add(btnDangXuat);
            panelLeft.Controls.Add(label1);
            panelLeft.Controls.Add(lblStaffInfo);
            panelLeft.Dock = DockStyle.Fill;
            panelLeft.Location = new Point(0, 138);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(875, 424);
            panelLeft.TabIndex = 1;
            // 
            // btnDangXuat
            // 
            btnDangXuat.BackColor = Color.FromArgb(192, 0, 0);
            btnDangXuat.FlatStyle = FlatStyle.Flat;
            btnDangXuat.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnDangXuat.ForeColor = Color.White;
            btnDangXuat.Location = new Point(22, 350);
            btnDangXuat.Name = "btnDangXuat";
            btnDangXuat.Size = new Size(150, 45);
            btnDangXuat.TabIndex = 2;
            btnDangXuat.Text = "Đăng xuất";
            btnDangXuat.UseVisualStyleBackColor = false;
            // 
            // lblStaffInfo
            // 
            lblStaffInfo.AutoSize = true;
            lblStaffInfo.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStaffInfo.ForeColor = Color.Black;
            lblStaffInfo.Location = new Point(22, 69);
            lblStaffInfo.Name = "lblStaffInfo";
            lblStaffInfo.Size = new Size(0, 30);
            lblStaffInfo.TabIndex = 0;
            // 
            // panelRight
            // 
            panelRight.BackColor = Color.White;
            panelRight.Controls.Add(tableLayoutPanel1);
            panelRight.Controls.Add(panelLeft);
            panelRight.Controls.Add(lblTitle);
            panelRight.Dock = DockStyle.Fill;
            panelRight.Location = new Point(0, 0);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(875, 562);
            panelRight.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = SystemColors.MenuBar;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(btnQuanLySinhVien, 0, 0);
            tableLayoutPanel1.Controls.Add(btnQuanLyHopDong, 0, 1);
            tableLayoutPanel1.Controls.Add(btnQuanLyHoaDon, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Right;
            tableLayoutPanel1.Location = new Point(390, 138);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Size = new Size(485, 424);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // btnQuanLySinhVien
            // 
            btnQuanLySinhVien.BackColor = SystemColors.Highlight;
            btnQuanLySinhVien.Dock = DockStyle.Fill;
            btnQuanLySinhVien.FlatStyle = FlatStyle.Flat;
            btnQuanLySinhVien.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnQuanLySinhVien.ForeColor = Color.White;
            btnQuanLySinhVien.Location = new Point(3, 3);
            btnQuanLySinhVien.Name = "btnQuanLySinhVien";
            btnQuanLySinhVien.Size = new Size(479, 135);
            btnQuanLySinhVien.TabIndex = 1;
            btnQuanLySinhVien.Text = "Quản Lý Sinh Viên";
            btnQuanLySinhVien.UseVisualStyleBackColor = false;
            btnQuanLySinhVien.Click += btnQuanLySinhVien_Click;
            // 
            // btnQuanLyHopDong
            // 
            btnQuanLyHopDong.BackColor = SystemColors.Highlight;
            btnQuanLyHopDong.Dock = DockStyle.Fill;
            btnQuanLyHopDong.FlatStyle = FlatStyle.Flat;
            btnQuanLyHopDong.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnQuanLyHopDong.ForeColor = Color.White;
            btnQuanLyHopDong.Location = new Point(3, 144);
            btnQuanLyHopDong.Name = "btnQuanLyHopDong";
            btnQuanLyHopDong.Size = new Size(479, 135);
            btnQuanLyHopDong.TabIndex = 2;
            btnQuanLyHopDong.Text = "Quản Lý Hợp Đồng";
            btnQuanLyHopDong.UseVisualStyleBackColor = false;
            btnQuanLyHopDong.Click += btnQuanLyHopDong_Click;
            // 
            // btnQuanLyHoaDon
            // 
            btnQuanLyHoaDon.BackColor = SystemColors.Highlight;
            btnQuanLyHoaDon.Dock = DockStyle.Fill;
            btnQuanLyHoaDon.FlatStyle = FlatStyle.Flat;
            btnQuanLyHoaDon.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnQuanLyHoaDon.ForeColor = Color.White;
            btnQuanLyHoaDon.Location = new Point(3, 285);
            btnQuanLyHoaDon.Name = "btnQuanLyHoaDon";
            btnQuanLyHoaDon.Size = new Size(479, 136);
            btnQuanLyHoaDon.TabIndex = 3;
            btnQuanLyHoaDon.Text = "Quản Lý Hóa Đơn";
            btnQuanLyHoaDon.UseVisualStyleBackColor = false;
            btnQuanLyHoaDon.Click += btnQuanLyHoaDon_Click;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Gainsboro;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI Black", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = SystemColors.Highlight;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(875, 138);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ KÝ TÚC XÁ";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(10, 13);
            label1.Name = "label1";
            label1.Size = new Size(172, 21);
            label1.TabIndex = 1;
            label1.Text = "Thông Tin Nhân Viên";
            // 
            // FormNhanVien
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(875, 562);
            Controls.Add(panelRight);
            Name = "FormNhanVien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Ký Túc Xá - Nhân Viên";
            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
            panelRight.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Button btnQuanLyHoaDon;
        private System.Windows.Forms.Button btnQuanLyHopDong;
        private System.Windows.Forms.Button btnQuanLySinhVien;
        private System.Windows.Forms.Label lblTitle;
        private TableLayoutPanel tableLayoutPanel1;
        private Label lblStaffInfo;
        private Label label1;
        private Button btnDangXuat;

        #endregion
    }
} 