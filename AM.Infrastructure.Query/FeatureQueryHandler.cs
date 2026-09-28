using PhoenixFramework.Dapper;
using PhoenixFramework.Identity;
using PhoenixFramework.Application.Query;
using AM.Infrastructure.Query.Contract.Shared;
using AM.Infrastructure.Query.Contract.Feature;

namespace AM.Infrastructure.Query;

public class FeatureQueryHandler(BaseDapperRepository dapper, IClaimHelper claimHelper)
    : IQueryHandlerAsync<string>
{
    public async Task<string> Handle()
    {
        var currentUserGuid = claimHelper.GetCurrentUserGuid();
        var result = await dapper.SelectFromSpAsync<FeatureViewModel>(QueryConstants.GetPermissions,
            new { UserGuid = currentUserGuid });

        return string.Join(",", result.Select(x => x.Title));
    }
}