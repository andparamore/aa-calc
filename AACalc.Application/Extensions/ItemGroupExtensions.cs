using AACalc.Shared.Domain.Enums;

namespace AACalc.Application.Extensions;

public static class ItemGroupExtensions
{
    public static int GetMaxCube(this ItemGroup group) => group switch
    {
        ItemGroup.Erenor or ItemGroup.Mythic => 35,
        _ => 30
    };
}