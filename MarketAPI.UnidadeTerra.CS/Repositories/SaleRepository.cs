using MarketAPI.UnidadeTerra.CS.Context;
using MarketAPI.UnidadeTerra.CS.Models;
using MarketAPI.UnidadeTerra.CS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MarketAPI.UnidadeTerra.CS.Repositories;

public class SaleRepository : ISaleRepository
{
    private readonly AppDbContext _context;
    
    public SaleRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Sale>> GetAllSales()
    {
        var sales = await _context.Sales.Include(sl => sl.Products).ToListAsync();

        return sales;
    }

    public async Task<Sale?> GetSaleById(int saleId)
    {
        return await _context.Sales.Include(sl => sl.Products).FirstOrDefaultAsync(sl => sl.SaleId == saleId);
    }

    public async Task<Sale> CreateSale(Sale sale, Market market)
    {
        var createdSale = await _context.Sales.AddAsync(sale);
        market.Sales.Add(sale);
        
        await _context.SaveChangesAsync();

        return createdSale.Entity;
    }

    public async Task DeleteSale(int saleId)
    {
        var sale = await _context.Sales.FirstOrDefaultAsync(sl => sl.SaleId == saleId);

        if (sale != null)
        {
            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync();
        }
    }
}