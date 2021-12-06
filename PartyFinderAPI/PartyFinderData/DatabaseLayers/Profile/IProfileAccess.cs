using PartyFinderData.ModelLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyFinderData.DatabaseLayers
{
    public interface IProfileAccess
    {
        Profile GetProfileByID(int id);
        List<Profile> GetProfileAll();
        int CreateProfile(Profile profileToAdd);
        void UpdateProfile(int id, Profile updatedProfile);
        int GetProfileIdByUserIdValue(string aspNetFK);
        void DeleteProfileById(int id);
    }
}
