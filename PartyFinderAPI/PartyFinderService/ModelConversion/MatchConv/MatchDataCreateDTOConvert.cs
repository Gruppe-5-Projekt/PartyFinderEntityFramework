using PartyFinderData.ModelLayers;
using PartyFinderService.DTO.MatchDTO;

namespace PartyFinderService.ModelConversion
{
    public class MatchDataCreateDTOConvert
    {
        public static Match ToMatch(MatchDataCreateDTO inDTO)
        {
            Match aMatch = null;
            if (inDTO != null)
            {
                aMatch = new Match(inDTO.ProfileId, inDTO.Id, inDTO.IsMatched);
            }
            return aMatch;
        }
    }
}
