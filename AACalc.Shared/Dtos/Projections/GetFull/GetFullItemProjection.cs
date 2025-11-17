using AACalc.Shared.Domain.Enums;

namespace AACalc.Shared.Dtos.Projections.GetFull;

public class GetFullItemProjection
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public string Icon { get; init; } = null!;
    public ItemType ItemType { get; init; }
    public ItemGroup? ItemGroup { get; init; }
    public string? ItemSubtype { get; init; }
    public ItemCategory ItemCategory { get; init; }
    public IReadOnlyCollection<QualityWithPools> Qualities { get; init; } = Array.Empty<QualityWithPools>();
}