using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKyTucXa.Db;

namespace QuanLyKyTucXa.UI
{
    public partial class FormThongTinLoaiPhong : Form
    {
        private string selectedKhu;

        public FormThongTinLoaiPhong(string maKhu)
        {
            try
            {
                InitializeComponent();
                this.selectedKhu = maKhu;

                // Hiển thị mã khu đang xem
                this.Text = $"Thông Tin Loại Phòng - Khu {maKhu}";
                label1.Text = $"THÔNG TIN LOẠI PHÒNG - KHU {maKhu}";

                // Đăng ký sự kiện click cho nút Quay Lại
                button2.Click += Button2_Click;

                // Kiểm tra xem có dữ liệu trong bảng Phong không
                VerifyPhongTableData();

                // Cấu hình DataGridView và load dữ liệu
                ConfigureDataGridView();
                LoadDataFromDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi tạo form: {ex.Message}\nStack Trace: {ex.StackTrace}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                // Quay lại form trước đó nếu có lỗi
                Button2_Click(null, EventArgs.Empty);
            }
        }

        private void VerifyPhongTableData()
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Phong";
                object result = DatabaseConnection.ExecuteScalar(query);
                int count = Convert.ToInt32(result);

                if (count == 0)
                {
                    MessageBox.Show("Bảng Phong không có dữ liệu nào!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Kiểm tra dữ liệu cho khu được chọn
                    query = "SELECT COUNT(*) FROM Phong WHERE MaKhu = @MaKhu";
                    var parameters = new SqlParameter[]
                    {
                        new SqlParameter("@MaKhu", selectedKhu)
                    };
                    result = DatabaseConnection.ExecuteScalar(query, parameters);
                    count = Convert.ToInt32(result);

                    if (count == 0)
                    {
                        MessageBox.Show($"Không có dữ liệu phòng nào cho khu {selectedKhu}!", "Cảnh báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kiểm tra dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureDataGridView()
        {
            try
            {
                // Xóa tất cả cột hiện có
                dataGridView1.Columns.Clear();

                // Thêm các cột mới
                dataGridView1.Columns.Add("MaKhu", "Mã Khu");
                dataGridView1.Columns.Add("MaTang", "Mã Tầng");
                dataGridView1.Columns.Add("MaPhong", "Mã Phòng");
                dataGridView1.Columns.Add("GiaPhong", "Giá Phòng");
                dataGridView1.Columns.Add("SucChua", "Sức Chứa");

                // Cấu hình thuộc tính của DataGridView
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.ReadOnly = true;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi cấu hình DataGridView: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDataFromDatabase()
        {
            try
            {
                if (string.IsNullOrEmpty(selectedKhu))
                {
                    MessageBox.Show("Mã khu không được để trống!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string query = @"
                    SELECT MaKhu, MaTang, MaPhong, GiaPhong, SucChua 
                    FROM Phong 
                    WHERE MaKhu = @MaKhu 
                    ORDER BY MaTang, MaPhong";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaKhu", selectedKhu)
                };

                DataTable dt = DatabaseConnection.ExecuteQuery(query, parameters);

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show($"Không tìm thấy thông tin phòng cho khu {selectedKhu}", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Xóa dữ liệu cũ trong DataGridView
                dataGridView1.Rows.Clear();

                // Thêm dữ liệu mới vào DataGridView
                foreach (DataRow row in dt.Rows)
                {
                    dataGridView1.Rows.Add(
                        row["MaKhu"]?.ToString(),
                        row["MaTang"]?.ToString(),
                        row["MaPhong"]?.ToString(),
                        row["GiaPhong"] != null ? string.Format("{0:N0}", row["GiaPhong"]) : "",
                        row["SucChua"]?.ToString()
                    );
                }

                // Hiển thị tổng số phòng
                this.Text = $"Thông Tin Loại Phòng - Khu {selectedKhu} - {dt.Rows.Count} phòng";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load dữ liệu: {ex.Message}\nStack Trace: {ex.StackTrace}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Hiển thị FormLoaiPhong trong cùng window
                FormLoaiPhong formLoaiPhong = new FormLoaiPhong();
                formLoaiPhong.TopLevel = false;
                formLoaiPhong.FormBorderStyle = FormBorderStyle.None;
                formLoaiPhong.Dock = DockStyle.Fill;

                if (this.Parent != null)
                {
                    this.Parent.Controls.Add(formLoaiPhong);
                    formLoaiPhong.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không thể tìm thấy form cha!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi quay lại: {ex.Message}\nStack Trace: {ex.StackTrace}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
