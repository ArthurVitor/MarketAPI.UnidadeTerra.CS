using MarketAPI.UnidadeTerra.CS.Models;
using MarketAPI.UnidadeTerra.CS.Profiles;
using MarketAPI.UnidadeTerra.CS.Repositories.Interfaces;
using MarketAPI.UnidadeTerra.CS.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MarketAPI.UnidadeTerra.CS.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    private readonly Mapper _mapper;
    
    public ProductService(IProductRepository productRepository, Mapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _productRepository.GetAllProducts();

        return new OkObjectResult(products.Select(_mapper.ProductToListProductDto));
    }

    public async Task<IActionResult> GetProductById(int productId)
    {
        var product = await _productRepository.GetProductById(productId);

        if (product == null) return new NotFoundObjectResult($"No Product with Id {productId}");
        
        return new OkObjectResult(_mapper.ProductToListProductDto(product));
    }

    public async Task<IActionResult> PatchProduct(int productId, JsonPatchDocument<Product>? patchDocument)
    {
        try
        {
            var product = await _productRepository.GetProductById(productId);

            if (product == null) return new NotFoundObjectResult($"Product with Id {productId} doesn't exist");

            if (patchDocument == null) return new BadRequestObjectResult("Patch Object can't be null");

            _productRepository.PatchProduct(product, patchDocument);

            return new NoContentResult();
        }
        catch
        {
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
}