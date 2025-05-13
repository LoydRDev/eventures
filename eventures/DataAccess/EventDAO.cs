using eventures.Models;
using eventures.Database;
using System;
using System.Data.OleDb;

namespace eventures.DataAccess
{
    public class EventDAO
    {
        public void CreateEvent(Event eventObj)
        {
            using (OleDbConnection connection = new OleDbConnection(DatabaseHelper.connectionString))
            {
                string query = "INSERT INTO Events (EventName, Description, EventDate, EventStart, EventEnd, Location, AgeRestriction, Capacity, Category, CreatorID, CreatedDate) " +
                               "VALUES (@EventName, @Description, @EventDate, @EventStart, @EventEnd, @Location, @AgeRestriction, @Capacity, @Category, @CreatorID, @CreatedDate)";

                using (OleDbCommand cmd = new OleDbCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@EventName", eventObj.EventName);
                    cmd.Parameters.AddWithValue("@Description", eventObj.Description);
                    cmd.Parameters.AddWithValue("@EventDate", eventObj.EventDate);
                    cmd.Parameters.AddWithValue("@EventStart", eventObj.EventStart);
                    cmd.Parameters.AddWithValue("@EventEnd", eventObj.EventEnd);
                    cmd.Parameters.AddWithValue("@Location", eventObj.Location);
                    cmd.Parameters.AddWithValue("@AgeRestriction", eventObj.AgeRestriction);
                    cmd.Parameters.AddWithValue("@Capacity", eventObj.Capacity);
                    cmd.Parameters.AddWithValue("@Category", eventObj.Category);
                    cmd.Parameters.AddWithValue("@CreatorID", eventObj.CreatorID);
                    cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}