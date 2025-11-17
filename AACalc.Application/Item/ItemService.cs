using AACalc.Application.Extensions;
using AACalc.Application.Helpers;
using AACalc.Domain.Repositories;
using AACalc.Infrastructure.Uow;
using AACalc.Shared.Domain.Enums;
using AACalc.Shared.Dtos.Models;
using AACalc.Shared.Dtos.Requests;
using AACalc.Shared.Dtos.Responses;

namespace AACalc.Application.Item;

public class ItemService(IUnitOfWork unitOfWork, IItemRepository itemRepository) : IItemService
{
    public async Task CreateItem(CreateItemRequest model, CancellationToken ct = default)
    {
        var itemModel = new Domain.Entities.Item
        {
            Name = model.Name,
            Icon = model.Icon,
            ItemType = model.ItemType,
            ItemGroup = model.ItemGroup,
            ItemSubtype = model.ItemSubtype,
            ItemCategory = model.ItemCategory,
            Qualities = model.QualityModels.Select(x => x.ToQuality()).ToList()
        };
        
        await itemRepository.Add(itemModel);
        await unitOfWork.SaveChangesAsync(ct);
    }

    public async Task<GetListResponse> GetListAsync(
        ItemCategory category,
        ItemType? type,
        QualityType requestedQuality,
        ItemGroup? itemGroup,
        CancellationToken ct = default)
    {
        var rawItems = await itemRepository.GetAllWithQualities(category, type, itemGroup, ct);

        var itemModels = rawItems
            .Select(item =>
            {
                var itemSlotGroup = item.ItemCategory.GetSlotGroup();
                    
                return new ItemListDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Icon = item.Icon,
                    ItemType = item.ItemType,
                    ItemGroup = item.ItemGroup,
                    ItemSubtype = item.ItemSubtype,
                    ItemCategory = item.ItemCategory,
                    MaxCube = ,
                    Quality = QualitySelector.SelectBest(item.Qualities, requestedQuality, itemSlotGroup)
                };
            })
            .Where(dto => dto.Quality != null)
            .ToList();

        return new GetListResponse { Items = itemModels, TotalCount = itemModels.Count };
    }
    
    public async Task<GetItemByIdResponse?> GetItemByIdAsync(Guid id, CancellationToken ct = default)
    {
        var data = await itemRepository.GetFullByIdAsync(id, ct);
        if (data is null)
            return null;
        
        var slotGroup = data.ItemCategory.GetSlotGroup();

        var qualities = data.Qualities.Select(q => new QualityModelDto
        {
            QualityType = q.QualityType,
            Rating = q.Rating,
            EngravingSlotCount = EngravingSlotCountHelper.GetEngravingSlotCount(slotGroup, q.QualityType),
            
            Attributes = q.Attributes.ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value
            ),
            
            SynthesisPools = q.SynthesisPools
                .GroupBy(sp => sp.PoolId)
                .Select(g => new SynthesisPoolModel
                {
                    PoolId = g.Key,
                    Ranges = g.ToDictionary(
                        sp => sp.Key,
                        sp => new SynthesisRangeModel
                        {
                            Min = sp.MinValue,
                            Max = sp.MaxValue
                        }
                    )
                })
                .OrderBy(p => p.PoolId) 
                .ToList()
        }).ToList();

        return new GetItemByIdResponse
        {
            Id = data.Id,
            Name = data.Name,
            Icon = data.Icon,
            ItemType = data.ItemType,
            ItemGroup = data.ItemGroup,
            ItemSubtype = data.ItemSubtype,
            ItemCategory = data.ItemCategory,
            AllQualities = qualities
        };
    }
}