using AACalc.Shared.Domain.Enums;
using AACalc.Shared.Dtos.Models;
using AACalc.Shared.Dtos.Requests;
using AACalc.Shared.Dtos.Responses;

namespace AACalc.Application.Item;

public interface IItemService
{
    Task CreateItem(CreateItemRequest model, CancellationToken ct = default);
    Task<GetListResponse> GetListAsync(ItemCategory category, ItemType? type, QualityType qualityType, ItemGroup? itemGroup, CancellationToken ct = default);
    Task<GetItemByIdResponse?> GetItemByIdAsync(Guid id, CancellationToken ct = default);
}