using System.ComponentModel.DataAnnotations;

namespace App.Data.Models;

public class Order
{
    public int Id { get; set; }

    [Display(Name = "Order Date")]
    [Required(ErrorMessage = "You must provide a Order Date")]
    public DateTime Date { get; set; }

    [Display(Name = "Sore City")]
    [Required(ErrorMessage = "You must provide a Sore City")]
    public string City { get; set; } = null!;


    public int CompanyId { get; set; }
    public Company? Company { get; set; }
}
