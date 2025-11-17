using AACalc.Shared.Domain.Enums;

namespace AACalc.Shared.Dtos.Projections;

public class QualityData
{
    public QualityType QualityType { get; init; }
    public int? Rating { get; init; }
    public IReadOnlyCollection<KeyValuePair<AttributeKey, double>> Attributes { get; init; } = [];
}