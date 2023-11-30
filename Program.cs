
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using OMS.Interfaces;
using OMS.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using Radzen;
using OMS.Entities;
using Radzen.Blazor;



// ...

// Add any other Radzen services as needed

// ...



var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();


//Customer service
builder.Services.AddScoped<ICustomerService, CustomerService>();
//User service
builder.Services.AddScoped<IUserService, UserService>();
//Register dapper in scope
builder.Services.AddScoped<IDapperService, DapperService>();
//Order service
builder.Services.AddScoped<IOrderService, OrderService>();
//Product service
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderDetails, OrderDetailsService>();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();

builder.Services.AddScoped<IPriceFormattingService,PriceFormattingService>();
builder.Services.AddScoped<ExampleService>();
builder.Services.AddScoped<ThemeService>();
builder.Services.AddScoped<ContextMenuService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<DownloadController>();
builder.Services.AddScoped<RevenueDataService>();




builder.Services.AddSignalR(e => e.MaximumReceiveMessageSize = 102400000);
builder.Services.AddScoped<ICategoryService,CategoryService>();
builder.Services.AddScoped<IBrandService, BrandService>();

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
app.MapControllers();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
