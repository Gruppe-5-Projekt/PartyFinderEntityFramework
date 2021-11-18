using PartyFinderData.ModelLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyFinderData.DatabaseLayers.Match
{
    internal interface MatchAccess : IMatchAccess
    {
        //Før denne metode startes transaktionen
        
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
                    .ToList().FirstOrDefault();
            int capacity = specificEvent.EventCapacity;
            return capacity;
        }
        
        //Optimistisk concurency, der tilføjer en person til match-tabellen
         public string CheckAndCommitMatch(int eventId, int profileId)
        {
            var db = new PartyFinderContext();
            using var transaction = db.Database.BeginTransaction();
            try
            {
                //Koden tjekker på databasen om der er plads, og comitter en profil.
                int allMatches = CheckCurrentMatches(eventId);
                int capacity = CheckCapacity(eventId);
                if (allMatches < capacity)
                {
                    Object matchToAdd = profileId + eventId;
                    Console.WriteLine("Inserting a new match");
                    db.Add(matchToAdd);
                }
                //Koden tjekker igen om der er plads og ruller tilbage hvis der er for mange.
                int allMatchesNow = CheckCurrentMatches(eventId);
                if (allMatchesNow <= capacity)
                {
                    transaction.Commit();
                    string status = "You have been added to the party";
                    return status;
                }
                else
                {
                    transaction.Rollback();
                    string status = "The party is at maximum capacity";
                    return status;
                }
            }
            catch
            {
                string status = "There was an error, you have not been added";
                return status;
            }
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