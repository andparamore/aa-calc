using AACalc.Shared.Domain.Enums;

namespace AACalc.Shared.Dtos.Models;

public sealed class SynthesisPoolModel
{
    public int PoolId { get; set; }

    public Dictionary<AttributeKey, SynthesisRangeModel> Ranges { get; set; } =
        [];
}