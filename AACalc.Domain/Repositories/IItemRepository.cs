using AACalc.Domain.Entities;
using AACalc.Shared.Domain.Enums;
using AACalc.Shared.Dtos.Models;
using AACalc.Shared.Dtos.Projections;
using AACalc.Shared.Dtos.Projections.GetFull;

namespace AACalc.Domain.Repositories;

public interface IItemRepository
{
    Task Add(Item item);

    Task<IReadOnlyCollection<ItemWithQualities>> GetAllWithQualities(
        ItemCategory category,
        ItemType? type,
        ItemGroup? itemGroup,
        CancellationToken ct);

    Task<GetFullItemProjection?> GetFullByIdAsync(Guid id, CancellationToken ct = default);
}