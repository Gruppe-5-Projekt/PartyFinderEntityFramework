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
        readonly PartyFinderContext db;

        public ProfileAccess()
        {
            db = new PartyFinderContext();
        }
        public int CreateProfile(Profile profileToAdd)
        {
            Console.WriteLine("Inserting a new profile ");
            var exists = db.Profiles
                      .Where(p => p.AspNetUserForeignKey == profileToAdd.AspNetUserForeignKey);
            if (exists.Any())
            {
                return -2;
            }
            else
            {
                try
                {
                    db.Add(profileToAdd);
                    db.SaveChanges();
                    return profileToAdd.Id;
                }
                catch
                {
                    return -1;
                }
            }
        }

        public void DeleteProfileById(int id)
        {
            Console.WriteLine("Deleteting profile");
            var removeByID = db.Profiles
                        .Where(e => e.Id == id).SingleOrDefault();
            db.Remove(removeByID);
            db.SaveChanges();
        }

        public List<Profile> GetProfileAll()
        {
            Console.WriteLine("Getting all profiles");
            var allProfiles = db.Profiles
                        .ToList();
            return allProfiles;
        }

        public Profile GetProfileByID(int id)
        {
            Console.WriteLine("Finding profile");
            var foundProfile = db.Profiles
                       .Where(e => e.Id == id).SingleOrDefault();
            return foundProfile;
        }

        public int GetProfileIdByUserIdValue(string aspNetFK)
        {
                var profile = db.Profiles
                        .Where(p => p.AspNetUserForeignKey == aspNetFK)
                        .SingleOrDefault();
            if (profile == null)
            {
                return -1;
            }
            else
            {
                int profileId = profile.Id;
                return profileId;
            }
        }

        public void UpdateProfile(int id, Profile updatedProfile)
        {
            Console.WriteLine("Updating profile");
            var eventToUpdate = db.Profiles
                .Where(e => e.Id == id).SingleOrDefault();
            eventToUpdate = updatedProfile;
            db.Update(updatedProfile);
            db.SaveChanges();
        }
    }
}
