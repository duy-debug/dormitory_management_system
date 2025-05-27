using System;
using System.Data;
using System.Windows.Forms;
using QuanLyKyTucXa;

namespace QuanLyKyTucXa.UI
{
    public partial class FormNhanVien : Form
    {
        private string maQuanLi;
        private string hoTen;

        public FormNhanVien(string maQuanLi)
        {
            InitializeComponent();
            this.maQuanLi = maQuanLi;
            LoadStaffInfo();
            btnDangXuat.Click += btnDangXuat_Click;
        }

        private void LoadStaffInfo()
        {
            string query = $@"SELECT HovaTenLot + ' ' + TenQuanLi as HoTen, MaKhu, GioiTinh, SDT 
                            FROM QuanLiKTX 
                            WHERE MaQuanLi = '{maQuanLi}'";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                hoTen = row["HoTen"].ToString();
                lblStaffInfo.Text = $"Mã Quản Lý: {maQuanLi}\n" +
                                  $"Họ tên: {hoTen}\n" +
                                  $"Khu: {row["MaKhu"]}\n" +
                                  $"Giới tính: {row["GioiTinh"]}\n" +
                                  $"SĐT: {row["SDT"]}";
            }
        }

        private void btnQuanLySinhVien_Click(object sender, EventArgs e)
        {
            FormQuanLySinhVien form = new FormQuanLySinhVien();
            form.ShowDialog();
        }

        private void btnQuanLyHopDong_Click(object sender, EventArgs e)
        {
            FormQuanLyHopDong form = new FormQuanLyHopDong();
            form.ShowDialog();
        }

        private void btnQuanLyHoaDon_Click(object sender, EventArgs e)
        {
            FormQuanLyHoaDon form = new FormQuanLyHoaDon();
            form.ShowDialog();
        }

        private void panelRight_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            FormDangNhap formDangNhap = new FormDangNhap();
            this.Hide();
            formDangNhap.ShowDialog();
            this.Close();
        }
    }
} 