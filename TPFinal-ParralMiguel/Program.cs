global using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using TPFinal_ParralMiguel.Context;
using TPFinal_ParralMiguel.Models;
using TPFinal_ParralMiguel.Controllers;


var builder = WebApplication.CreateBuilder(args);

    //Metodo de autenticacion de cookies
    builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
    {
    //Path o direccion del login
    option.LoginPath = "/Login/Index";
    //Vencimiento del tiempo de sesion 
    option.ExpireTimeSpan = TimeSpan.FromMinutes(15);
    //Al no tener acceso a una vista se redirige al usuario a la siguiente vista
    option.AccessDeniedPath = "/Home/Index";
    });

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddSqlServer<ComandasContext>(builder.Configuration.GetConnectionString("ConexionBBDD"));

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
