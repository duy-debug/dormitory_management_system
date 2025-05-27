using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyKyTucXa
{
    public class DatabaseHelper
    {
        private static string connectionString = @"Data Source=.;Initial Catalog=QLKTX;Integrated Security=True";
        private static SqlConnection connection;

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
            if (connection == null)
            {
                connection = new SqlConnection(connectionString);
            }
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
        }

        public static void CloseConnection()
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public static DataTable ExecuteQuery(string query)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error executing query: " + ex.Message);
                return null;
            }
            finally
            {
                CloseConnection();
            }
        }

        public static int ExecuteNonQuery(string query)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand(query, connection);
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error executing non-query: " + ex.Message);
                return -1;
            }
            finally
            {
                CloseConnection();
            }
        }
    }
} 