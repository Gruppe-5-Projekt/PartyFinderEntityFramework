using PartyFinderData.ModelLayers;

namespace PartyFinderService.BusinessLogicLayer
{
    public interface IProfileData
    {
        int GetProfileByUserIdValue(string userIdValue);
        bool Add(Profile profileToAdd);
    }
}
