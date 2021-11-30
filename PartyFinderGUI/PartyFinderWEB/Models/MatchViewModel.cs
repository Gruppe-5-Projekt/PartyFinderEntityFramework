namespace PartyFinderWEB.Models
{
    public class MatchViewModel
    {
        public MatchViewModel(string aspNetFK, int eventId, bool isMatched)
        {
            AspNetFK = aspNetFK;
            EventId = eventId;
            IsMatched = isMatched;
        }


        public int EventId { get; set; }
        public string EventName { get; set; } = null!;
        public int EventCapacity { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string? Description { get; set; }
        public string? AspNetFK { get; set; }
        public bool IsMatched { get; set; }
        public virtual ICollection<Match> Matches { get; set; } = null;
    }
}
