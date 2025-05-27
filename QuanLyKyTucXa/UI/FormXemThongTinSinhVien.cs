using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKyTucXa.Models;

namespace QuanLyKyTucXa.UI
{
    public partial class FormXemThongTinSinhVien : Form
    {
        private string tenDangNhap;

        // Constructor with parameter
        public FormXemThongTinSinhVien(string tenDangNhap)
        {
            InitializeComponent();
            this.tenDangNhap = tenDangNhap;
            LoadThongTinSinhVien();
            LoadHopDong();
        }

        private void LoadThongTinSinhVien()
        {
            try
            {
                DataTable dt = SinhVienModel.LayThongTinSinhVien(tenDangNhap);
                if (dt.Rows.Count > 0)
                {
                    dgvThongTinSinhVien.DataSource = dt;
                    dgvThongTinSinhVien.ReadOnly = true;
                    dgvThongTinSinhVien.AllowUserToAddRows = false;
                    dgvThongTinSinhVien.ClearSelection();
                    dgvThongTinSinhVien.Columns["MaSV"].HeaderText = "Mã sinh viên";
                    dgvThongTinSinhVien.Columns["MaKhu"].HeaderText = "Mã khu";
                    dgvThongTinSinhVien.Columns["MaTang"].HeaderText = "Mã tầng";
                    dgvThongTinSinhVien.Columns["MaPhong"].HeaderText = "Mã phòng";
                    dgvThongTinSinhVien.Columns["HovaTenLot"].HeaderText = "Họ và tên lót";
                    dgvThongTinSinhVien.Columns["Ten"].HeaderText = "Tên";
                    dgvThongTinSinhVien.Columns["NgaySinh"].HeaderText = "Ngày sinh";
                    dgvThongTinSinhVien.Columns["GioiTinh"].HeaderText = "Giới tính";
                    dgvThongTinSinhVien.Columns["Email"].HeaderText = "Email";
                    dgvThongTinSinhVien.Columns["DiaChi"].HeaderText = "Địa chỉ";
                    dgvThongTinSinhVien.Columns["MaUuTien"].HeaderText = "Mã ưu tiên";
                    dgvThongTinSinhVien.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin sinh viên!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbThongTinSinhVien_Click(object sender, EventArgs e)
        {
            LoadThongTinSinhVien();
        }

        private void dgvThongTinSinhVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xử lý sự kiện click vào cell nếu cần
        }

        private void LoadHopDong()
        {
            try
            {
                string maSV = tenDangNhap; // Giả sử MaSV = tenDangNhap
                var dt = QuanLyKyTucXa.Models.HopDongModel.LayDanhSachHopDongTheoSinhVien(maSV);
                dgvHopDong.DataSource = dt;
                dgvHopDong.ReadOnly = true;
                dgvHopDong.AllowUserToAddRows = false;
                dgvHopDong.ClearSelection();
                if (dt.Columns.Contains("MaSV"))
                    dgvHopDong.Columns["MaSV"].HeaderText = "Mã sinh viên";
                if (dt.Columns.Contains("NgayApDung"))
                    dgvHopDong.Columns["NgayApDung"].HeaderText = "Ngày áp dụng";
                if (dt.Columns.Contains("NgayHetHan"))
                    dgvHopDong.Columns["NgayHetHan"].HeaderText = "Ngày hết hạn";
                dgvHopDong.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDangXuat1_Click(object sender, EventArgs e)
        {
            FormDangNhap formDangNhap = new FormDangNhap();
            formDangNhap.Show();
            this.Close();
        }
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            FormDangNhap formDangNhap = new FormDangNhap();
            formDangNhap.Show();
            this.Close();
        }
    }
}
