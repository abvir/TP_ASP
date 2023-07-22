using App.Data;
using App.Data.Models;

namespace App.RepositoryData;

public class Repository : IRepository
{
    private ApiContext context;
     
    public Repository()
    {
        
        context = new ApiContext();
        context.Companies.AddRange(
                    Enumerable
                    .Range(1, 2)
                    .Select(c => new Company()
                    {
                        Name = $"Company name #{c}",
                        City = $"City#{c}",
                        State = $"State#{c}",
                        Address = $"{c}\'th street",
                        Phone = $"({Random.Shared.Next(100, 1000)})-{Random.Shared.Next(100, 1000)}-{Random.Shared.Next(1000, 10000)}",
                        Employees = Enumerable
                        .Range(1, 3)
                        .Select(e => new Employee()
                        {
                            LastName = $"LName{e}",
                            FirstName = $"FName{e}",
                            Birthday = new DateTime(1970, 01, 01).AddYears(Random.Shared.Next(0, 35)),
                            CompanyId = c,
                            Position = $"Position #{e}",
                            Title = (Title)Random.Shared.Next(0, Enum.GetValues<Title>().Length),
                            Notes = Enumerable.Range(1, Random.Shared
                            .Next(2, 3))
                            .Select(n => new Note()
                            {
                                CompanyId = c,
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

                ); ;
        context.SaveChanges();
    }

    public IEnumerable<CompanyRow> GetCompanyRows()
    {
       return context.Companies.Select(s => new CompanyRow(s.Id, s.Name, s.City, s.State, s.Phone));
    }
}
