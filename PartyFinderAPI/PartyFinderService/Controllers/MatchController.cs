using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PartyFinderData.ModelLayers;
using PartyFinderService.BusinessLogicLayer;
using PartyFinderService.DTO;

namespace PartyFinderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MatchController : ControllerBase
    {
        readonly MatchDataControl _mControl;
        readonly ProfileDataControl _pControl;
        public MatchController()
        {
            _mControl = new MatchDataControl();

            _pControl = new ProfileDataControl();
        }
        [HttpPost]
        public ActionResult<bool> PostMatch(Match match)
        {
            int eventId = match.EventId;
            int profileId = match.ProfileId;
            bool isMatched = match.Match1;
            return _mControl.Match(eventId, profileId, isMatched);
        }
        [HttpGet("{aspNetFK}")]
        public ActionResult<Event> GetSpecificEvent(string aspNetFK)
        {
            int profileId = _pControl.GetProfileByUserIdValue(aspNetFK);

            ActionResult<Event> foundReturn;
            // retrieve and convert data
            Event foundEvent = _mControl.GetSpecificEvent(profileId);

            // evaluate
            if (foundEvent != null)
            {
                if (foundEvent.Id > 0)
                {
                    foundReturn = Ok(foundEvent);                 // Statuscode 200
                }
                else
                {
                    foundReturn = new StatusCodeResult(204);    // Ok, but no content
                }
            }
            else
            {
                foundReturn = new StatusCodeResult(500);        // Internal server error
            }
            // send response back to client
            return foundReturn;
        }
    }
}
