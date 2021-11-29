using PartyFinderData.ModelLayers;
using PartyFinderService.DTO.ProfileDTO;

namespace PartyFinderService.ModelConversion
{
    public class ProfileDataCreateDTOConvert
    {
        public static Profile ToProfile(ProfileDataCreateDTO inDTO)
        {
            Profile aProfile = null;
            if(inDTO != null)
            {
                aProfile = new Profile(inDTO.FirstName, inDTO.LastName, inDTO.Age, inDTO.Gender, inDTO.Description, inDTO.IsBanned,  inDTO.AspNetFK);
            }
            return aProfile;
        }
    }
}
