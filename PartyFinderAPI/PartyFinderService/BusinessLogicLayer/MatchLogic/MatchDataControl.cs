using PartyFinderData.DatabaseLayers;
using PartyFinderData.ModelLayers;

namespace PartyFinderService.BusinessLogicLayer
{
    public class MatchDataControl : IMatchData
    {
        readonly IMatchAccess _matchAccess;

        public MatchDataControl()
        {
            _matchAccess = new MatchAccess();
        }
        public bool Match(int eventId, int profileId)
        {
            bool status = false;
            try
            {
                status = _matchAccess.CheckAndCommitMatchPublic(eventId, profileId);
            }
            catch
            {
            }
            return status;
        }
    }
}
