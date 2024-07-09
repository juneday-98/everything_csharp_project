using System;
using System.Collections.Generic;

namespace amazing_api.Models;

public partial class Relic
{
    public int Id { get; set; }

    public string? RelicName { get; set; }

    public bool? Useable { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }
}
