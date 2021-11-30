using Microsoft.AspNetCore.Mvc;

namespace PartyFinderWEB.Controllers
{
    public class MatchController : Controller
    {
        public IActionResult SwipeEvent()
        {
            return View();
        }

        public async Task<ActionResult> Like(string eventName, int eventCapacity, DateTime startDateTime, DateTime endDateTime, string description)
        {
            int insertedId = -1;
            //HOW, database user != database profile. Hvordan hækler vi dem sammen? Identity er en string, men bliver converted til en int?
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var aspNetFK = claim.Value;

            int profileId = -1;
            if (aspNetFK != null)
            {
                EventViewModel newEvent = new EventViewModel(eventName, eventCapacity, startDateTime, endDateTime, description, aspNetFK, profileId);
                insertedId = await _eAccess.SaveEvent(newEvent);
            }
            else
            {

            }
            return View("CreatedEvent", insertedId as object);
        }
        public async Task<ActionResult> Dislike(string eventName, int eventCapacity, DateTime startDateTime, DateTime endDateTime, string description)
        {
            int insertedId = -1;
            //HOW, database user != database profile. Hvordan hækler vi dem sammen? Identity er en string, men bliver converted til en int?
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var aspNetFK = claim.Value;

            int profileId = -1;
            if (aspNetFK != null)
            {
                EventViewModel newEvent = new EventViewModel(eventName, eventCapacity, startDateTime, endDateTime, description, aspNetFK, profileId);
                insertedId = await _eAccess.SaveEvent(newEvent);
            }
            else
            {

            }
            return View("CreatedEvent", insertedId as object);
        }
    }
}
