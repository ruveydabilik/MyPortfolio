using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;
using MyPortfolio.DAL.Entities;
using System;

namespace MyPortfolio.Controllers
{
    public class ContactController : Controller
    {
        private readonly MyPortfolioContext _portfolioContext;
        public ContactController(MyPortfolioContext portfolioContext)
        {
            _portfolioContext = portfolioContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(Message message)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    message.IsRead = false;
                    message.SendDate = DateTime.Now;
                    _portfolioContext.Messages.Add(message); // Ekleme işlemini yap
                    _portfolioContext.SaveChanges(); // Veritabanına değişiklikleri kaydet
                    ViewBag.flag = true;
                    TempData["SuccessMessage"] = "Mesajınız gönderildi. Teşekkürler!";
                    return RedirectToAction("Index", "Default"); // Tekrar yönlendirme yap
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                TempData["ErrorMessage"] = "Bir şeyler yanlış gitti. Lütfen yeniden deneyin!";
            }

            return View();
        }
    }
}
