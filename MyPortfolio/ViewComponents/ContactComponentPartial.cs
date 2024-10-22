using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.ViewComponents
{
    public class ContactComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
