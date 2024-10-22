using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.ViewComponents
{
    public class FeatureComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
