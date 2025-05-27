#nullable disable

using System;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using QuanLyKyTucXa;

namespace QuanLyKyTucXa.UI
{
    public partial class FormQuanLySinhVien : Form
    {
        private DataTable dtSinhVien;

        public FormQuanLySinhVien()
        {
            InitializeComponent();
            LoadSinhVien();
            InitializeControls();

            // Đăng ký sự kiện cho nút Quay lại
            this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);
        }

        private void InitializeControls()
        {
            try
            {
                // Load Khu
                string queryKhu = "SELECT MaKhu FROM KHU";
                DataTable dtKhu = DatabaseHelper.ExecuteQuery(queryKhu);
                cboKhu.DataSource = dtKhu;
                cboKhu.DisplayMember = "MaKhu";
                cboKhu.ValueMember = "MaKhu";
                cboKhu.SelectedIndex = -1;

                // Load Ưu tiên
                string queryUuTien = "SELECT MaUuTien, MoTa FROM QuyDinhUuTien";
                DataTable dtUuTien = DatabaseHelper.ExecuteQuery(queryUuTien);
                cboUuTien.DataSource = dtUuTien;
                cboUuTien.DisplayMember = "MoTa";
                cboUuTien.ValueMember = "MaUuTien";
                cboUuTien.SelectedIndex = -1;

                // Set up Giới tính
                cboGioiTinh.Items.Clear();
                cboGioiTinh.Items.AddRange(new string[] { "Nam", "Nữ" });
                cboGioiTinh.SelectedIndex = -1;

                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo form: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSinhVien()
        {
            string query = @"SELECT sv.MaSV, sv.HovaTenLot + ' ' + sv.Ten as HoTen, 
                           sv.NgaySinh, sv.GioiTinh, sv.Email, sv.DiaChi,
                           sv.MaKhu, sv.MaTang, sv.MaPhong, ut.MoTa as UuTien,
                           sv.MaUuTien
                           FROM SinhVien sv
                           LEFT JOIN QuyDinhUuTien ut ON sv.MaUuTien = ut.MaUuTien";
            dtSinhVien = DatabaseHelper.ExecuteQuery(query);
            dgvSinhVien.DataSource = dtSinhVien;
        }

        private void ClearForm()
        {
            txtMaSV.Clear();
            txtHoTenLot.Clear();
            txtTen.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            cboGioiTinh.SelectedIndex = -1;
            txtEmail.Clear();
            txtDiaChi.Clear();
            cboKhu.SelectedIndex = -1;
            cboTang.SelectedIndex = -1;
            cboPhong.SelectedIndex = -1;
            cboUuTien.SelectedIndex = -1;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaSV.Text))
                {
                    MessageBox.Show("Vui lòng nhập mã sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaSV.Focus();
                    return;
                }

                string maSV = txtMaSV.Text.Trim();
                string hoTenLot = txtHoTenLot.Text.Trim();
                string ten = txtTen.Text.Trim();
                string ngaySinh = dtpNgaySinh.Value.ToString("yyyy-MM-dd");
                string gioiTinh = cboGioiTinh.Text;
                string email = txtEmail.Text.Trim();
                string diaChi = txtDiaChi.Text.Trim();
                string maKhu = cboKhu.SelectedValue?.ToString();
                string maTang = cboTang.SelectedValue?.ToString();
                string maPhong = cboPhong.SelectedValue?.ToString();
                string maUuTien = cboUuTien.SelectedValue == null ? "NULL" : $"'{cboUuTien.SelectedValue}'";

                string query = $@"INSERT INTO SinhVien (MaSV, HovaTenLot, Ten, NgaySinh, GioiTinh, 
                                Email, DiaChi, MaKhu, MaTang, MaPhong, MaUuTien)
                                VALUES ('{maSV}', N'{hoTenLot}', N'{ten}', '{ngaySinh}', N'{gioiTinh}', 
                                '{email}', N'{diaChi}', '{maKhu}', {maTang}, {maPhong}, {maUuTien})";

                int result = DatabaseHelper.ExecuteNonQuery(query);
                if (result > 0)
                {
                    MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadSinhVien();
                    ClearForm();
                    txtMaSV.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm sinh viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaSV.Text))
                {
                    MessageBox.Show("Vui lòng chọn sinh viên cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvSinhVien.Focus();
                    return;
                }

                string maSV = txtMaSV.Text.Trim();
                string hoTenLot = txtHoTenLot.Text.Trim();
                string ten = txtTen.Text.Trim();
                string ngaySinh = dtpNgaySinh.Value.ToString("yyyy-MM-dd");
                string gioiTinh = cboGioiTinh.Text;
                string email = txtEmail.Text.Trim();
                string diaChi = txtDiaChi.Text.Trim();
                string maKhu = cboKhu.SelectedValue?.ToString();
                string maTang = cboTang.SelectedValue?.ToString();
                string maPhong = cboPhong.SelectedValue?.ToString();
                string maUuTien = cboUuTien.SelectedValue == null ? "NULL" : $"'{cboUuTien.SelectedValue}'";

                string query = $@"UPDATE SinhVien 
                                SET HovaTenLot = N'{hoTenLot}', Ten = N'{ten}', 
                                NgaySinh = '{ngaySinh}', GioiTinh = N'{gioiTinh}',
                                Email = '{email}', DiaChi = N'{diaChi}', 
                                MaKhu = '{maKhu}', MaTang = {maTang}, MaPhong = {maPhong},
                                MaUuTien = {maUuTien}
                                WHERE MaSV = '{maSV}'";

                int result = DatabaseHelper.ExecuteNonQuery(query);
                if (result > 0)
                {
                    MessageBox.Show("Cập nhật sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadSinhVien();
                    ClearForm();
                    dgvSinhVien.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật sinh viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa sinh viên này?", "Xác nhận",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string maSV = txtMaSV.Text;
                string query = $"DELETE FROM SinhVien WHERE MaSV = '{maSV}'";

                if (DatabaseHelper.ExecuteNonQuery(query) > 0)
                {
                    MessageBox.Show("Xóa sinh viên thành công!");
                    LoadSinhVien();
                    ClearForm();
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string searchText = txtTimKiem.Text.Trim();
            string query = $@"SELECT sv.MaSV, sv.HovaTenLot + ' ' + sv.Ten as HoTen, 
                           sv.NgaySinh, sv.GioiTinh, sv.Email, sv.DiaChi,
                           sv.MaKhu, sv.MaTang, sv.MaPhong, ut.MoTa as UuTien
                           FROM SinhVien sv
                           LEFT JOIN QuyDinhUuTien ut ON sv.MaUuTien = ut.MaUuTien
                           WHERE sv.MaSV LIKE '%{searchText}%'
                           OR sv.HovaTenLot LIKE N'%{searchText}%'
                           OR sv.Ten LIKE N'%{searchText}%'
                           OR sv.Email LIKE '%{searchText}%'";

            dtSinhVien = DatabaseHelper.ExecuteQuery(query);
            dgvSinhVien.DataSource = dtSinhVien;
        }

        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvSinhVien.Rows[e.RowIndex];

                    txtMaSV.Text = row.Cells["MaSV"].Value?.ToString() ?? "";

                    string hoTen = row.Cells["HoTen"].Value?.ToString() ?? "";
                    string[] hoTenParts = hoTen.Split(' ');
                    if (hoTenParts.Length > 0)
                    {
                        txtTen.Text = hoTenParts[hoTenParts.Length - 1];
                        txtHoTenLot.Text = string.Join(" ", hoTenParts.Take(hoTenParts.Length - 1));
                    }

                    if (row.Cells["NgaySinh"].Value != null)
                    {
                        dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
                    }

                    cboGioiTinh.Text = row.Cells["GioiTinh"].Value?.ToString() ?? "";
                    txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
                    txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString() ?? "";

                    string maKhu = row.Cells["MaKhu"].Value?.ToString() ?? "";
                    if (!string.IsNullOrEmpty(maKhu))
                    {
                        cboKhu.SelectedValue = maKhu;

                        string maTang = row.Cells["MaTang"].Value?.ToString() ?? "";
                        if (!string.IsNullOrEmpty(maTang))
                        {
                            cboTang.SelectedValue = maTang;

                            string maPhong = row.Cells["MaPhong"].Value?.ToString() ?? "";
                            if (!string.IsNullOrEmpty(maPhong))
                            {
                                cboPhong.SelectedValue = maPhong;
                            }
                        }
                    }

                    string uuTien = row.Cells["UuTien"].Value?.ToString();
                    if (!string.IsNullOrEmpty(uuTien))
                    {
                        for (int i = 0; i < cboUuTien.Items.Count; i++)
                        {
                            DataRowView item = cboUuTien.Items[i] as DataRowView;
                            if (item != null && item["MoTa"].ToString() == uuTien)
                            {
                                cboUuTien.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                    else
                    {
                        cboUuTien.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load thông tin sinh viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearForm();
            }
        }

        private void cboKhu_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cboTang.DataSource = null;
                cboPhong.DataSource = null;

                if (cboKhu.SelectedValue != null)
                {
                    string maKhu = cboKhu.SelectedValue.ToString();
                    string queryTang = $"SELECT MaTang FROM Tang WHERE MaKhu = '{maKhu}'";
                    DataTable dtTang = DatabaseHelper.ExecuteQuery(queryTang);
                    cboTang.DataSource = dtTang;
                    cboTang.DisplayMember = "MaTang";
                    cboTang.ValueMember = "MaTang";
                }

                cboTang.SelectedIndex = -1;
                cboPhong.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load dữ liệu tầng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboTang_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cboPhong.DataSource = null;

                if (cboKhu.SelectedValue != null && cboTang.SelectedValue != null)
                {
                    string maKhu = cboKhu.SelectedValue.ToString();
                    string maTang = cboTang.SelectedValue.ToString();
                    string queryPhong = $"SELECT MaPhong FROM Phong WHERE MaKhu = '{maKhu}' AND MaTang = {maTang}";
                    DataTable dtPhong = DatabaseHelper.ExecuteQuery(queryPhong);
                    cboPhong.DataSource = dtPhong;
                    cboPhong.DisplayMember = "MaPhong";
                    cboPhong.ValueMember = "MaPhong";
                }

                cboPhong.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load dữ liệu phòng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}