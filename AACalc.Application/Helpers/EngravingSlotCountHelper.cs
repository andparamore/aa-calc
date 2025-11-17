using AACalc.Application.Extensions;
using AACalc.Shared.Domain.Enums;

namespace AACalc.Application.Helpers;

public static class EngravingSlotCountHelper
{
    public static int GetEngravingSlotCount(ItemSlotGroup group, QualityType quality)
    {
        var baseSlots = group.GetBaseSlots();
        var bonus = quality.GetSlotBonus();
        
        var result = baseSlots + bonus;
        return Math.Max(0, result);
    }
}