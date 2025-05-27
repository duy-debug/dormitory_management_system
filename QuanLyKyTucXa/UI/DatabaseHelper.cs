using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections.Generic;

namespace QuanLyKyTucXa.UI
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
            return ExecuteQuery(query, null);
        }

        public static DataTable ExecuteQuery(string query, Dictionary<string, object> parameters)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand(query, connection);
                
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        command.Parameters.AddWithValue(param.Key, param.Value);
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error executing query: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                CloseConnection();
            }
        }

        public static int ExecuteNonQuery(string query)
        {
            return ExecuteNonQuery(query, null);
        }

        public static int ExecuteNonQuery(string query, Dictionary<string, object> parameters)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand(query, connection);

                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        command.Parameters.AddWithValue(param.Key, param.Value);
                    }
                }

                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error executing non-query: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            finally
            {
                CloseConnection();
            }
        }

        public static object ExecuteScalar(string query)
        {
            return ExecuteScalar(query, null);
        }

        public static object ExecuteScalar(string query, Dictionary<string, object> parameters)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand(query, connection);

                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        command.Parameters.AddWithValue(param.Key, param.Value);
                    }
                }

                return command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error executing scalar: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                CloseConnection();
            }
        }
    }
} 