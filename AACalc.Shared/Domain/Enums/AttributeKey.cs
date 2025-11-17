namespace AACalc.Shared.Domain.Enums;

public enum AttributeKey : short
{
    // Основные статы (0–6)
    Strength = 0,
    Agility = 1,
    Intelligence = 2,
    Spirit = 3,
    Endurance = 4,
    
    // Защитные статы
    MagicResist = 5,
    Defense = 6,
    
    // Сила атаки → Damage (4 направления) — 7–10
    MeleeDamage = 7,           // 1) Сила атаки в ближнем бою
    RangedDamage = 8,          // 2) Сила атаки в дальнем бою
    SpellDamage = 9,           // 3) Сила заклинаний
    HealingDamage = 10,        // 4) Эффективность исцеления (Healing Power → Healing Damage)
    
    // Шанс крита (4 направления) — 11–14
    MeleeCritChance = 11,
    RangedCritChance = 12,
    SpellCritChance = 13,
    HealingCritChance = 14,
    
    // Сила крита (4 направления) — 15–18
    MeleeCritDamage = 15,      // Crit Power → Crit Damage
    RangedCritDamage = 16,
    SpellCritDamage = 17,
    HealingCritDamage = 18,
    
    // Доп. урон (4 направления) — 19–22
    MeleeBonusDamage = 19,
    RangedBonusDamage = 20,
    SpellBonusDamage = 21,
    HealingBonusDamage = 22
}