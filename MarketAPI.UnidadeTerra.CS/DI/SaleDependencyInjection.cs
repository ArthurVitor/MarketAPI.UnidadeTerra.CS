using MarketAPI.UnidadeTerra.CS.Repositories;
using MarketAPI.UnidadeTerra.CS.Repositories.Interfaces;
using MarketAPI.UnidadeTerra.CS.Services;
using MarketAPI.UnidadeTerra.CS.Services.Interfaces;

namespace MarketAPI.UnidadeTerra.CS.DI;

public static class SaleDependencyInjection
{
    public static IServiceCollection AddSales(this IServiceCollection services)
    {
        services.AddScoped<ISaleRepository, SaleRepository>();
        services.AddScoped<ISaleService, SaleService>();

        return services;
    }
}