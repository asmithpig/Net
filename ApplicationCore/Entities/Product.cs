using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities;

[Table("Products")]
public class Product
{
    
    public int Id { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(40")]
    public string ProductName { get; set; }
    
    public int? CategoryId { get; set; }
    
    public decimal? UnitPrice { get; set; }
    
    public short? UnitsInStock { get; set; }

    public short? UnitsOnOrder { get; set; }
    
}