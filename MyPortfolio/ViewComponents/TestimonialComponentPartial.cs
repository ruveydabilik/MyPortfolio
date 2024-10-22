using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.ViewComponents
{
    public class TestimonialComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
