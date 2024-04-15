using System;
using System.Collections.Generic;

namespace diplom.Models;

public partial class Load
{
    public int Id { get; set; }

    public int TeacherId { get; set; }

    public int SubjectId { get; set; }

    public int GroupId { get; set; }

    public int FirstSemesterTime { get; set; }

    public int SecondSemesterTime { get; set; }

    public int TheoryTime { get; set; }

    public int PracticalTime { get; set; }

    public int? LpzOneTime { get; set; }

    public int? LpzTwoTime { get; set; }

    public int? ConsultationTime { get; set; }

    public int? CourseProjectTime { get; set; }

    public string AllHoursInFirstSemester { get; set; } = null!;

    public string AllHoursInSecondSemester { get; set; } = null!;

    public int Total { get; set; }

    public virtual Group Group { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}
