using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyFinderClient.ModelLayer
{
    public class Event
    {

        public int ID { get; set; }
        public String EventName { get; set; }
        public int EventCapacity { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public String Description { get; set; }
        public int ProfileID { get; set; }


        public Event() { }
        public Event(string eventName, int eventCapacity, DateTime startDateTime, DateTime endDateTime, string description, int profileID)
        {
            EventName = eventName;
            EventCapacity = eventCapacity;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            Description = description;
            ProfileID = profileID;
        }
        public Event(int id, String EventName, int EventCapacity, DateTime StartDateTime, DateTime EndDateTime, String Desription, int ProfileID) : this(EventName, EventCapacity, StartDateTime, EndDateTime, Desription, ProfileID)
        {
            ID = id;
        }  
    }
}
