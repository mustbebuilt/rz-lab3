using System.Globalization;
using Microsoft.EntityFrameworkCore;
using rz.Data;

// Set default culture to en-GB so currency and date formatting match the lab tutorial (£)
var cultureInfo = new CultureInfo("en-GB");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

var builder = WebApplication.CreateBuilder(args);

// Register SQLite DbContext service with Dependency Injection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddRazorPages();

// -----------------------------------------------------------------------------
// LAB 3: Database & Service Registration
// -----------------------------------------------------------------------------
// Once you complete Step 01 of the tutorial, you will:
// 1. Install the NuGet package:
//    dotnet add package Microsoft.EntityFrameworkCore.Sqlite
// 2. Create Models/Staff.cs and Data/ApplicationDbContext.cs
// 3. Uncomment the following lines to register ApplicationDbContext:
//
// using Microsoft.EntityFrameworkCore;
// using MyRazorApp.Data;
// builder.Services.AddDbContext<ApplicationDbContext>(options =>
//     options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
// -----------------------------------------------------------------------------



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

