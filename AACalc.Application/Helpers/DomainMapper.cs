using AACalc.Domain.Entities;
using AACalc.Shared.Domain.Enums;
using AACalc.Shared.Dtos.Models;

namespace AACalc.Application.Helpers;

public static class DomainMapper
{
    public static Quality ToQuality(this CreateQualityModelDto qualityModelDto)
    {
        var quality = new Quality
        {
            QualityType = qualityModelDto.QualityType,
            Rating = qualityModelDto.Rating,
            AttributesKeyValue = qualityModelDto.Attributes.Select(ToAttributeKeyValue).ToList(),
            SynthesisPools = qualityModelDto.SynthesisPools.SelectMany(ToSynthesisPools).ToList(),
        };
        
        return quality;
    }

    public static AttributeKeyValue ToAttributeKeyValue(this KeyValuePair<AttributeKey, double> attributeKeyValue)
    {
        var attribute = new AttributeKeyValue
        {
            Key = attributeKeyValue.Key,
            Value = attributeKeyValue.Value
        };
        
        return attribute;
    }

    public static List<SynthesisPool> ToSynthesisPools(this SynthesisPoolModel synthesisPoolModel)
    {
        var fallbackPoolId = synthesisPoolModel.PoolId;

        var list = new List<SynthesisPool>(synthesisPoolModel.Ranges.Count);

        foreach (var (key, range) in synthesisPoolModel.Ranges)
        {
            list.Add(new SynthesisPool
            {
                PoolId    = fallbackPoolId,
                Key       = key,
                MinValue  = range.Min,
                MaxValue  = range.Max
            });
        }

        return list;
    }
}