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
using System.Data.SqlClient;

namespace QuanLyKyTucXa.UI
{
    public partial class FormThemKhuPhong : Form
    {
        private Form parentForm;

        public FormThemKhuPhong(Form parent = null)
        {
            InitializeComponent();
            this.parentForm = parent;

            // Đăng ký sự kiện click cho các nút
            button2.Click += Button2_Click; // Nút Quay Lại
            button1.Click += Button1_Click; // Nút Thêm Khu

            // Thêm sự kiện validate cho textBox1 (Mã Khu)
            textBox1.TextChanged += TextBox1_TextChanged;

            // Thiết lập vị trí form
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            // Đảm bảo mã khu theo định dạng "K" + số
            if (textBox1.Text.Length > 0 && !textBox1.Text.StartsWith("K"))
            {
                textBox1.Text = "K" + textBox1.Text;
                textBox1.SelectionStart = textBox1.Text.Length;
            }
        }

        private bool KiemTraKhuTonTai(string maKhu)
        {
            try
            {
                string query = $"SELECT COUNT(*) FROM KHU WHERE MaKhu = '{maKhu}'";
                object result = DatabaseConnection.ExecuteScalar(query);
                return Convert.ToInt32(result) > 0;
                }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi kiểm tra khu tồn tại: " + ex.Message);
            }
        }

        private void ThemThongTinKhu()
        {
            try
            {
                string maKhu = textBox1.Text;
                string maTang = textBox6.Text;
                string soTang = textBox2.Text;
                string soPhong = textBox3.Text;
                string phanLoai = textBox4.Text;
                string doiTuong = textBox5.Text;

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

                bool khuTonTai = KiemTraKhuTonTai(maKhu);

                if (khuTonTai)
                {
                    // Thêm thông tin tầng vào khu đã tồn tại
                    string insertTangQuery = $@"
                        INSERT INTO TANG (MaKhu, MaTang, SLPhong, DoiTuong) 
                        VALUES ('{maKhu}', '{maTang}', {soPhong}, N'{doiTuong}')";

                    DatabaseConnection.ExecuteNonQuery(insertTangQuery);
                        MessageBox.Show("Đã thêm thông tin tầng vào khu " + maKhu + " thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Thêm khu mới
                    string insertKhuQuery = $@"
                        INSERT INTO KHU (MaKhu, SLTang, PhanLoai) 
                        VALUES ('{maKhu}', {soTang}, N'{phanLoai}')";
                    
                    DatabaseConnection.ExecuteNonQuery(insertKhuQuery);

                    // Thêm thông tin tầng cho khu mới
                    string insertTangQuery = $@"
                        INSERT INTO TANG (MaKhu, MaTang, SLPhong, DoiTuong) 
                        VALUES ('{maKhu}', '{maTang}', {soPhong}, N'{doiTuong}')";

                    DatabaseConnection.ExecuteNonQuery(insertTangQuery);
                        MessageBox.Show("Đã thêm khu mới và thông tin thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Sau khi thêm thành công, quay lại form Khu Phòng
                if (parentForm != null)
                {
                    FormKhuPhong formKhuPhong = new FormKhuPhong();
                    formKhuPhong.TopLevel = false;
                    formKhuPhong.FormBorderStyle = FormBorderStyle.None;
                    formKhuPhong.Dock = DockStyle.Fill;
                    
                    // Xóa form hiện tại khỏi parent
                    parentForm.Controls.Clear();

                    // Thêm form mới vào parent
                    parentForm.Controls.Add(formKhuPhong);
                    formKhuPhong.Show();
                    
                    // Đóng form hiện tại
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (parentForm != null)
                {
                    FormKhuPhong formKhuPhong = new FormKhuPhong();
                    formKhuPhong.TopLevel = false;
                    formKhuPhong.FormBorderStyle = FormBorderStyle.None;
                    formKhuPhong.Dock = DockStyle.Fill;
                    
                    // Xóa form hiện tại khỏi parent
                    parentForm.Controls.Clear();

                    // Thêm form mới vào parent
                    parentForm.Controls.Add(formKhuPhong);
                    formKhuPhong.Show();
                    
                    // Đóng form hiện tại
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi quay lại: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ThemThongTinKhu();
        }
    }
}
