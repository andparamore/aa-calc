using AACalc.Shared.Domain.Enums;

namespace AACalc.Application.Extensions;

public static class ItemCategoryExtensions
{
    public static ItemSlotGroup GetSlotGroup(this ItemCategory category) => category switch
    {
        ItemCategory.PrimaryWeapon 
            or ItemCategory.TwoHandedWeapon
            or ItemCategory.OneHandedWeapon 
            or ItemCategory.ShootingWeapons
            or ItemCategory.Shield                      => ItemSlotGroup.Weapon,
        
        ItemCategory.MusicalInstrument                  => ItemSlotGroup.Musical,
        
        ItemCategory.Breastplate                        => ItemSlotGroup.PrimaryArmor,
        
        ItemCategory.Helmet or ItemCategory.Greaves     => ItemSlotGroup.SecondaryArmor,
        
        ItemCategory.Gloves or ItemCategory.Boots       => ItemSlotGroup.MinorArmor,
        
        ItemCategory.Belt or ItemCategory.Bracers       => ItemSlotGroup.LowTierArmor,
        
        ItemCategory.Necklace
            or ItemCategory.Earring 
            or ItemCategory.Ring                        => ItemSlotGroup.Jewelry,
        
        ItemCategory.Underpants                         => ItemSlotGroup.Underwear,
        
        _                                               => ItemSlotGroup.WithoutEngravings
    };
}