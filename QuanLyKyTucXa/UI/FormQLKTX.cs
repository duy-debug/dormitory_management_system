using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKyTucXa.UI;

namespace QuanLyKyTucXa
{
    public partial class FormQLKTX : Form
    {
        public FormQLKTX()
        {
            InitializeComponent();

            // Đăng ký sự kiện click cho label và pictureBox Khu
            label2.Click += Label2_Click;
            pictureBox1.Click += PictureBox1_Click;

            // Đăng ký sự kiện click cho label và pictureBox Phòng
            label3.Click += Label3_Click;
            pictureBox2.Click += PictureBox2_Click;

            // Đăng ký sự kiện click cho label và pictureBox Quản trị
            label4.Click += Label4_Click;
            pictureBox3.Click += PictureBox3_Click;

            // Đăng ký sự kiện click cho nút Đăng Xuất
            btnThemKhuPhong.Click += BtnDangXuat_Click;
        }

        private void BtnDangXuat_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                // Tìm form gốc (form chứa tất cả)
                Form mainForm = FindMainForm();
                if (mainForm != null)
                {
                    // Tạo form đăng nhập mới
                    FormDangNhap formDangNhap = new FormDangNhap();
                    formDangNhap.TopLevel = false;
                    formDangNhap.FormBorderStyle = FormBorderStyle.None;
                    formDangNhap.Dock = DockStyle.Fill;

                    // Xóa tất cả controls trong form gốc
                    mainForm.Controls.Clear();
                    
                    // Thêm form đăng nhập vào form gốc
                    mainForm.Controls.Add(formDangNhap);
                    formDangNhap.Show();
                }
                else
                {
                    // Nếu không tìm thấy form gốc, tạo form đăng nhập mới độc lập
                    FormDangNhap formDangNhap = new FormDangNhap();
                    formDangNhap.StartPosition = FormStartPosition.CenterScreen;
                    formDangNhap.Show();
                    
                    // Đóng tất cả các form hiện tại
                    foreach (Form form in Application.OpenForms)
                    {
                        if (form != formDangNhap)
                        {
                            form.Hide();
                        }
                    }
                }
            }
        }

        private Form FindMainForm()
        {
            // Tìm form gốc bằng cách đi ngược lên các parent
            Control current = this;
            while (current != null)
            {
                if (current is Form)
                {
                    // Kiểm tra xem form này có phải là form gốc không
                    if (current.Parent == null)
                    {
                        return current as Form;
                    }
                }
                current = current.Parent;
            }
            return null;
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            OpenFormKhuPhong();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            OpenFormKhuPhong();
        }

        private void Label3_Click(object sender, EventArgs e)
        {
            OpenFormLoaiPhong();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            OpenFormLoaiPhong();
        }

        private void Label4_Click(object sender, EventArgs e)
        {
            OpenFormQuanLyNhanVien();
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            OpenFormQuanLyNhanVien();
        }

        private void OpenFormKhuPhong()
        {
            // Tạo instance của FormKhuPhong
            FormKhuPhong formKhuPhong = new FormKhuPhong();
            
            // Thiết lập các thuộc tính để form mới thay thế form hiện tại
            formKhuPhong.TopLevel = false;
            formKhuPhong.FormBorderStyle = FormBorderStyle.None;
            formKhuPhong.Dock = DockStyle.Fill;

            // Xóa tất cả controls hiện tại
            this.Controls.Clear();
            
            // Thêm form mới vào
            this.Controls.Add(formKhuPhong);
            
            // Hiển thị form mới
            formKhuPhong.Show();
        }

        private void OpenFormLoaiPhong()
        {
            // Tạo instance của FormLoaiPhong
            FormLoaiPhong formLoaiPhong = new FormLoaiPhong();
            
            // Thiết lập các thuộc tính để form mới thay thế form hiện tại
            formLoaiPhong.TopLevel = false;
            formLoaiPhong.FormBorderStyle = FormBorderStyle.None;
            formLoaiPhong.Dock = DockStyle.Fill;

            // Xóa tất cả controls hiện tại
            this.Controls.Clear();
            
            // Thêm form mới vào
            this.Controls.Add(formLoaiPhong);
            
            // Hiển thị form mới
            formLoaiPhong.Show();
        }

        private void OpenFormQuanLyNhanVien()
        {
            // Tạo instance của FormQLNV
            FormQLNV formQLNV = new FormQLNV();
            
            // Thiết lập các thuộc tính để form mới thay thế form hiện tại
            formQLNV.TopLevel = false;
            formQLNV.FormBorderStyle = FormBorderStyle.None;
            formQLNV.Dock = DockStyle.Fill;

            // Xóa tất cả controls hiện tại
            this.Controls.Clear();
            
            // Thêm form mới vào
            this.Controls.Add(formQLNV);
            
            // Hiển thị form mới
            formQLNV.Show();
        }
    }
}
