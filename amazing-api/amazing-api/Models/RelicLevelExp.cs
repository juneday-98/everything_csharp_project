using System;
using System.Collections.Generic;

namespace amazing_api.Models;

public partial class RelicLevelExp
{
    public int Id { get; set; }

    public int RelicRarityId { get; set; }

    public int CurrentLevel { get; set; }

    public int Exp { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }
}
