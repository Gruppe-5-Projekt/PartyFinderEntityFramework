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
        public MatchController()
        {
            _mControl = new MatchDataControl();
        }
        [HttpPost]
        public ActionResult<bool> PostMatch(Match match)
        {
            int eventId = match.EventId;
            int profileId = match.ProfileId;
            bool isMatched = match.Match1;
            return _mControl.Match(eventId, profileId, isMatched);
        }
        [HttpGet("SpecificEvents")]
        public ActionResult<List<MatchDataReadDTO>> GetSpecificEvents()
        {
            ActionResult<List<MatchDataReadDTO>> foundReturn;
            // retrieve and convert data
            List<Event> foundEvents = _mControl.GetSpecificEvents();
            List<MatchDataReadDTO> foundDTOs = ModelConversion.MatchDataReadDTOConvert.FromEventCollection(foundEvents);
            // evaluate
            if (foundDTOs != null)
            {
                if (foundDTOs.Count > 0)
                {
                    foundReturn = Ok(foundDTOs);                 // Statuscode 200
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
