﻿using Microsoft.Extensions.Configuration;
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
        public void CreateEvent(Event eventToAdd)
        {
            var db = new PartyFinderContext();
            Console.WriteLine("Inserting a new event");
            db.Add(eventToAdd);
            db.SaveChanges();
        }

        public void DeleteEventById(int id)
        {
            Console.WriteLine("Deleteting event");
            var db = new PartyFinderContext();
            var removeByID = db.Events
                        .Where(e => e.ID == id);
            db.Remove(removeByID);
            db.SaveChanges();
        }

        public List<Event> GetEventAll()
        {
            Console.WriteLine("Getting all events");
            var db = new PartyFinderContext();
            var allEvents = db.Events
                        .ToList();
            return allEvents;
        }
        public Event GetEventByID(int id)
        {
            Console.WriteLine("Finding event");
            var db = new PartyFinderContext();
            var foundEvent = db.Events
                       .Where(e => e.ID == id);
            return (Event)foundEvent;
        }

        public void UpdateEvent(int id, Event updatedEvent)
        {
            Console.WriteLine("Updating event");
            var db = new PartyFinderContext();
            var eventToUpadate = db.Events
                .Where(e => e.ID == id);
            db.Update(eventToUpadate);
            db.SaveChanges();
        }
    }
}
