using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKyTucXa.UI
{
    public partial class FormLoaiPhong : Form
    {
        public FormLoaiPhong()
        {
            InitializeComponent();
            
            // Đăng ký sự kiện click cho nút Quay Lại
            button2.Click += Button2_Click;
            
            // Đăng ký sự kiện click cho nút Sửa Thông Tin
            btnSuaThongTinKhu.Click += BtnSuaThongTinKhu_Click;
            
            // Đăng ký sự kiện click cho các nút K1-K8
            button1.Click += (s, e) => Button_KhuClick(s, e, "K1");
            button8.Click += (s, e) => Button_KhuClick(s, e, "K2");
            button7.Click += (s, e) => Button_KhuClick(s, e, "K3");
            button4.Click += (s, e) => Button_KhuClick(s, e, "K4");
            button5.Click += (s, e) => Button_KhuClick(s, e, "K5");
            button6.Click += (s, e) => Button_KhuClick(s, e, "K6");
            button3.Click += (s, e) => Button_KhuClick(s, e, "K7");
            button9.Click += (s, e) => Button_KhuClick(s, e, "K8");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Hiển thị FormQLKTX trong cùng window
                FormQLKTX formQLKTX = new FormQLKTX();
                formQLKTX.TopLevel = false;
                formQLKTX.FormBorderStyle = FormBorderStyle.None;
                formQLKTX.Dock = DockStyle.Fill;
                
                if (this.Parent != null)
                {
                    this.Parent.Controls.Add(formQLKTX);
                    formQLKTX.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy form cha!", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi chuyển form: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSuaThongTinKhu_Click(object sender, EventArgs e)
        {
            try
            {
                // Hiển thị FormSuaThongTinLoaiPhong trong cùng window
                FormSuaThongTinLoaiPhong formSua = new FormSuaThongTinLoaiPhong();
                formSua.TopLevel = false;
                formSua.FormBorderStyle = FormBorderStyle.None;
                formSua.Dock = DockStyle.Fill;
                
                if (this.Parent != null)
                {
                    this.Parent.Controls.Add(formSua);
                    formSua.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy form cha!", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi chuyển form: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button_KhuClick(object sender, EventArgs e, string maKhu)
        {
            try
            {
                if (string.IsNullOrEmpty(maKhu))
                {
                    MessageBox.Show("Mã khu không được để trống!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra xem form cha có tồn tại không
                if (this.Parent == null)
                {
                    MessageBox.Show("Không tìm thấy form cha!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tạo và cấu hình form mới
                FormThongTinLoaiPhong formThongTin = new FormThongTinLoaiPhong(maKhu);
                formThongTin.TopLevel = false;
                formThongTin.FormBorderStyle = FormBorderStyle.None;
                formThongTin.Dock = DockStyle.Fill;

                // Xóa form hiện tại khỏi parent trước khi thêm form mới
                Control parent = this.Parent;
                parent.Controls.Remove(this);
                parent.Controls.Add(formThongTin);
                
                // Hiển thị form mới
                formThongTin.Show();
                this.Dispose(); // Giải phóng tài nguyên của form cũ
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi chuyển form: {ex.Message}\nStack Trace: {ex.StackTrace}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
