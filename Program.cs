using Accounts.Repositories;
using Accounts.Repositories.Command;
using Accounts.Services;
using Accounts.Services.Command;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Procurement.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

/*builder.Services.AddMvc()
            .AddJsonOptions(options => options.JsonSerializerOptions.TypeInfoResolver = new DefaultContractResolver());*/

builder.Services.AddSingleton<IFiscalPeriods, FiscalRepository>();
builder.Services.AddScoped<IFiscalPeriodCommands, FiscalCommandRepo>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Accounts}/{action=GetAllAccounts}/{id?}");
app.MapRazorPages();

app.Run();
