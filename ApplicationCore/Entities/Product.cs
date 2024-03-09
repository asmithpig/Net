using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities;

[Table("Products")]
public class Product
{
    
    public int Id { get; set; }
    
    [Required]
    public string ProductName { get; set; }
    
}