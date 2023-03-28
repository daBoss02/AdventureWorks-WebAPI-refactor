using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.EntityMethods;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AdventureWorksLt2019Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AdventureWorksLt2019Context")));

var app = builder.Build();

// ENTITY METHODS
app.MapGet("/address", AddressMethods.GetAddresses);
app.MapGet("/addressbyid", AddressMethods.GetAddressById);

app.Run();