using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PartyFinderData.ModelLayers;
using PartyFinderService.BusinessLogicLayer.EventLogic;
using PartyFinderService.DTO;
using System.Collections.Generic;

namespace PartyFinderService.Controllers
{
    [Route("api/event")]
    [ApiController]

    public class EventController : Controller
    {
        readonly EventDataControl _eControl;

        public EventController()
        {
            _eControl = new EventDataControl();
        }

        // URL: api/event
        [HttpGet]
        public ActionResult<List<EventDataReadDTO>> Get()
        {
            ActionResult<List<EventDataReadDTO>> foundReturn;
            // retrieve and convert data
            List<Event> foundEvents = _eControl.Get();
            List<EventDataReadDTO> foundDTOs = ModelConversion.EventDataReadDTOConvert.FromEventCollection(foundEvents);
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

        // URL: api/event
        [HttpPost]
        public void PostNewEvent(EventDataCreateDTO inEvent)
        {
            if (inEvent != null)
            {
                ModelConversion.EventDataCreateDTOConvert.ToEvent(inEvent);
            }
        }

    }
}
