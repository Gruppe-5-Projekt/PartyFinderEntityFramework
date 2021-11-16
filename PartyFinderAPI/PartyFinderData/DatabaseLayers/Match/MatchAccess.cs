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
        public void Match(int profileId, int eventID)
        {
            Object matchToAdd = profileId + eventID;
            var db = new PartyFinderContext();
            Console.WriteLine("Inserting a new match");
            db.Add(matchToAdd);
            db.SaveChanges();
        }
    }
}
