using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities;

[Table("Products")]
public class Product
{
    
    public int Id { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(40)")]
    public string ProductName { get; set; }
    
    [Required]
    public decimal UnitPrice { get; set; }
    
    [Required]
    public int UnitsInStock { get; set; }
    
    public string? Description { get; set; }
    
    [ForeignKey(nameof(Category))]
    public int? CategoryId { get; set; }
    
    public Category? Category { get; set; }
    
    public ICollection<Review> Reviews { get; set; }
    
}