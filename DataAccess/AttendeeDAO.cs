using System;
using System.Data;
using System.Collections.Generic;
using eventms.Database;
using eventms.Models;

namespace eventms.DataAccess
{
    public class AttendeeDAO
    {
        public static List<Attendee> GetAllAttendees()
        {
            List<Attendee> attendees = new List<Attendee>();
            string query = "SELECT * FROM Attendees ORDER BY LastName, FirstName";

            DataTable dataTable = DatabaseHelper.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                attendees.Add(new Attendee
                {
                    AttendeeId = Convert.ToInt32(row["AttendeeId"]),
                    FirstName = row["FirstName"].ToString(),
                    LastName = row["LastName"].ToString(),
                    Email = row["Email"].ToString(),
                    Phone = row["Phone"].ToString(),
                    Organization = row["Organization"].ToString(),
                    RegistrationDate = Convert.ToDateTime(row["RegistrationDate"])
                });
            }

            return attendees;
        }

        public static Attendee GetAttendeeById(int attendeeId)
        {
            string query = $"SELECT * FROM Attendees WHERE AttendeeId = {attendeeId}";
            DataTable dataTable = DatabaseHelper.ExecuteQuery(query);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                return new Attendee
                {
                    AttendeeId = Convert.ToInt32(row["AttendeeId"]),
                    FirstName = row["FirstName"].ToString(),
                    LastName = row["LastName"].ToString(),
                    Email = row["Email"].ToString(),
                    Phone = row["Phone"].ToString(),
                    Organization = row["Organization"].ToString(),
                    RegistrationDate = Convert.ToDateTime(row["RegistrationDate"])
                };
            }
            return null;
        }

        public static int CreateAttendee(Attendee attendee)
        {
            string query = $@"INSERT INTO Attendees (FirstName, LastName, Email, Phone, Organization, RegistrationDate) 
                             VALUES ('{attendee.FirstName}', '{attendee.LastName}', '{attendee.Email}', 
                                     '{attendee.Phone}', '{attendee.Organization}', '{DateTime.Now:yyyy-MM-dd HH:mm:ss}')";

            return DatabaseHelper.ExecuteNonQuery(query);
        }

        public static int UpdateAttendee(Attendee attendee)
        {
            string query = $@"UPDATE Attendees 
                             SET FirstName = '{attendee.FirstName}', 
                                 LastName = '{attendee.LastName}', 
                                 Email = '{attendee.Email}', 
                                 Phone = '{attendee.Phone}', 
                                 Organization = '{attendee.Organization}' 
                             WHERE AttendeeId = {attendee.AttendeeId}";

            return DatabaseHelper.ExecuteNonQuery(query);
        }

        public static int DeleteAttendee(int attendeeId)
        {
            string query = $"DELETE FROM Attendees WHERE AttendeeId = {attendeeId}";
            return DatabaseHelper.ExecuteNonQuery(query);
        }

        public static List<Attendee> SearchAttendees(string searchTerm)
        {
            List<Attendee> attendees = new List<Attendee>();
            string query = $@"SELECT * FROM Attendees 
                             WHERE FirstName LIKE '%{searchTerm}%' 
                             OR LastName LIKE '%{searchTerm}%' 
                             OR Email LIKE '%{searchTerm}%' 
                             OR Organization LIKE '%{searchTerm}%'";

            DataTable dataTable = DatabaseHelper.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                attendees.Add(new Attendee
                {
                    AttendeeId = Convert.ToInt32(row["AttendeeId"]),
                    FirstName = row["FirstName"].ToString(),
                    LastName = row["LastName"].ToString(),
                    Email = row["Email"].ToString(),
                    Phone = row["Phone"].ToString(),
                    Organization = row["Organization"].ToString(),
                    RegistrationDate = Convert.ToDateTime(row["RegistrationDate"])
                });
            }

            return attendees;
        }
    }
}