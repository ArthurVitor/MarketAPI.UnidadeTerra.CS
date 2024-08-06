using MarketAPI.UnidadeTerra.CS.Dtos.Market;
using MarketAPI.UnidadeTerra.CS.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MarketAPI.UnidadeTerra.CS.Services.Interfaces;

public interface IMarketService
{
    Task<IActionResult> CreateMarket(CreateMarketDto marketDto);

    Task<IActionResult> GetAllMarkets();

    Task<IActionResult> GetMarketById(int marketId);

    Task<IActionResult> PatchMarket(int marketId, JsonPatchDocument<Market>? patchDoc);

    Task<IActionResult> DeleteMarket(int marketId);
}