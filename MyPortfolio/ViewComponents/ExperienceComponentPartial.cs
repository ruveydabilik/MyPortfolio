using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;

namespace MyPortfolio.ViewComponents
{
    public class ExperienceComponentPartial : ViewComponent
    {
        private readonly MyPortfolioContext _portfolioContext;
        public ExperienceComponentPartial(MyPortfolioContext portfolioContext)
        {
            _portfolioContext = portfolioContext;
        }
        public IViewComponentResult Invoke()
        {
            var values = _portfolioContext.Experiences.ToList();
            return View(values);
        }
    }
}
