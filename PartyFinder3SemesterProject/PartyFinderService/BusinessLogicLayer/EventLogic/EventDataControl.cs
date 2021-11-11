using Microsoft.Extensions.Configuration;
using PartyFinderData.DatabaseLayers;
using PartyFinderData.ModelLayers;
using System.Collections.Generic;

namespace PartyFinderService.BusinessLogicLayer.EventLogic
{
    public class EventDataControl : IEventData
    {
        readonly IEventAccess _eventAccess;

        public EventDataControl()
        {
            _eventAccess = new EventAccess();
        }


        public void Add(Event eventToAdd)
        {
            try
            {
                _eventAccess.CreateEvent(eventToAdd);
            }
            catch
            {
            }
        }


        public void Delete(int id)
        {
            _eventAccess.DeleteEventById(id);
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

        public void Put(int id, Event updatedEvent)
        {
            _eventAccess.UpdateEvent(id, updatedEvent);
        }
    }
}
