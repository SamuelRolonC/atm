using System;
using System.Collections.Generic;

namespace Core.Entities;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string IdentityNumber { get; set; } = null!;

    public bool Active { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Card> Cards { get; set; } = new List<Card>();
}
