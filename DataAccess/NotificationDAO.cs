using System;
using System.Data;
using System.Collections.Generic;
using eventms.Database;
using eventms.Models;

namespace eventms.DataAccess
{
    public class NotificationDAO
    {
        public static List<Notification> GetEventNotifications(int eventId)
        {
            List<Notification> notifications = new List<Notification>();
            string query = $"SELECT * FROM Notifications WHERE EventId = {eventId} ORDER BY CreatedDate DESC";

            DataTable dataTable = DatabaseHelper.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                notifications.Add(new Notification
                {
                    NotificationId = Convert.ToInt32(row["NotificationId"]),
                    EventId = Convert.ToInt32(row["EventId"]),
                    AttendeeId = row["AttendeeId"] != DBNull.Value ? Convert.ToInt32(row["AttendeeId"]) : (int?)null,
                    NotificationType = row["NotificationType"].ToString(),
                    Message = row["Message"].ToString(),
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    SentDate = row["SentDate"] != DBNull.Value ? Convert.ToDateTime(row["SentDate"]) : (DateTime?)null,
                    Status = row["Status"].ToString(),
                    DeliveryMethod = row["DeliveryMethod"].ToString()
                });
            }

            return notifications;
        }

        public static List<Notification> GetAttendeeNotifications(int attendeeId)
        {
            List<Notification> notifications = new List<Notification>();
            string query = $"SELECT * FROM Notifications WHERE AttendeeId = {attendeeId} ORDER BY CreatedDate DESC";

            DataTable dataTable = DatabaseHelper.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                notifications.Add(new Notification
                {
                    NotificationId = Convert.ToInt32(row["NotificationId"]),
                    EventId = Convert.ToInt32(row["EventId"]),
                    AttendeeId = Convert.ToInt32(row["AttendeeId"]),
                    NotificationType = row["NotificationType"].ToString(),
                    Message = row["Message"].ToString(),
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    SentDate = row["SentDate"] != DBNull.Value ? Convert.ToDateTime(row["SentDate"]) : (DateTime?)null,
                    Status = row["Status"].ToString(),
                    DeliveryMethod = row["DeliveryMethod"].ToString()
                });
            }

            return notifications;
        }

        public static List<Notification> GetPendingNotifications()
        {
            List<Notification> notifications = new List<Notification>();
            string query = "SELECT * FROM Notifications WHERE Status = 'Pending' ORDER BY CreatedDate";

            DataTable dataTable = DatabaseHelper.ExecuteQuery(query);

            foreach (DataRow row in dataTable.Rows)
            {
                notifications.Add(new Notification
                {
                    NotificationId = Convert.ToInt32(row["NotificationId"]),
                    EventId = Convert.ToInt32(row["EventId"]),
                    AttendeeId = row["AttendeeId"] != DBNull.Value ? Convert.ToInt32(row["AttendeeId"]) : (int?)null,
                    NotificationType = row["NotificationType"].ToString(),
                    Message = row["Message"].ToString(),
                    CreatedDate = Convert.ToDateTime(row["CreatedDate"]),
                    SentDate = row["SentDate"] != DBNull.Value ? Convert.ToDateTime(row["SentDate"]) : (DateTime?)null,
                    Status = row["Status"].ToString(),
                    DeliveryMethod = row["DeliveryMethod"].ToString()
                });
            }

            return notifications;
        }

        public static int CreateNotification(Notification notification)
        {
            string attendeeIdValue = notification.AttendeeId.HasValue ? notification.AttendeeId.ToString() : "NULL";
            string sentDateValue = notification.SentDate.HasValue ? $"'{notification.SentDate.Value:yyyy-MM-dd HH:mm:ss}'" : "NULL";

            string query = $@"INSERT INTO Notifications (EventId, AttendeeId, NotificationType, Message, CreatedDate, SentDate, Status, DeliveryMethod) 
                             VALUES ({notification.EventId}, {attendeeIdValue}, '{notification.NotificationType}', 
                                     '{notification.Message}', '{notification.CreatedDate:yyyy-MM-dd HH:mm:ss}', 
                                     {sentDateValue}, '{notification.Status}', '{notification.DeliveryMethod}')";

            return DatabaseHelper.ExecuteNonQuery(query);
        }

        public static int UpdateNotificationStatus(int notificationId, string status, DateTime? sentDate = null)
        {
            string sentDateValue = sentDate.HasValue ? $"SentDate = '{sentDate.Value:yyyy-MM-dd HH:mm:ss}'," : "";
            string query = $@"UPDATE Notifications 
                             SET {sentDateValue} 
                                 Status = '{status}' 
                             WHERE NotificationId = {notificationId}";

            return DatabaseHelper.ExecuteNonQuery(query);
        }

        public static int DeleteNotification(int notificationId)
        {
            string query = $"DELETE FROM Notifications WHERE NotificationId = {notificationId}";
            return DatabaseHelper.ExecuteNonQuery(query);
        }
    }
}