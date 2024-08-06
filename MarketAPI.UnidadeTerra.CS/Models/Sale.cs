namespace MarketAPI.UnidadeTerra.CS.Models;

public class Sale
{
    public int SaleId { get; set; }
    public DateTime SaleTime { get; set; } = DateTime.Now;
    
    public int MarketId { get; set; }
    public Market Market { get; set; } = new Market();

    public ICollection<Product> Products { get; set; } = new List<Product>();
}