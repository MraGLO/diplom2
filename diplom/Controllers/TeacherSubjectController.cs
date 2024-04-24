using diplom.data.Enum;
using diplom.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace diplom.Controllers
{
	public class TeacherSubjectController : Controller
	{
		private readonly ITeacherSubjectRepository _repository;
		private readonly ITeacherRepository _teacherRepository;
		private readonly ISubjectRepository _subjectRepository;
		public TeacherSubjectController(ITeacherSubjectRepository repository, ITeacherRepository teacherRepository, ISubjectRepository subjectRepository)
		{
			_repository = repository;
			_teacherRepository = teacherRepository;
			_subjectRepository = subjectRepository;
		}
		public async Task<IActionResult> Index()
		{
			IEnumerable<Models.TeacherSubject> teacherSubject = await _repository.GetAll();
			return View(teacherSubject);
		}
		public async Task<IActionResult> Create()
		{
			ViewBag.Teachers = await _teacherRepository.GetAll();
			ViewBag.Subject = await _subjectRepository.GetAll();
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Models.TeacherSubject obj)
		{
			if (!ModelState.IsValid)
			{
				return View(obj);
			}
			_repository.Add(obj);
			TempData["success"] = "Предметы успешно прекреплены к преподавателю";
			return RedirectToAction("Index");

		}

		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			var teacherSubjectFromDb = await _repository.GetByIdAsync(id);
			if (teacherSubjectFromDb == null)
			{
				return NotFound();
			}

			return View(teacherSubjectFromDb);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Models.TeacherSubject obj)
		{
			if (ModelState.IsValid)
			{
				_repository.Update(obj);
				TempData["success"] = "Предметы у преподавателя успегшно обновлены";
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

			var obj = await _repository.GetByIdAsync(id);
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
			var obj = await _repository.GetByIdAsync(id);
			if (obj == null)
			{
				return NotFound();
			}
			_repository.Delete(obj);
			TempData["success"] = "Преподаватель больше не имеет предметв";
			return RedirectToAction("Index");
		}
	}
}
