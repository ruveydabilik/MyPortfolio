using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.ViewComponents
{
    public class PortfolioComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
