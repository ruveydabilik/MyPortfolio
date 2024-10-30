using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;

namespace MyPortfolio.ViewComponents
{
    public class PortfolioComponentPartial : ViewComponent
    {
        private readonly MyPortfolioContext _portfolioContext;
        public PortfolioComponentPartial(MyPortfolioContext portfolioContext)
        {
            _portfolioContext = portfolioContext;
        }
        public IViewComponentResult Invoke()
        {
            var values = _portfolioContext.Portfolios.ToList();
            return View(values);
        }
    }
}
