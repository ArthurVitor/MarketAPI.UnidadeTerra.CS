using MarketAPI.UnidadeTerra.CS.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MarketAPI.UnidadeTerra.CS.Services.Interfaces;

public interface IProductService
{
    Task<IActionResult> GetAllProducts();

    Task<IActionResult> GetProductById(int productId);

    Task<IActionResult> PatchProduct(int productId, JsonPatchDocument<Product>? patchDocument);
}