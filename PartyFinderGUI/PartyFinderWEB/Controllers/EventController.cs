using Microsoft.AspNetCore.Mvc;

namespace PartyFinderWEB.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
