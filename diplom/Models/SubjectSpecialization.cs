using System;
using System.Collections.Generic;

namespace diplom.Models;

public partial class SubjectSpecialization
{
    public int Id { get; set; }

    public int SpecializationId { get; set; }

    public int SubjectId { get; set; }

    public virtual Specialization Specialization { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;
}
