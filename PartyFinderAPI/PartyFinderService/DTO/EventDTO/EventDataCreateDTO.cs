using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyFinderService.DTO
{
    public class EventDataCreateDTO
    {
        public string EventName { get; set; }
        public int EventCapacity { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Description { get; set; }
        public string AspNetFK { get; set; }
        public int ProfileId { get; set; }


        public EventDataCreateDTO() { }

        public EventDataCreateDTO(string eventName, int eventCapacity, DateTime startDateTime, DateTime endDateTime, string description, string aspNetFK, int profileId)
        {
            EventName = eventName;
            EventCapacity = eventCapacity;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            Description = description;
            AspNetFK = aspNetFK;
            ProfileId = profileId;
        }
    }
}
