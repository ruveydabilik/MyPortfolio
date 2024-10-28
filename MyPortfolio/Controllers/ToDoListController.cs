using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;
using MyPortfolio.DAL.Entities;

namespace MyPortfolio.Controllers
{
	public class ToDoListController : Controller
	{
		private readonly MyPortfolioContext _portfolioContext;
		public ToDoListController(MyPortfolioContext portfolioContext)
		{
			_portfolioContext = portfolioContext;
		}
		public IActionResult Index()
		{
			var values = _portfolioContext.ToDoLists.ToList();
			return View(values);
		}

		[HttpGet]
		public IActionResult CreateToDo() // Yapılacaklar listesine yeni bir şey ekleme
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateToDo(ToDoList toDoList) // Yapılacaklar listesine yeni bir şey ekleme
		{
			if (ModelState.IsValid)
			{
				toDoList.Status = false;
				_portfolioContext.ToDoLists.Add(toDoList); // Ekleme işlemini yap
				_portfolioContext.SaveChanges(); // Veritabanına değişiklikleri kaydet
				return RedirectToAction("Index"); // Tekrar yönlendirme yap
			}
			return View();
		}

		public IActionResult DeleteToDo(int id)
		{
			var value = _portfolioContext.ToDoLists.Find(id);
			if (value == null)
			{
				return NotFound();
			}
			else
			{
				_portfolioContext.ToDoLists.Remove(value);
				_portfolioContext.SaveChanges();
				return RedirectToAction("Index");
			}
		}

		// GET: Düzenlenecek öğeyi göstermek için
		[HttpGet]
		public IActionResult UpdateToDo(int id)
		{
			var value = _portfolioContext.ToDoLists.Find(id);
			if (value == null)
			{
				return NotFound();
			}
			return View(value);
		}

		// POST: Güncelleme işlemini gerçekleştirmek için
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult UpdateToDo(ToDoList toDoList)
		{
			if (ModelState.IsValid)
			{
				_portfolioContext.ToDoLists.Update(toDoList);
				_portfolioContext.SaveChanges();
				return RedirectToAction("Index");
			}
			return View();
		}

        public IActionResult ChangeIsDoneToTrue(int id) // Yapıldı Olarak İşaretle
        {
            var value = _portfolioContext.ToDoLists.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            else
            {
                value.Status = true;
                _portfolioContext.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public IActionResult ChangeIsDoneToFalse(int id) // Yapılmadı Olarak İşaretle
        {
            var value = _portfolioContext.ToDoLists.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            else
            {
                value.Status = false;
                _portfolioContext.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}
