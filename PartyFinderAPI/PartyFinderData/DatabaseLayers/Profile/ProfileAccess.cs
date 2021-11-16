using PartyFinderData.ModelLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyFinderData.DatabaseLayers
{
    public class ProfileAccess : IProfileAccess
    {

        public void CreateProfile(Profile profileToAdd)
        {
            var db = new PartyFinderContext();
            Console.WriteLine("Inserting a new profile ");
            db.Add(profileToAdd);
            db.SaveChanges();
        }

        public void DeleteProfileById(int id)
        {
            Console.WriteLine("Deleteting profile");
            var db = new PartyFinderContext();
            var removeByID = db.Profiles
                        .Where(e => e.Id == id).SingleOrDefault();
            db.Remove(removeByID);
            db.SaveChanges();
        }

        public List<Profile> GetProfileAll()
        {
            Console.WriteLine("Getting all profiles");
            var db = new PartyFinderContext();
            var allProfiles = db.Profiles
                        .ToList();
            return allProfiles;
        }

        public Profile GetProfileByID(int id)
        {
            Console.WriteLine("Finding profile");
            var db = new PartyFinderContext();
            var foundProfile = db.Profiles
                       .Where(e => e.Id == id).SingleOrDefault();
            return foundProfile;
        }

        public void UpdateProfile(int id, Profile updatedProfile)
        {
            Console.WriteLine("Updating profile");
            var db = new PartyFinderContext();
            var eventToUpdate = db.Profiles
                .Where(e => e.Id == id).SingleOrDefault();
            eventToUpdate = updatedProfile;
            db.Update(updatedProfile);
            db.SaveChanges();
        }
    }
}
