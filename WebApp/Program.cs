using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models.Entities;
using WebApp.Services;
using WebApp.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Lägg till DbContext med connection string från appsettings.json
var env = builder.Environment;

var connectionString = env.IsDevelopment()
    ? builder.Configuration.GetConnectionString("DefaultConnection")  // LocalDB
    : builder.Configuration.GetConnectionString("AzureConnection");   // Azure

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));


// Lägg till Identity och koppla till vår ApplicationUser och DbContext
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<AccountService>();


builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Auth/Login"; // path till login
});


// Lägg till MVC
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ProjectService>();
builder.Services.AddScoped<ProjectRepository>();



var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=projects}/{action=Index}/{id?}");

app.Run();