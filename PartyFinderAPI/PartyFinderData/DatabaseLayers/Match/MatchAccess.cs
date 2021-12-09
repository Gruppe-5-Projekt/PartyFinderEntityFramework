using Microsoft.EntityFrameworkCore;
using PartyFinderData.ModelLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyFinderData.DatabaseLayers
{
    public class MatchAccess : IMatchAccess
    {
        readonly PartyFinderContext db;

        public MatchAccess()
        {
            db = new PartyFinderContext();
        }
        static Random rnd = new Random();
        private Event foundEvent;
        private int eventToRemove;

        public int CheckCurrentMatches(int eventId)
        {
            var allMatches = db.Matches
                .Where(e => e.EventId == eventId)
                .Where(m => m.Match1 == true)
                .Count();
            return allMatches;
        }
        public int CheckCapacity(int eventId)
        {
            var specificEvent = db.Events
                    .Where(e => e.Id == eventId)
                    .ToList().SingleOrDefault();
            int capacity = specificEvent.EventCapacity;
            return capacity;
        }

        //Optimistisk concurency, der tilføjer en person til match-tabellen
        public int CheckAndCommitMatch(Match match)
        {
            int eventId = match.EventId;
            bool isMatched = match.Match1;
            int status = -1;
            if (!isMatched)
            {
                db.Matches
                       .Add(match);
                db.SaveChanges();
                status = -3;
            }
            else
            {
                db.Matches
                       .Add(match);
                int matchAmount = CheckCurrentMatches(eventId);
                int capacity = CheckCapacity(eventId);
                if (matchAmount < capacity)
                {
                    db.SaveChanges();
                    status = 0;
                }
                else
                {
                    status = -2;
                }
            }
            return status;
        }

    public Event GetRandomEvent(int profileId)
    {
        bool complete = false;
        var foundEvents = db.Events
                    .Where(e => e.EndDateTime > DateTime.Now)
                    .Where(e => e.ProfileId != profileId)
                    .ToList();
        while (!complete)
        {
            if (eventToRemove > 0)
            {
                Event itemToRemove = foundEvents.Single(r => r.Id == eventToRemove);
                foundEvents.Remove(itemToRemove);
            }
            int count = foundEvents.Count;
            if (count > 0)
            {
                int r = rnd.Next(count);
                foundEvent = foundEvents.ElementAt(r);
            }
            else
            {
                foundEvent.Id = -1;
                complete = true;
            }
            foundEvent.Matches = db.Matches
                .Where(m => m.EventId == foundEvent.Id)
                .ToList();
            int capacity = foundEvent.EventCapacity;
            int matchAmount = CheckCurrentMatches(foundEvent.Id);
            if (matchAmount > 0 && matchAmount != capacity)
            {
                Match matchInfo = db.Matches
                .Where(m => m.EventId == foundEvent.Id)
                .Where(m => m.ProfileId == profileId)
                .SingleOrDefault();
                if (matchInfo != null)
                {
                    complete = false;
                    eventToRemove = foundEvent.Id;
                }
                else
                {
                    complete = true;
                }
            }
            else
            {
                complete = true;
            }
        }
        return foundEvent;
    }
}
}

