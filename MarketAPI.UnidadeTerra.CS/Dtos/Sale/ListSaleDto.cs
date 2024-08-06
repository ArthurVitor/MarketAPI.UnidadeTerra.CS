using MarketAPI.UnidadeTerra.CS.Dtos.Product;

namespace MarketAPI.UnidadeTerra.CS.Dtos.Sale;

public class ListSaleDto
{
    public int Id { get; set; }
    
    public DateTime SaleTime { get; set; }

    public ICollection<ListProductDto> ProductDtos { get; set; } = new List<ListProductDto>();
}