using GerenciadorBLContainer;
using Microsoft.EntityFrameworkCore;

// Sérgio Wu (CB3025691)
// Leonardo de Lima (CB3026655)
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<GerenciadorBLContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=BLs}/{action=Index}/{id?}");
app.Run();
