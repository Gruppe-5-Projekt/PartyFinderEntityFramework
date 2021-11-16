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
        void Match(int profileID, int eventID);
    }
}
