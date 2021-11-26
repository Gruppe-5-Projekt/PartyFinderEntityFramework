using PartyFinderData.DatabaseLayers;

namespace PartyFinderService.BusinessLogicLayer
{
    public class ProfileDataControl : IProfileData
    {
        readonly IProfileAccess _profileAccess;

        public ProfileDataControl()
        {
            _profileAccess = new ProfileAccess();
        }
        public int GetProfileByUserIdValue(string userIdValue)
        {

            int profileId = _profileAccess.GetProfileIdByUserIdValue(userIdValue);
            return profileId;
        }
    }
}
