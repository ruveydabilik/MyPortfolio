using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.ViewComponents
{
    public class SkillComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
