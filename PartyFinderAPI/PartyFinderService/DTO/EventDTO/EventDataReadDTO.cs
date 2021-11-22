using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyFinderService.DTO
{
    public class EventDataReadDTO
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public int EventCapacity { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public String Description { get; set; }
        public String EventInfo { get; set; }
        public int ProfileId { get; set; }


        public EventDataReadDTO() { }

        public EventDataReadDTO(int id, String eventName, int eventCapacity, DateTime startDateTime, DateTime endDateTime, String description, int profileId)
        {
            Id = id;
            EventName = eventName;
            EventCapacity = eventCapacity;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            Description = description;
            ProfileId = profileId;
        }
    }
}
