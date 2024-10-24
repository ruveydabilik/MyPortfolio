using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;

namespace MyPortfolio.ViewComponents
{
    public class AboutComponentPartial : ViewComponent
    {
        private readonly MyPortfolioContext _portfolioContext;
        public AboutComponentPartial(MyPortfolioContext portfolioContext)
        {
            _portfolioContext = portfolioContext;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.aboutTitle = _portfolioContext.Abouts.Select(x => x.Title).FirstOrDefault();
            ViewBag.aboutSubdescription = _portfolioContext.Abouts.Select(x => x.SubDescription).FirstOrDefault();
            ViewBag.aboutDetails = _portfolioContext.Abouts.Select(x => x.Details).FirstOrDefault();
            return View();
        }
    }
}
