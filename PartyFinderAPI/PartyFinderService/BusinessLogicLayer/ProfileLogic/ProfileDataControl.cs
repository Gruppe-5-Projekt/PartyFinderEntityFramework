﻿using PartyFinderData.DatabaseLayers;
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
        public bool Add(Profile profileToAdd)
        {
            bool status;
            try
            {
                status = _profileAccess.CreateProfile(profileToAdd);
            }
            catch
            {
                status = false;
            }
            return status;
        }

        public int GetProfileByUserIdValue(string aspNetFK)
        {

            int profileId = _profileAccess.GetProfileIdByUserIdValue(aspNetFK);
            return profileId;
        }
    }
}
