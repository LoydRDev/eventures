using eventures.Models;
using eventures.Database;
using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace eventures.DataAccess
{
    public class EventDAO
    {
        public void CreateEvent(Event eventObj)
        {
            bool isSuccess = false;
            try
            {
                using (OleDbConnection connection = new OleDbConnection(DatabaseHelper.connectionString))
                {
                    string query = "INSERT INTO Events (EventName, Description, EventDate, EventStart, EventEnd, Location, AgeRestriction, Capacity, Category, CreatorID, DateCreated) " +
                                   "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

                    using (OleDbCommand cmd = new OleDbCommand(query, connection))
                    {
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = eventObj.EventName;
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = eventObj.Description;
                        cmd.Parameters.Add("?", OleDbType.Date).Value = eventObj.EventDate;
                        cmd.Parameters.Add("?", OleDbType.Date).Value = eventObj.EventStart;
                        cmd.Parameters.Add("?", OleDbType.Date).Value = eventObj.EventEnd;
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = eventObj.Location;
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = eventObj.AgeRestriction;
                        cmd.Parameters.Add("?", OleDbType.Integer).Value = eventObj.Capacity;
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = eventObj.Category;
                        cmd.Parameters.Add("?", OleDbType.Integer).Value = eventObj.CreatorID;
                        cmd.Parameters.Add("?", OleDbType.Date).Value = DateTime.Now;


                        connection.Open();
                        cmd.ExecuteNonQuery();
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
                    var result = MessageBox.Show("Event created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        public int GetTableRowsCount()
        {
            int rowCount = 0;
            try
            {
                string query = $"SELECT COUNT(*) FROM Event";
                using (OleDbConnection connection = new OleDbConnection(DatabaseHelper.connectionString))
                {
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        connection.Open();
                        rowCount = (int)command.ExecuteScalar();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving row count: {ex.Message}");
            }
            return rowCount;
        }
        
    }
}