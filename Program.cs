using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Cookies;
using BasketballStore.Data;
using BasketballStore.Models;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BasketballStoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BasketballStoreContext") ?? throw new InvalidOperationException("Connection string 'BasketballStoreContext' not found.")));
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


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

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
