using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PartyFinderData.ModelLayers;
using PartyFinderService.BusinessLogicLayer;

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
    }
}
