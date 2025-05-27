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
    public partial class FormQLNV : Form
    {
        private SqlConnection conn;

        public FormQLNV()
        {
            InitializeComponent();
            conn = DatabaseConnection.GetConnection();

            // Đăng ký sự kiện click cho nút Thêm Nhân Viên
            btnThemKhuPhong.Click += BtnThemNhanVien_Click;

            // Đăng ký sự kiện click cho nút Sửa Thông Tin Nhân Viên
            btnSuaThongTinKhu.Click += BtnSuaThongTinNhanVien_Click;

            // Đăng ký sự kiện click cho nút Quay Lại
            button2.Click += BtnQuayLai_Click;

            // Đăng ký sự kiện click cho các nút QL1-QL8
            button1.Click += BtnQL_Click;
            button8.Click += BtnQL_Click;
            button7.Click += BtnQL_Click;
            button4.Click += BtnQL_Click;
            button5.Click += BtnQL_Click;
            button6.Click += BtnQL_Click;
            button3.Click += BtnQL_Click;
            button9.Click += BtnQL_Click;

            // Load danh sách nhân viên từ database
            LoadDanhSachNhanVien();
        }

        private void LoadDanhSachNhanVien()
        {
            try
            {
                // Xóa tất cả các button nhân viên cũ (trừ các button mặc định)
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is Button btn && btn.Name.StartsWith("btnQL_"))
                    {
                        this.Controls.Remove(btn);
                        btn.Dispose();
                    }
                }

                // Lấy danh sách nhân viên từ database
                string query = @"SELECT MaQuanLi as MaNV 
                               FROM QuanLiKTX 
                               WHERE MaQuanLi NOT IN ('QL1', 'QL2', 'QL3', 'QL4', 'QL5', 'QL6', 'QL7', 'QL8') 
                               ORDER BY MaQuanLi";

                DataTable dt = DatabaseConnection.ExecuteQuery(query);

                if (dt != null)
                {
                    int lastButtonBottom = button9.Bottom; // Lấy vị trí bottom của nút QL8
                    int spacing = 10; // Khoảng cách giữa các nút

                    foreach (DataRow row in dt.Rows)
                    {
                        string maNV = row["MaNV"].ToString();

                        // Tạo nút mới
                        Button newButton = new Button();
                        newButton.Name = $"btnQL_{maNV}";
                        newButton.Text = maNV;
                        newButton.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 163);
                        newButton.Location = new Point(52, lastButtonBottom + spacing);
                        newButton.Size = new Size(1049, 40);
                        newButton.UseVisualStyleBackColor = true;
                        newButton.Click += BtnQL_Click;

                        // Thêm nút vào form
                        this.Controls.Add(newButton);

                        lastButtonBottom = newButton.Bottom;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách nhân viên: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnThemNhanVien_Click(object sender, EventArgs e)
        {
            FormThemNV formThemNV = new FormThemNV();
            formThemNV.TopLevel = false;
            formThemNV.FormBorderStyle = FormBorderStyle.None;
            formThemNV.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(formThemNV);
            formThemNV.Show();
        }

        private void BtnSuaThongTinNhanVien_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại nhập mã quản lý
            string maQL = Microsoft.VisualBasic.Interaction.InputBox(
                "Nhập mã quản lý cần sửa thông tin (VD: QL1):",
                "Sửa thông tin nhân viên",
                "",
                -1, -1);

            if (!string.IsNullOrWhiteSpace(maQL))
            {
                FormSuaThongTinNV formSuaThongTinNV = new FormSuaThongTinNV(maQL);
                formSuaThongTinNV.TopLevel = false;
                formSuaThongTinNV.FormBorderStyle = FormBorderStyle.None;
                formSuaThongTinNV.Dock = DockStyle.Fill;
                this.Controls.Clear();
                this.Controls.Add(formSuaThongTinNV);
                formSuaThongTinNV.Show();
            }
        }

        private void BtnQuayLai_Click(object sender, EventArgs e)
        {
            FormQLKTX formQLKTX = new FormQLKTX();
            formQLKTX.TopLevel = false;
            formQLKTX.FormBorderStyle = FormBorderStyle.None;
            formQLKTX.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(formQLKTX);
            formQLKTX.Show();
        }

        private void BtnQL_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string maQL = button.Text;

            // Hiển thị thông tin quản lý
            FormThongTinNV formThongTin = new FormThongTinNV(maQL);
            formThongTin.TopLevel = false;
            formThongTin.FormBorderStyle = FormBorderStyle.None;
            formThongTin.Dock = DockStyle.Fill;

            this.Controls.Clear();
            this.Controls.Add(formThongTin);
            formThongTin.Show();
        }

        private void btnXoaNhanVien_Click(object sender, EventArgs e)
        {
            string maQL = Microsoft.VisualBasic.Interaction.InputBox("Nhập mã quản lý cần xóa (VD: QL1):", "Xóa nhân viên", "", -1, -1);
            if (!string.IsNullOrWhiteSpace(maQL))
            {
                try
                {
                    // Xóa nhân viên từ bảng QuanLiKTX
                    string queryQuanLi = "DELETE FROM QuanLiKTX WHERE MaQuanLi = @MaQuanLi";
                    var parametersQuanLi = new SqlParameter[] { new SqlParameter("@MaQuanLi", maQL) };
                    DatabaseConnection.ExecuteNonQuery(queryQuanLi, parametersQuanLi);

                    // Xóa nhân viên từ bảng NguoiDung
                    string queryNguoiDung = "DELETE FROM NguoiDung WHERE TenDangNhap = @TenDangNhap";
                    var parametersNguoiDung = new SqlParameter[] { new SqlParameter("@TenDangNhap", maQL) };
                    DatabaseConnection.ExecuteNonQuery(queryNguoiDung, parametersNguoiDung);

                    MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachNhanVien(); // Cập nhật lại danh sách nhân viên
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
