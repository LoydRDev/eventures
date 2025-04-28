using System;

namespace eventms.Models
{
    public class Attendee
    {
        public int AttendeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Organization { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}