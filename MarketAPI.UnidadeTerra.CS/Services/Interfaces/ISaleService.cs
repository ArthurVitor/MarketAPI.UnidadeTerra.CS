using MarketAPI.UnidadeTerra.CS.Dtos.Sale;
using Microsoft.AspNetCore.Mvc;

namespace MarketAPI.UnidadeTerra.CS.Services.Interfaces;

public interface ISaleService
{
    Task<IActionResult> GetAllSales();

    Task<IActionResult> GetSaleById(int saleId);

    Task<IActionResult> CreateSale(int marketId, CreateSaleDto createSaleDto);

    Task<IActionResult> DeleteSale(int saleId);
}