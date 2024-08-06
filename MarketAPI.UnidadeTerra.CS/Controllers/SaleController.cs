using MarketAPI.UnidadeTerra.CS.Dtos.Sale;
using MarketAPI.UnidadeTerra.CS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MarketAPI.UnidadeTerra.CS.Controllers;


[ApiController]
[Route("api/[controller]")]
public class SaleController : ControllerBase
{
    private readonly ISaleService _saleService;

    public SaleController(ISaleService saleService)
    {
        _saleService = saleService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSales()
    {
        return await _saleService.GetAllSales();
    }

    [HttpGet("{saleId}")]
    public async Task<IActionResult> GetSaleById(int saleId)
    {
        return await _saleService.GetSaleById(saleId);
    }

    [HttpPost("addSaleToMarket/{marketId}")]
    public async Task<IActionResult> AddSaleToMarket(int marketId, [FromBody] CreateSaleDto createSaleDto)
    {
        return await _saleService.CreateSale(marketId, createSaleDto);
    }

    [HttpDelete("{saleId}")]
    public async Task<IActionResult> DeleteSale(int saleId)
    {
        return await _saleService.DeleteSale(saleId);
    }
}