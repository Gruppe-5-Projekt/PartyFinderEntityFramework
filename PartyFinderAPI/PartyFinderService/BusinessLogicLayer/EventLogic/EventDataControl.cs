using Microsoft.Extensions.Configuration;
using PartyFinderData.DatabaseLayers;
using PartyFinderData.ModelLayers;
using System.Collections.Generic;

namespace PartyFinderService.BusinessLogicLayer
{
    public class EventDataControl : IEventData
    {
        readonly IEventAccess _eventAccess;

        public EventDataControl()
        {
            _eventAccess = new EventAccess();
        }


        public int Add(Event eventToAdd)
        {
            try
            {
                return _eventAccess.CreateEvent(eventToAdd);
            }
            catch
            {
                return -1;
            }
        }


        public bool Delete(Event eventToDelete)
        {
            bool successful = false;
            try
            {
                _eventAccess.DeleteEvent(eventToDelete);
                successful = true;
            }
            catch
            {
                successful = false;
            }
            return successful;
        }

        public Event Get(int id)
        {
            Event foundEvent;
            
            foundEvent = _eventAccess.GetEventByID(id);
            
            return foundEvent;

        }

        public List<Event> Get()
        {
            List<Event> foundEvents;
            
            foundEvents = _eventAccess.GetEventAll();
            
            return foundEvents;

        }

        public bool Put(Event updatedEvent)
        {
            bool successful = false;
            try
            {
                _eventAccess.UpdateEvent(updatedEvent);
                successful = true;
            }
            catch
            {
                successful = false;
            }
            return successful;
        }
    }
}
