using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PartyFinderWEB.Models;
using PartyFinderWEB.ServiceLayer;
using System.Security.Claims;

namespace PartyFinderWEB.Controllers
{
    public class MatchController : Controller
    {
        MatchServiceAccess _mAccess;
        public MatchController()
        {
            _mAccess = new MatchServiceAccess();
        }

        [Authorize]
        public async Task<ActionResult> SwipeEvent()
        {
            try
            {
                var claimsIdentity = (ClaimsIdentity)this.User.Identity;
                var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
                var aspNetFK = claim.Value;
                MatchViewModel foundEvent = await _mAccess.GetEvent(aspNetFK);
                    return View(foundEvent);
            }
            catch
            {
                return View(null);
            }
        }

        public IActionResult Liked()
        {
            return View();
        }

        public IActionResult Disliked()
        {
            return View();
        }

        public IActionResult MaxCapacity()
        {
            return View();
        }


        public async Task<ActionResult> LikeOrDislike(int id, bool isMatched)
        {
            int insertedId = -1;
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var aspNetFK = claim.Value;

            if (aspNetFK != null)
            {
                MatchViewModel newMatch = new MatchViewModel(aspNetFK, id, isMatched);
                insertedId = await _mAccess.LikeOrDislike(newMatch);
                if (insertedId == 0)
                {
                    return RedirectToAction("Liked", "Match");
                }

                else if (insertedId == -1)
                {
                    return RedirectToAction("Disliked", "Match");
                }
                else if (insertedId == -2)
                {
                    return RedirectToAction("MaxCapacity", "Match");
                }
            }
            else
            {

            }
            return RedirectToAction("SwipeEvent", "Match");
        }
        
    }
}
