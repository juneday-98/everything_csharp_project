using System;
using System.Collections.Generic;

namespace amazing_api.Models;

public partial class ExistRelic
{
    public int Id { get; set; }

    public int Level { get; set; }

    public int Exp { get; set; }

    public int RelicId { get; set; }

    public int RelicRarityId { get; set; }

    public int RelicPhotoId { get; set; }

    public int RelicItenId { get; set; }

    public int? TagId { get; set; }

    public bool? Usable { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }
}
