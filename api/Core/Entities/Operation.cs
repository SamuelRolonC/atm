using System;
using System.Collections.Generic;

namespace Core.Entities;

public partial class Operation
{
    public int Id { get; set; }

    public int CardId { get; set; }

    public decimal? Amount { get; set; }

    public DateTime DateTime { get; set; }

    public int OperationTypeId { get; set; }

    public virtual Card Card { get; set; } = null!;

    public virtual OperationType OperationType { get; set; } = null!;
}
