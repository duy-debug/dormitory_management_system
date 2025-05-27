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
using QuanLyKyTucXa.UI;

namespace QuanLyKyTucXa
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                string tenDangNhap = txbtendangnhap.Text.Trim();
                string matKhau = txbmatkhau.Text.Trim();

                if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (DangNhapModel.KiemTraDangNhap(tenDangNhap, matKhau))
                {
                    string vaiTro = DangNhapModel.LayVaiTro(tenDangNhap).ToUpper();
                    MessageBox.Show($"Đăng nhập thành công!\nVai trò: {vaiTro}", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (vaiTro == "SINH VIÊN" || vaiTro == "SINHVIEN")
                    {
                        FormXemThongTinSinhVien formSinhVien = new FormXemThongTinSinhVien(tenDangNhap);
                        formSinhVien.Show();
                        this.Hide();
                    }
                    else if (vaiTro == "NHÂN VIÊN" || vaiTro == "NHANVIEN")
                    {
                        // Get MaQuanLi from NguoiDung table
                        string maQuanLi = DangNhapModel.LayMaQuanLi(tenDangNhap);
                        if (!string.IsNullOrEmpty(maQuanLi))
                        {
                            FormNhanVien formNhanVien = new FormNhanVien(maQuanLi);
                            formNhanVien.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thông tin nhân viên!", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Show();
                        }
                    }
                    else if (vaiTro == "ADMIN" || vaiTro == "QUẢN TRỊ" || vaiTro == "QUANTRI")
                    {
                        FormQLKTX formQLKTX = new FormQLKTX();
                        formQLKTX.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
