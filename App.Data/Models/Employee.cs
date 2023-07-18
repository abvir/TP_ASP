using System.ComponentModel.DataAnnotations;

namespace App.Data.Models;

public class Employee
{
    public int Id { get; set; }

    [Display(Name = "FirstName")]
    [Required(ErrorMessage = "You must provide a FirstName")]
    public string FirstName { get; set; } = null!;

    [Display(Name = "LastName")]
    [Required(ErrorMessage = "You must provide a LastName")]
    public string LastName { get; set; } = null!;

    [Display(Name = "Title")]
    [Required(ErrorMessage = "You must provide a Title")]
    public Title Title { get; set; }

    [Display(Name = "Birthday")]
    [Required(ErrorMessage = "You must provide a Birthday")]
    public DateTime Birthday { get; set; }

    [Display(Name = "Position")]
    [Required(ErrorMessage = "You must provide a Position")]
    public string Position { get; set; } = null!;

    public int CompanyId { get; set; }
    public Company? Company { get; set; }

    public List<Note> Notes { get; set; } = new();

   
}
