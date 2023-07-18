using App.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ApiContext>();
var app = builder.Build();

app.MapGet("/", (ApiContext api) => api.Companies);

app.Run();
