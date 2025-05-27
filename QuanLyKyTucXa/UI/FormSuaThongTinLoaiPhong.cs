using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QuanLyKyTucXa.Db;

namespace QuanLyKyTucXa.UI
{
    public partial class FormSuaThongTinLoaiPhong : Form
    {
        public FormSuaThongTinLoaiPhong()
        {
            InitializeComponent();
            
            // Đăng ký sự kiện click cho các nút
            button2.Click += Button2_Click; // Nút Quay Lại
            button1.Click += Button1_Click; // Nút Sửa
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ các textbox
                string maKhu = textBox1.Text.Trim();
                string maTang = textBox6.Text.Trim();
                string soTang = textBox2.Text.Trim();
                decimal giaPhong;
                int sucChua;

                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(maKhu) || string.IsNullOrEmpty(maTang) || 
                    string.IsNullOrEmpty(soTang) || string.IsNullOrEmpty(textBox3.Text) || 
                    string.IsNullOrEmpty(textBox4.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra và chuyển đổi giá phòng
                if (!decimal.TryParse(textBox3.Text.Trim(), out giaPhong))
                {
                    MessageBox.Show("Giá phòng không hợp lệ!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra và chuyển đổi sức chứa
                if (!int.TryParse(textBox4.Text.Trim(), out sucChua))
                {
                    MessageBox.Show("Sức chứa không hợp lệ!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cập nhật thông tin phòng
                string updateQuery = @"
                    UPDATE Phong 
                    SET GiaPhong = @GiaPhong,
                        SucChua = @SucChua
                    WHERE MaKhu = @MaKhu 
                    AND MaTang = @MaTang";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaKhu", maKhu),
                    new SqlParameter("@MaTang", maTang),
                    new SqlParameter("@GiaPhong", giaPhong),
                    new SqlParameter("@SucChua", sucChua)
                };

                int result = DatabaseConnection.ExecuteNonQuery(updateQuery, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Cập nhật thông tin phòng thành công!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Quay lại form Loại Phòng
                    Button2_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy phòng cần cập nhật!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật thông tin: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // Hiển thị FormLoaiPhong trong cùng window
            FormLoaiPhong formLoaiPhong = new FormLoaiPhong();
            formLoaiPhong.TopLevel = false;
            formLoaiPhong.FormBorderStyle = FormBorderStyle.None;
            formLoaiPhong.Dock = DockStyle.Fill;
            
            this.Parent.Controls.Add(formLoaiPhong);
            formLoaiPhong.Show();
            this.Close();
        }
    }
}
