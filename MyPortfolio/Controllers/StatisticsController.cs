using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;

namespace MyPortfolio.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly MyPortfolioContext _portfolioContext;
        public StatisticsController(MyPortfolioContext portfolioContext)
        {
            _portfolioContext = portfolioContext;
        }
        public IActionResult Index()
        {
            ViewBag.numOfSkills = _portfolioContext.Skills.Count(); // Veritabanındaki Skill tablosunun veri sayısı
            ViewBag.numOfMessages = _portfolioContext.Messages.Count(); // Veritabanındaki Messages tablosunun veri sayısı
            // Veritabanındaki Messages tablosundaki okunmamış olarak belirtilen mesaj sayısı
            ViewBag.numOfUnreadMessages = _portfolioContext.Messages.Where(x => x.IsRead == false).Count();
            // Veritabanındaki okunmuş olarak belirtilen mesaj sayısı
            ViewBag.numOfReadMessages = _portfolioContext.Messages.Where(x => x.IsRead == true).Count();

            ViewBag.numOfPortfolio = _portfolioContext.Portfolios.Count();
            ViewBag.numOfToDo = _portfolioContext.ToDoLists.Count();
            ViewBag.numOfNotDone = _portfolioContext.ToDoLists.Where(x => x.Status == false).Count();
            ViewBag.numOfDone = _portfolioContext.ToDoLists.Where(x => x.Status == true).Count();
            return View();
        }
    }
}
