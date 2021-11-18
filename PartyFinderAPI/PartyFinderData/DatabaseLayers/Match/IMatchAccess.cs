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
        bool CheckAndCommitMatchPublic(int profileID, int eventID);
    }
}
