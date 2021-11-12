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

        [HttpGet("{id}")]
        public ActionResult<EventDataReadDTO> Get(int Id)
        {
            ActionResult<EventDataReadDTO> foundReturn;
            Event foundEvent = _eControl.Get(Id);
            EventDataReadDTO foundDTOs = ModelConversion.EventDataReadDTOConvert.FromEvent(foundEvent);

            if (foundDTOs != null)
            {
                foundReturn = Ok(foundDTOs);                 // Statuscode 200  
            }
            else
            {
                foundReturn = new StatusCodeResult(500);        // Internal server error
            }
            return foundReturn;
        }

        [HttpDelete("{id}")]
        public ActionResult<String> Delete(int Id)
        {

            String status = "";
            try
            {
                _eControl.Delete(Id);
                status = "Success";
            }
            catch
            {
                status = "Failed";
            }
            return status;
        }
        /*[HttpPut]("{id}")]
        public ActionResult<String> Update(int Id, Event)*/
    }
}
