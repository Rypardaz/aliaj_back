using PhoenixFramework.Application.Query;
using AM.Presentation.Facade.Contract.Region;
using AM.Infrastructure.Query.Contract.Region;

namespace AM.Presentation.Facade.Query;

public class RegionQueryFacade(IQueryBusAsync queryBus) : IRegionQueryFacade
{
    public async Task<IEnumerable<RegionViewModel>> GetList(RegionSearchModel searchModel) =>
        await queryBus.Dispatch<IEnumerable<RegionViewModel>, RegionSearchModel>(searchModel);
}