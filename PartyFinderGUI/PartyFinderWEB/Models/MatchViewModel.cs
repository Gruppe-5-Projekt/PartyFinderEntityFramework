namespace PartyFinderWEB.Models
{
    public class MatchViewModel
    {
        public MatchViewModel(string eventName, int eventCapacity, DateTime startDateTime, DateTime endDateTime, string description, string aspNetFK, int profileId)
        {
            EventName = eventName;
            EventCapacity = eventCapacity;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            Description = description;
            AspNetFK = aspNetFK;
            ProfileId = profileId;

        }


        public int Id { get; set; }
        public string EventName { get; set; } = null!;
        public int EventCapacity { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string? Description { get; set; }
        public string? AspNetFK { get; set; }
        public int ProfileId { get; set; }
    }
}
