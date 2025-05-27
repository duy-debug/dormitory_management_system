using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyKyTucXa.Db
{
    internal class DatabaseConnection
    {
        private static string connectionString = @"Data Source=LAPTOP-76GA8G9L\SQLEXPRESS;Initial Catalog=QLKTX;Integrated Security=True";
        private static SqlConnection connection = null;

        public static void TestConnection()
        {
            try
            {
                using (SqlConnection testConnection = new SqlConnection(connectionString))
                {
                    testConnection.Open();
                    MessageBox.Show("Kết nối thành công đến cơ sở dữ liệu!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối: {ex.Message}\nConnection String: {connectionString}", 
                    "Lỗi Kết Nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static SqlConnection GetConnection()
        {
            if (connection == null)
            {
                connection = new SqlConnection(connectionString);
            }
            return connection;
        }
        
        public static void OpenConnection()
        {
            try
            {
                if (connection == null)
                {
                    connection = new SqlConnection(connectionString);
                }
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối đến cơ sở dữ liệu: {ex.Message}\nConnection String: {connectionString}", 
                    "Lỗi Kết Nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public static void CloseConnection()
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public static DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            DataTable dataTable = new DataTable();
            try
            {
                OpenConnection();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thực thi truy vấn: {ex.Message}\nQuery: {query}", 
                    "Lỗi Truy Vấn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception("Lỗi khi thực thi truy vấn: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return dataTable;
        }

        public static int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            int result = 0;
            try
            {
                OpenConnection();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    result = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thực thi truy vấn: {ex.Message}\nQuery: {query}", 
                    "Lỗi Truy Vấn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception("Lỗi khi thực thi truy vấn: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }

        public static object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            object result = null;
            try
            {
                OpenConnection();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    result = command.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thực thi truy vấn: {ex.Message}\nQuery: {query}", 
                    "Lỗi Truy Vấn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception("Lỗi khi thực thi truy vấn: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }
    }
}
