using System;
using System.Collections.Generic;

namespace diplom.Models;

public partial class Group
{
    public int Id { get; set; }

    public int Course { get; set; }

    public int Year { get; set; }

    public int SpecializationId { get; set; }

    public virtual ICollection<Load> Loads { get; set; } = new List<Load>();

    public virtual Specialization Specialization { get; set; } = null!;
}
