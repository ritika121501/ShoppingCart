using Microsoft.EntityFrameworkCore;
using NToastNotify;
using ShoppingCart.Data;
using ShoppingCart.Models;
using ShoppingCart.Repository;

var builder = WebApplication.CreateBuilder(args);
//Add Toast notification services
builder.Services.AddScoped<IRepository<Category>, Repository<Category>>();
builder.Services.AddScoped<IRepository<Product>, Repository<Product>>();
builder.Services.AddRazorPages().AddNToastNotifyNoty(new NotyOptions
{
    ProgressBar = true,
    Timeout = 5000,
    Theme = "mint"
});



// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ShoppingCartContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CRUDApi1Context") ?? throw new InvalidOperationException("Connection string 'CRUDApi1Context' not found.")));
//builder.Services.AddScoped<IRepository<Category>, Repository<Category>>();
//builder.Services.AddScoped<IRepository<Product>, Repository<Product>>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
