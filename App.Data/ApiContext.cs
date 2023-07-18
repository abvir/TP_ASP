using App.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Data;

public class ApiContext : DbContext
{
    public DbSet<Company> Companies { get; set; } = null!;
    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<Order> History { get; set; } = null!;
    public DbSet<Note> Notes { get; set; } = null!;


    protected override void OnConfiguring(DbContextOptionsBuilder builder)
            => builder.UseInMemoryDatabase(databaseName: "CompanyDb");

    public ApiContext()
    {

        Database.EnsureCreated();
        Creating();
    }

    void Creating()
    {
        Companies.AddRange(
                Enumerable
                .Range(0, 2)
                .Select(c => new Company()
                {
                    CompanyName = $"Company name #{c}",
                    City = $"City#{c}",
                    State = $"State#{c}",
                    Address = $"{c}\'th street",
                    Phone = $"({Random.Shared.Next(100, 1000)})-{Random.Shared.Next(100, 1000)}-{Random.Shared.Next(1000, 10000)}",
                    Employees = Enumerable
                    .Range(0, 2)
                    .Select(e => new Employee()
                    {
                        LastName = $"LName{e}",
                        FirstName = $"FName{e}",
                        Birthday = new DateTime(1970, 01, 01).AddYears(Random.Shared.Next(0, 35)),
                        CompanyId = c,
                        Position = $"Position #{e}",
                        Title = (Title)Random.Shared.Next(0, Enum.GetValues<Title>().Length),
                        Notes = Enumerable.Range(1, Random.Shared
                        .Next(0, 2))
                        .Select(n => new Note()
                        {
                            EmployeeId = e,
                            InvoiceNumber = Random.Shared.Next(30000, 35000)
                        }).ToList()
                    }).ToList(),
                    Orders = Enumerable
                    .Range(1, 2)
                    .Select(o => new Order()
                    {
                        City = $"OrderCity{o}",
                        Date = new DateTime(2022, 01, 01).AddDays(Random.Shared.Next(0, 365)),
                        CompanyId = c
                    }).ToList()
                }).ToList()

            );
        SaveChanges();
    }
}
