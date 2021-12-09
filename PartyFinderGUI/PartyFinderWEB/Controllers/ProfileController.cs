using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PartyFinderWEB.Models;
using PartyFinderWEB.ServiceLayer;
using System.Security.Claims;

namespace PartyFinderWEB.Controllers
{
    public class ProfileController : Controller
    {
        
        ProfileServiceAccess _pAccess;
        public string ReturnUrl { get; set; }

        public ProfileController()
        {
            _pAccess = new ProfileServiceAccess();
        }

        public IActionResult CreateProfile()
        {
            return View();
        }

        [Authorize]
        public async Task<ActionResult> SaveProfile(string firstName, string lastName, DateTime age, string gender, string returnUrl = null)
        {
            int insertedId = -1;

            returnUrl ??= ("~/");
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var aspNetFK = claim.Value;
            //string sGender = gender.ToString();


            string description = "";
            bool isBanned = false;

            ProfileViewModel newProfile = new ProfileViewModel(firstName, lastName, age, gender, description, isBanned, aspNetFK);
            insertedId = await _pAccess.SaveProfile(newProfile);
            if (insertedId == 0)
            {
                returnUrl = Url.Content("~/Match/SwipeEvent");
            } 
                else 
                {
                //You must be logged in to create a profile.
                //You already own a profile.
                TempData["Message"] = "An error occured";
                }
   
            
            return LocalRedirect(returnUrl);

        }
        
    }
}
