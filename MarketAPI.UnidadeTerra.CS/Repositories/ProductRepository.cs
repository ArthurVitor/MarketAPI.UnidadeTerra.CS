using MarketAPI.UnidadeTerra.CS.Context;
using MarketAPI.UnidadeTerra.CS.Models;
using MarketAPI.UnidadeTerra.CS.Repositories.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace MarketAPI.UnidadeTerra.CS.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product?> GetProductById(int productId)
    {
        return await _context.Products.FirstOrDefaultAsync(pr => pr.ProductId == productId);
    }

    public void PatchProduct(Product product, JsonPatchDocument<Product> patchDocument)
    {
        patchDocument.ApplyTo(product);
        _context.SaveChangesAsync();
    }
}