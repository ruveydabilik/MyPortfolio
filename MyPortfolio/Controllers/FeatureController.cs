using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;
using MyPortfolio.DAL.Entities;

namespace MyPortfolio.Controllers
{
    public class FeatureController : Controller
    {
        private readonly MyPortfolioContext _portfolioContext;
        public FeatureController(MyPortfolioContext portfolioContext)
        {
            _portfolioContext = portfolioContext;
        }
        public IActionResult Feature()
        {
            ViewBag.featureId = _portfolioContext.Features.Select(x => x.FeatureId).FirstOrDefault();
            ViewBag.featureTitle = _portfolioContext.Features.Select(x => x.Title).FirstOrDefault();
            ViewBag.featureDescription = _portfolioContext.Features.Select(x => x.Description).FirstOrDefault();
            return View();
        }

        [HttpGet]
        public IActionResult UpdateFeature(int id)
        {
            var value = _portfolioContext.Features.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            return View(value);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateFeature(Feature feature)
        {
            if (ModelState.IsValid)
            {
                _portfolioContext.Features.Update(feature);
                _portfolioContext.SaveChanges();
                return RedirectToAction("Feature");
            }
            return View();
        }
    }
}
