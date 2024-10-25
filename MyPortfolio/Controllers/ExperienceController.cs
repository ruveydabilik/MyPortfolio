using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.Controllers
{
    public class ExperienceController : Controller
    {
        public IActionResult ExperienceList()
        {
            return View();
        }
    }
}
