using Microsoft.EntityFrameworkCore;
using NToastNotify;
using ShoppingCart.Data;
using ShoppingCart.Models;
using ShoppingCart.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using ShoppingCart.Utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ShoppingCartContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CRUDApiContext") ?? throw new InvalidOperationException("Connection string 'CRUDApi1Context' not found.")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ShoppingCartContext>().AddDefaultTokenProviders();
builder.Services.AddScoped<IRepository<Category>, Repository<Category>>();
builder.Services.AddScoped<IRepository<Product>, Repository<Product>>();
builder.Services.AddScoped<IRepository<Company>, Repository<Company>>();
builder.Services.AddScoped<IRepository<Cart>, Repository<Cart>>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddScoped<IRepository<State>, Repository<State>>();
builder.Services.AddScoped<IRepository<City>, Repository<City>>();

//Add Toast notification service
builder.Services.AddRazorPages().AddNToastNotifyNoty(new NotyOptions
{
    ProgressBar = true,
    Timeout = 2000
});


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
app.UseAuthentication();;

app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
