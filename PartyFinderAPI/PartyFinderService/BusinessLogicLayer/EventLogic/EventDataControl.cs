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


        public bool Add(Event eventToAdd)
        {
            bool status = false;
            try
            {
                _eventAccess.CreateEvent(eventToAdd);
                status = true;
            }
            catch
            {
                status = false;
            }
            return status;
        }


        public bool Delete(Event eventToDelete)
        {
            bool successful = false;
            try
            {
                _eventAccess.DeleteEventById(eventToDelete);
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

        /*public List<Event> GetSepcificEvents()
        {
            List<Event> foundEvents;

            foundEvents = _eventAccess.GetSpecificEvents();

            return foundEvents;

        }*/

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
