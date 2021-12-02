using System;
using System.Collections.Generic;

namespace PartyFinderData.ModelLayers
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

        public virtual Event Event { get; set; } = null!;
        public virtual Profile Profile { get; set; } = null!;
    }
}
