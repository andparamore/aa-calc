using AACalc.Shared.Domain.Enums;

namespace AACalc.Application.Extensions;

public static class QualityTypeExtensions
{
    public static int GetSlotBonus(this QualityType quality) => quality switch
    {
        QualityType.Uncommon or QualityType.Rare or QualityType.Ancient or QualityType.Heroic or QualityType.Unique or QualityType.Artifact => 0,
        QualityType.Wonder or QualityType.Epic or QualityType.Legendary => 1,
        QualityType.Mythic => 2,
        QualityType.Arche => 3,
        _ => -100
    };
}