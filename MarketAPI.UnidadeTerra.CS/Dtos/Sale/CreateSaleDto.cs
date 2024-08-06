using MarketAPI.UnidadeTerra.CS.Dtos.Product;

namespace MarketAPI.UnidadeTerra.CS.Dtos.Sale;

public class CreateSaleDto
{
    public ICollection<CreateProductDto> ProductDtos { get; set; } = new List<CreateProductDto>();
}