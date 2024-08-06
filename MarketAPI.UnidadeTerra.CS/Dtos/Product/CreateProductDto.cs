namespace MarketAPI.UnidadeTerra.CS.Dtos.Product;

public class CreateProductDto
{
    public string Name { get; set; } = String.Empty;
    
    public double Price { get; set; }
}