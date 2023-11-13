
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using OMS.Interfaces;

using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using Radzen;


    // ...

    // Add any other Radzen services as needed

    // ...



var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();


//Customer service
builder.Services.AddScoped<ICustomerService, OMS.Data.CustomerService>();
//Register dapper in scope
builder.Services.AddScoped<IDapperService, OMS.Data.DapperService>();
//Order service
builder.Services.AddScoped<IOrderService, OMS.Data.OrderService>();
//Product service
builder.Services.AddScoped<IProductService, OMS.Data.ProductService>();
builder.Services.AddScoped<IOrderDetails, OMS.Data.OrderDetailsService>();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
