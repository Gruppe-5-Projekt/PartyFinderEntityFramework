using Microsoft.AspNetCore.Mvc;
using PartyFinderData.ModelLayers;
using PartyFinderService.BusinessLogicLayer;
using PartyFinderService.DTO.ProfileDTO;
using PartyFinderService.ModelConversion.ProfileConv;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PartyFinderService.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        readonly ProfileDataControl _pControl;

        public ProfileController()
        {
            _pControl = new ProfileDataControl();
        }

        // GET: api/<ProfileController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ProfileController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProfileController>
        [HttpPost]
        public ActionResult<string> PostProfile(ProfileDataCreateDTO postProfile)
        {
            try
            {
                Profile dbProfile = ModelConversion.ProfileDataCreateDTOConvert.ToProfile(postProfile);
                _pControl.Add(dbProfile);
                return new StatusCodeResult(200);

            }
            catch
            {
                return new StatusCodeResult(404);
            }
        }

        // PUT api/<ProfileController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProfileController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
