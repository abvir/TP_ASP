using App.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IRepository, Repository>();
var app = builder.Build();

app.UseStaticFiles();

app.Map("/api/companies", (IRepository repository) => repository.Companies);

app.Map("/", async (HttpContext context, IRepository repository) =>
    {
        context.Response.ContentType = "text/html; charset=utf-8";
        await context.Response.SendFileAsync("wwwroot/index.html"); 
    });
app.Map("/detail/{id}", async (HttpContext context, IRepository repository, int id) =>
    {
        context.Response.ContentType = "text/html; charset=utf-8";
        await context.Response.SendFileAsync("wwwroot/detail.html"); 
    });

app.Run();







