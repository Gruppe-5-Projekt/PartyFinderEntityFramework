using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PartyFinderWEB.Controllers
{
    public class EventController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public IActionResult CreateEvent()
        {
            return View();
        }
        }
    }
