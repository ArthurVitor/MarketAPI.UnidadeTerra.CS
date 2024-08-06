using MarketAPI.UnidadeTerra.CS.Repositories;
using MarketAPI.UnidadeTerra.CS.Repositories.Interfaces;
using MarketAPI.UnidadeTerra.CS.Services;
using MarketAPI.UnidadeTerra.CS.Services.Interfaces;

namespace MarketAPI.UnidadeTerra.CS.DI;

public static class ProductDependencyInjection
{
    public static IServiceCollection AddProducts(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductService, ProductService>();
            
        return services;
    }
}