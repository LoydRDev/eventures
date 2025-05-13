using eventures.Models;
using eventures.Database;
using System;
using System.Data.OleDb;

namespace eventures.DataAccess
{
    public class UserDAO
    {
        public void AddUser(User user)
        {
            using (OleDbConnection connection = new OleDbConnection(DatabaseHelper.connectionString))
            {
                string query = "INSERT INTO Users (UserID, FirstName, LastName, Username, Email, [Password], CreatedDate) VALUES (@UserID, @FirstName, @LastName, @Username, @Email, @Password, @CreatedDate)";

                using (OleDbCommand cmd = new OleDbCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UserID", user.UserID);
                    cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", user.LastName);
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@CreatedDate", user.CreatedDate);

                    connection.Open();
                    cmd.ExecuteNonQuery();
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
                                CreatedDate = reader.GetDateTime(6)
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
