using AACalc.Shared.Domain.Enums;

namespace AACalc.Domain.Entities;

public class Quality
{
    public Guid Id { get; init; } = Guid.NewGuid();
    
    public Guid ItemId { get; set; }
    public Item? Item { get; set; }

    public int? Rating { get; set; }
    
    public required QualityType QualityType { get; set; }

    public IEnumerable<AttributeKeyValue> AttributesKeyValue { get; set; } = new List<AttributeKeyValue>();
    
    public IEnumerable<SynthesisPool> SynthesisPools { get; set; } =  new List<SynthesisPool>();

}