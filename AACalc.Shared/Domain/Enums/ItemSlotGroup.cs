using AACalc.Shared.Attributes;

namespace AACalc.Shared.Domain.Enums;

public enum ItemSlotGroup
{
    [SlotConfig(6, true, "Оружие")]
    Weapon,

    [SlotConfig(3, false, "Музыкальный инструмент")]
    Musical,

    [SlotConfig(6, true, "Нагрудник")]
    PrimaryArmor,

    [SlotConfig(5, true, "Шлем, поножи")]
    SecondaryArmor,

    [SlotConfig(4, true, "Перчатки и сапоги")]
    MinorArmor,
    
    [SlotConfig(3, true, "Пояс и наручи")]
    LowTierArmor,

    [SlotConfig(2, false, "Украшения")]
    Jewelry,

    [SlotConfig(-100, false, "Без гравировок")]
    WithoutEngravings,

    [SlotConfig(3, false, "Нижнее белье")]
    Underwear
}