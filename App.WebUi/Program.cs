using App.RepositoryData;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IRepository, Repository>();
var app = builder.Build();
app.UseDefaultFiles();
app.UseStaticFiles();

app.Map("/api/companies", (IRepository repository) => repository.GetCompanyRows());
app.Map("/api/company-detail/{companyId}", (IRepository repository, int companyId) => repository.GetCompanyDetail(companyId));
app.Map("/api/company-order-history/{companyId}", (IRepository repository, int companyId) => repository.GetCompanyOrderHistoryRows(companyId));
app.Map("/api/company-notes/{companyId}", (IRepository repository, int companyId) => repository.GetCompanyNoteRows(companyId));
app.Map("/api/company-employees/{companyId}", (IRepository repository, int companyId) => repository.GetCompanyEmployees(companyId));
app.Map("/api/employee-detail/{employeeId}", (IRepository repository, int employeeId) => repository.GetEmployeeDetail(employeeId));



app.Run();

