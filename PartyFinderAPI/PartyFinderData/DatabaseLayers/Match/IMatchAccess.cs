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
        bool CheckIfFreeSpot(int eventId);
        int CheckAndCommitMatch(Match match);
        Event GetRandomEvent(int profileId);
    }
}
