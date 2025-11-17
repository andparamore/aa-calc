using AACalc.Application.Extensions;
using AACalc.Shared.Domain.Enums;

namespace AACalc.Application.Helpers;

public class MaxCubeHelper
{
    public static int GetMaxCube(ItemSlotGroup group, ItemGroup? itemGroup)
    {
        var withCube = group.WithCube();
        return !withCube || itemGroup == null ? 0 : itemGroup.GetMaxCube();
    }
}