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
        public ActionResult<string> PostMatch(MatchDataCreateDTO postEvent)
        {
            try
            {
                postEvent.ProfileId = _pControl.GetProfileByUserIdValue(postEvent.AspNetFK);
                Match dbMatch = ModelConversion.MatchDataCreateDTOConvert.ToMatch(postEvent);

                int matchPosted = _mControl.Match(dbMatch);
                if (matchPosted == -1) return new StatusCodeResult(500);
                if (matchPosted == -2) return new StatusCodeResult(403);
                return new StatusCodeResult(200);
            }
            catch
            {
                return new StatusCodeResult(404);
            }


        }

        [HttpGet("{aspNetFK}")]
        public ActionResult<Event> GetRandomEvent(string aspNetFK)
        {
            try
            {
                int profileId = _pControl.GetProfileByUserIdValue(aspNetFK);
                ActionResult<Event> foundReturn;
                // retrieve and convert data
                Event foundEvent = _mControl.GetRandomEvent(profileId);

                if (foundEvent is null) return new StatusCodeResult(500); // internal server error
                if (foundEvent.Id is <= 0) return new StatusCodeResult(204); // Ok, but no content
                return Ok(foundEvent); // Statuscode 200
            }
            catch
            {
                return new StatusCodeResult(404);
            }

            
        }
    }
}
