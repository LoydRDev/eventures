using System;
using System.Data.OleDb;

using eventures.Models;
using eventures.Database;
using System.Windows.Forms;

namespace eventures.DataAccess
{
    public class UserDAO
    {
        public void AddUser(User user)
        {
            bool isSuccess = true;
            try
            {
                using (OleDbConnection connection = new OleDbConnection(DatabaseHelper.connectionString))
                {
                    string query = "INSERT INTO Users (FirstName, LastName, Username, Email, [Password], DateCreated) " +
                                   "VALUES (?, ?, ?, ?, ?, ?)";

                    using (OleDbCommand cmd = new OleDbCommand(query, connection))
                    {
                        cmd.Parameters.Add("?", OleDbType.VarChar).Value = user.FirstName;
                        cmd.Parameters.Add("?", OleDbType.VarChar).Value = user.LastName;
                        cmd.Parameters.Add("?", OleDbType.VarChar).Value = user.Username;
                        cmd.Parameters.Add("?", OleDbType.VarChar).Value = user.Email;
                        cmd.Parameters.Add("?", OleDbType.VarChar).Value = user.Password;
                        cmd.Parameters.Add("?", OleDbType.Date).Value = user.DateCreated;

                        connection.Open();
                        int result = cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            catch (OleDbException ex)
            {
                isSuccess = false;
                MessageBox.Show($"Database error occurred: {ex.Message}\nError code: {ex.ErrorCode}");
            }
            catch (Exception ex)
            {
                isSuccess = false;
                MessageBox.Show($"An unexpected error occurred: {ex.Message}");
            }
            finally
            {
                if (isSuccess)
                {
                    // display message
                }
            }
        }

        public User AuthenticateUser(string username, string password)
        {
            using (OleDbConnection connection = new OleDbConnection(DatabaseHelper.connectionString))
            {
                string query = "SELECT * FROM Users WHERE Username = @Username AND [Password] = @Password";

                using (OleDbCommand cmd = new OleDbCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    connection.Open();
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                UserID = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                Username = reader.GetString(3),
                                Email = reader.GetString(4),
                                Password = reader.GetString(5),
                                DateCreated = reader.GetDateTime(6)
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}
