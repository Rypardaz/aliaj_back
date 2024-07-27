using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PhoenixFramework.Domain;
using PhoenixFramework.Identity;
using UserManagement.Domain.UserAgg;
using UserManagement.Persistence;

namespace Phoenix.SSO.IdentitySettings;

public class UserAuthenticationValidator : IResourceOwnerPasswordValidator
{
    public int LoginAttemptsCountLimit;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IConnectionStringBuilder _connectionStringBuilder;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IConfiguration _configuration;

    public UserAuthenticationValidator(IPasswordHasher passwordHasher,
        IConnectionStringBuilder connectionStringBuilder, IHttpContextAccessor httpContextAccessor,
        IConfiguration configuration)
    {
        _passwordHasher = passwordHasher;
        _connectionStringBuilder = connectionStringBuilder;
        _httpContextAccessor = httpContextAccessor;
        _configuration = configuration;
        LoginAttemptsCountLimit = int.Parse(_configuration["LoginAttemptsCountLimit"]);
    }

    public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
    {
        var dbContextOptionsBuilder = new DbContextOptionsBuilder<UserManagementCommandContext>();
        var dbName = context.Request.Raw["dbName"];
        var connectionString = _connectionStringBuilder.Build(dbName);
        dbContextOptionsBuilder.UseSqlServer(connectionString);
        var identityContext = new UserManagementCommandContext(dbContextOptionsBuilder.Options);

        try
        {
            var user = identityContext
                .Users
                .Include(x => x.Passwords)
                .Include(x => x.Sessions
                    .Where(x => x.IsSuccessful)
                    .Where(x => x.IsActive == EntityBase<long>.ActiveStates.Active))
                .Include(u => u.Roles)
                .FirstOrDefault(x => x.Username == context.UserName && !x.IsRemoved);

            if (user is null)
            {
                context.Result =
                    new GrantValidationResult(TokenRequestErrors.InvalidClient,
                        "مشخصات ورود اشتباه است. لطفا دوباره تلاش کنید.");
                return Task.FromResult(context.Result);
            }

            if (user.IsLocked == AuditableAggregateRootBase<int>.LockStates.Lock)
            {
                context.Result = LoginFailed("کاربر قفل شده است، لطفا به راهبر سیستم اطلاع رسانی کنید.");
                return Task.FromResult(context.Result);
            }

            if (LoginAttemptsCountReached(user))
            {
                user.Lock(user.Guid);
                identityContext.SaveChanges();
                context.Result = LoginFailed("کاربر قفل شده است، لطفا به راهبر سیستم اطلاع رسانی کنید.");
                return Task.FromResult(context.Result);
            }

            var clientIpAddress = _httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString();

            if (user.Sessions.Any(x => !x.IsExpired()))
            {
                //user.OpenSession(user.Guid, user.NationalCode, user.Fullname, user.Username, user.Company.Title,
                //    user.OrganizationChart.Title, false, clientIpAddress);
                identityContext.SaveChanges();

                context.Result = LoginFailed("کاربر با این مشخصات قبلا وارد سیستم شده است.");
                return Task.FromResult(context.Result);
            }

            var userPassword = user.Passwords
                .First(x => x.IsActive == EntityBase<long>.ActiveStates.Active);

            var (verified, _) = _passwordHasher.Check(userPassword.Password, context.Password);

            if (!verified)
            {
                user.LoginFailed();
                if (LoginAttemptsCountReached(user))
                {
                    user.Lock(user.Guid);
                    identityContext.SaveChanges();
                    context.Result = LoginFailed("کاربر قفل شده است، لطفا به راهبر سیستم اطلاع رسانی کنید.");
                    return Task.FromResult(context.Result);
                }

                //user.OpenSession(user.Guid, user.NationalCode, user.Fullname, user.Username, user.Company.Title,
                //    user.OrganizationChart.Title, false, clientIpAddress);
                identityContext.SaveChanges();

                context.Result = LoginFailed("مشخصات ورود اشتباه است. لطفا دوباره تلاش کنید.");
                return Task.FromResult(context.Result);
            }

            var tokenExpiryTime = int.Parse(_configuration["TokenExpiryTime"]);
            //user.OpenSession(user.Guid, user.NationalCode, user.Fullname, user.Username, user.Company.Title,
            //    user.OrganizationChart.Title, true, clientIpAddress, tokenExpiryTime);

            var firstLogin = identityContext.Users
                .Where(x => x.Guid == user.Guid)
                .SelectMany(x => x.Sessions)
                .Any(x => x.IsSuccessful) == false;

            var shouldChangePassword = firstLogin || userPassword.IsExpired();

            if (shouldChangePassword)
                user.ShouldChangePassword();
            else
                user.PasswordRenewed();

            user.ResetFailedLoginAttempts(user.Guid);
            identityContext.SaveChanges();

            context.Result = new GrantValidationResult(user.Id.ToString(), "Bearer", DateTime.Now,
                new List<Claim>
                {
                    new("id", user.Guid.ToString()),
                    new("role", string.Join(",", user.Roles.Select(x => x.RoleId))),
                    new("dbName", dbName),
                    //new("organizationChartGuid", user.OrganizationChart.Guid.ToString())
                });

            return Task.FromResult(context.Result);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }
    }

    private bool LoginAttemptsCountReached(User user)
    {
        return user.FailedLoginAttempts >= LoginAttemptsCountLimit;
    }

    private static GrantValidationResult LoginFailed(string message)
    {
        return new GrantValidationResult(TokenRequestErrors.InvalidClient, message)
        {
            CustomResponse = new Dictionary<string, object> { { "a", "500" } }
        };
    }
}