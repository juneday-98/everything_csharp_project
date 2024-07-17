﻿using System;
using System.Collections.Generic;

namespace amazing_api.Models;

public partial class RelicAvailabilityStat
{
    public int Id { get; set; }

    public bool Usable { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? RelicId { get; set; }

    public int? RelicStatId { get; set; }
}
