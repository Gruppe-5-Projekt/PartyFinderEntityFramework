using System;
using System.Collections.Generic;

namespace PartyFinderData.Models
{
    public partial class Chat
    {
        public int DestinationId { get; set; }
        public int SourceId { get; set; }
        public DateTime TimeSent { get; set; }
        public string? Body { get; set; }
        public int Id { get; set; }

        public virtual Event Destination { get; set; } = null!;
        public virtual Profile Source { get; set; } = null!;
    }
}
