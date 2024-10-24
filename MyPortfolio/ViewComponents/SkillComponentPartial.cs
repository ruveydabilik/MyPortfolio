using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;

namespace MyPortfolio.ViewComponents
{
    public class SkillComponentPartial : ViewComponent
    {
        private readonly MyPortfolioContext _portfolioContext;
        public SkillComponentPartial(MyPortfolioContext portfolioContext)
        {
            _portfolioContext = portfolioContext;
        }
        public IViewComponentResult Invoke()
        {
            var values = _portfolioContext.Skills.ToList();
            return View(values);
        }
    }
}
