using System.Reflection;
using AACalc.Shared.Attributes;
using AACalc.Shared.Domain.Enums;

namespace AACalc.Application.Extensions;

public static class ItemSlotGroupExtensions
{
    public static int GetBaseSlots(this ItemSlotGroup group)
    {
        var field = group.GetType().GetField(group.ToString());
        var attribute = field?.GetCustomAttribute<SlotConfigAttribute>();
        return attribute?.BaseSlots ?? -100;
    }

    public static string GetDisplayName(this ItemSlotGroup group)
    {
        var field = group.GetType().GetField(group.ToString());
        var attribute = field?.GetCustomAttribute<SlotConfigAttribute>();
        return attribute?.DisplayName ?? group.ToString();
    }
    
    public static bool WithCube(this ItemSlotGroup group)
    {
        var field = group.GetType().GetField(group.ToString());
        var attribute = field?.GetCustomAttribute<SlotConfigAttribute>();
        return attribute?.WithCube ?? false;
    }
}