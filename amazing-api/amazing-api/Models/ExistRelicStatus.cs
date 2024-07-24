using System;
using System.Collections.Generic;

namespace amazing_api.Models;

public partial class ExistRelicStatus
{
    public int Id { get; set; }

    public int ExistRelicId { get; set; }

    public int RelicStatId { get; set; }

    public int StatType { get; set; }

    public int Step { get; set; }

    public double Value { get; set; }

    public string? CreateDate { get; set; }

    public string? UpdateDate { get; set; }
}
