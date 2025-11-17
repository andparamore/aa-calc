using AACalc.Application.Extensions;
using AACalc.Shared.Domain.Enums;

namespace AACalc.Application.Helpers;

public class MaxCubeHelper
{
    public static int GetSynthesisSlots(ItemSlotGroup group, QualityType quality)
    {
        var baseSlots = group.GetBaseSlots();
        var bonus = quality.GetSlotBonus();
        
        var result = baseSlots + bonus;
        return Math.Max(0, result);
    }
}