using MarketAPI.UnidadeTerra.CS.Dtos.Sale;

namespace MarketAPI.UnidadeTerra.CS.Dtos.Market;

public class ListMarketDto
{
    public int Id { get; set; }
    
    public string Name { get; set; } = String.Empty;

    public ICollection<ListSaleDto> ListSaleDtos { get; set; } = new List<ListSaleDto>();
}