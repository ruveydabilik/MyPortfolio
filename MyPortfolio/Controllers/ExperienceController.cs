using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.DAL.Context;
using MyPortfolio.DAL.Entities;
using Newtonsoft.Json.Linq;

namespace MyPortfolio.Controllers
{
    public class ExperienceController : Controller
    {
		private readonly MyPortfolioContext _portfolioContext;
		public ExperienceController(MyPortfolioContext portfolioContext)
		{
			_portfolioContext = portfolioContext;
		}
		public IActionResult ExperienceList()
        {
			var values = _portfolioContext.Experiences.ToList();
			return View(values);
		}

		// Sayfa yüklenince çalışacak
		[HttpGet]
		public IActionResult CreateExperience() {
            return View();
        }

		// Butonla tetiklenir
		[HttpPost]
        public IActionResult CreateExperience(Experience experience)
        {
            if (ModelState.IsValid)
            {
                _portfolioContext.Experiences.Add(experience); // Ekleme işlemini yap
                _portfolioContext.SaveChanges(); // Veritabanına değişiklikleri kaydet
                return RedirectToAction("ExperienceList"); // Tekrar yönlendirme yap
            }
            return View();
        }

        public IActionResult DeleteExperience(int id)
        {
            var value = _portfolioContext.Experiences.Find(id);
            if (value == null)
            {
                return NotFound();
            }else
            {
                _portfolioContext.Experiences.Remove(value);
                _portfolioContext.SaveChanges();
                return RedirectToAction("ExperienceList");
            }
        }

        // GET: Düzenlenecek öğeyi göstermek için
        [HttpGet]
        public IActionResult UpdateExperience(int id)
        {
            var value = _portfolioContext.Experiences.Find(id);
            if(value == null)
            {
                return NotFound();
            }
            return View(value);
        }

        // POST: Güncelleme işlemini gerçekleştirmek için
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateExperience(Experience experience)
        {
            if (ModelState.IsValid)
            {
                _portfolioContext.Experiences.Update(experience);
                _portfolioContext.SaveChanges();
                return RedirectToAction("ExperienceList");
            }
            return View();
        }
    }
}
