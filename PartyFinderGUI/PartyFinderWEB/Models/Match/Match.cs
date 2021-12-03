using System;
using System.Collections.Generic;

namespace PartyFinderWEB.Models
{
    public partial class Match
    {
        public Match()
        {

        }
        public Match(int profileId, int eventId, bool isMatched)
        {
            ProfileId = profileId;
            EventId = eventId;
            Match1 = isMatched;
        }
        public int ProfileId { get; set; }
        public int EventId { get; set; }
        public bool Match1 { get; set; }

        public virtual MatchViewModel MatchViewModel { get; set; } = null!;
    }
}
