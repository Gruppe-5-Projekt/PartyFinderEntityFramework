namespace PartyFinderMVC.Models
{
    public class EventViewModel
    {
        private int capacity;

        public EventViewModel(string eventName, int capacity, DateTime startDateTime, DateTime endDateTime, string description, int profileID)
        {
            EventName = eventName;
            this.capacity = capacity;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            Description = description;
            ProfileID = profileID;
        }

        public string EventName { get; set; }
        public int EventCapacity { get; set; }
        public System.DateTime StartDateTime { get; set; }
        public System.DateTime EndDateTime { get; set; }
        public string Description { get; set; }
        public int ProfileID { get; set; }
    }
}
