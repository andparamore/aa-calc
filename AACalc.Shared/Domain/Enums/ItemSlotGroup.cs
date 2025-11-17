using AACalc.Shared.Attributes;

namespace AACalc.Shared.Domain.Enums;

public enum ItemSlotGroup
{
    [SlotConfig(6, "Оружие")]
    Weapon,

    [SlotConfig(6, "Нагрудник")]
    PrimaryArmor,

    [SlotConfig(5, "Шлем, поножи")]
    SecondaryArmor,

    [SlotConfig(4, "Перчатки и сапоги")]
    MinorArmor,
    
    [SlotConfig(3, "Пояс и наручи")]
    LowTierArmor,

    [SlotConfig(2, "Украшения")]
    Jewelry,

    [SlotConfig(-100, "Без гравировок")]
    WithoutEngravings,

    [SlotConfig(3, "Нижнее белье")]
    Underwear
}