using Microsoft.AspNetCore.Mvc;

namespace MSL.CalendarApp.Controllers
{
    public class VacancyController : Controller
    {
        public IActionResult getEvents()
        {
            return View();
        }
    }
}
