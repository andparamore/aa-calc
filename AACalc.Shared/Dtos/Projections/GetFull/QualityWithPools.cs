using AACalc.Shared.Domain.Enums;

namespace AACalc.Shared.Dtos.Projections.GetFull;

public sealed class QualityWithPools
{
    public QualityType QualityType { get; init; }
    public int? Rating { get; init; }
    
    // Attributes как List<KeyValuePair> — потом в сервисе можно в Dictionary
    public IReadOnlyCollection<KeyValuePair<AttributeKey, double>> Attributes { get; init; } 
        = Array.Empty<KeyValuePair<AttributeKey, double>>();
    
    public IReadOnlyCollection<SynthesisPoolData> SynthesisPools { get; init; } 
        = Array.Empty<SynthesisPoolData>();
}