using System;
using System.Collections.Generic;

namespace amazing_api.Models;

public partial class RelicAvailabilityStat
{
    public int Id { get; set; }

    public string RelicId { get; set; } = null!;

    public string RelicStatId { get; set; } = null!;

    public bool Usable { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }
}
