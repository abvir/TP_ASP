using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace App.Data.Models;

[PrimaryKey("Id")]
public class Company
{
   [Key] public int Id { get; set; }

    public string Name { get; set; } = null!;
    

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public List<Employee> Employees { get; set; } = new();
    public List<Order> Orders { get; set; } = new();
}
