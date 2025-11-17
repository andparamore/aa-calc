using AACalc.Shared.Domain.Enums;

namespace AACalc.Shared.Dtos.Projections.GetFull;

public sealed class SynthesisPoolData
{
    public int PoolId { get; init; }
    public AttributeKey Key { get; init; }
    public double MinValue { get; init; }
    public double MaxValue { get; init; }
}