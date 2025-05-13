using System;

namespace eventures.Models
{
    public class Event
    {
        public int EventID { get; set; }
        public string EventName { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime EventStart { get; set; }
        public DateTime EventEnd { get; set; }
        public string Location { get; set; }
        public string AgeRestriction { get; set; }
        public int Capacity { get; set; }
        public int CreatorID { get; set; }
        public DateTime CreatedDate { get; set; }

        public User Creator { get; set; }
    }
}
