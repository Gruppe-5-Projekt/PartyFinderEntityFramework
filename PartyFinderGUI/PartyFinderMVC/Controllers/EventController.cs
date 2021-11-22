using Microsoft.AspNetCore.Mvc;
using PartyFinderMVC.Models;
using PartyFinderMVC.Access;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Json;

namespace PartyFinderMVC.Controllers
{
    public class EventController : Controller
    {
        private readonly ILogger<EventController> _logger;

        public EventController(ILogger<EventController> logger)
        {
            _logger = logger;
        }

        public IActionResult Event()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /*[HttpPost]
        public async void Index(string eventName, int capacity, DateTime startDateTime, DateTime endDateTime, string description, int profileID)
        {
            EventServiceAccess _eAccess = new EventServiceAccess();
            EventViewModel newEvent = new EventViewModel(eventName, capacity, startDateTime, endDateTime, description, profileID);

        
        using (var client = new HttpClient())

        {
            client.BaseAddress = new Uri("http://localhost:44377/api/event");

            var postTask = client.PostAsJsonAsync<EventViewModel>("api", eventvm);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
        }

        return View(eventvm);
        */
    }
}
