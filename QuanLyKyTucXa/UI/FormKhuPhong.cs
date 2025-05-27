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
using QuanLyKyTucXa.Models;

namespace QuanLyKyTucXa.UI
{
    public partial class FormKhuPhong : Form
    {
        public FormKhuPhong()
        {
            InitializeComponent();

            // Đăng ký sự kiện click cho các nút
            btnThemKhuPhong.Click += BtnThemKhuPhong_Click;
            btnSuaThongTinKhu.Click += BtnSuaThongTinKhu_Click;
            button2.Click += Button2_Click;

            // Đăng ký sự kiện click cho các nút khu
            button1.Click += ButtonKhu_Click; // K1
            button8.Click += ButtonKhu_Click; // K2
            button7.Click += ButtonKhu_Click; // K3
            button4.Click += ButtonKhu_Click; // K4
            button5.Click += ButtonKhu_Click; // K5
            button6.Click += ButtonKhu_Click; // K6
            button3.Click += ButtonKhu_Click; // K7
            button9.Click += ButtonKhu_Click; // K8

            // Load danh sách khu từ database
            LoadDanhSachKhu();

            // Điều chỉnh kích thước form
            this.ClientSize = new Size(1200, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void LoadDanhSachKhu()
        {
            try
            {
                // Xóa tất cả các button khu cũ (trừ các button mặc định)
                foreach (Control ctrl in this.Controls.Cast<Control>().ToList())
                {
                    if (ctrl is Button btn && btn.Name.StartsWith("btnKhu_"))
                    {
                        this.Controls.Remove(btn);
                        btn.Dispose();
                    }
                }

                // Lấy danh sách khu từ database
                string query = @"
                    SELECT MaKhu 
                    FROM KHU 
                    WHERE MaKhu NOT IN ('K1', 'K2', 'K3', 'K4', 'K5', 'K6', 'K7', 'K8')";

                DataTable dt = DatabaseConnection.ExecuteQuery(query);

                // Chuyển DataTable thành List và sắp xếp
                var khuList = new List<string>();
                foreach (DataRow row in dt.Rows)
                {
                    khuList.Add(row["MaKhu"].ToString());
                }

                // Sắp xếp theo số trong mã khu
                khuList.Sort((a, b) => {
                    int numA = int.Parse(a.Substring(1));
                    int numB = int.Parse(b.Substring(1));
                    return numA.CompareTo(numB);
                });

                // Lấy thuộc tính từ nút K8 làm chuẩn
                Button referenceButton = button9; // K8
                int startX = referenceButton.Left;
                int buttonWidth = referenceButton.Width;
                int buttonHeight = referenceButton.Height;
                int spacing = 50; // Khoảng cách giữa các nút
                int nextY = referenceButton.Bottom + spacing;

                // Tạo các nút mới với thuộc tính giống hệt nút K8
                foreach (string maKhu in khuList)
                {
                    Button newButton = new Button();
                    newButton.Name = $"btnKhu_{maKhu}";
                    newButton.Text = maKhu;
                    newButton.Font = referenceButton.Font;
                    newButton.Size = referenceButton.Size;
                    newButton.Location = new Point(startX, nextY);
                    newButton.UseVisualStyleBackColor = true;
                    newButton.FlatStyle = referenceButton.FlatStyle;
                    newButton.BackColor = referenceButton.BackColor;
                    newButton.ForeColor = referenceButton.ForeColor;
                    newButton.Click += ButtonKhu_Click;

                    this.Controls.Add(newButton);
                    nextY = newButton.Bottom + spacing;
                }

                // Điều chỉnh kích thước form nếu cần
                int minHeight = nextY + 50; // Thêm khoảng trống ở dưới
                if (this.ClientSize.Height < minHeight)
                {
                    this.ClientSize = new Size(this.ClientSize.Width, minHeight);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách khu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void XoaKhu(string maKhu)
        {
            try
            {
                // Xóa dữ liệu từ bảng TANG trước
                string deleteTangQuery = $"DELETE FROM TANG WHERE MaKhu = '{maKhu}'";
                DatabaseConnection.ExecuteNonQuery(deleteTangQuery);

                // Sau đó xóa từ bảng KHU
                string deleteKhuQuery = $"DELETE FROM KHU WHERE MaKhu = '{maKhu}'";
                DatabaseConnection.ExecuteNonQuery(deleteKhuQuery);

                MessageBox.Show($"Đã xóa khu {maKhu} thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reload lại danh sách khu
                LoadDanhSachKhu();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa khu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // Tạo instance của FormQLKTX
            FormQLKTX formQLKTX = new FormQLKTX();

            // Thiết lập các thuộc tính để form mới thay thế form hiện tại
            formQLKTX.TopLevel = false;
            formQLKTX.FormBorderStyle = FormBorderStyle.None;
            formQLKTX.Dock = DockStyle.Fill;

            // Xóa tất cả controls hiện tại
            this.Controls.Clear();

            // Thêm form mới vào
            this.Controls.Add(formQLKTX);

            // Hiển thị form mới
            formQLKTX.Show();
        }

        private void BtnThemKhuPhong_Click(object sender, EventArgs e)
        {
            // Tạo instance của FormThemKhuPhong và truyền form hiện tại làm parent
            FormThemKhuPhong formThemKhu = new FormThemKhuPhong(this);
            formThemKhu.ShowDialog(); // Hiển thị form như một dialog độc lập
            
            // Sau khi form đóng, reload lại danh sách khu
            LoadDanhSachKhu();
        }

        private void BtnSuaThongTinKhu_Click(object sender, EventArgs e)
        {
            // Tạo instance của FormSuaThongTInKhu và truyền form hiện tại làm parent
            FormSuaThongTInKhu formSuaKhu = new FormSuaThongTInKhu(this);

            // Xóa tất cả controls hiện tại
            this.Controls.Clear();

            // Thêm form mới vào
            this.Controls.Add(formSuaKhu);

            // Hiển thị form mới
            formSuaKhu.Show();
        }

        private void ButtonKhu_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string maKhu = button.Text;

            // Hiển thị dialog xác nhận xóa
            if (ModifierKeys == Keys.Control)
            {
                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa khu {maKhu}?", "Xác nhận xóa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    XoaKhu(maKhu);
                    return;
                }
            }

            // Nếu không phải Ctrl+Click, hiển thị thông tin khu như bình thường
            FormThongTinKhuPhong formThongTin = new FormThongTinKhuPhong(maKhu, this);
            formThongTin.TopLevel = false;
            formThongTin.FormBorderStyle = FormBorderStyle.None;
            formThongTin.Dock = DockStyle.Fill;

            this.Controls.Clear();
            this.Controls.Add(formThongTin);
            formThongTin.Show();
        }

        private void FormKhuPhong_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
