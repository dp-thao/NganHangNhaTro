using Microsoft.EntityFrameworkCore;
using NganHangNhaTro.Models;
using NganHangNhaTro.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<dbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUserRepository, UserRepository>();

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
    pattern: "{controller=home}/{action=index}/{id?}");

app.Run();
