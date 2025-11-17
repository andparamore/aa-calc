using AACalc.Shared.Domain.Enums;
using AACalc.Shared.Dtos.Models;
using AACalc.Shared.Dtos.Projections;

namespace AACalc.Application.Helpers;

public static class QualitySelector
{
    public static QualityModelDto? SelectBest(
        IEnumerable<QualityData> available,
        QualityType requested,
        ItemSlotGroup slotGroup)
    {
        var list = available.ToList();
        if (!list.Any()) return null;

        var requestedValue = (short)requested;

        // Точное совпадение
        var exact = list.FirstOrDefault(q => q.QualityType == requested);
        if (exact != null)
            return Map(exact, slotGroup);

        // Ближайшее выше или равное
        var higher = list
            .Where(q => (short)q.QualityType >= requestedValue)
            .MinBy(q => (short)q.QualityType);

        // Если нет выше — берём максимальное
        return Map(higher ?? list.MaxBy(q => (short)q.QualityType)!, slotGroup);
    }

    private static QualityModelDto Map(QualityData q, ItemSlotGroup slotGroup)
    {
        return new QualityModelDto
        {
            QualityType = q.QualityType,
            Rating = q.Rating,
            EngravingSlotCount = EngravingSlotCountHelper.GetSynthesisSlots(category, q.QualityType),
            Attributes = q.Attributes.ToDictionary(kv => kv.Key, kv => kv.Value),
            SynthesisPools = new List<SynthesisPoolModel>()
        };
    }
}