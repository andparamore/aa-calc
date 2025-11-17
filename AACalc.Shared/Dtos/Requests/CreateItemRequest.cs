using AACalc.Shared.Domain.Enums;
using AACalc.Shared.Dtos.Models;

namespace AACalc.Shared.Dtos.Requests;

public class CreateItemRequest
{
    public ItemGroup ItemGroup { get; set; }
    
    public ItemType ItemType { get; set; }
    
    public ItemCategory ItemCategory  { get; set; }
    
    public string ItemSubtype { get; set; } = string.Empty;
    
    public string Name { get; set; } = string.Empty;
    
    public string Icon { get; set; } = string.Empty;
    
    public IList<CreateQualityModelDto> QualityModels { get; set; }  = new List<CreateQualityModelDto>();
}