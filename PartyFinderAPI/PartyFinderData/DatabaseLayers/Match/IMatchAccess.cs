using PartyFinderData.ModelLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyFinderData.DatabaseLayers.Match
{
    internal interface IMatchAccess
    {
        int CheckCurrentMatches(int EventId);
        int CheckCapacity(int eventId);
        string CheckAndCommitMatch(int profileID, int eventID);
    }
}
