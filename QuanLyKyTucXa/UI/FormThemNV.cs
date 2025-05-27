using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLyKyTucXa.Db;

namespace QuanLyKyTucXa.UI
{
    public partial class FormThemNV : Form
    {
        private SqlConnection conn;

        public FormThemNV()
        {
            InitializeComponent();
            conn = DatabaseConnection.GetConnection();

            button2.Click += BtnQuayLai_Click;
            button1.Click += BtnThemNhanVien_Click;

            // Thêm các giá trị vào ComboBox giới tính
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Nam");
            comboBox1.Items.Add("Nữ");
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            // Thêm sự kiện validate cho textBox1 (Mã Nhân Viên)
            textBox1.TextChanged += TextBox1_TextChanged;

            // Load danh sách mã khu từ database
            LoadDanhSachMaKhu();
        }

        private void LoadDanhSachMaKhu()
        {
            try
            {
                string query = "SELECT MaKhu FROM KHU ORDER BY MaKhu";
                DataTable dt = DatabaseConnection.ExecuteQuery(query);

                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        textBox6.AutoCompleteCustomSource.Add(row["MaKhu"].ToString());
                    }
                }

                textBox6.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                textBox6.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách mã khu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            // Đảm bảo mã nhân viên theo định dạng "QL" + số
            if (textBox1.Text.Length > 0 && !textBox1.Text.StartsWith("QL"))
            {
                textBox1.Text = "QL" + textBox1.Text;
                textBox1.SelectionStart = textBox1.Text.Length;
            }
        }

        private bool KiemTraNhanVienTonTai(string maNV)
        {
            try
            {
                string query = $"SELECT COUNT(*) FROM QuanLiKTX WHERE MaQuanLi = @MaNV";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaNV", maNV)
                };
                object result = DatabaseConnection.ExecuteScalar(query, parameters);
                return Convert.ToInt32(result) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi kiểm tra nhân viên tồn tại: " + ex.Message);
            }
        }

        private bool KiemTraMaKhuTonTai(string maKhu)
        {
            try
            {
                string query = $"SELECT COUNT(*) FROM KHU WHERE MaKhu = @MaKhu";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaKhu", maKhu)
                };
                object result = DatabaseConnection.ExecuteScalar(query, parameters);
                return Convert.ToInt32(result) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi kiểm tra mã khu tồn tại: " + ex.Message);
            }
        }

        private void BtnThemNhanVien_Click(object sender, EventArgs e)
        {
            try
            {
                string maNV = textBox1.Text;
                string maKhu = textBox6.Text;
                string hoTenLot = textBox2.Text;
                string tenNV = textBox3.Text;
                string gioiTinh = comboBox1.SelectedItem?.ToString();
                string soDienThoai = textBox4.Text;
                string queQuan = textBox5.Text;

                if (string.IsNullOrEmpty(maNV) || string.IsNullOrEmpty(maKhu) || 
                    string.IsNullOrEmpty(hoTenLot) || string.IsNullOrEmpty(tenNV) || 
                    string.IsNullOrEmpty(gioiTinh) || string.IsNullOrEmpty(soDienThoai) || 
                    string.IsNullOrEmpty(queQuan))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (KiemTraNhanVienTonTai(maNV))
                {
                    MessageBox.Show("Mã quản lý đã tồn tại!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!KiemTraMaKhuTonTai(maKhu))
                {
                    MessageBox.Show("Mã khu không tồn tại! Vui lòng chọn mã khu hợp lệ.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query = @"INSERT INTO QuanLiKTX (MaQuanLi, MaKhu, HoVaTenLot, TenQuanLi, GioiTinh, SDT, QueQuan) 
                               VALUES (@MaNV, @MaKhu, @HoTenLot, @TenNV, @GioiTinh, @SoDienThoai, @QueQuan)";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaNV", maNV),
                    new SqlParameter("@MaKhu", maKhu),
                    new SqlParameter("@HoTenLot", hoTenLot),
                    new SqlParameter("@TenNV", tenNV),
                    new SqlParameter("@GioiTinh", gioiTinh),
                    new SqlParameter("@SoDienThoai", soDienThoai),
                    new SqlParameter("@QueQuan", queQuan)
                };

                int result = DatabaseConnection.ExecuteNonQuery(query, parameters);
                
                if (result > 0)
                {
                    MessageBox.Show("Đã thêm quản lý mới thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Quay lại form QLNV và cập nhật danh sách
                    FormQLNV formQLNV = new FormQLNV();
                    formQLNV.TopLevel = false;
                    formQLNV.FormBorderStyle = FormBorderStyle.None;
                    formQLNV.Dock = DockStyle.Fill;
                    this.Controls.Clear();
                    this.Controls.Add(formQLNV);
                    formQLNV.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
