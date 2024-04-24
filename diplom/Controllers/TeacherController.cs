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
using diplom.Interfaces;

namespace diplom.Controllers
{
	public class TeacherController : Controller
	{
		private readonly ITeacherRepository _repository;
		public TeacherController(ITeacherRepository teacherRepository)
		{
			_repository = teacherRepository;
		}
		public async Task<IActionResult> Index()
		{
            IEnumerable<Models.Teacher> teachers = await _repository.GetAll();
			return View(teachers);
		}
		public IActionResult Create()
		{ 
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Models.Teacher obj)
		{
            if (!ModelState.IsValid)
			{
                return View(obj);
            }
            _repository.Add(obj);
            TempData["success"] = "Преподаватель успешно добавлен";
            return RedirectToAction("Index");
            
		}

		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			var teacherFromDb = await _repository.GetByIdAsync(id);
			if (teacherFromDb == null)
			{
				return NotFound();
			}

			return View(teacherFromDb);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Models.Teacher obj)
		{
			if (ModelState.IsValid)
			{
				_repository.Update(obj);
				TempData["success"] = "Преподаватель успешно обновлен";
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
			TempData["success"] = "Преподаватель успешно удален";
			return RedirectToAction("Index");
		}
	}
}
