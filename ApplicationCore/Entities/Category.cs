using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities;

public class Category
{
    public int Id { get; set; }
    
    [Required]
    [Column(TypeName ="varchar(50)")]
    public string Name { get; set; }
    
    public ICollection<Product> Products { get; set; }
}