using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;

namespace MyPortfolio.ViewComponents.LayoutViewComponents
{
	public class LayoutNavbarComponentPartial : ViewComponent
	{
        private readonly MyPortfolioContext _portfolioContext;
        public LayoutNavbarComponentPartial(MyPortfolioContext portfolioContext)
        {
            _portfolioContext = portfolioContext;
        }
        public IViewComponentResult Invoke()
		{
            ViewBag.toDoListCount = _portfolioContext.ToDoLists.Where(x => x.Status == false).Count();
            var values = _portfolioContext.ToDoLists.Where(x => x.Status == false).ToList();
			return View(values);
		}
	}
}
