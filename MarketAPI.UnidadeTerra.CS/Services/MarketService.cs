using MarketAPI.UnidadeTerra.CS.Dtos.Market;
using MarketAPI.UnidadeTerra.CS.Models;
using MarketAPI.UnidadeTerra.CS.Profiles;
using MarketAPI.UnidadeTerra.CS.Repositories.Interfaces;
using MarketAPI.UnidadeTerra.CS.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MarketAPI.UnidadeTerra.CS.Services;

public class MarketService : IMarketService
{
    private readonly IMarketRepository _marketRepository;

    private readonly Mapper _mapper;
    
    public MarketService(IMarketRepository marketRepository, Mapper mapper)
    {
        _marketRepository = marketRepository;
        _mapper = mapper;
    }

    public async Task<IActionResult> CreateMarket(CreateMarketDto marketDto)
    {
        try
        {
            var mappedMarket = _mapper.CreateMarketDtoToMarket(marketDto);
            var createMarket = await _marketRepository.CreateMarketAsync(mappedMarket);

            return new OkObjectResult(_mapper.MarketToListMarketDto(createMarket));
        }
        catch
        {
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<IActionResult> GetAllMarkets()
    {
        try
        {
            var markets = await _marketRepository.GetAllMarkets();
            var marketDtos = markets.Select(_mapper.MarketToListMarketDto);

            return new OkObjectResult(marketDtos);
        }
        catch
        {
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<IActionResult> GetMarketById(int marketId)
    {
        var market = await _marketRepository.GetMarketById(marketId);
        
        if (market == null) return new NotFoundObjectResult($"No Market with Id {marketId}");
        
        return new OkObjectResult(_mapper.MarketToListMarketDto(market));
    }

    public async Task<IActionResult> PatchMarket(int marketId, JsonPatchDocument<Market>? patchDoc)
    {
        var market = await _marketRepository.GetMarketById(marketId);

        if (market is null)
        {
            return new NotFoundObjectResult($"No Market with Id {marketId}");
        }

        if (patchDoc == null)
        {
            return new BadRequestObjectResult("Patch Object can't be null");
        }

        try
        {
            _marketRepository.PatchMarket(market, patchDoc);

            return new NoContentResult();
        }
        catch
        {
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<IActionResult> DeleteMarket(int marketId)
    {
        await _marketRepository.DeleteMarket(marketId);
        return new NoContentResult();
    }
}