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

       
        Database.EnsureDeleted();
        Database.EnsureCreated();
        
    }

    
    
}
