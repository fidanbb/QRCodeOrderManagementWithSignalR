using Microsoft.AspNetCore.Identity;
using SignalR.DataAccessLayer.Concrete;
using SignalR.EntityLayer.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<SignalRContext>();
builder.Services.AddIdentity<AppUser,AppRole>()
                .AddEntityFrameworkStores<SignalRContext>()
                .AddDefaultTokenProviders();
builder.Services.AddHttpClient();

builder.Services.Configure<IdentityOptions>(options =>
{
	options.Password.RequireNonAlphanumeric = true;
	options.Password.RequireDigit = true;
	options.Password.RequireLowercase = true;
	options.Password.RequireUppercase = true;
	options.Password.RequiredLength = 6;

	options.User.RequireUniqueEmail = true;

	options.SignIn.RequireConfirmedEmail = false;

	// Default Lockout settings.
	options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
	options.Lockout.MaxFailedAccessAttempts = 5;
	options.Lockout.AllowedForNewUsers = true;
});

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
