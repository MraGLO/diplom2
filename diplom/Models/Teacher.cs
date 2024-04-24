using System;
using System.Collections.Generic;

namespace diplom.Models;

public partial class Teacher
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public int Category { get; set; }

    public virtual ICollection<Load> Loads { get; set; } = new List<Load>();

    public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; } = new List<TeacherSubject>();

	public override string ToString()
	{
        return FullName;
	}
}
