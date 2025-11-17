using AACalc.Shared.Domain.Enums;

namespace AACalc.Shared.Dtos.Models;

public sealed class ItemListDto
{
    public Guid Id { get; set; }
    
    public ItemGroup? ItemGroup { get; set; }
    
    public ItemType ItemType { get; set; }
    
    public ItemCategory ItemCategory  { get; set; }
    
    public string? ItemSubtype { get; set; } = string.Empty;
    
    public string Name { get; set; } = string.Empty;
    
    public string Icon { get; set; } = string.Empty;
    
    public int MaxCube { get; init; }
    
    public QualityModelDto? Quality { get; set; }
}