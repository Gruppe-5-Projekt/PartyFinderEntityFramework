using PartyFinderData.ModelLayers;

namespace PartyFinderService.BusinessLogicLayer
{
    public interface IMatchData
    {
        bool Match(Match match);
        Event GetRandomEvent(int profileId);
    }
}
