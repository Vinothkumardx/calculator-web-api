using Calculatorwebapi.Database;
using Calculatorwebapi.Repository;
using Calculatorwebapi.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<Icalculator, Calculatorservice>();
builder.Services.AddScoped<Iuser, Userservice>();

builder.Services.AddCors();

builder.Services.AddControllers();
builder.Services.AddDbContext<Dbcontextclass>(options => options.UseSqlServer
(builder.Configuration.GetConnectionString(("Defaultconnection"))));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
