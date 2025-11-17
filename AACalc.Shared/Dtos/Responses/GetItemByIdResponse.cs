using AACalc.Shared.Domain.Enums;
using AACalc.Shared.Dtos.Models;

namespace AACalc.Shared.Dtos.Responses;

public sealed class GetItemByIdResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public string Icon { get; init; } = null!;
    public ItemType ItemType { get; init; }
    public ItemGroup? ItemGroup { get; init; }
    public string? ItemSubtype { get; init; }
    public ItemCategory ItemCategory { get; init; }
    public int MaxCube { get; init; }
    public IReadOnlyCollection<QualityModelDto> AllQualities { get; init; } = Array.Empty<QualityModelDto>();
}