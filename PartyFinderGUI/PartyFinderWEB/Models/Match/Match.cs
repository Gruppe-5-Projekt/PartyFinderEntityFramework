﻿using System;
using System.Collections.Generic;

namespace PartyFinderWEB.Models
{
    public partial class Match
    {
        public int EventId { get; set; }
        public int ProfileId { get; set; }
        public bool Match1 { get; set; }
    }
}