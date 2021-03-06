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
                if (postEvent.ProfileId == -1) return new StatusCodeResult(500);

                Match dbMatch = ModelConversion.MatchDataCreateDTOConvert.ToMatch(postEvent);

                int matchPosted = _mControl.Match(dbMatch);
                if (matchPosted < 0) return new StatusCodeResult(500);
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
                if (profileId == -1) return new StatusCodeResult(500);

                ActionResult<Event> foundReturn;
                // retrieve and convert data
                Event foundEvent = _mControl.GetRandomEvent(profileId);

                if (foundEvent is null) return new StatusCodeResult(500); // internal server error
                return Ok(foundEvent); // Statuscode 200
            }
            catch
            {
                return new StatusCodeResult(404);
            }

            
        }
    }
}
