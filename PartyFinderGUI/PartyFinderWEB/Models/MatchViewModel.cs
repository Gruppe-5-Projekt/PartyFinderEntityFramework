namespace PartyFinderWEB.Models
{
    public class MatchViewModel
    {
        public MatchViewModel(string aspNetFK, int id, bool isMatched)
        {
            AspNetFK = aspNetFK;
            Id = id;
            IsMatched = isMatched;
        }


        public int Id { get; set; }
        public string EventName { get; set; } = null!;
        public int EventCapacity { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string? Description { get; set; }
        public string? AspNetFK { get; set; }
        public int ProfileId { get; set; }
        public bool IsMatched { get; set; }
        public virtual ICollection<Match> Matches { get; set; } = null;

        public int calculateCount()
        {
            int count = 0;
            foreach (var item in Matches)
            {
                if (item.Match1 == true)
                {
                    count++;
                }
            }
            return count;
        }
    }
    
}
