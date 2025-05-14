using eventures.Models;
using eventures.Database;
using System;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Collections.Generic;

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
                string query = $"SELECT COUNT(*) FROM Events";
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

        public List<Event> GetEvents()
        {
            List<Event> events = new List<Event>();
            using (OleDbConnection conn = new OleDbConnection(DatabaseHelper.connectionString))
            {
                string query = "SELECT EventID, EventName, Category, Description, EventDate, EventStart,EventEnd, Location, AgeRestriction, Capacity, CreatorID  FROM Events";
                OleDbCommand cmd = new OleDbCommand(query, conn);
                conn.Open();
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Event evt = new Event
                    {
                        EventID = Convert.ToInt32(reader["EventID"]),
                        EventName = reader["EventName"].ToString(),
                        Category = reader["Category"].ToString(),
                        Description = reader["Description"].ToString(),
                        EventDate = Convert.ToDateTime(reader["EventDate"].ToString()),
                        EventStart = Convert.ToDateTime(reader["EventStart"].ToString()),
                        EventEnd = Convert.ToDateTime(reader["EventEnd"].ToString()),
                        Location = reader["Location"].ToString(),
                        AgeRestriction = reader["AgeRestriction"].ToString(),
                        Capacity = Convert.ToInt32(reader["Capacity"]),
                        CreatorID = Convert.ToInt32(reader["CreatorID"])
                    };
                    events.Add(evt);
                }
                reader.Close();
            }
            return events;
        }
    }
}