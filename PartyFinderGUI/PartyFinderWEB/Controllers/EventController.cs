using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PartyFinderWEB.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using RestSharp;
using RestSharp.Authenticators;
using System.Dynamic;
using PartyFinderWEB.ServiceLayer;

namespace PartyFinderWEB.Controllers
{
    public class EventController : Controller
    {
        EventServiceAccess _eAccess;

        public EventController()
        {
            _eAccess = new EventServiceAccess();
        }
        public IActionResult CreateEvent()
        {
            return View();
        }
        public async Task<int> SaveEvent(string eventName, int eventCapacity, DateTime startDateTime, DateTime endDateTime, string description)
        {
            var identity = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            string userIdValue = claims.Where(c => c.Type == "user_id").FirstOrDefault()?.Value;

            int profileId = int.Parse(userIdValue);

            EventViewModel newEvent = new EventViewModel(eventName, eventCapacity, startDateTime, endDateTime, description, profileId);
            int insertedId = await _eAccess.SaveEvent(newEvent);
            return insertedId;
            
        }
        /*public async Task<EventViewModel> GetEvent(int id)
        {
            EventViewModel foundEvent = await _eAccess.(id);
            return foundEvent;
        }*/
    }
  }
