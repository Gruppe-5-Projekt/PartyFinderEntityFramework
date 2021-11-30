namespace PartyFinderService.DTO
{
    public class MatchDataReadDTO
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public int EventCapacity { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public String Description { get; set; }
        public String EventInfo { get; set; }
        public int ProfileId { get; set; }
        public int CurrMatched { get; set; }


        public MatchDataReadDTO() { }

        public MatchDataReadDTO(int id, String eventName, int eventCapacity, int currMatched, DateTime startDateTime, DateTime endDateTime, String description, int profileId)
        {
            Id = id;
            EventName = eventName;
            EventCapacity = eventCapacity;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            Description = description;
            ProfileId = profileId;
            CurrMatched = currMatched;
        }
    }
}
