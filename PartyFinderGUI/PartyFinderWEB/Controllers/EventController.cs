﻿using Microsoft.AspNetCore.Authorization;
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
        static Random rnd = new Random();

        [Authorize]
        public IActionResult CreateEvent()
        {
            return View();
        }
        [Authorize]
        public IActionResult EventList()
        {
            return View();
        }
        public async Task<int> SaveEvent(string eventName, int eventCapacity, DateTime startDateTime, DateTime endDateTime, string description)
        {
            int insertedId = -1;
            //HOW, database user != database profile. Hvordan hækler vi dem sammen? Identity er en string, men bliver converted til en int?
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            var aspNetFK = claim.Value;

            int profileId = -1;
            if(aspNetFK != null)
            {
                EventViewModel newEvent = new EventViewModel(eventName, eventCapacity, startDateTime, endDateTime, description, aspNetFK, profileId);
                insertedId = await _eAccess.SaveEvent(newEvent);
            }
            else
            {

            }
            return insertedId;

        }
        public async Task<EventViewModel> GetEvents()
        {
            int id = -1;
            List<EventViewModel> foundEvents = await _eAccess.GetEvents(id);
            int r = rnd.Next(foundEvents.Count);
            EventViewModel foundEvent = foundEvents.ElementAt(r);
            return foundEvent;
        }
    }
}
