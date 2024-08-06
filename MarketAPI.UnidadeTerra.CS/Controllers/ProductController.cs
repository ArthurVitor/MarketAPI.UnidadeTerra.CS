using MarketAPI.UnidadeTerra.CS.Models;
using MarketAPI.UnidadeTerra.CS.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MarketAPI.UnidadeTerra.CS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        return await _productService.GetAllProducts();
    }

    [HttpGet("{productId}")]
    public async Task<IActionResult> GetProductById(int productId)
    {
        return await _productService.GetProductById(productId);
    }

    [HttpPatch("{productId}")]
    public async Task<IActionResult> PatchProduct(int productId, JsonPatchDocument<Product>? patchDocument)
    {
        return await _productService.PatchProduct(productId, patchDocument);
    }
}