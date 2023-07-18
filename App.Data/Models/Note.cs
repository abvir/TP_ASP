using System.ComponentModel.DataAnnotations;

namespace App.Data.Models;

public class Note
{
    public int Id { get; set; }


    public int InvoiceNumber { get; set;}


    public int EmployeeId { get; set; }

}
