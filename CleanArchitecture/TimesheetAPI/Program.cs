using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Service.Implementations;
using Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(opt => 
opt.UseMySql(builder.Configuration.GetConnectionString("MYSQL"),
ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MYSQL"))));

builder.Services.AddScoped<ICategoriesService, CategoriesService>();
builder.Services.AddScoped<IClientsService, ClientsService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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
