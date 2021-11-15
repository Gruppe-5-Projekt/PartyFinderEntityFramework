using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyFinderService.DTO
{
    public class EventDataReadDTO
    {
        public string EventName { get; set; }
        public int EventCapacity { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public String Description { get; set; }
        public String EventInfo { get; set; }
        public int ProfileID { get; set; }


        public EventDataReadDTO() { }

        public EventDataReadDTO(String eventName, int eventCapacity, DateTime startDateTime, DateTime endDateTime, String description, int profileID)
        {
            EventName = eventName;
            EventCapacity = eventCapacity;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            Description = description;
            ProfileID = profileID;
        }
    }
}
