using PartyFinderData.ModelLayers;

namespace PartyFinderService.BusinessLogicLayer
{
    public interface IProfileData
    {
        int GetProfileByUserIdValue(string aspNetFK);
        bool Add(Profile profileToAdd);
    }
}
