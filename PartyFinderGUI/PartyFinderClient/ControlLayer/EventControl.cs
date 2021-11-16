using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PartyFinderClient.ModelLayer;
using PartyFinderClient.ServiceLayer;

namespace PartyFinderClient.ControlLayer
{
    public class EventControl
    {

        EventServiceAccess _eAccess;

        public EventControl()
        {
            _eAccess = new EventServiceAccess();
        }

        public async Task<List<Event>> GetAllEvents()
        {
            List<Event> foundEvents = await _eAccess.GetEvents();
            return foundEvents;
        }

        public async Task<int> SaveEvent(string eventName, int eventCapacity, DateTime startDateTime, DateTime endDateTime, string description, int profileID)
        {
            Event newEvent = new Event(eventName, eventCapacity, startDateTime, endDateTime, description, profileID);
            int insertedId = await _eAccess.SaveEvent(newEvent);
            return insertedId;
        }


    }
}
