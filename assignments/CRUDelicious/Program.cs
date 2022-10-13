using CRUDelicious.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();  // add this line before calling the builder.Build() method

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MyContext>(option =>
{
    option.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
}); 

var app = builder.Build();


app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseSession();    // add this line before calling the app.MapControllerRoute() method

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
