using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BasketballStore.Data;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Cookies;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
}
)
    .AddCookie()
    .AddGoogle(GoogleDefaults.AuthenticationScheme, option =>
    {
        option.ClientId = builder.Configuration.GetSection("GoogleKeys:ClientId").Value;
        option.ClientSecret = builder.Configuration.GetSection("GoogleKeys:ClientSecret").Value;
    });

builder.Services.AddDbContext<BasketballStoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BasketballStoreContext") ?? throw new InvalidOperationException("Connection string 'BasketballStoreContext' not found.")));


// Add services to the container.
builder.Services.AddControllersWithViews();

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
