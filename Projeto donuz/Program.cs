using Microsoft.EntityFrameworkCore;
using Projeto_donuz.Model;
using Projeto_donuz.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ClienteContext>(x => x.UseSqlite("Data source = Projeto donuz"));
builder.Services.AddScoped<IClienteRepositories, ClienteRepositories>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseEndpoints(Endpoint =>
{
Endpoint.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action/{id?}",
    defaults: new { controller = "Home", Action = "Index" });

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
