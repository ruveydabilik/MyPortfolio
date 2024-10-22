using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.ViewComponents
{
    public class NavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
