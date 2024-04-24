using diplom.Models;

namespace diplom.Interfaces
{
	public interface ITeacherSubjectRepository
	{
		Task<IEnumerable<TeacherSubject>> GetAll();
		Task<TeacherSubject> GetByIdAsync(int? id);
		bool Add(TeacherSubject teacherSubject);
		bool Update(TeacherSubject teacherSubject);
		bool Delete(TeacherSubject teacherSubject);
		bool Save();
	}
}
