using diplom.Data;
using diplom.Interfaces;
using diplom.Models;
using Microsoft.EntityFrameworkCore;

namespace diplom.Repository
{
	public class TeacherRepository : ITeacherRepository
	{
		private readonly DiplomDbContext _context;
		public TeacherRepository(DiplomDbContext context)
		{
			_context = context;
		}
		public bool Add(Teacher teacher)
		{
            _context.Add(teacher);
			return Save();
		}

		public bool Delete(Teacher teacher)
		{
			_context.Remove(teacher);
			return Save();
		}

		public async Task<IEnumerable<Teacher>> GetAll()
		{
			return await _context.Teachers.ToListAsync();
		}

		public async Task<Teacher> GetByIdAsync(int? id)
		{
			return await _context.Teachers.FirstOrDefaultAsync(x => x.Id == id);

		}

		public bool Save()
		{
			var saved = _context.SaveChanges();
			return saved > 0 ? true : false;
		}

		public bool Update(Teacher teacher)
		{
			_context.Update(teacher);
			return Save();
		}
	}
}
