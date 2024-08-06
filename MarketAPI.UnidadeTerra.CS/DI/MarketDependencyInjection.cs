using MarketAPI.UnidadeTerra.CS.Repositories;
using MarketAPI.UnidadeTerra.CS.Repositories.Interfaces;
using MarketAPI.UnidadeTerra.CS.Services;
using MarketAPI.UnidadeTerra.CS.Services.Interfaces;

namespace MarketAPI.UnidadeTerra.CS.DI;

public static class MarketDependencyInjection
{
    public static IServiceCollection AddMarket(this IServiceCollection services)
    {
        services.AddScoped<IMarketRepository, MarketRepository>();
        services.AddScoped<IMarketService, MarketService>();
        
        return services;
    }
}