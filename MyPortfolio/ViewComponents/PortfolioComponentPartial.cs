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
            ViewBag.aboutTitle = _portfolioContext.Portfolios.Select(x => x.Title).FirstOrDefault();
            ViewBag.aboutSubTitle = _portfolioContext.Portfolios.Select(x => x.SubTitle).FirstOrDefault();
            ViewBag.aboutDescription = _portfolioContext.Portfolios.Select(x => x.Description).FirstOrDefault();
            var values = _portfolioContext.Portfolios.ToList();
            return View(values);
        }
    }
}
