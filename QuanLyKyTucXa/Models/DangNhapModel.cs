using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKyTucXa.Db;

namespace QuanLyKyTucXa.Models
{
    internal class DangNhapModel
    {
        public static bool KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            try
            {
                string query = @"SELECT COUNT(*) FROM NguoiDung 
                                WHERE TenDangNhap = @TenDangNhap 
                                AND MatKhau = @MatKhau";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@TenDangNhap", tenDangNhap),
                    new SqlParameter("@MatKhau", matKhau)
                };

                object result = DatabaseConnection.ExecuteScalar(query, parameters);
                return Convert.ToInt32(result) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi kiểm tra đăng nhập: " + ex.Message);
            }
        }

        public static string LayVaiTro(string tenDangNhap)
        {
            try
            {
                string query = @"SELECT UPPER(VaiTro) FROM NguoiDung 
                                WHERE TenDangNhap = @TenDangNhap";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@TenDangNhap", tenDangNhap)
                };

                object result = DatabaseConnection.ExecuteScalar(query, parameters);
                return result?.ToString() ?? "";
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy vai trò: " + ex.Message);
            }
        }

        public static string LayMaQuanLi(string tenDangNhap)
        {
            try
            {
                string query = @"SELECT MaQuanLi FROM NguoiDung 
                                WHERE TenDangNhap = @TenDangNhap";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@TenDangNhap", tenDangNhap)
                };

                object result = DatabaseConnection.ExecuteScalar(query, parameters);
                return result?.ToString() ?? "";
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy mã quản lí: " + ex.Message);
            }
        }
    }
}
