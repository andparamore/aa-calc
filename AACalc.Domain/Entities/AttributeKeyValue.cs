using AACalc.Shared.Domain.Enums;

namespace AACalc.Domain.Entities;

public class AttributeKeyValue
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public Guid QualityId { get; set; }        // FK
    public Quality Quality { get; set; } = null!;
    
    public AttributeKey Key { get; set; }
    public double Value { get; set; }
}