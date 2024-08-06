namespace MarketAPI.UnidadeTerra.CS.Models;

public class Market
{
    public int MarketId { get; set; }
    public string Name { get; set; } = String.Empty;

    public ICollection<Sale> Sales { get; set; } = new List<Sale>();
}