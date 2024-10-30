using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;
using MyPortfolio.DAL.Entities;

namespace MyPortfolio.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly MyPortfolioContext _portfolioContext;
        public PortfolioController(MyPortfolioContext portfolioContext)
        {
            _portfolioContext = portfolioContext;
        }
        public IActionResult PortfolioList()
        {
            var values = _portfolioContext.Portfolios.ToList();
            return View(values);
        }

        [HttpGet] // Sayfa yüklenince çalışacak
        public IActionResult CreatePortfolio()
        {
            return View();
        }

        [HttpPost] // Butonla tetiklenir
        [ValidateAntiForgeryToken]
        public IActionResult CreatePortfolio(Portfolio portfolio)
        {
            if (ModelState.IsValid)
            {
                _portfolioContext.Portfolios.Add(portfolio); // Ekleme işlemini yap
                _portfolioContext.SaveChanges(); // Veritabanına değişiklikleri kaydet
                return RedirectToAction("PortfolioList"); // Tekrar yönlendirme yap
            }
            else
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage); // Ya da loglama yapabilirsiniz
                }
            }
            return View();
        }

        public IActionResult DeletePortfolio(int id)
        {
            var value = _portfolioContext.Portfolios.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            else
            {
                _portfolioContext.Portfolios.Remove(value);
                _portfolioContext.SaveChanges();
                return RedirectToAction("PortfolioList");
            }
        }

        [HttpGet] // Düzenlenecek öğeyi göstermek için
        public IActionResult UpdatePortfolio(int id)
        {
            var value = _portfolioContext.Portfolios.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            return View(value);
        }

        [HttpPost] // Güncelleme işlemini gerçekleştirmek için
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePortfolio(Portfolio portfolio)
        {
            if (ModelState.IsValid)
            {
                _portfolioContext.Portfolios.Update(portfolio);
                _portfolioContext.SaveChanges();
                return RedirectToAction("PortfolioList");
            }
            return View();
        }
    }
}
