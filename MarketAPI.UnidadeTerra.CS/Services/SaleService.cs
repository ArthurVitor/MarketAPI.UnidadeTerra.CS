using MarketAPI.UnidadeTerra.CS.Dtos.Sale;
using MarketAPI.UnidadeTerra.CS.Profiles;
using MarketAPI.UnidadeTerra.CS.Repositories.Interfaces;
using MarketAPI.UnidadeTerra.CS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MarketAPI.UnidadeTerra.CS.Services;

public class SaleService : ISaleService
{
    private readonly ISaleRepository _saleRepository;

    private readonly IMarketRepository _marketRepository;
    
    private readonly Mapper _mapper;

    public SaleService(Mapper mapper, ISaleRepository saleRepository, IMarketRepository marketRepository)
    {
        _mapper = mapper;
        _saleRepository = saleRepository;
        _marketRepository = marketRepository;
    }

    public async Task<IActionResult> GetAllSales()
    {
        try
        {
            var sales = await _saleRepository.GetAllSales();
            var saleDtos = sales.Select(_mapper.SaleToListSaleDto).ToList();

            return new OkObjectResult(saleDtos);
        }
        catch
        {
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<IActionResult> GetSaleById(int saleId)
    {
        var sale = await _saleRepository.GetSaleById(saleId);

        if (sale == null) return new NotFoundObjectResult($"No Sale with Id: {saleId}");

        return new OkObjectResult(_mapper.SaleToListSaleDto(sale));
    }

    public async Task<IActionResult> CreateSale(int marketId, CreateSaleDto createSaleDto)
    {
        var market = await _marketRepository.GetMarketById(marketId);
        if (market == null) return new NotFoundObjectResult($"There's no Market with Id {marketId}");

        var sale = _mapper.CreateSaleDtoToSale(createSaleDto);
        var createdSale = await _saleRepository.CreateSale(sale, market);

        return new OkObjectResult(_mapper.SaleToListSaleDto(createdSale));
    }

    public async Task<IActionResult> DeleteSale(int saleId)
    {
        await _saleRepository.DeleteSale(saleId);

        return new NoContentResult();
    }
}