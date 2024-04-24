using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace diplom.Models;

public partial class Subject
{
    public int Id { get; set; }
	[DisplayName("Название предмета")]
	public string SubjectName { get; set; } = null!;

    public virtual ICollection<Load> Loads { get; set; } = new List<Load>();

    public virtual ICollection<SubjectSpecialization> SubjectSpecializations { get; set; } = new List<SubjectSpecialization>();

    public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; } = new List<TeacherSubject>();
	public override string ToString()
	{
		return SubjectName;
	}
}
