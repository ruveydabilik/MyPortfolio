using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.ViewComponents
{
    public class ExperienceComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
