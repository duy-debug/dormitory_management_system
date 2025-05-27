using System;
using System.Data;
using QuanLyKyTucXa.Db;

namespace QuanLyKyTucXa.Models
{
    internal class SinhVienModel
    {
        public static DataTable LayThongTinSinhVien(string tenDangNhap)
        {
            try
            {
                string query = $@"SELECT sv.MaSV, sv.MaKhu, sv.MaTang, sv.MaPhong, sv.HovaTenLot, sv.Ten, sv.NgaySinh, sv.GioiTinh, 
                                sv.Email, sv.DiaChi, sv.MaUuTien
                                FROM SinhVien sv
                                INNER JOIN NguoiDung nd ON sv.MaSV = nd.TenDangNhap
                                WHERE nd.TenDangNhap = '{tenDangNhap}'";

                return DatabaseConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy thông tin sinh viên: " + ex.Message);
            }
        }

        public static DataTable LayDanhSachSinhVien()
        {
            try
            {
                string query = @"SELECT sv.MaSV, sv.MaKhu, sv.MaTang, sv.MaPhong, sv.HovaTenLot, sv.Ten, sv.NgaySinh, sv.GioiTinh, 
                                sv.Email, sv.DiaChi, sv.MaUuTien
                                FROM SinhVien sv";

                return DatabaseConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách sinh viên: " + ex.Message);
            }
        }

        public static bool ThemSinhVien(string maSV, string hoVaTenLot, string ten, DateTime ngaySinh, string gioiTinh,
            string email, string diaChi, string maKhu, int? maTang, int? maPhong, string maUuTien)
        {
            try
            {
                string query = $@"INSERT INTO SinhVien (MaSV, HovaTenLot, Ten, NgaySinh, GioiTinh, Email, DiaChi, MaKhu, MaTang, MaPhong, MaUuTien)
                                VALUES ('{maSV}', N'{hoVaTenLot}', N'{ten}', '{ngaySinh:yyyy-MM-dd}', N'{gioiTinh}', 
                                '{email}', N'{diaChi}', '{maKhu}', {maTang?.ToString() ?? "NULL"}, {maPhong?.ToString() ?? "NULL"}, '{maUuTien}')";

                return DatabaseConnection.ExecuteNonQuery(query) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm sinh viên: " + ex.Message);
            }
        }

        public static bool CapNhatSinhVien(string maSV, string hoVaTenLot, string ten, DateTime ngaySinh, string gioiTinh,
            string email, string diaChi, string maKhu, int? maTang, int? maPhong, string maUuTien)
        {
            try
            {
                string query = $@"UPDATE SinhVien 
                                SET HovaTenLot = N'{hoVaTenLot}',
                                    Ten = N'{ten}',
                                    NgaySinh = '{ngaySinh:yyyy-MM-dd}',
                                    GioiTinh = N'{gioiTinh}',
                                    Email = '{email}',
                                    DiaChi = N'{diaChi}',
                                    MaKhu = '{maKhu}',
                                    MaTang = {maTang?.ToString() ?? "NULL"},
                                    MaPhong = {maPhong?.ToString() ?? "NULL"},
                                    MaUuTien = '{maUuTien}'
                                WHERE MaSV = '{maSV}'";

                return DatabaseConnection.ExecuteNonQuery(query) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật sinh viên: " + ex.Message);
            }
        }

        public static bool XoaSinhVien(string maSV)
        {
            try
            {
                string query = $"DELETE FROM SinhVien WHERE MaSV = '{maSV}'";
                return DatabaseConnection.ExecuteNonQuery(query) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa sinh viên: " + ex.Message);
            }
        }

        public static DataTable TimKiemSinhVien(string keyword)
        {
            try
            {
                string query = $@"SELECT sv.MaSV, sv.MaKhu, sv.MaTang, sv.MaPhong, sv.HovaTenLot, sv.Ten, sv.NgaySinh, sv.GioiTinh, 
                                sv.Email, sv.DiaChi, sv.MaUuTien
                                FROM SinhVien sv
                                WHERE sv.MaSV LIKE '%{keyword}%' 
                                OR sv.HovaTenLot LIKE N'%{keyword}%'
                                OR sv.Ten LIKE N'%{keyword}%'
                                OR sv.Email LIKE '%{keyword}%'";

                return DatabaseConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm sinh viên: " + ex.Message);
            }
        }
    }
} 