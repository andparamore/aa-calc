namespace AACalc.Shared.Attributes;

[AttributeUsage(AttributeTargets.Field)]
public sealed class SlotConfigAttribute : Attribute
{
    public int BaseSlots { get; }           // для Uncommon/Rare/Artifact
    public string DisplayName { get; }      // опционально

    public SlotConfigAttribute(int baseSlots, string? displayName = null)
    {
        BaseSlots = baseSlots;
        DisplayName = displayName ?? string.Empty;
    }
}