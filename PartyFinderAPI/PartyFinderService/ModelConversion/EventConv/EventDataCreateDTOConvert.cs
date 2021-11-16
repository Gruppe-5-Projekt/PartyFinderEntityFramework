using PartyFinderData.ModelLayers;
using PartyFinderService.DTO;

namespace PartyFinderService.ModelConversion
{
    public class EventDataCreateDTOConvert
    {
        public static Event ToEvent(EventDataCreateDTO inDTO)
        {
            Event anEvent = null;
            if (inDTO != null)
            {
                anEvent = new Event(inDTO.EventName, inDTO.EventCapacity, inDTO.StartDateTime, inDTO.EndDateTime, inDTO.Description, inDTO.ProfileId);
            }
            return anEvent;
        }

    }
}
