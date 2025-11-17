using AACalc.Shared.Domain.Enums;

namespace AACalc.Domain.Entities;

public class SynthesisPool
{
    public Guid Id { get; init; } = Guid.NewGuid();
    
    public Guid QualityId { get; set; }        // FK
    public Quality Quality { get; set; } = null!;
    
    public int PoolId { get; set; }
    public required AttributeKey Key { get; set; }
    public double MinValue { get; set; }
    public double MaxValue { get; set; }
    
}