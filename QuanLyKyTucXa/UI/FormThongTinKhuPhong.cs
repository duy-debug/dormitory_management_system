using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QuanLyKyTucXa.Db;

namespace QuanLyKyTucXa.UI
{
    public partial class FormThongTinKhuPhong : Form
    {
        private string maKhu;
        private Form parentForm;

        public FormThongTinKhuPhong(string maKhu, Form parent = null)
        {
            InitializeComponent();
            this.maKhu = maKhu;
            this.parentForm = parent;
            this.Load += FormThongTinKhuPhong_Load;
            label1.Text = $"THÔNG TIN KHU {maKhu}";
            button2.Click += Button2_Click;
        }

        private void FormThongTinKhuPhong_Load(object sender, EventArgs e)
        {
            LoadThongTinKhu();
        }

        private void LoadThongTinKhu()
        {
            try
            {
                string query = $@"
                    SELECT t.MaTang, k.SLTang as SoTang, t.SLPhong as SoPhong, k.PhanLoai, t.DoiTuong 
                    FROM KHU k
                    LEFT JOIN TANG t ON k.MaKhu = t.MaKhu
                    WHERE k.MaKhu = '{maKhu}' 
                    ORDER BY t.MaTang";

                DataTable dt = DatabaseConnection.ExecuteQuery(query);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show($"Không tìm thấy thông tin cho khu {maKhu}", "Thông báo", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    dataGridView1.DataSource = dt;
                    
                    // Đặt tên cột tiếng Việt
                    dataGridView1.Columns["MaTang"].HeaderText = "Mã Tầng";
                    dataGridView1.Columns["SoTang"].HeaderText = "Số Tầng";
                    dataGridView1.Columns["SoPhong"].HeaderText = "Số Phòng";
                    dataGridView1.Columns["PhanLoai"].HeaderText = "Phân Loại";
                    dataGridView1.Columns["DoiTuong"].HeaderText = "Đối Tượng";

                    // Căn chỉnh độ rộng cột
                    dataGridView1.AutoResizeColumns();

                    // Định dạng DataGridView
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.AllowUserToDeleteRows = false;
                    dataGridView1.ReadOnly = true;
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.MultiSelect = false;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin khu: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (parentForm != null)
                {
                    // Xóa form hiện tại
                    this.Dispose();

                    // Tạo form mới
                    FormKhuPhong formKhuPhong = new FormKhuPhong();
                    formKhuPhong.TopLevel = false;
                    formKhuPhong.FormBorderStyle = FormBorderStyle.None;
                    formKhuPhong.Dock = DockStyle.Fill;

                    // Thêm form mới vào parent
                    parentForm.Controls.Add(formKhuPhong);
                    formKhuPhong.Show();
                }
                else
                {
                    // Nếu không có parent form, tạo form mới và hiển thị như form độc lập
                    FormKhuPhong formKhuPhong = new FormKhuPhong();
                    formKhuPhong.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi quay lại: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
