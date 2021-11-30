using PartyFinderData.ModelLayers;

namespace PartyFinderService.BusinessLogicLayer
{
    public interface IMatchData
    {
        bool Match(int eventId, int profileId, bool isMatched);
        Event GetSpecificEvent();
    }
}
