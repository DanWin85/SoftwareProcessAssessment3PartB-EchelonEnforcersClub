
using EchelonEnforcers.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);




builder.Services.AddDbContext<NewsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NewsDbContext") ?? throw new InvalidOperationException("Connection string 'NewsDbContext' not found.")));
builder.Services.AddDbContext<CompetitionsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CompetitionsDbContext") ?? throw new InvalidOperationException("Connection string 'CompetitionsDbContext' not found.")));
builder.Services.AddDbContext<CompetitionsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CompetitionsDbContext") ?? throw new InvalidOperationException("Connection string 'CompetitionsDbContext' not found.")));
builder.Services.AddDbContext<NewsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NewsDbContext") ?? throw new InvalidOperationException("Connection string 'NewsDbContext' not found.")));

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapControllerRoute(
    name: "Members Area",
    pattern: "{controller=MembersArea}/{action=Index}/{id?}");


app.MapRazorPages();

app.Run();
