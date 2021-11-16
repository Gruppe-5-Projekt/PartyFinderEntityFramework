using System;
using System.Collections.Generic;
using System.Text;

namespace PartyFinderData.ModelLayers
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

        public bool IsEventEmpty
        {
            get
            {
                if (String.IsNullOrWhiteSpace(EventName))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
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
        public Event(int id, String EventName, int eventCapacity, DateTime startDateTime, DateTime endDateTime, String desription, int profileID) : this(EventName, eventCapacity, startDateTime, endDateTime, desription, profileID)
        {
            ID = id;
        }
    }
}
