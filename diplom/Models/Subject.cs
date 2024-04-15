using System;
using System.Collections.Generic;

namespace diplom.Models;

public partial class Subject
{
    public int Id { get; set; }

    public string SubjectName { get; set; } = null!;

    public virtual ICollection<Load> Loads { get; set; } = new List<Load>();

    public virtual ICollection<SubjectSpecialization> SubjectSpecializations { get; set; } = new List<SubjectSpecialization>();

    public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; } = new List<TeacherSubject>();
}
