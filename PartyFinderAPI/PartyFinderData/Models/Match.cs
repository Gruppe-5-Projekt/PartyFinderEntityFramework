using System;
using System.Collections.Generic;

namespace PartyFinderData.Models
{
    public partial class Match
    {
        public int EventId { get; set; }
        public int ProfileId { get; set; }
        public bool Match1 { get; set; }

        public virtual Event Event { get; set; } = null!;
        public virtual Profile Profile { get; set; } = null!;
    }
}
