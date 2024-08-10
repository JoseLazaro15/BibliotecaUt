<<<<<<< HEAD
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using PracticaBiblioteca.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
=======
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using PracticaBiblioteca.Models;
>>>>>>> 4c10a11d4b25c301d0d69c9904bd3c5ce17f64d8

var builder = WebApplication.CreateBuilder(args);

// Configuración de servicios
builder.Services.AddDbContext<BibliotecaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("connectionLibrary")));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    options.AddPolicy("UserOnly", policy => policy.RequireRole("Usuario"));
});

builder.Services.AddControllersWithViews();

<<<<<<< HEAD
// Configure Entity Framework Core
var connection = builder.Configuration.GetConnectionString("connectionLibrary");
builder.Services.AddDbContext<BibliotecaContext>(options =>
    options.UseSqlServer(connection));

// Configure Authentication and Authorization
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    options.AddPolicy("UserOnly", policy => policy.RequireRole("Usuario"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
=======
var app = builder.Build();

// Configuración del middleware
>>>>>>> 4c10a11d4b25c301d0d69c9904bd3c5ce17f64d8
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

<<<<<<< HEAD
// Add authentication and authorization middleware
=======
>>>>>>> 4c10a11d4b25c301d0d69c9904bd3c5ce17f64d8
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Welcome}/{id?}");

app.Run();
