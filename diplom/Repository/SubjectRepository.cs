using diplom.Data;
using diplom.Interfaces;
using diplom.Models;
using Microsoft.EntityFrameworkCore;

namespace diplom.Repository
{
	public class SubjectRepository : ISubjectRepository
	{
		private readonly DiplomDbContext _context;
		public SubjectRepository(DiplomDbContext context) 
		{
			_context = context;
		}

		public bool Add(Subject subject)
		{
			_context.Add(subject);
			return Save();
		}

		public bool Update(Subject subject)
		{
			_context.Update(subject);
			return Save();
		}

		public bool Delete(Subject subject)
		{
			_context.Remove(subject);
			return Save();
		}

		public bool Save()
		{
			var saved = _context.SaveChanges();
			return saved > 0 ? true : false;
		}

		public async Task<IEnumerable<Subject>> GetAll()
		{
			return await _context.Subjects.ToListAsync();
		}

		public async Task<Subject> GetByIdAsync(int? id)
		{
			return await _context.Subjects.FirstOrDefaultAsync(x => x.Id == id);
		}




	}
}
