using PartyFinderData.DatabaseLayers;
using PartyFinderData.ModelLayers;
using PartyFinderService.DTO;

namespace PartyFinderService.BusinessLogicLayer
{
    public class MatchDataControl : IMatchData
    {
        readonly IMatchAccess _matchAccess;

        public MatchDataControl()
        {
            _matchAccess = new MatchAccess();
        }
        public int Match(Match match)
        {
            int status = -1;
            try
            {
                status = _matchAccess.CheckAndCommitMatchPublic(match);
            }
            catch
            {
                status = -1;
            }
            return status;
        }

        public Event GetRandomEvent(int profileId)
        {
            Event randomEvent = null;
            try
            {
                randomEvent = _matchAccess.GetRandomEvent(profileId);
            }
            catch
            {

            }
            return randomEvent;
        }
    }
}
