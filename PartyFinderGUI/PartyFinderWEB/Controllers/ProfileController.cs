using Microsoft.AspNetCore.Mvc;
using PartyFinderWEB.Models;
using System.Security.Claims;

namespace PartyFinderWEB.Controllers
{
    public class ProfileController : Controller
    {
        /*
        ProfileServiceAccess _pAccess;

        public ProfileController()
        {
            _pAccess = new ProfileServiceAccess();
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<int> SaveProfile(string firstName, string lastName, DateTime age, string gender)
        {
            int insertedId = -1;
            //HOW, database user != database profile. Hvordan hækler vi dem sammen? Identity er en string, men bliver converted til en int?
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var aspNetFK = claim.Value;
            if (aspNetFK != null)
            {
                ProfileViewModel newProfile = new ProfileViewModel(firstName, lastName, age, gender, aspNetFK);
                insertedId = await _pAccess.SaveEvent(newProfile);
            }
            else
            {

            }
            return insertedId;

        }
        */
    }
}
