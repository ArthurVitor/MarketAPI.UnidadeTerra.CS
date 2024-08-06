namespace MarketAPI.UnidadeTerra.CS.Models;

public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; } = String.Empty;
    public double Price { get; set; }
    
    public int SaleId { get; set; }
    public Sale Sale { get; set; } = new Sale();
}