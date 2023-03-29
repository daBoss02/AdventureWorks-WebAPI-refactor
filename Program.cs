using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.EntityMethods;
using System;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AdventureWorksLt2019Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AdventureWorksLt2019Context")));

var app = builder.Build();

// Product METHODS
app.MapGet("/product", ProductMethods.GetProducts);
app.MapGet("/productbyid", ProductMethods.GetProductById);
app.MapDelete("/product/delete", ProductMethods.DeleteProduct);
app.MapPost("/product", ProductMethods.CreateProduct);
app.MapPut("/product/update", ProductMethods.UpdateProduct);

// Customer METHODS
app.MapGet("/customer", CustomerMethods.GetCustomers);
app.MapGet("/customerbyid", CustomerMethods.GetCustomerById);
app.MapDelete("/customer/delete", CustomerMethods.DeleteCustomer);
app.MapPost("/customer", CustomerMethods.CreateCustomer);


// Address METHODS
app.MapGet("/address", AddressMethods.GetAddresses);
app.MapGet("/addressbyid", AddressMethods.GetAddressById);
app.MapDelete("/address/delete", AddressMethods.DeleteAddress);
app.MapPost("/address", AddressMethods.CreateAddress);

// Sales Order Header METHODS
app.MapGet("/salesheader", SalesOrderHeaderMethods.GetSalesOrderHeaders);
app.MapGet("/salesheaderbyid", SalesOrderHeaderMethods.GetSalesOrderHeaderById);
app.MapDelete("/salesheader/delete", SalesOrderHeaderMethods.DeleteSalesOrderHeader);

app.Run();