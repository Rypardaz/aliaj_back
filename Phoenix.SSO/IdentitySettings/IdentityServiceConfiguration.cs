using System.Security.Claims;
using IdentityServer4.Models;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Phoenix.SSO.IdentitySettings;

public class IdentityServiceConfiguration
{
    private const string PhoenixCoreApi = "PhoenixCoreApi";
    private const string UserManagementApi = "UserManagementApi";

    private readonly IConfiguration _configuration;

    public IdentityServiceConfiguration(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public static IEnumerable<ApiScope> ApiScopes()
    {
        return new List<ApiScope>
        {
            new(PhoenixCoreApi, "سیستم اصلی"),
            new(UserManagementApi, "مدیریت کاربران")
        };
    }

    public static IEnumerable<Client> Clients(int tokenExpiryTime, string[] allowedOrigins)
    {
        return new List<Client>
        {
            new()
            {
                ClientId = "PhoenixClientCode",
                ClientName = "سامانه کنترل تولید",
                ClientSecrets = { new Secret("4568_!*&^^%".Sha256()) },
                AllowedGrantTypes = GrantTypes.Code,

                RedirectUris = { "http://localhost:4200/#/challange" },
                FrontChannelLogoutUri = "https://localhost:5001/signout-oidc",
                PostLogoutRedirectUris = { "http://localhost:4200" },

                //RedirectUris = { "http://192.168.2.21:8083/#/challange" },
                //FrontChannelLogoutUri = "http://192.168.2.21:8080/signout-oidc",
                //PostLogoutRedirectUris = { "http://192.168.2.21:8083" },

                IdentityTokenLifetime = tokenExpiryTime,
                AuthorizationCodeLifetime = tokenExpiryTime,
                AccessTokenLifetime = tokenExpiryTime,
                AllowedCorsOrigins = allowedOrigins,
                AllowOfflineAccess = true,
                ClientClaimsPrefix = "",
                AllowedScopes =
                {
                    "openid",
                    "profile",
                    PhoenixCoreApi,
                    UserManagementApi
                },
                AlwaysIncludeUserClaimsInIdToken = true,
                AlwaysSendClientClaims = true
            },
            new()
            {
                ClientId = "PhoenixClientPassword",
                ClientName = "Phoenix Angular Client",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                AllowAccessTokensViaBrowser = true,
                IdentityTokenLifetime = tokenExpiryTime,
                AuthorizationCodeLifetime = tokenExpiryTime,
                AccessTokenLifetime = tokenExpiryTime,
                AllowedCorsOrigins = allowedOrigins,
                AllowedScopes =
                {
                    "openid",
                    "profile",
                    PhoenixCoreApi,
                    UserManagementApi
                },
                AlwaysIncludeUserClaimsInIdToken = true,
                AlwaysSendClientClaims = true,
                AllowOfflineAccess = true,
                ClientSecrets = new List<Secret> { new("4568_!*&^^%".Sha256()) }
            }
        };
    }

    public static IEnumerable<IdentityResource> IdentityResources()
    {
        return new List<IdentityResource>
        {
            new IdentityResources.OpenId
            {
                UserClaims = new[]
                {
                    "id",
                    ClaimTypes.Role,
                    ClaimTypes.Email,
                    "Guid"
                }
            },
            new IdentityResources.Profile(),
            new IdentityResources.Email()
        };
    }
}