namespace PartyFinderWEB.Models
{
    public class PostMatch
    {

        public PostMatch(string aspNetFK, int id, bool isMatched)
        {
            this.AspNetFK = aspNetFK;
            this.Id = id;
            this.IsMatched = isMatched;
        }
        public string AspNetFK { get; set; }
        public int Id { get; set; }
        public bool IsMatched { get; set; }
    }
}
