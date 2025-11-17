using AACalc.Shared.Domain.Enums;

namespace AACalc.Domain.Entities;

public class Item
{
    public Guid Id { get; init; } = Guid.NewGuid();
    
    public ItemGroup ItemGroup { get; set; }
    
    public ItemType ItemType { get; set; }
    
    public ItemCategory ItemCategory { get; set; }
    
    public string ItemSubtype { get; set; } = string.Empty;
    
    public string Name { get; set; } = string.Empty;
    
    public string Icon { get; set; } = string.Empty;
    
    
    public IEnumerable<Quality> Qualities { get; init; } =  new List<Quality>();
}