using System;
using System.Data;
using System.Data.OleDb;

namespace eventures.Database
{
    internal class DatabaseHelper
    {
        public static string dbPath = "C:\\Users\\noemi\\Documents\\Eventures.accdb";
        public static string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbPath}";
        public static OleDbConnection connection = null;

        public static OleDbConnection GetConnection()
        {
            if (connection == null)
            {
                connection = new OleDbConnection(connectionString);
            }
            return connection;
        }

        public static void OpenConnection()
        {
            if (connection != null && connection.State == ConnectionState.Closed)
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
            DataTable dataTable = new DataTable();
            try
            {
                using (OleDbCommand command = new OleDbCommand(query, GetConnection()))
                {
                    OpenConnection();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Database error: {ex.Message}");
            }
            finally
            {
                CloseConnection();
            }
            return dataTable;
        }

        public static int ExecuteNonQuery(string query)
        {
            int result = 0;
            try
            {
                using (OleDbCommand command = new OleDbCommand(query, GetConnection()))
                {
                    OpenConnection();
                    result = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Database error: {ex.Message}");
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }
    }
}
