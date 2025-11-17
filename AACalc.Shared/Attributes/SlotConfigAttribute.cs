namespace AACalc.Shared.Attributes;

[AttributeUsage(AttributeTargets.Field)]
public sealed class SlotConfigAttribute(int baseSlots, bool withCube, string? displayName = null) : Attribute
{
    public int BaseSlots { get; } = baseSlots;
    public bool WithCube { get; } = withCube;
    public string DisplayName { get; } = displayName ?? string.Empty;
}