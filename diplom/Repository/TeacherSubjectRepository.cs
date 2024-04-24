
using diplom.Data;
using diplom.Interfaces;
using diplom.Models;
using Microsoft.EntityFrameworkCore;

namespace diplom.Repository
{
	public class TeacherSubjectRepository : ITeacherSubjectRepository
	{
		private readonly DiplomDbContext _context;
		public TeacherSubjectRepository(DiplomDbContext context)
		{
			_context = context;
		}

		public bool Add(Models.TeacherSubject teacherSubject)
		{
			_context.Add(teacherSubject);
			return Save();
		}

		public bool Delete(Models.TeacherSubject teacherSubject)
		{
			_context.Remove(teacherSubject);
			return Save();
		}

		public bool Update(Models.TeacherSubject teacherSubject)
		{
			_context.Update(teacherSubject);
			return Save();
		}
		public bool Save()
		{
			var saved = _context.SaveChanges();
			return saved > 0 ? true : false;
		}
		public async Task<IEnumerable<Models.TeacherSubject>> GetAll()
		{
			return await _context.TeacherSubjects.ToListAsync();
		}

		public async Task<Models.TeacherSubject> GetByIdAsync(int? id)
		{
			return await _context.TeacherSubjects.FirstOrDefaultAsync(x => x.Id == id);

		}


		
	}
}
