using App.RepositoryData;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IRepository, Repository>();
var app = builder.Build();

app.UseStaticFiles();

app.Map("/api/companies", (IRepository repository) => repository.GetCompanyRows());

app.Map("/", async (HttpContext context) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.SendFileAsync("wwwroot/index.html");
});

app.Run();







