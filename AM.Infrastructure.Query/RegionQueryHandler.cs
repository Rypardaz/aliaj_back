using PhoenixFramework.Dapper;
using PhoenixFramework.Application.Query;
using AM.Infrastructure.Query.Contract.Region;
using AM.Infrastructure.Query.Contract.Shared;

namespace AM.Infrastructure.Query;

public class RegionQueryHandler(BaseDapperRepository dapper) :
    IQueryHandlerAsync<IEnumerable<RegionViewModel>, RegionSearchModel>
{
    public async Task<IEnumerable<RegionViewModel>> Handle(RegionSearchModel searchModel) =>
        await dapper.SelectFromSpAsync<RegionViewModel>(QueryConstants.GetRegion, new
        {
            searchModel.ProvinceGuid
        });
}