using System;
using System.Data;
using System.Windows.Forms;
using QuanLyKyTucXa;

namespace QuanLyKyTucXa.UI
{
    public partial class FormQuanLyHoaDon : Form
    {
        private DataTable dtHoaDon;
        private const decimal GIA_DIEN = 3500; // VND/kWh
        private const decimal GIA_NUOC = 15000; // VND/m3
        private bool isViewingHistory = false; // Biến theo dõi trạng thái xem lịch sử

        public FormQuanLyHoaDon()
        {
            InitializeComponent();
            btnTinhTien.Click += btnTinhTien_Click;
            btnXemLichSu.Click += btnXemLichSu_Click;
            btnXuatHoaDon.Click += btnXuatHoaDon_Click;
            btnQuayLai.Click += btnQuayLai_Click;
            dgvHoaDon.CellClick += DgvHoaDon_CellClick;
            cboKhu.SelectedIndexChanged += cboKhu_SelectedIndexChanged;
            btnThemHoaDon.Click += btnThemHoaDon_Click;
        }

        private void FormQuanLyHoaDon_Load(object sender, EventArgs e)
        {
            LoadKhu();
            LoadHoaDon();
            SetupDataGridView();
            LoadDichVu();

            // Set default values
            numThang.Value = DateTime.Now.Month;
            numNam.Value = DateTime.Now.Year;
        }

        private void LoadDichVu()
        {
            cboDichVu.Items.Clear();
            cboDichVu.Items.Add(new { Text = "Điện", Value = "DV001" });
            cboDichVu.Items.Add(new { Text = "Nước", Value = "DV002" });
            cboDichVu.DisplayMember = "Text";
            cboDichVu.ValueMember = "Value";
        }

        private void SetupDataGridView()
        {
            dgvHoaDon.AutoGenerateColumns = false;
            dgvHoaDon.Columns.Clear();

            dgvHoaDon.Columns.Add("MaKhu", "Khu");
            dgvHoaDon.Columns.Add("MaTang", "Tầng");
            dgvHoaDon.Columns.Add("MaPhong", "Phòng");
            dgvHoaDon.Columns.Add("Thang", "Tháng");
            dgvHoaDon.Columns.Add("Nam", "Năm");
            dgvHoaDon.Columns.Add("TenDV", "Dịch vụ");
            dgvHoaDon.Columns.Add("ChiSoDau", "Chỉ số đầu");
            dgvHoaDon.Columns.Add("ChiSoCuoi", "Chỉ số cuối");
            dgvHoaDon.Columns.Add("TieuThu", "Tiêu thụ");
            dgvHoaDon.Columns.Add("ThanhTien", "Thành tiền");

            foreach (DataGridViewColumn col in dgvHoaDon.Columns)
            {
                col.DataPropertyName = col.Name;
            }

            dgvHoaDon.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
        }

        private void DgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHoaDon.Rows[e.RowIndex];

                cboKhu.Text = row.Cells["MaKhu"].Value.ToString();
                txtTang.Text = row.Cells["MaTang"].Value.ToString();
                txtPhong.Text = row.Cells["MaPhong"].Value.ToString();
                numThang.Value = Convert.ToInt32(row.Cells["Thang"].Value);
                numNam.Value = Convert.ToInt32(row.Cells["Nam"].Value);
                numChiSoDau.Value = Convert.ToInt32(row.Cells["ChiSoDau"].Value);
                numChiSoCuoi.Value = Convert.ToInt32(row.Cells["ChiSoCuoi"].Value);

                string tenDV = row.Cells["TenDV"].Value.ToString();
                foreach (var item in cboDichVu.Items)
                {
                    if (item.GetType().GetProperty("Text").GetValue(item).ToString() == tenDV)
                    {
                        cboDichVu.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private void LoadKhu()
        {
            string query = "SELECT MaKhu FROM Khu ORDER BY MaKhu";
            DataTable dtKhu = DatabaseHelper.ExecuteQuery(query);

            cboKhu.DataSource = dtKhu;
            cboKhu.DisplayMember = "MaKhu";
            cboKhu.ValueMember = "MaKhu";
            cboKhu.SelectedIndex = -1;
        }

        private void LoadHoaDon()
        {
            string query = @"SELECT hd.MaKhu, hd.MaTang, hd.MaPhong, hd.Thang, hd.Nam,
                           hd.MaDV, dv.TenDV, hd.ChiSoDau, hd.ChiSoCuoi,
                           (hd.ChiSoCuoi - hd.ChiSoDau) as TieuThu,
                           CASE 
                               WHEN dv.MaDV = 'DV001' THEN (hd.ChiSoCuoi - hd.ChiSoDau) * @GiaDien
                               WHEN dv.MaDV = 'DV002' THEN (hd.ChiSoCuoi - hd.ChiSoDau) * @GiaNuoc
                           END as ThanhTien
                           FROM HoaDon hd
                           JOIN DichVu dv ON hd.MaDV = dv.MaDV
                           ORDER BY hd.Nam DESC, hd.Thang DESC";

            var parameters = new Dictionary<string, object>
            {
                { "@GiaDien", GIA_DIEN },
                { "@GiaNuoc", GIA_NUOC }
            };

            dtHoaDon = DatabaseHelper.ExecuteQuery(query, parameters);
            dgvHoaDon.DataSource = dtHoaDon;
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            if (!ValidatePhong()) return;

            string maKhu = cboKhu.Text;
            string maTang = txtTang.Text;
            string maPhong = txtPhong.Text;
            int thang = (int)numThang.Value;
            int nam = (int)numNam.Value;

            string query = @"SELECT hd.MaDV, dv.TenDV, (hd.ChiSoCuoi - hd.ChiSoDau) as TieuThu,
                           CASE 
                               WHEN dv.MaDV = 'DV001' THEN (hd.ChiSoCuoi - hd.ChiSoDau) * @GiaDien
                               WHEN dv.MaDV = 'DV002' THEN (hd.ChiSoCuoi - hd.ChiSoDau) * @GiaNuoc
                           END as ThanhTien,
                           p.GiaPhong
                           FROM HoaDon hd
                           JOIN DichVu dv ON hd.MaDV = dv.MaDV
                           JOIN Phong p ON hd.MaKhu = p.MaKhu 
                                AND hd.MaTang = p.MaTang 
                                AND hd.MaPhong = p.MaPhong
                           WHERE hd.MaKhu = @MaKhu
                           AND hd.MaTang = @MaTang
                           AND hd.MaPhong = @MaPhong
                           AND hd.Thang = @Thang
                           AND hd.Nam = @Nam";

            var parameters = new Dictionary<string, object>
            {
                { "@MaKhu", maKhu },
                { "@MaTang", maTang },
                { "@MaPhong", maPhong },
                { "@Thang", thang },
                { "@Nam", nam },
                { "@GiaDien", GIA_DIEN },
                { "@GiaNuoc", GIA_NUOC }
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            if (dt != null && dt.Rows.Count > 0)
            {
                decimal tongTien = 0;
                string chiTiet = "Chi tiết hóa đơn:\n\n";

                foreach (DataRow row in dt.Rows)
                {
                    string tenDV = row["TenDV"].ToString();
                    int tieuThu = Convert.ToInt32(row["TieuThu"]);
                    decimal thanhTien = Convert.ToDecimal(row["ThanhTien"]);
                    tongTien += thanhTien;

                    chiTiet += $"{tenDV}: {tieuThu} x {(row["MaDV"].ToString() == "DV001" ? GIA_DIEN : GIA_NUOC):N0} = {thanhTien:N0} VND\n";
                }

                decimal giaPhong = Convert.ToDecimal(dt.Rows[0]["GiaPhong"]);
                tongTien += giaPhong;
                chiTiet += $"\nTiền phòng: {giaPhong:N0} VND\n";
                chiTiet += $"\nTổng tiền: {tongTien:N0} VND";

                MessageBox.Show(chiTiet, "Thông tin hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin hóa đơn cho phòng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXemLichSu_Click(object sender, EventArgs e)
        {
            if (!ValidatePhong()) return;

            string maKhu = cboKhu.Text;
            string maTang = txtTang.Text;
            string maPhong = txtPhong.Text;

            if (!isViewingHistory)
            {
                // Chuyển sang xem lịch sử
                string query = @"SELECT hd.MaKhu, hd.MaTang, hd.MaPhong, hd.Thang, hd.Nam,
                               dv.TenDV, hd.ChiSoDau, hd.ChiSoCuoi, (hd.ChiSoCuoi - hd.ChiSoDau) as TieuThu,
                               CASE 
                                   WHEN dv.MaDV = 'DV001' THEN (hd.ChiSoCuoi - hd.ChiSoDau) * @GiaDien
                                   WHEN dv.MaDV = 'DV002' THEN (hd.ChiSoCuoi - hd.ChiSoDau) * @GiaNuoc
                               END as ThanhTien
                                FROM HoaDon hd
                                JOIN DichVu dv ON hd.MaDV = dv.MaDV
                               WHERE hd.MaKhu = @MaKhu
                               AND hd.MaTang = @MaTang
                               AND hd.MaPhong = @MaPhong
                               ORDER BY hd.Nam DESC, hd.Thang DESC";

                var parameters = new Dictionary<string, object>
                {
                    { "@MaKhu", maKhu },
                    { "@MaTang", maTang },
                    { "@MaPhong", maPhong },
                    { "@GiaDien", GIA_DIEN },
                    { "@GiaNuoc", GIA_NUOC }
                };

                dtHoaDon = DatabaseHelper.ExecuteQuery(query, parameters);
                dgvHoaDon.DataSource = dtHoaDon;

                if (dtHoaDon.Rows.Count == 0)
                {
                    MessageBox.Show("Không có lịch sử hóa đơn cho phòng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    btnXemLichSu.Text = "Quay lại";
                    isViewingHistory = true;
                }
            }
            else
            {
                // Quay lại xem danh sách hóa đơn
                LoadHoaDon();
                btnXemLichSu.Text = "Xem lịch sử";
                isViewingHistory = false;
            }
        }

        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {
            if (!ValidatePhong()) return;

            string maKhu = cboKhu.Text;
            string maTang = txtTang.Text;
            string maPhong = txtPhong.Text;
            int thang = (int)numThang.Value;
            int nam = (int)numNam.Value;

            string query = @"SELECT hd.MaKhu, hd.MaTang, hd.MaPhong, hd.Thang, hd.Nam,
                           dv.TenDV, hd.ChiSoDau, hd.ChiSoCuoi, (hd.ChiSoCuoi - hd.ChiSoDau) as TieuThu,
                           CASE 
                               WHEN dv.MaDV = 'DV001' THEN (hd.ChiSoCuoi - hd.ChiSoDau) * @GiaDien
                               WHEN dv.MaDV = 'DV002' THEN (hd.ChiSoCuoi - hd.ChiSoDau) * @GiaNuoc
                           END as ThanhTien,
                           p.GiaPhong,
                           sv.HovaTenLot + ' ' + sv.Ten as TenSV
                           FROM HoaDon hd
                           JOIN DichVu dv ON hd.MaDV = dv.MaDV
                           JOIN Phong p ON hd.MaKhu = p.MaKhu 
                                AND hd.MaTang = p.MaTang 
                                AND hd.MaPhong = p.MaPhong
                           JOIN SinhVien sv ON sv.MaKhu = hd.MaKhu 
                                AND sv.MaTang = hd.MaTang 
                                AND sv.MaPhong = hd.MaPhong
                           WHERE hd.MaKhu = @MaKhu
                           AND hd.MaTang = @MaTang
                           AND hd.MaPhong = @MaPhong
                           AND hd.Thang = @Thang
                           AND hd.Nam = @Nam";

            var parameters = new Dictionary<string, object>
            {
                { "@MaKhu", maKhu },
                { "@MaTang", maTang },
                { "@MaPhong", maPhong },
                { "@Thang", thang },
                { "@Nam", nam },
                { "@GiaDien", GIA_DIEN },
                { "@GiaNuoc", GIA_NUOC }
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            if (dt != null && dt.Rows.Count > 0)
            {
                decimal tongTien = 0;
                string hoaDon = $@"HÓA ĐƠN TIỀN PHÒNG KÝ TÚC XÁ
Tháng {thang}/{nam}

Thông tin phòng:
Khu: {maKhu}
Tầng: {maTang}
Phòng: {maPhong}
Sinh viên: {dt.Rows[0]["TenSV"]}

Chi tiết:
";
                foreach (DataRow row in dt.Rows)
                {
                    string tenDV = row["TenDV"].ToString();
                    int chiSoDau = Convert.ToInt32(row["ChiSoDau"]);
                    int chiSoCuoi = Convert.ToInt32(row["ChiSoCuoi"]);
                    int tieuThu = Convert.ToInt32(row["TieuThu"]);
                    decimal thanhTien = Convert.ToDecimal(row["ThanhTien"]);
                    tongTien += thanhTien;

                    hoaDon += $"\n{tenDV}:\n";
                    hoaDon += $"Chỉ số đầu: {chiSoDau}\n";
                    hoaDon += $"Chỉ số cuối: {chiSoCuoi}\n";
                    hoaDon += $"Tiêu thụ: {tieuThu}\n";
                    hoaDon += $"Đơn giá: {(tenDV == "Điện" ? GIA_DIEN : GIA_NUOC):N0} VND\n";
                    hoaDon += $"Thành tiền: {thanhTien:N0} VND\n";
                }

                decimal giaPhong = Convert.ToDecimal(dt.Rows[0]["GiaPhong"]);
                tongTien += giaPhong;
                hoaDon += $"\nTiền phòng: {giaPhong:N0} VND\n";
                hoaDon += $"\nTổng tiền: {tongTien:N0} VND";

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.FileName = $"HoaDon_Phong{maPhong}_Thang{thang}_{nam}.txt";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.WriteAllText(saveFileDialog.FileName, hoaDon);
                    MessageBox.Show("Xuất hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin hóa đơn cho phòng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearInputs()
        {
            cboKhu.SelectedIndex = -1;
            txtTang.Clear();
            txtPhong.Clear();
            cboDichVu.SelectedIndex = -1;
            numThang.Value = DateTime.Now.Month;
            numNam.Value = DateTime.Now.Year;
            numChiSoDau.Value = 0;
            numChiSoCuoi.Value = 0;
        }

        private bool ValidateInputs()
        {
            if (!ValidatePhong()) return false;

            if (numChiSoDau.Value < 0)
            {
                MessageBox.Show("Chỉ số đầu không được âm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (numChiSoCuoi.Value < 0)
            {
                MessageBox.Show("Chỉ số cuối không được âm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool ValidatePhong()
        {
            if (string.IsNullOrEmpty(cboKhu.Text))
            {
                MessageBox.Show("Vui lòng chọn khu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtTang.Text))
            {
                MessageBox.Show("Vui lòng nhập tầng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtPhong.Text))
            {
                MessageBox.Show("Vui lòng nhập phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void cboKhu_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTang.Clear();
            txtPhong.Clear();
        }

        private void btnThemHoaDon_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            string maKhu = cboKhu.Text;
            string maTang = txtTang.Text;
            string maPhong = txtPhong.Text;
            int thang = (int)numThang.Value;
            int nam = (int)numNam.Value;
            int chiSoDau = (int)numChiSoDau.Value;
            int chiSoCuoi = (int)numChiSoCuoi.Value;
            string maDV = ((dynamic)cboDichVu.SelectedItem).Value.ToString();

            // Kiểm tra hóa đơn đã tồn tại chưa
            string checkQuery = @"SELECT COUNT(*) FROM HoaDon 
                                WHERE MaKhu = @MaKhu 
                                AND MaTang = @MaTang 
                                AND MaPhong = @MaPhong 
                                AND Thang = @Thang 
                                AND Nam = @Nam 
                                AND MaDV = @MaDV";

            var checkParams = new Dictionary<string, object>
            {
                { "@MaKhu", maKhu },
                { "@MaTang", maTang },
                { "@MaPhong", maPhong },
                { "@Thang", thang },
                { "@Nam", nam },
                { "@MaDV", maDV }
            };

            int exists = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkQuery, checkParams));
            if (exists > 0)
            {
                MessageBox.Show("Hóa đơn này đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Thêm hóa đơn mới
            string insertQuery = @"INSERT INTO HoaDon (MaKhu, MaTang, MaPhong, Thang, Nam, MaDV, ChiSoDau, ChiSoCuoi)
                                 VALUES (@MaKhu, @MaTang, @MaPhong, @Thang, @Nam, @MaDV, @ChiSoDau, @ChiSoCuoi)";

            var insertParams = new Dictionary<string, object>
            {
                { "@MaKhu", maKhu },
                { "@MaTang", maTang },
                { "@MaPhong", maPhong },
                { "@Thang", thang },
                { "@Nam", nam },
                { "@MaDV", maDV },
                { "@ChiSoDau", chiSoDau },
                { "@ChiSoCuoi", chiSoCuoi }
            };

            try
            {
                DatabaseHelper.ExecuteNonQuery(insertQuery, insertParams);
                MessageBox.Show("Thêm hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadHoaDon();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}