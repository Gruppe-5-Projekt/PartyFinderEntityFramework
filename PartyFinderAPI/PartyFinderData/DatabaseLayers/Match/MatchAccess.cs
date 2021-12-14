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
            var foundEvent = db.Events
              .Include(e => e.Matches)
              .Where(e => e.EndDateTime > DateTime.Now)
              .Where(e => e.ProfileId != profileId)
              .Where(e => e.EventCapacity > e.Matches.Count(m => m.Match1 == true))
              .Where(e => e.Matches.Count(m => m.ProfileId == profileId) == 0)
              .OrderBy(e => Guid.NewGuid())
              .FirstOrDefault();
            return foundEvent;
        }
    }
}

