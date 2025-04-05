﻿using System;
using System.Collections.Generic;

namespace HexagonalArchitecture.DbService.AppDbContextModels;

public partial class Set
{
    public string Key { get; set; } = null!;

    public double Score { get; set; }

    public string Value { get; set; } = null!;

    public DateTime? ExpireAt { get; set; }
}
