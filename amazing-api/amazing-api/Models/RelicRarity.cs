using System;
using System.Collections.Generic;

namespace amazing_api.Models;

public partial class RelicRarity
{
    public int Id { get; set; }

    public string RarityName { get; set; } = null!;

    public int Number { get; set; }

    public double Percent { get; set; }

    public int MaxLevel { get; set; }

    public int MaxSubStat { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }
}
