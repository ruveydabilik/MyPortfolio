using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;
using MyPortfolio.DAL.Entities;

namespace MyPortfolio.Controllers
{
    public class SkillController : Controller
    {
        private readonly MyPortfolioContext _portfolioContext;
        public SkillController(MyPortfolioContext portfolioContext)
        {
            _portfolioContext = portfolioContext;
        }
        public IActionResult SkillList()
        {
            var values = _portfolioContext.Skills.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateSkill()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSkill(Skill skill)
        {
            if (ModelState.IsValid)
            {
                _portfolioContext.Skills.Add(skill); // Ekleme işlemini yap
                _portfolioContext.SaveChanges(); // Veritabanına değişiklikleri kaydet
                return RedirectToAction("SkillList"); // Tekrar yönlendirme yap
            }
            return View();
        }
        public IActionResult DeleteSkill(int id)
        {
            var value = _portfolioContext.Skills.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            else
            {
                _portfolioContext.Skills.Remove(value);
                _portfolioContext.SaveChanges();
                return RedirectToAction("SkillList");
            }
        }

        [HttpGet]
        public IActionResult UpdateSkill(int id)
        {
            var value = _portfolioContext.Skills.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            return View(value);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateSkill(Skill skill)
        {
            if (ModelState.IsValid)
            {
                _portfolioContext.Skills.Update(skill);
                _portfolioContext.SaveChanges();
                return RedirectToAction("SkillList");
            }
            return View();
        }
    }
}
