using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PartyFinderData.ModelLayers;
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
            try
            {
                // retrieve and convert data
                List<Event> foundEvents = _eControl.Get();
                List<EventDataReadDTO> foundDTOs = ModelConversion.EventDataReadDTOConvert.FromEventCollection(foundEvents);
                // evaluate

                if (foundDTOs is null) return new StatusCodeResult(500); // internal server error
                if (foundDTOs.Count() is 0) return new StatusCodeResult(204); // Ok, but no content
                return Ok(foundDTOs); // Statuscode 200
            }
            catch
            {
                return new StatusCodeResult(404);
            }
            
        }

        [HttpGet("{id:int}")]
        public ActionResult<EventDataReadDTO> Get(int Id)
        {
            try
            {
                ActionResult<EventDataReadDTO> foundReturn;
                Event foundEvent = _eControl.Get(Id);
                EventDataReadDTO foundDTOs = ModelConversion.EventDataReadDTOConvert.FromEvent(foundEvent);

                if (foundDTOs is null) return new StatusCodeResult(500); // internal server error
                if (foundDTOs.Id is <= 0) return new StatusCodeResult(204); // Ok, but no content
                return Ok(foundDTOs); // Statuscode 200
            }
            catch
            {
                return new StatusCodeResult(404);
            }
            
        }

        [HttpDelete("{id:int}")]
        public ActionResult<String> Delete(int id)
        {
            try
            {
                Event foundEvent = _eControl.Get(id);
                _eControl.Delete(foundEvent);

                if (foundEvent is null) return new StatusCodeResult(500); // internal server error
                if (foundEvent.Id is <= 0) return new StatusCodeResult(204); // Ok, but no content
                return Ok(foundEvent); // Statuscode 200
            }
            catch
            {
                return new StatusCodeResult(404);
            }

        }

        [HttpPost]
        public ActionResult<string> PostEvent(EventDataCreateDTO postEvent)
        {
            try
            {
                string loggedInId = postEvent.AspNetFK;
                int profileId = _pControl.GetProfileByUserIdValue(loggedInId);
                if (profileId == -1) return new StatusCodeResult(500);

                postEvent.ProfileId = profileId;
                Event dbEvent = ModelConversion.EventDataCreateDTOConvert.ToEvent(postEvent);
                int eventId = _eControl.Add(dbEvent);
                if (eventId is -1) return new StatusCodeResult(500); // internal server error
                if (eventId is <= 0) return new StatusCodeResult(204); // Ok, but no content
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
