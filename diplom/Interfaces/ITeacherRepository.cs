using diplom.Models;

namespace diplom.Interfaces
{
	public interface ITeacherRepository
	{
		Task<IEnumerable<Teacher>> GetAll();
		Task<Teacher> GetByIdAsync(int? id);
		bool Add(Teacher teacher);
		bool Update(Teacher teacher);
		bool Delete(Teacher teacher);
		bool Save();
	}
}
