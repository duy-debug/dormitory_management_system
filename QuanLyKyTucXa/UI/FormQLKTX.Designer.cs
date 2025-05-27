namespace QuanLyKyTucXa
{
    partial class FormQLKTX
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormQLKTX));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            btnThemKhuPhong = new Button();
            pictureBox3 = new PictureBox();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(594, 22);
            label1.Name = "label1";
            label1.Size = new Size(329, 46);
            label1.TabIndex = 0;
            label1.Text = "QUẢN LÝ KÝ TÚC XÁ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label2.Location = new Point(263, 288);
            label2.Name = "label2";
            label2.Size = new Size(53, 31);
            label2.TabIndex = 1;
            label2.Text = "Khu";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label3.Location = new Point(726, 288);
            label3.Name = "label3";
            label3.Size = new Size(80, 31);
            label3.TabIndex = 2;
            label3.Text = "Phòng";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(671, 112);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(179, 150);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(202, 112);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(176, 159);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // btnThemKhuPhong
            // 
            btnThemKhuPhong.BackColor = SystemColors.Highlight;
            btnThemKhuPhong.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnThemKhuPhong.Location = new Point(56, 22);
            btnThemKhuPhong.Name = "btnThemKhuPhong";
            btnThemKhuPhong.Size = new Size(200, 46);
            btnThemKhuPhong.TabIndex = 18;
            btnThemKhuPhong.Text = "ĐĂNG XUẤT";
            btnThemKhuPhong.UseVisualStyleBackColor = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(1103, 112);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(171, 159);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 19;
            pictureBox3.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 163);
            label4.Location = new Point(1136, 288);
            label4.Name = "label4";
            label4.Size = new Size(117, 31);
            label4.TabIndex = 20;
            label4.Text = "Nhân viên";
            // 
            // FormQLKTX
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1471, 917);
            Controls.Add(label4);
            Controls.Add(pictureBox3);
            Controls.Add(btnThemKhuPhong);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormQLKTX";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormQLKTX";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Button btnThemKhuPhong;
        private PictureBox pictureBox3;
        private Label label4;
    }
}