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

        
        public async Task<int> SaveProfile(string firstName, string lastName, DateTime age, Gender gender)
        {
            int insertedId = -1;

            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var aspNetFK = claim.Value;

            if (aspNetFK != null)
            {
                ProfileViewModel newProfile = new ProfileViewModel(firstName, lastName, age, gender, aspNetFK);
                insertedId = await _pAccess.SaveProfile(newProfile);
            }
            else
            {

            }
            return insertedId;

        }
        
    }
}
