using MarketAPI.UnidadeTerra.CS.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace MarketAPI.UnidadeTerra.CS.Repositories.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllProducts();

    Task<Product?> GetProductById(int productId);

    void PatchProduct(Product product, JsonPatchDocument<Product> patchDocument);
}