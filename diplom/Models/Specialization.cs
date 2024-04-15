using System;
using System.Collections.Generic;

namespace diplom.Models;

public partial class Specialization
{
    public int Id { get; set; }

    public string SpecializationName { get; set; } = null!;

    public string Qualification { get; set; } = null!;

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();

    public virtual ICollection<SubjectSpecialization> SubjectSpecializations { get; set; } = new List<SubjectSpecialization>();
}
