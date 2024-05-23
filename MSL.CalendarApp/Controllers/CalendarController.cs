using Microsoft.AspNetCore.Mvc;

namespace MSL.CalendarApp.Controllers
{
    public class CalendarController : Controller
    {
        public IActionResult Calendar()
        {
            return View();
        }
    }
}
