using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKyTucXa.Db;

namespace QuanLyKyTucXa.UI
{
    public partial class FormSuaThongTInKhu : Form
    {
        private Form parentForm;

        public FormSuaThongTInKhu(Form parent = null)
        {
            InitializeComponent();
            this.parentForm = parent;

            // Đăng ký sự kiện click cho các nút
            button2.Click += Button2_Click; // Nút Quay Lại
            button1.Click += Button1_Click; // Nút Sửa Khu

            // Thiết lập form
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (parentForm != null)
            {
                // Xóa form hiện tại khỏi parent
                parentForm.Controls.Remove(this);

                // Tạo và hiển thị FormKhuPhong mới
                FormKhuPhong formKhuPhong = new FormKhuPhong();
                formKhuPhong.TopLevel = false;
                formKhuPhong.FormBorderStyle = FormBorderStyle.None;
                formKhuPhong.Dock = DockStyle.Fill;

                parentForm.Controls.Add(formKhuPhong);
                formKhuPhong.Show();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ các textbox
                string maKhu = textBox1.Text.Trim();
                string maTang = textBox6.Text.Trim();
                string soTang = textBox2.Text.Trim();
                string soPhong = textBox3.Text.Trim();
                string phanLoai = textBox4.Text.Trim();
                string doiTuong = textBox5.Text.Trim();

                // Kiểm tra dữ liệu không được để trống
                if (string.IsNullOrEmpty(maKhu) || string.IsNullOrEmpty(maTang) ||
                    string.IsNullOrEmpty(soTang) || string.IsNullOrEmpty(soPhong) ||
                    string.IsNullOrEmpty(phanLoai) || string.IsNullOrEmpty(doiTuong))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra mã tầng không được lớn hơn số tầng
                if (int.Parse(maTang) > int.Parse(soTang))
                {
                    MessageBox.Show($"Mã tầng không thể lớn hơn số tầng! (Mã tầng: {maTang}, Số tầng: {soTang})",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Cập nhật thông tin khu trong database
                string updateKhuQuery = $@"
                    UPDATE KHU 
                    SET SLTang = {soTang}, PhanLoai = N'{phanLoai}'
                    WHERE MaKhu = '{maKhu}'";

                string updateTangQuery = $@"
                    UPDATE Tang 
                    SET SLPhong = {soPhong}, DoiTuong = N'{doiTuong}'
                    WHERE MaKhu = '{maKhu}' AND MaTang = '{maTang}'";

                // Thực hiện cập nhật
                DatabaseConnection.ExecuteQuery(updateKhuQuery);
                DatabaseConnection.ExecuteQuery(updateTangQuery);

                MessageBox.Show("Cập nhật thông tin khu thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Quay lại form Khu Phòng
                Button2_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật thông tin: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void XoaKhu(string maKhu)
        {
            try
            {
                // Xóa thông tin từ bảng Tang trước
                string deleteTangQuery = $"DELETE FROM Tang WHERE MaKhu = '{maKhu}'";
                DatabaseConnection.ExecuteQuery(deleteTangQuery);

                // Sau đó xóa thông tin từ bảng KHU
                string deleteKhuQuery = $"DELETE FROM KHU WHERE MaKhu = '{maKhu}'";
                DatabaseConnection.ExecuteQuery(deleteKhuQuery);

                MessageBox.Show($"Đã xóa thông tin khu {maKhu} thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa thông tin: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
