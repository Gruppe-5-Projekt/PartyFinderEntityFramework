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
        public void Match(int profileID, int eventID)
        {
            Object matchToAdd = profileID + eventID;
            var db = new PartyFinderContext();
            Console.WriteLine("Inserting a new match");
            db.Add(matchToAdd);
            db.SaveChanges();
        }
    }
}
