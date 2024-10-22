using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.ViewComponents
{
    public class StatisticsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
