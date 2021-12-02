using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PartyFinderData.ModelLayers;
using PartyFinderService.BusinessLogicLayer;
using PartyFinderService.DTO;
using PartyFinderService.DTO.MatchDTO;

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

        //Vi skal have lavet en DTO der tager imod aspNetFK + 
        [HttpPost]
        public ActionResult<bool> PostMatch(MatchDataCreateDTO postEvent)
        {
            string aspNetFK = postEvent.AspNetFK;
            int profileId = _pControl.GetProfileByUserIdValue(aspNetFK);
            postEvent.ProfileId = profileId;
            Match dbMatch = ModelConversion.MatchDataCreateDTOConvert.ToMatch(postEvent);

            return _mControl.Match(dbMatch);
        }

        [HttpGet("{aspNetFK}")]
        public ActionResult<Event> GetRandomEvent(string aspNetFK)
        {
            int profileId = _pControl.GetProfileByUserIdValue(aspNetFK);

            ActionResult<Event> foundReturn;
            // retrieve and convert data
            Event foundEvent = _mControl.GetRandomEvent(profileId);

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
