using System;
using System.Collections.Generic;

namespace PartyFinderData.ModelLayers
{
    public partial class Business
    {
        public string Name { get; set; } = null!;
        public string Cvr { get; set; } = null!;
        public bool? Subscription { get; set; }
        public int ProfileId { get; set; }

        public virtual Profile Profile { get; set; } = null!;
    }
}
