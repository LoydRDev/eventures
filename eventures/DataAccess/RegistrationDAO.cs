using System;
using System.Data;
using System.Collections.Generic;
using eventures.Database;
using eventures.Models;

namespace eventures.DataAccess
{
    internal class RegistrationDAO
    {
        public static bool RegisterUser(User user)
        {
            try
            {
                string query = $"INSERT INTO Users (FirstName, LastName, Username, Email, Password) " +
                              $"VALUES ('{user.FirstName}', '{user.LastName}', '{user.Username}', '{user.Email}', '{user.Password}')"; 

                int result = DatabaseHelper.ExecuteNonQuery(query);
                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsEmailExists(string email)
        {
            try
            {
                string query = $"SELECT COUNT(*) FROM Users WHERE Email = '{email}'";
                DataTable result = DatabaseHelper.ExecuteQuery(query);
                return Convert.ToInt32(result.Rows[0][0]) > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsUsernameExists(string username)
        {
            try
            {
                string query = $"SELECT COUNT(*) FROM Users WHERE Username = '{username}'";
                DataTable result = DatabaseHelper.ExecuteQuery(query);
                return Convert.ToInt32(result.Rows[0][0]) > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
