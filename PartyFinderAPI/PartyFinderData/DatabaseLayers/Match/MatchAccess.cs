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
            Console.WriteLine(capacity);
            return capacity;
        }
        
        //Optimistisk concurency, der tilføjer en person til match-tabellen
         public bool CheckAndCommitMatchPublic(int eventId, int profileId, bool isMatched)
        {
            var db = new PartyFinderContext();
            bool status = false;
            try
            {
                
                if(isMatched == true)
                {
                    //Koden tjekker på databasen om der er plads, og comitter en profil.
                    int allMatches = CheckCurrentMatches(eventId);
                    int capacity = CheckCapacity(eventId);
                    if (allMatches < capacity)
                    {
                        Match match = new Match { EventId = eventId, ProfileId = profileId, Match1 = isMatched };
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
                    Match match = new Match { EventId = eventId, ProfileId = profileId, Match1 = isMatched };
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

        public Event GetSpecificEvent()
        {
            var db = new PartyFinderContext();


            var foundEvents = db.Events
                .Where(e => e.EndDateTime > DateTime.Now)
                .ToList();

            int r = rnd.Next(foundEvents.Count());
            var foundEvent = foundEvents.ElementAt(r);

            var matches = db.Matches
                            .Where(m => m.EventId == foundEvent.Id)
                            .ToList();

            foundEvent.Matches = matches;
            
            return foundEvent;
        }

        //public int GetSpecificEventCount(Event foundEvent)
        //{
        //    var db = new PartyFinderContext();

        //    int foundEventId = foundEvent.Id;

        //    var matchCount = db.Matches
        //                .Where(m => m.EventId == foundEventId)
        //                .Where(m => m.Match1 == true)
        //                .Count();

        //    return matchCount;
        //}
    }
}

