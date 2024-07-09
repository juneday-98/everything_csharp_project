using System;
using System.Collections.Generic;

namespace amazing_api.Models;

public partial class RelicMainValue
{
    public int Id { get; set; }

    public int RelicStatId { get; set; }

    public int? RelicRarityId { get; set; }

    public double? Base { get; set; }

    public double? PerLevel { get; set; }

    public double? MaxValue { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }
}
