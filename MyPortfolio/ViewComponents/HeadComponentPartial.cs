using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.ViewComponents
{
    public class HeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
