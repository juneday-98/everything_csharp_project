using System;
using System.Collections.Generic;

namespace amazing_api.Models;

public partial class RelicSubValue
{
    public int Id { get; set; }

    public int RelicStatId { get; set; }

    public int RelicRarityId { get; set; }

    public double Value { get; set; }

    public string? Step { get; set; }

    public string? CreateDate { get; set; }

    public string? UpdateDate { get; set; }
}
