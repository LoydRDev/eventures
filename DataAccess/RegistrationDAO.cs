using System;
using System.Data;
using System.Collections.Generic;
using eventms.Database;
using eventms.Models;

namespace eventmsDataAccess
{
    public class RegistrationDAO
    {
        public static List<Registration> GetEventRegistrations(int eventId)
        {
            List<Registration> registrations = new List<Registration>();
            string query = $"SELECT * FROM Registrations WHERE EventId = {eventId} ORDER BY RegistrationDate";

            DataTable dataTable = DatabaseHelper.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                registrations.Add(new Registration
                {
                    RegistrationId = Convert.ToInt32(row["RegistrationId"]),
                    EventId = Convert.ToInt32(row["EventId"]),
                    AttendeeId = Convert.ToInt32(row["AttendeeId"]),
                    RegistrationDate = Convert.ToDateTime(row["RegistrationDate"]),
                    Status = row["Status"].ToString(),
                    AttendanceStatus = row["AttendanceStatus"].ToString(),
                    Notes = row["Notes"].ToString(),
                    HasAttended = Convert.ToBoolean(row["HasAttended"])
                });
            }

            return registrations;
        }

        public static List<Registration> GetAttendeeRegistrations(int attendeeId)
        {
            List<Registration> registrations = new List<Registration>();
            string query = $"SELECT * FROM Registrations WHERE AttendeeId = {attendeeId} ORDER BY RegistrationDate";

            DataTable dataTable = DatabaseHelper.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                registrations.Add(new Registration
                {
                    RegistrationId = Convert.ToInt32(row["RegistrationId"]),
                    EventId = Convert.ToInt32(row["EventId"]),
                    AttendeeId = Convert.ToInt32(row["AttendeeId"]),
                    RegistrationDate = Convert.ToDateTime(row["RegistrationDate"]),
                    Status = row["Status"].ToString(),
                    AttendanceStatus = row["AttendanceStatus"].ToString(),
                    Notes = row["Notes"].ToString(),
                    HasAttended = Convert.ToBoolean(row["HasAttended"])
                });
            }

            return registrations;
        }

        public static Registration GetRegistration(int registrationId)
        {
            string query = $"SELECT * FROM Registrations WHERE RegistrationId = {registrationId}";
            DataTable dataTable = DatabaseHelper.ExecuteQuery(query);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                return new Registration
                {
                    RegistrationId = Convert.ToInt32(row["RegistrationId"]),
                    EventId = Convert.ToInt32(row["EventId"]),
                    AttendeeId = Convert.ToInt32(row["AttendeeId"]),
                    RegistrationDate = Convert.ToDateTime(row["RegistrationDate"]),
                    Status = row["Status"].ToString(),
                    AttendanceStatus = row["AttendanceStatus"].ToString(),
                    Notes = row["Notes"].ToString(),
                    HasAttended = Convert.ToBoolean(row["HasAttended"])
                };
            }
            return null;
        }

        public static int CreateRegistration(Registration registration)
        {
            string query = $@"INSERT INTO Registrations (EventId, AttendeeId, RegistrationDate, Status, AttendanceStatus, Notes, HasAttended) 
                             VALUES ({registration.EventId}, {registration.AttendeeId}, '{DateTime.Now:yyyy-MM-dd HH:mm:ss}', 
                                     '{registration.Status}', '{registration.AttendanceStatus}', '{registration.Notes}', 
                                     {(registration.HasAttended ? 1 : 0)})";

            return DatabaseHelper.ExecuteNonQuery(query);
        }

        public static int UpdateRegistration(Registration registration)
        {
            string query = $@"UPDATE Registrations 
                             SET Status = '{registration.Status}', 
                                 AttendanceStatus = '{registration.AttendanceStatus}', 
                                 Notes = '{registration.Notes}', 
                                 HasAttended = {(registration.HasAttended ? 1 : 0)} 
                             WHERE RegistrationId = {registration.RegistrationId}";

            return DatabaseHelper.ExecuteNonQuery(query);
        }

        public static int DeleteRegistration(int registrationId)
        {
            string query = $"DELETE FROM Registrations WHERE RegistrationId = {registrationId}";
            return DatabaseHelper.ExecuteNonQuery(query);
        }

        public static int GetEventRegistrationCount(int eventId)
        {
            string query = $"SELECT COUNT(*) FROM Registrations WHERE EventId = {eventId}";
            DataTable dataTable = DatabaseHelper.ExecuteQuery(query);
            return Convert.ToInt32(dataTable.Rows[0][0]);
        }
    }
}