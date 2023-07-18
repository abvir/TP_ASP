using App.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IRepository, Repository>();
var app = builder.Build();

app.MapGet("/", (IRepository rep) => {
    return rep.Companies;
    });

app.Run();
