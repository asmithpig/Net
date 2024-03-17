namespace ApplicationCore.Models.Response;

public class ProductResponseModel
{
    public int Id { get; set; }
    
    public string ProductName { get; set; }
    
    public decimal UnitPrice { get; set; }
    
    public string ImageUrl { get; set; }
}