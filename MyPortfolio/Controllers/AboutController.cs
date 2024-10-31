using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;
using MyPortfolio.DAL.Entities;

namespace MyPortfolio.Controllers
{
    public class AboutController : Controller
    {
        private readonly MyPortfolioContext _portfolioContext;
        public AboutController(MyPortfolioContext portfolioContext)
        {
            _portfolioContext = portfolioContext;
        }
        public IActionResult About()
        {
            ViewBag.aboutId = _portfolioContext.Abouts.Select(x => x.AboutId).FirstOrDefault();
            ViewBag.aboutTitle = _portfolioContext.Abouts.Select(x => x.Title).FirstOrDefault();
            ViewBag.aboutSubdescription = _portfolioContext.Abouts.Select(x => x.SubDescription).FirstOrDefault();
            ViewBag.aboutDetails = _portfolioContext.Abouts.Select(x => x.Details).FirstOrDefault();
            return View();
        }

        [HttpGet]
        public IActionResult UpdateAbout(int id)
        {
            var value = _portfolioContext.Abouts.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            return View(value);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateAbout(About about)
        {
            if (ModelState.IsValid)
            {
                _portfolioContext.Abouts.Update(about);
                _portfolioContext.SaveChanges();
                return RedirectToAction("About");
            }
            return View();
        }
    }
}
