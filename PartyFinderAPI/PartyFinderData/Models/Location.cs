using System;
using System.Collections.Generic;

namespace PartyFinderData.Models
{
    public partial class Location
    {
        public string Zip { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int EventId { get; set; }

        public virtual Event Event { get; set; } = null!;
    }
}
