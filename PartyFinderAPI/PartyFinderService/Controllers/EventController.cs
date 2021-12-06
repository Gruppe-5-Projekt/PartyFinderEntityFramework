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
            // retrieve and convert data
            List<Event> foundEvents = _eControl.Get();
            List<EventDataReadDTO> foundDTOs = ModelConversion.EventDataReadDTOConvert.FromEventCollection(foundEvents);
            // evaluate

            if (foundDTOs is null) return new StatusCodeResult(500); // internal server error
            if (foundDTOs.Count() is 0) return new StatusCodeResult(204); // Ok, but no content

            return Ok(foundDTOs); // Statuscode 200
        }

        [HttpGet("{id}")]
        public ActionResult<EventDataReadDTO> Get(int Id)
        {
            ActionResult<EventDataReadDTO> foundReturn;
            Event foundEvent = _eControl.Get(Id);
            EventDataReadDTO foundDTOs = ModelConversion.EventDataReadDTOConvert.FromEvent(foundEvent);

            if (foundDTOs is null) return new StatusCodeResult(500); // internal server error

            return Ok(foundDTOs); // Statuscode 200
        }

        [HttpDelete("{id}")]
        public ActionResult<String> Delete(int id)
        {
            Event foundEvent = _eControl.Get(id);

            if (foundEvent is null) return new StatusCodeResult(500); // internal server error

            return Ok(foundEvent); // Statuscode 200

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
