using Microsoft.AspNetCore.Mvc;
using PartyFinderWEB.Models;
using System.Security.Claims;

namespace PartyFinderWEB.Controllers
{
    public class MatchController : Controller
    {
        public MatchController()
        {
            _mAccess = new MatchServiceAccess();
        }
        static Random rnd = new Random();
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
                insertedId = await _mAccess.LikeMatch(newMatch);
            }
            else
            {

            }
            return View();
            //return View("CreatedEvent", insertedId as object);
        }
        public async Task<EventViewModel> GetEvent()
        {
            int id = -1;
            List<EventViewModel> foundEvents = await _mAccess.GetEvents(id);
            int r = rnd.Next(foundEvents.Count);
            EventViewModel foundEvent = foundEvents.ElementAt(r);
            return foundEvent;
        }
    }
}
