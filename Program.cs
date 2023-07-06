using Accounts.Repositories;
using Accounts.Repositories.Command;
using Accounts.Services;
using Accounts.Services.Command;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Accounts.Data;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddSingleton<IFiscalPeriods, FiscalRepository>();
builder.Services.AddScoped<IFiscalPeriodCommands, FiscalCommandRepo>();

//GeneralLedgerAccounts
builder.Services.AddScoped<IGeneralLedgerAccountsCommand, GeneralLedgerAccountsCommandRepo>();
builder.Services.AddScoped<IGeneralLedgerAccountsQuery, GeneralLedgerAccountsQueryRepo>();

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
    pattern: "{controller=Accounts}/{action=GeneralLedgerAccounts}/{id?}");
app.MapRazorPages();

app.Run();
