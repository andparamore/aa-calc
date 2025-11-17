using AACalc.Domain.Entities;
using AACalc.Domain.Repositories;
using AACalc.Infrastructure.Context;
using AACalc.Shared.Domain.Enums;
using AACalc.Shared.Dtos.Models;
using AACalc.Shared.Dtos.Projections;
using AACalc.Shared.Dtos.Projections.GetFull;
using Microsoft.EntityFrameworkCore;

namespace AACalc.Infrastructure.Repositories;

public class ItemRepository : IItemRepository
{
    private readonly CoreContext _context;
    
    public ItemRepository(CoreContext context)
    {
        _context = context;
    }
    
    public async Task Add(Item item)
    {
        await _context.Items.AddAsync(item);
    }

    public async Task<IReadOnlyCollection<ItemWithQualities>> GetAllWithQualities(
        ItemCategory category,
        ItemType? type,
        ItemGroup? itemGroup,
        CancellationToken ct)
    {
        var data = await _context.Items
            .AsSplitQuery()
            .Where(i => i.ItemCategory == category &&
                        (!type.HasValue || i.ItemType == type) &&
                        (!itemGroup.HasValue || i.ItemGroup == itemGroup))
            .Select(i => new ItemWithQualities
            {
                Id = i.Id,
                Name = i.Name,
                Icon = i.Icon,
                ItemType = i.ItemType,
                ItemGroup = i.ItemGroup,
                ItemSubtype = i.ItemSubtype,
                ItemCategory = i.ItemCategory,
                Qualities = i.Qualities.Select(q => new QualityData
                {
                    QualityType = q.QualityType,
                    Rating = q.Rating,
                    Attributes = q.AttributesKeyValue
                        .Select(a => new KeyValuePair<AttributeKey, double>(a.Key, a.Value))
                        .ToList()
                }).ToList()
            })
            .ToListAsync(ct);

        return data.AsReadOnly();
    }
    
    public async Task<GetFullItemProjection?> GetFullByIdAsync(Guid id, CancellationToken ct = default)
    {
        return await _context.Items
            .Where(i => i.Id == id)
            .Select(i => new GetFullItemProjection
            {
                Id = i.Id,
                Name = i.Name,
                Icon = i.Icon,
                ItemType = i.ItemType,
                ItemGroup = i.ItemGroup,
                ItemSubtype = i.ItemSubtype,
                ItemCategory = i.ItemCategory,
                Qualities = i.Qualities.Select(q => new QualityWithPools
                {
                    QualityType = q.QualityType,
                    Rating = q.Rating,
                    Attributes = q.AttributesKeyValue
                        .Select(a => new KeyValuePair<AttributeKey, double>(a.Key, a.Value))
                        .ToList(),
                    SynthesisPools = q.SynthesisPools.Select(sp => new SynthesisPoolData
                    {
                        PoolId = sp.PoolId,
                        Key = sp.Key,
                        MinValue = sp.MinValue,
                        MaxValue = sp.MaxValue
                    }).ToList()
                }).ToList()
            })
            .AsSplitQuery()
            .FirstOrDefaultAsync(ct);
    }
}