using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using diplom.Data;
using diplom.Models;
using diplom.data.Enum;

namespace diplom.Controllers
{
	public class TeachersController : Controller
	{
		private readonly DiplomDbContext _dbContext;
		public TeachersController(DiplomDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public IActionResult Index()
		{
			List<Teacher> teachers = _dbContext.Teachers.ToList();
			return View(teachers);
		}
		public IActionResult Create()
		{ 
			ViewBag.Category = Enum.GetValues(typeof(TeacherCategory));
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Teacher obj, string SelectedCategory)
		{
			if (ModelState.IsValid)
			{
				obj.Category = Array.IndexOf(Enum.GetValues(typeof(TeacherCategory)), SelectedCategory);
				_dbContext.Teachers.Add(obj);
				_dbContext.SaveChanges();
				TempData["success"] = "Преподаватель успешно добавлен";
				return RedirectToAction("Index");
			}
			return View(obj);
		}

		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			var teacherFromDb = _dbContext.Teachers.Find(id);
			if (teacherFromDb == null)
			{
				return NotFound();
			}

			return View(teacherFromDb);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Teacher obj)
		{
			if (ModelState.IsValid)
			{
				_dbContext.Teachers.Update(obj);
				_dbContext.SaveChanges();
				TempData["success"] = "Преподаватель успешно обновлен";
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

			var obj = _dbContext.Teachers.Find(id);
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
			var obj = _dbContext.Teachers.Find(id);
			if (obj == null)
			{
				return NotFound();
			}
			_dbContext.Teachers.Remove(obj);
			_dbContext.SaveChanges();
			TempData["success"] = "Преподаватель успешно удален";
			return RedirectToAction("Index");
		}
	}
}
