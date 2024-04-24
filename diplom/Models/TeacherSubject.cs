using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace diplom.Models;

public partial class TeacherSubject
{
    [Key]
    public int Id { get; set; }

    public int TeacherId { get; set; }

    public int SubjectId { get; set; }

    public virtual Subject Subject { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}
