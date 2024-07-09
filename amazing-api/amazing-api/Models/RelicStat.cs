using System;
using System.Collections.Generic;

namespace amazing_api.Models;

public partial class RelicStat
{
    public int Id { get; set; }

    public string? StatCode { get; set; }

    public string? StatName { get; set; }

    public string? DateType { get; set; }

    public string? Unit { get; set; }

    public bool? Usable { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }
}
