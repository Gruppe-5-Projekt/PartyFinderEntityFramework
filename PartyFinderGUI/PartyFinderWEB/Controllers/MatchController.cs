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
        public IActionResult SwipeEvent()
        {
            return View();
        }

        public async Task<ActionResult> LikeOrDislike(int eventId, bool isMatched)
        {
            int insertedId = -1;
            //HOW, database user != database profile. Hvordan hækler vi dem sammen? Identity er en string, men bliver converted til en int?
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var aspNetFK = claim.Value;

            if (aspNetFK != null)
            {
                MatchViewModel newMatch = new MatchViewModel(aspNetFK, eventId, isMatched);
                insertedId = await _mAccess.LikeOrDislike(newMatch);
            }
            else
            {

            }
            return View();
            //return View("CreatedEvent", insertedId as object);
        }
        public async Task<MatchViewModel> GetEvent()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var aspNetFK = claim.Value;
            MatchViewModel foundEvent = await _mAccess.GetEvent(aspNetFK);
            return foundEvent;

        }
    }
}
