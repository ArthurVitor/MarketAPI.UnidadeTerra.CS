using MarketAPI.UnidadeTerra.CS.Models;

namespace MarketAPI.UnidadeTerra.CS.Repositories.Interfaces;

public interface ISaleRepository
{
    Task<IEnumerable<Sale>> GetAllSales();

    Task<Sale?> GetSaleById(int saleId);

    Task<Sale> CreateSale(Sale sale, Market market);

    Task DeleteSale(int saleId);
}