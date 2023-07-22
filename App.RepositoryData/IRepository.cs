using App.Data.Models;

namespace App.RepositoryData;

public interface IRepository
{
    public IEnumerable<CompanyRow> GetCompanyRows(); 
}

public record CompanyRow(int Id, string CompanyName, string City, string State, string Phone);