using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities;

[Table("Shippers")]
public class Shipper
{
    public int Id { get; set; }
    
    [Required]
    [Column(TypeName ="varchar(40)")]
    public string CompanyName { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(24)")]
    [DataType(DataType.PhoneNumber)]
    public string Mobile { get; set; }
    
}