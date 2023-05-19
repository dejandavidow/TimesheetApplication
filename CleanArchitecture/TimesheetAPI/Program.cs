using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.MembersService;
using Infrastructure.Models;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Identity;
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
opt.UseSqlServer(builder.Configuration.GetConnectionString("MSSQL")));

/*builder.Services.AddDbContext<ApplicationDbContext>(opt =>
opt.UseMySql(builder.Configuration.GetConnectionString("MYSQL"),
ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MYSQL"))));*/

builder.Services.AddIdentity<Member, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddScoped<ICategoriesService, CategoriesService>();
builder.Services.AddScoped<IClientsService, ClientsService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IMembersService, MembersService>();  

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(opt => opt.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
