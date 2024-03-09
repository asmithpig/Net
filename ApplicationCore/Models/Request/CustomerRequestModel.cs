using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Models.Request;

public class CustomerRequestModel
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "First Name is required")]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage = "Last Name is required")]
    public string LastName { get; set; }
    
    [Required(ErrorMessage = "Phone Number is required")]
    [MaxLength(24, ErrorMessage = "The maximum length of Mobile Number is 24")]
    [DataType(DataType.PhoneNumber)]
    public string Mobile { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Location is required")]
    public string Location { get; set; }
}