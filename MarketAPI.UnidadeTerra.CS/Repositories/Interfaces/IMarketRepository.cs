using MarketAPI.UnidadeTerra.CS.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace MarketAPI.UnidadeTerra.CS.Repositories.Interfaces;

public interface IMarketRepository
{
    Task<Market> CreateMarketAsync(Market market);

    Task<ICollection<Market>> GetAllMarkets();

    Task<Market?> GetMarketById(int marketId);

    void PatchMarket(Market market, JsonPatchDocument<Market> patchDocument);

    Task DeleteMarket(int marketId);
    
    Task<bool> Exists(int id);
}