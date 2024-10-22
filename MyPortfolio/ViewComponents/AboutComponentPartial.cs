using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.ViewComponents
{
    public class AboutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
