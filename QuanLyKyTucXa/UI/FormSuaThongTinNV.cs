using System;
using System.Windows.Forms;
using QuanLyKyTucXa.Db;

namespace QuanLyKyTucXa.UI
{
    public partial class FormSuaThongTinNV : Form
    {
        private string selectedQL;

        public FormSuaThongTinNV()
        {
            InitializeComponent();
            button2.Click += BtnQuayLai_Click;
            button1.Click += BtnSuaThongTin_Click;
            
            // Thêm các giá trị vào ComboBox giới tính
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Nam");
            comboBox1.Items.Add("Nữ");
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public FormSuaThongTinNV(string maQL) : this()
        {
            selectedQL = maQL;
            LoadThongTinNhanVien();
        }

        private void LoadThongTinNhanVien()
        {
            try
            {
                string query = $"SELECT * FROM QuanLiKTX WHERE MaQuanLi = '{selectedQL}'";
                var dataTable = DatabaseConnection.ExecuteQuery(query);

                if (dataTable.Rows.Count > 0)
                {
                    var row = dataTable.Rows[0];
                    textBox1.Text = row["MaQuanLi"].ToString();      // Mã nhân viên
                    textBox6.Text = row["MaKhu"].ToString();         // Mã khu
                    textBox2.Text = row["HoVaTenLot"].ToString();    // Họ tên lót
                    textBox3.Text = row["TenQuanLi"].ToString();     // Tên nhân viên
                    comboBox1.Text = row["GioiTinh"].ToString();     // Giới tính
                    textBox4.Text = row["SDT"].ToString();           // Số điện thoại
                    textBox5.Text = row["QueQuan"].ToString();       // Quê quán

                    // Disable mã nhân viên vì đây là khóa chính
                    textBox1.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSuaThongTin_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu nhập vào
            if (string.IsNullOrWhiteSpace(textBox6.Text) || 
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(comboBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Hiển thị thông báo xác nhận
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn cập nhật thông tin này?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    string query = $@"UPDATE QuanLiKTX 
                                    SET MaKhu = '{textBox6.Text}',
                                        HoVaTenLot = N'{textBox2.Text}',
                                        TenQuanLi = N'{textBox3.Text}',
                                        GioiTinh = N'{comboBox1.Text}',
                                        SDT = '{textBox4.Text}',
                                        QueQuan = N'{textBox5.Text}'
                                    WHERE MaQuanLi = '{selectedQL}'";

                    int rowsAffected = DatabaseConnection.ExecuteNonQuery(query);

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Chuyển về form danh sách và hiển thị thông tin vừa cập nhật
                        FormThongTinNV formThongTinNV = new FormThongTinNV(selectedQL);
                        formThongTinNV.TopLevel = false;
                        formThongTinNV.FormBorderStyle = FormBorderStyle.None;
                        formThongTinNV.Dock = DockStyle.Fill;
                        this.Controls.Clear();
                        this.Controls.Add(formThongTinNV);
                        formThongTinNV.Show();
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu nào được cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật thông tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
