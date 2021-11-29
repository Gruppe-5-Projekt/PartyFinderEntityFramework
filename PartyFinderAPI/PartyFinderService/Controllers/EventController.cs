using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PartyFinderData.ModelLayers;
using PartyFinderService.BusinessLogicLayer;
using PartyFinderService.BusinessLogicLayer;
using PartyFinderService.DTO;
using System.Collections.Generic;

namespace PartyFinderService.Controllers
{
    [Route("api/event")]
    [ApiController]

    public class EventController : ControllerBase
    {
        readonly EventDataControl _eControl;
        readonly ProfileDataControl _pControl;

        public EventController()
        {
            _eControl = new EventDataControl();

            _pControl = new ProfileDataControl();
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

        /*[HttpGet("SpecificEvents")]
        public ActionResult<List<EventDataReadDTO>> GetSpecificEvents()
        {
            ActionResult<List<EventDataReadDTO>> foundReturn;
            // retrieve and convert data
            List<Event> foundEvents = _eControl.GetSpecificEvents();
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
        }*/

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
                foundReturn = new StatusCodeResult(204);    // Ok, but no content
            }
            return foundReturn;
        }

        [HttpDelete("{id}")]
        public ActionResult<String> Delete(int id)
        {
            Event foundEvent = _eControl.Get(id);
            if (foundEvent != null)
            {
                _eControl.Delete(foundEvent);
                return new StatusCodeResult(200);
            }
            else
            {
                return new StatusCodeResult(204);
            }

        }

        [HttpPost]
        public ActionResult<string> PostEvent(EventDataCreateDTO postEvent)
        {
            try
            {
                string loggedInId = postEvent.AspNetFK;
                int profileId = _pControl.GetProfileByUserIdValue(loggedInId);
                postEvent.ProfileId = profileId;
                Event dbEvent = ModelConversion.EventDataCreateDTOConvert.ToEvent(postEvent);
                _eControl.Add(dbEvent);
                return new StatusCodeResult(200);

            }
            catch
            {
                return new StatusCodeResult(404);
            }
        }

        [HttpPut]
        public ActionResult<string> Update(EventDataCreateDTO putEvent)
        {
            String status = "";
            try
            {
                Event dbEvent = ModelConversion.EventDataCreateDTOConvert.ToEvent(putEvent);
                _eControl.Put(dbEvent);
                return new StatusCodeResult(200);
            }
            catch
            {
                return new StatusCodeResult(404);
            }
        }
    }
}
