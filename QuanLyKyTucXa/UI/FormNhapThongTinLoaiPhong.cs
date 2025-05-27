using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QuanLyKyTucXa.Db;

namespace QuanLyKyTucXa.UI
{
    public partial class FormNhapThongTinLoaiPhong : Form
    {
        private string selectedKhu;

        public FormNhapThongTinLoaiPhong(string maKhu)
        {
            InitializeComponent();
            
            // Lưu mã khu được chọn
            this.selectedKhu = maKhu;
            
            // Đăng ký sự kiện click cho nút Quay Lại
            button2.Click += Button2_Click;

            // Cấu hình DataGridView và load dữ liệu
            ConfigureDataGridView();
            LoadDataFromDatabase();
        }

        private void ConfigureDataGridView()
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

        private void LoadDataFromDatabase()
        {
            try
            {
                string query = $@"
                    SELECT MaKhu, MaTang, MaPhong, GiaPhong, SucChua 
                    FROM Phong 
                    WHERE MaKhu = '{selectedKhu}'";

                DataTable dt = DatabaseConnection.ExecuteQuery(query);

                // Xóa dữ liệu cũ trong DataGridView
                dataGridView1.Rows.Clear();

                // Thêm dữ liệu mới vào DataGridView
                foreach (DataRow row in dt.Rows)
                {
                    dataGridView1.Rows.Add(
                        row["MaKhu"].ToString(),
                        row["MaTang"].ToString(),
                        row["MaPhong"].ToString(),
                        string.Format("{0:N0}", row["GiaPhong"]), // Format số tiền
                        row["SucChua"].ToString()
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load dữ liệu: {ex.Message}", "Lỗi", 
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
