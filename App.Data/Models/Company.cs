using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace App.Data.Models;

[PrimaryKey("Id")]
public class Company
{
    public int Id { get; set; }
    [Display(Name = "Company Name")]
    [Required(ErrorMessage = "You must provide a Company Name")]
    public string CompanyName { get; set; } = null!;
    
    [Display(Name = "City")]
    [Required(ErrorMessage = "You must provide a City")]
    public string City { get; set; } = null!;
    
    [Display(Name = "State")]
    [Required(ErrorMessage = "You must provide a State")]
    public string State { get; set; } = null!;
    
    [Display(Name = "Address")]
    [Required(ErrorMessage = "You must provide a Address")]
    public string Address { get; set; } = null!;

    [Required(ErrorMessage = "You must provide a Phone Number")]
    [Display(Name ="Phone Number")]
    [DataType(DataType.PhoneNumber)]
    [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
    public string Phone { get; set; } = null!;

    public List<Employee> Employees { get; set; } = new();
    public List<Order> Orders { get; set; } = new();
}
