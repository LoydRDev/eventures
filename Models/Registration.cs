using System;

namespace eventms.Models
{
    public class Registration
    {
        public int RegistrationId { get; set; }
        public int EventId { get; set; }
        public int AttendeeId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Status { get; set; }
        public string AttendanceStatus { get; set; }
        public string Notes { get; set; }
        public bool HasAttended { get; set; }
    }
}