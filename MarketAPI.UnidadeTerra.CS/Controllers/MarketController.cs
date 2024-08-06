using MarketAPI.UnidadeTerra.CS.Dtos.Market;
using MarketAPI.UnidadeTerra.CS.Models;
using MarketAPI.UnidadeTerra.CS.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MarketAPI.UnidadeTerra.CS.Controllers;


[ApiController]
[Route("api/[controller]")]
public class MarketController : ControllerBase
{
    private readonly IMarketService _marketService;

    public MarketController(IMarketService marketService)
    {
        _marketService = marketService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateMarket([FromBody] CreateMarketDto marketDto)
    {
        return await _marketService.CreateMarket(marketDto);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllMarkets()
    {
        return await _marketService.GetAllMarkets();
    }

    [HttpGet("{marketId}")]
    public async Task<IActionResult> GetMarketById(int marketId)
    {
        return await _marketService.GetMarketById(marketId);
    }

    [HttpPatch]
    public async Task<IActionResult> PatchMarket(int marketId, JsonPatchDocument<Market> patchDocument)
    {
        return await _marketService.PatchMarket(marketId, patchDocument);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteMarket(int marketId)
    {
        return await _marketService.DeleteMarket(marketId);
    }
}