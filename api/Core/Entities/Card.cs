using System;
using System.Collections.Generic;

namespace Core.Entities;

public partial class Card
{
    public int Id { get; set; }

    public string Number { get; set; } = null!;

    public string Pin { get; set; } = null!;

    public int UserId { get; set; }

    public DateTime DueDate { get; set; }

    public decimal Balance { get; set; }

    public bool IsBlocked { get; set; }

    public int FailAttempts { get; set; }

    public bool Active { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Operation> Operations { get; set; } = new List<Operation>();

    public virtual User User { get; set; } = null!;
}
