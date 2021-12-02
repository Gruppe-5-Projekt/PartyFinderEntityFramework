namespace PartyFinderService.DTO.MatchDTO
{
    public class MatchDataCreateDTO
    {
        public string AspNetFK { get; set; }
        public int EventId { get; set; }
        public bool IsMatched { get; set; }

        public MatchDataCreateDTO() { }

        public MatchDataCreateDTO(string aspNetFK, int id, bool isMatched)
        {
            AspNetFK = aspNetFK;
            EventId = id;
            IsMatched = isMatched;
        }
    }
}
