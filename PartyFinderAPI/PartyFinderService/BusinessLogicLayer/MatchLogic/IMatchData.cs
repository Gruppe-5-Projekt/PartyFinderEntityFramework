using PartyFinderData.ModelLayers;

namespace PartyFinderService.BusinessLogicLayer
{
    public interface IMatchData
    {
        int Match(Match match);
        Event GetRandomEvent(int profileId);
    }
}
