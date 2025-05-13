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
            try
            {
                using (OleDbConnection connection = new OleDbConnection(DatabaseHelper.connectionString))
                {
                    string query = "INSERT INTO Users (FirstName, LastName, Username, Email, [Password], CreatedDate) " +
                                   "VALUES (@FirstName, @LastName, @Username, @Email, @Password, @CreatedDate)";

                    using (OleDbCommand cmd = new OleDbCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", user.LastName);
                        cmd.Parameters.AddWithValue("@Username", user.Username);
                        cmd.Parameters.AddWithValue("@Email", user.Email);
                        cmd.Parameters.AddWithValue("@Password", user.Password);
                        cmd.Parameters.AddWithValue("@CreatedDate", user.DateCreated);

                        connection.Open();
                        int result = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show($"Database error occurred: {ex.Message}\nError code: {ex.ErrorCode}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}");
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
                                UserID = reader.GetInt32(1),
                                FirstName = reader.GetString(2),
                                LastName = reader.GetString(3),
                                Username = reader.GetString(4),
                                Email = reader.GetString(5),
                                Password = reader.GetString(6),
                                DateCreated = reader.GetDateTime(7)
                            };
                        }
                    }
                }
            }
            return null;
        }
        public User GetUserByID(int uniqueUserID)
        { 
            return null; 
        }

        public User GenerateUniqueID()
        {
            Random random = new Random();
            int uniqueUserID = random.Next(100000, 999999);
            User user = GetUserByID(uniqueUserID);
            while (user != null)
            {
                uniqueUserID = random.Next(100000, 999999);
                user = GetUserByID(uniqueUserID);
            }
            return new User { UserID = uniqueUserID };
        }
    }
}
