using PartyFinderData.DatabaseLayers;
using PartyFinderData.ModelLayers;

namespace PartyFinderService.BusinessLogicLayer
{
    public class ProfileDataControl : IProfileData
    {
        readonly IProfileAccess _profileAccess;

        public ProfileDataControl()
        {
            _profileAccess = new ProfileAccess();
        }
        public int Add(Profile profileToAdd)
        {
            try
            {
                return _profileAccess.CreateProfile(profileToAdd);
            }
            catch
            {
                return -1;
            }
        }

        public int GetProfileByUserIdValue(string aspNetFK)
        {

            int profileId = _profileAccess.GetProfileIdByUserIdValue(aspNetFK);
            return profileId;
        }
    }
}
