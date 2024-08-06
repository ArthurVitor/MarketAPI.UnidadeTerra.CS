using MarketAPI.UnidadeTerra.CS.Dtos.Market;
using MarketAPI.UnidadeTerra.CS.Dtos.Product;
using MarketAPI.UnidadeTerra.CS.Dtos.Sale;
using MarketAPI.UnidadeTerra.CS.Models;

namespace MarketAPI.UnidadeTerra.CS.Profiles;

public class Mapper
{
    public ListMarketDto MarketToListMarketDto(Market market)
    {
        return new ListMarketDto()
        {
            Id = market.MarketId,
            Name = market.Name,
            ListSaleDtos = market.Sales.Select(SaleToListSaleDto).ToList()
        };
    }

    public Market CreateMarketDtoToMarket(CreateMarketDto marketDto)
    {
        return new Market()
        {
            Name = marketDto.Name
        };
    }
    
    public ListSaleDto SaleToListSaleDto(Sale sale)
    {
        return new ListSaleDto()
        {
            Id = sale.SaleId,
            SaleTime = sale.SaleTime,
            ProductDtos = sale.Products.Select(ProductToListProductDto).ToList()
        };
    }

    public ListProductDto ProductToListProductDto(Product product)
    {
        return new ListProductDto()
        {
            Id = product.ProductId,
            Name = product.Name,
            Price = product.Price
        };
    }

    public Product CreateProductDtoToProduct(CreateProductDto productDto)
    {
        return new Product()
        {
            Name = productDto.Name,
            Price = productDto.Price,
        };
    }

    public Sale CreateSaleDtoToSale(CreateSaleDto createSaleDto)
    {
        return new Sale()
        {
            SaleTime = DateTime.Now.ToUniversalTime(),
            Products = createSaleDto.ProductDtos.Select(CreateProductDtoToProduct).ToList()
        };
    }
}