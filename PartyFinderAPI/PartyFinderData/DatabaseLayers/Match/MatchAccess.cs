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
         public int CheckAndCommitMatchPublic(Match match)
        {
            var db = new PartyFinderContext();
            int eventId = match.EventId;
            int profileId = match.ProfileId;
            bool isMatched = match.Match1;
            int status = -1;
            try
            {
                
                if(isMatched == true)
                {
                    //Koden tjekker på databasen om der er plads, og comitter en profil.
                    int matchAmount = CheckCurrentMatches(eventId);
                    int capacity = CheckCapacity(eventId);
                    if (matchAmount < capacity)
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
                            status = 0;
                        }
                        else
                        {
                            status = -2;
                        }
                    }
                }
                else
                {
                    db.Matches
                            .Add(match);
                    db.SaveChanges();
                    status = 0;
                }
            }
            catch
            {
                status = -1;
            }

            return status;
        }

        public Event GetRandomEvent(int profileId)
        {

            var db = new PartyFinderContext();

            bool complete = false;

            // Så længe while loopet ikke er true, fortsætter den.
            while (complete == false)
            {
                var foundEvents = db.Events
                .Where(e => e.EndDateTime > DateTime.Now)
                .Where(e => e.ProfileId != profileId)
                .ToList();

                // Vælger et tilfældigt event, af de events funktionen over lige har fundet.
                int r = rnd.Next(foundEvents.Count());
                foundEvent = foundEvents.ElementAt(r);

                // Laver en liste over matches, og placerer dem i en ICollection på eventet.
                foundEvent.Matches = db.Matches
                    .Where(m => m.EventId == foundEvent.Id)
                    .ToList();

                int capacity = CheckCapacity(foundEvent.Id);
                int matchAmount = CheckCurrentMatches(foundEvent.Id);

                // Tjekker om der er matches på eventet.
                if(foundEvent.Matches.Count > 0)
                {
                    // foreach der tjekker igennem ICollection af Matches på eventet.
                    foreach (Match item in foundEvent.Matches)
                    {
                        // Tjekker at man ikke allerede er matched.
                        if (item.ProfileId == profileId)
                        {
                            complete = false;
                        }
                        else
                        {
                            // Tjekker om der er plads på eventet.
                            if (matchAmount == capacity)
                            {
                                complete = false;
                            }
                            else
                            {
                                complete = true;
                            }
                        }
                    }
                }
                // Hvis der ikke er matches, tilføjes man uanset, da vi antager at der altid er plads på et event med 0 matches.
                else
                {
                    complete = true;
                }
            }
            return foundEvent;
        }
    }
}

