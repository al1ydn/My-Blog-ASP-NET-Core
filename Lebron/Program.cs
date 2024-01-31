using BusinessLayer.Authentication;
using BusinessLayer.Authorization.AuthorizeAttributes.MinimumAge;
using BusinessLayer.Authorization.AuthorizeAttributes.OnlyAnonymous;
using BusinessLayer.Authorization.Customization;
using BusinessLayer.Authorization.Entities.Blog;
using BusinessLayer.Authorization.Entities.User;
using BusinessLayer.Services;
using BusinessLayer.Validation.Configuration;
using BusinessLayer.Validation.User;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Globalization;

#region build
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>();

#region identity
builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
	options.SignIn.RequireConfirmedEmail = true;
	options.User.RequireUniqueEmail = true;

	#region disable validation
	options.User.AllowedUserNameCharacters = null;
	options.Password.RequireDigit = false;
	options.Password.RequiredLength = 0;
	options.Password.RequiredUniqueChars = 0;
	options.Password.RequireLowercase = false;
	options.Password.RequireNonAlphanumeric = false;
	options.Password.RequireUppercase = false;
	#endregion
}).AddEntityFrameworkStores<Context>()
  .AddDefaultTokenProviders();

//builder.Services.AddDefaultIdentity()
//builder.Services.AddIdentityCore<AppUser>();

builder.Services.AddScoped<
	IUserClaimsPrincipalFactory<AppUser>,
	CustomClaimsPrincipalFactory>();
#endregion

builder.Services.AddControllersWithViews()
	.AddRazorRuntimeCompilation();

#region authentication
//builder.Services.AddMvc();

/*builder.Services
	.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
		.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,
			options =>
			{
				builder.Configuration.Bind("JwtSettings", options);
			})
		.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
			options =>
			{
				builder.Configuration.Bind("CookieSettings", options);
			});*/

/*builder.Services
	.AddAuthentication("Test")
		.AddCookie("Test", options =>
		{
			options.Cookie.Name = "Test";
		});*/

builder.Services.ConfigureApplicationCookie(options =>
{
	options.Cookie.HttpOnly = true;

	options.SlidingExpiration = true;
	options.ExpireTimeSpan = TimeSpan.FromDays(2);

	options.LoginPath = "/UserSignIn/SignIn";
	options.AccessDeniedPath = "/Forbidden";
	/*options.Events.OnRedirectToAccessDenied = context =>
	{
		context.Response.StatusCode = 403;

		return Task.CompletedTask;
	}*/
});
#endregion

#region authorization
builder.Services.AddAuthorization(options =>
{
	options.FallbackPolicy = new AuthorizationPolicyBuilder()
		.RequireAuthenticatedUser()
		.Build();
});

/*builder.Services.AddMvc(config =>
{
	var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

	config.Filters.Add(new AuthorizeFilter(policy));
});*/

builder.Services.AddAuthorization(options =>
{
	options.AddPolicy("OnlyAnonymous", policy =>
	{
		policy.Requirements.Add(new OnlyAnonymousRequirement());
		//policy.RequireClaim();
		//policy.RequireRole();
	});
});

builder.Services.AddScoped<IAuthorizationHandler,
						   BlogIsOwnerAuthorizationHandler>();
builder.Services.AddSingleton<IAuthorizationHandler,
							  BlogModeratorAuthorizationHandler>();
builder.Services.AddSingleton<IAuthorizationHandler,
							  BlogAdminAuthorizationHandler>();

builder.Services.AddScoped<IAuthorizationHandler,
						   UserIsOwnerAuthorizationHandler>();
builder.Services.AddSingleton<IAuthorizationHandler,
							  UserModeratorAuthorizationHandler>();
builder.Services.AddSingleton<IAuthorizationHandler,
							  UserAdminAuthorizationHandler>();

builder.Services.AddSingleton<IAuthorizationHandler,
							  MinimumAgeHandler>();
builder.Services.AddSingleton<IAuthorizationHandler,
							  OnlyAnonymousHandler>();

builder.Services.AddSingleton<IAuthorizationPolicyProvider,
							  CustomAuthorizationPolicyProvider>();

builder.Services.AddSingleton<IAuthorizationMiddlewareResultHandler,
							  CustomAuthorizationMiddlewareResultHandler>();
#endregion

builder.Services.AddSession();

#region email
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration);
#endregion

#region validation
ValidatorOptions.Global.LanguageManager = new CustomLanguageManager();
//Disable localization and set default
ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr");

/*
ValidatorOptions.Global.DisplayNameResolver = (type, member, expression) =>
{
	if (member != null)
	{
		if(member.Name == "Password")
		{
			return "Parola";
		}

		return member.Name;
	}

	return null;
};
*/

builder.Services.AddScoped<IValidator<UserAddModel>,
	UserAddModelValidator>();
builder.Services.AddScoped<IValidator<UserEditModel>,
	UserEditModelValidator>();
builder.Services.AddScoped<IValidator<UserSignInModel>,
	UserSignInModelValidator>();
builder.Services.AddScoped<IValidator<ResendConfirmationEmailViewModel>,
	ResendConfirmationEmailViewModelValidator>();
#endregion

builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
{
	options.TokenLifespan = TimeSpan.FromMinutes(10);
});

#region localization
builder.Services.AddLocalization(options =>
options.ResourcesPath = "Resources");

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
	var supportedCultures = new[] { "tr" };
	options.SetDefaultCulture(supportedCultures[0])
		.AddSupportedCultures(supportedCultures)
		.AddSupportedUICultures(supportedCultures);
});
#endregion

var app = builder.Build();
#endregion

#region use
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseStatusCodePagesWithReExecute(
	"/StatusCodePages", 
	"?statusCode={0}");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseSession();

app.UseRequestLocalization();
#endregion

#region route
app.MapControllerRoute(
	name: "areas",
	pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");
#endregion

app.Run();
