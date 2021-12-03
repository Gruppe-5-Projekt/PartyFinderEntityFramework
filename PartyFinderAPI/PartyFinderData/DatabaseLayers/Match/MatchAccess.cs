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

        static Random rnd = new Random();
        private Event foundEvent;

        public int CheckCurrentMatches(int eventId)
        {
            var db = new PartyFinderContext();
            var allMatches = db.Matches
                .Where(e => e.EventId == eventId)
                .Where(m => m.Match1 == true)
                .Count();
            return allMatches;
        }
        public int CheckCapacity(int eventId)
        {
            var db = new PartyFinderContext();
            var specificEvent = db.Events
                    .Where(e => e.Id == eventId)
                    .ToList().SingleOrDefault();
            int capacity = specificEvent.EventCapacity;
            return capacity;
        }
        
        //Optimistisk concurency, der tilføjer en person til match-tabellen
         public bool CheckAndCommitMatchPublic(Match match)
        {
            var db = new PartyFinderContext();
            bool status = false;
            int eventId = match.EventId;
            int profileId = match.ProfileId;
            bool isMatched = match.Match1;
            try
            {
                
                if(isMatched == true)
                {
                    //Koden tjekker på databasen om der er plads, og comitter en profil.
                    int allMatches = CheckCurrentMatches(eventId);
                    int capacity = CheckCapacity(eventId);
                    if (allMatches < capacity)
                    {
                        Console.WriteLine("Inserting a new match");
                        db.Matches
                            .Add(match);
                        Console.WriteLine("Breakpoint her.");
                        //Koden tjekker igen om der er plads og ruller tilbage hvis der er for mange.
                        int allMatchesNow = CheckCurrentMatches(eventId);
                        if (allMatchesNow < capacity)
                        {
                            db.SaveChanges();
                            status = true;
                        }
                        else
                        {
                            status = false;
                        }
                    }
                }
                else
                {
                    db.Matches
                            .Add(match);
                    db.SaveChanges();
                    status = true;
                }
            }
            catch
            {
                status = false;
            }

            return status;
        }

        public Event GetRandomEvent(int profileId)
        {

            var db = new PartyFinderContext();

            bool complete = false;

            while (complete == false)
            {
                var foundEvents = db.Events
                .Where(e => e.EndDateTime > DateTime.Now)
                .Where(e => e.ProfileId != profileId)
                .ToList();

                int r = rnd.Next(foundEvents.Count());
                foundEvent = foundEvents.ElementAt(3);

                foundEvent.Matches = db.Matches
                    .Where(m => m.EventId == foundEvent.Id)
                    .ToList();

                if(foundEvent.Matches.Count > 0)
                {
                    foreach (Match item in foundEvent.Matches)
                    {
                        if (item.ProfileId == profileId || item.ProfileId == null)
                        {
                            complete = false;
                        }
                        else
                        {
                            complete = true;
                        }
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

