﻿using System;
using System.Collections.Generic;

namespace PartyFinderData.Models
{
    public partial class Event
    {
        public Event()
        {
            Chats = new HashSet<Chat>();
            Matches = new HashSet<Match>();
        }

        public int Id { get; set; }
        public string EventName { get; set; } = null!;
        public int EventCapacity { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string? Description { get; set; }
        public int ProfileId { get; set; }

        public virtual Profile Profile { get; set; } = null!;
        public virtual Location Location { get; set; } = null!;
        public virtual ICollection<Chat> Chats { get; set; }
        public virtual ICollection<Match> Matches { get; set; }
    }
}
