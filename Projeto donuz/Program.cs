using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Projeto_donuz.AppDbContex;
using Projeto_donuz.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlite("Data source = Projeto donuz"));
builder.Services.AddScoped<IClienteRepositories, ClienteRepositories>();
builder.Services.AddControllers();
builder.Services.AddScoped<ITransacaoRepository, TransacaoRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
