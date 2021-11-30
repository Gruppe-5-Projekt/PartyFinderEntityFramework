using Microsoft.AspNetCore.Mvc;
using PartyFinderWEB.Models;
using PartyFinderWEB.ServiceLayer;
using System.Security.Claims;

namespace PartyFinderWEB.Controllers
{
    public class ProfileController : Controller
    {
        
        ProfileServiceAccess _pAccess;


        public ProfileController()
        {
            _pAccess = new ProfileServiceAccess();
        }

        public IActionResult CreateProfile()
        {
            return View();
        }

        
        public async Task<int> SaveProfile(string firstName, string lastName, DateTime age, string gender)
        {
            int insertedId = -1;

            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var aspNetFK = claim.Value;
            //string sGender = gender.ToString();

            if (aspNetFK != null)
            {
                string description = "";
                bool isBanned = false;

                ProfileViewModel newProfile = new ProfileViewModel(firstName, lastName, age, gender, description, isBanned, aspNetFK);
                insertedId = await _pAccess.SaveProfile(newProfile);
            }
            else
            {
                //You must be logged in to create a profile.
            }
            return insertedId;

        }
        
    }
}
