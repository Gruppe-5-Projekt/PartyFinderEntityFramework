using Microsoft.AspNetCore.Mvc;

namespace PartyFinderWEB.Controllers
{
    public class MatchController : Controller
    {
        public IActionResult SwipeEvent()
        {
            return View();
        }

        //public void match(MatchIds)
        //{
        //    Db.add(matchids);
        //    CheckCap(); //bReAkPoInT!
        //    CheckIsSpace(); //ElLeR wHaTeVeR dE mEtOdEr HeDdEr

        //    if(space<capacity)
        //    {
        //        dB.saveChanges();
        //    }
        //}
    }
}
