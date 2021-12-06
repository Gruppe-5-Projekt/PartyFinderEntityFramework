using PartyFinderData.ModelLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyFinderData.DatabaseLayers
{
    public interface IMatchAccess
    {
        int CheckCurrentMatches(int EventId);
        int CheckCapacity(int eventId);
        int CheckAndCommitMatchPublic(Match match);
        Event GetRandomEvent(int profileId);
    }
}
