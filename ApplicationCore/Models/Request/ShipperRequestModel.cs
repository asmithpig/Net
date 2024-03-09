using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models.Request;

public class ShipperRequestModel
{
    
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Company Name is required")]
    public string CompanyName { get; set; }
    
    [Required(ErrorMessage = "Phone Number is required")]
    [DataType(DataType.PhoneNumber)]
    public string Mobile { get; set; }
    
}