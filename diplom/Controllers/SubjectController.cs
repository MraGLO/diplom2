using diplom.Data;
using diplom.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace diplom.Controllers
{
    public class SubjectController : Controller
    {
        private readonly DiplomDbContext _dbContext;
        public SubjectController(DiplomDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            List<Subject> subject = _dbContext.Subjects.ToList();
            return View(subject);
        }
		public IActionResult Create()
		{
			return View();
		}
        [HttpPost]
        [ValidateAntiForgeryToken]
		public IActionResult Create(Subject obj)
		{
            if (ModelState.IsValid) 
            {
				_dbContext.Subjects.Add(obj);
				_dbContext.SaveChanges();
				TempData["success"] = "Предмет успешно добавлен";
				return RedirectToAction("Index");
			}
            return View(obj);
		}

		public IActionResult Edit(int? id)
		{
			if (id==null || id==0) 
			{
				return NotFound();
			}

			var subjectFromDb = _dbContext.Subjects.Find(id);
			if (subjectFromDb == null)
			{
				return NotFound();
			}

			return View(subjectFromDb);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Subject obj)
		{
			if (ModelState.IsValid)
			{
				_dbContext.Subjects.Update(obj);
				_dbContext.SaveChanges();
				TempData["success"] = "Предмет успешно обновлен";
				return RedirectToAction("Index");
			}
			return View(obj);
		}

		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			var obj = _dbContext.Subjects.Find(id);
			if (obj == null)
			{
				return NotFound();
			}

			return View(obj);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult DeletePost(int? id)
		{
			var obj = _dbContext.Subjects.Find(id);
			if (obj == null)
			{
				return NotFound();
			}
			_dbContext.Subjects.Remove(obj);
			_dbContext.SaveChanges();
			TempData["success"] = "Предмет успешно удален";
			return RedirectToAction("Index");
		}
	}
}
