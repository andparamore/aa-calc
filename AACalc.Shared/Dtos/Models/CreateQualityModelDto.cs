using AACalc.Shared.Domain.Enums;

namespace AACalc.Shared.Dtos.Models;

public class CreateQualityModelDto
{
    public QualityType QualityType { get; set; }
    
    public int? Rating { get; set; }
    public Dictionary<AttributeKey, double> Attributes { get; set; } = [];
    
    public IReadOnlyCollection<SynthesisPoolModel> SynthesisPools { get; set; } = new List<SynthesisPoolModel>();
}