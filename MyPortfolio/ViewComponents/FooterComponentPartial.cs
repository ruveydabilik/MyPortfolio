using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.ViewComponents
{
    public class FooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
