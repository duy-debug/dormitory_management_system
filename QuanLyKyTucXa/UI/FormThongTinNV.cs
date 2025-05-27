using System;
using System.Data;
using System.Windows.Forms;
using QuanLyKyTucXa.Db;

namespace QuanLyKyTucXa.UI
{
    public partial class FormThongTinNV : Form
    {
        private string selectedQL;

        public FormThongTinNV()
        {
            InitializeComponent();
            button2.Click += BtnQuayLai_Click;
            SetupDataGridView();
            LoadData(); // Load tất cả dữ liệu khi khởi tạo form
        }

        public FormThongTinNV(string maQL) : this()
        {
            selectedQL = maQL;
            LoadData(); // Load lại dữ liệu với mã QL được chọn
        }

        private void SetupDataGridView()
        {
            // Thiết lập các cột cho DataGridView
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("MaQuanLi", "Mã Quản Lí");
            dataGridView1.Columns.Add("MaKhu", "Mã Khu");
            dataGridView1.Columns.Add("HoVaTenLot", "Họ và Tên Lót");
            dataGridView1.Columns.Add("TenQuanLi", "Tên Quản Lí");
            dataGridView1.Columns.Add("GioiTinh", "Giới Tính");
            dataGridView1.Columns.Add("SDT", "Số Điện Thoại");
            dataGridView1.Columns.Add("QueQuan", "Quê Quán");

            // Thiết lập độ rộng cụ thể cho từng cột
            dataGridView1.Columns["MaQuanLi"].Width = 100;
            dataGridView1.Columns["MaKhu"].Width = 100;
            dataGridView1.Columns["HoVaTenLot"].Width = 150;
            dataGridView1.Columns["TenQuanLi"].Width = 120;
            dataGridView1.Columns["GioiTinh"].Width = 100;
            dataGridView1.Columns["SDT"].Width = 120;
            dataGridView1.Columns["QueQuan"].Width = 400;

            // Thiết lập căn chỉnh cho các cột
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            // Cho phép wrap text ở tất cả các cột
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
        }

        private void LoadData()
        {
            try
            {
                // Xóa dữ liệu cũ
                dataGridView1.Rows.Clear();

                // Tạo câu truy vấn SQL
                string query;
                if (string.IsNullOrEmpty(selectedQL))
                {
                    query = "SELECT * FROM QuanLiKTX";
                }
                else
                {
                    query = $"SELECT * FROM QuanLiKTX WHERE MaQuanLi = '{selectedQL}'";
                }

                // Thực thi truy vấn và lấy dữ liệu
                DataTable dataTable = DatabaseConnection.ExecuteQuery(query);

                // Thêm dữ liệu vào DataGridView
                foreach (DataRow row in dataTable.Rows)
                {
                    dataGridView1.Rows.Add(
                        row["MaQuanLi"].ToString(),
                        row["MaKhu"].ToString(),
                        row["HoVaTenLot"].ToString(),
                        row["TenQuanLi"].ToString(),
                        row["GioiTinh"].ToString(),
                        row["SDT"].ToString(),
                        row["QueQuan"].ToString()
                    );
                }

                // Refresh DataGridView để hiển thị dữ liệu mới
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnQuayLai_Click(object sender, EventArgs e)
        {
            FormQLNV formQLNV = new FormQLNV();
            formQLNV.TopLevel = false;
            formQLNV.FormBorderStyle = FormBorderStyle.None;
            formQLNV.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(formQLNV);
            formQLNV.Show();
        }
    }
}
