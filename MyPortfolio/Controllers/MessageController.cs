using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;

namespace MyPortfolio.Controllers
{
    public class MessageController : Controller
    {
        private readonly MyPortfolioContext _portfolioContext;
        public MessageController(MyPortfolioContext portfolioContext)
        {
            _portfolioContext = portfolioContext;
        }
        public IActionResult Inbox()
        {
            var values = _portfolioContext.Messages.ToList();
            return View(values);
        }

        public IActionResult ChangeIsReadToTrue(int id) // Okundu Olarak İşaretle
        {
            var value = _portfolioContext.Messages.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            else
            {
                value.IsRead = true;
                _portfolioContext.SaveChanges();
                return RedirectToAction("Inbox");
            }
        }

        public IActionResult ChangeIsReadToFalse(int id) // Okunmadı Olarak İşaretle
        {
            var value = _portfolioContext.Messages.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            else
            {
                value.IsRead = false;
                _portfolioContext.SaveChanges();
                return RedirectToAction("Inbox");
            }
        }

        public IActionResult DeleteMessage(int id)
        {
            var value = _portfolioContext.Messages.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            else
            {
                _portfolioContext.Messages.Remove(value);
                _portfolioContext.SaveChanges();
                return RedirectToAction("Inbox");
            }
        }

        public IActionResult MessageDetail(int id)
        {
            var value = _portfolioContext.Messages.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            return View(value);
        }
    }
}
