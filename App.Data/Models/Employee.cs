namespace App.Data.Models;

public class Employee
{
    public int Id { get; set; }


    public string FirstName { get; set; } = null!;


    public string LastName { get; set; } = null!;


    public Title Title { get; set; }


    public DateTime Birthday { get; set; }


    public string Position { get; set; } = null!;

    public int CompanyId { get; set; }
    public Company? Company { get; set; }

    public List<Note> Notes { get; set; } = new();

    public string FullName => $"{FirstName} {LastName}";
   
}
