﻿using System;
using System.Collections.Generic;

namespace amazing_api.Models;

public partial class RelicItem
{
    public int Id { get; set; }

    public string ItemDescription { get; set; } = null!;

    public DateTime? CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? RelicId { get; set; }

    public string? ItemName { get; set; }

    public string? ItemCode { get; set; }
}
