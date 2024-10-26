using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;

namespace MyPortfolio.ViewComponents
{
    public class FeatureComponentPartial : ViewComponent
    {
        private readonly MyPortfolioContext _portfolioContext;
        public FeatureComponentPartial(MyPortfolioContext portfolioContext)
        {
            _portfolioContext = portfolioContext;
        }
        public IViewComponentResult Invoke()
        {
            var values = _portfolioContext.Features.ToList();
            return View(values);
        }
    }
}
