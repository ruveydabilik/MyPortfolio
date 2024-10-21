// EF Core'u veritabaný iþlemleri için kullanýyoruz.
// EF Core Design ve tools paketleri code first iþlemleri için (migration) kullanýlacak olan paket
// EF Core SQL Server, SQL'e iþlemleri yansýtabilmek için kullanýlacak

using Microsoft.EntityFrameworkCore;
using MyPortfolio.DAL.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile("config.json", optional: true, reloadOnChange: true);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Veritabaný baðlantýsýný config.json'dan al
builder.Services.AddDbContext<MyPortfolioContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
