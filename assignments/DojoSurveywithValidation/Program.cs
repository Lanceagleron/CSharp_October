var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddSession();  // add this line before calling the builder.Build() method

var app = builder.Build();
app.UseSession();    // add this line before calling the app.MapControllerRoute() method
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();