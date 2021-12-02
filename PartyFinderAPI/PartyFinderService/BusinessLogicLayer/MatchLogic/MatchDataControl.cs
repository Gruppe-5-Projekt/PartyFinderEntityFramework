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
        public bool Match(Match match)
        {
            bool status = false;
            try
            {
                status = _matchAccess.CheckAndCommitMatchPublic(match);
            }
            catch
            {
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
