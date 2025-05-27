namespace QuanLyKyTucXa
{
    partial class FormDangNhap
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
            btnDangNhap = new Button();
            label1 = new Label();
            label2 = new Label();
            txbtendangnhap = new TextBox();
            txbmatkhau = new TextBox();
            label3 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // btnDangNhap
            // 
            btnDangNhap.BackColor = SystemColors.Highlight;
            btnDangNhap.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDangNhap.Location = new Point(363, 272);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(123, 41);
            btnDangNhap.TabIndex = 0;
            btnDangNhap.Text = "Đăng nhập";
            btnDangNhap.UseVisualStyleBackColor = false;
            btnDangNhap.Click += btnDangNhap_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveCaption;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(239, 221);
            label1.Name = "label1";
            label1.Size = new Size(98, 28);
            label1.TabIndex = 1;
            label1.Text = "Mật khẩu:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ActiveCaption;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(188, 170);
            label2.Name = "label2";
            label2.Size = new Size(149, 28);
            label2.TabIndex = 2;
            label2.Text = "Tên đăng nhập: ";
            // 
            // txbtendangnhap
            // 
            txbtendangnhap.Location = new Point(363, 170);
            txbtendangnhap.Name = "txbtendangnhap";
            txbtendangnhap.Size = new Size(255, 27);
            txbtendangnhap.TabIndex = 3;
            // 
            // txbmatkhau
            // 
            txbmatkhau.Location = new Point(363, 221);
            txbmatkhau.Name = "txbmatkhau";
            txbmatkhau.Size = new Size(255, 27);
            txbmatkhau.TabIndex = 4;
            txbmatkhau.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ControlLightLight;
            label3.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Red;
            label3.Location = new Point(53, 40);
            label3.Name = "label3";
            label3.Size = new Size(716, 38);
            label3.TabIndex = 2;
            label3.Text = "QUẢN LÝ KÝ TÚC XÁ TRƯỜNG ĐẠI HỌC NHA TRANG";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Highlight;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(492, 272);
            button1.Name = "button1";
            button1.Size = new Size(126, 38);
            button1.TabIndex = 5;
            button1.Text = "Thoát";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // FormDangNhap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Banner;
            ClientSize = new Size(797, 517);
            Controls.Add(button1);
            Controls.Add(txbmatkhau);
            Controls.Add(txbtendangnhap);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnDangNhap);
            Name = "FormDangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "QUẢN LÝ KÝ TÚC XÁ";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDangNhap;
        private Label label1;
        private Label label2;
        private TextBox txbtendangnhap;
        private TextBox txbmatkhau;
        private Label label3;
        private Button button1;
    }
}