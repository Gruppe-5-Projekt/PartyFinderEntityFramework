using PartyFinderData.ModelLayers;

namespace PartyFinderService.BusinessLogicLayer
{
    public interface IProfileData
    {
        int GetProfileByUserIdValue(string aspNetFK);
        int Add(Profile profileToAdd);
    }
}
