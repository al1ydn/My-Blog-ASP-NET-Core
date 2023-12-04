using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
// Ben ekledim - logging
using Microsoft.Extensions.Logging.Console;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Ben ekledim - logging
//builder.Logging.ClearProviders();
//builder.Logging.AddConsole();

// Add services to the container.
builder.Services.AddControllersWithViews();

//Identity için
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>(x =>
{
	x.Password.RequireNonAlphanumeric = false;
}).AddEntityFrameworkStores<Context>();

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddSession();
builder.Services.AddMvc(config =>
{
	var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

	config.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddMvc();
builder.Services.AddAuthentication(
	CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(x =>
	{
		x.LoginPath = "/UserSignIn/SignIn";
	});

builder.Services.ConfigureApplicationCookie(options =>
{
	options.Cookie.HttpOnly = true;
	options.ExpireTimeSpan = TimeSpan.FromDays(2);

	options.LoginPath = "/UserSignIn/SignIn";
	options.SlidingExpiration = true;

	options.AccessDeniedPath = "/ErrorPage/Error2";
});

builder.Services.AddAuthorization(options =>
{
	options.AddPolicy(
		"MustBeAdmin",
		new AuthorizationPolicyBuilder()
			.RequireRole("Admin")
			.Build());
});

// Ben ekledim - logging
//builder.Logging.AddSimpleConsole(i => i.ColorBehavior = LoggerColorBehavior.Disabled);

var app = builder.Build();

// Ben ekledim - logging
//app.Logger.LogInformation("Adding Routes");
//app.MapGet("/", () => "Hello World!");
//app.Logger.LogInformation("Starting the app");

// Ben ekledim - logging
//app.MapGet("/", () => "Hello World!");
//app.MapGet("/Employee", async (ILogger<Program> logger, HttpResponse response) =>
//{
//	logger.LogInformation("Testing logging in Program.cs");
//	await response.WriteAsync("Testing");
//});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1", "?code={0}");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "areas",
	pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
