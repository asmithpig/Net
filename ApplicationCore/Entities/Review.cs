using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities;

public class Review
{
    public int Id { get; set; }
    
    public string ReviewText { get; set; }
    
    [Range(1,5)]
    public int Rating { get; set; }
    
    [ForeignKey(nameof(Reviewer))]
    public int ReviewerId { get; set; }
    public Customer Reviewer { get; set; }
    
    [ForeignKey(nameof(Product))]
    public int ProductId { get; set; }
    public Product Product { get; set; }
}