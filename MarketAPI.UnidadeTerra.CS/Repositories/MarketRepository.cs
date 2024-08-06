using MarketAPI.UnidadeTerra.CS.Context;
using MarketAPI.UnidadeTerra.CS.Models;
using MarketAPI.UnidadeTerra.CS.Repositories.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace MarketAPI.UnidadeTerra.CS.Repositories;

public class MarketRepository : IMarketRepository
{
    private readonly AppDbContext _context;

    public MarketRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Market> CreateMarketAsync(Market market)
    {
        var createEntity = await _context.Markets.AddAsync(market);
        
        await _context.SaveChangesAsync();

        return createEntity.Entity;
    }

    public async Task<ICollection<Market>> GetAllMarkets()
    {
        return await _context.Markets.Include(mk => mk.Sales).ThenInclude(sl => sl.Products).ToListAsync();
    }

    public async Task<Market?> GetMarketById(int marketId)
    {
        return await _context.Markets.Include(mk => mk.Sales).ThenInclude(sl => sl.Products).FirstOrDefaultAsync(mk => mk.MarketId == marketId);
    }

    public void PatchMarket(Market market, JsonPatchDocument<Market> patchDocument)
    {
        patchDocument.ApplyTo(market);

        _context.SaveChanges();
    }

    public async Task DeleteMarket(int marketId)
    {
        var market = await _context.Markets.FirstOrDefaultAsync(mk => mk.MarketId == marketId);
        if (market != null)
        {
            _context.Markets.Remove(market);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> Exists(int id)
    {
        return await _context.Markets.AnyAsync(mk => mk.MarketId == id);
    }
}