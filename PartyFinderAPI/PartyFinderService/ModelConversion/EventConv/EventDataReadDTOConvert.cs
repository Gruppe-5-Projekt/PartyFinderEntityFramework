using PartyFinderData.ModelLayers;
using PartyFinderService.DTO;
using System;
using System.Collections.Generic;

namespace PartyFinderService.ModelConversion
{
    public class EventDataReadDTOConvert
    {
        public static List<EventDataReadDTO> FromEventCollection(List<Event> inEvent)
        {
            List<EventDataReadDTO> anEventReadDTOList = null;
            if (inEvent != null)
            {
                anEventReadDTOList = new List<EventDataReadDTO>();
                EventDataReadDTO tempDTO;
                foreach (Event anEvent in inEvent)
                {
                    tempDTO = FromEvent(anEvent);
                    anEventReadDTOList.Add(tempDTO);
                }
            }
            return anEventReadDTOList;
        }

        public static EventDataReadDTO FromEvent(Event inEvent)
        {
            EventDataReadDTO anEventReadDTO = null;
            if (inEvent != null)
            {
                anEventReadDTO = new EventDataReadDTO(inEvent.EventName, inEvent.EventCapacity, inEvent.StartDateTime, inEvent.EndDateTime, inEvent.Description, inEvent.ProfileID);
                anEventReadDTO.EventInfo = $"{inEvent.EventName} {inEvent.EventCapacity} {inEvent.StartDateTime} {inEvent.EndDateTime} {inEvent.Description}";
            }
            return anEventReadDTO;
        }

    }
}
