using System.ComponentModel.DataAnnotations;

namespace App.Data.Models;

public class Order
{
    public int Id { get; set; }


    public DateTime Date { get; set; }

    public string City { get; set; } = null!;


    public int CompanyId { get; set; }
    public Company? Company { get; set; }
}
