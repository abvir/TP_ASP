using App.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Data;

public class ApiContext :DbContext
{
    public DbSet<Company> Companies { get; set; } = null!;
    
    
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
            => builder.UseInMemoryDatabase(databaseName:"CompanyDb");
    
}
