namespace PartyFinderService.DTO.MatchDTO
{
    public class MatchDataCreateDTO
    {
        public string AspNetFK { get; set; }
        public int Id { get; set; }
        public bool IsMatched { get; set; }
        public int ProfileId { get; set; }

        public MatchDataCreateDTO() { }

        public MatchDataCreateDTO(string aspNetFK, int profileId, int id, bool isMatched)
        {
            AspNetFK = aspNetFK;
            ProfileId = profileId;
            Id = id;
            IsMatched = isMatched;
        }
    }
}
