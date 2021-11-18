﻿using PartyFinderData.ModelLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyFinderData.DatabaseLayers
{
    public class MatchAccess : IMatchAccess
    {
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
         public bool CheckAndCommitMatchPublic(int eventId, int profileId)
        {
            var db = new PartyFinderContext();
            bool status = false;
            try
            {
                //Koden tjekker på databasen om der er plads, og comitter en profil.
                int allMatches = CheckCurrentMatches(eventId);
                int capacity = CheckCapacity(eventId);
                if (allMatches < capacity)
                {
                    Match match = new Match {EventId = eventId, ProfileId = profileId, Match1 = true };
                    Console.WriteLine("Inserting a new match");
                    db.Matches
                        .Add(match);
                }
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
            catch
            {
                status = false;
            }

            return status;
        }
            
    }
}




//Kodenote:
/*var allMatches = db.Matches
                    .Where(e => e.EventId == eventId)
                    .Where(m => m.Match1 == true)
                    .Count();
                */
/*var specificEvent = db.Events
    .Where(e => e.Id == eventId)
    .ToList().FirstOrDefault();
int capacity = specificEvent.EventCapacity;
*/