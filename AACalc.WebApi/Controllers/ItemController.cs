using AACalc.Application.Item;
using AACalc.Shared.Domain.Enums;
using AACalc.Shared.Dtos.Models;
using AACalc.Shared.Dtos.Requests;
using AACalc.Shared.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AACalc.WebApi.Controllers;

[ApiController]
[Route("api/items")]
public class ItemController(IItemService itemService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateItem([FromBody] CreateItemRequest model)
    {
        try
        {
            await itemService.CreateItem(model);
            return NoContent();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpGet]
    public async Task<ActionResult<GetListResponse>> GetList([FromQuery] ItemCategory category, [FromQuery] ItemType? type, [FromQuery] QualityType quality, [FromQuery] ItemGroup? group)
    {
        try
        {
            var response = await itemService.GetListAsync(category, type, quality, group);
            return Ok(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GetItemByIdResponse>> GetItemById([FromRoute] Guid id, CancellationToken ct = default)
    {
        try
        {
            var item = await itemService.GetItemByIdAsync(id, ct);
            return item is null ? NotFound() : Ok(item);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}