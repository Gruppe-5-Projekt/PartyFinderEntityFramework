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
        public bool Match(int eventId, int profileId, bool isMatched)
        {
            bool status = false;
            try
            {
                status = _matchAccess.CheckAndCommitMatchPublic(eventId, profileId, isMatched);
            }
            catch
            {
            }
            return status;
        }

        public Event GetSpecificEvent()
        {
            Event specificEvent = null;
            try
            {
                specificEvent = _matchAccess.GetSpecificEvent();
            }
            catch
            {

            }
            return specificEvent;
        }
    }
}
