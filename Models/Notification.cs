using System;

namespace eventms.Models
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public int EventId { get; set; }
        public int? AttendeeId { get; set; }
        public string NotificationType { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? SentDate { get; set; }
        public string Status { get; set; }
        public string DeliveryMethod { get; set; }
    }
}