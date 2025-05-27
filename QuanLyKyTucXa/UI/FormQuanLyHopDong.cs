#nullable disable

using System;
using System.Data;
using System.Windows.Forms;
using QuanLyKyTucXa;

namespace QuanLyKyTucXa.UI
{
    public partial class FormQuanLyHopDong : Form
    {
        private DataTable dtHopDong;

        public FormQuanLyHopDong()
        {
            InitializeComponent();
            LoadHopDong();
            InitializeControls();

            // Đăng ký sự kiện cho nút Quay lại
            btnQuayLai.Click += new EventHandler(btnQuayLai_Click);
        }

        private void InitializeControls()
        {
            try
            {
                // Set default values for date pickers
                dtpNgayApDung.Value = DateTime.Now;
                dtpNgayHetHan.Value = DateTime.Now.AddMonths(6);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo form: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormQuanLyHopDong_Load(object sender, EventArgs e)
        {
            // Form load event handler required by designer
            InitializeControls();
        }

        private void LoadHopDong()
        {
            string query = @"SELECT hd.MaHD, hd.MaSV, sv.HovaTenLot + ' ' + sv.Ten as HoTen,
                           hd.NgayApDung, hd.NgayHetHan,
                           sv.MaKhu, sv.MaTang, sv.MaPhong
                           FROM HopDongKTX hd
                           JOIN SinhVien sv ON hd.MaSV = sv.MaSV";
            dtHopDong = DatabaseHelper.ExecuteQuery(query);
            dgvHopDong.DataSource = dtHopDong;
        }

        private void ClearForm()
        {
            txtMaHD.Clear();
            txtMaSV.Clear();
            dtpNgayApDung.Value = DateTime.Now;
            dtpNgayHetHan.Value = DateTime.Now.AddMonths(6);
        }

        private void btnLapHopDong_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaHD.Text))
                {
                    MessageBox.Show("Vui lòng nhập mã hợp đồng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaHD.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtMaSV.Text))
                {
                    MessageBox.Show("Vui lòng nhập mã sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaSV.Focus();
                    return;
                }

                string maHD = txtMaHD.Text.Trim();
                string maSV = txtMaSV.Text.Trim();
                string ngayApDung = dtpNgayApDung.Value.ToString("yyyy-MM-dd");
                string ngayHetHan = dtpNgayHetHan.Value.ToString("yyyy-MM-dd");

                // Kiểm tra mã hợp đồng đã tồn tại
                string checkQuery = $"SELECT COUNT(*) FROM HopDongKTX WHERE MaHD = '{maHD}'";
                int exists = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkQuery));
                if (exists > 0)
                {
                    MessageBox.Show("Mã hợp đồng đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaHD.Focus();
                    return;
                }

                // Kiểm tra sinh viên tồn tại
                checkQuery = $"SELECT COUNT(*) FROM SinhVien WHERE MaSV = '{maSV}'";
                exists = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkQuery));
                if (exists == 0)
                {
                    MessageBox.Show("Không tìm thấy sinh viên với mã này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaSV.Focus();
                    return;
                }

                // Kiểm tra sinh viên đã có hợp đồng còn hiệu lực
                checkQuery = $@"SELECT COUNT(*) FROM HopDongKTX 
                              WHERE MaSV = '{maSV}' 
                              AND NgayHetHan >= GETDATE()";
                exists = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkQuery));
                if (exists > 0)
                {
                    MessageBox.Show("Sinh viên đã có hợp đồng còn hiệu lực!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaSV.Focus();
                    return;
                }

                string query = $@"INSERT INTO HopDongKTX (MaHD, MaSV, NgayApDung, NgayHetHan)
                                VALUES ('{maHD}', '{maSV}', '{ngayApDung}', '{ngayHetHan}')";

                int result = DatabaseHelper.ExecuteNonQuery(query);
                if (result > 0)
                {
                    MessageBox.Show("Lập hợp đồng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadHopDong();
                    ClearForm();
                    txtMaHD.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lập hợp đồng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChamDut_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaHD.Text))
                {
                    MessageBox.Show("Vui lòng chọn hợp đồng cần chấm dứt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvHopDong.Focus();
                    return;
                }

                string maHD = txtMaHD.Text.Trim();

                // Kiểm tra hợp đồng tồn tại
                string checkQuery = $"SELECT COUNT(*) FROM HopDongKTX WHERE MaHD = '{maHD}'";
                int exists = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkQuery));
                if (exists == 0)
                {
                    MessageBox.Show("Không tìm thấy hợp đồng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Bạn có chắc muốn chấm dứt và xóa hợp đồng này?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Xóa hợp đồng thay vì cập nhật ngày hết hạn
                    string query = $"DELETE FROM HopDongKTX WHERE MaHD = '{maHD}'";

                    int result = DatabaseHelper.ExecuteNonQuery(query);
                    if (result > 0)
                    {
                        MessageBox.Show("Đã xóa hợp đồng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadHopDong();
                        ClearForm();
                        dgvHopDong.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa hợp đồng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGiaHan_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaHD.Text))
                {
                    MessageBox.Show("Vui lòng chọn hợp đồng cần gia hạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvHopDong.Focus();
                    return;
                }

                string maHD = txtMaHD.Text.Trim();
                string ngayHetHan = dtpNgayHetHan.Value.ToString("yyyy-MM-dd");

                string query = $"UPDATE HopDongKTX SET NgayHetHan = '{ngayHetHan}' WHERE MaHD = '{maHD}'";

                int result = DatabaseHelper.ExecuteNonQuery(query);
                if (result > 0)
                {
                    MessageBox.Show("Gia hạn hợp đồng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadHopDong();
                    ClearForm();
                    dgvHopDong.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gia hạn hợp đồng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string searchText = txtTimKiem.Text.Trim();
            string query = $@"SELECT hd.MaHD, hd.MaSV, sv.HovaTenLot + ' ' + sv.Ten as HoTen,
                           hd.NgayApDung, hd.NgayHetHan,
                           sv.MaKhu, sv.MaTang, sv.MaPhong
                           FROM HopDongKTX hd
                           JOIN SinhVien sv ON hd.MaSV = sv.MaSV
                           WHERE hd.MaHD LIKE '%{searchText}%'
                           OR hd.MaSV LIKE '%{searchText}%'
                           OR sv.HovaTenLot LIKE N'%{searchText}%'
                           OR sv.Ten LIKE N'%{searchText}%'";

            dtHopDong = DatabaseHelper.ExecuteQuery(query);
            dgvHopDong.DataSource = dtHopDong;
        }

        private void dgvHopDong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvHopDong.Rows[e.RowIndex];
                    txtMaHD.Text = row.Cells["MaHD"].Value?.ToString();
                    txtMaSV.Text = row.Cells["MaSV"].Value?.ToString();

                    if (row.Cells["NgayApDung"].Value != null)
                    {
                        dtpNgayApDung.Value = Convert.ToDateTime(row.Cells["NgayApDung"].Value);
                    }

                    if (row.Cells["NgayHetHan"].Value != null)
                    {
                        dtpNgayHetHan.Value = Convert.ToDateTime(row.Cells["NgayHetHan"].Value);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load thông tin hợp đồng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearForm();
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}