using PartyFinderData.ModelLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace PartyFinderData.DatabaseLayers
{
    public class EventAccess : IEventAccess
    {
        readonly PartyFinderContext db;

        public EventAccess()
        {
            db = new PartyFinderContext();
        }

        public int CreateEvent(Event eventToAdd)
        {
            Console.WriteLine("Inserting a new event");
            try
            {
                db.Add(eventToAdd);
                db.SaveChanges();
                return eventToAdd.Id;
            }
            catch
            {
                return -1;
            }
        }

        public bool DeleteEventById(Event eventToDelete)
        {
            bool successful = false;
            Console.WriteLine("Deleteting event");
            int id = eventToDelete.Id;
            var removeByID = db.Events
                        .Where(e => e.Id == id)
                        .SingleOrDefault();
            try
            {
                db.Remove(removeByID);
                db.SaveChanges();
                successful = true;
            }
            catch
            {
                successful = false;
            }
            return successful;
        }

        public List<Event> GetEventAll()
        {
            Console.WriteLine("Getting all events");
            var allEvents = db.Events
                        .ToList();
            return allEvents;
        }

        public Event GetEventByID(int id)
        {
            Console.WriteLine("Finding event");
            var db = new PartyFinderContext();
            var foundEvent = db.Events
                       .Where(e => e.Id == id)
                       .SingleOrDefault();
            return foundEvent;
        }

        public bool UpdateEvent(Event updatedEvent)
        {
            bool successful = false;
            Console.WriteLine("Updating event");
            //int id = updatedEvent.Id;
            //var eventToUpdate = db.Events
            //    .Where(e => e.Id == id)
            //    .SingleOrDefault();
            //eventToUpdate = updatedEvent;
            try
            {
                db.Update(updatedEvent);
                db.SaveChanges();
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
