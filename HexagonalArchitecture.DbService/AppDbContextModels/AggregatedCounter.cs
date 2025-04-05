using System;
using System.Collections.Generic;

namespace HexagonalArchitecture.DbService.AppDbContextModels;

public partial class AggregatedCounter
{
    public string Key { get; set; } = null!;

    public long Value { get; set; }

    public DateTime? ExpireAt { get; set; }
}
