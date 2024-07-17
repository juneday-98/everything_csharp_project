using System;
using System.Collections.Generic;

namespace amazing_api.Models;

public partial class RelicItemPhoto
{
    public int Id { get; set; }

    public int RelicItemId { get; set; }

    public string RelicLinkPhoto { get; set; } = null!;

    public bool Usable { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }
}
