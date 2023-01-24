using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            return View("partyInfo");
        }
        public IActionResult showGuests()
        {
            List<Guests> guests = SampleData.guests;
            return View("showGuests", guests);
        }
        public IActionResult appForm()
        {
            return View("appForm");
        }
        public IActionResult addtoGuests(Guests g)
        {
            SampleData.guests.Add(g);
            List<Guests> guests =  SampleData.guests;
            View("showGuests", guests);
            if (g.willAttend == "yes")
            {
                return View("thankyou");
            } else
            {
                return View("seeYouLater");
            }

        }

    }
}
