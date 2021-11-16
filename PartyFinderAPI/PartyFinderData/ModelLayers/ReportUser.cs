using System;
using System.Collections.Generic;

namespace PartyFinderData.ModelLayers
{
    public partial class ReportUser
    {
        public int AccuserId { get; set; }
        public int OffenderId { get; set; }
        public string? Description { get; set; }
        public int Id { get; set; }

        public virtual Profile Accuser { get; set; } = null!;
        public virtual Profile Offender { get; set; } = null!;
    }
}
