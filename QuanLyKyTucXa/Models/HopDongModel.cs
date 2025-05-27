using System;
using System.Data;
using QuanLyKyTucXa.Db;

namespace QuanLyKyTucXa.Models
{
    internal class HopDongModel
    {
        public static DataTable LayDanhSachHopDongTheoSinhVien(string maSV)
        {
            try
            {
                string query = $@"SELECT MaSV, NgayApDung, NgayHetHan FROM HopDongKTX WHERE MaSV = '{maSV}'";
                return DatabaseConnection.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách hợp đồng: " + ex.Message);
            }
        }
    }
} 