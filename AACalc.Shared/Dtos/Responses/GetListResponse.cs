using AACalc.Shared.Dtos.Models;

namespace AACalc.Shared.Dtos.Responses;

public class GetListResponse
{
    public IReadOnlyCollection<ItemListDto> Items { get; set; } = new List<ItemListDto>();
    public int TotalCount { get; set; }
}