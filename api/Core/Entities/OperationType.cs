using System;
using System.Collections.Generic;

namespace Core.Entities;

public partial class OperationType
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public string Code { get; set; } = null!;

    public bool Active { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Operation> Operations { get; set; } = new List<Operation>();
}
