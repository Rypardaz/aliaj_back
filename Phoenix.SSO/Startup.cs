using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Phoenix.SSO.IdentitySettings;
using Phoenix.SSO.Quickstart;
using Phoenix.SSO.Validators;
using PhoenixFramework.Identity;
using UserManagement.Persistence;

namespace Phoenix.SSO;

public class Startup
{
    private IWebHostEnvironment Environment { get; }
    private IConfiguration Configuration { get; }

    public Startup(IWebHostEnvironment environment, IConfiguration configuration)
    {
        Environment = environment;
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();

        var builder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
                options.EmitStaticAudienceClaim = true;
            })
            //.AddProfileService<ProfileService>()
            .AddCustomTokenRequestValidator<CustomTokenRequestValidator>();
            // .AddTestUsers(TestUsers.Users);

        var tokenExpiryTime = int.Parse(Configuration["TokenExpiryTime"]) * 60;
        var allowedOrigins = Configuration.GetSection("AllowedOrigins").Get<string[]>();

        // in-memory, code config
        builder.AddInMemoryIdentityResources(IdentityServiceConfiguration.IdentityResources());
        builder.AddInMemoryApiScopes(IdentityServiceConfiguration.ApiScopes());
        builder.AddInMemoryClients(IdentityServiceConfiguration.Clients(tokenExpiryTime, allowedOrigins));

        // not recommended for production - you need to store your key material somewhere secure
        builder.AddDeveloperSigningCredential();

        builder.Services.AddTransient<IPasswordHasher, PasswordHasher>();
        builder.Services.AddTransient<IConnectionStringBuilder, BeautifulConnectionStringBuilder>();
        builder.Services.AddTransient<IPasswordValidator, PasswordValidator>();

        var connectionString = Configuration.GetConnectionString("Application");
        builder.Services.AddDbContext<UserManagementCommandContext>(builder =>
            builder.UseSqlServer(connectionString), ServiceLifetime.Transient);

        services.Configure<CookiePolicyOptions>(options =>
        {
            options.CheckConsentNeeded = context => false;
            options.MinimumSameSitePolicy = SameSiteMode.Lax;
        });

        services.AddAuthentication();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseStaticFiles();

        app.UseRouting();
        app.UseIdentityServer();
        app.UseCookiePolicy();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapDefaultControllerRoute();
        });
    }
}