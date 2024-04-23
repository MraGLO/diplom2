using diplom.Data;
using diplom.Interfaces;
using diplom.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace diplom.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubjectRepository _subjectRepository;
        public SubjectController(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Subject> subject = await _subjectRepository.GetAll();
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
				_subjectRepository.Add(obj);
				TempData["success"] = "Предмет успешно добавлен";
				return RedirectToAction("Index");
			}
            return View(obj);
		}

		public async Task<IActionResult> Edit(int? id)
		{
			if (id==null || id==0) 
			{
				return NotFound();
			}

			var subjectFromDb = await _subjectRepository.GetByIdAsync(id);
			if (subjectFromDb == null)
			{
				return NotFound();
			}

			return View(subjectFromDb);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public  IActionResult Edit(Subject obj)
		{
			if (ModelState.IsValid)
			{
				_subjectRepository.Update(obj);
				TempData["success"] = "Предмет успешно обновлен";
				return RedirectToAction("Index");
			}
			return View(obj);
		}

		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			var obj = await _subjectRepository.GetByIdAsync(id);
			if (obj == null)
			{
				return NotFound();
			}

			return View(obj);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeletePost(int? id)
		{
			var obj = await _subjectRepository.GetByIdAsync(id);
			if (obj == null)
			{
				return NotFound();
			}
			_subjectRepository.Delete(obj);
			TempData["success"] = "Предмет успешно удален";
			return RedirectToAction("Index");
		}
	}
}
