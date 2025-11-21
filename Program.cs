using Microsoft.EntityFrameworkCore;
using NoteProject.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



#region DB Context Connect to Sql server
builder.Services.AddDbContext<NoteDBContext>(options =>
{
    options.UseSqlServer("Data Source=DESKTOP-7DMA6P7;Initial Catalog=NotesDB;Integrated Security=true;TrustServerCertificate=true");
});
#endregion




builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();

app.UsePathBase("/note");   // ← فقط اینجا
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
