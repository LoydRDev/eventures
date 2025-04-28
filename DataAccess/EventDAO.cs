using System;
using System.Data;
using System.Collections.Generic;
using eventms.Database;
using eventms.Models;

namespace eventms.DataAccess
{
    public class EventDAO
    {
        public static List<Event> GetAllEvents()
        {
            List<Event> events = new List<Event>();
            string query = "SELECT * FROM Events ORDER BY EventDate";

            DataTable dataTable = DatabaseHelper.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                events.Add(new Event
                {
                    EventId = Convert.ToInt32(row["EventId"]),
                    EventName = row["EventName"].ToString(),
                    Description = row["Description"].ToString(),
                    EventDate = Convert.ToDateTime(row["EventDate"]),
                    Location = row["Location"].ToString(),
                    MaxAttendees = Convert.ToInt32(row["MaxAttendees"]),
                    Status = row["Status"].ToString(),
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    LastModifiedDate = Convert.ToDateTime(row["LastModifiedDate"])
                });
            }

            return events;
        }

        public static Event GetEventById(int eventId)
        {
            string query = $"SELECT * FROM Events WHERE EventId = {eventId}";
            DataTable dataTable = DatabaseHelper.ExecuteQuery(query);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                return new Event
                {
                    EventId = Convert.ToInt32(row["EventId"]),
                    EventName = row["EventName"].ToString(),
                    Description = row["Description"].ToString(),
                    EventDate = Convert.ToDateTime(row["EventDate"]),
                    Location = row["Location"].ToString(),
                    MaxAttendees = Convert.ToInt32(row["MaxAttendees"]),
                    Status = row["Status"].ToString(),
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    LastModifiedDate = Convert.ToDateTime(row["LastModifiedDate"])
                };
            }
            return null;
        }

        public static int CreateEvent(Event evt)
        {
            string query = $@"INSERT INTO Events (EventName, Description, EventDate, Location, MaxAttendees, Status, CreatedDate, LastModifiedDate) 
                             VALUES ('{evt.EventName}', '{evt.Description}', '{evt.EventDate:yyyy-MM-dd HH:mm:ss}', 
                                     '{evt.Location}', {evt.MaxAttendees}, '{evt.Status}', 
                                     '{DateTime.Now:yyyy-MM-dd HH:mm:ss}', '{DateTime.Now:yyyy-MM-dd HH:mm:ss}')";

            return DatabaseHelper.ExecuteNonQuery(query);
        }

        public static int UpdateEvent(Event evt)
        {
            string query = $@"UPDATE Events 
                             SET EventName = '{evt.EventName}', 
                                 Description = '{evt.Description}', 
                                 EventDate = '{evt.EventDate:yyyy-MM-dd HH:mm:ss}', 
                                 Location = '{evt.Location}', 
                                 MaxAttendees = {evt.MaxAttendees}, 
                                 Status = '{evt.Status}', 
                                 LastModifiedDate = '{DateTime.Now:yyyy-MM-dd HH:mm:ss}' 
                             WHERE EventId = {evt.EventId}";

            return DatabaseHelper.ExecuteNonQuery(query);
        }

        public static int DeleteEvent(int eventId)
        {
            string query = $"DELETE FROM Events WHERE EventId = {eventId}";
            return DatabaseHelper.ExecuteNonQuery(query);
        }
    }
}