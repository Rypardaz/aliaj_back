using AM.Presentation.Api;
using System.IO.Compression;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using AM.Infrastructure.Config;
using AM.Presentation.Api.Controllers;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.IdentityModel.Logging;
using PhoenixFramework.Autofac;
using PhoenixFramework.Core;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Services.AddRazorPages();

builder.Services.AddLogging();
builder.Services.AddRazorPages();
builder.Services.Configure<GzipCompressionProviderOptions>
    (options => options.Level = CompressionLevel.Fastest);

builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
    options.Providers.Add<GzipCompressionProvider>();
});

builder.Services.AddHttpContextAccessor();

var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();

if (allowedOrigins is not null)
    builder.Services.AddCors(options => options
        .AddPolicy("Cors",
            builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
                .WithOrigins(allowedOrigins)
        ));

builder.Services.AddSignalR();

builder.Services.AddControllers()
    .AddApplicationPart(typeof(PartGroupController).Assembly)
    .AddNewtonsoftJson();

var jwtIssuer = builder.Configuration["Jwt:Issuer"]
                ?? throw new InvalidOperationException("Jwt:Issuer is not configured.");
var jwtAudience = builder.Configuration["Jwt:Audience"]
                  ?? throw new InvalidOperationException("Jwt:Audience is not configured.");
var jwtKey = builder.Configuration["Jwt:Key"]
             ?? throw new InvalidOperationException(
                 "Jwt:Key is not configured. Set it through user secrets or the Jwt__Key environment variable.");

if (Encoding.UTF8.GetByteCount(jwtKey) < 32)
    throw new InvalidOperationException("Jwt:Key must be at least 32 bytes long.");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.MapInboundClaims = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtIssuer,
            ValidateAudience = true,
            ValidAudience = jwtAudience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
            ValidateLifetime = true,
            ClockSkew = TimeSpan.FromSeconds(30),
            NameClaimType = JwtRegisteredClaimNames.UniqueName,
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("PhoenixCoreScope", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "PhoenixCoreApi");
    });
});

var connectionString = builder.Configuration["ApplicationConnectionString"];

if (string.IsNullOrWhiteSpace(connectionString))
    throw new Exception("Please Set Connection String");

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule<PhoenixFrameworkModule>();
    containerBuilder.RegisterModule(new AliajMonitoringModule(connectionString));
});

var app = builder.Build();
var autofacContainer = app.Services.GetAutofacRoot();
ServiceLocator.SetCurrent(new AutofacServiceLocator(autofacContainer));

app.UseResponseCompression();

app.UseStaticFiles();
app.UseDeveloperExceptionPage();
IdentityModelEventSource.ShowPII = true;

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("Cors");

app.UseAuthentication();
app.UseAuthorization();

app.ConfigureExceptionHandler();
app.UseAntiXssMiddleware();

app.MapControllers().RequireAuthorization("PhoenixCoreScope");
app.MapRazorPages();
app.MapDefaultControllerRoute();

app.Run();