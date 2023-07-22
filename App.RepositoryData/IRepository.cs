using App.Data.Models;

namespace App.RepositoryData;

public interface IRepository
{
    public CompanyDetail? GetCompanyDetail(int companyId);
    public EmployeeDetail? GetEmployeeDetail(int employeeId);
    public IEnumerable<CompanyRow> GetCompanyRows(); 
    public IEnumerable<CompanyOrder> GetCompanyOrderHistoryRows(int companyId); 
    public IEnumerable<CompanyNote> GetCompanyNoteRows(int companyId);
    public IEnumerable<CompanyEmployee> GetCompanyEmployees(int companyId);
}

public record CompanyRow(int Id, string Name, string City, string State, string Phone);
public record CompanyDetail(int Id, string Name, string City, string State, string Address);
public record CompanyOrder(int Id, string Date, string City);
public record CompanyNote(int Id, string Number, string Employee);
public record CompanyEmployee(int Id, string FirstName, string LastName);
public record EmployeeDetail(int Id, string FirstName, string LastName, string Title, string Date, string Position);