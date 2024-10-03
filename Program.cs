using amartech.Data;
using amartech.Repositories;
using amartech.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

var accountSid = builder.Configuration["Twilio:AccountSid"];
var authToken = builder.Configuration["Twilio:AuthToken"];
var fromWhatsAppNumber = builder.Configuration["Twilio:FromWhatsAppNumber"];
var toWhatsAppNumber = builder.Configuration["Twilio:ToWhatsAppNumber"];

if (string.IsNullOrEmpty(accountSid) || string.IsNullOrEmpty(authToken) || string.IsNullOrEmpty(fromWhatsAppNumber) || string.IsNullOrEmpty(toWhatsAppNumber))
{
    throw new InvalidOperationException("Twilio configuration values are not set correctly.");
}

builder.Services.AddScoped<WhatsAppService>(provider =>
    new WhatsAppService(accountSid, authToken, fromWhatsAppNumber, toWhatsAppNumber));

builder.Services.AddScoped<RequestPricingRepository>();
builder.Services.AddScoped<ContactUsRepository>();
builder.Services.AddControllersWithViews();
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
